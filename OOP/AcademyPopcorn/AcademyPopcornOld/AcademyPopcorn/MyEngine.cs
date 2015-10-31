using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class MyEngine : Engine
    {
        public MyEngine(IRenderer renderer, IUserInterface userInterface, int speed = 300)
            : base(renderer, userInterface, speed)
        {
        }

        public void ShootPlayerRacket()
        {
            for (int i = 0; i < this.staticObjects.Count; i++)
            {
                if (this.staticObjects[i] is ShootingRacket)
                {
                    ((ShootingRacket)this.staticObjects[i]).Shoot(this.playerRacket.TopLeft);
                    
                    break;
                }
            }
        }
    }
}
