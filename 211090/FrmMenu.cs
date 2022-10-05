using System;
using System.Windows.Forms;
using _211090.Views;


namespace _211090
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        private void cidadesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            FrmCidades form = new FrmCidades();
            form.Show();

        }
    }
}
