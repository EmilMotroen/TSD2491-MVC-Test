using System;

namespace TSD2491_MVC_Test.Models
{
    public class MatchingGameModel
    {
        static Random random = new Random();
        private int matchesFound = 0;

        private const string GameRunningText = "Match as fast as you can!";
        private const string GameWonText = "Game Complete";

        private readonly static List<string> animalEmoji = new List<string>()
        {
            "🐺", "🐺",
            "🦖", "🦖",
            "🕷", "🕷",
            "🐒", "🐒",
            "🦊", "🦊",
            "🦌", "🦌",
            "🦈", "🦈",
            "🐢", "🐢"
        };
        private readonly static List<string> itemEmoji = new List<string>()
        {
            "⌚️", "⌚️",
            "📽", "📽",
            "🔮", "🔮",
            "🖋", "🖋",
            "🎈", "🎈",
            "🧻", "🧻",
            "🧬", "🧬",
            "🔬", "🔬"
        };
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

        public List<string> ShuffledEmoji = animalEmoji.OrderBy(item => random.Next()).ToList();

        public List<string> GetShuffledAnimals()
        {
            return ShuffledEmoji;
        }

        public int GetMatchesFound()
        {
            return matchesFound;
        }

        public string GetGameRunningText()
        {
            return GameRunningText;
        }

        public string GetGameFinishedText()
        {
            return GameWonText;
        }

        public List<string> SetupGame()
        {
            matchesFound = 0;
            return ShuffledEmoji = PickRandomEmoji();
        }

        private static List<string> PickRandomEmoji()
        {
            int emoji = random.Next(0, 3);
            switch (emoji)
            {
                case 0:  return animalEmoji.OrderBy(item => random.Next()).ToList();
                case 1:  return itemEmoji.OrderBy(item => random.Next()).ToList();
                default: return travelEmoji.OrderBy(item => random.Next()).ToList();
            }
        }

        private string lastEmojiFound = string.Empty;
        private string lastDescription = string.Empty;

        public void ButtonClick(string emoji, string emojiDescription)
        {
            if (lastEmojiFound == string.Empty)
            {
                lastEmojiFound = emoji;
                lastDescription = emojiDescription;

            }
            else if ((lastEmojiFound == emoji) && (emojiDescription != lastDescription))
            {
                // Match found! Reset for next pair.
                lastEmojiFound = string.Empty;

                // Replace found animals with empty string to hide them.
                ShuffledEmoji = ShuffledEmoji
                    .Select(a => a.Replace(emoji, string.Empty))
                    .ToList();

                matchesFound++;
                if (matchesFound == 8)
                {
                    SetupGame();
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
