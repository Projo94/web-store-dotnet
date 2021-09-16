using System.ComponentModel.DataAnnotations;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductList
{
    public class CategoryToReturnDto
    {
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string Caption { get; set; }
    }
}
