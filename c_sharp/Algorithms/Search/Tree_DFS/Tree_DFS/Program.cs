using System;
using System.Collections.Generic;

namespace Tree_DFS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Action<string> print = Console.WriteLine;

            print("Hello, World!");

            var myTree = new MyBinaryTree();
            myTree.Insert(9);
            //myTree.PrintTree();
            //print("##############################");
            myTree.Insert(4);
            myTree.Insert(6);
            //myTree.PrintTree();
            myTree.Insert(20);
            myTree.Insert(170);
            myTree.Insert(15);
            myTree.Insert(1);
            myTree.PrintTree();
            //     9
            //  4     20
            //1  6  15  170

            var list = myTree.DFS_InOrder();
            Console.WriteLine($"DFS_InOrder - Should display elements in ascending numerical order");
            myTree.PrintList(list);

            list = myTree.DFS_PreOrder();
            Console.WriteLine($"\nDFS_PreOrder - Useful when you want to recreate the tree");
            myTree.PrintList(list);

            list = myTree.DFS_PostOrder();
            Console.WriteLine($"\nDFS_PostOrder");
            myTree.PrintList(list);

        }
    }

    //------------------------------

    public class MyBinaryTree
    {
        private Node root = null;

        public List<Node> DFS_InOrder()
        {
            var list = new List<Node>();
            return Traverse_InOrder(this.root, list);
        }

        public List<Node> DFS_PostOrder()
        {
            var list = new List<Node>();
            return Traverse_PostOrder(this.root, list);
        }

        public List<Node> DFS_PreOrder()
        {
            var list = new List<Node>();
            return Traverse_PreOrder(this.root, list);
        }

        //---

        //given how the binary tree is organized how we define what is pre-order, in-order and post-order?
        // consider the functions below, we are using recursive calls to add elements to a list
        // so in the 'In Order' case we go:
        //    left until the end;
        //    when there's nothing else to the left we add the current element to the list;
        //    pop up, add the current element to the list (this is the parent node);
        //    check the right side, if there's something call the 'In_Order' function,
        //      where we add the current element to the list.
        //
        // Taking this subtree as an example:
        //        4
        //      1   6
        //
        // Roughly:
        //  if(currentNode.left != null) { In_Order(currentNode.left,list); }
        //  list.add(currentNode);
        //  if(currentNode.right != null) { In_Order(currentNode.right,list); }
        //
        // And we can change que sequence presented in the list simply by changing where the 'list.add(currentNode);' is
        //  added, i.e.:
        //   Pre Order: first add to the list, then check left, then right
        //   In Order: check left, add to the list, then check right
        //   Post Order: Check left, check right, then add to the list


        // This method search the tree and add elements to the list keeping the numerical order: 1,4,6


        private List<Node> Traverse_InOrder(Node node, List<Node> list)
        {
            if (node.left != null) { Traverse_InOrder(node.left, list); }
            list.Add(node);
            if (node.right != null) { Traverse_InOrder(node.right, list); }
            return list;
        }

        private List<Node> Traverse_PostOrder(Node node, List<Node> list)
        {
            if (node.left != null) { Traverse_PostOrder(node.left, list); }
            
            if (node.right != null) { Traverse_PostOrder(node.right, list); }
            list.Add(node);
            return list;
        }

        private List<Node> Traverse_PreOrder(Node node, List<Node> list)
        {
            list.Add(node);
            if (node.left != null) { Traverse_PreOrder(node.left, list); }
            if (node.right != null) { Traverse_PreOrder(node.right, list); }
            return list;
        }




        //-------------------
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

        public void PrintList(List<Node> list)
        {
            foreach (var i in list)
            {
                Console.Write($"{i.nValue}, ");
            }
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


}





