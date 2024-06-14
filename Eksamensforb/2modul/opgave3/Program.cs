using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Opgave 3 - Filter-funktioner til ord

        // CreateWordFilterFn: Funktionen skal returnere en ny funktion.
        var CreateWordFilterFn = (string[] words) => {
            return (string inputText) => {
                var filteredWords = inputText
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Where(word => !words.Contains(word));
                
                return string.Join(" ", filteredWords);
            };
        };

        // Test af CreateWordFilterFn
        var wordsToFilter = new string[] { "lort", "skidt", "møg" };
        var FilterWords = CreateWordFilterFn(wordsToFilter);
        Console.WriteLine(FilterWords("Dette er noget lort og skidt"));
        // Output: "Dette er noget og."

        // CreateWordReplacerFn: Funktionen skal returnere en ny funktion.
        var CreateWordReplacerFn = (string[] words, string replacementWord) => {
            return (string inputText) => {
                var replacedWords = inputText
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => words.Contains(word) ? replacementWord : word);
                
                return string.Join(" ", replacedWords);
            };
        };

        // Test af CreateWordReplacerFn
        var badWords = new string[] { "lort", "fuck", "idiot" };
        var FilterBadWords = CreateWordReplacerFn(badWords, "kage");
        Console.WriteLine(FilterBadWords("Sikke en gang lort"));
        // Output: "Sikke en gang kage."
    }
}
