using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // A class to represent a word in the scripture text
    class ScriptureWord
    {
        // The word itself, such as "God" or "love"
        public string _word { get; private set; }

        // A boolean flag to indicate if the word is hidden or not
        public bool _isHidden { get; set; }

        // A constructor to create a new word with the given word and hidden status
        public ScriptureWord(string word, bool isHidden)
        {
            _word = word;
            _isHidden = isHidden;
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
    }
}
