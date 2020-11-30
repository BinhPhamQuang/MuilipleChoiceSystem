using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplechoiseSystem.DTO
{   
    class Answer
    {
        public Answer() { }
        public string key;
        public string text;
        public int inCorrect = 0;
        public string KeyAnswerSheet;
        public string questionID;
    }
    class QuestionDTO
    {
        public QuestionDTO(){}
        public string qID;
        public string qText;
        public DateTime datecreated;
        public string userID;
        public string lecturername;
        public string courseID;
        public string courseName;
        public int Option=1;
        public List<Answer> answers = new List<Answer>();
        public string examID;
        public int NO;
    }
}
