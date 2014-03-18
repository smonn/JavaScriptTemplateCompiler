using System.Text;
using JSTC.Compilation;
using JSTC.Config;
using JSTC.Extensions;
using NUnit.Framework;

namespace JSTC.Tests
{
    [TestFixture]
    public sealed class CompilerTests
    {
        [Test]
        public void AaaDummyTest()
        {
            
        }

        [Test]
        public void ShouldCompileIntoSingleFile()
        {
            var config = new JSTCConfiguration();
            var compiler = new Compiler(config);

            compiler.Compile();
        }

        [Test]
        public void ShouldEscapeQuotes()
        {
            var input = "<div class=\"widget\"></div>";
            var expected = "<div class=\\\"widget\\\"></div>";
            var sb = new StringBuilder(input);

            sb.EscapeQuotes();
            input = sb.ToString();

            Assert.AreEqual(expected, input);
        }

        [Test]
        public void ShouldClearTagWhiteSpace()
        {
            var input = "<div class=\\\"widget\\\"> <span> </span> </div>";
            var expected = "<div class=\\\"widget\\\"><span></span></div>";
            var sb = new StringBuilder(input);

            sb.CompactWhiteSpaces();
            input = sb.ToString();

            Assert.AreEqual(expected, input);
        }
    }
}
