namespace FirstRecurringCharacter
{
    /// <summary>
    /// Given an array, return the first recurring character.
    /// [2,5,1,2,3,4,1,2,4] => should return 2
    /// [2,1,1,2,3,5,1,2,4] => should return 1
    /// [2,3,4,5] => should return null
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 2, 5, 1, 2, 3, 4, 1, 2, 4 };
            int[] array2 = {2,1,1,2,3,4,1,2,4 };
            int[] array3 = { 2, 3, 4, 5 };

            HashSet<int> set = new HashSet<int>();      //Since adding a duplicate to a hashset creates a collision instantly, O(n)
            bool notDuplicate = true;

            foreach(int i in array3)
            {
                notDuplicate = set.Add(i);              //Booleans are set to false in case of collision
                if(notDuplicate == false)
                {
                    Console.WriteLine("The first recurring item is {0}", i);
                    break;
                }
            }

            if (notDuplicate)
            {
                Console.WriteLine("No duplicates were found");
            }
            
            
            Console.ReadKey();
        }
    }
}