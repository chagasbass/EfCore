using EFCORE.Exemplos.Contextos;
using EFCORE.Exemplos.Contratos;
using EFCORE.Exemplos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;


namespace EFCORE.Exemplos.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly ContextoEfCore Contexto;

        public PedidoRepositorio(ContextoEfCore contexto)
        {
            Contexto = contexto;
        }

        public void InserirPedido(Pedido pedido)
        {
            Contexto.Add(pedido);
            Contexto.SaveChanges();
        }

        public Pedido ListarPedidoComItensFiltrados(int pedidoId, int itemPedidoId)
        {
            #region Carregamento Adiantado
            //var pedido = Contexto.Pedidos.
            //    Include(x => x.Itens)
            //    .FirstOrDefault(x=> x.Id == pedidoId);
            #endregion

            #region Linq

            var pedido = Contexto.Pedidos.Where(x => x.Id == pedidoId)
                .Select(
                x => new Pedido()
                {
                    Id = x.Id,
                    ClienteId = x.ClienteId,
                    FinalizadoEm = x.FinalizadoEm,
                    IniciadoEm = x.IniciadoEm,
                    Observacao = x.Observacao,
                    StatusPedido = x.StatusPedido,
                    TipoFrete = x.TipoFrete,
                    Itens = x.Itens.Where(y => y.Id == itemPedidoId).ToList()
                }).FirstOrDefault();

            #endregion

            //#region Carregamento explícito
            //var pedido = Contexto.Pedidos
            //    .Single(p => p.Id == pedidoId);

            //var item = Contexto.Entry(pedido)
            //    .Collection(p => p.Itens)
            //    .Query()
            //    .Where(x => x.Id == itemPedidoId)
            //    .ToList();

            //pedido.Itens = item;

            //#endregion

            #region Carregamento Preguiçoso


            #endregion
            //var items = new List<PedidoItem>();

            //foreach (var item in pedido)
            //{
            //   items.Add(Contexto.PedidoItems.Find(itemPedidoId));
            //}

            //pedido.Itens = items;

            return pedido;
        }
    }
}
