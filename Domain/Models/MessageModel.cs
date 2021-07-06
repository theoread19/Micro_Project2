using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class MessageModel
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public long SenderId { get; set; }
        public long RecipientId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual UserModel Sender { get; set; }
        public virtual UserModel Recipeint { get; set; }
    }
}
