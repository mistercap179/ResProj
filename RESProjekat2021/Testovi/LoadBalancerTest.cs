using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoadBalancerClass;
using Moq;
using NUnit.Framework;
namespace Testovi
{
    [TestFixture]
    public class LoadBalancerTest
    {
        private LoadBalancerClass.LoadBalancer loadBalancer;

        [SetUp]
        public void SetUp()
        {
            Mock<LoadBalancerClass.LoadBalancer> mockLoadBalancer = new Mock<LoadBalancer>();
            loadBalancer = mockLoadBalancer.Object;
        }

        [Test]
        public void LoadBalancerKonstruktor()
        {
            Assert.AreNotEqual(loadBalancer, null);
        }


        [Test]
        [TestCase(0,CodeEnum.CODE_ANALOG, 123)]
        [TestCase(1,CodeEnum.CODE_DIGITAL, 0)]
        [TestCase(2,CodeEnum.CODE_CUSTOM, 316)]
        [TestCase(3,CodeEnum.CODE_LIMITSET, 655)]
        [TestCase(4,CodeEnum.CODE_SINGLENODE, 128)]
        [TestCase(5,CodeEnum.CODE_MULTIPLENODE, 543)]
        [TestCase(6,CodeEnum.CODE_CONSUMER, 136)]
        [TestCase(7,CodeEnum.CODE_SOURCE, 777)]
        public void PorukaOdWriteraTest(int id, int code, int value)
        {
            Assert.DoesNotThrow(() =>
            {
                loadBalancer.PorukaOdWritera(id,code, value);
            });
        }

        [Test]
        public void UpaliWTest()
        {
            Assert.IsTrue(loadBalancer.UpaliW());
        }

        [Test]
        public void UgasiWTest()
        {
            loadBalancer.UpaliW();
            Assert.IsTrue(loadBalancer.UgasiW());
        }

        [Test]
        public void RoundRobinTest()
        {
            loadBalancer.RoundRobin();

            Assert.AreEqual(loadBalancer.i, 1);
        }

        [TearDown]
        public void TearDown()
        {
            loadBalancer = null;
        }

    }
}
