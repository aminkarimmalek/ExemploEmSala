using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCrudWinForms.Model
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Insercao { get; set; }
        public DateTime Data_Remocao { get; set; }
    }
}
