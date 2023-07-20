namespace BigO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // O(n)     --> Linear Time         --> as the problem input increases with n, the time to solve it increases with n
            // O(1)     --> Constant Time       --> irrespective of the input, the function runs 1 operation
            // O(n^2)   --> Quadratic Time      --> seen with nested loops
            // O(n!)    --> Factorial Time      --> Adding a nested loop for every input. 

            // Rule 1: Worst Case                   --> calculate as though you will find your answer on the last possible iteration
            // Rule 2: Remove Constants             --> these do not grow with the problem input
            // Rule 3: Different terms for inputs   --> You have to take into account different inputs O(a + b), nested loops O(n^2)
            // Rule 4: Drop Non Dominants           --> When combined and one is far larger, go with the largest. O(n + n^2) becomes simply O(n^2)

            // Space complexity: how much space usage are we adding with our function? 


        }


    }
}