using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NathanPalmer.com.Core.Domain.Model
{
    public class Post
    {
        public int ID { get; set; }
        public DateTime DateCreated { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IList<Tag> Tags { get; set; }

        public Post()
        {
            Tags = new List<Tag>();
            DateCreated = DateTime.Now;
        }
    }
}
