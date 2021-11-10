using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Vector2DTests
    {
        [Test]
        public void ProjectOnTest()
        {
            Vector2D vector = new Vector2D(10, 10);
            Vector2D projectionVector = new Vector2D(0, 1);
            Vector2D projectedVector = Vector2D.ProjectOn(vector, projectionVector);

            Assert.IsTrue(new Vector2D(0, 10) == projectedVector);
        }

        [Test]
        public void Vector2DTest()
        {
            Vector2D vector2D = new(0, 0);

            Assert.IsTrue(vector2D != null);
            Assert.IsTrue(vector2D == new Vector2D(0, 0));
        }

        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(4, 3, ExpectedResult = 5)]
        [TestCase(5, 0, ExpectedResult = 5)]
        public float GetMagniduteTest(float x, float y)
        {
            Vector2D vector2D = new(x, y);

            return vector2D.GetMagnidute();
        }

        [TestCase(0, 10, 0, 1)]
        [TestCase(5, 0, 1, 0)]
        public void NormalizeTest(float x, float y, float nx, float ny)
        {
            Vector2D vector2D = new(x, y);
            Vector2D expected = new(nx, ny);

            Assert.IsTrue(expected == vector2D.Normalize());
        }

        [Test]
        public void DirectionToTest()
        {
            Vector2D vector1 = new(1, 1);
            Vector2D vector2 = new(4, 2);
            Vector2D expected = new(3, 1);

            Vector2D direction = vector1.DirectionTo(vector2);

            Assert.IsTrue(direction == expected);
        }

        [Test]
        public void LerpTest()
        {
            Vector2D origin = new(0, 1);
            Vector2D target = new(0, 10);

            Vector2D new1 = Vector2D.Lerp(origin, target, 0);
            Vector2D new2 = Vector2D.Lerp(origin, target, 0.5f);
            Vector2D new3 = Vector2D.Lerp(origin, target, 1);

            Assert.IsTrue(new1 == origin);
            Assert.IsTrue(new2 == new Vector2D(0, 5.5f));
            Assert.IsTrue(new3 == target);
        }

        [Test]
        public void ProjectOnTest1()
        {
            Assert.Fail();
        }

        [TestCase(0, 1, 0, 1, ExpectedResult = 1)]
        [TestCase(0, 1, 1, 1, ExpectedResult = 1)]
        [TestCase(0, 0, 0, 0, ExpectedResult = 0)]
        [TestCase(1, 2, 3, 4, ExpectedResult = 11)]
        public float DotProductTest(float x, float y, float nx, float ny)
        {
            Vector2D vector1 = new(x, y);
            Vector2D vector2 = new(nx, ny);
            return Vector2D.DotProduct(vector1, vector2);
        }

        [TestCase(0, 10, 0, 1, ExpectedResult = true)]
        [TestCase(0, 10, 0, 1, ExpectedResult = false)]
        public bool EqualsTest(float x, float y, float nx, float ny)
        {
            Vector2D vector1 = new(x, y);
            Vector2D vector2 = new(nx, ny);

            return vector1.Equals(vector2);
        }
        public void GetHashCodeTest()
        {
            Vector2D vector2D = new(0, 0);
            Assert.IsTrue(vector2D.GetHashCode() != 0);
        }
    }
}




