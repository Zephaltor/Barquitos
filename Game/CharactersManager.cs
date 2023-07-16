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

        private List<GameObject> characters = new List<GameObject>();

        public void AddCharacter(GameObject p_newCharacter)
        {
            if (!characters.Contains(p_newCharacter))
            {
                characters.Add(p_newCharacter);
            }
        }

        public void RemoveCharacter(GameObject p_newCharacter)
        {
            characters.Remove(p_newCharacter);
        }

        public List<GameObject> GetCharacters()
        {
            List<GameObject> chars = new List<GameObject>(characters);
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
