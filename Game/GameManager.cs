using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameManager
    {
        private int shipCount = 16;

        //private bool counted = false;
        private bool victory = false;

        Vector2 posSpawn1 = new Vector2(-50, 200);
        Vector2 posSpawn2 = new Vector2(850, 300);
        Vector2 posSpawn3 = new Vector2(850, 100);

        //private float startCounter1 = 0;
        //private float startCounter2 = 3;
        //private float startCounter3 = 6;

        //private float counterFinish = 3;
        //private float counter = 0;

        private float spawnTime = 3;
        private float _timer = 2;

        public bool Victory => victory;

        public void Update()
        {
            _timer += Program.deltaTime;

            //if (counter >= counterFinish + 1) counter = 0;
            if (_timer >= spawnTime)
            {
                ShipSpawner(ShipType.normal, posSpawn1, true);
                ShipSpawner(ShipType.small, posSpawn2, false);
                ShipSpawner(ShipType.gunner, posSpawn3, false);

                _timer = 0;
                //counter++;
            }


            //Engine.Debug(counter);
        }

        public void VictoryCheck()
        {
            shipCount -= 1;

            //Engine.Debug(shipCount);
            if (shipCount <= 0)
            {
                victory = true;
                //Engine.Debug("Ganaste");
            }
        }

        public void ShipSpawner(ShipType p_type, Vector2 position, bool rMovement)
        {
            var ship = ShipFactory.CreateShip(p_type, rMovement);
            ship.SetPosition(position);
            ship.OnKilled += VictoryCheck;
        }
    }
}
