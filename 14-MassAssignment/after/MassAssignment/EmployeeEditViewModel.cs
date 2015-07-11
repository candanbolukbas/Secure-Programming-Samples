using System;
using System.ComponentModel;

namespace MassAssignment
{
    public class EmployeeEditViewModel
    {
        public int EmployeeID { get; set; }
        public string Title { get; set; }
        [DisplayName("Title Of Courtesy (Mr. / Ms.)")]
        public string TitleOfCourtesy { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        [DisplayName("Home Phone")]
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string Notes { get; set; }
    }
}