using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GameObject
    {
        private string id;
        protected Transform transform;
        protected Animation currentAnimation;

        public Action OnKilled;

        public GameObject(string p_id)
        {
            id = p_id;
        }

        public Transform Transf => transform;
        public string ID => id;

        public float RealHeight => currentAnimation.CurrentFrame.Height * transform.scale.y;
        public float RealWidth => currentAnimation.CurrentFrame.Width * transform.scale.x;

        public virtual void Draw()
        {
            Engine.Draw(currentAnimation.CurrentFrame, transform.position.x, transform.position.y, transform.scale.x, transform.scale.y, transform.rotation, RealWidth / 2f, RealHeight / 2f);
        }

        public virtual void Update()
        {
        }

        public virtual void Kill()
        {
        }

        public virtual void GetDamage()
        {
        }
    }
}
