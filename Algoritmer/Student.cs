using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer
{
    public class Student
    {
        private string fullName;
        private int groupNumber;

        // Property for fullName
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        // Property for groupNumber
        public int GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }

        public Student(string fullName, int groupNumber)
        {
            FullName = fullName;
            GroupNumber = groupNumber;
        }

        public string MakeTitle()
        {
            return (this.FullName + ", " + this.GroupNumber);
        }
    }
}
