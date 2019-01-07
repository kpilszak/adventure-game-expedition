using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game_expedition
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location)
            : base(game, location, 6)
        { }

        public override void Move(Random random)
        {
            if (HitPoints >= 1)
            {
                if (random.Next(2) == 0)
                    location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                else
                    location = Move((Direction)random.Next(4), game.Boundaries);
            }

            if (NearPlayer())
                game.HitPlayer(2, random);
        }
    }
}
