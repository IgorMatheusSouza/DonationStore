namespace DonationStore.Domain.Enities
{
    using System;
    using System.Collections.Generic;

    public abstract class Entity<TIdentifier> : IEquatable<Entity<TIdentifier>> where TIdentifier : struct
    {
        protected Entity() { }

        protected Entity(TIdentifier id)
        {
            this.Id = id;
        }

        public TIdentifier Id { get; private set; }

        public override bool Equals(object obj) => this.Equals(obj as Entity<TIdentifier>);

        public bool Equals(Entity<TIdentifier> other) => other is null ? false : this.Id.Equals(other.Id);

        public override int GetHashCode()
        {
            return EqualityComparer<TIdentifier>.Default.GetHashCode(Id);
        }
    }
}