using CSharpFunctionalExtensions;

namespace SwimSync.Core.Models
{
    public class AttendanceRecord
    {
        private AttendanceRecord(DateTime date, TimeSpan startTime, TimeSpan endTime, bool isPresent, Swimmer swimmer) 
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            IsPresent = isPresent;
            Swimmer = swimmer;
        }

        public DateTime Date { get; }

        public TimeSpan StartTime { get;}

        public TimeSpan EndTime { get; }
        
        public bool IsPresent { get; }

        public Swimmer Swimmer { get; }


        public static Result<AttendanceRecord> Create (
            DateTime date,
            TimeSpan startTime,
            TimeSpan endTime,
            bool isPresent,
            Swimmer swimmer)
        {
            if (startTime < endTime)
            {
                return Result.Failure<AttendanceRecord>($"{nameof(endTime)} cannot come before {nameof(startTime)}");
            }

            if (startTime == endTime)
            {
                return Result.Failure<AttendanceRecord>($"{nameof(startTime)} and {nameof(endTime)} times cannot be equal");
            }

            var attedanceRecord = new AttendanceRecord (date, startTime, endTime, isPresent, swimmer );

            return Result.Success(attedanceRecord);
        }
    }
}
