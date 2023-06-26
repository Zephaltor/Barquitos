using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void OnLifeChanged(int p_currentLife);
    public delegate void OnKilled(IDamageable p_killedObject);
    
    public interface IDamageable
    {
        int HitPoints { get; }

        bool IsAlive { get; set; }

        //event OnLifeChanged OnLifeChanged;
        event OnKilled OnKilled;

        //void GetDamage(int p_damage);
        //void Kill();
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
