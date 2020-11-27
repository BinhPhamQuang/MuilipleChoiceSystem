using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.DAO
{

    class CourseDAO
    {
        private static CourseDAO instance;
        public static CourseDAO Instance
        {
            get { if (instance == null) instance = new CourseDAO(); return CourseDAO.instance; }
            private set { CourseDAO.instance = value; }
        }
        private CourseDAO() { }

        public List<ExamDTO> getExam(string idCourse)
        {
            List<ExamDTO> lst = new List<ExamDTO>();
            string query = $"select * from EXAM JOIN COURSE on EXAM.courseID= course.courseID JOIN SYSTEMUSER on uid=course.IDheader WHERE EXAM.COURSEID='{idCourse}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                ExamDTO t = new ExamDTO();
                t.courseID = i["courseid"].ToString().Trim();
                t.examID = i["eid"].ToString().Trim();
                t.testDate = (DateTime)i["testday"];
                t.AcademyYear = int.Parse(i["academyyear"].ToString());
                t.courseName = i["coursename"].ToString().Trim();
                t.teacherCreate = i["firstname"].ToString().Trim() +" "+ i["lastname"].ToString().Trim();
                lst.Add(t);
        }

            return lst;
        }

        public List<CourseDTO> getAllCourse()
        {
            List<CourseDTO> lst = new List<CourseDTO>();

            string query = "select * from course JOIN teach on teach.courseID=course.courseID JOIN SYSTEMUSER on userID= uID";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow i in result.Rows)
            {
                CourseDTO t = new CourseDTO();
                t.CourseID = i["courseID"].ToString().Trim();
                t.LecturerName = i["FirstName"].ToString().Trim() + " " + i["LastName"].ToString().Trim();
                t.idLecturer = i["userID"].ToString().Trim();
                t.idheader = i["IDheader"].ToString().Trim();
                t.CourseName = i["CourseName"].ToString().Trim();
                t.idmanager = i["IDmngLecturer"].ToString().Trim();

                lst.Add(t);
            }
            return lst;
        }

        public List<CourseDTO> getAllCourseByID(string id)
        {
            List<CourseDTO> lst = new List<CourseDTO>();

            string query = $"select * from course JOIN teach on teach.courseID=course.courseID JOIN SYSTEMUSER on userID= uID where course.courseID='{id}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                CourseDTO t = new CourseDTO();
                t.CourseID = i["courseID"].ToString().Trim();
                t.LecturerName = i["FirstName"].ToString().Trim() + " " + i["LastName"].ToString().Trim();
                t.idLecturer = i["userID"].ToString().Trim();
                t.idheader = i["IDheader"].ToString().Trim();
                t.CourseName = i["CourseName"].ToString().Trim();
                t.idmanager = i["IDmngLecturer"].ToString().Trim();

                lst.Add(t);
            }
            return lst;
        }
    }
}
