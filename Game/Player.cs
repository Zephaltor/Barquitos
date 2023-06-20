using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        private Transform transform;

        static public List<Bullet> cannonBullets = new List<Bullet>();

        Texture cannon = new Texture("Cannon.png");

        private static float bulletSpeed = 400;
        private static float bulletSizeMod = 0.5f;

        public float RealHeight => cannon.Height * transform.scale.y;
        public float RealWidth => cannon.Width * transform.scale.x;

        private float p_speed;
        private float attackSpeed = 0.5f;
        private float timer = 0;

        private bool attackCooldown = false;



        public Player(Vector2 initialPos,  float speed)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            p_speed = speed;
        }

        public void Update()
        {
            timer += Program.deltaTime;

            Input();

            if (transform.position.x >= 825 - cannon.Width)
            {
                transform.position.x = 825 - cannon.Width;
            }
            if (transform.position.x <= -25 + cannon.Width)
            {
                transform.position.x = -25 + cannon.Width;
            }

            for (int i = 0; i < cannonBullets.Count; i++)
            {
                cannonBullets[i].Update();
            }
        }

        public void Draw()
        {
            Engine.Draw(cannon, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2, RealHeight / 2);

            for (int i = 0; i < cannonBullets.Count; i++)
            {
                if (!cannonBullets[i].Draw)
                {
                    cannonBullets.RemoveAt(i);
                }
            }

            for (int i = 0; i < cannonBullets.Count; i++)
            {
                cannonBullets[i].DrawBullet();
            }
            
        }

        public void Move(float velocity)
        {
            transform.position.x += velocity * Program.deltaTime;
        }

        public void Input()
        {
            if (Engine.GetKey(Keys.D))
            {
                Move(p_speed);
            }
            if (Engine.GetKey(Keys.A))
            {
                Move(-p_speed);
            }
            if (Engine.GetKey(Keys.SPACE))
            {

                if (timer >= attackSpeed)
                {
                    attackCooldown = false;
                    timer = 0;
                }
                else
                {
                    if (!attackCooldown)
                    {
                        Shoot(new Vector2(transform.position.x, transform.position.y));
                        attackCooldown = true;
                    }
                }
            }
        }

        
        static void Shoot(Vector2 position)
        {
            cannonBullets.Add(new Bullet(new Vector2(position.x, position.y - 20), bulletSpeed, bulletSizeMod));
        }
        
    }
}
