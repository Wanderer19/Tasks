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