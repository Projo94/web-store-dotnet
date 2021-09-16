using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.WebStore.Application.Features.Products.Queries.GetBestBuyProductsInLastMonth
{
    public class GetBestBuyProductsInLastMonthQuery : IRequest<List<BestBuyProductVm>>
    {

    }
}
