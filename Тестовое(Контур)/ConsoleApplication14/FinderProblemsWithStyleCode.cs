using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Compilers.CSharp;

namespace ConsoleApplication14
{
    public struct DescriptorMethod
    {
        public int LineNumber;
        public int Length;
        public int NestingLevel;

        public DescriptorMethod(int lineNumber, int length, int nestingLevel)
        {
            this.LineNumber = lineNumber;
            this.Length = length;
            this.NestingLevel = nestingLevel;
        }
    }

    class FinderProblemsWithStyleCode
    {
        private SyntaxAnalyserProgramCode syntaxAnalyser;

        public List<DescriptorMethod> FindProblems(string fileName)
        {
            this.syntaxAnalyser = new SyntaxAnalyserProgramCode(GetSyntaxTreeFromCode(fileName));
            var descriptionOfMethods = new List<DescriptorMethod>();
            
            foreach (var methodDeclaration in syntaxAnalyser.GetMethodsFromCode())
            {
                var lineNumber = syntaxAnalyser.GetLineNumberMethod(methodDeclaration);
                var length = syntaxAnalyser.GetLengthMethod(methodDeclaration);
                var nestingLevel = syntaxAnalyser.GetNestingLevelMethod(methodDeclaration);

                descriptionOfMethods.Add(new DescriptorMethod(lineNumber, length, nestingLevel));
            }

            return descriptionOfMethods;
        }

        private static SyntaxTree GetSyntaxTreeFromCode(string fileName)
        {
            var textProgramCode = File.ReadAllText(fileName);

            return SyntaxTree.ParseText(textProgramCode);
        }
    }
}
