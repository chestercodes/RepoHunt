using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    // http://stevehanov.ca/blog/index.php?id=114

    public class TrieNode
    {
        public string word;

        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();

        public void Insert(string word)
        {
            var node = this;

            foreach (char c in word)
            {
                if (node.children.ContainsKey(c) == false)
                {
                    node.children[c] = new TrieNode();
                }

                node = node.children[c];
            }

            node.word = word;
        }
    }

    public class Search
    {
        public static Dictionary<string, int> Run(TrieNode trie, string word, int maxDistance)
        {
            var results = new Dictionary<string, int>();

            var currentRow = Enumerable.Range(0, word.Length + 1).ToList();

            foreach (var letter in trie.children.Keys)
            {
                searchRecursive(trie.children[letter], letter, word, currentRow, results, maxDistance);
            }

            return results;
        }

        public static void searchRecursive(TrieNode node, char letter, string word, List<int> previousRow, Dictionary<string, int> results, int maxDistance)
        {
            var columns = word.Length + 1;
            var currentRow = new List<int>(){
                previousRow[0] + 1
            };

            foreach (var column in Enumerable.Range(1, columns - 1))
            {
                var insertCost = currentRow[column - 1] + 1;
                var deleteCost = previousRow[column] + 1;
                var replaceCost = word[column - 1] != letter
                    ? previousRow[column - 1] + 1
                    : previousRow[column - 1];

                currentRow.Add(Math.Min(Math.Min(insertCost, deleteCost), replaceCost));
            }
            var dist = currentRow.Last();
            // if the last entry in the row indicates the optimal cost is less than the
            // maximum cost, and there is a word in this trie node, then add it.
            if (dist <= maxDistance && node.word != null)
            {
                results[node.word] = dist;
            }

            // if any entries in the row are less than the maximum cost, then 
            // recursively search each branch of the trie
            if (currentRow.Min() <= maxDistance)
            {
                foreach (var l in node.children.Keys)
                {
                    searchRecursive(node.children[l], l, word, currentRow, results, maxDistance);
                }
            }
        }
    }
}
