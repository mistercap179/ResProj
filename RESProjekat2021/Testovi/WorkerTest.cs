﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
namespace Testovi
{
    [TestFixture]
    public class WorkerTest
    {

        private WorkerClass.Worker worker;

        [SetUp]
        public void SetUp()
        {
            Mock<WorkerClass.Worker> mockWorker = new Mock<WorkerClass.Worker>();
            worker = mockWorker.Object;
        }

        [Test]
        public void WorkerKonsturktorTest()
        {
            Assert.AreNotEqual(worker, null);
        }

        [Test]
        public void PorukaOdLoadBalanceraTest1()
        {
            List<Description> descriptions = new List<Description>() {new Description()};
            Assert.DoesNotThrow(() =>
            {
                worker.PorukaOdLoadBalancera(descriptions);
            });
        }

        [Test]
        public void PorukaOdLoadBalanceraTest2()
        {
            List<Description> descriptions = null;
            Assert.DoesNotThrow(() =>
            {
                worker.PorukaOdLoadBalancera(descriptions);
            });
        }

        private static readonly object[] _PorukaLoadBalancer =
        {
            new object[] {
                new List<Description>{new Description{DataSet = 2,Id = 1,ListaItema = new List<Item>
                {
                    new Item{Code = CodeEnum.CODE_CUSTOM,Value = 122},
                    new Item{Code = CodeEnum.CODE_LIMITSET,Value = 521},
                }}}
                    
            }
        };
        [Test]
        [TestCaseSource("_PorukaLoadBalancer")]
        public void PorukaOdLoadBalanceraTest3(List<Description> d)
        {

            Assert.DoesNotThrow(() =>
            {
                worker.PorukaOdLoadBalancera(d);
            });
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
        public void DeadBandTest(CollectionDescription cd)
        {

            Assert.DoesNotThrow(() =>
            {
                worker.DeadBand(cd);
            });
        }

        [Test]
        [TestCase(null)]
        public void DeadBandTestNull(CollectionDescription cd)
        {

            Assert.DoesNotThrow(() =>
            {
                worker.DeadBand(cd);
            });
        }


        private static readonly object[] _deadBandLosTest1 =
        {
            new object[] {
                new CollectionDescription{ID = 0,DataSet = 1,HistoricalCollection = new HistoricalCollection(new List<WorkerProperty>{
                    new WorkerProperty{Code = CodeEnum.CODE_SINGLENODE,TimeStamp = DateTime.Now,WorkerValue = 1000},
                    new WorkerProperty{Code = CodeEnum.CODE_DIGITAL,TimeStamp = DateTime.Now,WorkerValue = 0}})
                }
            }
        };
        [Test]
        [TestCaseSource("_deadBandLosTest1")]
        public void DeadBandLosTest1(CollectionDescription cd)
        {

            Assert.DoesNotThrow(() =>
            {
                worker.DeadBand(cd);
            });
        }



        private static readonly object[] _deadBandLosTest2 =
        {
            new object[] {
                new CollectionDescription{ID = 1,DataSet = 4,HistoricalCollection = new HistoricalCollection(new List<WorkerProperty>{
                    new WorkerProperty{Code = CodeEnum.CODE_LIMITSET,TimeStamp = DateTime.Now,WorkerValue = 122000},
                    new WorkerProperty{Code = CodeEnum.CODE_SOURCE,TimeStamp = DateTime.Now,WorkerValue = 1212121}})
                }
            }
        };
        [Test]
        [TestCaseSource("_deadBandLosTest2")]
        public void DeadBandLosTest2(CollectionDescription cd)
        {

            Assert.DoesNotThrow(() =>
            {
                worker.DeadBand(cd);
            });
        }


        private static readonly object[] _ForDeadBand =
        {
            new object[] {
                new CollectionDescription{ID= 1,DataSet = 3,HistoricalCollection = new HistoricalCollection(new List<WorkerProperty>{
                    new WorkerProperty{Code = CodeEnum.CODE_SINGLENODE,TimeStamp=DateTime.Parse("9.9.1999."),WorkerValue = 188},
                    new WorkerProperty{Code = CodeEnum.CODE_MULTIPLENODE,TimeStamp=DateTime.Parse("10.10.2010."),WorkerValue = 231}})
                }
            }
        };

        [Test]
        [TestCaseSource("_ForDeadBand")]
        public void DeadBandData(CollectionDescription cd)
        {
            CollectionDescription collectionDescription = new CollectionDescription();
            collectionDescription.DataSet = 3;
            collectionDescription.ID = 1;
            collectionDescription.HistoricalCollection = new HistoricalCollection();
            collectionDescription.HistoricalCollection.listaWorkerPropertys = new List<WorkerProperty>();
            collectionDescription.HistoricalCollection.listaWorkerPropertys.Add(new WorkerProperty{Code = CodeEnum.CODE_SINGLENODE, TimeStamp = DateTime.Parse("9.9.1999."), WorkerValue = 188});
            collectionDescription.HistoricalCollection.listaWorkerPropertys.Add(new WorkerProperty { Code = CodeEnum.CODE_MULTIPLENODE, TimeStamp = DateTime.Parse("10.10.2010."), WorkerValue = 231 });
            
            bool equal = true;
            CollectionDescription cdb = worker.DeadBand(cd);
            equal &= collectionDescription.DataSet == cdb.DataSet;
            for (int i = 0; i < 2; i++)
            {
                equal = collectionDescription.HistoricalCollection.listaWorkerPropertys[i].Code == cdb.HistoricalCollection.listaWorkerPropertys[i].Code;
                equal &= collectionDescription.HistoricalCollection.listaWorkerPropertys[i].WorkerValue == cdb.HistoricalCollection.listaWorkerPropertys[i].WorkerValue;
            }
            Assert.IsTrue(equal);

        }

        

        [TearDown]
        public void TearDown()
        {
            worker = null;
        }
    }
}
