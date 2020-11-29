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
        private static TestDAO instance; // Ctrl + R + E

        public static TestDAO Instance
        {
            get { if (instance == null) instance = new TestDAO(); return TestDAO.instance; }
            private set { TestDAO.instance = value; }
        }
        public List<TestDTO> getListTestByExamID_courseID(string examID, string courseID)
        {
            List<TestDTO> lst = new List<TestDTO>();
            string query = $"SELECT * from TEST where examID='{examID}' and courseID='{courseID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                TestDTO t = new TestDTO();
                t.code = i["Code"].ToString().Trim();
                t.examID = i["examID"].ToString().Trim();
                t.courseID = i["courseID"].ToString().Trim();
                t.DateAppove = (DateTime)i["DateApprove"];
                t.DateComfirm = (DateTime)i["DateConfirm"];
                lst.Add(t);
            }
            return lst;
        }
    }
}
