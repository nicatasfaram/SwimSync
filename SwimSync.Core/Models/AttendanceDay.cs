using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class AttendanceDay
    {
        private List<TrainingGroup> _trainingGroups = [];

        private AttendanceDay(DayOfWeek day, TimeSpan startTime, TimeSpan endTime, List<TrainingGroup> trainingGroups)
        {
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
            _trainingGroups = trainingGroups;
        }

        public DayOfWeek Day { get; }

        public TimeSpan StartTime { get; } = TimeSpan.Zero;
        
        public TimeSpan EndTime { get; } = TimeSpan.Zero;

        public IReadOnlyList<TrainingGroup> TrainingGroups => _trainingGroups;


        public static Result<AttendanceDay> Create(
            DayOfWeek day,
            TimeSpan startTime,
            TimeSpan endTime,
            List<TrainingGroup> trainingGroups)
        {
            if (startTime < endTime)
            {
                return Result.Failure<AttendanceDay>($"{nameof(endTime)} cannot come before {nameof(startTime)}");
            }

            if (startTime == endTime)
            {
                return Result.Failure<AttendanceDay>($"{nameof(startTime)} and {nameof(endTime)} times cannot be equal");
            } 

            var attendanceDay = new AttendanceDay(day, startTime, endTime, trainingGroups);

            return Result.Success(attendanceDay);
        }

        public override string ToString()
        {
            return $"{Day}: {StartTime} - {EndTime}";
        }
    }
}
