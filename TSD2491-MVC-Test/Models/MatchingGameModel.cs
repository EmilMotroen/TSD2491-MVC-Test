using System;

namespace TSD2491_MVC_Test.Models
{
    public class MatchingGameModel
    {
        static Random random = new Random();
        public int MatchesFound = 0;
        public int TimeDisplay = 0;
        public static List<string> animalEmoji = new List<string>()
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

        public static List<string> itemEmoji = new List<string>()
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

        public static List<string> travelEmoji = new List<string>()
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
            return MatchesFound;
        }

        public int GetTimeDisplay()
        {
            return TimeDisplay;
        }

        public List<string> SetupGame()
        {
            MatchesFound = 0;
            return ShuffledEmoji = PickRandomEmoji();
        }

        public List<string> PickRandomEmoji()
        {
            int emoji = random.Next(0, 3);
            switch (emoji)
            {
                case 0: return animalEmoji.OrderBy(item => random.Next()).ToList();
                case 1: return itemEmoji.OrderBy(item => random.Next()).ToList();
                default: return travelEmoji.OrderBy(item => random.Next()).ToList();
            }
        }

        public string lastEmojiFound = string.Empty;
        public string lastDescription = string.Empty;

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

                MatchesFound++;
                if (MatchesFound == 8)
                {
                    //timer.Stop();
                    //timeDisplay += " - Play Again?";

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
