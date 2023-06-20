using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet
    {
        //private Player player;

        Texture bullet = new Texture("Bala.png");

        private Transform transform;

        public Transform Transf => transform;

        //public CircleCollider collider;

        public float RealHeight => bullet.Height * transform.scale.y;
        public float RealWidth => bullet.Width * transform.scale.x;

        private float _speed = 150;
        //private float _posX = 0;
        //private float _posY = 0;
        private float _rot = 0;
        private float _sizeMod;

        private float lifeTime = 3;
        private float timer = 0;

        private bool alive = true;

        //public float Radius => RealHeight / 2;


        private bool draw = true;

        public bool Draw => draw;

        public Bullet(Vector2 position, float speed, float sizeMod)
        {
            transform = new Transform(position, 0, new Vector2(1, 1));
            _speed = speed;
            _sizeMod = sizeMod;
            BulletManager.Instance.AddBullet(this);
        }

        public void Update()
        {
            if (!alive)
            {
                return;
            }

            transform.position.y -= _speed * Program.deltaTime;

            timer += Program.deltaTime;

            if (timer >= lifeTime)
            {
                alive = false;
            }
        }

        public void DrawBullet()
        {
            if (!alive)
            {
                return;
            }

            //if (draw)
                Engine.Draw(bullet, transform.position.x, transform.position.y, 1 * _sizeMod, 1 * _sizeMod, _rot, RealWidth/2, RealHeight/2);
        }

        public void Kill()
        {
            alive = false;
            BulletManager.Instance.RemoveBullet(this);
        }
    }
}
