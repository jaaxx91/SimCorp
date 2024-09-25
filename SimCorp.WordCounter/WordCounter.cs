using System.Text.RegularExpressions;

namespace SimCorp.WordCounter
{
    public class WordCounter
    {
        private List<string> _filesContent;

        private const string MatchWordRegex = "(?<![-])\\b[a-zA-Z]+(?:[-'][a-zA-Z]+)*";

        public WordCounter()
        {
            _filesContent = new List<string>();
        }

        public void LoadData(IEnumerable<string> content)
        {
            _filesContent.AddRange(content);
        }

        public void LoadDataFromFiles(IEnumerable<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    continue;
                }

                string fileContent = File.ReadAllText(filePath);

                _filesContent.Add(fileContent);
            }
        }

        public Dictionary<string, int> GetWordCounts()
        {
            var wordCounts = new Dictionary<string, int>();

            foreach (var content in _filesContent)
            {
                var words = Regex.Matches(content, MatchWordRegex);

                foreach (Match word in words)
                {
                    var loweredWord = word.Value.ToLower();

                    if (wordCounts.ContainsKey(loweredWord))
                    {
                        wordCounts[loweredWord]++;
                    }
                    else
                    {
                        wordCounts[loweredWord] = 1;
                    }
                }
            }

            return wordCounts
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
