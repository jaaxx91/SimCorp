using SimCorp.WordCounter;

var filePaths = new List<string>
{
    "file1.txt",
    "file2.txt",
    "file3.txt"
};

var wordCounter = new WordCounter();

wordCounter.LoadDataFromFiles(filePaths);

var wordCounts = wordCounter.GetWordCounts();

DisplayWordCounts(wordCounts);

static void DisplayWordCounts(Dictionary<string, int> wordCounts)
{
    foreach (var wordCount in wordCounts)
    {
        Console.WriteLine($"{wordCount.Key}: {wordCount.Value}");
    }
}