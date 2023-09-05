using DSA_Lab1_1;

namespace DSA_Lab1_1Test
{
    [TestClass]
    public class ProteinSelection
    {
        RestaurantMenu menu;
        [TestInitialize]
        public void TestSetup()
        {
            menu = new RestaurantMenu();
        }

        [TestMethod]
        [DataRow("Beef","hamburger")]
        [DataRow("Pepperoni","pizza")]
        [DataRow("Tofu","Tofu Fried Rice")]
        public void TestWithExpectedProteinTypeShouldReturnCorrespondingDishes(string proteinChoices,string menuItem)
        {
            string dish = menu.GetDishRecommendation(proteinChoices);
            Assert.AreEqual(menuItem, dish, true);
        }

        [TestMethod]
        public void TestWith_UNExpected_ProteinTypeShouldReturnMessageProteinNotAvailable()
        {
            string dish = menu.GetDishRecommendation("fish");
            Assert.AreEqual("That protein is not available.", dish, true);
        }
    }

 
}