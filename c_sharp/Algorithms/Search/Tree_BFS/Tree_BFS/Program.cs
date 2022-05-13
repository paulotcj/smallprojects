// See https://aka.ms/new-console-template for more information

Action<string> print = Console.WriteLine;

print("Hello, World!");

var myTree = new MyBinaryTree();
myTree.Insert(9);
myTree.PrintTree();
print("##############################");
myTree.Insert(4);
myTree.Insert(6);
myTree.PrintTree();
myTree.Insert(20);
myTree.Insert(170);
myTree.Insert(15);
myTree.Insert(1);
myTree.PrintTree();
//     9
//  4     20
//1  6  15  170

print("BreadthFirstSearch() below");
var myList = myTree.BreadthFirstSearch();
Console.WriteLine($"Printing List. It should be: 9 , 4 , 20 , 1 , 6 , 15 , 170");
myTree.PrintList(myList);

print("##############################");
print("BFS() below");
myList = myTree.My_BFS();
myTree.PrintList(myList);
print("##############################");
print("BFS_Recursive() below");
myList = myTree.My_BFS_Recursive();
myTree.PrintList(myList);

//------------------------------

public class MyBinaryTree
{
    private Node root = null;

    public List<Node> My_BFS()
    {
        List<Node> list = new();
        Queue<Node> q = new();
        Node current;
        q.Enqueue(root);

        while (q.Count > 0)
        {     
            current = q.Dequeue();
            list.Add(current);

            if(current.left != null) { q.Enqueue(current.left); }
            if (current.right != null) { q.Enqueue(current.right); }

        }

        return list;

    }


    public List<Node> My_BFS_Recursive(Queue<Node> q = null , List<Node> list = null)
    {
        //check if q and list are null
        if (q == null)
        {
            q = new(); list = new();
            q.Enqueue(this.root);
        }

        //if q is empty, then we are done - return list
        if (q.Count == 0) { return list; }

        var current = q.Dequeue();

        //add the current element being inspected to the list
        list.Add(current);

        //check for left
        if (current.left != null) { q.Enqueue(current.left); }
        //check for right
        if (current.right != null) { q.Enqueue(current.right); }

        //return with a recursive call to BFS_Recursive
        return BFS_Recursive(q, list);
    }


    public List<Node> BFS_Recursive( Queue<Node> q = null, List<Node> list = null )
    {
        if (q == null) //house keeping and the first call
        { 
            q = new Queue<Node>(); 
            list = new List<Node>(); 
            q.Enqueue(root); 
        }

        if (q.Count == 0) { return list; }

        Node current = q.Dequeue();
        list.Add(current);
        if (current.left != null) { q.Enqueue(current.left); }
        if (current.right != null) { q.Enqueue(current.right); }

        return BFS_Recursive(q, list);

    }

    public List<Node> BreadthFirstSearch()
    {
        Node current = this.root;
        List<Node> list = new ();
        Queue<Node> queue = new ();

        //suppose we have the following:
        //     9
        //  4     20
        //1  6  15  170

        // root is 9, and it's assigned to current, we then enque node '9' as this is the starting point
        // of this algorithm.
        // We then will perform a loop checking whether the queue is ever empty, if not, pop an element from the
        //  queue, add it to the return list, and then investigate whether this element has left or right children
        //  if they exist add them to the queue, and then loop.
        // The expected outcome should be breadth first so: 9 , 4 , 20 , 1 , 6 , 15 , 170

        queue.Enqueue(current);
        while (queue.Count > 0)
        {
            current = queue.Dequeue();
            list.Add(current);

            if (current.left != null) 
            {
                queue.Enqueue(current.left);
            }
            if (current.right != null)
            {
                queue.Enqueue(current.right);
            }
        }

        return list;
    }

    public void PrintList(List<Node> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            Console.WriteLine($"List[{i}] : {item.nValue}");

        }
    }


    //---------------------------------------

    public void Insert(int value)
    {
        var newNode = new Node();
        newNode.nValue = value;
        //-----
        if (root == null) { root = newNode; return; }

        var current = root;
        //-----
        while (true)
        {
            if (value < current.nValue) //left
            {
                if (current.left == null)
                {
                    current.left = newNode;
                    return;
                }
                current = current.left;

            }
            else //right
            {
                if (current.right == null)
                {
                    current.right = newNode;
                    return;
                }
                current = current.right;
            }

        }


    }

    public int? LookUp(int value)
    {
        if (root == null) return null;

        var current = root;
        while (current != null)
        {
            if (value == current.nValue) { return current.nValue; }
            else if (value < current.nValue) //left
            {
                current = current.left;
            }
            else  //right
            {
                current = current.right;
            }
        }

        return null;
    }

    public void Remove(int value)
    {
        if (root == null) { return; }

        Node current = root;
        Node parent = null;

        while (current != null)
        {
            if (value < current.nValue) //value < node value -> left
            {
                parent = current;
                current = current.left;
            }
            else if (value > current.nValue) //value > node value -> right
            {
                parent = current;
                current = current.right;
            }
            else if (value == current.nValue) //value == node value -> do some work
            {
                //General rule: we want to delete current, since it matched the value
                // to be deleted, now we have to manage its possible children

                //by deleting current, we have 2 lose ends that we need to attach somewhere
                // the general approach is try to work our way around the right node (we will not balance the tree)

                //1 - No right child , then we will connect the parent node to current's left node
                //       (parent)
                //           |
                //       (current)
                //       /       \
                // Left(???)    Right(null)
                if (current.right == null)
                {
                    //special case, when there's no parent root will assume the default node position
                    if (parent == null) { this.root = current.left; }
                    else
                    {
                        //at this point we have the current node and the parent node, and we need to know
                        // if the current node  is at the left or right of the parent's node so we can replace it
                        // accordingly

                        //so.. if parent > current value, make current left child a child of its parent
                        if (current.nValue < parent.nValue) //current sits at the left side
                        {
                            parent.left = current.left; //this effectively replaces current node
                        }
                        else if (current.nValue > parent.nValue) //current sits at the right side of its parent
                        {
                            parent.right = current.left; //this effectively replaces current node
                        }
                    }
                } // 1 end


                //2 - There is a right child, and this right child does not have a left child
                //     then we want to get current.left and place it on current.right.left
                //     and then since we want to delete current, we will replace the origin link
                //     from parent, with current.right
                //
                //       (parent)
                //           |
                //       (current)
                //       /       \
                // Left(???)    Right(NOT NULL)
                //                /       \
                //             L(null)    R(? maybe not null ?) <- connect this
                else if (current.right.left == null)
                {
                    current.right.left = current.left;

                    //special case, when there's no parent root will assume the default node position
                    if (parent == null)
                    {
                        this.root = current.right;
                    }
                    else
                    {
                        //at this point we have the current node and the parent node, and we need to know
                        // if the current node  is at the left or right of the parent's node so we can replace it
                        // accordingly

                        if (current.nValue < parent.nValue)//current sits at the left side
                        {
                            parent.left = current.right; //this effectively replaces current node
                        }
                        else if (current.nValue > parent.nValue)  //current sits at the right side of its parent
                        {
                            parent.right = current.right; //this effectively replaces current node
                        }
                    }
                } //2 end



                //3 - There is a right child, and this child has a left child
                //       (parent)
                //           |
                //       (current)
                //       /       \
                // Left(???)    Right(NOT NULL)   --------> leftMostParent
                //              /        \
                //       L(not null)     R(???)
                //            |
                //            |---------------------------> leftMost
                else
                {
                    //Right child -> find its left most child
                    var leftMost = current.right.left;
                    var leftMostParent = current.right;

                    while (leftMost.left != null) //trying to get all the way to the left
                    {
                        leftMostParent = leftMost;
                        leftMost = leftMost.left;
                    }

                    //by now we should be all the way to the left

                    leftMostParent.left = leftMost.right;
                    leftMost.left = current.left;
                    leftMost.right = current.right;


                    // at this point we reassigned the lose ends,
                    // we need now to remove 'current' from the tree

                    //------


                    //this is a complicated operation but basically we are going to replace the
                    // current node by the left most node
                    // everything remains the same but the leftMost.right now is leftMostParent.left

                    if (parent == null)
                    {
                        this.root = leftMost;
                    }
                    else
                    {

                        if (current.nValue < parent.nValue)
                        {
                            parent.left = leftMost;
                        }
                        else if (current.nValue > parent.nValue)
                        {
                            parent.right = leftMost;
                        }
                    }



                } //3 end

                return;
            } // do work end

        } //while end



        return;
    }

    public void PrintTree()
    {
        Console.WriteLine($"--------------------------\nPrint Tree\n");
        PrintTree(root, null);
    }

    private void PrintTree(Node node, Node parentNode)
    {
        Console.WriteLine($"    Node Value : {node.nValue}        Parent Node : { parentNode?.nValue}");

        if (node.left != null)
        {
            Console.WriteLine($"    Left node below");
            PrintTree(node.left, node);
        }
        if (node.right != null)
        {
            Console.WriteLine($"    Right node below");
            PrintTree(node.right, node);
        }
    }
}



public class Node
{
    public int? nValue = null;
    public Node left = null;
    public Node right = null;
}