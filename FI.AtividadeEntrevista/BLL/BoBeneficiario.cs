using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        /// <summary>
        /// Inclui um novo beneficiario
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Incluir(beneficiario);
        }

        /// <summary>
        /// Altera um beneficiario
        /// </summary>
        /// <param name="cliente">Objeto de beneficiario</param>
        public long Alterar(DML.Beneficiario beneficiario)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Alterar(beneficiario);
        }

        /// <summary>
        /// Consulta o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Consultar(id);
        }

        /// <summary>
        /// Excluir o beneficiario pelo id
        /// </summary>
        /// <param name="id">id do beneficiario</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            ben.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Listar();
        }

        public DML.Beneficiario Consultar(long id)
        {
            DAL.DaoBeneficiario ben = new DAL.DaoBeneficiario();
            return ben.Consultar(id);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            DAL.DaoBeneficiario cli = new DAL.DaoBeneficiario();
            return cli.VerificarExistencia(CPF);
        }
    }
}
