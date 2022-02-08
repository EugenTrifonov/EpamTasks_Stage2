using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Base;
using Task5.YopMail;

namespace Tests
{
    public class YopMailTests
    {
        [Test]
        [Category("All")]
        public void OpenMail()
        {
           var page= YopMailUtilities.OpenYopMail();

            Assert.IsTrue(page is CreateAccPage);
        }

        [Test]
        [Category("All")]
        [Category("Smoke tests")]
        public void CreateRandomAccTest() 
        {
            var page = YopMailUtilities.OpenYopMail().CreateRandomAcc();

            Assert.IsTrue(page is InboxPage);
        }

        [TearDown]
        public void TearDown() 
        {
            Driver.CloseBrowser();
        }
    }
}
