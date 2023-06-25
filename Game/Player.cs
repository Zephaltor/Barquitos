﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IDisparable
    {
        float AttackSpeed { get; }
        float Timer { get; }

        bool AttackCooldown { get; }


        void Shoot();
    }

    public interface IMovible
    {
        void AddMove();
    }

    class Player : GameObject, IDisparable
    {
        static public List<Bullet> cannonBullets = new List<Bullet>();

        Texture cannon = new Texture("Cannon.png");

        private static float bulletSpeed = 400;

        private float p_speed;

        private float attackSpeed = 0.5f;
        private float timer = 0;

        private bool attackCooldown = false;

        public float AttackSpeed => attackSpeed;
        public float Timer => timer;

        public bool AttackCooldown => attackCooldown;

        public Player(string p_id, Vector2 initialPos, float speed) : base(p_id)
        {
            transform = new Transform(initialPos, 0, new Vector2(1, 1));

            List<Texture> list = new List<Texture>();
            list.Add(cannon);

            currentAnimation = new Animation("cannon", list, 0, true);

            p_speed = speed;

            CharactersManager.Instance.AddCharacter(this);
        }

        public override void Update()
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

        public override void Draw()
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
                        Shoot();
                        attackCooldown = true;
                    }
                }
            }
        }

        public void Shoot()
        {
            var bullet = BulletFactory.CreateBullet(BulletSize.huge, "bulletCannon", transform, bulletSpeed);
            cannonBullets.Add(bullet);
        }
    }
}
