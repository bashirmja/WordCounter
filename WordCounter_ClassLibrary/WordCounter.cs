using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter_ClassLibrary
{
    public class WordCounter
    {
        private Dictionary<string, int> _dictionary = new Dictionary<string, int>();

        public Dictionary<string, int> CountInputText(string text)
        {
            Calculator(text);
            return _dictionary;
        }

        public Dictionary<string, int> CountInputFile(string path)
        {
            Calculator(System.IO.File.ReadAllText(path));
            return _dictionary;
        }


        private void Calculator(string text)
        {

            string word = "";
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    word += c;
                }
                else if (word != "")
                {
                    AddToDictunary(word);
                    word = "";
                }
            }

            if (word.Length > 0)
            {
                AddToDictunary(word);
            }

        }

        private void AddToDictunary(string rawWord)
        {
            string word = rawWord.ToLower();

            if (_dictionary.ContainsKey(word))
            {
                _dictionary[word] = _dictionary[word] + 1;
            }
            else
            {
                _dictionary.Add(word, 1);
            }
        }

    }
}
