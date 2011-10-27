namespace UnitTests
{
    using FluentAssertions;

    using NUnit.Framework;

    using Rhino.Mocks;

    using ServiceLibrary.Configuration;

    [TestFixture]
    public class ConfigurationAccessorBaseTests
    {
        [Test]
        public void Scope_Returns_New_ConfigurationAccessScope_Instance()
        {
            // arrange
            var mocks = new MockRepository();
            var parent = mocks.Stub<ConfigurationAccessorBase>();

            // act
            var scope1 = parent.Scope(typeof(System.Collections.ArrayList)) as ConfigurationAccessorScope;
            var scope2 = parent.Scope(typeof(System.Collections.Hashtable)) as ConfigurationAccessorScope;

            // assert
            scope1.Should().NotBeNull();
            scope2.Should().NotBeNull();

            scope1.Should().NotBe(scope2);

            scope1.ScopeName.Should().Be("ArrayList");
            scope2.ScopeName.Should().Be("Hashtable");
        }
    }
}