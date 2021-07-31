using Blog.Interfaces.Base;
using System;

namespace Blog.Interfaces.Post
{
    public class Post : BaseEntity
    {
        Guid CategoryId { get; set; }
    }
}