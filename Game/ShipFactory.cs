using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum ShipType
    {
        normal,
        small,
        gunner
    }
    public static class ShipFactory
    {
        public static Character CreateShip(ShipType p_type, bool rMovent)
        {
            string p_id = "bote";
            switch (p_type)
            {
                default:
                    return new Character(p_id, 1, rMovent, 100, 1.5f);
                case ShipType.small:
                    return new Character(p_id, 0.5f, rMovent, 130, 2);
                case ShipType.gunner:
                    return new Character(p_id, 1, rMovent, 85, 0.7f);
            }
        }
    }
}
