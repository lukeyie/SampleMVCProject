using LukeTest.Models.DAO;

namespace LukeTest.Models.ViewModels.Member
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderDAO> Orders { get; set; }
        public string PageTitleText = "會員訂單列表";
        public string OrderDetailButtonText = "訂單明細";
        public string NoOrderText = "目前沒有訂單";
    }
}