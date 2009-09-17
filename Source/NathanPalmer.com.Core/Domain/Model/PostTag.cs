using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NathanPalmer.com.Core.Domain.Model
{
    public class PostTag
    {
        public virtual int ID { get; set; }
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
