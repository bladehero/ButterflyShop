using ButterflyShop.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;

namespace ButterflyShop.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork UnitOfWork { get; private set; }

        public BaseController()
        {
            UnitOfWork = new UnitOfWork(new SqlConnection(GlobalVariables.ConnectionString));
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            UnitOfWork.Dispose();
        }
    }
}
