using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.CSharp;

namespace ConsoleApplication15
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SyntaxTree tree = SyntaxTree.ParseText(
                @"using System;
class Sample
{
       public class A
       {
            
             override protected void SendBuffer(LoggingEvent[] events)
		{
			 if (m_reconnectOnError && (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open))
			{

				InitializeDatabaseConnection();
				InitializeDatabaseCommand();
			}
				else if (x == 0)
				{
					TestDelegate myDel = n => { string s = n; Console.WriteLine(s); };
				}

                try{

                }
                catch(Exception ex){
                
                }
			}
		}

       }
}");

            var root = (CompilationUnitSyntax) tree.GetRoot();
            var firstMember = root.Members[0];
            //var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
            //var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
            // var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[1];

            var methods = root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>();

            var helloWorldString = root.DescendantNodes()
                .OfType<StatementSyntax>();

            int count = 0;

            foreach (var method in methods)
            {
                var set = new HashSet<int>() {0};
                
                var nodes = method.DescendantNodes().OfType<StatementSyntax>().Where(IsEnlargersNesting).ToList();
               
               
                for(var j = 0; j < nodes.Count;)
                {
                    var list = new List<Tuple<SyntaxNode, int>>();
                    list.Add(Tuple.Create((SyntaxNode)nodes[j], 1));
                    for (var i = 0; i < list.Count; ++i)
                    {
                        Console.WriteLine("Родитель = {0} ,  {1}   -   {2}  !!!!!!!!!", list[i].Item1, list[i].Item2, list[i].Item1.GetType());
                       
                        var li = list[i].Item1.ChildNodes().OfType<SyntaxNode>();
                        set.Add(list[i].Item2);
                        foreach (var statementSyntax in li)
                        {
                            Console.Write("Ребёнок = ");
                            Console.WriteLine(statementSyntax);
                            
                            if (IsEnlargersNesting(statementSyntax))
                            {
                                list.Add(Tuple.Create(statementSyntax, list[i].Item2 + 1));
                            }
                            else
                            {
                                if (!(statementSyntax is LiteralExpressionSyntax || statementSyntax is ExpressionStatementSyntax || statementSyntax is IdentifierNameSyntax || statementSyntax is BinaryExpressionSyntax))
                                    list.Add(Tuple.Create(statementSyntax, list[i].Item2));
                            }
                            Console.WriteLine("++++++++++++");
                        }
                         //list.AddRange(li.Where(ii => !(ii is ExpressionStatementSyntax || ii is LiteralExpressionSyntax)));
                        
                        Console.WriteLine("###########");
                    }
                    count = list.Where(ii => IsEnlargersNesting(ii.Item1)).Count();
                    Console.WriteLine(count.ToString());
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n\n");
                   // j++;
                    j += count;
                }

                Console.WriteLine("NESTING   ==   {0}", set.Last());
            }

            
        }

       
        private static bool IsEnlargersNesting(SyntaxNode statement)
        {
            return (
              
                        statement is IfStatementSyntax ||
                        statement is SwitchStatementSyntax ||
                        statement is ForStatementSyntax ||
                        statement is ForEachStatementSyntax ||
                        statement is DoStatementSyntax ||
                        statement is WhileStatementSyntax ||
                        statement is CheckedStatementSyntax ||
                        statement is FixedStatementSyntax ||
                        statement is UsingStatementSyntax ||
                        statement is LockStatementSyntax ||
                        statement is UnsafeStatementSyntax ||
                        statement is TryStatementSyntax ||
                        statement is CatchDeclarationSyntax ||
                        statement is FinallyClauseSyntax ||
                        statement is AnonymousMethodExpressionSyntax ||
                       statement is SimpleLambdaExpressionSyntax ||
                           statement is ParenthesizedLambdaExpressionSyntax
                        );
        }
    }
}
