using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float p_x, float p_y)
        {
            x = p_x;
            y = p_y;
        }
    }
    public struct Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;

        public Transform(Vector2 p_initialPosition,float p_initialRotation,Vector2 p_scale)
        {
            position = p_initialPosition;
            rotation = p_initialRotation;
            scale = p_scale;

        }
    }
}
