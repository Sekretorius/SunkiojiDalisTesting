using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class Vector2DTests
    {
        [TestMethod()]
        public void ProjectOnTest()
        {
            Vector2D vector = new Vector2D(10,10);
            Vector2D projectionVector = new Vector2D(0,1);
            Vector2D projectedVector = Vector2D.ProjectOn(vector, projectionVector);

            Assert.IsTrue(new Vector2D(0,10) == projectedVector);
        }
    }
}



