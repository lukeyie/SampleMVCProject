using LukeTest.Models.DTO;

namespace LukeTest.Models.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public string PriceTitleText = "單價";
        public string AddCartText = "加入購物車";
    }
}