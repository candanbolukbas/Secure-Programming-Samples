using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MassAssignment
{
    public static class IQueryableExtensions
    {
        public static IQueryable<dynamic> SelectPartially<T>(this IQueryable<T> source, IEnumerable<string> propertyNames)
        {
            if (source == null) throw new ArgumentNullException("Source Object is NULL");

            //Prepare ParameterExpression refering to the source object
            var sourceItem = Expression.Parameter(source.ElementType, "t");

            //Get PropertyInfos from Source Object (Filter all Misspelled Property-Names)
            var sourceProperties = propertyNames.Where(name => source.ElementType.GetProperty(name) != null).ToDictionary(name => name, name => source.ElementType.GetProperty(name));

            //Build dynamic a Class that includes the Fields (no inheritance, no interfaces)
            var dynamicType = DynamicTypeBuilder.GetDynamicType(sourceProperties.Values.ToDictionary(f => f.Name, f => f.PropertyType), typeof(object), Type.EmptyTypes);

            //Create the Binding Expressions
            var bindings = dynamicType.GetFields().Select(p => Expression.Bind(p, Expression.Property(sourceItem, sourceProperties[p.Name]))).OfType<MemberBinding>().ToList();

            //Create the Projection
            var selector = Expression.Lambda<Func<T, dynamic>>(Expression.MemberInit(Expression.New(dynamicType.GetConstructor(Type.EmptyTypes)), bindings), sourceItem);

            //Now Select and return the IQueryable object
            return source.Select(selector);
        }
    }
}