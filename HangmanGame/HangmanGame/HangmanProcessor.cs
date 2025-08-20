using Spectre.Console;

namespace HangmanGame
{
    public class HangmanProcessor
    {
        private const char HIDDEN_CHAR = '_';
        private const int MAX_MISTAKES_COUNT = 5;

        private readonly string _word;
        private int _mistakesCount = 0;
        private List<char> _hiddenWord = new List<char>();

        public HangmanProcessor(string word)
        {
            _word = word;

            for (int i = 0; i < word.Length; i++)
            {
                _hiddenWord.Add(HIDDEN_CHAR);
            }
        }

        public void AddLetter(char letter)
        {
            int openEntriesCount = _hiddenWord.Where(x => x == letter).Count();
            int hiddenEntriesCount = _word.Where(x => x == letter).Count();

            if (hiddenEntriesCount >= 0 && openEntriesCount != hiddenEntriesCount)
            {
                AnsiConsole.MarkupLine($"Nice! Letter [green]{letter}[/] opened!");

                for (int i = 0; i < _word.Length; i++)
                {
                    if (letter == _word[i])
                    {
                        _hiddenWord[i] = letter;
                    }
                }
            }
            else
            {
                AnsiConsole.MarkupLine($"Letter [red]{letter}[/] is not correct!");
                _mistakesCount++;
            }
        }

        public bool IsGameEnded()
        {
            if (_mistakesCount == MAX_MISTAKES_COUNT)
            {
                AnsiConsole.MarkupLine($"[bold red]You lost! The word is {_word}.[/]");
                return true;
            }
            if (!_hiddenWord.Contains(HIDDEN_CHAR))
            {
                AnsiConsole.MarkupLine($"[bold green]Congratulations! You won! The word is {_word}.[/]");
                return true;
            }

            return false;
        }

        public void PrintCurrentState()
        {
            DrawHangman();
            Console.Write("\n   ");
            _hiddenWord.ForEach(x => AnsiConsole.Markup(x.ToString()));
            Console.Write("\n\n");
        }

        private void DrawHangman()
        {
            var hangmanFormat = "bold white on black";
            switch (_mistakesCount)
            {
                case 0:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] ________  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |________ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]           [/]");
                    break;
                case 1:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] ________  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      |  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |________ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]           [/]");
                    break;
                case 2:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] ________  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      |  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      О  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |________ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]           [/]");
                    break;
                case 3:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] ________  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      |  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      О  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      |  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |________ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]           [/]");
                    break;
                case 4:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] ________  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      |  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      О  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |     /|\\ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |________ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]           [/]");
                    break;
                case 5:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] ________  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      |  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |      О  [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |     /|\\ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |     / \\ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |         [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}] |________ [/]");
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]           [/]");
                    break;
                default:
                    AnsiConsole.MarkupLine($"[{hangmanFormat}]Invalid mistake count[/]");
                    break;
            }
        }
    }
}
