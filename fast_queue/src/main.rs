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

use std::time::{Instant};

fn main() {   

    let mut queue = Queue::new();

    let mut item = 1;
    for _ in 0..500000 {
        queue.push(item);
        item += 1;
    }

    queue.pop();

    let sneak = queue.peek();
    println!("{}", sneak);

    let empty = queue.empty();
    println!("{}", empty);


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

    // The Rust documentation would indicate that this is an O(1) operation, since a vector slice is a view. 
    // However, the time increases when the queue gets bigger. I don't understand how and why, since this contradicts what the documentation says. 
    // Maybe I'll shoot this over to the Rust foundation or Stackoverflow...
    fn pop(&mut self) {
        if self.data.len() > 0 {
            let start_time = Instant::now();
            let slice: &Vec<i32> = &self.data[1..].to_vec(); // https://doc.rust-lang.org/std/primitive.slice.html  says it should be O(1)...
            let end_time = Instant::now();
            let elapsed_time = end_time - start_time;
            println!("{:?}", elapsed_time);
            self.data = slice.to_vec();
        }else {
            println!("Nothing to pop!");
        }
        
    }

    fn iter(&self) -> std::slice::Iter<'_, i32> {
        self.data.iter()
    }
}