using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class Swimmer
    {
        private List<Parent> _parents = [];

        private Swimmer(
            Guid id,
            string firstName,
            string lastName,
            DateOnly dob,
            Gender gender,
            string idNumber,
            string contactNumber,
            List<Parent> parents,
            TrainingGroup? trainingGroup
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            IdNumber = idNumber;
            ContactNumber = contactNumber;
            _parents = parents;
            TrainingGroup = trainingGroup;
        }

        public Guid Id { get; set; }

        public string FirstName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public DateOnly DOB { get; }

        public Gender Gender { get; } = Gender.Male;

        public string IdNumber { get; } = string.Empty;

        public DateTime RegisterDate { get; } = DateTime.MinValue;

        public IReadOnlyList<Parent> Parents => _parents;

        public string ContactNumber { get; } = string.Empty;

        public TrainingGroup? TrainingGroup { get; } = null;


        public static Result<Swimmer> Create(
           Guid id,
           string firstName,
           string lastName,
           DateOnly dob,
           Gender gender,
           string idNumber,
           string contactNumber,
           List<Parent> parents,
           TrainingGroup? trainingGroup
           )
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failure<Swimmer>($"{nameof(firstName)} and {nameof(lastName)} cannot be null or empty");
            }

            var swimmmer = new Swimmer(id, firstName, lastName, dob, gender, idNumber, contactNumber, parents, trainingGroup);

            return Result.Success(swimmmer);
        }
    }
}

