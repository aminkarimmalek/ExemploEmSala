using ExercicioCrudWinForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCrudWinForms.Controller.Interfaces
{
    public interface IProdutosController
    {
        void Inserir(string descricao);
        List<Produtos> Busca();
        void DeletaRegistro(int id);
        void Atualizar(int id, string descricao);
    }

}
