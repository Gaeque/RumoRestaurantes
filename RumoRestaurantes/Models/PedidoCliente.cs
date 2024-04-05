using System.ComponentModel.DataAnnotations;

namespace RumoRestaurantes.Models
{
    public class PedidoCliente
    {
        public int PedidoClienteId { get; set; }
        public string? NomeSolicitante { get; set; }
        public int Mesa { get; set; }
        public string? Prato { get; set; }
        public string? Bebida { get; set; }
        public int Quantidade { get; set; }

        [Display(Name = "Data e Hora do Pedido")]
        public DateTime DataHoraPedido { get; set; }
    }
}
