﻿using System;
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
        private float lifeTime;
        private float timer = 0;

        private bool alive = true;

        public float _Speed => _speed;

        public event Action<Bullet> OnCollition;

        public Bullet(string p_id, float speed, float sizeMod) : base(p_id)
        {
            transform = new Transform(new Vector2(0, 0), 0, new Vector2(1, 1));
            _speed = speed;
            _sizeMod = sizeMod;

            lifeTime = 3;

            List<Texture> list = new List<Texture>();
            list.Add(bullet);

            currentAnimation = new Animation("bullet", list, 0, true);

            CharactersManager.Instance.AddCharacter(this);
        }

        public override void Update()
        {
            AddMove(new Vector2 (0, -_speed * Program.deltaTime));

            timer += Program.deltaTime;

            if (timer >= lifeTime)
            {
                alive = false;
                Kill();
            }
        }

        public override void Draw()
        {
            //if (!alive)
            //{
            //    return;
            //}

            Engine.Draw(bullet, transform.position.x, transform.position.y, 1 * _sizeMod, 1 * _sizeMod, _rot, RealWidth/2, RealHeight/2);
        }

        public void AddMove(Vector2 pos)
        {
            transform.position.x += pos.x;
            transform.position.y += pos.y;
        }

        public override void Kill()
        {
            //alive = false;
            lifeTime = 3;
            timer = 0;
            //BulletManager.Instance.RemoveBullet(this);
            CharactersManager.Instance.RemoveCharacter(this);
            OnCollition?.Invoke(this);
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
        public static Bullet createPlayerBullet() => CreateBullet();
        public static Bullet CreateBullet(BulletSize p_size = BulletSize.tiny, string p_id = "bulletCannon")
        {

            switch (p_size)
            {
                default:
                    return new Bullet(p_id, -400, .5f);
                case BulletSize.huge:
                    return new Bullet(p_id, -400 / 2, 1f);
                case BulletSize.tiny:
                    return new Bullet(p_id, 400 * 1.5f, .35f);

            }
        }

    }
}
