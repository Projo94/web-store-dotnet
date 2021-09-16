using System.ComponentModel.DataAnnotations;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetProductList
{
    public class SizeTypeToReturnDto
    {

        public int SizeTypeEID { get; set; }

        public string Caption { get; set; }
    }
}
