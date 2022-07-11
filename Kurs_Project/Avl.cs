using System;
using System.Collections.Generic;

namespace Kurs_Project
{
    public class Avl
    {
        public enum NodePosition
        {
            left,
            right,
            center
        }
        public class Node
        {
            public LinkedList<Table2> Data = new LinkedList<Table2>();
            public Node Left;
            public Node Right;
            public Node(Table2 data)
            {
                this.Data.Add(data);
            }
            private string PrintValue(string value, NodePosition nodePostion)
            {
                switch (nodePostion)
                {
                    case NodePosition.left:
                        return ($"L: {value}");
                    case NodePosition.right:
                        return ($"R: {value}");
                    case NodePosition.center:
                        return (value);
                    default:
                        return "0";
                }
            }
            public void PrintPretty(string indent, NodePosition nodePosition, bool last, bool empty, LinkedList<string> str)
            {
                string temp = "";
                temp += (indent);
                if (last)
                {
                    temp += ("└─");
                    indent += "  ";
                }
                else
                {
                    temp += ("├─");
                    indent += "| ";
                }

                var stringValue = empty ? "-" : Data.GetStringRepresentation();
                temp += empty ?  PrintValue("-", nodePosition): PrintValue(Data.GetStringRepresentation(), nodePosition);
                str.Add(temp);
                if(!empty && (this.Left != null || this.Right != null))
                {
                    if (this.Left != null)
                        this.Left.PrintPretty(indent, NodePosition.left, false, false, str);
                    else
                        PrintPretty(indent, NodePosition.left, false, true, str);

                    if (this.Right != null)
                        this.Right.PrintPretty(indent, NodePosition.right, true, false, str);
                    else
                        PrintPretty(indent, NodePosition.right, true, true, str);
                }
            }
            
        }
        
        public LinkedList<string> Print()
        {
            LinkedList<string> tmp = new LinkedList<string>();
            if (Root == null)
            {
                return tmp;
            }
            Root.PrintPretty("", NodePosition.center, true, false, tmp);
            return tmp;
        }
        
        
        public Node Root;
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
            if (temp2 == null)
            {
                return;
            }
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