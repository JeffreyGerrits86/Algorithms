/*
    Implement the following functions on a blazingly fast Queue:
        - push()  --> add item to back of the queue
        - peek()  --> return the first item in the queue
        - empty() --> return if the queue is empty
        - pop()   --> remove item from the front of the queue

    
    The original assignment was to only use stacks to implement a queue. 
    The result of that assignment was to use two stacks for enqueue and dequeue.
    However, I felt like there could be a faster way to do this, by looking at the origins of stacks and queues. 
    A stack is essentially an array, and a queue is essentially a linked list. 
    If we could build a queue out of an array, we might get increased performance out of pop() functions.
*/

fn main() {
    let mut queue = Queue::new();


    // some obligatory functions
    queue.push(1);
    queue.push(2);
    queue.push(3);
    queue.push(4);

    queue.pop();

    let sneak = queue.peek();
    println!("{}", sneak);

    let empty = queue.empty();
    println!("{}", empty);


    for i in queue.iter() {
        println!("{}", i);
    }

}


struct Queue {
    length: usize,
    data: Vec<i32>,
} 

impl Queue {
    fn new() -> Queue {
        let vector: Vec<i32> = Vec::new();

        Queue {
            length: vector.len(),
            data: vector,
        }
    }

    fn push(&mut self, x: i32) {
        self.data.push(x);
        self.length = self.data.len();
    }

    fn peek(&self) -> i32 {
        if self.data.len() > 0 {
            return self.data[0];
        }else {
            println!("The queue is empty!");
            return 0;
        }        
    }

    fn empty(&self) -> bool {
        if self.data.len() > 0 {
            return false;
        }else {
            return true;
        }
    }

    // This was the tricky one, you can have queue functions with an array by taking a slice of index[1] and greater.
    // If you now store the new slice as the old vector, you did a pop without moving shit around!
    // Since the reference to the first item no longer exists, the borrow checker kills it.
    // That means it is also safe! 
    fn pop(&mut self) {
        if self.data.len() > 0 {
            let slice: &Vec<i32> = &self.data[1..].to_vec();
            self.data = (&slice).to_vec();
        }else {
            println!("Nothing to pop!");
        }
        
    }

    fn iter(&self) -> std::slice::Iter<'_, i32> {
        self.data.iter()
    }
}