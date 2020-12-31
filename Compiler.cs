using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Compiler
{

    class Compiler
    {
        static bool tryTrue = false;
        static bool exceptTrue = true;
        public string file;
        bool goodGrammar = true;
        string ptf = Directory.GetCurrentDirectory();
        static List<string> keywords = new List<string>();
        public string csscript = "using System;\n\nnamespace BareRunTime\n{\n    class BareRunTime\n    {\n        static void Main()\n        {";
        

        public void Compile(string command)
        {
            string[] content = Regex.Split(command, "\n");
            foreach (string line in content)
            {
                string[] words = Regex.Split(line, " ");
                foreach (string word in words)
                {
                    if (keywords.Contains(word) && !word.Contains("'") && !word.Contains("\"") && line.StartsWith(word)) ;
                    {
                        switch (word)
                        {
                            case "say":
                                Add($"Console.WriteLine({line.Substring(4, line.Length - 4)});");
                                break;
                            case "ask":
                                Add($"Console.Write({line.Substring(4, line.Length - 4)})\nConsole.ReadLine();");
                                break;
                        }
                    }
                }
            }
            // Execute The script we just compiled from Bare to CS
        }

        private void exec(string script)
        {
            Console.WriteLine(csscript);
        }

        private void Add(string script)
        {
            string[] scriptsplit = Regex.Split(script, "\n");
            foreach (string scriptline in scriptsplit)
            {
                csscript += $"\n            {scriptline}";
            }
        }

        public void Finalize()
        {
            csscript += "\n        }\n    }\n}";
            exec(csscript);
        }

        public void Error(string name, string details, int ln, int wn, string fn)
        {
            switch (tryTrue)
            {
                case false:
                    switch (goodGrammar)
                    {
                        case false:
                            Console.WriteLine("\nDuring this error, another error occurred:\n");
                            break;
                    }
                    Console.WriteLine("Error (Most recent is shown last):\n  File '<{fn}>',");
                    try
                    {
                        switch (ln.GetType().ToString())
                        {
                            case "string":
                                Console.WriteLine($"    Line '<lift>', word {wn}:");
                                break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"    Line {ln}, word {wn}:");
                    }
                    Console.WriteLine($"{name}:\n    {details}");
                    goodGrammar = false;
                    tryTrue = true;
                    break;
                default:
                    exceptTrue = true;
                    break;
            }
            
        }
    }
}
