﻿namespace Hotel_Reservations_Management
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string expires { get; set; }
        public string issued { get; set; }
        public string userId { get; set; }
        public string role { get; set; }
    }
}