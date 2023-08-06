namespace QueueUsingStacks
{
    /// <summary>
    /// 
    /// Implement the following operations of a queue using stacks:
    /// - push(x):  push element to back of queue
    /// - pop(): remove element from front of queue
    /// - peek(): get front element
    /// - emtpy(): return whether queue is empty
    /// 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            //Perform some obligatory operations
            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Push(4);

            queue.Pop();           

            bool isEmpty = queue.Empty();
            Console.WriteLine(isEmpty);

            int sneakPeek = queue.Peek();
            Console.WriteLine(sneakPeek);   

            queue.PrintAllItems();

            Console.ReadKey();
        }


    }
    
    public class Queue
    {
        /// <summary>
        /// the idea is to constantly keep track of the first item in the list with the dequeue stack for the peek().
        /// We use the enqueue stack as the actual queue.
        /// For a pop, we have to move all but one item over to the dequeue stack and then push them back.
        /// </summary>
        private Stack<int> enqueue = new Stack<int>();
        private Stack<int> dequeue = new Stack<int>();

        public void Push(int i)
        {
            // if there is no item yet, you gotta push both, making sure you have something to peek at
            if (dequeue.Count() == 0)
            {
                dequeue.Push(i);
                enqueue.Push(i);
            }
            else
            {
                enqueue.Push(i);
            }
        }

        public int Peek()
        {
            // Peeking the enqueue would result in the last item being returned
            return dequeue.Peek();            
        }

        public bool Empty()
        {
            if(enqueue.Count() <= 0)
            {
                return true;
            }else
            {
                return false;
            }
            
        }

        public void Pop()
        {
            // First deal with instances that are easy to deal with
            if(enqueue.Count() <= 0)
            {
                Console.WriteLine("Nothing to pop!");
            }else if(enqueue.Count() == 1)      // don't forget to pop both
            {
                enqueue.Pop();
                dequeue.Pop();
            }else if(enqueue.Count == 2)        // if there are only two items, that means the top one needs to be saved
            {
                int onlyItemLeft = enqueue.Pop();
                dequeue.Push(onlyItemLeft);
                enqueue.Clear();
                enqueue.Push(onlyItemLeft);
            }
            else     
            {
                // Let's say there are multiple items in the queue, start by clearing the dequeue item, this is no longer relevant
                dequeue.Pop();
                int currentItems = enqueue.Count();
                // You have to run a for loop leaving 2 items in the enqueue stack, since you have te reuse the top one and dump the bottom one
                for (int i = 0; i < currentItems - 2; i++)
                {
                    int item = enqueue.Pop();
                    dequeue.Push(item);             // the ol' switcheroo
                }

                int newFirstItem = enqueue.Pop();   // special treatment for the second item, this will be the new first
                dequeue.Push(newFirstItem);         // complete the dequeue
                enqueue.Clear();
                int currentCount = dequeue.Count();

                for (int j = 0; j < currentCount; j++) // bring m back to the enqueue without bottom item
                {
                    int item = dequeue.Pop();
                    enqueue.Push(item);
                }

                dequeue.Push(newFirstItem);     // don't forget, we need something to peek in there
            }          

        }

        public void PrintAllItems()
        {
            foreach (int i in enqueue)
            {
                Console.WriteLine(i);
            }
        }

    }

}