namespace HangmanGame
{
    public class HangmanProcessor
    {
        private readonly int _mistakesCount = 0;
        private readonly string _word = "hangman";

        public HangmanProcessor(string word)
        {
            _word = word;
        }
    }
}
