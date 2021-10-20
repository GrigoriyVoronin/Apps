using System;
using System.Collections.Generic;
using System.Linq;

namespace Anagrams
{
    internal static class AnagramsProgram
    {
        private static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var words = new List<string>();
            for (var i = 0; i < n; i++)
                words.Add(Console.ReadLine());
            var lettersCollections = words
                .Select(w => new LetterCollection(w))
                .ToHashSet();

            Console.WriteLine(lettersCollections.Count);
        }
    }

    internal sealed class LetterCollection : IEquatable<LetterCollection>
    {
        public Dictionary<char, int> CharsCountDictionary { get; } = new Dictionary<char, int>();
        public int Hash { get; }

        public LetterCollection(string word)
        {
            foreach (var ch in word)
            {
                if (CharsCountDictionary.ContainsKey(ch))
                    CharsCountDictionary[ch] += 1;
                else
                    CharsCountDictionary[ch] = 1;
                Hash += CharsCountDictionary[ch].GetHashCode();
            }
        }

        public bool Equals(LetterCollection other)
        {
            foreach (var (ch, count) in other.CharsCountDictionary)
                if (!CharsCountDictionary.ContainsKey(ch) || CharsCountDictionary[ch] != count)
                    return false;

            return true;
        }

        public override int GetHashCode() => Hash;
    }
}
