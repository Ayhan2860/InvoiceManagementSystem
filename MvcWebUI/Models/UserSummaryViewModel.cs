namespace MvcWebUI.Models
{
    public class UserSummaryViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }= false;
    }
}