using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game_expedition
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location)
            : base(game, location, 10)
        { }

        public override void Move(Random random)
        {
            if (HitPoints >= 1)
            {
                int randValue = random.Next(3);
                if (randValue == 0 || randValue == 1)
                    location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }

            if (NearPlayer())
                game.HitPlayer(4, random);
        }
    }
}
