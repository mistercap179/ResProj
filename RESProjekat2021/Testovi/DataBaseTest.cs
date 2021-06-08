using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Moq;
using NUnit.Framework;

namespace Testovi
{
    [TestFixture]
    public class DataBaseTest
    {
        private DataBase.PristupBazi db;
        private DataBase.DescriptionT tabela;

        [SetUp]
        public void SetUp()
        {
            Mock<DataBase.PristupBazi> mockDb = new Mock<DataBase.PristupBazi>();
            db = mockDb.Object;
            Mock<DataBase.DescriptionT> mockTable = new Mock<DataBase.DescriptionT>();
            tabela = mockTable.Object;
        }

        [Test]
        public void ConvertWorkerPropertyToBaseTest()
        {
            WorkerProperty worker = new WorkerProperty { Code = CodeEnum.CODE_ANALOG , WorkerValue = 579,TimeStamp = DateTime.Now};
            tabela = PristupBazi.ConvertWorkerPropertyToBase(worker);

            bool isEqual = (CodeEnum)tabela.Code == worker.Code;
            isEqual &= tabela.Value == worker.WorkerValue;
            isEqual &= tabela.TimeStamp == worker.TimeStamp;
            isEqual &= tabela.DataSet == (int)(worker.Code + 1)/2;

            Assert.IsTrue(isEqual);

        }

        [Test]
        public void ConvertBPropertyToWorkerTest()
        {
            tabela = new DescriptionT {Code = 1, DataSet = 1, TimeStamp = DateTime.Now, Value = 222};
            WorkerProperty wp = PristupBazi.ConvertBPropertyToWorker(tabela);

            bool isEqual = (CodeEnum)tabela.Code == wp.Code;
            isEqual &= tabela.Value == wp.WorkerValue;
            isEqual &= tabela.TimeStamp == wp.TimeStamp;
            isEqual &= tabela.DataSet == (int)(wp.Code + 1) / 2;

            Assert.IsTrue(isEqual);

        }

        [Test]
        public void DTKonstuktorTest()
        {
            Assert.AreNotEqual(tabela, null);
        }

        [Test]
        public void DTKonstuktorTest1()
        {
            Assert.DoesNotThrow(() =>
            {
                tabela = new DescriptionT { Code = 3,DataSet = 2,TimeStamp = DateTime.Now, Value = 331};
            });
        }

        [TearDown]
        public void TearDown()
        {
            tabela = null;
            db = null;
        }

    }
}
