using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace Kontur
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect command line parameters.");
            }
            else
            {
                try
                {
                    var problemSolver = new ProblemSolver(inputDirectory: args[0]);

                    problemSolver.SetAnswersToProblems();

                    problemSolver.PrintAnswers();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
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

    public class ProblemSolver
    {
        private const string FileWithLongMethods = "long.txt";
        private const string FileWithNestingsMethods = "nesting.txt";
        private const int MaxLinesOutputFile = 100;
        private const string FormatOutputStrings = "{0}\t{1}:{2}";

        private readonly List<DescriptorMethod> descriptorsMethods;
        private IEnumerable<string> lengthsMethods;
        private IEnumerable<string> nestingsMethods;

        private readonly string inputDirectory;

        public ProblemSolver(string inputDirectory)
        {
            this.inputDirectory = inputDirectory;
            descriptorsMethods = new List<DescriptorMethod>();
            lengthsMethods = new List<string>();
            nestingsMethods = new List<string>();
        }

        public void SetAnswersToProblems()
        {
            SetAllDescriptorsMethods();

            lengthsMethods = GetAnswerForMethodsLengths();

            nestingsMethods = GetAnswerForMethodsNestings();
        }

        private void SetAllDescriptorsMethods()
        {
            foreach (var programFile in Directory.GetFiles(@inputDirectory))
                descriptorsMethods.AddRange(DescriptorCode.GetDescriptorsMethods(programFile));
        }

        private IEnumerable<string> GetAnswerForMethodsLengths()
        {
            return descriptorsMethods.OrderByDescending(i => i.Length)
                                        .ThenBy(j => j.FileName)
                                        .ThenBy(k => k.LineNumber)
                                        .Take(MaxLinesOutputFile)
                                        .Select(s => String.Format(FormatOutputStrings, s.Length, s.FileName, s.LineNumber))
                                        .ToList();
        }

        private IEnumerable<string> GetAnswerForMethodsNestings()
        {
            return descriptorsMethods.OrderByDescending(i => i.NestingLevel)
                                        .ThenBy(j => j.FileName)
                                        .ThenBy(k => k.LineNumber)
                                        .Take(MaxLinesOutputFile)
                                        .Select(s => String.Format(FormatOutputStrings, s.NestingLevel, s.FileName, s.LineNumber))
                                        .ToList();
        }

        public void PrintAnswers()
        {
            PrintLengthsMethods();
            PrintNestingsMethods();
        }

        private void PrintLengthsMethods()
        {
            PrintAnswerToFile(lengthsMethods, FileWithLongMethods);
        }

        private void PrintNestingsMethods()
        {
            PrintAnswerToFile(nestingsMethods, FileWithNestingsMethods);
        }

        private static void PrintAnswerToFile(IEnumerable<string> linesAnswer, string outputFileName)
        {
            using (var writer = new StreamWriter(outputFileName))
            {
                foreach (var line in linesAnswer)
                    writer.WriteLine(line);
            }
        }
    }

    public static class DescriptorCode
    {
        public static IEnumerable<DescriptorMethod> GetDescriptorsMethods(string fileName)
        {
            var syntaxTreeFromCode = GetSyntaxTreeFromCode(ReadTextProgramCode(fileName));
            var syntaxAnalyser = new SyntaxAnalyserCode(syntaxTreeFromCode);

            var shortFileName = GetShortFileName(fileName);

            return syntaxAnalyser.GetMethodsFromCode()
                                    .Select(methodDeclaration => new DescriptorMethod(syntaxAnalyser.GetLineNumberMethod(methodDeclaration),
                                                                                        syntaxAnalyser.GetLengthMethod(methodDeclaration),
                                                                                        syntaxAnalyser.GetNestingLevelMethod(methodDeclaration),
                                                                                        shortFileName
                                                                                      ));
        }

        private static string GetShortFileName(string fileName)
        {
            return fileName.Split('\\').Last();
        }

        private static string ReadTextProgramCode(string fileName)
        {
            return File.ReadAllText(fileName);
        }

        private static SyntaxTree GetSyntaxTreeFromCode(string textProgramCode)
        {
            return SyntaxTree.ParseText(textProgramCode);
        }
    }

    public class SyntaxAnalyserCode
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
                        typeof (CatchClauseSyntax ),
                        typeof (FinallyClauseSyntax ),
                        typeof (SimpleLambdaExpressionSyntax ),
                        typeof (ParenthesizedLambdaExpressionSyntax ),
                        typeof (AnonymousMethodExpressionSyntax)
        };

        public SyntaxAnalyserCode(SyntaxTree syntaxTreeProgramCode)
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
            return GetStatements(methodDeclaration).Count();
        }

        private static IEnumerable<StatementSyntax> GetStatements(MethodDeclarationSyntax methodDeclaration)
        {
            return methodDeclaration.DescendantNodes()
                .OfType<StatementSyntax>().Where(statementSyntax => !(statementSyntax is BlockSyntax));
        }

        private static IEnumerable<SyntaxNode> GetSyntaxesNodesIncreaseNesting(MethodDeclarationSyntax methodDeclaration)
        {
            return methodDeclaration.DescendantNodes()
                .OfType<SyntaxNode>().Where(IsEnlargersNesting);
        }

        public int GetNestingLevelMethod(MethodDeclarationSyntax methodDeclaration)
        {
            var nestings =  GetSyntaxesNodesIncreaseNesting(methodDeclaration)
                                .Select(statementSyntax => GetNestingLevelStatement(statementSyntax, methodDeclaration))
                                .ToList();

            return nestings.Count == 0 ? 0 : nestings.OrderByDescending(nesting => nesting).First();
        }

        private static int GetNestingLevelStatement(SyntaxNode statement, MethodDeclarationSyntax methodDeclaration)
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
