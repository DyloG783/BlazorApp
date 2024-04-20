using BlazorApp1.Components.Layout;
using BlazorApp1.Components.Pages;
using BlazorBootstrap;
using Moq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using System;

namespace BlazorApp1.Unit
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
    /// </summary>
    [TestClass]
    public class NavComponentTests : BunitTestContext
    {
        private Mock<IIdGenerator> mockIdGenerator;

        [TestInitialize]
        public void Setup()
        {

            // Call the base class setup method
            base.Setup();

            // Create a mock of IIdGenerator
            mockIdGenerator = new Mock<IIdGenerator>();

            // Register the mockIdGenerator with the service collection
            Services.AddSingleton(mockIdGenerator.Object);
        }

        [TestMethod]
        public void TitleExistsInNav()
        {
            // Arrange
            var cut = RenderComponent<NavMenu>();

            Console.WriteLine(cut.Find("a.navbar-brand").InnerHtml);

            Assert.IsTrue(Regex.IsMatch(cut.Find("a.navbar-brand").InnerHtml, "Drummers\nJourney", RegexOptions.Singleline));
        }

        [TestMethod]
        public void NavLinksArePresent()
        {

            var cut = RenderComponent<NavMenu>();

            var navLinks = cut.FindAll("a.nav-link");

            Assert.AreEqual(3, navLinks.Count);
            Assert.IsTrue(Regex.IsMatch(navLinks[0].InnerHtml, "Learn"));
            Assert.IsTrue(Regex.IsMatch(navLinks[1].InnerHtml, "Kit"));
            Assert.IsTrue(Regex.IsMatch(navLinks[2].InnerHtml, "Ask"));
        }

        [TestMethod]
        public void LearnSubLinksArePresent()
        {
            var cut = RenderComponent<NavMenu>();

            var dropDownLinks = cut.FindAll("a.dropdown-item");

            Assert.AreEqual(3, dropDownLinks.Count);
            Assert.IsTrue(Regex.IsMatch(dropDownLinks[0].InnerHtml, "Overview"));
            Assert.IsTrue(Regex.IsMatch(dropDownLinks[1].InnerHtml, "Fundamentals"));
            Assert.IsTrue(Regex.IsMatch(dropDownLinks[2].InnerHtml, "Technique"));
        }

    }
}
