using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Blatt2
{
    public class Aufgabe1RegistermaschineUtf32
    {
        public string[] Code { get; set; }
        public List<int> Register { get; set; } = new List<int>();
        public string Befehl { get; set; }
        public int Parameter { get; set; }

        public int Iterator { get; set; }
        public int Akkumulator { get; set; }

        public Aufgabe1RegistermaschineUtf32(string codePfad)
        {
            Code = File.ReadAllLines(codePfad);
        }

        public void Run(bool debug = false)
        {
            for (Iterator = 0; Befehl != "HLT"; Iterator++)
            {
                if (ParseLine(Code[Iterator]))
                {
                    ExecuteLine();
                    if (debug)
                    {
                        Console.WriteLine(DebugString());
                        Console.WriteLine("Enter für nächsten Schritt!");
                        Console.ReadLine();
                    }
                }
            }
        }

        private void ExecuteLine()
        {
            switch (Befehl)
            {
                case "ADD":
                    Akkumulator += Register[Parameter - 1];
                    break;
                case "SUB":
                    Akkumulator -= Register[Parameter - 1];
                    break;
                case "MUL":
                    Akkumulator *= Register[Parameter - 1];
                    break;
                case "DIV":
                    Akkumulator /= Register[Parameter - 1];
                    break;
                case "LDA":
                    Akkumulator = Register[Parameter - 1];
                    break;
                case "LDK":
                    Akkumulator = Parameter;
                    break;
                case "STA":
                    AddToRegister(Parameter - 1, Akkumulator);
                    break;
                case "INP":
                    AddToRegister(Parameter - 1, Console.Read());
                    break;
                case "OUT":
                    Console.Write(char.ConvertFromUtf32(Register[Parameter - 1]));
                    break;
                case "JMP":
                    Iterator = Parameter - 2;
                    break;
                case "JEZ":
                    if (Akkumulator == 0) Iterator = Parameter - 2;
                    break;
                case "JNE":
                    if (Akkumulator != 0) Iterator = Parameter - 2;
                    break;
                case "JLZ":
                    if (Akkumulator < 0) Iterator = Parameter - 2;
                    break;
                case "JLE":
                    if (Akkumulator <= 0) Iterator = Parameter - 2;
                    break;
                case "JGZ":
                    if (Akkumulator > 0) Iterator = Parameter - 2;
                    break;
                case "JGE":
                    if (Akkumulator >= 0) Iterator = Parameter - 2;
                    break;
                case "HLT":
                    Console.WriteLine(DebugString());
                    break;
                default:
                    Console.WriteLine($"Unbekannter Befehl in Zeile: {Iterator}");
                    break;
            }
        }

        private void AddToRegister(int index, int value)
        {
            while (Register.Count - 1 < index)
            {
                Register.Add(0);
            }

            Register[index] = value;
        }

        private bool ParseLine(string line)
        {

            if (!String.IsNullOrWhiteSpace(line))
            {
                var lineSplit = line.Split(' ');
                Befehl = lineSplit[0].ToUpper();
                Parameter = int.Parse(lineSplit[1]);
            }

            return !String.IsNullOrWhiteSpace(line);
        }

        private string DebugString()
        {
            string output = $"Zeile: {Iterator} | {Befehl}: {Parameter} Akkumulator: {Akkumulator}";
            output += "\nRegister:";
            for (int i = 0; i < Register.Count; i++)
            {
                output += $"\n{i + 1}: {Register[i]}";
            }

            return output;
        }
    }
}
