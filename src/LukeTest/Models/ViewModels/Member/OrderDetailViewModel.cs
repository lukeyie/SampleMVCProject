using LukeTest.Models.DAO;

namespace LukeTest.Models.ViewModels.Member
{
    public class OrderDetailViewModel
    {
        public IEnumerable<OrderDetailDAO> OrderDetails { get; set; }
        public string PageTitleText = "訂單明細";
    }
}