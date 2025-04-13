using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("account")]
public partial class Account
{
    [Key]
    [Column("accountId")]
    public int AccountId { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(100)]
    public string Password { get; set; } = null!;

    [Column("role")]
    public int Role { get; set; }

    [InverseProperty("Account")]
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    [InverseProperty("Account")]
    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();
}
