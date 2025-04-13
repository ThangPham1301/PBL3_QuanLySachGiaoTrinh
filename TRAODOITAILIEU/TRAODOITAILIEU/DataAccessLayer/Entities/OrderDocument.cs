using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("order_document")]
public partial class OrderDocument
{
    [Key]
    [Column("order_documentId")]
    public int OrderDocumentId { get; set; }

    [Column("documentId")]
    public int DocumentId { get; set; }

    [Column("orderId")]
    public int OrderId { get; set; }

    [ForeignKey("DocumentId")]
    [InverseProperty("OrderDocuments")]
    public virtual Document Document { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDocuments")]
    public virtual Order Order { get; set; } = null!;
}
