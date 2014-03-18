using JSTC.Config;
using NUnit.Framework;

namespace JSTC.Tests
{
    [TestFixture]
    public sealed class ConfigurationTests
    {
        [Test]
        public void ShouldReadConfigFromFile()
        {
            var config = new JSTCConfiguration();

            Assert.AreEqual(".tmpl.html", config.Extension);
            Assert.AreEqual(".", config.Path);
        }
    }
}
