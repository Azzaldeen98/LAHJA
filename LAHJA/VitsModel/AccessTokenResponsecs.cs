﻿namespace CardShopping.Web.VitsModel
{
    public class AccessTokenResponsecs
    {
        
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public long ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
