using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfSimpleTokenExample.Business;
using WcfSimpleTokenExample.Database;

namespace WcfSimpleTokenExample.Tests.Business
{
    [TestClass]
    public class DatabaseTokenValidatorTests
    {
        [TestMethod]
        public void IsExpired30Minutes1Second()
        {
            // Arrange
            var token = new Token { CreateDate = DateTime.Now.AddSeconds(-1801) };
            var validator = new DatabaseTokenValidator(null);

            // Act 
            var actual = validator.IsExpired(token);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsExpired29Minutes59Second()
        {
            // Arrange
            var token = new Token { CreateDate = DateTime.Now.AddSeconds(-1799) };
            var validator = new DatabaseTokenValidator(null);

            // Act 
            var actual = validator.IsExpired(token);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
