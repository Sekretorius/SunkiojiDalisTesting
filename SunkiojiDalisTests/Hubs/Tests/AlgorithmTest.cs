using NUnit.Framework;
using SignalRWebPack.Characters;
using SignalRWebPack.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunkiojiDalisTests.Hubs.Tests
{
    class AlgorithmTest
    {
        [Test]
        public void AttackAlgorithmConstructorTest()
        {
            AttackAlgorithm algorithmRanged = new Ranged("ranged", 10, 10, 10);
            Assert.AreNotEqual(algorithmRanged, null);

            AttackAlgorithm algorithmMelee = new Melee("melee", 10, 10);
            Assert.AreNotEqual(algorithmMelee, null);

            AttackAlgorithm algorithmMixed = new Mixed("melee", 10);
            Assert.AreNotEqual(algorithmMixed, null);
        }

        [Test]
        public void MoveAlgorithmContructorTest()
        {
            MoveAlgorithm algorithmFly = new Fly();
            Assert.AreNotEqual(algorithmFly, null);

            MoveAlgorithm algorithmWalk = new Walk();
            Assert.AreNotEqual(algorithmWalk, null);

            MoveAlgorithm algorithmMixed = new MixedMove(1);
            Assert.AreNotEqual(algorithmMixed, null);

            MoveAlgorithm algorithmStand = new Stand();
            Assert.AreNotEqual(algorithmStand, null);
        }

        [Test]
        public void AttackAlgorithmTest()
        {
            AttackAlgorithm algorithmRanged = new Ranged("ranged", 10, 10, 10);
            Assert.AreNotEqual(algorithmRanged, null);

            float delayRanged = algorithmRanged.Attack(new Vector2D(10, 10), new Vector2D(15, 15));
            Assert.AreEqual(delayRanged, 10);

            AttackAlgorithm algorithmMelee = new Melee("melee", 10, 10);
            Assert.AreNotEqual(algorithmMelee, null);

            float delayMelee = algorithmMelee.Attack(new Vector2D(10, 10), new Vector2D(15, 15));
            Assert.AreEqual(delayMelee, 10);

            AttackAlgorithm algorithmMixed = new Mixed("melee", 10);
            Assert.AreNotEqual(algorithmMixed, null);

            float delayMixed = algorithmMelee.Attack(new Vector2D(10, 10), new Vector2D(15, 15));
            Assert.AreEqual(delayMelee, 10);
        }

        [Test]
        public void MoveAlgorithmTest()
        {
            Vector2D currentPosition = new Vector2D(10, 10);
            Vector2D targetPositiom = new Vector2D(20, 20);
            Vector2D newPostion;

            //fly
            MoveAlgorithm algorithmFly = new Fly();
            Assert.AreNotEqual(algorithmFly, null);

            ServerEngine.Instance.UpdateTime = 10;
            newPostion = algorithmFly.Move(currentPosition, targetPositiom, 5);
            Assert.AreEqual(currentPosition.X, newPostion.X);
            Assert.AreEqual(currentPosition.Y, newPostion.Y);

            //walk
            MoveAlgorithm algorithmWalk = new Walk();
            Assert.AreNotEqual(algorithmWalk, null);

            ServerEngine.Instance.UpdateTime = 10;
            newPostion = algorithmWalk.Move(currentPosition, targetPositiom, 5);
            Assert.AreNotEqual(currentPosition.X, newPostion.X);
            Assert.AreNotEqual(currentPosition.Y, newPostion.Y);

            //mixed move
            MoveAlgorithm algorithmMixed = new MixedMove(10);
            Assert.AreNotEqual(algorithmMixed, null);

            ServerEngine.Instance.UpdateTime = 10;
            newPostion = algorithmMixed.Move(currentPosition, targetPositiom, 5);
            Assert.AreNotEqual(currentPosition.X, newPostion.X);
            Assert.AreNotEqual(currentPosition.Y, newPostion.Y);

            //stand
            MoveAlgorithm algorithmStand = new Stand();
            Assert.AreNotEqual(algorithmStand, null);

            ServerEngine.Instance.UpdateTime = 10;
            newPostion = algorithmStand.Move(currentPosition, targetPositiom, 5);
            Assert.AreEqual(currentPosition.X, newPostion.X);
            Assert.AreEqual(currentPosition.Y, newPostion.Y);
        }


        [Test]
        public void MoveAlgorithmShallowCopyTest()
        {
            MoveAlgorithm algorithmFly = new Fly();
            MoveAlgorithm algorithmFlyShallow = algorithmFly.ShallowCopy();

            Assert.AreNotEqual(algorithmFlyShallow.GetHashCode(), algorithmFly.GetHashCode());

            MoveAlgorithm algorithmWalk = new Walk();
            MoveAlgorithm algorithmWalkShallow = algorithmWalk.ShallowCopy();

            Assert.AreNotEqual(algorithmWalkShallow.GetHashCode(), algorithmWalk.GetHashCode());

            MoveAlgorithm algorithmStand = new Stand();
            MoveAlgorithm algorithmStandShallow = algorithmStand.ShallowCopy();

            Assert.AreNotEqual(algorithmStandShallow.GetHashCode(), algorithmStand.GetHashCode());

            MoveAlgorithm algorithmMixedMove = new MixedMove(1);
            MoveAlgorithm algorithmMixedMoveShallow = algorithmMixedMove.ShallowCopy();

            Assert.AreNotEqual(algorithmMixedMoveShallow.GetHashCode(), algorithmMixedMove.GetHashCode());
        }
    }
}
