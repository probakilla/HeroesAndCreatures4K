namespace HeroesAndCreatures.Characters {
    public struct CharacterStats {
        public float MaxHealth { get; set; }
        public float Health { get; set; }
        public int Agility { get; set; }
        public int Initiative { get; set; }

        public CharacterStats(float health, int agility) {
            MaxHealth = health;
            Health = health;
            Agility = agility;
            Initiative = CharacterConsts.DefaultInitiative;
        }
    }
}
