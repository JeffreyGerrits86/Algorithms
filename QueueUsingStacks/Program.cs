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
            // I think we can do this O(1). I can build something that, for the pop function, moves the reference to the right, hence missing the first item. 
            // Then, I am going to cut the length of the stack by one, making sure that the queue actually gets smaller. 

            // queue.push(1);
            // queue.push(2);
            // queue.peek();    --> returns 1
            // queue.pop();
            // queue.empty();   --> returns false
        }
    }



    public class Queue
    {
        
    }
}