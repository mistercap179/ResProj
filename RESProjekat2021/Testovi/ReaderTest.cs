using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerClass;
using NUnit.Framework;
using Moq;
using ReaderClass;
using WorkerClass;


namespace Testovi
{
    [TestFixture]
    public class ReaderTest
    {
        private Reader reader;
        

          [SetUp]
          public void SetUp()
          {
              Mock<ReaderClass.Reader> mockReader = new Mock<ReaderClass.Reader>(); 
              reader = mockReader.Object;
          

          }

          [Test]
          public void ReaderKonstruktorTest()
          {
              Assert.AreNotEqual(reader, null);
          }

          [Test]
          [TestCase("1/1/2021 00:00:00", "11/13/2021 00:00:00", 1)]
          public void PoslatiZaReaderTest(DateTime d1, DateTime d2, int code)
          {
              Assert.DoesNotThrow(() => reader.PoslatiZaReader(d1, d2, code));
          }
          [Test]
          [TestCase("1/1/2021 00:00:00", "11/13/2021 00:00:00", 1)]
          public void slanjeW(DateTime d1, DateTime d2, int code)
          {
              Assert.DoesNotThrow(() => reader.slanjeW(d1, d2, code));
          }
    }
}
