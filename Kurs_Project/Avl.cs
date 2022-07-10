using System;
namespace Kurs_Project
{
    public class Avl
    {
        public class Node
                {
                    public List<Table2> Data = new List<Table2>();
                    public Node Left;
                    public Node Right;
                    public Node(Table2 data)
                    {
                        this.Data.AddFirst(data);
                    }
                }
        
                public Node Root;
        
                public static void AvlToList(Node tree, List<Table2> mainList)
                {
                    if (tree != null)
                    {
                        AvlToList(tree.Left, mainList);
                        AvlToList(tree.Right, mainList);
                        mainList.AddListInList(tree.Data);
                    }
                }
                public void Add(Table2 data)
                {
                    Node newItem = new Node(data);
                    if (Root == null)
                    {
                        Root = newItem; 
                    }
                    else
                    {
                        Root = RecursiveInsert(Root, newItem);
                    }
                }
                private Node RecursiveInsert(Node current, Node n)
                {
                    if (current == null)
                    {
                        current = n;
                        return current;
                    }
                    else if (String.CompareOrdinal(n.Data[0].Category,current.Data[0].Category) < 0)
                    {
                        current.Left = RecursiveInsert(current.Left, n);
                        current = balance_tree(current);
                    }
                    else if (String.CompareOrdinal(n.Data[0].Category,current.Data[0].Category) > 0)
                    {
                        current.Right = RecursiveInsert(current.Right, n);
                        current = balance_tree(current);
                    }
                    else if (String.CompareOrdinal(n.Data[0].Category,current.Data[0].Category) == 0)
                    {
                        current.Data.AddFirst(n.Data[0]); 
                    }
                    return current;
                }
                private Node balance_tree(Node current)
                {
                    int bFactor = balance_factor(current);
                    if (bFactor > 1)
                    {
                        if (balance_factor(current.Left) > 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                    else if (bFactor < -1)
                    {
                        if (balance_factor(current.Right) > 0)
                        {
                            current = RotateRL(current);
                        }
                        else
                        {
                            current = RotateRR(current);
                        }
                    }
                    return current;
                }
                
                public void Delete(Table2 target)
                {
                    Node temp2 = Find(target.Category, Root);
                    if (temp2.Data.Count == 1)
                    {
                        Root = Delete(Root, target.Category);
                    }
                    else
                    {
                        temp2.Data.Remove(target);
                    }
                }
                
                
                private Node Delete(Node current, string target)
                {
                    if (current == null)
                    { return null; }
                    else
                    {
                        if (String.CompareOrdinal(target,current.Data[0].Category) < 0)
                        {
                            current.Left = Delete(current.Left, target);
                            if (balance_factor(current) == -2)
                            {
                                if (balance_factor(current.Right) <= 0)
                                {
                                    current = RotateRR(current);
                                }
                                else
                                {
                                    current = RotateRL(current);
                                }
                            }
                        }
                        //right subtree
                        else if (String.CompareOrdinal(target,current.Data[0].Category) > 0)
                        {
                            current.Right = Delete(current.Right, target);
                            if (balance_factor(current) == 2)
                            {
                                if (balance_factor(current.Left) >= 0)
                                {
                                    current = RotateLL(current);
                                }
                                else
                                {
                                    current = RotateLR(current);
                                }
                            }
                        }
                        else
                        {
                            if (current.Right != null)
                            {
                                var parent = current.Right;
                                while (parent.Left != null)
                                {
                                    parent = parent.Left;
                                }
                                current.Data = parent.Data;
                                current.Right = Delete(current.Right, parent.Data[0].Category);
                                if (balance_factor(current) == 2)
                                {
                                    if (balance_factor(current.Left) >= 0)
                                    {
                                        current = RotateLL(current);
                                    }
                                    else { current = RotateLR(current); }
                                }
                            }
                            else if (current.Left != null)
                            {   
                                return current.Left;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                    return current;
                }

                public List<Table2> Find(string key)
                {
                    if (Find(key, Root) == null)
                    {
                        return new List<Table2>();
                        
                    }
                    if (Find(key, Root).Data[0].Category == key)
                    {
                        return Find(key, Root).Data;
                    }
                    else
                    {
                        return new List<Table2>();
                    }
                    return new List<Table2>();
                }
                public List<string> DisplayTree()
                {
                    List<string> temp = new List<string>();
                    if (Root == null)
                    {
                        string tempStr = "Дерево пустое";
                        temp.AddFirst(tempStr);
                        return temp;
                    }
                    InOrderDisplayTree(Root, temp);
                    return temp;
                }
                private void InOrderDisplayTree(Node current, List<string> stringing)
                {
                    if (current != null)
                    {
                        InOrderDisplayTree(current.Left, stringing);
                        stringing.AddFirst(current.Data.GetStringRepresentation());
                        InOrderDisplayTree(current.Right, stringing);
                    }
                }
                public Node Find(string target, Node current)
                {
                    if (current == null)
                    {
                        return null;
                    }
                    if (String.CompareOrdinal(target,current.Data[0].Category) == 0)
                    {
                        return current;
                    }
                    if (String.CompareOrdinal(target,current.Data[0].Category) < 0)
                    {
                        return Find(target, current.Left);
                    }
                    else
                    {
                        return Find(target, current.Right);
                    }
                }
                private int max(int l, int r)
                {
                    return l > r ? l : r;
                }
                private int GetHeight(Node current)
                {
                    int height = 0;
                    if (current != null)
                    {
                        int l = GetHeight(current.Left);
                        int r = GetHeight(current.Right);
                        int m = max(l, r);
                        height = m + 1;
                    }
                    return height;
                }
                private int balance_factor(Node current)
                {
                    int l = GetHeight(current.Left);
                    int r = GetHeight(current.Right);
                    int bFactor = l - r;
                    return bFactor;
                }
                private Node RotateRR(Node parent)
                {
                    Node pivot = parent.Right;
                    parent.Right = pivot.Left;
                    pivot.Left = parent;
                    return pivot;
                }
                private Node RotateLL(Node parent)
                {
                    Node pivot = parent.Left;
                    parent.Left = pivot.Right;
                    pivot.Right = parent;
                    return pivot;
                }
                private Node RotateLR(Node parent)
                {
                    Node pivot = parent.Left;
                    parent.Left = RotateRR(pivot);
                    return RotateLL(parent);
                }
                private Node RotateRL(Node parent)
                {
                    Node pivot = parent.Right;
                    parent.Right = RotateLL(pivot);
                    return RotateRR(parent);
                }
    }
}