namespace UnitTests
{
    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceLibrary.Configuration;

    [TestFixture]
    public class ConfigurationAccessorScopeTests
    {
        [Test]
        public void Calls_Parent_For_GetString()
        {
            // arrange
            var mocks = new MockRepository();
            var parent = mocks.StrictMock<IConfigurationAccessor>();

            using (mocks.Record())
            {
                // delayed assert
                parent.Expect(a => a.GetString("ConfigurationAccessorScopeTests.MyName")).Return("Desmond").Repeat.Once();
            }

            var scope = new ConfigurationAccessorScope(typeof(ConfigurationAccessorScopeTests), parent);

            // act
            using (mocks.Playback())
            {
                var configValue = scope.GetString("MyName");

                // assert
                configValue.Should().Be("Desmond");
            }
        }
    }
}
