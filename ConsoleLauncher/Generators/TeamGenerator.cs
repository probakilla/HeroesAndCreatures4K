﻿using HeroesAndCreatures.Characters;
using HeroesAndCreatures.Team;
using HeroesAndCreatures.Weapons;

namespace ConsoleLauncher.Generators {
    public class TeamGenerator {
        private static TeamGenerator Instance = null;
        private readonly CharacterGenerator CharGenerator;
        private readonly WeaponGenerator WeaponGenerator;

        public static TeamGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new TeamGenerator();
                }
                return Instance;
            }
        }

        public TeamGenerator() {
            CharGenerator = CharacterGenerator.GetInstance;
            WeaponGenerator = WeaponGenerator.GetInstance;
        }

        public CharacterTeam GenerateRandomTeam(bool isPlayer) {
            CharacterTeam team = new CharacterTeam();
            for (int i = 0; i < 4; ++i) {
                IWeapon weapon = WeaponGenerator.GetRandomWeapon();
                AbstractCharacter character = CharGenerator.GetRandomCharacter();
                character.EquipWeapon(weapon);
                team.InsertCharacter(character, isPlayer);
            }
            return team;
        }
    }
}
