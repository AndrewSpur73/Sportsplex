using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _CommentRepo;

        public CommentService(ICommentRepository CommentRepo)
        {
            _CommentRepo = CommentRepo;
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var singleComment = _CommentRepo.GetCommentByIdAsync(id);

            if (singleComment == null)
            {
                throw new ArgumentException("Comment not found.");
            }

            return await _CommentRepo.GetCommentByIdAsync(id);
        }

        public async Task<Comment> CreateCommentAsync(CreateCommentDTO CommentDTO)
        {
            return await _CommentRepo.CreateCommentAsync(CommentDTO);
        }

        public async Task<Comment> DeleteCommentAsync(int id)
        {
            return await _CommentRepo.DeleteCommentAsync(id);
        }

        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            return await _CommentRepo.GetAllCommentsAsync();
        }

        public async Task<Comment> UpdateCommentAsync(int id, UpdateCommentDTO CommentDTO)
        {
            return await _CommentRepo.UpdateCommentAsync(id, CommentDTO);

        }
    }
}
