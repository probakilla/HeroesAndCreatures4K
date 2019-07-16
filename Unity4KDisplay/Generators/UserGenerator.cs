﻿using Display.User;
using SwaggAndCreaturesLib.Team;
using SwaggAndCreaturesLib.User;

namespace Unity4KDisplay.Generators {
    class UserGenerator {
        private static UserGenerator Instance = null;
        private readonly TeamGenerator TeamGenerator;

        public static UserGenerator GetInstance {
            get {
                if (Instance == null) {
                    Instance = new UserGenerator();
                }
                return Instance;
            }
        }

        private UserGenerator() => TeamGenerator = TeamGenerator.GetInstance;

        public IUser GetUser(bool isPlayer) {
            CharacterTeam team = TeamGenerator.GenerateRandomTeam(isPlayer);
            if (isPlayer) {
                return new Player(team);
            }
            return new Computer(team);
        }
    }
}