using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerClass;
using NUnit.Framework;
using Moq;
using System.IO;

namespace Testovi
{
    [TestFixture]
    public class LoggerTest
    {
        private Logger logger;

        [SetUp]
        public void SetUp()
        {
            Mock<LoggerClass.Logger> mockLogger = new Mock<LoggerClass.Logger>();
            logger = mockLogger.Object;
        }

        [Test]
        [TestCase(1,3,321)]
        public void PorukaWriteraTest(int id, int code, int value)
        {
            Assert.IsTrue(logger.PorukaWritera(id, code, value));
        }

        [Test]
        [TestCase("1/1/2021 00:00:00","11/13/2021 00:00:00", 1)]
        public void PoslatiPodaciZaReaderaTest(DateTime d1, DateTime d2, int code)
        {
            Assert.IsTrue(logger.PoslatiPodaciZaReader(d1, d2, code));
        }

        private static readonly object[] _CollectionDescription =
        {
            new object[] {
                new CollectionDescription{ID = 0,DataSet = 1,HistoricalCollection = new HistoricalCollection(new List<WorkerProperty>{
                    new WorkerProperty{Code = CodeEnum.CODE_ANALOG,TimeStamp = DateTime.Now,WorkerValue = 200},
                    new WorkerProperty{Code = CodeEnum.CODE_DIGITAL,TimeStamp = DateTime.Now,WorkerValue = 0}})
                }
            }
        };
        [Test]
        [TestCaseSource("_CollectionDescription")]
          public void PrimljeniPodaciZaReaderTest(CollectionDescription cd)
          {
              Assert.IsTrue(logger.PrimljeniPodaciZaReader(cd));
          }

          [Test]
        public void UgasiWorkerZahtjevTest()
        {
            Assert.IsTrue(logger.UgasiWorkerZahtjev());
        }
        [Test]
        public void UpaliWorkerZahtjevTest()
        {
            Assert.IsTrue(logger.UpaliWorkerZahtjev());
        }

        [Test]
        [TestCase(2)]
        public void UpaljenWorkerTest(int i)
        {
            Assert.IsTrue(logger.UpaljenWorker(i));
        }
        [Test]
        [TestCase(2)]
        public void UgasenWorkerTest(int i)
        {
            Assert.IsTrue(logger.UgasenWorker(i));
        }
        [Test]
        [TestCase(1)]
        public void NijeUgasenWorkerTest(int i)
        {
            Assert.IsTrue(logger.NijeUgasenWorker(i));
        }
        [Test]
        [TestCase(4)]
        public void NijeUpaljenWorkerTest(int i)
        {
            Assert.IsTrue(logger.NijeUpaljenWorker(i));
        }

        
        [Test]
        [TestCase(2,(CodeEnum)(3),(CodeEnum)(4),221,220)]
        public void UpisiUBazuTest(int dataset, CodeEnum code, CodeEnum code1, int value, int value1)
        {
            Assert.IsTrue(logger.UpisUBazu(dataset,code,code1,value,value1));
        }

       
        
        [TearDown]
        public void TearDown()
        {
            logger = null;
        }
    }
}
