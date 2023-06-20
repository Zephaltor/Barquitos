using System;
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

        public Transform Transf => transform;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public Transform Transform => transform;

        Animation currentAnimation = null;
        Animation idle;

        private bool alive = true;



        //CONSTRUCTOR DE PERSONAJES
        public Character(Vector2 initialPos)
        {
            idle = CreateAnimation("Idle", "Barco", 3, 1);
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            currentAnimation = idle;
            currentAnimation.Reset();

            CharactersManager.Instance.AddCharacter(this);
        }

        public void Update()
        {
            if (!alive)
            {
                return;
            }

            currentAnimation.Update();
        }

        public void Draw()
        {
            if (!alive)
            {
                return;
            }

            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2f, RealHeight / 2f);
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
            alive = false;
            CharactersManager.Instance.RemoveCharacter(this);
        }
    }
}
