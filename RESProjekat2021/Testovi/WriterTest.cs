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
        public void WriterKonstruktorTest()
        {
            Assert.AreNotEqual(writer,null);
        }
        

        [Test]
        public void CodeTest()
        {
            Assert.DoesNotThrow(() => writer.RandomCode());
        }

        [Test]
        public void ValueTest()
        {
            Assert.DoesNotThrow(() => writer.RandomValue());
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

        [TearDown]
        public void TearDown()
        {
            writer = null;
            loadBalancer = null;
        }
    }

}
