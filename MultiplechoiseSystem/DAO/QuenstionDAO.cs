using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplechoiseSystem.DTO;
using MultiplechoiseSystem.DAO;
using System.Data;

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

        public List<QuestionDTO> loadListQuestionByCourseIDtoCreateSetQuestion(string courseID,string NameExam)
        {
            List<QuestionDTO> questions = new List<QuestionDTO>();
            string query = $"select * from question where courseID='{courseID}' and qID not in (Select questionID from showquestion where examID='{NameExam}')";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                QuestionDTO question = new QuestionDTO();
                question.courseID = i["courseID"].ToString().Trim();
                question.qText = i["qText"].ToString().Trim();
                question.datecreated = (DateTime)i["DateCreated"];
                question.qID = i["qID"].ToString().Trim();
                   
                questions.Add(question);
            }
            


        
            return questions;
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

        public QuestionDTO LoadQuestionByID(string id)
        {
            QuestionDTO question = new QuestionDTO();
            string query = $"select * from question where qID='{id}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            try
            {
                question.courseID = result.Rows[0]["courseID"].ToString().Trim();
                question.qID = id;
                question.qText = result.Rows[0]["qText"].ToString().Trim();
                question.datecreated = (DateTime)result.Rows[0]["DateCreated"];
                query = $"select * from ANSWER where questionID='{id}'";
            }
            catch
            {
               
            }
            result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                Answer answer = new Answer();
                answer.key = i["aID"].ToString().Trim();
                answer.text = i["aText"].ToString().Trim();
                answer.inCorrect = int.Parse(i["isCorrect"].ToString());
                question.answers.Add(answer);
            }


            return question;
        }
         
        public List<QuestionDTO> LoadListShowQuestionWithAnswers(string examID,string courseID)
        {
            List<QuestionDTO> lst = new List<QuestionDTO>();
            string query = $"SELECT * FROM SHOWQUESTION WHERE courseID='{courseID}'and examID='{examID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow i in result.Rows)
            {
                QuestionDTO q = new QuestionDTO();
                q.NO = (int)i["sNO"];
                q.qID = i["questionID"].ToString().Trim();
                q.examID = i["examID"].ToString().Trim();
                q.courseID = courseID;
                q.Option = (int)i["QuestionOption"];
                query = $"select * from ANSWER where questionID='{q.qID}'";
                result = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow j in result.Rows)
                {
                    Answer answer = new Answer();
                    answer.key = j["aID"].ToString().Trim();
                    answer.text = j["aText"].ToString().Trim();
                    answer.inCorrect = int.Parse(j["isCorrect"].ToString());
                    answer.questionID = q.qID;
                    q.answers.Add(answer);
                }


                lst.Add(q);
            }
            return lst;
        }


        public List<QuestionDTO> LoadListQuestionOfTest(string codeExam, string examID, string courseID)
        {
            List<QuestionDTO> lst = new List<QuestionDTO>();
            string query = $"select * from question join SHOWQUESTION ON qID=questionID where question.qID in ( select distinct questionID from CREATE_TEST_QUESTION where courseID='{courseID}' and codeExam='{codeExam}'   )and examID='{examID}'";
            //string query = $" select * from CREATE_TEST_QUESTION as C JOIN SHOWQUESTION as S ON S.sNO= C.sNO and C.questionID=S.questionID and S.courseID=C.courseID  JOIN QUESTION ON c.questionID= QUESTION.qID where C.codeExam='{codeExam}' and C.examID='{examID}'  and C.courseID='{courseID}' ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                QuestionDTO q = new QuestionDTO();
                q.NO = (int)i["sNO"];
                q.qID = i["questionID"].ToString().Trim();
                q.examID = i["examID"].ToString().Trim();
                q.courseID = courseID;
                q.Option = (int)i["QuestionOption"];
                q.qText = i["qText"].ToString().Trim();

                query = $"select * from CREATE_TEST_QUESTION join ANSWER on aID=answerID and ANSWER.questionID=CREATE_TEST_QUESTION.questionID where CREATE_TEST_QUESTION.questionID='{q.qID}' and examID='{examID}' and codeExam='{codeExam}' and courseID='{courseID}'";
                result = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow j in result.Rows)
                {
                    Answer answer = new Answer();
                    answer.key = j["aID"].ToString().Trim();
                    answer.text = j["aText"].ToString().Trim();
                    answer.inCorrect = int.Parse(j["isCorrect"].ToString());
                    answer.questionID = q.qID;
                    q.answers.Add(answer);
                }


                lst.Add(q);
            }
            return lst;
        }
    }
}
