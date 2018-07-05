using System;
using System.Configuration;
using System.Text.RegularExpressions;

namespace FindReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("Pass regex pattern and replacement");
            }
            else
            {
                /*
                Console.Write("args length is ");
                Console.WriteLine(args.Length);
                for (int i = 0; i < args.Length; i++)
                {
                    string argument = args[i];
                    Console.Write("args index ");
                    Console.Write(i); // Write index
                    Console.Write(" is [");
                    Console.Write(argument); // Write string
                    Console.WriteLine("]");
                }
                */

                //Adding file names
                string SourceFileLocation = ConfigurationManager.AppSettings[@"SourceFileLocation"];
                string DestinationFileLocation = ConfigurationManager.AppSettings[@"DestinationFileLocation"];
                int counter = 1;
                string line;

                //Reading source files  
                System.IO.StreamReader SourceFile1 =
                    new System.IO.StreamReader(SourceFileLocation);

                //Open/Create the destination file in specified location above
                System.IO.StreamWriter DestinationFile =
                    new System.IO.StreamWriter(DestinationFileLocation);

                while ((line = SourceFile1.ReadLine()) != null)
                {
                    string pattern = @"\@subscriber = N'PMRP02\\PMRP02',";
                    string substitution = @"";

                    RegexOptions options = RegexOptions.Multiline | RegexOptions.Singleline | RegexOptions.IgnoreCase;

                    Regex regex = new Regex(pattern, options);
                    string result = regex.Replace(line, substitution);

                    if (result.Length > 0)
                    {
                        //DestinationFile.WriteLine(counter.ToString() + "," + result, true);
                        DestinationFile.WriteLine(result, true);
                    }
                    else Console.WriteLine("No Match on line : " + counter);

                    //Next line
                    counter++;

                }

                SourceFile1.Close();
                DestinationFile.Close();

                Console.WriteLine("There were {0} lines Processed.", counter);
                Console.WriteLine("Generated file is located Here: " + DestinationFileLocation);
                Console.WriteLine("Press Enter key to End...");

            }
            Console.ReadLine();

        }
    }
}
