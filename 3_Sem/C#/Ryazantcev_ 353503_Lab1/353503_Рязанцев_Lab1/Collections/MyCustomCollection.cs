using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _353503_Рязанцев_Lab1.Collections
{
    internal class MyCustomCollection<T> : Interfaces.ICustomCollection<T>
    {
        public class Node
        {
            public T? Value;
            public Node? next;

            public Node(T? value)
            {
                Value = value;
            }
        }

        public MyCustomCollection()
        {
            head = null;
            counter = 0;
        }

        Node? head;
        Node? current;
        int counter = 0;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= counter)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }

                return GetNodeAt(index).Value;
            }
            set
            {
                if (index < 0 || index >= counter)
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
                 
                GetNodeAt(index).Value = value;
            }
        }

        private Node GetNodeAt(int index)
        {
            if(head == null)
            {
                return null;
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        public void Reset()
        {
            current = head;
        }
        public void Next()
        {
            if(current.next != null)
            {
                current = current.next;
            }
        } 
        public T Current()
        {
            return current.Value;
        }
        public void Add(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }

            counter++;
        }
        public void Remove(int item)
        {
            if (item < 0 || item >= counter)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (item == 0)
            {
                head = head.next;
            }
            else
            {
                Node previous = GetNodeAt(item - 1);
                previous.next = previous.next.next;
            }

            counter--;
        }
        public int Count 
        {
            get { return counter; }
        }
        public T RemoveCurrent()
        {
            if(current != null)
            {
                if (current == head)
                {
                    Node DeletedNode = head;
                    head = head.next;
                    return DeletedNode.Value;
                }
                else
                {
                    Node previous = head;

                    while (previous != null && previous.next != current)
                    {
                        previous = previous.next;
                    }
                    if (previous == null)
                    {
                        throw new InvalidOperationException("The node to delete does not exist in the list");
                    }

                    Node DeletedNode = previous.next;
                    previous.next = current.next;

                    counter--;

                    return DeletedNode.Value;
                }
            }
            else
            {
                throw new InvalidOperationException("The node to delete does not exist in the list");
            }
            
        }
    }
}
