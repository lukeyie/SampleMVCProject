using LukeTest.Models.DAO;
using LukeTest.Models.ViewModels.Partials;

namespace LukeTest.Models.ViewModels.Member
{
    public class ShoppingCartViewModel
    {
        public DynamicTablePartialViewModel OrderDetails = new DynamicTablePartialViewModel() 
        { 
            Data = new List<OrderDetailDAO>(), 
            EmptyDataText = "目前購物車沒有商品" 
        };
        public string PageTitleText = "會員購物車";
        public string DeleteButtonText = "刪除";
        public string GetDeleteConfirmationText(string productName)
        {
            return $"確定要刪除 {productName} 嗎？";
        }
        public string RecipientTitleText = "填寫訂單收件人資料";
        public string RecipientNameText = "收件人姓名";
        public string RecipientMailText = "收件人信箱";
        public string RecipientAddressText = "收件人地址";
        public string RecipientFormSumbitText = "確認訂購";
    }
}