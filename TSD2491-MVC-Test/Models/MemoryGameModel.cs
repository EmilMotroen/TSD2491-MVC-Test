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

        private static List<string> ShuffledEmoji = travelEmoji.OrderBy(item => random.Next()).ToList();
        public List<string> HiddenEmoji = Enumerable.Repeat("?", ShuffledEmoji.Count).ToList();

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

        public void SetupGame()
        {
            matchesFound = 0;
            ShuffledEmoji = travelEmoji.OrderBy(item => random.Next()).ToList();
        }

        private string lastEmojiFound = string.Empty;
        private string lastDescription = string.Empty;
        public void ButtonClick(string emoji, string emojiDescription)
        {
            gameFinished = false;
            if (lastEmojiFound == string.Empty)
            {
                lastEmojiFound = emoji;
                lastDescription = emojiDescription;

            }
            else if ((lastEmojiFound == emoji) && (emojiDescription != lastDescription))
            {
                // Match found! Reset for next pair.
                lastEmojiFound = string.Empty;

                // Replace found emoji with empty string to hide them.
                ShuffledEmoji = ShuffledEmoji
                    .Select(a => a.Replace(emoji, string.Empty))
                    .ToList();

                matchesFound++;
                if (matchesFound == 8)
                {
                    SetupGame();
                    gameFinished = true;
                }
            }
            else
            {
                // User selected a pair that don't match.
                // Reset selection.
                lastEmojiFound = string.Empty;
            }
        }
    }
}
