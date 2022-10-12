using Platform.Core.Entities;
using Platform.Core.Requests.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core.Interfaces
{
    public interface ICommentsService
    {
        Task<ServiceResponse<CommentDto>> Create(CreateCommentDto newComment);
    }
}
