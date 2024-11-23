using Microsoft.EntityFrameworkCore;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;

namespace Sportsplex.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly SportsplexDbContext _context;

        public CommentRepository(SportsplexDbContext context)
        {
            _context = context;
        }

        //Get all Comments
        public async Task<List<Comment>> GetAllCommentsAsync()
        {
            {

                var Comment = await _context.Comments
                    .ToListAsync();

                if (Comment == null)
                {
                    return null;
                }

                return Comment;

            };
        }


        //Create a Comment
        public async Task<Comment> CreateCommentAsync(CreateCommentDTO CommentDTO)
        {

            var newComment = new Comment
            {
                Content = CommentDTO.Content
            };

            try
            {
                _context.Comments.Add(newComment);
                await _context.SaveChangesAsync();
                return newComment;
            }
            catch (DbUpdateException)
            {
                return null;
            }

        }


        //Update a Comment
        public async Task<Comment> UpdateCommentAsync(int id, UpdateCommentDTO CommentDTO)
        {
            var CommentToUpdate = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

            if (CommentToUpdate == null)
            {
                return null;
            }
            CommentToUpdate.Content = CommentDTO.Content;

            try
            {
                await _context.SaveChangesAsync();
                return CommentToUpdate;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
        }

        //Delete a Comment
        public async Task<Comment> DeleteCommentAsync(int id)
        {

            var Comment = await _context.Comments
                    .FirstOrDefaultAsync(c => c.Id == id);

            if (Comment == null)
            {
                return null;
            }

            // Remove the Comment
            _context.Comments.Remove(Comment);
            _context.SaveChanges();

            return Comment;

        }

        //Get a Single Comment
        public async Task<Comment> GetCommentByIdAsync(int id)
        {

            var singleComment = await _context.Comments
            .FirstOrDefaultAsync(c => c.Id == id);

            try
            {
                await _context.SaveChangesAsync();
                return singleComment;
            }
            catch (DbUpdateException ex)
            {
                return null;
            }

        }
    }
}
