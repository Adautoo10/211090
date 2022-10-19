using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using _211090.Models;

namespace _211090.Views
{
    public partial class FrmCidades : Form
    {
        Cidade c;
        public FrmCidades()
        {
            InitializeComponent();
        }

        private void cidadesToolStripMenuItem_Click(object sender , EventArgs e)
        {
            FrmCidades form = new FrmCidades();
            form.Show();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            txtPesquisa.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade();
            {
                txtNome.Text = pesquisa;
            };
            dgvCidades.DataSource = c.Consultar();
        }

      

        private void dgvCidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["uf"].Value.ToString();

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                uf = txtUF.Text
            };

            c.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a cidade?", "Exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIncluir_Click_1(object sender, EventArgs e)
        {
            {
                if (txtNome.Text == String.Empty) return;

                c = new Cidade()
                {
                    nome = txtNome.Text,
                    uf = txtUF.Text
                };
                c.Incluir();

                limpaControles();
                carregarGrid("");
            }


        }

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }
    }
}
