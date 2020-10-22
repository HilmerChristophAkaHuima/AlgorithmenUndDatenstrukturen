using System;
using System.Collections.Generic;
using System.IO;

namespace Blatt2
{
    class Program
    {
        static void Main(string[] args)
        {
            Aufgabe1RegistermaschineUtf32 aufgabe1Registermaschine = new Aufgabe1RegistermaschineUtf32("./RegisterMaschinenCodeUtf32.txt");
            aufgabe1Registermaschine.Run(false);
        }
    }
}
