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

        public Transform transform;

        public CircleCollider collider;

        public float RealHeight => bullet.Height * transform.scale.y;
        public float RealWidth => bullet.Width * transform.scale.x;

        private float _speed = 150;
        //private float _posX = 0;
        //private float _posY = 0;
        private float _rot = 0;
        private float _sizeMod;

        private float lifeTime = 3;
        private float timer = 0;

        public float Radius => RealHeight / 2;

        private bool draw = true;

        public bool Draw => draw;

        public Bullet(Vector2 position, float speed, float sizeMod)
        {
            transform = new Transform(position, 0, new Vector2(1, 1));
            _speed = speed;
            _sizeMod = sizeMod;
            //_rot = rot;

            collider = new CircleCollider(transform.position, Radius);
        }

        public void Update()
        {
            transform.position.y -= _speed * Program.deltaTime;

            timer += Program.deltaTime;

            if (timer >= lifeTime)
            {
                draw = false;
            }

            //BulletManager.Instance.AddBullet(this);
        }

        public void DrawBullet()
        {
            if (draw)
                Engine.Draw(bullet, transform.position.x, transform.position.y, 1 * _sizeMod, 1 * _sizeMod, _rot, RealWidth/2, RealHeight/2);
        }


    }
}
