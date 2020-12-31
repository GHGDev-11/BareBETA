using System;
using System.Collections.Generic;
using System.IO;

namespace bpp
{
    class Program
    {
        static List<string> argv = new List<string>();
        int st = 0;
        bool time = false;
        static System.String run;
        bool is_string = false;

        /*
        ************************************
        This function needs to be worked on.
        ************************************
        */
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            foreach (string arg in args)
            {
                argv.Add(arg);
            }

            try
            {
                string run = argv[1];
            }
            catch
            {
                Console.WriteLine("Copyright (c) 2020 Bare++.\nAll Rights Reserved.\n\n");
                // Initialize Compiler
                while (true)
                {
                    try
                    {
                        Console.Write(">>> ");
                        string command = Console.ReadLine();
                        string end = "NOTHING";
                        string newlines = "";
                        if (command.EndsWith(":"))
                        {
                            while (end != "")
                            {
                                Console.Write("... ");
                                end = Console.ReadLine();
                                if (end == "")
                                {
                                    break;
                                }
                                else
                                {
                                    newlines += $"\n{end}";
                                }
                            }
                        }
                        command += $"\n{newlines}";

                        /*
                         * Run variable command
                         * V------------^
                         * A string the user inputs.
                         * */
                    }
                    catch
                    {
                        System.Environment.Exit(1);
                    }
                }
            }

            if (argv.Contains("--timeit"))
            {
                // Add a timer
            }

            if (run == "new")
            {
                if (argv.Count < 3)
                {
                    Console.WriteLine("New file types:\n    Command              Type\n----------------------------------------------------------------------------------------\n    console              Console/Terminal Application (For backend applications, no GUI)\n    conole template      Console/Terminal Application Template (For backend applications, no GUI)\n    window               Windowed Application (For front-end applications, with GUI)\n    window template      Windowed Application Template (For front-end applications, with GUI)");
                }
                else
                {
                    var type_ = argv[2];
                    string win_temp = "";
                    if (argv.Count == 4)
                    {
                        win_temp = argv[3];
                    }
                    Console.WriteLine($"Creating new file, type: {type_}");
                    if (type_ == "console" && win_temp == "")
                    {
                        System.IO.File.WriteAllText($@"{Directory.GetCurrentDirectory()}\Application.ba", "|| New Console application - generated with Bare");
                    }
                    else if (type_ == "window" && win_temp == "")
                    {
                        System.IO.File.WriteAllText($@"{Directory.GetCurrentDirectory()}\Application.ba", "||  Imports / Uses\nuse <bagui> -> [built-in]\n\n|| Window Initialization\nnew-window 'root'\n\n|| Window - Start Looping Frames\nloop 'root'");
                    }
                    else if (type_ == "window" && win_temp == "template")
                    {
                        System.IO.File.WriteAllText($@"{Directory.GetCurrentDirectory()}\Application.ba", "||  Imports / Uses\nuse <bagui> -> [built-in]\n\n|| Window Initialization\nnew-window 'root'\n\n|| Window Configuration\nconfigure 'root' ; background-color='#282828' ; title='Application'\n\n|| Add Widgets To Window\nadd-text 'root' ; label='Label_1' ; background-color='#282828' ; foreground-color='white' ; text='Test Application' ; font='Haettenschweiler' ; font-size=65 ; font-weight='normal'\nadd-space 'root' ; '#282828'\nadd-text 'root' ; label='Login' ; background-color='#282828' ; foreground-color='white' ; text='Login' ; font='Haettenschweiler' ; font-size=15 ; font-weight='normal'\nadd-space 'root' ; '#282828'\nadd-inputfield 'root' ; label='Username' ; text='Username'\nadd-inputfield 'root' ; label='Password' ; text='Password'\nmake $checklogin: get-response 'Username'=uname | get-response 'Password'=upass | say 'Username:' | say uname | say '\\\\n' | say 'Password:' | say upass\nadd-space 'root' ; '#282828'\nadd-button 'root' ; label='LoginButton' ; width=25 ; command=$checklogin ; text='Login' ; border=0\n\n|| Window - Start Looping Frames\nloop 'root'");
                    }
                    else if (type_ == "console" && win_temp == "template")
                    {
                        System.IO.File.WriteAllText($@"{Directory.GetCurrentDirectory()}\Application.ba", "|| New Console application - generated with Bare\n\nmake $main:\n    say 'Hello, World!'\n    return 0\n\nif null == 0:\n    $main");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: BPP001: Type '{type_}' does not exist.");
                    }

                }
            }
            RunNormal();
        }

        public static void RunCompiled()
        {
            // Run Compiled
        }

        public static void RunNormal()
        {
            var compiler = new Compiler.Compiler();
            compiler.Compile(Console.ReadLine());
            compiler.Finalize();
        }
    }
}
