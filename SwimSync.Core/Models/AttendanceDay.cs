using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class AttendanceDay
    {
        private AttendanceDay(DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
        {
            Day = day;
            StartTime = startTime;
            EndTime = endTime;
        }

        public DayOfWeek Day { get; }

        public TimeSpan StartTime { get; } = TimeSpan.Zero;
        
        public TimeSpan EndTime { get; } = TimeSpan.Zero;


        public static Result<AttendanceDay> Create(DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime < endTime)
            {
                return Result.Failure<AttendanceDay>($"{nameof(endTime)} cannot come before {nameof(startTime)}");
            }

            if (startTime == endTime)
            {
                return Result.Failure<AttendanceDay>($"{nameof(startTime)} and {nameof(endTime)} times cannot be equal");
            } 

            var attendanceDay = new AttendanceDay(day, startTime, endTime);

            return Result.Success(attendanceDay);
        }

        public override string ToString()
        {
            return $"{Day}: {StartTime} - {EndTime}";
        }
    }
}
