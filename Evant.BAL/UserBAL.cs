using Evant.BO;
using Evant.BO.AdminModels;
using Evant.BO.Models;
using Evant.DAL;
using System;
using System.Collections.Generic;

namespace Evant.BAL
{
    public sealed class UserBAL
    {
        private UserDAL userDal;


        public UserBAL()
        {
            userDal = new UserDAL();
        }


        public TokenBO Register(RegisterModel user)
        {
            if(!string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                return userDal.Register(user);
            }

            else
            {
                return null;
            }         
        }

        public TokenBO Login(LoginModel user)
        {
            if(!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                return userDal.Login(user);
            }

            else
            {
                var model = new TokenBO()
                {
                    AccessToken = null,
                    IsSuccess = false,
                    Message = "Kullanıcı adı ve şifreyi boş bırakmayınız."
                };

                return model;
            }
        }

        public UserBO GetMe(string token)
        {
            return userDal.GetMe(token);
        }

        public UserBO GetPersonInformation(int personId)
        {
            return userDal.GetPersonInformation(personId);
        }

        public List<FollowerModel> GetFollowers(int personId)
        {
            return userDal.GetFollowers(personId);
        }

        public List<FollowingModel> GetFollowing(int personId)
        {
            return userDal.GetFollowing(personId);
        }

        public ResultModel ChangePassword(ChangePasswordModel password)
        {
            if(!string.IsNullOrEmpty(password.NewPassword) && !string.IsNullOrEmpty(password.OldPassword) && !string.IsNullOrEmpty(password.ReNewPassword))
            {
                if (password.OldPassword == password.NewPassword)
                {
                    return new ResultModel() { Message = "Please choose a different password" };
                }

                else if (password.NewPassword == password.ReNewPassword)
                {
                    return userDal.ChangePassword(password);
                }

                else
                {
                    return new ResultModel() { Message = "New passwords are not same" };
                }

            }

            else
            {
                return new ResultModel() { Message = "Do not leave empty spaces" };
            }
        }

        public ResultModel DeleteAccount(int personId)
        {
            return userDal.DeleteAccount(personId);
        }

        public List<UserModel> Admin_GetAllUsers()
        {
            return userDal.Admin_GetAllUsers();
        }

        public ResultModel Admin_UserUpdate(int id, string name, string email)
        {
            if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                return userDal.Admin_UserUpdate(id, name, email);
            }

            else
            {
                return new ResultModel()
                {
                    IsSuccess = false,
                    Message = "Do not leave empty spaces"
                };
            }
        }
    }
}