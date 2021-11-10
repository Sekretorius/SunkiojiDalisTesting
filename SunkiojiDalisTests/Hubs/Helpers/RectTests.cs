using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class RectTests
    {
        [Test]
        public void RectTest()
        {
            Vector2D p = new Vector2D(0, 2);
            Vector2D s = new Vector2D(0, 2);
            Rect rect = new Rect(p, s);

            Assert.IsTrue(rect != null);
            Assert.IsTrue(p == rect.Position);
            Assert.IsTrue(s == rect.Size);
        }

        [TestCase(0, 0, 10, 10, 5, 5, ExpectedResult = true)]
        [TestCase(0, 0, 10, 10, 11, 11, ExpectedResult = false)]
        [TestCase(0, 0, 10, 10, 0, 0, ExpectedResult = true)]
        [TestCase(0, 0, 10, 10, 0, 10, ExpectedResult = false)]
        public bool ContainsTest(int px, int py, int sx, int sy, int x, int y)
        {
            Rect rect = new Rect(new Vector2D(px, py), new Vector2D(sx, sy));

            return rect.Contains(new Vector2D(x, y));

        }

        [TestCase(0, 0, 10, 10, 0, 0, 10, 10, ExpectedResult = true)]
        [TestCase(0, 0, 10, 10, 0, 0, 5, 10, ExpectedResult = true)]
        [TestCase(0, 0, 10, 10, 100, 100, 5, 10, ExpectedResult = false)]
        [TestCase(0, 0, 10, 10, 0, 0, 0, 0, ExpectedResult = true)]
        public bool IntersectsTest(int px1, int py1, int sx1, int sy1, int px2, int py2, int sx2, int sy2)
        {
            Rect rect1 = new Rect(new Vector2D(px1, py1), new Vector2D(sx1, sy1));
            Rect rect2 = new Rect(new Vector2D(px2, py2), new Vector2D(sx2, sy2));

            return rect1.Intersects(rect2);
        }
    }
}