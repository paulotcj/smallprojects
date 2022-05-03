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

print("##############################");
print("Looking for values that should be in this tree");
print($"Looking for value 9 : {myTree.LookUp(9)}");
print($"Looking for value 4 : {myTree.LookUp(4)}");
print($"Looking for value 1 : {myTree.LookUp(1)}");
print($"Looking for value 6 : {myTree.LookUp(6)}");
print($"Looking for value 20 : {myTree.LookUp(20)}");
print($"Looking for value 15 : {myTree.LookUp(15)}");
print($"Looking for value 170 : {myTree.LookUp(170)}");
print("-----");
print("Looking for values that should NOT be in this tree");
print($"Looking for value 11 : {myTree.LookUp(11)}");
print($"Looking for value 22 : {myTree.LookUp(22)}");
print($"Looking for value 33 : {myTree.LookUp(33)}");

print("##############################");
var removeValue = 9;
print($"Remove {removeValue}");
myTree.Remove(removeValue);
myTree.PrintTree();


//------------------------------

public class MyBinaryTree
{
    private Node root = null;
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
                        if (current.nValue <  parent.nValue) //current sits at the left side
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

    private void PrintTree(Node node , Node parentNode) 
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