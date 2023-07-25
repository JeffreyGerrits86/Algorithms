namespace MergeSortedArrays
{
    /// <summary>
    /// The assignment is to merge two sorted arrays. There may be duplicate values. 
    /// The easy fix would be to go for a O(n^2) type solution; a nested for loop.
    /// There should be a way, however, to do this in lineair time. 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 0, 3, 4, 31 };     // I'm choosing fixed arrays here, since this adds a little bit of extra difficulty
            int[] array2 = { 4, 6, 30 };        // Also, if we're looking for optimization, fixed arrays are better than dynamic arrays
            int[] sortedArray = new int[array1.Length + array2.Length];   // For scalibility, add some logic here
            int currentIndex1 = 0;      // I figured we need to loop through both lists in one go to achieve lineair efficiency
            int currentIndex2 = 0;      // That means we need to keep track of the position in both arrays

            //If we can fill the combined array from both arrays in one function, we should be able to achieve lineair efficiency
            for(int i = 0; i < (array1.Length + array2.Length); i++)    
            {
                if ( currentIndex1 < array1.Length && currentIndex2 < array2.Length && array1[currentIndex1] > array2[currentIndex2]) //Check if you're not exceeding array sizes first
                {
                    sortedArray[i] = array2[currentIndex2];
                    currentIndex2++;
                }else if( currentIndex1 < array1.Length && currentIndex2 < array2.Length && array1[currentIndex1] < array2[currentIndex2]) //Otherwise expect 'out of bounds' errors
                {
                    sortedArray[i] = array1[currentIndex1];
                    currentIndex1++;
                }
                else        // This case handles the double values
                {
                    sortedArray[i] = array1[currentIndex1];
                    currentIndex1++;
                }
            }



            foreach(int i in sortedArray)
            {
                Console.WriteLine(i);      // It seems to work! O(n) baby!
            }
            
            Console.ReadKey();
        }
    }
}