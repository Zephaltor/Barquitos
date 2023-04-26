﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character
    {
        //private float life = 100f;

        private Transform transform;

        public BoxCollider collider;

        //private Collitions collitions;

        //public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        //public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;
        public float RealHeight => ship.Height * transform.scale.y;
        public float RealWidth => ship.Width * transform.scale.x;

        //private Vector2 realSize = new Vector2(ship)


        public Transform Transform => transform;

        Animation currentAnimation = null;
        Animation idle;

        Texture ship = new Texture("Barco.png");


        //CONSTRUCTOR DE PERSONAJES
        public Character(Vector2 initialPos)
        {
            idle = CreateAnimation("Idle", "", 4, 2);
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            currentAnimation = idle;// GetAnimation("Idle");
            currentAnimation.Reset();

            collider = new BoxCollider(transform.position, new Vector2(RealWidth, RealHeight));

            CharactersManager.Instance.AddCharacter(this);
        }

        public void Update()
        {
            //currentAnimation.Update();

            /*
            foreach (var bullet in Player.cannonBullets)
            {
                for (int i = 0; i < Player.cannonBullets.Count; i ++)
                {

                }
            }
            
            foreach (var bullet in Player.cannonBullets)
            {
                for (int i = 0; i < Player.cannonBullets.Count; i++)
                {
                    if (Collitions.CircleToBoxCollition(transform, new Vector2(RealWidth, RealHeight), Player.cannonBullets[i].transform, Player.cannonBullets[i].Radius))
                    {
                        Engine.Debug("ESTOR COLICIONANDO");
                    }
                }
            }
            */
            /*
            var l_bullet = BulletManager.Instance.GetBullet();
            foreach (var bullet in l_bullet)
            {
                for (int i = 0; i < l_bullet.Count; i++)
                {
                    if (collitions.CircleToBoxCollition(transform, new Vector2(RealWidth, RealHeight), l_bullet[i].transform, l_bullet[i].Radius))
                    {
                        Engine.Debug("ESTOR COLICIONANDO");
                    }
                }
            }
            */
            //if (Collitions.CircleToBoxCollition(transform, new Vector2(RealWidth, RealHeight))
        }

        public void Draw()
        {
            //Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);

            Engine.Draw(ship, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
        }
        

        private Animation CreateAnimation(string p_animationID, string p_path,int p_texturesAmount,float p_animationSpeed)
        {
            // Idle Animation
            List<Texture> animationFrames = new List<Texture>();

            for (int i = 1; i < p_texturesAmount; i++)
            {
                animationFrames.Add(Engine.GetTexture($"{p_path}{i}.png"));
            }

            Animation animation = new Animation(p_animationID, animationFrames, p_animationSpeed, true);

            return animation;
        }

        
        public bool IsBoxColliding(Character p_objB)
        {
            float distanceX = Math.Abs(transform.position.x - p_objB.transform.position.x);
            float distanceY = Math.Abs(transform.position.y - p_objB.transform.position.y);

            float sumHalfWidths = RealWidth /2 + p_objB.RealWidth /2;
            float sumHalfHeights = RealHeight /2 + p_objB.RealHeight/2;

            if(distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }


        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }

        /*
        public void DamageLife(int damage)
        {
            life -= damage;
        }
        */

        public void Kill()
        {

        }

        /*
       private List<Animation> GetPlayerAnimations()
       {
           List<Animation> animations = new List<Animation>();

           // Idle Animation
           List<Texture> idleFrames = new List<Texture>();

           for (int i = 0; i < 4; i++)
           {
               idleFrames.Add(Engine.GetTexture($"Textures/Animations/Idle/{i}.png"));
           }

           Animation idleAnimation = new Animation("Idle", idleFrames, 0.2f, true);
           animations.Add(idleAnimation);

           return animations;
       }
       */
    }
}
