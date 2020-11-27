using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
