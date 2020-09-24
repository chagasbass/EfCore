using EFCORE.Exemplos.Entidades;

namespace EFCORE.Exemplos.Contratos
{
    public interface IPedidoRepositorio
    {
        void InserirPedido(Pedido pedido);
        Pedido ListarPedidoComItensFiltrados(int pedidoId, int itemPedidoId);
    }
}
