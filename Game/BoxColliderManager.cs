using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class BoxColliderManager
    {
        private static BoxColliderManager instance;

        private List<BoxCollider> boxCollider = new List<BoxCollider>();

        public void AddBoxCollider(BoxCollider p_newCollider)
        {
            boxCollider.Add(p_newCollider);
        }

        public List<BoxCollider> GetCollider()
        {
            List<BoxCollider> coll = new List<BoxCollider>(boxCollider);
            return coll;
        }

        public static BoxColliderManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BoxColliderManager();
                }

                return instance;
            }
        }
    }
}
