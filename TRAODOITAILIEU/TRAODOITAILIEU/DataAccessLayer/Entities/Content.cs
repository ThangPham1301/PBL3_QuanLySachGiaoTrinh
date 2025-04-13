using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("content")]
public partial class Content
{
    [Key]
    [Column("contentId")]
    public int ContentId { get; set; }

    [Column("content")]
    public string? Content1 { get; set; }

    [Column("commentDate")]
    public DateTime? CommentDate { get; set; }

    [Column("documentId")]
    public int DocumentId { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("Contents")]
    public virtual Document Document { get; set; } = null!;
}
