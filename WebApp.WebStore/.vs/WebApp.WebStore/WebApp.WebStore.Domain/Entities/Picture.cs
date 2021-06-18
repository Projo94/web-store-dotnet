using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.WebStore.Domain.Entities
{
    public class Picture
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PictureID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string PictureDisplay { get; set; }


        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public Guid ProductID { get; set; }
    }
}

