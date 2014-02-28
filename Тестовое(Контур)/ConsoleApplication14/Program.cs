using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        private readonly Dictionary<int, List<Tuple<string, int>>> methodsListOfLength; 
        private readonly Dictionary<int, List<Tuple<string, int>>> methodsListOfNestingLevel;
        private readonly FinderProblemsWithStyleCode finder;
        private readonly string inputDirectory;

        public Program(string inputDirectory)
        {
            this.methodsListOfLength = new Dictionary<int, List<Tuple<string, int>>>();
            this.methodsListOfNestingLevel = new Dictionary<int, List<Tuple<string, int>>>();
            this.finder = new FinderProblemsWithStyleCode();

            this.inputDirectory = inputDirectory;
        }

        static void Main(string[] args)
        {
            try
            {
                var program = new Program(args[0]);
                
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
                FindProblems(programFile);
            
            PrintLengthsMethods();
            PrintNestingsMethods();
        }
        
        private void FindProblems(string programFile)
        {
            var shortFileName = programFile.Split('\\').Last();
            
            foreach (var descriptorMethod in finder.FindProblems(programFile))
            {
                AddLengthMethod(descriptorMethod, shortFileName);
                AddNestingLevelMethod(descriptorMethod, shortFileName);
            }
        }

        public void AddNestingLevelMethod(DescriptorMethod descriptorMethod, string fileName)
        {
            if (!methodsListOfNestingLevel.ContainsKey(descriptorMethod.NestingLevel))
                methodsListOfNestingLevel.Add(descriptorMethod.NestingLevel, new List<Tuple<string, int>>());

            methodsListOfNestingLevel[descriptorMethod.NestingLevel].Add(Tuple.Create(fileName, descriptorMethod.LineNumber));
        }

        public void AddLengthMethod(DescriptorMethod descriptorMethod, string fileName)
        {
            if (!methodsListOfLength.ContainsKey(descriptorMethod.Length))
                methodsListOfLength.Add(descriptorMethod.Length, new List<Tuple<string, int>>());


            methodsListOfLength[descriptorMethod.Length].Add(Tuple.Create(fileName, descriptorMethod.LineNumber));
        }

        public void PrintLengthsMethods()
        {
            PrintResults(GetOutputLines(methodsListOfLength), FileWithLongMethods);
        }

        public void PrintNestingsMethods()
        {
           PrintResults(GetOutputLines(methodsListOfNestingLevel), FileWithNestingsMethods);
        }

        public static IEnumerable<string> GetOutputLines(Dictionary<int, List<Tuple<string, int>>> methodListOfParameter)
        {
            // Переделать
            var countLines = 0;
            var isOver = false;
            var outputLines = new List<string>();

            foreach (var parameter in methodListOfParameter.Keys.OrderByDescending(i => i))
            {
                foreach (var methodDefinition in methodListOfParameter[parameter].OrderBy(i => i.Item1).ThenBy(j => j.Item2))
                {
                    if (countLines < MaxLinesOutputFile)
                    {
                        outputLines.Add(String.Format("{0}  {1} : {2}", parameter, methodDefinition.Item1, methodDefinition.Item2));

                        countLines++;
                    }
                    else
                    {
                        isOver = true;

                        break;
                    }
                }

                if (isOver)
                    break;
            }

            return outputLines;
        }

        public static void PrintResults(IEnumerable<string> outputLines, string outputFileName)
        {
            using (var writer = new StreamWriter(outputFileName))
            {
                foreach (var line in outputLines)
                    writer.WriteLine(line);
            }
        }
    }
}
