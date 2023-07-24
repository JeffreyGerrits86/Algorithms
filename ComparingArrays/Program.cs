namespace ComparingArrays
{
    //Given two fixed arrays (see the readonly items), find if there are similar values. 
    //If so, return true. 


    internal class Program
    {
        static readonly char[] array1 = { 'a', 'b', 'c', 'x' };
        static readonly char[] array2 = {'z', 'y', 'e' };

        static void Main(string[] args)
        {
            bool sharesvalues = ShareValues(array1, array2);

            Console.WriteLine(sharesvalues);

            Console.ReadKey();  
        }


        //This has lineair time complexity. It has to do with using the Hashset. 
        //The HashSet uses the AddIfNotPresent(T value, out int location) function. This checks if a value is already present by turning the value into a pointer.
        //If the value at the pointer is 0, you add the value to your set and set the value at the pointer to 1. 
        //Let's say somewhere down the line you add a similar value, it is safe to assume that it is hashed the same. Hence, you now find that the value at the pointer is 1. 
        //This is how you know that you already have that value in your list, without looping through it. Quite smart, if you ask me! 
        static bool ShareValues(char[] array1, char[] array2)
        {
            HashSet<char> keys = new HashSet<char>();           //The secret to succes!
            foreach (char c in array1)
            {
                keys.Add(c);
            }

            foreach (char c in array2)
            {
                bool added = keys.Add(c);
                if (added == false)
                {
                    return true;
                }
            }

            return false;
        }

    }
}