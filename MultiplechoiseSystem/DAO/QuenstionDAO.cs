using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplechoiseSystem.DTO;
using MultiplechoiseSystem.DAO;
namespace MultiplechoiseSystem.DAO
{   
    class QuenstionDAO
    {
        private static QuenstionDAO instance;
        public static QuenstionDAO Instance
        {
            get { if (instance == null) instance = new QuenstionDAO(); return QuenstionDAO.instance; }
            private set { QuenstionDAO.instance = value; }
        }
        private QuenstionDAO() { }

        public List<QuenstionDAO> loadListQuestion()
        {
            List<QuenstionDAO> quenstions = new List<QuenstionDAO>();

            return quenstions;
        }
        public int insertQuestion(QuestionDTO question )
        {
            string questionID = DateTime.Now.ToString("MMhddmms");
            string query = $"INSERT INTO QUESTION  (qID ,qText,userID ,QuestionLevel,courseID)   VALUES ('{questionID}',N'{question.qText}','{question.userID}','hard','{question.courseID}') ";
            int result= DataProvider.Instance.ExecuteNonQuery(query);
            foreach ( Answer i in question.answers)
            {
                query = $"INSERT INTO ANSWER (aID,questionID,aText,isCorrect) VALUES ('{i.key}','{questionID}',N'{i.text}',{i.inCorrect})";
                result = DataProvider.Instance.ExecuteNonQuery(query);
            }
            
            return result;
        }
    }
}
