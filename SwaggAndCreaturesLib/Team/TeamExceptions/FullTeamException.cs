using System;
using System.Runtime.Serialization;

namespace SwaggAndCreaturesLib.Team.TeamExceptions {
    public class FullTeamException : Exception {
        public FullTeamException() : base(TeamConsts.FullTeamMessage) { }

        public FullTeamException(string message) : base(message) { }

        public FullTeamException(string message, Exception innerException) : base(message, innerException) { }

        protected FullTeamException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
