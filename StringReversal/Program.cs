namespace StringReversal
{
    /// <summary>
    /// We're looking to reverse a string. A string is an array of type char. I don't think there is a nother way to solve this but O(n).
    /// Unless there is some function I am not aware of.  
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "Hi My name is Jeffrey";
            string output = "";

            //There are built-in string reversal methods. They all essentially work like this though. 
            for(int i = input.Length -1; i >= 0; i--)
            {
                output += input[i]; 
            }

            Console.WriteLine(output);

            Console.ReadKey();
        }
    }
}