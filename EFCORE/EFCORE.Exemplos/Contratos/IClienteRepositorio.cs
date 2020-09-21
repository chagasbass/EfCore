using EFCORE.Exemplos.Entidades;
using System.Collections.Generic;

namespace EFCORE.Exemplos.Contratos
{
    public interface IClienteRepositorio
    {
        void InserirCliente(Cliente cliente);
        void InserirMultiplosClientes(IEnumerable<Cliente> clientes);
        void AtualizarCliente(Cliente cliente);
        void ExcluirClientes(Cliente cliente);
        void ListarClientes();
        void ListarClientes(int id);

    }
}
