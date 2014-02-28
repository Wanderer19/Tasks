using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.CSharp;

namespace ConsoleApplication14
{
    class Program
    {
        private const string FileWithLongMethods = "long.txt";
        private const string FileWithNestingsMethods = "nesting.txt";
        private const int MaxLinesOutputFile = 100;
        private const string FormatOutputStrings = "{0}\t{1}:{2}";

        private readonly FinderProblemsWithCode finder;
        private readonly List<DescriptorMethod> descriptorsMethods; 
        private readonly string inputDirectory;

        public Program(string inputDirectory)
        {
            this.finder = new FinderProblemsWithCode();
            this.descriptorsMethods = new List<DescriptorMethod>(); 
            
            this.inputDirectory = inputDirectory;
        }

        static void Main(string[] args)
        {
            try
            {
                var program = new Program(inputDirectory : args[0]);
               
                program.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Run()
        {
            foreach (var programFile in Directory.GetFiles(@inputDirectory))
                descriptorsMethods.AddRange(finder.GetDescriptorsMethods(programFile));

            PrintLengthsMethods();
            PrintNestingsMethods();
        }

        public void PrintLengthsMethods()
        {
            PrintAnswer(GetAnswerForMethodsLengths(descriptorsMethods), FileWithLongMethods);
        }

        public void PrintNestingsMethods()
        {
           PrintAnswer(GetAnswerForMethodsNestings(descriptorsMethods), FileWithNestingsMethods);
        }

        public static IEnumerable<string> GetAnswerForMethodsLengths(List<DescriptorMethod> descriptorsMethods)
        {
            return descriptorsMethods.OrderByDescending(i => i.Length)
                                        .ThenBy(j => j.FileName)
                                        .ThenBy(k => k.LineNumber)
                                        .Take(MaxLinesOutputFile)
                                        .Select(s => String.Format(FormatOutputStrings, s.Length, s.FileName, s.LineNumber))
                                        .ToList();
        }

        public static IEnumerable<string> GetAnswerForMethodsNestings(List<DescriptorMethod> descriptorsMethods)
        {
            return descriptorsMethods.OrderByDescending(i => i.NestingLevel)
                                        .ThenBy(j => j.FileName)
                                        .ThenBy(k => k.LineNumber)
                                        .Take(MaxLinesOutputFile)
                                        .Select(s => String.Format(FormatOutputStrings, s.NestingLevel, s.FileName, s.LineNumber))
                                        .ToList();
        }

        public static void PrintAnswer(IEnumerable<string> outputLines, string outputFileName)
        {
            using (var writer = new StreamWriter(outputFileName))
            {
                foreach (var line in outputLines)
                    writer.WriteLine(line);
            }
        }
    }
}
