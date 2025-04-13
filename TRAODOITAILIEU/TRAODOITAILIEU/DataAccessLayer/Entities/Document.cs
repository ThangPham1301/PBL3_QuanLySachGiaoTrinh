using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("document")]
public partial class Document
{
    [Key]
    [Column("documentId")]
    public int DocumentId { get; set; }

    [Column("accountId")]
    public int AccountId { get; set; }

    [Column("documentName")]
    [StringLength(100)]
    public string DocumentName { get; set; } = null!;

    [Column("category")]
    [StringLength(50)]
    public string? Category { get; set; }

    [Column("price")]
    public double? Price { get; set; }

    [Column("author")]
    [StringLength(100)]
    public string? Author { get; set; }

    [ForeignKey("AccountId")]
    [InverseProperty("Documents")]
    public virtual Account Account { get; set; } = null!;

    [InverseProperty("Document")]
    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    [InverseProperty("Document")]
    public virtual ICollection<OrderDocument> OrderDocuments { get; set; } = new List<OrderDocument>();
}
