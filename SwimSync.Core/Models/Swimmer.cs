using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class Swimmer
    {
        private List<Parent> _parents = [];

        private List<AttendanceRecord> _attendanceRecords = []; 

        private Swimmer(
            Guid id,
            string firstName,
            string lastName,
            DateOnly dob,
            Gender gender,
            string idNumber,
            TrainingGroup? trainingGroup,
            string contactNumber,
            List<Parent> parents,
            List<AttendanceRecord> attendanceRecords
            )
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DOB = dob;
            Gender = gender;
            IdNumber = idNumber;
            TrainingGroup = trainingGroup;
            ContactNumber = contactNumber;
            _parents = parents;
            _attendanceRecords = attendanceRecords;
        }

        public Guid Id { get; set; }

        public string FirstName { get; } = string.Empty;

        public string LastName { get; } = string.Empty;

        public DateOnly DOB { get; }

        public Gender Gender { get; } = Gender.Male;

        public string IdNumber { get; } = string.Empty;

        public DateTime RegisterDate { get; } = DateTime.MinValue;

        public TrainingGroup? TrainingGroup { get; } = null;

        public string ContactNumber { get; } = string.Empty;

        public IReadOnlyList<Parent> Parents => _parents;

        public IReadOnlyList<AttendanceRecord> AttendanceRecords => _attendanceRecords;


        public static Result<Swimmer> Create(
           Guid id,
           string firstName,
           string lastName,
           DateOnly dob,
           Gender gender,
           string idNumber,
           string contactNumber,
           List<Parent> parents,
           TrainingGroup? trainingGroup,
           List<AttendanceRecord> attendanceRecords
           )
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                return Result.Failure<Swimmer>($"{nameof(firstName)} and {nameof(lastName)} cannot be null or empty");
            }

            var swimmmer = new Swimmer(
                id,
                firstName,
                lastName,
                dob,
                gender,
                idNumber,
                trainingGroup,
                contactNumber,
                parents,
                attendanceRecords);

            return Result.Success(swimmmer);
        }
    }
}

