namespace DSA_Lab1_1
{
    public class RestaurantMenu
    {
        public string GetDishRecommendation(string proteinChoices)
        {
            switch (proteinChoices.ToLower())
            {
                case "beef":
                    return "Hamburger";
                case "pepperoni":
                    return "Pizza";
                case "tofu":
                    return "Tofu fried rice";
                default:
                    return "That protein is not available.";
            }
        }
    }
}