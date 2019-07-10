using SwaggAndCreaturesLib.Characters;
using System.Collections.Generic;
using System.Text;
using Unity4KDisplay.TeamDisplays;

namespace Unity4KDisplay
{
    public struct TeamDisplay
    {
        public static string DisplayTeam(List<ICharacter> team, bool isPlayer)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AddSlotNumber(4);
            if (isPlayer)
            {
                builder.AddMultiple(4, CharactersStrings.BACK);
            }
            else
            {
                builder.AddMultiple(4, CharactersStrings.HEAD);
            }
            builder.AddMultiple(4, CharactersStrings.ARMS);
            builder.AddMultiple(4, CharactersStrings.BODY);
            builder.AddMultiple(4, CharactersStrings.LEGS);
            builder.AddHP(team);
            return builder.ToString();
        }

        public static string TeamSeparator(int teamLength)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < teamLength; ++i)
            {
                builder.Append(CharactersStrings.SEPARATOR);
            }
            builder.AppendLine();
            return builder.ToString();
        }
    }
}
