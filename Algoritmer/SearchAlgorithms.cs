using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmer
{
    internal class SearchAlgorithms
    {
        // pseudokode for en LINEÆR søgningsalgoritme:
        // gå igennem hvert index i en kollektion et efter et (evt. brug en for-løkke).
        // hvis index er lig den værdi, der søges efter, returnes værdien i indexet.

        public Stopwatch stopWatch = new Stopwatch();

        // Method that searches a student collection by name using linear search.
        public Student LinearSearch(Student[] studentArray, string fullName)
        {
            stopWatch.Restart();
            for (int i = 0; i < studentArray.Length; i++)
            {
                if (studentArray[i].FullName == fullName)
                {
                    stopWatch.Stop();
                    Console.WriteLine($"{fullName} was found in {stopWatch.Elapsed} seconds. Press <enter> to return to main menu.");
                    Console.ReadLine();
                    return studentArray[i];
                }
            }

            Console.WriteLine("Student was not found. Press <enter> to return to main menu.");
            Console.ReadLine();
            return null;
        }

        // pseudokode for en BINÆR søgningsalgoritme.
        // sorter først kollektionen.
        // vælg midterste værdi (key'en).
        // hvis det er værdien, der søges efter, stop og returner den.
        // ellers, hvis værdien, der søges efter, ligger til venstre for midten (altså, den er mindre end key), kig på værdierne til venstre. Ellers værdierne til højre.
        // vælg midterste værdi i værdierne til venstre og gentag:
        // hvis værdien, der søges efter, ligger til venstre, kig kun på værdierne til venstre. Ellers værdierne til højre.
        // ... returner værdien, når key er lig værdien, der søges efter.

        // SORT THE ARRAY FIRST

        // Method that searches a student collection by name using binary search.
        public int BinarySearch(Student[] studentArray, string fullName)
        {
            // Initialize start and end pointers.
            int start = 0;
            int end = studentArray.Length - 1;
            stopWatch.Restart();

            // Loop until start pointer is less than or equal to end pointer.
            while (start <= end)
            {
                // Calculate the index of the middle element.
                int mid = (start + end) / 2;                            

                if (studentArray[mid].FullName == fullName)
                {
                    // If target element is found at middle index, return the index.
                    stopWatch.Stop();
                    Console.WriteLine($"{fullName} was found in {stopWatch.Elapsed} seconds. Press <enter> to return to main menu.");
                    Console.ReadLine();
                    return mid; 
                }
                // If target element is greater than middle element, search in the right half.
                // Compare() returns 1 if fullName is greater alphabetically (e.g. fullName is A, but FullName is B).
                // Compare(() returns 0 if they are equal. (e.g. both are 'A')
                // Compare() returns -1 if fullName is lesser alphabetically (e.g. fullName is B, but FullName is A).
                else if (String.Compare(fullName, studentArray[mid].FullName) > 0)
                {
                    // Update the start pointer, so it moves closer towards the end of the greater half of the array, where the value should be if present.
                    start = mid + 1;                        
                }
                // If target element is smaller than middle element, search in the left half. (no logic necessary, this is the only other option left now).
                else
                {
                    // Update the end pointer, so it moves closer towards the start of the lesser half of the array, where the value should be if present.
                    end = mid - 1;          
                }
            }
            // If we reach here, the element was not present, so -1 is returned (equal to null for ints, meaning unsuccesful).
            Console.WriteLine("Student was not found. Press <enter> to return to main menu.");
            Console.ReadLine();
            return -1;                              
        }

        // Alternative RECURSIVE method that searches a student collection by name using binary search.
        // What is recursive now, is the incrementation or reduction of the variables "start" and "end", which are made into parameters for the method.
        // In the case that the value has not been found, the index is moved by calling the method again using the changed parameter, just like before.
        // BUT...
        // If the searched name is value greater than the key, the method is recursively called with mid+1
        // If the searched name is a compared value less than the key, the method is recursively called with mid - 1.
        // This achieves the same as BinarySearch(), but end and start do not need to be declared in the method body, as they are parameters here.
        // Additionally, Compare() is moved to its own line (L112), and its returned value is referenced and checked in the if statements instead.

        public int RecursiveBinarySearch(Student[] studentArray, string fullName, int start, int end)
        {
            stopWatch.Restart();

            while (start <= end)
            {
                // Calculate the index of the middle element
                int mid = (start + end) / 2;

                // Compare the full name of the middle element with the target full name
                int comparisonResult = String.Compare(fullName, studentArray[mid].FullName);

                // If the full names are equal, return the index of the middle element
                if (comparisonResult == 0)
                {
                    stopWatch.Stop();
                    Console.WriteLine($"{fullName} was found in {stopWatch.Elapsed} seconds. Press <enter> to return to the main menu.");
                    Console.ReadLine();
                    return mid;
                }
                else if (comparisonResult > 0)
                {
                    return RecursiveBinarySearch(studentArray, fullName, mid + 1, end);
                }
                else
                {
                    return RecursiveBinarySearch(studentArray, fullName, start, mid - 1);
                }
            }

            Console.WriteLine("Student was not found. Press <enter> to return to the main menu.");
            Console.ReadLine();
            return -1;
            
        }
    }
}
