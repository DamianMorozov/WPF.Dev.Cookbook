using System.Runtime.Serialization;

namespace CH09.EmployeeService.DataModels
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Designation { get; set; }
    }
}