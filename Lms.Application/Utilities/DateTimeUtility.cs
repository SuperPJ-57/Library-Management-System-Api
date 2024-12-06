namespace Lms.Application.Utilities
{
    public static class DateTimeUtility
    {
        public static int Year { get; set; }
        public static int Month { get; set; }
        public static int Day { get; set; }
        static DateTimeUtility()
        {
            var datetime = DateTime.Now;
            Year = datetime.Year;
            Month = datetime.Month;
            Day = datetime.Day;
        }
        
    }
}
