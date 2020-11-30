using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplechoiseSystem.DAO
{
    class CourseOutcomesDTO
    {
        public CourseOutcomesDTO() { }
        public string Code;
        public string description;
        public string courseID;

    }
    class CourseOutcomesDAO
    {
        private static CourseOutcomesDAO instance;

        public static CourseOutcomesDAO Instance
        {
            get { if (instance == null) instance = new CourseOutcomesDAO(); return CourseOutcomesDAO.instance; }
            private set { CourseOutcomesDAO.instance = value; }

            
        }
        public List<CourseOutcomesDTO> getListOCbyCourseID(string courseID)
        {
            List<CourseOutcomesDTO> lst = new List<CourseOutcomesDTO>();
            string query = $"select * from COURSE_OUTCOMES  where courseID='{courseID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow i in result.Rows)
            {
                CourseOutcomesDTO cc = new CourseOutcomesDTO();
                cc.Code = i["cID"].ToString().Trim();
                cc.courseID = courseID;
                cc.description = i["Content"].ToString().Trim();
                lst.Add(cc);
            }



            return lst;

        }
        
    }
}
