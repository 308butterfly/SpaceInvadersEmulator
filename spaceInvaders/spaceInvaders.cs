using System;
using System.IO;

namespace SpaceInvaderEmulator
{
    class Program
    {
        static string ToHex(long value)
        {
            return value.ToString("X");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let the decompiling begin");

            using (FileStream fs = File.Open("../invaders/invaders", FileMode.Open, FileAccess.Read))
            {
                Decompiler decompiler = new(fs);
                decompiler.Decompile();

            }

            Screen.Display2();

        }
    }
}
