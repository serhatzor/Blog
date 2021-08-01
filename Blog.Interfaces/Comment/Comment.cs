using Blog.Interfaces.Base;
using System;

namespace Blog.Interfaces.Comment
{
    public class Comment : BaseEntity
    {
        public Guid PostId { get; set; }
        public string Text { get; set; }
    }
}