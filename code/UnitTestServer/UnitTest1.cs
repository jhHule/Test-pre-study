using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using storage;
using ThriftServer;

namespace UnitTestServer
{
    [TestClass]
    public class UnitTest1
    {
        private StorageServiceHandler _handler;
        /*
        private TestContext _testContext;
        
        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }*/

        [TestInitialize()]
        public void InitializeSomething()
        {
            _handler = new StorageServiceHandler();
            _handler.ClearStorage();
        }

        [TestCleanup()]
        public void CleanupSomething()
        {
        }

        [TestMethod]
        public void GetStoragepoints()
        {
            var list = _handler.StoragePoints();
            Assert.IsTrue(list.Count == 0, "Storage list count test failed");
        }
        
        [TestMethod]
        public void AddStoragepointItem()
        {
            var storagePoint = new StoragePoint {StorageId = 0, Name = "Storage 1", Description = "Description 1"};
            Assert.IsTrue(_handler.AddStoragePoint(storagePoint), "Storage point add failed");
            Assert.IsFalse(_handler.AddStoragePoint(storagePoint), "Storage point add duplicate item failed");

            var list = _handler.StoragePoints();
            Assert.AreEqual(list[0].StorageId, storagePoint.StorageId, 0, "Added item does not match");
        }

        [TestMethod]
        public void ReadStoragepointItem()
        {
            string value = "TestValue";
            var storagePoint = InitializeReadWriteStoragePoint();

            string readValue = _handler.read(storagePoint.StorageId);
            Assert.AreEqual(value, readValue);
        }

        [TestMethod]
        public void WriteStoragepointItem()
        {
            string value;
            var storagePoint = InitializeReadWriteStoragePoint();

            string writeValue = "writeValue";
            Assert.IsTrue(_handler.write(storagePoint.StorageId, writeValue), "Write failed");
            value = _handler.read(storagePoint.StorageId);
            Assert.AreEqual(value, writeValue);


            writeValue = "";
            Assert.IsFalse(_handler.write(storagePoint.StorageId, writeValue), "Write empty value failed");
            value = _handler.read(storagePoint.StorageId);
            Assert.AreEqual(value, writeValue);

            writeValue = null;
            Assert.IsFalse(_handler.write(storagePoint.StorageId, writeValue), "Write empty value failed");
            value = _handler.read(storagePoint.StorageId);
            Assert.AreEqual(value, writeValue);
        }

        private StoragePoint InitializeReadWriteStoragePoint()
        {
            string value = "TestValue";
            var storagePoint = new StoragePoint
            {
                StorageId = 1,
                Name = "Storage 1",
                Description = "Description 1",
                Value = value
            };
            Assert.IsTrue(_handler.AddStoragePoint(storagePoint), "Storage point add failed");
            return storagePoint;
        }
    }
}
