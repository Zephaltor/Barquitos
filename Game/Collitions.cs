using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Collitions
    {
        //private Transform transform;
        /*
        public void BulletShipCollition(List<)
        {
            //COLICIÓN BALA BARCO
            foreach (var character in characters)
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    if (character != characters[i])
                        if (character.IsBoxColliding(characters[i]))
                        {
                            Engine.Debug("ESTOY COLISIONANDO");
                        }
                }
            }
        }
        */

        //private Character character;
        //private Bullet bullet;

        public void Update()
        {
            var l_boxCollider = BoxColliderManager.Instance.GetCollider();
            var l_circleCollider = CircleColliderManager.Instance.GetCollider();
            foreach (var boxCollider in l_boxCollider)
            {
                foreach (var circleCollider in l_circleCollider)
                {
                    for (int i = 0; i < l_circleCollider.Count; i++)
                    {
                        if (CircleToBoxCollition(boxCollider, l_circleCollider[i]))
                        {
                            Engine.Debug("ESTOY COLICIONANDO");
                        }
                    }
                }
                
            }


            /*
            if (CircleToBoxCollition(character.collider, bullet.collider))
            {
                Engine.Debug("ESTOY COLICIONANDO");
            }
            */
        }


        
        public bool CircleToBoxCollition(BoxCollider box, CircleCollider circle)
        {
            float px = circle._position.x;
            if (circle._position.x < box._position.x) px = box._position.x;
            else if (circle._position.x > box._position.x + box._dimentions.x/2) px = box._position.x + box._dimentions.x/2;

            float py = circle._position.y;
            if (circle._position.y < box._position.y) px = box._position.y;
            else if (circle._position.y > box._position.y + box._dimentions.y/2) px = box._position.y + box._dimentions.y/2;

            float distanceX = circle._position.x - px;
            float distanceY = circle._position.y - py;

            float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            if (distance <= circle._radio)
            {
                return true;
            }
            return false;
        }
        
        /*
        public void BoxToBoxCollition(Transform p_objA, Transform p_objB)
        {
            float distanceX = Math.Abs(p_objA.position.x - p_objB.position.x);
            float distanceY = Math.Abs(p_objA.position.y - p_objB.position.y);

            float sumHalfWidths = p_objA.RealWidth / 2 + p_objB.RealWidth / 2;
            float sumHalfHeights = p_objA.RealHeight / 2 + p_objB.RealHeight / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }
        */
    }
}
