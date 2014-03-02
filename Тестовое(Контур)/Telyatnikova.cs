using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace Kontur
{
    class Program
    {
        private const string FileWithLongMethods = "long.txt";
        private const string FileWithNestingsMethods = "nesting.txt";
        private const int MaxLinesOutputFile = 100;
        private const string FormatOutputStrings = "{0}\t{1}:{2}";

        private readonly List<DescriptorMethod> descriptorsMethods;
        private readonly string inputDirectory;

        public Program(string inputDirectory)
        {
            descriptorsMethods = new List<DescriptorMethod>();

            this.inputDirectory = inputDirectory;
        }

        static void Main(string[] args)
        {
            try
            {
                var program = new Program(inputDirectory: args[0]);

                program.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void Run()
        {
            GetAllDescriptorsMethods();

            PrintLengthsMethods();
            
            PrintNestingsMethods();
        }

        public void GetAllDescriptorsMethods()
        {
            foreach (var programFile in Directory.GetFiles(@inputDirectory))
                descriptorsMethods.AddRange(FinderProblemsWithCode.GetDescriptorsMethods(programFile));
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

    public struct DescriptorMethod
    {
        public int LineNumber;
        public int Length;
        public int NestingLevel;
        public string FileName;

        public DescriptorMethod(int lineNumber, int length, int nestingLevel, string fileName)
        {
            LineNumber = lineNumber;
            Length = length;
            NestingLevel = nestingLevel;
            FileName = fileName;
        }
    }

    class FinderProblemsWithCode
    {
        public static IEnumerable<DescriptorMethod> GetDescriptorsMethods(string fileName)
        {
            var syntaxTreeFromCode = GetSyntaxTreeFromCode(ReadTextProgramCode(fileName));
            var syntaxAnalyser = new SyntaxAnalyserProgramCode(syntaxTreeFromCode);

            var shortFileName = GetShortFileName(fileName);

            return syntaxAnalyser.GetMethodsFromCode()
                                    .Select(methodDeclaration => new DescriptorMethod(syntaxAnalyser.GetLineNumberMethod(methodDeclaration),
                                                                                        syntaxAnalyser.GetLengthMethod(methodDeclaration),
                                                                                        syntaxAnalyser.GetNestingLevelMethod(methodDeclaration),
                                                                                        shortFileName
                                                                                      ));
        }

        public static string GetShortFileName(string fileName)
        {
            return fileName.Split('\\').Last();
        }

        public static string ReadTextProgramCode(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        private static SyntaxTree GetSyntaxTreeFromCode(string textProgramCode)
        {
            return SyntaxTree.ParseText(textProgramCode);
        }
    }

    class SyntaxAnalyserProgramCode
    {
        private readonly CompilationUnitSyntax rootSyntaxTreeCode;
        private static readonly List<Type> TypesIncreaseNesting = new List<Type>() 
        {
                        typeof (IfStatementSyntax ), 
                        typeof (SwitchStatementSyntax ),
                        typeof (ForStatementSyntax ),
                        typeof (ForEachStatementSyntax),
                        typeof (DoStatementSyntax ),
                        typeof (WhileStatementSyntax ),
                        typeof (CheckedStatementSyntax ),
                        typeof (FixedStatementSyntax ),
                        typeof (UsingStatementSyntax ),
                        typeof (LockStatementSyntax ),
                        typeof (UnsafeStatementSyntax ),
                        typeof (TryStatementSyntax ),
                        typeof (CatchDeclarationSyntax ),
                        typeof (FinallyClauseSyntax ),
                        typeof (SimpleLambdaExpressionSyntax ),
                        typeof (ParenthesizedLambdaExpressionSyntax ),
                        typeof (AnonymousMethodExpressionSyntax)
        };

        public SyntaxAnalyserProgramCode(SyntaxTree syntaxTreeProgramCode)
        {
            rootSyntaxTreeCode = (CompilationUnitSyntax)syntaxTreeProgramCode.GetRoot();
        }

        public IEnumerable<MethodDeclarationSyntax> GetMethodsFromCode()
        {
            return rootSyntaxTreeCode.DescendantNodes().OfType<MethodDeclarationSyntax>();
        }

        public int GetLineNumberMethod(MethodDeclarationSyntax methodDeclaration)
        {
            var locationMethod = methodDeclaration.GetLocation()
                                                    .GetLineSpan(false)
                                                    .StartLinePosition;

            int lineNumber;
            return Int32.TryParse(locationMethod.ToString()
                                                    .Split(',')
                                                    .First(), out lineNumber

                                  ) ? lineNumber + 1 : -1;
        }

        public int GetLengthMethod(MethodDeclarationSyntax methodDeclaration)
        {
            return GetStatementSyntaxs(methodDeclaration).Count();
        }

        private static IEnumerable<StatementSyntax> GetStatementSyntaxs(MethodDeclarationSyntax method)
        {
            return method.DescendantNodes()
                            .OfType<StatementSyntax>()
                            .Where(statement => !(statement is BlockSyntax));
        }


        public int GetNestingLevelMethod(MethodDeclarationSyntax methodDeclaration)
        {
            var nestings = GetStatementSyntaxs(methodDeclaration)
                                .Select(statementSyntax => GetNestingLevelStatement(statementSyntax, methodDeclaration))
                                .ToList();

            return nestings.Count == 0 ? 0 : nestings.OrderByDescending(nesting => nesting).First();
        }

        private static int GetNestingLevelStatement(StatementSyntax statement, MethodDeclarationSyntax methodDeclaration)
        {
            var nestingLevelStatement = IsEnlargersNesting(statement) ? 1 : 0;
            var parentStatement = statement.Parent;

            while (parentStatement != null && parentStatement != methodDeclaration)
            {
                if (IsEnlargersNesting(parentStatement))
                    nestingLevelStatement++;

                parentStatement = parentStatement.Parent;
            }

            return nestingLevelStatement;
        }

        private static bool IsEnlargersNesting(SyntaxNode statementSyntax)
        {
            return TypesIncreaseNesting.Any(type => statementSyntax.GetType() == type);
        }
    }
}
