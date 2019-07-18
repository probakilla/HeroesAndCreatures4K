using System;
using System.Collections.Generic;

namespace HeroesAndCreatures.User.UserFactory {

    public class FactoryDistributor {
        private readonly Dictionary<Type, Func<IUserFactory>> Factories;

        public FactoryDistributor() {
            Factories = new Dictionary<Type, Func<IUserFactory>> {
                { typeof(PlayerFactory), delegate () { return new PlayerFactory(); } },
                { typeof(ComputerFactory), delegate () { return new ComputerFactory(); } }
            };
        }

        public IUserFactory GetFactory(Type factoryType) {
            bool success = Factories.TryGetValue(factoryType, out Func<IUserFactory> function);
            if (!success) {
                throw new UnknownFactoryException();
            }
            return function();
        }
    }
}
