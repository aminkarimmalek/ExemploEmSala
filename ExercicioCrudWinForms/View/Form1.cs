using ExercicioCrudWinForms.Controller;
using ExercicioCrudWinForms.Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicioCrudWinForms
{
    public partial class Form1 : Form
    {
        private IProdutosController produtos;
        private int IdGriad{get;set;}
        public Form1()
        {
            InitializeComponent();
            IdGriad = 0;
            produtos = new ProdutosController();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {
                produtos.Inserir(txtProduto.Text);
                LimpaCampos();
            }
            else
                MessageBox.Show("Há campos Vazios");
        }
        private bool ValidaCampos()
        {
            if (txtProduto.Text == "")
                return false;
            return true;
        }
        private void LimpaCampos()
        {
            txtProduto.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtProdutos.DataSource = produtos.Busca();
            for (int i=0; i < dtProdutos.Columns.Count; i++)
            {
                dtProdutos.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dtProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdGriad = Convert.ToInt32(dtProdutos.Rows[e.RowIndex].Cells[0].Value);
            txtProduto.Text = dtProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnRemove.Enabled = true;
            btnAlter.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            btnRemove.Enabled = false;
            btnAlter.Enabled = false;
            var confirm = MessageBox.Show($"Vocé deseja remover o id {IdGriad}", "deseja remove ?", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                produtos.DeletaRegistro(IdGriad);
                dtProdutos.DataSource = produtos.Busca();
            }
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            btnAlter.Enabled = false;
            var confirm = MessageBox.Show($"Vocé deseja alterar o registro numero{IdGriad}", "warning", MessageBoxButtons.YesNo);
            if (confirm== DialogResult.Yes)
            {
                produtos.Atualizar(IdGriad, txtProduto.Text);
                dtProdutos.DataSource = produtos.Busca();
                txtProduto.Text = "";
            }
        }
    }
}
