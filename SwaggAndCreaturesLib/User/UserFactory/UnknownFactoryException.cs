using System;
using System.Runtime.Serialization;

namespace SwaggAndCreaturesLib.User.UserFactory {
    public class UnknownFactoryException : Exception {
        public UnknownFactoryException() : base() { }

        public UnknownFactoryException(string message) : base(message) { }

        public UnknownFactoryException(string message, Exception innerException) : base(message, innerException) { }

        protected UnknownFactoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
