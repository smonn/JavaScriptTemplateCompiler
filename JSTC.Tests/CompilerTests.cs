using JSTC.Compilation;
using JSTC.Config;
using NUnit.Framework;

namespace JSTC.Tests
{
    [TestFixture]
    public sealed class CompilerTests
    {
        [Test]
        public void ShouldCompileIntoSingleFile()
        {
            var config = new JSTCConfiguration();
            var compiler = new Compiler(config);

            compiler.Compile();
        }
    }
}
