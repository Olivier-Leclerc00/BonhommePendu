using BonhommePendu.Models;

namespace BonhommePendu.Events
{
    // Un événement à créer chaque fois qu'un utilisateur essai une "nouvelle" lettre
    public class GuessEvent : GameEvent
    {
        public override string EventType { get { return "Guess"; } }

        // TODO: Compléter
        public GuessEvent(GameData gameData, char letter) {
            // TODO: Commencez par ICI
            Events = new List<GameEvent>();

            Events.Add(new GuessedLetterEvent(gameData, letter));

            int counter = 0;
            for (int i = 0; i < gameData.RevealedWord.Length; i++)
            {
                if (gameData.HasSameLetterAtIndex(letter, i))
                {
                    Events.Add(new RevealLetterEvent(gameData, letter, i));
                    counter++;
                }
            }
            if (counter == 0)
            {
                Events.Add(new WrongGuessEvent(gameData));
            }
        }
    }
}
