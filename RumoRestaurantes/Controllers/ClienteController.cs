using Microsoft.AspNetCore.Mvc;
using RumoRestaurantes.Context;
using RumoRestaurantes.Models;

namespace RumoRestaurantes.Controllers
{
    public class ClienteController : Controller
    {

        private readonly PedidoContext _pedidoContext;
        public ClienteController(PedidoContext pedidoContext)
        {
            _pedidoContext = pedidoContext;
        }


        // Recebe os dados do pedido vindo de cliente index.cshtml
        [HttpPost]
        public IActionResult CriarPedido(PedidoCliente cliente)
        {
            cliente.DataHoraPedido = DateTime.Now;
            _pedidoContext.Pedidos.Add(cliente);
            _pedidoContext.SaveChanges();
            TempData["Mensagem"] = "Pedido realizado com sucesso"; 
            return RedirectToAction("Index");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}


