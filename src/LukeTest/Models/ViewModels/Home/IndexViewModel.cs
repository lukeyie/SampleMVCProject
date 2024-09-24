using LukeTest.Models;

namespace LukeTest.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<ProductDAO> Products { get; set; } = new List<ProductDAO>();
        public string PriceTitleText = "單價";
        public string AddCartText = "加入購物車";
    }
}