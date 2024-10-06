using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class TrainingGroup
    {
        private List<Swimmer> _swimmers { get; } = [];

        private List<AttendanceDay> _attendanceDays = [];

        private TrainingGroup(
            Guid id,
            string description,
            Coach coach,
            List<Swimmer> swimmers,
            List<AttendanceDay> attendanceDays)
        {
            Id = id;
            Description = description;
            Coach = coach;
            _swimmers = swimmers;
            _attendanceDays = attendanceDays;
        }

        public Guid Id { get; }

        public string Description { get; } = string.Empty;

        public Coach? Coach { get; } = null;

        public IReadOnlyList<Swimmer> Swimmers => _swimmers;

        public IReadOnlyList<AttendanceDay> AttendanceDays => _attendanceDays;


        public static Result<TrainingGroup> Create(
            Guid id,
            string description,
            Coach coach,
            List<Swimmer> swimmers,
            List<AttendanceDay> attendanceDays)
        {

            if (coach is null)
            {
                return Result.Failure<TrainingGroup>($"{nameof(coach)} cannot be null");
            }

            var trainingGroup = new TrainingGroup(id, description, coach, swimmers, attendanceDays);

            return Result.Success(trainingGroup);
        }
    }
}
