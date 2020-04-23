using BL.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.RegistroNotas
{
    public partial class FormReporteTransaccion : Form
    {
        public FormReporteTransaccion()
        {
            InitializeComponent();

            var _transaccionBL = new TransaccionBL();
            var _materiasBL = new MateriasBL();
            var _seccionesBL = new SeccionesBL();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = _transaccionBL.ObtenerTransacciones();

            var bindingSource2 = new BindingSource();
            bindingSource2.DataSource = _materiasBL.ObtenerMaterias();

            var bindingSource3 = new BindingSource();
            bindingSource3.DataSource = _seccionesBL.ObtenerSecciones();

            var reporte = new ReporteTransaccion();
            reporte.Database.Tables["Transaccion"].SetDataSource(bindingSource);
            reporte.Database.Tables["Materia"].SetDataSource(bindingSource2);
            reporte.Database.Tables["Seccion"].SetDataSource(bindingSource3);

            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
