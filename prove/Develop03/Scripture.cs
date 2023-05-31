using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // A class to represent a scripture, including the reference and the text 
    class Scripture
    {
        // The scripture reference object 
        private ScriptureReference _reference;

        // The list of scripture words objects 
        private List<ScriptureWord> _words;

        // A constructor to create a new scripture with the given reference and text 
        public Scripture(ScriptureReference reference, string text)
        { 
            _reference = reference; 
            _words = GenerateWords(text); // Call the GenerateWords method to create the list of words
        }

        // A method to generate a list of scripture words from a given text 
        private List<ScriptureWord> GenerateWords(string text)
        { 
            List<ScriptureWord> words = new List<ScriptureWord>();

            // Split the text into words by spaces and punctuation marks 
            char[] separators = new char[] { ' ', ',', '.', ';', ':', '?', '!' }; 
            string[] wordsArray = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            // Add each word to the list as a visible word object 
            foreach (string word in wordsArray)
            { 
                words.Add(new ScriptureWord(word)); 
            }

            return words; 
        }

        // A method to return the string representation of the scripture 
        public override string ToString()
        { 
            string result = "";

            // Add the reference to the result 
            result += _reference.ToString() + "\n";

            // Add each word to the result with a space in between 
            foreach (ScriptureWord word in _words)
            { 
                result += word.ToString() + " "; 
            }

            return result; 

        }

        // A method to check if all words in the scripture are hidden 

        public bool AllWordsHidden()
        { 

            foreach (ScriptureWord word in _words)
            { 

                if (!word.IsHidden())
                { 

                    return false; 

                } 

            }

            // If all words are hidden, return true 

            return true; 

        }

        // A method to hide three random words in the scripture that are not already hidden 

        public void HideRandomWords(Random random)
        { 

            // Get a list of indices of words that are not hidden 

            List<int> visibleIndices = new List<int>();

            for (int i = 0; i < _words.Count; i++)
            { 

                if (!_words[i].IsHidden())
                { 

                    visibleIndices.Add(i); 

                } 

            }

            // Shuffle the list using Fisher-Yates algorithm 

            for (int i = visibleIndices.Count - 1; i > 0; i--)
            { 

                int j = random.Next(0, i + 1); 

                // Get a random index from 0 to i

                // Swap the elements at i and j 

                int temp = visibleIndices[i]; 

                visibleIndices[i] = visibleIndices[j]; 

                visibleIndices[j] = temp; 

            }

            // Hide three words from the shuffled list if possible 

            int count = Math.Min(3, visibleIndices.Count);

            for (int i = 0; i < count; i++)
            { 

                _words[visibleIndices[i]].Hide(); 

            } 

        } 

    } 

}
