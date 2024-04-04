using System.Security.Cryptography.X509Certificates;

namespace Algoritmer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choice;
            string choice2;
            string choice3;

            // Setup.
            // Instantiate and set the file name for the DataHandler class.
            DataHandler dataHandler = new DataHandler("Students.txt");
            // Instantiate the SortingAlgorithms class.
            SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();
            // Instantiate the SearchAlgorithms class.
            SearchAlgorithms searchAlgorithms = new SearchAlgorithms();
            // Load the Students.txt file using LoadStudents() and store a reference to the returned array.
            Student[] students = dataHandler.LoadStudents();
        
            // The top menu.
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Options: ");
                Console.WriteLine("1. Sort students.");
                Console.WriteLine("2. Search students.");
                Console.WriteLine("3: Print the student list.".PadRight(30));
                Console.WriteLine("4: Save the student list.".PadRight(30));
                Console.WriteLine("5: Close the program".PadRight(30));
                Console.Write("\nPlease select an option: ");
                choice = Console.ReadLine();
            
                switch (choice)
                {
                    case "1":
                        SortingSubmenu();
                        continue;
                    case "2":
                        SearchSubMenu();
                        continue;
                    case "3":
                        PrintStudents();
                        continue;
                    case "4":
                        dataHandler.SaveStudents(students);
                        continue;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid input. Press <enter> to try again.");
                        Console.ReadLine();
                        continue;
                }
            }

            void PrintStudents()
            {
                Console.Clear();
                // Console print with colors for full name and team number
                foreach (Student student in students)
                {
                    // E.g. "-25" means that, the FullName value in the console should take up minimum 25 char-spaces, if it doesn't, add remaining spaces so it takes up 25 spaces. Assures alignment.
                    Console.WriteLine($"| \u001b[32m{student.FullName,-25}\u001b[0m | \u001b[34m{student.GroupNumber,-13}\u001b[0m |");
                }
                Console.WriteLine("\nPress <enter> to return to main menu.");
                Console.ReadLine();
            }

            void SortingSubmenu()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Options: ");
                    Console.WriteLine($"1: Sort by name using quick sort.");
                    Console.WriteLine($"2: Sort by group number using selection sort.");
                    Console.Write("\nPlease select an option: ");
                    choice2 = Console.ReadLine();

                    switch (choice2)
                    {
                        case "1":
                            Console.WriteLine("\nStudents sorted by name. (Quick Sort, Ascending) \nPress <enter> to return to main menu.");
                            sortingAlgorithms.QuickSortByFirstLetter(students, 0, students.Length - 1);
                            Console.ReadLine();                            
                            return;
                        case "2":
                            Console.WriteLine("\nStudents sorted by group number. (Bubble Sort, Ascending) \nPress <enter> to return to main menu.");
                            sortingAlgorithms.BubbleSortAscending(students);
                            // Sorts the students team number in descending order.
                            //sortingAlgorithms.SelectionSortDescending(students);
                            Console.ReadLine();
                            return;
                        default:
                            Console.WriteLine("Invalid input. Press <enter> to try again.");
                            Console.ReadLine();
                            continue;
                    }
                }                
            }
            void SearchSubMenu()
            {
               while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the full name of the student to search for: ");
                    string searchStudent = Console.ReadLine();
                
                    Console.Clear();
                    Console.WriteLine("Searching for: " + searchStudent);
                    Console.WriteLine("\nPlease select a search algorithm to use: ");
                    Console.WriteLine($"1: Search using linear search.");
                    Console.WriteLine($"2: Search using binary search.");
                    Console.WriteLine($"3: Search using recursive binary search.");
                    Console.Write("\nPlease select an option: ");
                    choice3 = Console.ReadLine();

                    switch (choice3)
                    { 
                        case "1":
                            searchAlgorithms.LinearSearch(students, searchStudent);
                            return;

                        case "2":
                            sortingAlgorithms.QuickSortByFirstLetter(students, 0, students.Length - 1);
                            // Call to alternative BubbleSort method.
                            //sortingAlgorithms.BubbleSortByFirstLetter(students);
                            searchAlgorithms.BinarySearch(students, searchStudent);
                            return;
                        case "3":
                            sortingAlgorithms.QuickSortByFirstLetter(students, 0, students.Length - 1);
                            searchAlgorithms.RecursiveBinarySearch(students, searchStudent, 0, students.Length - 1);
                            return;

                    }
                }
            }

        }
    }
}
