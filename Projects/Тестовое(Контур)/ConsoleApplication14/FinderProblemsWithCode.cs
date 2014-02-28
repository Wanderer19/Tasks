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
}
