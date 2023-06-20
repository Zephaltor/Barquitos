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
            var l_bullet = BulletManager.Instance.GetBullet();
            var l_characters = CharactersManager.Instance.GetCharacters();
            foreach (var character in l_characters)
            {
                foreach (var bullet in l_bullet)
                {
                    if (BoxToBoxCollition(character.Transf.position, new Vector2(character.RealWidth, character.RealHeight), bullet.Transf.position, new Vector2(bullet.RealWidth, bullet.RealHeight)))
                    {
                        Engine.Debug("IMPACTO A ESTRIBOR");
                        character.Kill();
                        bullet.Kill();
                    }
                }

                //character.Update();
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
