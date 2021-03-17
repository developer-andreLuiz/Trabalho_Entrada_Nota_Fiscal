using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NFMercadoTitio.Formulario;

namespace NFMercadoTitio
{
    public partial class FrmMain : Form
    {
        int x, y;
        Point Point = new Point();
        public FrmMain()
        {
            InitializeComponent();
        }

        #region Eventos Form
        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelForm.Controls.Add(ChildForm);
            panelForm.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        #endregion
      
        #region Btns
        private void btnPaginaInicial_Click(object sender, EventArgs e)
        {
            try
            {
                pInterface.Location = new Point(0, btnPaginaInicial.Location.Y);
                openChildForm(new FrmPaginaInicial(""));
            }
            catch { }
        }
        private void btnNotas_Click(object sender, EventArgs e)
        {
            try
            {
                pInterface.Location = new Point(0, btnNotas.Location.Y);
                openChildForm(new FrmNotasXml());
            }
            catch { }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                pInterface.Location = new Point(0, btnDownload.Location.Y);
                openChildForm(new FrmDownload());
            }
            catch { }
           
        }
        private void BtnNFPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                pInterface.Location = new Point(0, BtnNFPesquisa.Location.Y);
                openChildForm(new FrmNFPesquisa());
            }
            catch { }
            
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    Application.DoEvents();
                }
            }
            catch { }
            
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                openChildForm(new FrmPaginaInicial(""));
            }
            catch { }
           
        }
        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        #endregion


    }
}
