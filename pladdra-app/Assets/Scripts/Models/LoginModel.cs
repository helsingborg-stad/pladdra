using UnityEngine;


namespace Pladdra.MVC.Models
{
    public class LoginModel
    {
        public bool isLoading { get; set; }
        public string noticeMessage { get; set; }
        public bool resetPassword { get; set; }
    }
}
