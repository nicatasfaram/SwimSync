using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class Coach
    {
        private Coach(Guid id, string firstName, string lastName, DateOnly dob, Gender gender, string contactNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            ContactNumber = contactNumber;
        }

        public Guid Id { get; }

        public string FirstName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public DateOnly DOB { get; }

        public Gender Gender { get; } = Gender.Male;

        public string ContactNumber { get; } = string.Empty;



        public static Result<Coach> Create(Guid id, string firstName, string lastName, DateOnly dob, Gender gender, string contactNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failure<Coach>($"{nameof(firstName)} and {nameof(lastName)} cannot be null or empty");
            }

            if (string.IsNullOrEmpty(contactNumber))
            {
                return Result.Failure<Coach>($"{nameof(contactNumber)} cannot be null or empty");
            }

            var coach = new Coach(id, firstName, lastName, dob, gender, contactNumber);

            return Result.Success<Coach>(coach);
        }
    }
}