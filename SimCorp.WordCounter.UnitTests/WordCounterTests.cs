namespace SimCorp.WordCounter.UnitTests
{
    public class WordCounterTests
    {
        [Test]
        public void Should_ReturnValidWordCounts()
        {
            // Arrange
            var wordCounter = new WordCounter();

            // Act
            wordCounter.LoadData(GetExampleContents());
            var wordCounts = wordCounter.GetWordCounts();

            // Assert
            Assert.That(wordCounts != null);
            Assert.That(wordCounts != (Dictionary<string, int>)default);
            Assert.That(wordCounts.Count == 15);
            Assert.That(wordCounts.Any(x => x.Key == "word-counter"));
            Assert.That(wordCounts.Any(x => x.Key != "2nd"));
            Assert.That(wordCounts.Any(x => x.Key != "-test-test"));
            Assert.That(wordCounts.First(x => x.Key == "examples").Value == 2);
            Assert.That(wordCounts.First(x => x.Key == "and").Value == 2);
            Assert.That(wordCounts.First(x => x.Key == "some").Value == 2);
            Assert.That(!wordCounts.Any(x => x.Key.Contains("!") ||
                                        x.Key.Contains("2") ||
                                        x.Key.Contains(".") ||
                                        x.Key.Contains(":)")));
        }

        private List<string> GetExampleContents()
            => new List<string>
            {
                "We'll test some cool word-counter examples!" + Environment.NewLine + "Line breaks, and interpunctual examples.",
                "2nd example with some digits and smile :)",
                "123 testing",
                "-test-test"
            };
    }
}