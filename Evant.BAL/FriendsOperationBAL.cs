using Evant.BO.AdminModels;
using Evant.BO.Models;
using Evant.DAL;
using System;
using System.Collections.Generic;

namespace Evant.BAL
{
    public sealed class FriendsOperationBAL
    {
        private FriendsOperationDAL friendsOperationDal;


        public FriendsOperationBAL()
        {
            friendsOperationDal = new FriendsOperationDAL();
        }


        public ResultModel FriendOperation(int followedId, int followerId)
        {
            return friendsOperationDal.FriendOperation(followedId, followerId);
        }

        public bool GetFriendOperationControl(int personId, int meId)
        {
            return friendsOperationDal.GetFriendOperationControl(personId, meId);
        }

        public List<FriendOperationModel> Admin_AllFriendOperations()
        {
            return friendsOperationDal.Admin_AllFriendOperations();
        }

        public ResultModel RemoveFriendOperation(int id)
        {
            return friendsOperationDal.RemoveFriendOperation(id);
        }
    }
}