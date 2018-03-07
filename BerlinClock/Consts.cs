namespace BerlinClock
{
    public static class Consts
    {
        public const string TimeRegex = "^((([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9])|(24:00:00))$";
        public const char TimeSegmentsDelimiter = ':';
        public const int HoursSegmentPosition = 0;
        public const int MinutesSegmentPosition = 1;
        public const int SecondsSegmentPosition = 2;
        public const char LampIsOff = 'O';
        public const char LampIsYellow = 'Y';
        public const char LampIsRed = 'R';
        public const string NewLine = "\n";
        public const int HourLampsInRow = 4;
        public const int FirstRowMinuteLamps = 11;
        public const int SecondRowMinuteLamps = 4;
        public const int FirstRowHourLampValue = 5;
        public const int FirstRowMinuteLampValue = 5;
        public const string MinutesQuarter = "YYY";
        public const string MinutesFormattedQuarter = "YYR";
    }
}