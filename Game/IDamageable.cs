using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void OnLifeChanged(int p_currentLife);
    
    public interface IDamageable
    {
        int HitPoints { get; }

        event OnLifeChanged OnLifeChanged;

        void GetDamage();
    }

    public interface IDisparable
    {
        float AttackSpeed { get; }
        float Timer { get; }

        bool AttackCooldown { get; }


        void Shoot();
    }

    public interface IMovible
    {
        float _Speed { get; }

        void AddMove(Vector2 pos);
    }
}
