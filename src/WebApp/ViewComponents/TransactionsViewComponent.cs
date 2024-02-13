using Microsoft.AspNetCore.Mvc;
using CoreBusiness;
using UseCases;

namespace WebApp.ViewComponents
{
    // decorate to tells the compiller that this class is a ViewComponent
    //heredada de ViewComponent
    [ViewComponent]
    public class TransactionsViewComponent : ViewComponent
    {

		private readonly IGetTodayTransactionsUseCase getTodayTransactionsUseCase;

		public TransactionsViewComponent(IGetTodayTransactionsUseCase getTodayTransactionsUseCase)
		{
			this.getTodayTransactionsUseCase = getTodayTransactionsUseCase;
		}

		public IViewComponentResult Invoke(string userName)
        {
            //var transactions = getTodayTransactionsUseCase.Execute(userName, DateTime.Now);
            
            var transactions = getTodayTransactionsUseCase.Execute(userName);
            
            return View(transactions);
        }
    }
}
