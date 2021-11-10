using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class QuadTreeTests
    {
        [Test]
        public void QuadTreeTest()
        {
            Rect boundry = new Rect(new Vector2D(0, 0), new Vector2D(50, 50));
            QuadTree quadTree = new QuadTree(boundry, 4);

            Assert.IsTrue(quadTree != null);
            Assert.AreEqual(boundry, quadTree.Boundry);
        }

        [TestCase(0, 0, 5, 5, 4)]
        [TestCase(0, 0, 5, 5, 4)]
        public void InsertTest_collider(int px, int py, int sx, int sy, int exR)
        {
            QuadTree quadTree = new QuadTree(new Rect(new Vector2D(0, 0), new Vector2D(50, 50)), 4);
            Rect boundry = new Rect(new Vector2D(px, py), new Vector2D(sx, sy));
            Collider newCollider = new Collider(boundry);

            quadTree.Insert(newCollider);

            Assert.IsTrue(exR == quadTree.points.Count);
        }

        [Test]
        public void InsertColliderFillTest()
        {
            Rect quadTreeBoundry = new Rect(new Vector2D(0, 0), new Vector2D(50, 50));
            QuadTree quadTree = new QuadTree(quadTreeBoundry, 4);
            
            Rect boundry1 = new Rect(new Vector2D(0, 0), new Vector2D(0.5f, 0.5f));
            Rect boundry2 = new Rect(new Vector2D(10, 15), new Vector2D(0.5f, 0.5f));
            Rect boundry3 = new Rect(new Vector2D(-10, 15), new Vector2D(0.5f, 0.5f));
            Rect boundry4 = new Rect(new Vector2D(10, -15), new Vector2D(0.5f, 0.5f));
            Rect boundry5 = new Rect(new Vector2D(-10, -15), new Vector2D(0.5f, 0.5f));

            quadTree.Insert(new Collider(boundry1));
            quadTree.Insert(new Collider(boundry2));
            quadTree.Insert(new Collider(boundry3));
            quadTree.Insert(new Collider(boundry4));
            quadTree.Insert(new Collider(boundry5));

            List<ColliderPoint> colliderPoints = quadTree.Query(quadTreeBoundry);

            Assert.IsTrue(20 == colliderPoints.Count);
        }


        [TestCase(0, 0, 5, 5, 4)]
        public void InsertTest_point(int px, int py, int sx, int sy, int exR)
        {
            Rect quadTreeBoundry = new Rect(new Vector2D(0, 0), new Vector2D(50, 50));
            QuadTree quadTree = new QuadTree(quadTreeBoundry, 4);

            Rect boundry = new Rect(new Vector2D(px, py), new Vector2D(sx, sy));
            ColliderPoint BottomLeftCorner = new ColliderPoint(new Collider(boundry), boundry.BottomLeftCorner);
            ColliderPoint BottomRightCorner = new ColliderPoint(new Collider(boundry), boundry.BottomRightCorner);
            ColliderPoint TopLeftCorner = new ColliderPoint(new Collider(boundry), boundry.TopLeftCorner);
            ColliderPoint TopRightCorner = new ColliderPoint(new Collider(boundry), boundry.TopRightCorner);

            quadTree.Insert(BottomLeftCorner);
            quadTree.Insert(BottomRightCorner);
            quadTree.Insert(TopLeftCorner);
            quadTree.Insert(TopRightCorner);

            List<ColliderPoint> colliderPoints = quadTree.Query(quadTreeBoundry);

            Assert.IsTrue(exR == colliderPoints.Count);
        }

        [TestCase(0, 0, 5, 5, 0, 0, 5, 5, 4)]
        [TestCase(0, 0, 5, 5, 3, 0, 5, 5, 2)]
        [TestCase(0, 0, 5, 5, 3, 2, 5, 5, 1)]
        [TestCase(0, 0, 5, 5, 10, 10, 5, 5, 0)]
        public void QueryTest(int px1, int py1, int sx1, int sy1, int px2, int py2, int sx2, int sy2, int exR)
        {
            QuadTree quadTree = new QuadTree(new Rect(new Vector2D(0, 0), new Vector2D(50, 50)), 4);

            Rect boundry1 = new Rect(new Vector2D(px1, py1), new Vector2D(sx1, sy1));
            Rect boundry2 = new Rect(new Vector2D(px2, py2), new Vector2D(sx2, sy2));

            Collider newCollider1 = new Collider(boundry1);

            quadTree.Insert(newCollider1);

            List<ColliderPoint> colliderPoints = quadTree.Query(boundry2);

            Assert.IsTrue(colliderPoints.Count == exR);
        }
    }
}