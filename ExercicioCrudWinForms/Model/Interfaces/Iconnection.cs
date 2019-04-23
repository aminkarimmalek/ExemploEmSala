using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioCrudWinForms.Model.Interfaces
{
    public interface Iconnection
    {
        SqlConnection Conexao();
    }
}
