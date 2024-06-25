using System.ComponentModel.DataAnnotations;

namespace LinkedListNamespace;

class Program
{
    static void Main(string[] args)
    {
        LinkedList list = new LinkedList();

        list.Add(0);
        list.Add(1);
        list.Add(2);
        list.Add(3);

        list.Display();

        list.Remove(2);
        list.Display();
        bool found = list.Find(0);
        int lenngth = list.Length();

        Console.WriteLine("found 0:" + found + " length: " + lenngth);
    }
}