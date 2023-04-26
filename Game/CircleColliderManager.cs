using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class CircleColliderManager
    {
        private static CircleColliderManager instance;

        private List<CircleCollider> circleColliders = new List<CircleCollider>();

        public void AddCircleCollider(CircleCollider p_newCollider)
        {
            circleColliders.Add(p_newCollider);
        }

        public List<CircleCollider> GetCollider()
        {
            List<CircleCollider> coll = new List<CircleCollider>(circleColliders);
            return coll;
        }

        public static CircleColliderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CircleColliderManager();
                }

                return instance;
            }
        }
    }
}

