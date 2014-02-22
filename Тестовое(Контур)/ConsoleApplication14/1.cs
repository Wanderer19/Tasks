using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace ConsoleApplication14
{
    class FinderProblemsWithStyleCode
    {
        public struct DataFunction
        {
            public int LineNumber;
            public int CountStatements;
            public int MaximumNesting;

            public DataFunction(int lineNumber, int countStatements, int maximumNesting)
            {
                this.LineNumber = lineNumber;
                this.CountStatements = countStatements;
                this.MaximumNesting = maximumNesting;
            }
        }

        public static List<DataFunction> FindProblems(string fileName)
        {
            var syntaxAnalyser = new SyntaxAnalyserProgramCode(GetSyntaxTreeFromCode(fileName));

            foreach (var method in syntaxAnalyser.GetMethodsFromCode())
            {

            }

            return null;
        }

        private static SyntaxTree GetSyntaxTreeFromCode(string fileName)
        {
            var textProgramCode = File.ReadAllText(fileName);

            return SyntaxTree.ParseText(textProgramCode);
        }

        public static List<Tuple<int, int>> GetLengthsFunctions(string fileName)
        {
            var aboutCodeMethods = new List<Tuple<int, int>>();
           
            var syntaxAnalyser = new SyntaxAnalyserProgramCode(GetSyntaxTreeFromCode(fileName));

            foreach (var method in syntaxAnalyser.GetMethodsFromCode())
            {
                var lineNumber = syntaxAnalyser.GetLineNumberMethod(method);
                var countStatements = syntaxAnalyser.GetCountStatementsMethod(method);

                aboutCodeMethods.Add(Tuple.Create(countStatements, lineNumber));
            }

            return aboutCodeMethods;
        }

        public static List<Tuple<int, int>> GetNestingFunctions(string fileName)
        {
            var aboutCodeMethods = new List<Tuple<int, int>>();

            var textProgramCode = File.ReadAllText(fileName);

            var syntaxAnalyser = new SyntaxAnalyserProgramCode(SyntaxTree.ParseText(textProgramCode));

            foreach (var method in syntaxAnalyser.GetMethodsFromCode())
            {
                var lineNumber = syntaxAnalyser.GetLineNumberMethod(method);
                var maximumNesting = syntaxAnalyser.GetMaximumNesting(method);

                aboutCodeMethods.Add(Tuple.Create(maximumNesting, lineNumber));
               // break;
            }
			
			 return  syntaxAnalyser.GetMethodsFromCode().AsParallel()
                    .Select(
                        i =>
                            new DataFunction(syntaxAnalyser.GetLineNumberMethod(i), GetLengthsFunctions(i),
                                GetNestingFunctions(i))).ToList();
								
            return aboutCodeMethods;
        } 
    }
}
