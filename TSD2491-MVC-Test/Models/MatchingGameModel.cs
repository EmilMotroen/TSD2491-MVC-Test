namespace TSD2491_MVC_Test.Models
{
    public class MatchingGameModel
    {
        public int MatchesFound = 0;
        public int TimeDisplay = 0;
        public List<string> animalEmoji = new List<string>()
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

        public List<string> ShuffledAnimals = new List<string>();

        public List<string> GetShuffledAnimals()
        {
            return ShuffledAnimals;
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
            Random random = new Random();
            return ShuffledAnimals = animalEmoji.OrderBy(item => random.Next()).ToList();
        }

        public List<string> ButtonClick(string animal, string animalDescription)
        {
            string lastAnimalFound = string.Empty;
            string lastDescription = string.Empty;

            if (lastAnimalFound == string.Empty)
            {
                lastAnimalFound = animal;
                lastDescription = animalDescription;

            }
            else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
            {
                // Match found! Reset for next pair.
                lastAnimalFound = string.Empty;

                // Replace found animals with empty string to hide them.
                ShuffledAnimals = ShuffledAnimals
                    .Select(a => a.Replace(animal, string.Empty))
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
                lastAnimalFound = string.Empty;
            }

            return ShuffledAnimals;
        }
    }
}
