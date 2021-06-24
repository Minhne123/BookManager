namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Mã sách không được để trống")]
        [Display(Name = "Mã sách")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100, ErrorMessage = "Tiêu đề sách không được vượt quá 30 ký tự")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Miêu tả không được để trống")]
        [Display(Name = "Miêu tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tác giả không được để trống")]
        [StringLength(30, ErrorMessage = "Tác giả sách không được vượt quá 30 ký tự")]
        [Display(Name = "Tác giả")]
        public string Author { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        [Display(Name = "Hình ảnh")]
        public string Images { get; set; }

        [Required(ErrorMessage = "Giá sách không được để trống")]
        [Range(1000, 1000000, ErrorMessage = "Giá sách từ 1000 - 1.000.000")]
        [Display(Name = "Giá sách")]
        public int Price { get; set; }
    }
}
