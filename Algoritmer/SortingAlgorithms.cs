using System;
using System.Buffers.Text;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Algoritmer
{
    internal class SortingAlgorithms
    {
        public void SelectionSortDescending(Student[] students)
        {
            int n = students.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Find the index of the smallest element in the remaining unsorted array.
                    // Sorts GroupNumber by DESCENDING, else use '<' for ASCENDING.
                    if (students[j].GroupNumber > students[minIndex].GroupNumber)
                    {
                        minIndex = j;
                    }
                }
                // Swap.
                Student temp = students[i];
                students[i] = students[minIndex];
                students[minIndex] = temp;
            }
        }

        public void BubbleSortAscending(Student[] students)
        {
            int n = students.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Sort GroupNumber by ASCENDING, else use '<' for DESCENDING.
                    if (students[j].GroupNumber > students[j + 1].GroupNumber)
                    {
                        // Swap.
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        public void BubbleSortByFirstLetter(Student[] students)
        {
            int n = students.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Compare the first letters of full names of students (using string index) to sort them alphebetically ascending (A first, then B, etc.).
                    if (string.Compare(students[j].FullName, students[j + 1].FullName) > 0)
                    {
                        // Swap.
                        Student temp = students[j];
                        students[j] = students[j + 1];
                        students[j + 1] = temp;
                    }
                }
            }
        }

        // Method to perform the initial sorting of the array before quick sorting/a binary search is performed?
        public void QuickSortByFirstLetter(Student[] students, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(students, left, right);
                QuickSortByFirstLetter(students, left, pivotIndex - 1);
                QuickSortByFirstLetter(students, pivotIndex + 1, right);
            }
        }

        // Method that partitions the array into two parts based on a pivot element.
        private int Partition(Student[] students, int left, int right)
        {
            string pivot = students[right].FullName;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (string.Compare(students[j].FullName, pivot) <= 0)
                {
                    i++;
                    // Swap.
                    Student temp = students[i];
                    students[i] = students[j];
                    students[j] = temp;
                }
            }
            
            // Swap.
            Student tempPivot = students[i + 1];
            students[i + 1] = students[right];
            students[right] = tempPivot;

            return i + 1;
        }
    }
}
