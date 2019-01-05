namespace adventure_game_expedition
{
    abstract class Weapon : Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location)
            : base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon()
        {
            PickedUp = true;
        }
    }
}