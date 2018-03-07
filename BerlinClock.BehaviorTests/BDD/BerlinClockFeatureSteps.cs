using BerlinClock.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BerlinClock.BehaviorTests.BDD
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private readonly ITimeConverter _berlinClock = new TimeConverter();
        private string _theTime;
        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            _theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string expectedClockOutput)
        {
            Assert.AreEqual(expectedClockOutput, _berlinClock.ConvertTime(_theTime));
        }

    }
}