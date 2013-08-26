using System;

namespace Labs.Pubquiz.Domain.Common.Commands
{
    [Serializable]
    public class Command<TCommand> : Command
        where TCommand : ICommand
    {
        public bool Equals(TCommand other)
        {
            return CommandId.Equals(other.CommandId);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (other.GetType() != GetType())
                return false;
            return Equals((TCommand) other);
        }

        public override int GetHashCode()
        {
            return CommandId.GetHashCode();
        }
    }

    [Serializable]
    public class Command : ICommand
    {
        public Command()
        {
            CommandId = Guid.NewGuid();
            Stamp = DateTimeOffset.Now;
        }

        public Guid CommandId { get; private set; }

        public DateTimeOffset Stamp { get; private set; }
    }
}