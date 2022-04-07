using System;
//using Brain.Dev.GStock.Metier.Tools.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brain.Dev.GStock.Metier.Models
{
    [Table("Category")]
    public class CategoryModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required, MaxLength(100)]
        [StringLength(100)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //public string Image { get; set; }
        //public EnumStatus Status { get; set; } = EnumStatus.Enable;

        //[NotMapped]
        //public string StatusStr
        //{
        //    get
        //    {
        //        return Status.ToString();//StatusC.Str(Status);
        //    }
        //}
        //[NotMapped]
        //public string StatusClass
        //{
        //    get
        //    {
        //        return StatusC.getClass(Status);
        //    }
        //}
    }
}
