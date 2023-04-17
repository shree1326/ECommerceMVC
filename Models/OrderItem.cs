﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public int PaintingId { get; set; }
        [ForeignKey("PaintingId")]
        public Painting Painting { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
