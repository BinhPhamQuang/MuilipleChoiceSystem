using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplechoiseSystem.DAO;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.DAO
{
    class SheetAnswerDAO
    {
        private static SheetAnswerDAO instance;
        public static SheetAnswerDAO Instance
        {
            get { if (instance == null) instance = new SheetAnswerDAO(); return SheetAnswerDAO.instance; }
            private set { SheetAnswerDAO.instance = value; }
        }
        private SheetAnswerDAO() { }
        public List<SheetDTO> getAllSheetAnswer(string examId, string courseID)
        {
            List<SheetDTO> lst = new List<SheetDTO>();
            string query = $"select * from SHEET_ANSWER join systemuser on userID=uID where examID='{examId}' and CourseID='{courseID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                SheetDTO t = new SheetDTO();
                t.examID = examId;
                t.courseID = courseID;
                t.CodeTest = i["codeTest"].ToString().Trim();
                t.DateTake = (DateTime)i["DateTake"];
                t.Fullname = i["FirstName"].ToString().Trim() + " " + i["LastName"].ToString().Trim();
                t.Marks = i["Marks"].ToString().Trim();
                t.userID = i["userID"].ToString().Trim();
                lst.Add(t);
            }
            return lst;
        }

        public List<SheetDTO> getSheetAnswerByIduser(string examId, string courseID, string idUser)
        {
            List<SheetDTO> lst = new List<SheetDTO>();
            string query = $"select * from SHEET_ANSWER join systemuser on userID=uID where examID='{examId}' and CourseID='{courseID}' and userID='{idUser}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                SheetDTO t = new SheetDTO();
                t.examID = examId;
                t.courseID = courseID;
                t.CodeTest = i["codeTest"].ToString().Trim();
                t.DateTake = (DateTime)i["DateTake"];
                t.Fullname = i["FirstName"].ToString().Trim() + " " + i["LastName"].ToString().Trim();
                t.Marks = i["Marks"].ToString().Trim();
                t.userID = idUser;
                lst.Add(t);
            }
            return lst;
        }
    }
}
