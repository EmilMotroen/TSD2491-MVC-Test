using System;

namespace TSD2491_MVC_Test.Models
{
    public class MatchingGameModel
    {
        private readonly static Random random = new Random();
        private int matchesFound = 0;

        private bool gameFinished = false;

        private const string gameRunningText = "Find the matching emojies!";
        private const string gameWonText = "Game Complete!";

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

        public List<string> ShuffledEmoji = PickRandomEmoji();

        public string Username { get; set; }
        public int GamesPlayed { get; set; }

        public Dictionary<string, int>? CountGamesPlayed = new Dictionary<string, int>();
        
        public IEnumerable<KeyValuePair<string, int>> SortedDict()
        {
            if (CountGamesPlayed.Count == 0)
            {
                return [];
            }
            return CountGamesPlayed.OrderByDescending(x => x.Value);
        }

        public List<string> GetShuffledAnimals()
        {
            return ShuffledEmoji;
        }

        public int GetShuffledAnimalsCount()
        {
            return ShuffledEmoji.Count;
        }

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
                    if (!string.IsNullOrEmpty(Username))
                    {
                        if (CountGamesPlayed.ContainsKey(Username))
                        {
                            CountGamesPlayed[Username]++;
                        }
                    }
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
