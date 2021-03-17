namespace NFMercadoTitio
{
    partial class FrmPaginaInicial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtNumeroNotaFiscal = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApagarNota = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.GridColor = System.Drawing.Color.Black;
            this.dataGridView.Location = new System.Drawing.Point(15, 125);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 35;
            this.dataGridView.Size = new System.Drawing.Size(670, 416);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentDoubleClick);
            // 
            // txtNumeroNotaFiscal
            // 
            this.txtNumeroNotaFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroNotaFiscal.Location = new System.Drawing.Point(15, 58);
            this.txtNumeroNotaFiscal.Name = "txtNumeroNotaFiscal";
            this.txtNumeroNotaFiscal.Size = new System.Drawing.Size(670, 29);
            this.txtNumeroNotaFiscal.TabIndex = 24;
            this.txtNumeroNotaFiscal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroNotaFiscal_KeyPress);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.panel10.Controls.Add(this.label6);
            this.panel10.Location = new System.Drawing.Point(15, 12);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(277, 31);
            this.panel10.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(234, 27);
            this.label6.TabIndex = 1;
            this.label6.Text = "Número da Nota Fiscal";
            // 
            // btnApagarNota
            // 
            this.btnApagarNota.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.btnApagarNota.FlatAppearance.BorderSize = 0;
            this.btnApagarNota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApagarNota.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarNota.ForeColor = System.Drawing.Color.White;
            this.btnApagarNota.Image = global::NFMercadoTitio.Properties.Resources.close;
            this.btnApagarNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApagarNota.Location = new System.Drawing.Point(485, 560);
            this.btnApagarNota.Name = "btnApagarNota";
            this.btnApagarNota.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnApagarNota.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnApagarNota.Size = new System.Drawing.Size(200, 46);
            this.btnApagarNota.TabIndex = 26;
            this.btnApagarNota.Text = "Apagar Nota";
            this.btnApagarNota.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnApagarNota.UseVisualStyleBackColor = false;
            this.btnApagarNota.Click += new System.EventHandler(this.btnApagarNota_Click);
            // 
            // FrmPaginaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(697, 632);
            this.Controls.Add(this.btnApagarNota);
            this.Controls.Add(this.txtNumeroNotaFiscal);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPaginaInicial";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmPaginaInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtNumeroNotaFiscal;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnApagarNota;
    }
}