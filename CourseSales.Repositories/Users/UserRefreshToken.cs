﻿namespace CourseSales.Repositories.Users
{
    public class UserRefreshToken
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
