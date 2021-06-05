using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
namespace Testovi
{
    [TestFixture]
    public class WriterTest
    {
        private WriterClass.Writer writer;
        private LoadBalancerClass.LoadBalancer loadBalancer;

        [SetUp]
        public void SetUp()
        {
            Mock<WriterClass.Writer> mockWriter = new Mock<WriterClass.Writer>();
            writer = mockWriter.Object;
            Mock<LoadBalancerClass.LoadBalancer> mockloadBalancer = new Mock<LoadBalancerClass.LoadBalancer>();
            loadBalancer = mockloadBalancer.Object;
        }


        [Test]
        public void WriterKonstruktor()
        {
            Assert.AreNotEqual(writer,null);
        }

        [Test]
        public void UpaliWorkeraTest()
        {
            Assert.IsTrue(writer.UpaliWorkera());
        }

        [Test]
        public void UgasiWorkeraTest()
        {
            Assert.IsTrue((writer.UgasiWorkera()));
        }


        [Test]
        [TestCase(CodeEnum.CODE_ANALOG, 111)]
        [TestCase(CodeEnum.CODE_DIGITAL, 1)]
        [TestCase(CodeEnum.CODE_CUSTOM, 233)]
        [TestCase(CodeEnum.CODE_LIMITSET, 454)]
        [TestCase(CodeEnum.CODE_SINGLENODE, 745)]
        [TestCase(CodeEnum.CODE_MULTIPLENODE, 546)]
        [TestCase(CodeEnum.CODE_CONSUMER, 145)]
        [TestCase(CodeEnum.CODE_SOURCE, 551)]

        public void SlanjeTest()
        {
            Assert.DoesNotThrow(() => writer.Slanje());
        }









        [TearDown]
        public void TearDown()
        {
            writer = null;
            loadBalancer = null;
        }
    }

}
