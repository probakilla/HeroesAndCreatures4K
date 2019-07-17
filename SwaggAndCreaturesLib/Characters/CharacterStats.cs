namespace SwaggAndCreaturesLib.Characters {
    public struct CharacterStats {
        public double MaxHealth { get; set; }
        public double Health { get; set; }
        public int Agility { get; set; }
        public int Initiative { get; set; }

        public CharacterStats(double health, int agility) {
            MaxHealth = health;
            Health = health;
            Agility = agility;
            Initiative = CharacterConsts.DefaultInitiative;
        }
    }
}
