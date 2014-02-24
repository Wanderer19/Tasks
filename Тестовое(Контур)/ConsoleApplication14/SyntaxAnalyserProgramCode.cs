using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace ConsoleApplication14
{
    class SyntaxAnalyserProgramCode
    {
        private readonly CompilationUnitSyntax rootSyntaxTreeCode;

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
            return Int32.TryParse(locationMethod.ToString()
                                                .Split(',')
                                                .First(), out lineNumber
                                                ) ? lineNumber + 1 : -1;
        }

        public int GetLengthMethod(MethodDeclarationSyntax methodDeclaration)
        {
            return GetStatementSyntaxs(methodDeclaration).Count(statementSyntax => !(statementSyntax is BlockSyntax));
        }

        private static IEnumerable<StatementSyntax> GetStatementSyntaxs(MethodDeclarationSyntax method)
        {
            return method.DescendantNodes().OfType<StatementSyntax>();
        }


        public int GetNestingLevelMethod(MethodDeclarationSyntax methodDeclaration)
        {

            var statementSyntax = GetStatementSyntaxs(methodDeclaration);
         
            var nestings = statementSyntax.Where(statement => !(statement is BlockSyntax) && IsEnlargersNesting(statement))
                                            .Select(i => GetNestingLevelStatement(i, methodDeclaration))
                                            .ToList();
           
            return nestings.Count == 0 ? 0 : nestings.OrderByDescending(nesting => nesting).First();
        }

        private int GetNestingLevelStatement(StatementSyntax statement, MethodDeclarationSyntax methodDeclaration)
        {
            var nestingLevelStatement = 1;
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
            return (
                        statementSyntax is IfStatementSyntax || 
                        statementSyntax is SwitchStatementSyntax ||
                        statementSyntax is ForStatementSyntax ||
                        statementSyntax is ForEachStatementSyntax ||
                        statementSyntax is DoStatementSyntax || 
                        statementSyntax is WhileStatementSyntax ||
                        statementSyntax is CheckedStatementSyntax || 
                        statementSyntax is FixedStatementSyntax ||
                        statementSyntax is UsingStatementSyntax || 
                        statementSyntax is LockStatementSyntax ||
                        statementSyntax is UnsafeStatementSyntax || 
                        statementSyntax is TryStatementSyntax ||
                        statementSyntax is CatchDeclarationSyntax || 
                        statementSyntax is FinallyClauseSyntax
                   );
        }
    }
}
