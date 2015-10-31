using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    class AdvancedEngine : Engine
    {
        public AdvancedEngine(IRenderer renderer, IUserInterface userInterface, int gameSpeed)
            : base(renderer, userInterface, gameSpeed)
        {
        }

        public void ShootPlayerRacket()
        {
            var racked = this.playerRacket as ShootingRacket;

            if (racked != null)
            {
                racked.Shoot();
            }
        }
    }
}
