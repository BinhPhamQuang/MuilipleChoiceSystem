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
               
                
                UserDTO.Instance.sex = r["Sex"].ToString().Trim();
                UserDTO.Instance.UserType = r["UserType"].ToString().Trim();
                UserDTO.Instance.DepartmentCode = r["Dcode"].ToString().Trim();
                UserDTO.Instance.userID = r["uID"].ToString().Trim().Trim();
                UserDTO.Instance.DepartmentName = r["Dname"].ToString().Trim();
                UserDTO.Instance.Username = username;
                UserDTO.Instance.password = password;
                try
                {
                    UserDTO.Instance.FirstName = r["FirstName"].ToString().Trim();
                    UserDTO.Instance.LastName = r["LastName"].ToString().Trim();
                    UserDTO.Instance.Address = r["UserAddress"].ToString().Trim();
                    UserDTO.Instance.DateOfBirth = (DateTime)r["DateOfBirth"];
                   
                }
                catch(Exception e)
                {

                }
                return true;
            }

            return false;
         
        }

        public List<CourseDTO> getCourse()
        {
            List<CourseDTO> lst = new List<CourseDTO>();
            string query = $"SELECT * FROM COURSE JOIN STUDY ON COURSEID= STUDY.idCourse JOIN SYSTEMUSER on uid=IDheader WHERE idUSER= '{UserDTO.Instance.userID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow i in result.Rows )
            {
                CourseDTO t = new CourseDTO();
                t.CourseID = i["courseID"].ToString().Trim();
                t.CourseName = i["coursename"].ToString().Trim();
                t.idheader = i["idheader"].ToString().Trim();
                t.idmanager = i["idmnglecturer"].ToString().Trim();
                t.LecturerName = i["firstname"].ToString().Trim() + " " + i["lastname"].ToString().Trim();
                lst.Add(t);
            }
            return lst;
        }
        public List<CourseDTO> getCourseTeacher()
        {
            List<CourseDTO> lst = new List<CourseDTO>();
            string query = $"SELECT * FROM COURSE JOIN STUDY ON COURSEID= STUDY.idCourse JOIN SYSTEMUSER on uid=IDheader WHERE idUSER= '{UserDTO.Instance.userID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                CourseDTO t = new CourseDTO();
                t.CourseID = i["courseID"].ToString().Trim();
                t.CourseName = i["coursename"].ToString().Trim();
                t.idheader = i["idheader"].ToString().Trim();
                t.idmanager = i["idmnglecturer"].ToString().Trim();
                t.LecturerName = i["firstname"].ToString().Trim() + " " + i["lastname"].ToString().Trim();
                lst.Add(t);
            }
            return lst;
        }


        public List<CourseDTO> getCourseTeachByTeacher()
        {
            List<CourseDTO> lst = new List<CourseDTO>();
            string query = $"SELECT * FROM COURSE JOIN TEACH ON COURSE.courseID= TEACH.courseID JOIN SYSTEMUSER on uid=IDheader WHERE userID= '{UserDTO.Instance.userID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                CourseDTO t = new CourseDTO();
                t.CourseID = i["courseID"].ToString().Trim();
                t.CourseName = i["coursename"].ToString().Trim();
                t.idheader = i["idheader"].ToString().Trim();
                t.idmanager = i["idmnglecturer"].ToString().Trim();
                t.LecturerName = i["firstname"].ToString().Trim() + " " + i["lastname"].ToString().Trim();
                lst.Add(t);
            }
            return lst;
        }
    }
}
