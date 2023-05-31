using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // A class to represent a word in the scripture text 
    class ScriptureWord
    {
        // The word itself, such as "God" or "love" 
        private string _word;

        // A boolean flag to indicate if the word is hidden or not 
        private bool _isHidden;

        // A constructor to create a new word with the given word and visible status 
        public ScriptureWord(string word)
        {
            _word = word;
            _isHidden = false; // By default, words are visible
        }

        // A method to return the string representation of the word 
        public override string ToString()
        {
            if (_isHidden) // Return an underscore for hidden words
            {
                return new String('_',_word.Length);
            }
            else // Return the word itself for visible words
            {
                return _word;
            }
        }

        // A method to check if the word is hidden or not 
        public bool IsHidden()
        {
            return _isHidden;
        }

        // A method to hide the word 
        public void Hide()
        {
            _isHidden = true;
        }
    }
}
