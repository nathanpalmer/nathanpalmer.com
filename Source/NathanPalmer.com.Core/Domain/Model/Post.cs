using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NathanPalmer.com.Core.Domain.Model
{
    public class Post
    {
        public virtual int ID { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }
    }
}
