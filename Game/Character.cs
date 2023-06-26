using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Character : GameObject, IDisparable, IMovible
    {
        Animation idle;

        private float _speed = 40;

        private float attackSpeed = 1.5f;
        private float timer = 0;

        private bool alive = true;
        private bool attackCooldown = true;

        public float AttackSpeed => attackSpeed;
        public float Timer => timer;

        public bool AttackCooldown => attackCooldown;

        public float _Speed => _speed;

        //CONSTRUCTOR DE PERSONAJES
        public Character(string p_id, Vector2 initialPos, bool rightMovment) : base(p_id)
        {
            float l_rotation = 0;

            if (!rightMovment)
            {
                _speed = -_speed;
                l_rotation = 180;
            }

            //scale = 1;

            idle = CreateAnimation("Idle", "Barco", 3, 1);
            transform = new Transform(initialPos, l_rotation, new Vector2(1, 1));

            currentAnimation = idle;
            currentAnimation.Reset();

            CharactersManager.Instance.AddCharacter(this);
        }

        public override void Update()
        {
            if (!alive)
            {
                return;
            }

            timer += Program.deltaTime;

            if (timer >= attackSpeed)
            {
                attackCooldown = false;
                timer = 0;
            }
            else
            {
                if (!attackCooldown)
                {
                    Shoot();
                    attackCooldown = true;
                }
            }

            AddMove(new Vector2(_speed * Program.deltaTime, 0));

            currentAnimation.Update();
        }

        public override void Draw()
        {
            if (!alive)
            {
                return;
            }

            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
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

        public override void Kill()
        {
            alive = false;
            CharactersManager.Instance.RemoveCharacter(this);
        }

        public void Shoot()
        {
            var bullet = BulletFactory.CreateBullet(BulletSize.normal, "bulletBote", transform, -250);
            //cannonBullets.Add(bullet);
        }

        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }
    }
}
