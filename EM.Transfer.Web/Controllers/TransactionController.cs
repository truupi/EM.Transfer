using System.Threading.Tasks;
using System.Web.Http;
using EM.Transfer.DAL.Common.Interfaces;

namespace EM.Transfer.Web.Controllers
{
    public class TransactionController : ApiController
    {
        protected readonly ITransactionManager _manager;

        public TransactionController(ITransactionManager manager)
        {
            _manager = manager;
        }

        [HttpGet, Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var transactions = await _manager.GetAllTransactionsAsync();
            return Json(transactions);
        }
    }
}
