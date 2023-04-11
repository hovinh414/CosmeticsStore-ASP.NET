using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Windows.Input;

namespace CosmeticsStore.Models.EF
{
    [Table("tb_BookingDetails")]
    public class BookingDetails
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ServiceId { get; set; }
        public int BranchId { get; set; }
        public decimal Price { get; set; }
        public virtual Bookings Bookings { get; set; }
        public virtual Service Service { get; set; }
        public virtual Branchs Branchs { get; set; }
    }
}