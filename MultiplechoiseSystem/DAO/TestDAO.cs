using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.DAO
{
    class TestDAO
    {
        private static TestDAO instance; 

        public static TestDAO Instance
        {
            get { if (instance == null) instance = new TestDAO(); return TestDAO.instance; }
            private set { TestDAO.instance = value; }
        }
        public List<TestDTO> getListTestByExamID_courseID(string examID, string courseID)
        {
            List<TestDTO> lst = new List<TestDTO>();
            string query = $"SELECT * from TEST join COURSE on COURSE.courseID= test.courseID where TEST.examID='{examID}' and TEST.courseID='{courseID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                TestDTO t = new TestDTO();
                t.code = i["Code"].ToString().Trim();
                t.examID = i["examID"].ToString().Trim();
                t.courseID = i["courseID"].ToString().Trim();
                t.DateAppove = (DateTime)i["DateApprove"];
                t.DateComfirm = (DateTime)i["DateConfirm"];
                t.corseName = i["CourseName"].ToString();
                lst.Add(t);
            }
            return lst;
        }


        public List<TestDTO> getListFullTestbyManager(string idmanager)
        {
            List<TestDTO> lst = new List<TestDTO>();

            string query = $" select * from test  join COURSE on COURSE.courseID= test.courseID where  test.courseID in (select courseID from course where IDmngLecturer='{UserDTO.Instance.userID}')       ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                 
                    TestDTO t = new TestDTO();
                    t.courseID = i["courseID"].ToString().Trim();
                    t.code = i["Code"].ToString().Trim();
                    t.DateComfirm = (DateTime)i["DateConfirm"];
                    t.examID = i["examID"].ToString().Trim();
                    t.corseName = i["CourseName"].ToString().Trim();
                try
                {
                    t.DateAppove = (DateTime)i["DateAppove1"];
                }
                catch
                {
                     
                }
                    lst.Add(t);
                
            }
            return lst;
        }
        
        

    }
}
