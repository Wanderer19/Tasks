using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLife
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateStartField()
        {
            var field = Life.Field.CreatStartField(1, 1, 1, 2, 1, 3);

            Assert.AreEqual(field.AliveCells.Count, 3);
            Assert.IsTrue(field.AliveCells.Contains(Tuple.Create(1, 1)));
            Assert.IsTrue(field.AliveCells.Contains(Tuple.Create(1, 2)));
            Assert.IsTrue(field.AliveCells.Contains(Tuple.Create(1, 3)));
        }

        [TestMethod]
        public void TestMaxMinXy()
        {
            var field = Life.Field.CreatStartField(1, 1, 1, 2, 1, 3);

            Assert.AreEqual(field.MaxX, 1);
            Assert.AreEqual(field.MinX, 1);
            Assert.AreEqual(field.MaxY, 3);
            Assert.AreEqual(field.MinY, 1);
        }

        [TestMethod]
        public void TestCountAliveNeibs()
        {
            var field = Life.Field.CreatStartField(1, 1, 1, 2, 1, 3);

            Assert.AreEqual(1, field.CountAliveNeibs(1, 1));
            Assert.AreEqual(1, field.CountAliveNeibs(0, 0));
            Assert.AreEqual(3, field.CountAliveNeibs(0, 2));
            Assert.AreEqual(3, field.CountAliveNeibs(2, 2));
            Assert.AreEqual(1, field.CountAliveNeibs(2, 0));
            Assert.AreEqual(2, field.CountAliveNeibs(2, 1));
            
        }

        [TestMethod]
        public void TestIsAlive()
        {
            var field = Life.Field.CreatStartField(1, 1, 1, 2, 1, 3);

            Assert.IsTrue(field.IsAlive(1, 2));
            Assert.IsFalse(field.IsAlive(1, 1));
            Assert.IsFalse(field.IsAlive(1, 3));
            Assert.IsTrue(field.IsAlive(0, 2));
            Assert.IsTrue(field.IsAlive(2, 2));
            Assert.IsFalse(field.IsAlive(0, 0));
            Assert.IsFalse(field.IsAlive(1, 4));

        }

        [TestMethod]
        public void TestNextStep()
        {
            var field = Life.Field.CreatStartField(1, 1, 1, 2, 1, 3);
            field.NextStep();
            
            Assert.AreEqual(3, field.AliveCells.Count());
            Assert.IsTrue(field.AliveCells.Contains(Tuple.Create(0, 2)));
            Assert.IsTrue(field.AliveCells.Contains(Tuple.Create(1, 2)));
            Assert.IsTrue(field.AliveCells.Contains(Tuple.Create(2, 2)));
        }
    }
}
