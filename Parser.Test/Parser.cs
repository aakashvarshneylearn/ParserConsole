using System.Runtime.InteropServices.ComTypes;
using ImportProduct.Services.Parsers;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using NUnit.Framework;

namespace Parser.Test
{
    public class Parser
    {
        private Mock<IParser> _parser;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ProgramTest()
        {
            var p = new Program();
            Assert.Pass();
        }
    }
}