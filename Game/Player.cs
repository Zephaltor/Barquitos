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

        //private Program program;

        private Bullet bullets;

        Texture cannon = new Texture("Cannon.png");

        public float RealHeight => cannon.Height * transform.scale.y;
        public float RealWidth => cannon.Width * transform.scale.x;

        private float p_speed;





        public Player(Vector2 initialPos,  float speed)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            p_speed = speed;
        }

        public void Update()
        {
            Input();

            if (transform.position.x >= 825 - cannon.Width)
            {
                transform.position.x = 825 - cannon.Width;
            }
            if (transform.position.x <= -25 + cannon.Width)
            {
                transform.position.x = -25 + cannon.Width;
            }
        }

        public void Draw()
        {
            Engine.Draw(cannon, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, 0, RealWidth / 2, RealHeight / 2);
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
        }

        /*
        static void Shoot()
        {
            bullets.Add(new Bullet(_posX + 230, _posY + 60, _rot));
        }
        */
    }
}
