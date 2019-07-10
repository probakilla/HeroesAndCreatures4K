using SwaggAndCreaturesLib.Characters;
using System.Collections.Generic;
using System.Text;

namespace Unity4KDisplay.TeamDisplays
{
    public static class CharactersStrings
    {
        public static readonly int CHARACTER_SLOT_LENGTH = 9;
        public static readonly string NB_SLOT = "   ({0})   ";
        public static readonly string HEAD = "    O    ";
        public static readonly string BACK = "    @    ";
        public static readonly string ARMS = "   /|\\   ";
        public static readonly string BODY = "    |    ";
        public static readonly string LEGS = "   / \\   ";
        public static readonly string NOTHING = "         ";
        public static readonly string SEPARATOR = "---------";

    }

    public static class StringBuilderTeamExtension
    {
        public static void AddMultiple(this StringBuilder builder, int nbIterations, string pattern)
        {
            for (int i = 0; i < nbIterations; ++i)
            {
                builder.Append(pattern);
            }
            builder.AppendLine();
        }

        public static void AddHP(this StringBuilder builder, List<ICharacter> team)
        {
            foreach (ICharacter character in team)
            {
                builder.Append(HpDisplayString(character));
            }
            builder.AppendLine();
        }

        public static void AddInitiative(this StringBuilder builder, List<ICharacter> team)
        {
            foreach (ICharacter character in team)
            {
                builder.Append(InitiativeDisplayString(character));
            }
            builder.AppendLine();
        }

        public static void AddSlotNumber(this StringBuilder builder, int teamLength)
        {
            for (int i = 0; i < teamLength; ++i)
            {
                builder.AppendFormat(CharactersStrings.NB_SLOT, i + 1);
            }
            builder.AppendLine().AppendLine();
        }

        private static string HpDisplayString(ICharacter character)
        {
            string displayString = "  HP:";
            string hp = character.Health.ToString("F0");
            displayString += hp;
            if (displayString.Length < CharactersStrings.CHARACTER_SLOT_LENGTH)
            {
                displayString = displayString.PadRight(CharactersStrings.CHARACTER_SLOT_LENGTH);
            }
            return displayString;
        }

        private static string InitiativeDisplayString(ICharacter character)
        {
            string displayString = " I:";
            string initiative = character.Initiative.ToString();
            displayString += initiative;
            if (displayString.Length < CharactersStrings.CHARACTER_SLOT_LENGTH)
            {
                displayString = displayString.PadRight(CharactersStrings.CHARACTER_SLOT_LENGTH);
            }
            return displayString;
        }
    }
}
