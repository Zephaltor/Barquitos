using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Collitions
    {
        public void Update()
        {
            //COLICIONES BALA - BARCOS
            var l_characters = CharactersManager.Instance.GetCharacters();
            foreach (var character in l_characters)
            {
                foreach (var char2 in l_characters)
                {

                    if (character.ID == "bote" && char2.ID == "bulletCannon")
                    {
                        if (BoxToBoxCollition(character.Transf.position, new Vector2(character.RealWidth, character.RealHeight), char2.Transf.position, new Vector2(char2.RealWidth, char2.RealHeight)))
                        {
                            character.Kill();
                            char2.Kill();
                        }
                    }
                    if (character.ID == "cannon" && char2.ID == "bulletBote")
                    {
                        if (BoxToBoxCollition(character.Transf.position, new Vector2(character.RealWidth, character.RealHeight), char2.Transf.position, new Vector2(char2.RealWidth, char2.RealHeight)))
                        {
                            char2.Kill();

                            //Engine.Debug("Ouch");
                            character.GetDamage();
                        }
                    }
                }
            }
        }



        private static bool BoxToBoxCollition(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
        {
            float distanceX = Math.Abs(positionA.x - positionB.x);
            float distanceY = Math.Abs(positionA.y - positionB.y);

            float sumHalfWidths = sizeA.x / 2 + sizeB.x / 2;
            float sumHalfHeights = sizeA.y / 2 + sizeB.y / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }
    }
}
