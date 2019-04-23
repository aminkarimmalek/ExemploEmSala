using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCrudWinForms.Model.Interfaces
{
    public interface IProdutosDAO
    {
        void InserirRegistro(string descricao);
        List<Produtos> BuscaProdutos();
        void DeletaRegistro( int id);
        void AtualizaRegistro(int id, string descricao);
    }
}
