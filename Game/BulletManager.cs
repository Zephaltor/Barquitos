using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BulletManager
    {
        private static BulletManager instance;

        private List<Bullet> bullets = new List<Bullet>();

        public void AddBullet(Bullet p_newBullet)
        {
            bullets.Add(p_newBullet);
        }

        public void RemoveBullet(Bullet p_newBullet)
        {
            bullets.Remove(p_newBullet);
        }

        public List<Bullet> GetBullet()
        {
            List<Bullet> bull = new List<Bullet>(bullets);
            return bull;
        }

        public static BulletManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BulletManager();
                }

                return instance;
            }
        }
    }
}
