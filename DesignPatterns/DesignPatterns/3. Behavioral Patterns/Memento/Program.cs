using System;
using DesignPatterns.Memento;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Memento()
        {
            var textBox = new TextBox();
            var caretaker = new Caretaker(textBox);
            Console.WriteLine("························ Initialize");
            textBox.Text = "Hello world!";
            Console.WriteLine("························ Selection 3 -> 3");
            textBox.Select(new Selection(3, 3));
            textBox.MoveCaretBy(2);
            Console.WriteLine(textBox);
            caretaker.Snapshot();
            Console.WriteLine("························ Snapshot");

            Console.WriteLine("························ Edit");
            textBox.Text = "Good bye world!";
            Console.WriteLine("························ Selection 4 -> 4");
            textBox.Select(new Selection(4, 5));
            textBox.MoveCaretBy(8);
            Console.WriteLine(textBox);
            caretaker.Snapshot();
            Console.WriteLine("························ Snapshot");

            Console.WriteLine("························ Edit");
            textBox.Text = "Foo";
            Console.WriteLine(textBox);
            caretaker.Undo();
            Console.WriteLine("························ Undo");
            Console.WriteLine(textBox);
            caretaker.Undo();
            Console.WriteLine("························ Undo");
            Console.WriteLine(textBox);
        }
    }
}