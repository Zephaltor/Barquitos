using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class MenuManager
    {
        Texture start = new Texture("Inicio.png");

        public void DrawStart()
        {
            Engine.Draw(start, 0, 0, 1, 1, 0, 0, 0);
        }
    }
}
