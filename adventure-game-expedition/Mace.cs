using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game_expedition
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location)
            : base(game, location)
        { }

        public override string Name
        {
            get
            {
                return "Mace";
            }
        }

        public override void Attack(Direction direction, Random random)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (!DamageEnemy(direction, 20, 6, random))
                        if (!DamageEnemy(Direction.Right, 20, 6, random))
                            if (!DamageEnemy(Direction.Down, 20, 6, random))
                                if (!DamageEnemy(Direction.Left, 20, 6, random))
                                    break;
                    break;

                case Direction.Down:
                    if (!DamageEnemy(direction, 20, 6, random))
                        if (!DamageEnemy(Direction.Left, 20, 6, random))
                            if (!DamageEnemy(Direction.Up, 20, 6, random))
                                if (!DamageEnemy(Direction.Right, 20, 6, random))
                                    break;
                    break;

                case Direction.Left:
                    if (!DamageEnemy(direction, 20, 6, random))
                        if (!DamageEnemy(Direction.Up, 20, 6, random))
                            if (!DamageEnemy(Direction.Right, 20, 6, random))
                                if (!DamageEnemy(Direction.Down, 20, 6, random))
                                    break;
                    break;

                case Direction.Right:
                    if (!DamageEnemy(direction, 20, 6, random))
                        if (!DamageEnemy(Direction.Down, 20, 6, random))
                            if (!DamageEnemy(Direction.Left, 20, 6, random))
                                if (!DamageEnemy(Direction.Up, 20, 6, random))
                                    break;
                    break;

                default:
                    break;
            }
        }
    }
}
