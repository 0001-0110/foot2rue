using foot2rue.WF.Extensions;
using foot2rue.WF.Services;
using System.Text.RegularExpressions;

namespace TestingIsDoubting.WF.Localization
{
    public class LocalizationTest
    {
        //LocalizationService localizationService;

        [SetUp]
        public void Setup()
        {
            //localizationService = new LocalizationService(); 
        }

        [Test]
        [TestCase("test", "test")]
        public void GetLocalizedStringTest(string expected, string input)
        {
            //Assert.That(localizationService.GetLocalizedString(input), Is.EqualTo(expected));
        }
    }
}
