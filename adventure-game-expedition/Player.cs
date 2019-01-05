using System.Collections.Generic;

namespace adventure_game_expedition
{
    class Player : Mover
    {
        private Weapon equippedWeapon;
        public int HitPoints { get; private set; }
        private List<Weapon> inventory = new List<Weapon>();
    }
}