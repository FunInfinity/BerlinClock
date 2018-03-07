using System;
using System.Text.RegularExpressions;
using BerlinClock.Interfaces;
using BerlinClock.Resources;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string ConvertTime(string time)
        {
            ValidateTimeFormat(time);
            return ConvertTimeToLampFormat(time);
        }

        private static void ValidateTimeFormat(string time)
        {
            if (time == null)
            {
                throw new ArgumentNullException(nameof(time), Messages.TimeIsNotSpecified);
            }

            var regex = new Regex(Consts.TimeRegex);

            if (!regex.IsMatch(time))
            {
                throw new InvalidCastException(string.Format(Messages.TimeHasInvalidFormat));
            }
        }
        
        private static string ConvertTimeToLampFormat(string timeToConvert)
        {
            var time = ParseTime(timeToConvert);
            return string.Format("{0}{1}{2}", ConvertSeconds(time.Seconds), ConvertHours(time.Hours), ConvertMinutes(time.Minutes));
        }
        
        private static Time ParseTime(string time)
        {
            var timeSegments = time.Split(Consts.TimeSegmentsDelimiter);
            return new Time(int.Parse(timeSegments[Consts.HoursSegmentPosition]),
                int.Parse(timeSegments[Consts.MinutesSegmentPosition]),
                int.Parse(timeSegments[Consts.SecondsSegmentPosition]));
        }

        private static string ConvertSeconds(int seconds)
        {
            return string.Format("{0}{1}", seconds % 2 == 0 ? Consts.LampIsYellow : Consts.LampIsOff, Consts.NewLine);
        }

        private static string ConvertHours(int hours)
        {
            return string.Format("{0}{1}{2}{3}{4}{2}", new string(Consts.LampIsRed, hours / Consts.FirstRowHourLampValue), new string(Consts.LampIsOff, Consts.HourLampsInRow - hours / Consts.FirstRowHourLampValue), Consts.NewLine, 
                new string(Consts.LampIsRed, hours % Consts.FirstRowHourLampValue), new string(Consts.LampIsOff, Consts.HourLampsInRow - hours % Consts.FirstRowHourLampValue));
        }

        private static string ConvertMinutes(int minutes)
        {
            return string.Format("{0}{1}{2}{3}{4}", new string(Consts.LampIsYellow, minutes / Consts.FirstRowMinuteLampValue).Replace(Consts.MinutesQuarter,Consts.MinutesFormattedQuarter),
                new string(Consts.LampIsOff, Consts.FirstRowMinuteLamps - minutes / Consts.FirstRowMinuteLampValue), Consts.NewLine, 
                new string(Consts.LampIsYellow, minutes % Consts.FirstRowMinuteLampValue), new string(Consts.LampIsOff, Consts.SecondRowMinuteLamps - minutes % Consts.FirstRowMinuteLampValue));
        }
    }
}