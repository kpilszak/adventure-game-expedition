using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game_expedition
{
    class BluePotion : Weapon, IPotion
    {
        private bool used;
        public bool Used
        {
            get
            {
                return used;
            }
        }

        public BluePotion(Game game, Point location)
            : base(game, location)
        {
            used = false;
        }

        public override string Name
        {
            get
            {
                return "Blue potion";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
            used = true;
        }
    }
}
