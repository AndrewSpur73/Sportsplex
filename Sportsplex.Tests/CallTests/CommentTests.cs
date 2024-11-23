using Moq;
using Sportsplex.DTO;
using Sportsplex.Interfaces;
using Sportsplex.Models;
using Sportsplex.Services;


namespace Sportsplex.Tests.CallTests
{
    public class CommentTests
    {
        private readonly Mock<ICommentRepository> _mockCommentRepository;
        private readonly ICommentService _CommentService;

        public CommentTests()
        {
            _mockCommentRepository = new Mock<ICommentRepository>();
            _CommentService = new CommentService(_mockCommentRepository.Object);
        }


        [Fact]
        public async Task GetCommentsAsync_WhenCalled_ReturnCommentsAsync()
        {
            var Comments = new List<Comment>
            {
                new Comment {Id = 1 },
                new Comment {Id = 2 },
                new Comment {Id = 3 }
            };

            _mockCommentRepository.Setup(x => x.GetAllCommentsAsync()).ReturnsAsync(Comments);

            var result = await _CommentService.GetAllCommentsAsync();

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async Task CreateCommentAsync_WhenCalled_ReturnNewCommentAsync()
        {

            var CommentDTO = new CreateCommentDTO
            {
                Content = "I love Tennis"
            };

            var Comment = new Comment
            {
                Content = CommentDTO.Content
            };

            _mockCommentRepository.Setup(x => x.CreateCommentAsync(CommentDTO)).ReturnsAsync(Comment);

            var result = await _CommentService.CreateCommentAsync(CommentDTO);

            Assert.NotNull(result);
            Assert.Equal(CommentDTO.Content, result.Content);
        }

        [Fact]
        public async Task UpdateCommentAsync_WhenCalled_ReturnUpdateCommentAsync()
        {

            int CommentId = 1;

            var Comment = new Comment
            {
                Content = "I love Swimming"
            };

            var editCommentDTO = new UpdateCommentDTO
            {
                Content = "I love Lacrosse"
            };

            var updatedComment = new Comment
            {
                Content = editCommentDTO.Content
            };

            _mockCommentRepository.Setup(x => x.GetCommentByIdAsync(CommentId)).ReturnsAsync(Comment);
            _mockCommentRepository.Setup(x => x.UpdateCommentAsync(CommentId, editCommentDTO)).ReturnsAsync(updatedComment);

            var result = await _CommentService.UpdateCommentAsync(CommentId, editCommentDTO);

            Assert.NotNull(result);
            Assert.Equal(editCommentDTO.Content, result.Content);
        }

        [Fact]
        public async Task GetCommentByIdAsync_WhenCalled_ReturnCommentByIdAsync()
        {

            var Comment = new Comment
            {
                Id = 1,
                Content = "I love Pickleball"
            };

            _mockCommentRepository.Setup(x => x.GetCommentByIdAsync(Comment.Id)).ReturnsAsync(Comment);

            var result = await _CommentService.GetCommentByIdAsync(Comment.Id);

            Assert.NotNull(result);
            Assert.Equal(Comment.Id, result.Id);
            Assert.Equal(Comment.Content, result.Content);
        }

        [Fact]
        public async Task DeleteCommentAsync_WhenCalled_ReturnDeletedCommentAsync()
        {

            var Comment = new Comment
            {
                Id = 1,
                Content = "I love Pickleball"
            };

            _mockCommentRepository.Setup(x => x.GetCommentByIdAsync(Comment.Id)).ReturnsAsync(Comment);

            await _CommentService.DeleteCommentAsync(Comment.Id);

            _mockCommentRepository.Verify(x => x.DeleteCommentAsync(Comment.Id), Times.Once);

            _mockCommentRepository.Setup(x => x.GetCommentByIdAsync(Comment.Id)).ReturnsAsync((Comment)null);
        }
    }
}
