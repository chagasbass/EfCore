using EFCORE.Exemplos.Contextos;
using EFCORE.Exemplos.Contratos;
using EFCORE.Exemplos.Entidades;
using System;

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
            Contexto.Update(cliente);
            Contexto.SaveChanges();

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

        public void ListarClientes()
        {
            throw new NotImplementedException();
        }

        public void ListarClientes(int id)
        {
            throw new NotImplementedException();
        }
    }
}
