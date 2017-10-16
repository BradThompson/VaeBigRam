using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VAE;

namespace BigRamUnitTests
{
    [TestClass]
    public class BigRamTests
    {
        [TestMethod]
        public void BruteForceBigRamTest()
        {
            var result = BigRam.BruteForceBigRam("this is a test is a test");
            Assert.AreEqual(result.Count, 4, "Only 4 pairs should be found.");

            Assert.IsTrue(result.ContainsKey("a test"));
            Assert.IsTrue(result.ContainsKey("is a"));
            Assert.IsTrue(result.ContainsKey("test is"));
            Assert.IsTrue(result.ContainsKey("this is"));

            Assert.AreEqual(result["a test"], 2);
            Assert.AreEqual(result["is a"], 2);
            Assert.AreEqual(result["test is"], 1);
            Assert.AreEqual(result["this is"], 1);
        }

        [TestMethod]
        public void BigRamUsingFileTest()
        {
            var result = BigRam.BigRamUsingFile("NoMatches.txt");
            Assert.AreEqual(result.Count, 1);

            Assert.IsTrue(result.ContainsKey("no matches"));
            Assert.AreEqual(result["no matches"], 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BigRamUsingDoesntExistTest()
        {
            var result = BigRam.BigRamUsingFile("DoesntExist.txt");
        }

        [TestMethod]
        public void BigRamUsingRegularFileTest()
        {
            var result = BigRam.BigRamUsingFile("Regular.txt");
            Assert.AreEqual(result.Count, 14);

            Assert.IsTrue(result.ContainsKey("about punctiation"));
            Assert.IsTrue(result.ContainsKey("and lots"));
            Assert.IsTrue(result.ContainsKey("I wonder"));
            Assert.IsTrue(result.ContainsKey("if we"));
            Assert.IsTrue(result.ContainsKey("lots and"));
            Assert.IsTrue(result.ContainsKey("lots of"));
            Assert.IsTrue(result.ContainsKey("matches, I"));
            Assert.IsTrue(result.ContainsKey("of matches,"));
            Assert.IsTrue(result.ContainsKey("punctiation about"));
            Assert.IsTrue(result.ContainsKey("should worry"));
            Assert.IsTrue(result.ContainsKey("we if"));
            Assert.IsTrue(result.ContainsKey("we should"));
            Assert.IsTrue(result.ContainsKey("wonder if"));
            Assert.IsTrue(result.ContainsKey("worry about"));

            int totalOne = 0;
            int totalTwo = 0;
            foreach (var item in result)
            {
                Assert.IsTrue(item.Value == 1 || item.Value == 2);
                if (item.Value == 1)
                    totalOne++;
                else
                    totalTwo++;
            }
            Assert.AreEqual(totalOne, 10, "Total count of ones should be {0}", totalOne);
            Assert.AreEqual(totalTwo, 4, "Total count of twos should be {0}", totalTwo);
        }

    }
}
