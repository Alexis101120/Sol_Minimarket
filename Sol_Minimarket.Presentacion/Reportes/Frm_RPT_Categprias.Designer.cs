namespace Sol_Minimarket.Presentacion.Reportes
{
    partial class Frm_RPT_Categprias
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataSet_MiniMaket = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMaket();
            this.uSPListadocaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_Listado_caTableAdapter = new Sol_Minimarket.Presentacion.Reportes.DataSet_MiniMaketTableAdapters.USP_Listado_caTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMaket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadocaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPListadocaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sol_Minimarket.Presentacion.Reportes.Rpt_Categorias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            // 
            // dataSet_MiniMaket
            // 
            this.dataSet_MiniMaket.DataSetName = "DataSet_MiniMaket";
            this.dataSet_MiniMaket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPListadocaBindingSource
            // 
            this.uSPListadocaBindingSource.DataMember = "USP_Listado_ca";
            this.uSPListadocaBindingSource.DataSource = this.dataSet_MiniMaket;
            // 
            // uSP_Listado_caTableAdapter
            // 
            this.uSP_Listado_caTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_RPT_Categprias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Frm_RPT_Categprias";
            this.Text = "Reporte de categorias";
            this.Load += new System.EventHandler(this.Frm_RPT_Categprias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_MiniMaket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPListadocaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource uSPListadocaBindingSource;
        private DataSet_MiniMaket dataSet_MiniMaket;
        private DataSet_MiniMaketTableAdapters.USP_Listado_caTableAdapter uSP_Listado_caTableAdapter;
    }
}