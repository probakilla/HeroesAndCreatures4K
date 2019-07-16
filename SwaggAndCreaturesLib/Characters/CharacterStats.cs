namespace SwaggAndCreaturesLib.Characters {
    public struct CharacterStats {
        public double Health { get; set; }
        public int Agility { get; set; }
        public int Initiative { get; set; }

        public CharacterStats(double health, int agility) {
            Health = health;
            Agility = agility;
            Initiative = 0;
        }
    }
}
