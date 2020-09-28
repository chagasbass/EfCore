using EFCORE.Exemplos.Contextos;
using EFCORE.Exemplos.Contratos;
using EFCORE.Exemplos.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCORE.Exemplos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ContextoEfCore Contexto;

        public ClienteRepositorio(ContextoEfCore contexto)
        {
            Contexto = contexto;
        }

        public void AtualizarCliente(Cliente cliente)
        {
            #region atualiza todas as propriedades
            Contexto.Update(cliente);
            Contexto.SaveChanges();
            #endregion

            #region Atualizando e retornando os campos atualizados

            var _cliente = new
            {
                Nome ="Teste",
                Telefone= "33445566"
            };

            Contexto.Entry(cliente).CurrentValues.SetValues(_cliente);
            Contexto.SaveChanges();
            #endregion
            //Caso so tenha o saveChanges(), atualiza somente as propriedades que foram atualizadas
        }

        public void ExcluirClientes(Cliente cliente)
        {
            Contexto.Remove(cliente);
            Contexto.SaveChanges();
        }

        public void InserirCliente(Cliente cliente)
        {
            Contexto.Add(cliente);
            Contexto.SaveChanges();
        }

        public void InserirMultiplosClientes(IEnumerable<Cliente> clientes)
        {
            Contexto.AddRange(clientes);
            Contexto.SaveChanges();
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return Contexto.Clientes.AsNoTracking().ToList();
        }

        public Cliente ListarClientes(int id)
        {
            return Contexto.Clientes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
