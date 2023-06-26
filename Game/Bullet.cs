using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Bullet : GameObject, IMovible
    {
        //private Player player;

        Texture bullet = new Texture("Bala.png");

        private float _speed;
        private float _rot = 0;
        private float _sizeMod;
        private float lifeTime = 3;
        private float timer = 0;

        private bool alive = true;

        public float _Speed => _speed;

        public Bullet(string p_id, Vector2 position, float speed, float sizeMod) : base(p_id)
        {
            transform = new Transform(position, 0, new Vector2(1, 1));
            _speed = speed;
            _sizeMod = sizeMod;


            List<Texture> list = new List<Texture>();
            list.Add(bullet);

            currentAnimation = new Animation("bullet", list, 0, true);

            CharactersManager.Instance.AddCharacter(this);


            //BulletManager.Instance.AddBullet(this);
        }

        public override void Update()
        {
            if (!alive)
            {
                return;
            }
            AddMove(new Vector2 (0, -_speed * Program.deltaTime));

            timer += Program.deltaTime;

            if (timer >= lifeTime)
            {
                alive = false;
            }
        }

        public override void Draw()
        {
            if (!alive)
            {
                return;
            }

            Engine.Draw(bullet, transform.position.x, transform.position.y, 1 * _sizeMod, 1 * _sizeMod, _rot, RealWidth/2, RealHeight/2);
        }

        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }

        public override void Kill()
        {
            alive = false;
            //BulletManager.Instance.RemoveBullet(this);
            CharactersManager.Instance.RemoveCharacter(this);
        }
    }

    public enum BulletSize
    {
        normal,
        huge,
        tiny
    }
    public static class BulletFactory
    {
        public static Bullet CreateBullet(BulletSize p_size, string p_id, Transform transform, float vel)
        {

            switch (p_size)
            {
                default:
                    return new Bullet(p_id, transform.position, vel, .5f);
                case BulletSize.huge:
                    return new Bullet(p_id, transform.position, vel / 2, 1f);
                case BulletSize.tiny:
                    return new Bullet(p_id, transform.position, vel, .35f);

            }
        }

    }
}
