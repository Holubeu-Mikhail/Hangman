using Spectre.Console;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace HangmanGame
{
    public class Program
    {
        public const string DICTIONARY_PATH = "../../../resources/words.txt";
        private static readonly Random _random = new Random();

        private static List<string> _words = new List<string>();

        public static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("[bold yellow]Welcome to the Hangman game![/]");
            
            _words = GetWordsFromFile(DICTIONARY_PATH);

            while (true)
            {
                try
                {
                    string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Choose an option[/]:")
                        .AddChoices(new[] {
                            "Start game",
                            "Exit"
                        }));

                    switch (choice)
                    {
                        case "Start game":
                            Play();
                            break;
                        case "Exit":
                            AnsiConsole.MarkupLine("[red]Exiting program...[/]");
                            return;
                        default:
                            AnsiConsole.MarkupLine("[red]Invalid choice, please try again[/]");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.MarkupLine($"[red]Some error occurred:[/] {ex.Message}\nPlease try again.");
                }
            }
        }

        private static void Play()
        {
            var timer = new Stopwatch();
            timer.Start();
            
            var word = _words[_random.Next(0, _words.Count - 1)];

            var hangmanProcessor = new HangmanProcessor(word);

            _words.Remove(word);
            timer.Stop();
            AnsiConsole.MarkupLine($"[yellow]Total time played: {timer.Elapsed.ToString(@"m\:ss\.fff")}.[/]");
        }

        private static List<string> GetWordsFromFile(string dictionaryPath)
        {
            var words = new List<string>(File.ReadAllLines(dictionaryPath));

            words.RemoveAll(x => !Regex.IsMatch(x, @"^[A-Za-z]{7,}$"));

            if (words.Count == 0)
            {
                throw new Exception("There are no valid words in dictionary.");
            }

            return words.Select(x => x.Trim().ToLower()).Distinct().ToList();
        }
    }
}
