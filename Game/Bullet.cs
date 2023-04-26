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

        private float _speed = 150;
        private float _posX = 0;
        private float _posY = 0;
        private float _rot = 0;

        private float lifeTime = 3;
        private float timer = 0;

        private bool draw = true;

        public bool Draw => draw;

        public Bullet(Vector2 position, float speed)
        {
            _posX = position.x;
            _posY = position.y;
            _speed = speed;
            //_rot = rot;
        }

        public void Update()
        {
            _posY -= _speed * Program.deltaTime;

            timer += Program.deltaTime;

            if (timer >= lifeTime)
            {
                draw = false;
            }
        }

        public void DrawBullet()
        {
            if (draw)
                Engine.Draw("ship.png", _posX, _posY, .25f, .25f, _rot, 145.5f, 86.5f);
        }


    }
}
