using System;
using System.Collections;
using System.Collections.Generic;

namespace Kurs_Project
{
    
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }
    
    public class LinkedList<T> : IEnumerable<T>  // односвязный список
    {
        Node<T> _head; 
        Node<T> _tail; 
        int _count; 

        
        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
 
            if (_head == null)
                _head = node;
            else
                _tail.Next = node;
            _tail = node;
 
            _count++;
        }
        // удаление элемента
        public bool Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;
 
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;
 
                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            _tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        _head = _head.Next;
 
                        // если после удаления список пуст, сбрасываем tail
                        if (_head == null)
                            _tail = null;
                    }
                    _count--;
                    return true;
                }
 
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public T returnFirst()
        {
            return _head.Data;
        }
        
        public int Count { get { return _count; } }
        public bool IsEmpty { get { return _count == 0; } }
        // очистка списка
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = _head;
            _head = node;
            if (_count == 0)
                _tail = _head;
            _count++;
        }
        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public T[] Getter()
        {
            T[] tempMas = new T[Count];
            Node<T> temp = _head;
            for(int i = 0; i < Count; i++)
            {
                tempMas[i] = temp.Data;
                temp = temp.Next;
            }
            return tempMas;
        }
        
        public string GetStringRepresentation()
        {
            string representation = "[";
            Node<T> temp = _head;
            for(var i = 0; i < Count; i++)
            {
                representation += temp.Data.ToString();
                if (i < Count - 1)
                {
                    representation += ", ";
                }

                temp = temp.Next;
            }
            representation += "]";
            return representation;
        }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}