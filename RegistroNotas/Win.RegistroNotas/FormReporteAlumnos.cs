﻿using BL.Registro;
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
    public partial class FormReporteAlumnos : Form
    {
        public FormReporteAlumnos()
        {
            InitializeComponent();

            var _alumnosBL = new AlumnosBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _alumnosBL.ObtenerAlumnos();

            var reporte = new ReporteAlumnos();
            reporte.SetDataSource(bindingSource);
            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
