using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ViewsExamples.ViewComponents
{
    [ViewComponent(Name = "MeuCarrinho")]
    public class CarrinhoViewComponent : ViewComponent
    {
        public int ItensNoCarrinho { get; set; }

        public CarrinhoViewComponent()
        {
            ItensNoCarrinho = 5;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(ItensNoCarrinho);
        }
    }
}
