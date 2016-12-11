using System;
using DesignPatterns.Interpreter;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    public partial class Program
    {
        public static void Interpreter()
        {
            Console.WriteLine("Trurn on speakers...");
            var player = new MidiPlayer();
            //var player = new BeepPlayer();
            var context = new Context(player);

            var melody = Parser.Parse(OdeToJoy);

            using (player)
            {
                player.Init();
                melody.Execute(context);
            }
        }

        const string Gamma = @"l4 CDEFGABB#";
        const string OdeToJoy = 
                @"L4
                E E F G   G F E D   C C D E   E.D8D2
                E E F G   G F E D   C C D E   D.C8C2
                D2  D E   CD8E8FE   CD8E8FE   D C D2
                E E F G   G F E D   C C D E   D.C8C2";
    }
}