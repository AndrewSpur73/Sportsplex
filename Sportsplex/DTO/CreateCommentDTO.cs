﻿namespace Sportsplex.DTO
{
    public class CreateCommentDTO
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public string? Content { get; set; }
    }
}
