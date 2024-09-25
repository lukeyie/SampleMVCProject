using LukeTest.Models.DAO;
using LukeTest.Models.ViewModels.Partials;

namespace LukeTest.Models.ViewModels.Member
{
    public class OrderDetailViewModel
    {
        public DynamicTablePartialViewModel OrderDetails = new DynamicTablePartialViewModel() 
        { 
            Data = new List<OrderDetailDAO>(), 
            EmptyDataText = "此訂單中無商品" 
        };
        public string PageTitleText = "訂單明細";
    }
}