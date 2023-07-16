using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameManager
    {
        private int shipCount = 3;

        private bool counted = false;
        private bool victory = false;

        public bool Victory => victory;

        public void Update()
        {
            if (!counted)
            {
                Counter();
                counted = true;
            }
        }

        public void Counter()
        {
            var l_characters = CharactersManager.Instance.GetCharacters();
            foreach (var character in l_characters)
            {
                if (character.ID == "bote")
                {
                    //shipCount++;
                    character.OnKilled += VictoryCheck;
                }
            }
        }
        public void VictoryCheck()
        {
            shipCount -= 1;

            Engine.Debug(shipCount);
            if (shipCount <= 0)
            {
                victory = true;
                //Engine.Debug("Ganaste");
            }
        }
    }
}
