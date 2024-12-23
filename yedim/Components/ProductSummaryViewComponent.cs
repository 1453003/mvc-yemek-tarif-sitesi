using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace yedim.Components
{ 
    // bu kodlar kaç tane ürün varsa onu döndürecek 
    public class ProductSummaryViewComponent:ViewComponent
    {
        private readonly IServiceManager _manager; //!

        public ProductSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            //Service
            return _manager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
