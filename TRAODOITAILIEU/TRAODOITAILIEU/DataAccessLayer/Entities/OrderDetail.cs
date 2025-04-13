using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

[Table("orderDetail")]
public partial class OrderDetail
{
    [Key]
    [Column("orderDetailId")]
    public int OrderDetailId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("bookingDate")]
    public DateOnly BookingDate { get; set; }

    [Column("orderId")]
    public int OrderId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order Order { get; set; } = null!;
}
