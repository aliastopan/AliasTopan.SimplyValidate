namespace AliasTopan.SimplyValidate.UnitTests.Models;

    public readonly record struct ValueObjectId
    {
        public static implicit operator Guid(ValueObjectId id) => id.Value;
        public Guid Value { get; init; }

        public ValueObjectId() => Guid.NewGuid();
        public ValueObjectId(Guid id) => Value = id;
    }

