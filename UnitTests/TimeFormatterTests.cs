namespace UnitTests
{
    using System;

    using FluentAssertions;
    using FluentAssertions.Assertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceLibrary;
    using ServiceLibrary.Configuration;

    [TestFixture]
    public class TimeFormatterTests
    {
        [Test]
        public void DefaultFormat_Constructor_Throws_ArgumentNullException_For_NullString()
        {
            // arrange
            Action act = () => new TimeFormatter((string)null);
            // act & assert
            act.ShouldThrow<ArgumentNullException>().WithMessage("defaultFormat", ComparisonMode.Substring);
        }

        [Test]
        public void DefaultFormat_Constructor_Throws_ArgumentNullException_For_EmptyString()
        {
            // arrange
            Action act = () => new TimeFormatter(string.Empty);
            // act & assert
            act.ShouldThrow<ArgumentNullException>().WithMessage("defaultFormat", ComparisonMode.Substring);
        }

        [Test]
        public void DefaultFormat_Constructor_DoesNot_Throw_ArgumentNullException_For_String()
        {
            // arrange
            Action act = () => new TimeFormatter("yyyy-MM-dd");
            // act & assert
            act.ShouldNotThrow<ArgumentNullException>();
        }

        [Test]
        public void ConfigurationAccessor_Constructor_Throws_ArgumentNullException_ForNullInstance()
        {
            // arrange
            Action act = () => new TimeFormatter((IConfigurationAccessor)null);
            // act & assert
            act.ShouldThrow<ArgumentNullException>().WithMessage("configurationAccessor", ComparisonMode.Substring);
        }

        [Test]
        public void ConfigurationAccessor_Constructor_DoestNot_Throw_ArgumentNullException_ForMockedInstance()
        {
            // arrange
            var mocks = new MockRepository();
            Action act = () => new TimeFormatter(mocks.Stub<IConfigurationAccessor>());
            // act & assert
            act.ShouldNotThrow<ArgumentNullException>();
        }
    }
}