namespace UnitTests
{
    using System;

    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceLibrary;

    [TestFixture]
    public class TimeServiceTests
    {
        [Test]
        public void TimeService_GetServerTime_Interacts_WithTimeProviderInterface()
        {
            var mocks = new MockRepository();
            var provider = mocks.StrictMock<ITimeProvider>();

            using (mocks.Record())
            {
                Expect.Call(provider.ServerTime).Return(new DateTime(2000, 1, 2)).Repeat.Once();
            }

            var service = new TimeService(provider, new TimeFormatter("yyyy"));

            using (mocks.Playback())
            {
                var result = service.GetServerTime();

                result.Should().Be("2000");
            }
        }

        [Test]
        public void TimeService_GetFormattedServerTime_Interacts_WithTimeProviderInterface()
        {
            // arrange
            var mocks = new MockRepository();
            var provider = mocks.StrictMock<ITimeProvider>();

            using (mocks.Record())
            {
                // delayed assert
                Expect.Call(provider.ServerTime).Return(new DateTime(2000, 1, 2)).Repeat.Once();
            }

            var service = new TimeService(provider, new TimeFormatter("yyyy"));

            // act
            using (mocks.Playback())
            {
                var result = service.GetFormattedServerTime("yyyy-MM-dd");

                // assert
                result.Should().Be("2000-01-02");
            }
        }
    }
}