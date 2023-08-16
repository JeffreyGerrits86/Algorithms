namespace BST
{
    /* Build a Binary Search Tree
     * Insert some items
     * Look up items
     * Traverse in order
     * Remove item
     */

    internal class Program
    {
        static void Main(string[] args)
        {   
            // I don't believe any of the statements in the main function are particularly ambiguous

            BinarySearchTree bst = new BinarySearchTree();

            bst.Insert(5);
            bst.Insert(3);
            bst.Insert(7);
            bst.Insert(2);
            bst.Insert(4);
            bst.Insert(6);
            bst.Insert(8);

            bst.LookUp(12);

            bst.Remove(2);

            bst.InorderTraversal(bst.root);
        }
    }

    public class BinarySearchTree
    {
        // The BinarySearchTree class should hold at least one node - root. 
        public BSTNode? root = null;

        public void Insert(int value)
        {
            root = InsertRecursive(root, value);           
        }

        // The recursive function compares the 'current' node to its left and right nodes. 
        // At first go, it takes the root and the value to be inserted. It keeps going until there is nothing to compare.
        private BSTNode InsertRecursive(BSTNode node, int value)
        {
            // Ya got sent to a place that doesn't exist? Thou shalt be created!
            if(node == null)
            {
                node = new BSTNode();
                node.value = value;
                return node;
            }

            // Decide whether to go left or right, lower or higher
            if(value < node.value)
            {
                node.nodeLeft = InsertRecursive(node.nodeLeft, value);
            }else if (value > node.value){
                node.nodeRight = InsertRecursive(node.nodeRight, value);
            }

            return node;
        }

        public void LookUp(int input)
        {
            // No need for doing difficult stuff if there's nothing there, save the resources for Flight Simulator
            if(root == null)
            {
                Console.WriteLine("No values to return");
            }else if(root.value == input)
            {
                Console.WriteLine("You searched for the root value, had you looked for one fucking second..."); // Sassy, I know, but c'mon
            }else
            {
                // I specifically wanted the recursive method to return a node, but now I don't remember why. 
                // To be fair, this does give more options in the long run. But I am waaaay too shortsighted to think about that in advance.
                BSTNode node = LookUpRecursive(root, input);
            }
            
        }

        private BSTNode LookUpRecursive(BSTNode node, int input)
        {
            // Not a lot of rocket science to this. If you found it, hooray! If you haven't, keep going!
            if(node.value == input)
            {
                Console.WriteLine("Found your input!");
                return node;
            }else if(input > node.value)
            {
                if(node.nodeRight != null)
                {
                    return LookUpRecursive(node.nodeRight, input);
                }
                else
                {
                    Console.WriteLine("Unable to find your input");
                    return node;
                }
            }else if(input < node.value)
            {
                if(node.nodeLeft != null)
                {
                    return LookUpRecursive(node.nodeLeft, input);
                }
                else
                {
                    Console.WriteLine("Unable to find your input");
                    return node;
                }
            }
            
            return node;
        }

        public void InorderTraversal(BSTNode node)
        {
            // This is a clever little trick, right? It loops without looping. 
            if(node == null)
            {
                return;
            }

            InorderTraversal(node.nodeLeft);
            Console.WriteLine(node.value);
            InorderTraversal(node.nodeRight);
        }

        public void Remove(int input)
        {
            root = RemoveRecursive(root, input); 
        }

        private BSTNode RemoveRecursive(BSTNode currentNode, int input)
        {
            if (currentNode == null)
                return null;

            if (input < currentNode.value)
                currentNode.nodeLeft = RemoveRecursive(currentNode.nodeLeft, input);
            else if (input > currentNode.value)
                currentNode.nodeRight = RemoveRecursive(currentNode.nodeRight, input);
            else //this is where we deal with the case that we have found the node we are looking for
            {
                if (currentNode.nodeLeft == null)   
                    return currentNode.nodeRight;          // if nodeRight is null, it falls through both statements, nulling the currentNode
                else if (currentNode.nodeRight == null) 
                    return currentNode.nodeLeft;

                currentNode.value = FindMinValue(currentNode.nodeRight);
                currentNode.nodeRight = RemoveRecursive(currentNode.nodeRight, (int)currentNode.value);
            }
            return currentNode;
        }

        private int FindMinValue(BSTNode node)
        {
            int minValue = (int)node.value;
            while(node.nodeLeft != null)
            {
                minValue = (int)node.nodeLeft.value;
                node = node.nodeLeft;
            }
            return minValue;    
        }

    }

    public class BSTNode
    {
        public int? value = null;
        public BSTNode? nodeRight = null;
        public BSTNode? nodeLeft = null;
    }
}