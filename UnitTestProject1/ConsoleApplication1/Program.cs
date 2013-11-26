using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Finder
    {
        public List<int> Find(Dictionary<string, List<int>> invertIndex, string[] requestWords)
        {
            try
            {
                var result = requestWords.Select(requestWord => invertIndex[requestWord]).ToList();
                
                return result.Skip(1).Aggregate(result.First(), (current, res) => current.Intersect(res).ToList());
            }
            catch (Exception e)
            {
                return new List<int>();
            }
        }
    }

    public class TextParser
    {
        public string[] SplitToWords(string line)
        {
            string[] words = Regex.Split(line, @"\W+");
            return (from word in  words where word != "" select word.ToLower()).ToArray();
        }

        public Dictionary<string, List<int>> BuildInvertIndex(List<List<string>> textWords)
        {
            return
                textWords.SelectMany((lines, ind) => lines.Select(w => new {word = w, index = ind}))
                    .GroupBy(word => word.word)
                    .ToDictionary(group => group.Key,
                        group => group.Select(x => x.index).ToList()
                    );
        }

    }

    public class Printer
    {
        public static string GetResult(List<int> reply, string separator, int maxCount)
        {
            var count = reply.Count() <= maxCount ? reply.Count() : maxCount;

            return String.Join(separator, reply.Take(count));
        }

        public static void PrintResult(List<List<int>> replyesList, string separator, int maxCount)
        {
           foreach (var reply in replyesList)
               Console.WriteLine(GetResult(reply, separator, maxCount));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var parser = new TextParser();
            var textLines = File.ReadAllLines(args[0]);
            var textWords = textLines.Select(parser.SplitToWords).Select(dummy =>  dummy.ToList()).ToList();
            var invertIndex = parser.BuildInvertIndex(textWords);

            var queriesLines = File.ReadAllLines(args[1]);
            var queriesWords = queriesLines.Select(line => parser.SplitToWords(line)).ToList();

            var finder = new Finder();
            var replies = queriesWords.Select(querie => finder.Find(invertIndex, querie)).ToList();

            Printer.PrintResult(replies, ",", 20);
        }
    }
}
