using EFCORE.Exemplos.Contextos;
using EFCORE.Exemplos.Repositorios;
using System;
using System.Linq;

namespace EFCORE.Exemplos
{
    class Program
    {
        static void Main(string[] args)
        {
            var contexto = new ContextoEfCore();
            var pedidoRepo = new PedidoRepositorio(contexto);

            var pedido = pedidoRepo.ListarPedidoComItensFiltrados(1, 3);

            Console.WriteLine("Resultado");
            Console.WriteLine($"pedido: {pedido.Id}");
            Console.WriteLine($"items: {pedido.Itens.Count}");
            Console.WriteLine($"items: {pedido.Itens.FirstOrDefault().Id} - {pedido.Itens.FirstOrDefault().Quantidade}");

            Console.ReadKey();
        }
    }
}
