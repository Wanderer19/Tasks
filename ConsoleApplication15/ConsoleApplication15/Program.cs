using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.CSharp;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree tree = SyntaxTree.ParseText(
@"using System;
class Sample
{
       public class A
       {
             public int f1(bool x)
             {
                    while (true)
                           if (x)
                                  return 1;
                    return 2;
             }
             
             public void f1()
             {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
             }

             bool f2()
             {
                    int a = 1;
                    f1();
                    if (true)
                    {
                           Func< bool, bool> not = b =>!b;
                           return not(false);
                    }
                    else
                           return false;
             }
       }
}");
            
            var root = (CompilationUnitSyntax)tree.GetRoot();
            var firstMember = root.Members[0];
            //var helloWorldDeclaration = (NamespaceDeclarationSyntax)firstMember;
            //var programDeclaration = (ClassDeclarationSyntax)helloWorldDeclaration.Members[0];
           // var mainDeclaration = (MethodDeclarationSyntax)programDeclaration.Members[1];
         
            var methods = root.DescendantNodes()
                .OfType<MethodDeclarationSyntax>();
          
            var helloWorldString = root.DescendantNodes()
                .OfType<StatementSyntax>();

           /* foreach (var syntax in helloWorldString.Where(i => !(i is BlockSyntax) ))
            {
                
                Console.WriteLine(syntax);
                Console.WriteLine(syntax.GetType());
                Console.WriteLine("#############");
            }*/


            foreach (var method in methods)
            {
                var r = method.GetLocation().GetLineSpan(false).StartLinePosition;
                Console.WriteLine(r.ToString());
               var ss= method.Body.OpenBraceToken;
                    
                var s = method.DescendantNodes().OfType<StatementSyntax>();
                foreach (var syntax in s.Where(i => !(i is BlockSyntax)))
                {

                    Console.WriteLine(syntax);
                    Console.WriteLine(syntax.GetType());
                    Console.WriteLine("++++++++++++++++++++++++");
                }
                Console.WriteLine("###########");
            }
            //Console.WriteLine(helloWorldString);
        }
    }
}
