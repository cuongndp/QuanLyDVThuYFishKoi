using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fish.Repositories.Models
{
    public class PublicMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; } // ID của người dùng gửi tin nhắn
        public virtual User User { get; set; } // Navigation property để liên kết với bảng User

        public string NoiDung { get; set; } // Nội dung của tin nhắn
    }
}
