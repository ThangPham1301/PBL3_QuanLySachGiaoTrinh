using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("user_profile")]
public partial class UserProfile
{
    [Column("accountId")]
    public int AccountId { get; set; }

    [Column("fullName")]
    [StringLength(100)]
    public string? FullName { get; set; }

    [Column("address")]
    [StringLength(200)]
    public string? Address { get; set; }

    [Column("birth")]
    public DateTime? Birth { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("phone")]
    [StringLength(20)]
    public string? Phone { get; set; }

    [Key]
    [Column("profileId")]
    public int ProfileId { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("UserProfiles")]
    public virtual Account Account { get; set; } = null!;
}
