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
        private readonly List<DescriptorMethod> descriptorMethods; 
        private readonly string inputDirectory;

        public Program(string inputDirectory)
        {
            this.finder = new FinderProblemsWithCode();
            this.descriptorMethods = new List<DescriptorMethod>(); 
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
                descriptorMethods.AddRange(finder.GetDescriptorsMethods(programFile));

            PrintLengthsMethods();
            PrintNestingsMethods();
        }

        public void PrintLengthsMethods()
        {
            PrintAnswer(GetAnswerForMethodsLengths(descriptorMethods), FileWithLongMethods);
        }

        public void PrintNestingsMethods()
        {
           PrintAnswer(GetAnswerForMethodsNestings(descriptorMethods), FileWithNestingsMethods);
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
            this.LineNumber = lineNumber;
            this.Length = length;
            this.NestingLevel = nestingLevel;
            this.FileName = fileName;
        }
    }

    class FinderProblemsWithCode
    {
        private SyntaxAnalyserProgramCode syntaxAnalyser;

        public List<DescriptorMethod> GetDescriptorsMethods(string fileName)
        {
            this.syntaxAnalyser = new SyntaxAnalyserProgramCode(GetSyntaxTreeFromCode(fileName));
            var descriptionOfMethods = new List<DescriptorMethod>();
            var shortFileName = fileName.Split('\\').Last();

            foreach (var methodDeclaration in syntaxAnalyser.GetMethodsFromCode())
            {
                var lineNumber = syntaxAnalyser.GetLineNumberMethod(methodDeclaration);
                var length = syntaxAnalyser.GetLengthMethod(methodDeclaration);
                var nestingLevel = syntaxAnalyser.GetNestingLevelMethod(methodDeclaration);
                
                descriptionOfMethods.Add(new DescriptorMethod(lineNumber, length, nestingLevel, shortFileName));
            }
           
            return descriptionOfMethods;
        }

        private static SyntaxTree GetSyntaxTreeFromCode(string fileName)
        {
            var textProgramCode = File.ReadAllText(fileName);

            return SyntaxTree.ParseText(textProgramCode);
        }
    }

    public class SyntaxAnalyserProgramCode
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
            this.rootSyntaxTreeCode = (CompilationUnitSyntax)syntaxTreeProgramCode.GetRoot();
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
            return Int32.TryParse( locationMethod.ToString()
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
            return method.DescendantNodes().OfType<StatementSyntax>().Where(statement => !(statement is BlockSyntax));
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
