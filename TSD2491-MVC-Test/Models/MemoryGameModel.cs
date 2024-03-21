using System;
using System.Runtime.CompilerServices;

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
            HiddenEmoji = Enumerable.Repeat("?", ShuffledEmoji.Count).ToList();
        }

        private string lastEmojiFound = string.Empty;
        private int[] numberOfLastEmojies = new int[2];
        private int click = 0;
        string emojiOne = string.Empty;
        string emojiTwo = string.Empty;
        public void ButtonClick(string emoji, string emojiDescription)
        {
            if (click == 0)
            {
                HiddenEmoji[numberOfLastEmojies[1]] = "?";
                HiddenEmoji[numberOfLastEmojies[0]] = "?";
                numberOfLastEmojies[0] = Convert.ToInt32(emojiDescription[8..]);
                HiddenEmoji[numberOfLastEmojies[0]] = ShuffledEmoji[numberOfLastEmojies[0]].ToString();
                emojiOne = ShuffledEmoji[numberOfLastEmojies[0]].ToString();
                click = 1;
            }
             else if (click == 1)
            {
                numberOfLastEmojies[1] = Convert.ToInt32(emojiDescription[8..]);
                HiddenEmoji[numberOfLastEmojies[1]] = ShuffledEmoji[numberOfLastEmojies[1]].ToString();
                emojiTwo = ShuffledEmoji[numberOfLastEmojies[1]].ToString();
                click = 0;
            }
                
            gameFinished = false;
            if (lastEmojiFound == string.Empty)
            {
                lastEmojiFound = emoji;
            }
            else if ((emojiOne == emojiTwo))
            {
                // Match found! Reset for next pair.
                lastEmojiFound = string.Empty;

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
                HiddenEmoji[numberOfLastEmojies[1]] = "?";
                HiddenEmoji[numberOfLastEmojies[0]] = "?";
            }
        }
    }
}
