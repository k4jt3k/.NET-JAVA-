using lab1;

namespace lab1_testy
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var problem = new Problem(10, 1);
            var result = problem.Solve(100);
            Assert.IsTrue(result.Items.Count > 0);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var problem = new Problem(10, 1);
            var result = problem.Solve(0);
            Assert.AreEqual(0, result.Items.Count);
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<int> sizes = new List<int>() { 10, 20, 30, 40, 50 };

            foreach (int n in sizes)
            {
                Problem problem = new Problem(n, 1);
                Assert.AreEqual(n, problem.Items.Count);
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            var problem = new Problem(10, 1);
            var result = problem.Solve(10);
            Assert.AreNotEqual(0, result.sumvalue);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int capacity = 25;
            var problem = new Problem(20, 123);
            var result = problem.Solve(capacity);
            Assert.IsTrue(result.sumweight <= capacity);
        }
    }
}
