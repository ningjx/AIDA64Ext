using System;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Xml;
using AIDA64Ext.Handlers;
using AIDA64Ext.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace AIDA64ExtTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //AIDA64.Start();

            var test = AIDA64.GetInfos();
        }
    }
}
