using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CosmeticsStore.Models.EF
{
    [Table("tb_Bookings")]
    public class Bookings : CommonAbstract
    {
        public Bookings()
        {
            this.BookingDetails = new HashSet<BookingDetails>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không được để trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ngày không được để trống")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Giờ bắt đầu không được để trống")]
        public DateTime TimeStart { get; set; }
        [Required(ErrorMessage = "Giờ kết thúc không được để trống")]
        public DateTime TimeFinish { get; set; }

        public decimal TotalAmount { get; set; }
        public virtual ICollection<BookingDetails> BookingDetails { get; set; }
    }
}