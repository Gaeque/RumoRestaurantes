using Microsoft.AspNetCore.Mvc;
using RumoRestaurantes.Context;
using RumoRestaurantes.Models;


namespace RumoRestaurantes.Controllers
{
    public class FuncionarioController : Controller
    {

        private readonly PedidoContext _pedidoContext;
        public FuncionarioController(PedidoContext pedidoContext)
        {
            _pedidoContext = pedidoContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        // Verificação simples de login
        [HttpPost]
        public IActionResult Login(string nome, string senha)
        {
            if (nome == "gaeque" && senha == "123")
            {
                return RedirectToAction("Index", "Funcionario", new { area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Home"); 
            }
        }


        // Ação para retornar os dados de Pedidos presentes no banco de dados, incrementado na views/funcionario/index
        [HttpGet]
        public IActionResult Pedidos()
        {
            var pedidos = _pedidoContext.Pedidos.ToList();
            return Ok(pedidos);
        }

        // Ação para remover os pedidos, incrementado na views/funcionario/index
        [HttpDelete]
        public IActionResult Pedidos(int id)
        {
            var item = _pedidoContext.Pedidos.Find(id);

            if (item == null)
            {
                return NotFound("Item não encontrado");
            }

            _pedidoContext.Pedidos.Remove(item);
            _pedidoContext.SaveChanges();
            return Ok();
        }

    }
}
