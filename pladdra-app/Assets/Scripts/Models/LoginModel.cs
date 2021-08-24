using UnityEngine;


namespace Pladdra.MVC.Models
{
    public interface ILoginModel
    {
        public bool isLoading { get; set; }
        public bool resetPassword { get; set; }
        public string noticeMessage { get; set; }
    }

    public class LoginModel : ILoginModel
    {
        public bool isLoading { get; set; }
        public string noticeMessage { get; set; }
        public bool resetPassword { get; set; }
    }
}
