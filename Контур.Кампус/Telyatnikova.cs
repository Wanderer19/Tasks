using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;


class Program
{
    private static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Incorrect command line parameters.");
        }
        else
        {
            try
            {
                var allLinesFromText = File.ReadAllLines(args[0]);
                var allLinesFromQueries = File.ReadAllLines(args[1]);

                var textParser = new TextParser(allLinesFromText);
                textParser.ParseText();

                var queries = new Queries(allLinesFromQueries, textParser);
                queries.ProcessAllRequests();
                queries.AllReplies.Print();
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}


class TextParser
{
    private readonly string[] _allLinesFromText;
    private readonly Dictionary<string, HashSet<int>> _wordToLinesFromTextMap =
            new Dictionary<string, HashSet<int>>();

    public Dictionary<string, HashSet<int>> WordToLinesFromTextMap
    {
        get { return _wordToLinesFromTextMap; }
    }

    public TextParser()
        : this(null){}

    public TextParser(IEnumerable<string> allLinesFromText)
    {
        _allLinesFromText = allLinesFromText.Select(e => e.ToLower()).ToArray();
    }

    public string [] GetWordsFromLine(int index)
    {
        if (_allLinesFromText.Length <= index) return new string[] { };

        var allWords = _allLinesFromText[index].Split(new[] {'.', ',', ':', '!', '/', '*', '?', '"', ' ', '-'},
            StringSplitOptions.RemoveEmptyEntries);

        return allWords;
    }

    public void ParseText()
    {
        for (var i = 0; i < _allLinesFromText.Length; ++i)
        {
            var words = GetWordsFromLine(i);

            foreach (var word in words.Where(word => !WordToLinesFromTextMap.ContainsKey(word)))
                WordToLinesFromTextMap.Add(word, new HashSet<int>());

            foreach (var word in words)
                WordToLinesFromTextMap[word].Add(i);
        }
    }
}


class Queries
{
    private readonly string[] _allQueries;
    private readonly TextParser _parser;
    private readonly Replies _allReplies = new Replies();

    public Replies AllReplies
    {
        get { return _allReplies; }
    }

    public Queries()
        : this(null){}

    public Queries(IEnumerable<string> allQueries)
        : this(allQueries, new TextParser()){}

    public Queries(IEnumerable<string> allQueries, TextParser parser)
    {
        _allQueries = allQueries.Select(e => e.ToLower()).ToArray();
        _parser = parser;
    }

    public void ProcessRequest(int index)
    {
        var allWordsFromRequest = Regex.Split(_allQueries[index], " ");
        var allLinesNumbers = new Dictionary<int, int>();
        allWordsFromRequest = (allWordsFromRequest.Distinct()).ToArray();
        
        var flag = true;
        foreach (var word in allWordsFromRequest)
        {
            if (_parser.WordToLinesFromTextMap.ContainsKey(word))
            {
                foreach (var number in _parser.WordToLinesFromTextMap[word])
                {
                    if (allLinesNumbers.ContainsKey(number))
                    {
                        allLinesNumbers[number]++;
                    }
                    else
                    {
                        allLinesNumbers.Add(number, 1);
                    }
                }
            }
            else
            {
                AllReplies.AllReplies.Add(new int [] {});

                flag = false;
                break;
            }
        }

        if (flag)
        {
            AllReplies.AllReplies.Add(AllReplies.GetResultLinesNumber(allLinesNumbers, allWordsFromRequest.Length));
        }
    }

    public void ProcessAllRequests()
    {
        for (var i = 0; i < _allQueries.Length; ++i)
            ProcessRequest(i);
    }
}


class Replies
{
    private List<IEnumerable<int>> _allReplies = new List<IEnumerable<int>>();
    private const int MaxCount = 20;
    private const string Separator = ",";

    public List<IEnumerable<int>> AllReplies
    {
        get { return _allReplies; }
        set { _allReplies = value; }
    }

    public IEnumerable<int> GetResultLinesNumber(Dictionary<int, int> allLinesNumbers, int count)
    {
        var resultLinesNumbers = from item in allLinesNumbers where item.Value == count orderby item.Key select item.Key;
        
        return resultLinesNumbers.ToArray();
    }

    public void Print()
    {
        foreach (var i in AllReplies)
        {
            var count = 0;
            var reply = i as int[] ?? i.ToArray();
            
            foreach (var j in reply)
            {
                if (count < MaxCount)
                {
                    Console.Write(j);
                    count++;

                    if (count < MaxCount && count < reply.Count())
                    {
                        Console.Write(Separator);
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine();
        }
    }
}
