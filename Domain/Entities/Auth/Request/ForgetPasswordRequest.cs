﻿namespace Domain.Entities.Auth.Request
{
    public class ForgetPasswordRequest
    {
        public string? Email { get; set; }
        public string? PageUrl { get; set; } = "https://asg.tryasp.net/swagger/index.html";
    }


}
