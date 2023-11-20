using System.ComponentModel.DataAnnotations;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            Player1 player = new Player1();
            Console.ForegroundColor = ConsoleColor.White;
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            Console.WriteLine(Display("Otthon", "Péntek este van. Otthon vagy.", "Milyen járművel indulsz el?", options, player));

        }
    }
}