using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            BLL.BoBeneficiario ben = new BLL.BoBeneficiario();
            var id = cli.Incluir(cliente);
            foreach(var beneficiario in cliente.Beneficiarios)
            {
                beneficiario.IdCliente = id;
                ben.Incluir(beneficiario);
            }
            return id;
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Alterar(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            var clienteAntigo = this.Consultar(cliente.Id);
            cli.Alterar(cliente);
            BLL.BoBeneficiario ben = new BLL.BoBeneficiario();
            //adicionar os que não tem, editar os que já tem
            foreach (var beneficiario in cliente.Beneficiarios)
            {
                beneficiario.IdCliente = cliente.Id;
                if(beneficiario.Id == 0)
                {
                    ben.Incluir(beneficiario);
                }
                else
                {
                    ben.Alterar(beneficiario);
                }
            }
            // remover os que nao tem mais
            foreach(var benAntigo in clienteAntigo.Beneficiarios)
            {
                if(!cliente.Beneficiarios.Any(b => b.Id == benAntigo.Id))
                {
                    ben.Excluir(benAntigo.Id);
                }
            }
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public DML.Cliente Consultar(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            BLL.BoBeneficiario ben = new BLL.BoBeneficiario();
            var cliente = cli.Consultar(id);
            cliente.Beneficiarios = ben.ListarPorCliente(cliente.Id);
            
            return cliente;
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            BLL.BoBeneficiario ben = new BLL.BoBeneficiario();
            var cliente = this.Consultar(id);
            foreach (var beneficiario in cliente.Beneficiarios)
            {
                ben.Excluir(beneficiario.Id);
            }
            cli.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            BLL.BoBeneficiario ben = new BLL.BoBeneficiario();

            var clientes = cli.Listar();
            foreach (var cliente in clientes)
            {
                cliente.Beneficiarios = ben.ListarPorCliente(cliente.Id);
            }
            return clientes;

        }
        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            BLL.BoBeneficiario ben = new BLL.BoBeneficiario();
            var clientes = cli.Pesquisa(iniciarEm,  quantidade, campoOrdenacao, crescente, out qtd);
            foreach(var cliente in clientes)
            {
                cliente.Beneficiarios = ben.ListarPorCliente(cliente.Id);
            }

            return clientes;
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.VerificarExistencia(CPF);
        }
    }
}
