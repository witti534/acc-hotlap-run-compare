using acc_hotrun_run_compare;

namespace acc_hotrun_run_compare_test
{
    /// <summary>
    /// The class containing tests for the TimeFormatter class
    /// </summary>
    [TestFixture]
    public class TimeFormatterTests
    {
        
        [TestCase(0, "-:-0:00.000")]
        [TestCase(1, "-:-0:00.001")]
        [TestCase(10, "-:-0:00.010")]
        [TestCase(100, "-:-0:00.100")]
        [TestCase(999, "-:-0:00.999")]
        [TestCase(1000, "-:-0:01.000")]
        [TestCase(59999, "-:-0:59.999")]
        [TestCase(60000, "-:-1:00.000")]
        [TestCase(599999, "-:-9:59.999")]
        [TestCase(600000, "-:10:00.000")]
        [TestCase(3599999, "-:59:59.999")]
        [TestCase(3600000, "1:00:00.000")]
        public void Test_CreateHoursString_CorrectValues(int timeInMs, string expectedResultTimeString)
        {
            //act
            var actualResultTimeString = TimeFormatter.CreateHoursString(timeInMs);

            //assert
            Assert.That(actualResultTimeString, Is.EqualTo(expectedResultTimeString));
        }

        [Test]
        public void Test_CreateHoursString_NegativeValue()
        {
            //arrange
            int timeInMs = -1;

            //Expect to throw exception
            Assert.That(() => TimeFormatter.CreateHoursString(timeInMs), Throws.Exception);
        }

        [TestCase(0, "0:00.000")]
        [TestCase(1, "0:00.001")]
        [TestCase(10, "0:00.010")]
        [TestCase(11, "0:00.011")]
        [TestCase(100, "0:00.100")]
        [TestCase(101, "0:00.101")]
        [TestCase(999, "0:00.999")]
        [TestCase(1000, "0:01.000")]
        [TestCase(1001, "0:01.001")]
        [TestCase(59999, "0:59.999")]
        [TestCase(60000, "1:00.000")]
        [TestCase(60001, "1:00.001")]
        [TestCase(599999, "9:59.999")]
        [TestCase(600000, "10:00.000")]
        [TestCase(6000000, "100:00.000")]
        public void Test_CreateMinutesString_CorrectValues(int timeInMs, string expectedResultTimeString)
        {
            //act
            var actualResultString = TimeFormatter.CreateMinutesString(timeInMs);

            //assert
            Assert.That(actualResultString, Is.EqualTo(expectedResultTimeString));
        }

        [Test]
        public void Test_CreateMinutesString_NegativeValue()
        {
            int timeInMs = -1;

            Assert.That(() => TimeFormatter.CreateMinutesString(timeInMs), Throws.Exception);
        }

        [TestCase(0, "  0.000")]
        [TestCase(1, "  0.001")]
        [TestCase(10, "  0.010")]
        [TestCase(11, "  0.011")]
        [TestCase(100, "  0.100")]
        [TestCase(101, "  0.101")]
        [TestCase(999, "  0.999")]
        [TestCase(1000, "  1.000")]
        [TestCase(1001, "  1.001")]
        [TestCase(59999, " 59.999")]
        [TestCase(60000, " 60.000")]
        [TestCase(99999, " 99.999")]
        [TestCase(100000, "100.000")]
        [TestCase(599999, "599.999")]
        [TestCase(600000, "600.000")]
        [TestCase(999999, "999.999")]
        [TestCase(1000000, "XXX.XXX")]
        [TestCase(Int32.MaxValue, "XXX.XXX")]
        public void Test_CreateThreeFixedDigitsSecondsString_CorrectValues(int timeInMs, string expectedResultTimeString)
        {
            var actualResultString = TimeFormatter.CreateThreeFixedDigitsSecondsString(timeInMs);

            Assert.That(actualResultString, Is.EqualTo(expectedResultTimeString));
        }

    }
}
