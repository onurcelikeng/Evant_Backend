﻿namespace Evant.BO.AdminModels
{
    public sealed class UserModel : BaseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string AccessToken { get; set; }
    }
}