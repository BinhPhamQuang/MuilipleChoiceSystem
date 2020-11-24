using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.DAO
{
    class UserDAO
    {
        private static UserDAO instance;
        public static UserDAO Instance
        {
            get { if (instance == null) instance = new UserDAO(); return UserDAO.instance; }
            private set { UserDAO.instance = value; }
        }
        private UserDAO() { }
        public bool getUser(string username, string password)
        {
            string query= $"select * from SYSTEMUSER JOIN ACCOUNT on userID=uID JOIN DEPARTMENT on DEPARTMENT.Dcode= SYSTEMUSER.Dcode where Username='{username}' and AccountPassword='{password}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count != 0)
            {
                
                DataRow r = result.Rows[0];
                UserDTO.Instance.FirstName = r["FirstName"].ToString();
                UserDTO.Instance.LastName = r["LastName"].ToString();
                UserDTO.Instance.Address = r["UserAddress"].ToString();
                UserDTO.Instance.sex = r["Sex"].ToString();
                UserDTO.Instance.UserType = r["UserType"].ToString().Trim();
                UserDTO.Instance.DepartmentCode = r["Dcode"].ToString();
                UserDTO.Instance.userID = r["uID"].ToString();
                UserDTO.Instance.DepartmentName = r["Dname"].ToString();
                return true;
            }

            return false;
         
        }
    }
}
