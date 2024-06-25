using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListNamespace
{
    public class LinkedList
    {
        private Node head;

        public LinkedList()
        {
            this.head = null;
        }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if (head == null)
            {
                head = newNode;

            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public bool Remove(int data)
        {
            if (head == null)
            {
                return false;
            }
            if (head.Data == data)
            {
                head = head.Next;
                return true;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Display()
        {
            Node current = head;
            while (current != null)
            {
                Console.Write(current.Data + " -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }

        public bool Find(int data)
        {
            Node current = head;
            while (current != null)
            {
              if (current.Data == data)
              {
                    return true;
              }
              current = current.Next;
                
                
            }
            return false;
        }

        public int Length()
        {
            int length = 0;
            Node current = head;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
            return length; 
        }
    }
}
