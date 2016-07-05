namespace CCHServer
{
    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using static EmployeeContract;
    public class EmployeeContract
    {
        [DataContract]
        public class EmployeeData
        {
            [DataMember]
            public string UserId { get; set; }
            [DataMember]
            public string Username { get; set; }
            [DataMember]
            public string Password { get; set; }
        }

        [ServiceContract]
        public interface IEmployeeService
        {
            [OperationContract]
            EmployeeData AuthenticateUser(EmployeeData employee);

        }

        public interface IEmployeeChannel : IEmployeeService, IClientChannel
        {
        }
    }

    //public class EmployeeService : IEmployeeService
    //{
    //    public EmployeeData AuthenticateUser(EmployeeData employee)
    //    {
    //        if (employee.Username == "mohsink13@gmail.com")
    //            return new EmployeeData
    //            {
    //                Username = employee.Username,
    //                UserId = "1"
    //            };
    //        else
    //            return null;
    //    }
    //}
}
