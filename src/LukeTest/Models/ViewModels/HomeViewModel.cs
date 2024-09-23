using LukeTest.Models;

namespace LukeTest.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string PriceTitleText = "單價";
        public string AddCartText = "加入購物車";
    }
}