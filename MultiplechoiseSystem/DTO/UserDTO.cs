using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplechoiseSystem.DTO
{
    class UserDTO
    {
        private static UserDTO instance;
        public static UserDTO Instance
        {
            get { if (instance == null) instance = new UserDTO(); return UserDTO.instance; }
            private set { UserDTO.instance = value; }
        }
        private UserDTO() { }
        public string Student = "STUDENT";
        public string Lecturer = "LECTURER";
        public string Manager = "MNGLECTURER";
        public string userID;
        public string FirstName;
        public string LastName;
        public string Address;
        public string sex;
        public DateTime DateOfBirth;
        public string DepartmentCode;
        public string UserType;
        public string DepartmentName;
    }
}
