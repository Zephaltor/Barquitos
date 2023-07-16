using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
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
