using Blog.Interfaces.Base;
using System;

namespace Blog.Interfaces.Comment
{
    public class Comment : BaseEntity
    {
        Guid PostId { get; set; }
        string Text { get; set; }
    }
}