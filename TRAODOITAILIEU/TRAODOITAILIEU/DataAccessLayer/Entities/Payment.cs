using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("payment")]
public partial class Payment
{
    [Key]
    [Column("paymentId")]
    public int PaymentId { get; set; }

    [Column("paymentDate")]
    public DateOnly PaymentDate { get; set; }

    [Column("paymentMethod")]
    [StringLength(50)]
    public string PaymentMethod { get; set; } = null!;

    [Column("status")]
    public bool Status { get; set; }

    [Column("orderId")]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order Order { get; set; } = null!;
}
