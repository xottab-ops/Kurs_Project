using System;
using System.Collections.Generic;

namespace Kurs_Project
{
    public class Avl
    {
        public class Node
        {
            public LinkedList<Table2> Data = new LinkedList<Table2>();
            public Node Left;
            public Node Right;
            public Node(Table2 data)
            {
                this.Data.Add(data);
            }
        }
        
                public Node Root;
                public int Count = 0;
                public LinkedList<Table2> AvlToList()
                {
                    LinkedList<Table2> temp = new LinkedList<Table2>();
                    if (Root == null)
                    {
                        return temp;
                    }
                    InOrderDisplayTree(Root, temp);
                    return temp;
                }
                
                private void InOrderDisplayTree(Node current, LinkedList<Table2> stringing)
                {
                    if (current != null)
                    {
                        InOrderDisplayTree(current.Left, stringing);
                        foreach (var add in current.Data)
                        {
                            stringing.Add(add);
                        }
                        InOrderDisplayTree(current.Right, stringing);
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

                    Count++;
                }
                private Node RecursiveInsert(Node current, Node n)
                {
                    if (current == null)
                    {
                        current = n;
                        return current;
                    }
                    else if (String.CompareOrdinal(n.Data.returnFirst().Category,current.Data.returnFirst().Category) < 0)
                    {
                        current.Left = RecursiveInsert(current.Left, n);
                        current = balance_tree(current);
                    }
                    else if (String.CompareOrdinal(n.Data.returnFirst().Category,current.Data.returnFirst().Category) > 0)
                    {
                        current.Right = RecursiveInsert(current.Right, n);
                        current = balance_tree(current);
                    }
                    else if (String.CompareOrdinal(n.Data.returnFirst().Category,current.Data.returnFirst().Category) == 0)
                    {
                        current.Data.Add(n.Data.returnFirst()); 
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

                    Count--;
                }
                
                
                private Node Delete(Node current, string target)
                {
                    if (current == null)
                    { return null; }
                    else
                    {
                        if (String.CompareOrdinal(target,current.Data.returnFirst().Category) < 0)
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
                        else if (String.CompareOrdinal(target,current.Data.returnFirst().Category) > 0)
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
                                current.Right = Delete(current.Right, parent.Data.returnFirst().Category);
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

                public LinkedList<Table2> Find(string key)
                {
                    if (Find(key, Root) == null)
                    {
                        return new LinkedList<Table2>();
                        
                    }
                    if (Find(key, Root).Data.returnFirst().Category == key)
                    {
                        return Find(key, Root).Data;
                    }
                    else
                    {
                        return new LinkedList<Table2>();
                    }
                    return new LinkedList<Table2>();
                }
                public LinkedList<string> DisplayTree()
                {
                    LinkedList<string> temp = new LinkedList<string>();
                    if (Root == null)
                    {
                        string tempStr = "Дерево пустое";
                        temp.Add(tempStr);
                        return temp;
                    }
                    InOrderDisplayTree(Root, temp);
                    return temp;
                }
                private void InOrderDisplayTree(Node current, LinkedList<string> stringing)
                {
                    if (current != null)
                    {
                        InOrderDisplayTree(current.Left, stringing);
                        stringing.Add(current.Data.GetStringRepresentation());
                        InOrderDisplayTree(current.Right, stringing);
                    }
                }
                public Node Find(string target, Node current)
                {
                    if (current == null)
                    {
                        return null;
                    }
                    if (String.CompareOrdinal(target,current.Data.returnFirst().Category) == 0)
                    {
                        return current;
                    }
                    if (String.CompareOrdinal(target,current.Data.returnFirst().Category) < 0)
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