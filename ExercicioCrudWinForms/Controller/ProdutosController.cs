using ExercicioCrudWinForms.Controller.Interfaces;
using ExercicioCrudWinForms.Model;
using ExercicioCrudWinForms.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCrudWinForms.Controller
{
    public class ProdutosController:IProdutosController
    {
        private IProdutosDAO produtosDAO;
        public ProdutosController()
        {
            produtosDAO = new ProdutosDAO();
        }
        public void Inserir(string descricao)
        {
            produtosDAO.InserirRegistro(descricao);
        }
        public List<Produtos> Busca()
        {
            return produtosDAO.BuscaProdutos();
        }
        public void DeletaRegistro(int id)
        {
            produtosDAO.DeletaRegistro(id);
        }
        public void Atualizar(int id,string descricao)
        {
            produtosDAO.AtualizaRegistro(id, descricao);
        }
    }
}
