using System;
using System.Collections.Generic;
using System.IO;

namespace branchcompiler
{
    public class trunk
    {
        public string type;
        public string input;
        public trunk(string type, string input)
        {
            this.type = type;
            this.input = input.Replace('_', ' ');
        }

        public string run()
        {
            string l = "";
            switch(this.type)
            {
                case "oak":
                    Console.WriteLine(input);
                    break;
                case "birch":
                    Console.Write(input + " ");
                    l = Console.ReadLine();
                    break;
                case "spruce":
                    Console.ReadLine();
                    l = "";
                    break;
                case "null":
                    l = input;
                    break;
                case "flush":
                    break;
            }
            return l;
        }
    }
    public class main
    {
        public static void Main(string[] args)
        {
            List<string> currents = new List<string>();
            currents.Add("root");
            string current = "root";
            string[] lines = File.ReadAllLines(args[0]);
            List<string> output = new List<string>();
            string outputmain = "";
            for(int i = 0; i < lines.Length; i++)
            {
                string unclean = lines[i];
                string[] line = unclean.Trim().Split(" ");
                switch (line[0])
                {
                    case ("branch"):
                        if (line.Length > 3)
                        {
                            if (outputmain == "!exit!")
                            {
                                break;
                            }
                            if (outputmain == line[2] && current == line[3])
                            {
                                current = line[1];
                                currents.Add(line[1]);
                            }
                        }
                        break;
                    case ("end"):
                        if (current == line[1])
                        {
                            currents.Remove(currents[currents.Count - 1]);
                            if (current != "root") current = currents[currents.Count - 1];
                        }
                        break;
                    case ("trunk"):
                        if (line[3] != current) break;
                        if (line[2] != "!input!")
                        {
                            output.Add(new trunk(line[1], line[2]).run());
                        }
                        else if (line[2] == "!input!")
                        {
                            string x = (new trunk(line[1], compile(output)).run());
                            output = new List<string>();
                            output.Add(x);
                        }
                        break;
                }
                outputmain = compile(output);
            }
        }

        public static string compile(List<string> s)
        {
            string x = "";
            for (int i = 0; i < s.Count; i++)
            {
                x += s[i];
            }
            return x;
        }
    }
}
