using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer
{
    internal class DataHandler
    {
        public string DataFileName { get; }

        // Constructor that sets the name of the file to be read/written.
        public DataHandler(string dataFileName)
        {
            DataFileName = dataFileName;
        }

        // Method to WRITE files with information on MULTIPLE people.
        public void SaveStudents(Student[] students)
        {
            Console.Clear();
            Console.WriteLine("Please enter a name for the file: ");
            string nameOfFile = Console.ReadLine();

            if (nameOfFile == "")
            {
                Console.WriteLine("Save was unsuccesful: The name of the file cannot be left blank. \nPress <enter> to return to main menu.");
                Console.ReadLine();
                return;
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(nameOfFile + ".txt"))
                {
                    foreach (Student student in students)
                    {
                        writer.WriteLine(student.MakeTitle());
                    }
                }
                Console.WriteLine("Save was successful. Press <enter> to return to main menu.");
                Console.ReadLine();
            }
        }

        // Method to READ files with information on MULTIPLE persons.
        public Student[] LoadStudents()
        {
            List<Student> studentsList = new List<Student>();

            using (StreamReader reader = new StreamReader(DataFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');                           /// Vi splitter ved komma, ikke ved semi-kolon i Student.txt

                    // Create a new Person object and add the value of each index from the array to the personsList-list.
                    /// Den anden værdi, holdnummer, skal parses som en int, fordi det kommer fra et string array, men Student-constructor skal bruge en int her.
                    studentsList.Add(new Student(parts[0], int.Parse(parts[1])));
                }
            }
            // Convert the list to an array and return it.
            return studentsList.ToArray();
        }

        // Alternativ LoadStudents()-metode der returnerer en liste i stedet for et array
        //public List<Student> LoadStudents()
        //{
        //    List<Student> studentsList = new List<Student>();

        //    using (StreamReader reader = new StreamReader(DataFileName))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            string[] parts = line.Split(',');

        //                string fullName = parts[0];
        //                int groupNumber = int.Parse(parts[1]);

        //                // Create a new Student object and add it to the studentsList
        //                studentsList.Add(new Student(fullName, groupNumber));
        //            }
        //        }
        //    }
        //    return studentsList;
        //}

    }
}
