using System;
using ManicTime.TagSource.SampleWeb.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManicTime.TagSource.SampleWeb.Tests
{
    [TestClass]
    public class WebReaderTest
    {
        [TestMethod]
        public void GetItemsTest()
        {
            var sampleUrl = "https://raw.githubusercontent.com/manictime/samplewebtagsource/master/ManicTime.TagSource.SampleWeb/SampleTags.txt";
            var tags = WebReader.GetItemsAsync(sampleUrl).Result;

            Assert.AreEqual(5, tags.Length);
            CollectionAssert.AreEqual(new []{"client 1", "project 1", "Activity 1"}, tags[0].Tags);
            Assert.AreEqual("Activity 1 notes", tags[0].Notes);
        }
    }
}
