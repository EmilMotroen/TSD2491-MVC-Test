using System;

namespace TSD2491_MVC_Test.Models
{
    public class MemoryGameModel
    {
        private static Random random = new Random();

        private int matchesFound = 0;

        private bool gameFinished = false;

        private const string gameRunningText = "Memorize the emojies!";
        private const string gameWonText = "Game Complete!";

        private readonly static List<string> travelEmoji = new List<string>()
        {
            "🚲", "🚲",
            "🎡", "🎡",
            "⛩", "⛩",
            "🌠", "🌠",
            "🎠", "🎠",
            "⛪️", "⛪️",
            "🌌", "🌌",
            "🗾", "🗾"
        };

        public List<string> ShuffledEmoji = travelEmoji.OrderBy(item => random.Next()).ToList();

        public bool GetGameFinished()
        {
            return gameFinished;
        }

        public int GetMatchesFound()
        {
            return matchesFound;
        }

        public string GetGameRunningText()
        {
            return gameRunningText;
        }

        public string GetGameFinishedText()
        {
            return gameWonText;
        }

        public void ButtonClick(string emoji, string uniqueDescription)
        {
            throw new NotImplementedException();
        }
    }
}
