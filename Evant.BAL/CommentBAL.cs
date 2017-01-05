using Evant.BO;
using Evant.BO.AdminModels;
using Evant.BO.Models;
using Evant.DAL;
using System;
using System.Collections.Generic;

namespace Evant.BAL
{
    public sealed class CommentBAL
    {
        private CommentDAL commentDal;


        public CommentBAL()
        {
            commentDal = new CommentDAL();
        }


        public ResultModel AddComment(AddCommentModel model)
        {
            if(!string.IsNullOrEmpty(model.Title) && !string.IsNullOrEmpty(model.Content))
            {
                return commentDal.AddComment(model);
            }

            else
            {
                return new ResultModel()
                {
                    IsSuccess = false,
                    Message = "Unsuccessful comment add operation"
                };
            }
        }

        public List<CommentBO> GetAllComments(int eventId)
        {
            return commentDal.GetAllComments(eventId);
        }

        public List<CommentModel> Admin_GetAllComments()
        {
            return commentDal.Admin_GetAllComments();
        }

        public void Admin_DeleteComment(int commentId)
        {
            commentDal.Admin_DeleteComment(commentId);
        }

        public ResultModel Admin_CommentUpdate(int id, string title, string content)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(content))
            {
                return commentDal.Admin_CommentUpdate(id, title, content);
            }

            else
            {
                return new ResultModel()
                {
                    IsSuccess = false,
                    Message = "Do not leave empty places"
                };
            }
        }
    }
}