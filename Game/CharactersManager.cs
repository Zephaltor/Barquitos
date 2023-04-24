using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CharactersManager
    {
        private static CharactersManager instance;

        private List<Character> characters = new List<Character>();

        public void AddCharacter(Character p_newCharacter)
        {
            characters.Add(p_newCharacter);
        }

        public List<Character> GetCharacters()
        {
            List<Character> chars = new List<Character>(characters);
            return chars;
        }

        public static CharactersManager Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new CharactersManager();
                }

                return instance; 
            }
        }


    }
}
