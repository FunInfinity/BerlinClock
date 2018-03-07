using System;
using BerlinClock.Interfaces;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BerlinClock.UnitTests
{
    [TestFixture]
    public class TimeConverterTests
    {
        private ITimeConverter _berlinClock;

        [SetUp]
        public void Init()
        {
            _berlinClock = new TimeConverter();
        }

        [TestCase("23:23:22", ExpectedResult= "Y\nRRRR\nRRRO\nYYRYOOOOOOO\nYYYO")]
        [TestCase("00:00:00", ExpectedResult= "Y\nOOOO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("24:00:00", ExpectedResult= "Y\nRRRR\nRRRR\nOOOOOOOOOOO\nOOOO")]
        [TestCase("01:00:00", ExpectedResult= "Y\nOOOO\nROOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("01:01:00", ExpectedResult= "Y\nOOOO\nROOO\nOOOOOOOOOOO\nYOOO")]
        [TestCase("01:01:01", ExpectedResult= "O\nOOOO\nROOO\nOOOOOOOOOOO\nYOOO")]
        public string ConvertTime_ValidTime_Converted(string time)
        {
            return _berlinClock.ConvertTime(time);
        }

        [TestCase("00:00:01", ExpectedResult = "O\nOOOO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("00:00:02", ExpectedResult = "Y\nOOOO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        public string ConvertTime_CheckTopLamp_LampStateSwitched(string time)
        {
            return _berlinClock.ConvertTime(time);
        }

        [TestCase("05:00:01", ExpectedResult = "O\nROOO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("10:00:01", ExpectedResult = "O\nRROO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("15:00:01", ExpectedResult = "O\nRRRO\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("20:00:01", ExpectedResult = "O\nRRRR\nOOOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("01:00:01", ExpectedResult = "O\nOOOO\nROOO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("02:00:01", ExpectedResult = "O\nOOOO\nRROO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("03:00:01", ExpectedResult = "O\nOOOO\nRRRO\nOOOOOOOOOOO\nOOOO")]
        [TestCase("04:00:01", ExpectedResult = "O\nOOOO\nRRRR\nOOOOOOOOOOO\nOOOO")]
        public string ConvertTime_CheckHourLamps_LampStateSwitched(string time)
        {
            return _berlinClock.ConvertTime(time);
        }
        
        [TestCase("00:05:01", ExpectedResult = "O\nOOOO\nOOOO\nYOOOOOOOOOO\nOOOO")]
        [TestCase("00:10:01", ExpectedResult = "O\nOOOO\nOOOO\nYYOOOOOOOOO\nOOOO")]
        [TestCase("00:15:01", ExpectedResult = "O\nOOOO\nOOOO\nYYROOOOOOOO\nOOOO")]
        [TestCase("00:20:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYOOOOOOO\nOOOO")]
        [TestCase("00:25:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYOOOOOO\nOOOO")]
        [TestCase("00:30:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYROOOOO\nOOOO")]
        [TestCase("00:35:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYRYOOOO\nOOOO")]
        [TestCase("00:40:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYRYYOOO\nOOOO")]
        [TestCase("00:45:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYRYYROO\nOOOO")]
        [TestCase("00:50:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYRYYRYO\nOOOO")]
        [TestCase("00:55:01", ExpectedResult = "O\nOOOO\nOOOO\nYYRYYRYYRYY\nOOOO")]
        [TestCase("00:01:01", ExpectedResult = "O\nOOOO\nOOOO\nOOOOOOOOOOO\nYOOO")]
        [TestCase("00:02:01", ExpectedResult = "O\nOOOO\nOOOO\nOOOOOOOOOOO\nYYOO")]
        [TestCase("00:03:01", ExpectedResult = "O\nOOOO\nOOOO\nOOOOOOOOOOO\nYYYO")]
        [TestCase("00:04:01", ExpectedResult = "O\nOOOO\nOOOO\nOOOOOOOOOOO\nYYYY")]
        public string ConvertTime_CheckMinuteLamps_LampStateSwitched(string time)
        {
            return _berlinClock.ConvertTime(time);
        }

        [TestCase("23:59:58", ExpectedResult = "Y\nRRRR\nRRRO\nYYRYYRYYRYY\nYYYY")]
        public string ConvertTime_CheckAllLamps_LampStateSwitched(string time)
        {
            return _berlinClock.ConvertTime(time);
        }

        [Test]
        public void ConvertTime_NullTime_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _berlinClock.ConvertTime(null));
        }
        
        [TestCase("")]
        [TestCase("   ")]
        [TestCase("abasdasdsad")]
        [TestCase("123:123123123:123")]
        [TestCase("13:14:15.333")]
        [TestCase("16:14:154")]
        [TestCase("16:14:15:14")]
        [TestCase("@#:14:15")]
        [TestCase("16:%$:15")]
        [TestCase("16:14:!&")]
        public void ConvertTime_InvalidTimeData_ThrowsInvalidCastException(string time)
        {
            Assert.Throws<InvalidCastException>(() => _berlinClock.ConvertTime(time));
        }

        [TestCase("08.02.01")]
        [TestCase("08/02/01")]
        [TestCase("08 02 01")]
        [TestCase("08|02|01")]
        [TestCase("08-02-01")]
        public void ConvertTime_InvalidTimeDelimiters_ThrowsInvalidCastException(string time)
        {
            Assert.Throws<InvalidCastException>(() => _berlinClock.ConvertTime(time));
        }

        [TestCase("04:00:01 ")]
        [TestCase("04:0 0:01")]
        [TestCase("0 4:00:01")]
        [TestCase("04:00:0 1")]
        public void ConvertTime_ExtraSpaceTimeSegments_ThrowsInvalidCastException(string time)
        {
            Assert.Throws<InvalidCastException>(() => _berlinClock.ConvertTime(time));
        }

        [TestCase("20:64:15")]
        [TestCase("30:14:10")]
        [TestCase("-00:25:10")]
        [TestCase("00:00:60")]
        [TestCase("24:00:01")]
        [TestCase("59:59:23")]
        public void ConvertTime_OutOfRangeTimeSegments_ThrowsInvalidCastException(string time)
        {
            Assert.Throws<InvalidCastException>(() => _berlinClock.ConvertTime(time));
        }
    }
}
