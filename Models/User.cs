using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Musictify.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string Email { get; set; } = null!;
    }
}
