using Sportsplex.DTO;
using Sportsplex.Models;

namespace Sportsplex.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment> GetCommentByIdAsync(int id);
        Task<Comment> CreateCommentAsync(CreateCommentDTO CommentDTO);
        Task<Comment> UpdateCommentAsync(int id, UpdateCommentDTO CommentDTO);
        Task<Comment> DeleteCommentAsync(int id);
    }
}
