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

    public void Remove(int value) { return; }

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