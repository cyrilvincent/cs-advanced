namespace FormationTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var i = 0;
            i++;
            // Assert.AreEqual(1, i);
            Assert.That(1, Is.EqualTo(i));
        }
    }
}