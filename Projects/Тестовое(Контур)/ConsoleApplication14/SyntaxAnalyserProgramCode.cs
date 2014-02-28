using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;

namespace ConsoleApplication14
{
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

        public int GetNesting(MethodDeclarationSyntax method)
        {
            var set = new HashSet<int>() { 0 };

            var nodes = method.DescendantNodes().OfType<StatementSyntax>().Where(IsEnlargersNesting).ToList();
            int c = 0;

            for (var j = 0; j < nodes.Count; )
            {
                var list = new List<Tuple<SyntaxNode, int>> { Tuple.Create((SyntaxNode)nodes[j], 1) };
                for (var i = 0; i < list.Count; ++i)
                {
                    //Console.WriteLine("Родитель = {0} ,  {1}   -   {2}  !!!!!!!!!", list[i].Item1, list[i].Item2, list[i].Item1.GetType());

                    var li = list[i].Item1.ChildNodes().OfType<SyntaxNode>();
                    set.Add(list[i].Item2);
                    foreach (var statementSyntax in li)
                    {
                        //Console.Write("Ребёнок = ");
                        //Console.WriteLine(statementSyntax);

                        if (IsEnlargersNesting(statementSyntax))
                        {
                            list.Add(Tuple.Create(statementSyntax, list[i].Item2 + 1));
                        }
                        else
                        {
                            if (!(statementSyntax is LiteralExpressionSyntax || statementSyntax is ExpressionStatementSyntax || statementSyntax is IdentifierNameSyntax || statementSyntax is BinaryExpressionSyntax))
                                list.Add(Tuple.Create(statementSyntax, list[i].Item2));
                        }
                        //Console.WriteLine("++++++++++++");
                    }
                    //list.AddRange(li.Where(ii => !(ii is ExpressionStatementSyntax || ii is LiteralExpressionSyntax)));

                    // Console.WriteLine("###########");
                }
                var count = list.Count(ii => IsEnlargersNesting(ii.Item1));
                // Console.WriteLine(count.ToString());
                //Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n\n");
                // j++;
                j += count;
            }

            return set.Last();
        }
    }
}
