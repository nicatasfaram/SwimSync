using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class Parent
    {
        private Parent(Guid id, string firstName, string lastName, Gender gender, string contactNumber, Swimmer swimmer)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            ContactNumber = contactNumber;
            Swimmer = swimmer;
        }

        public Guid Id { get; }

        public string FirstName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public Gender Gender { get; } = Gender.Male;

        public string ContactNumber { get; } = string.Empty;

        public Swimmer Swimmer { get; }

        public static Result<Parent> Create(Guid id, string firstName, string lastName, Gender gender, string contactNumber, Swimmer swimmer)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failure<Parent>($"{nameof(firstName)} and {nameof(lastName)} cannot be null or empty");
            }

            if (string.IsNullOrEmpty(contactNumber))
            {
                return Result.Failure<Parent>($"{nameof(contactNumber)} cannot be null or empty");
            }

            var parent = new Parent(id, firstName, lastName, gender, contactNumber, swimmer);

            return Result.Success<Parent>(parent);
        }
    }
}

