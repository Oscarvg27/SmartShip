using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using Microsoft.Data.SqlClient;
using Modelos;
using System.IO;
using OfficeOpenXml.Drawing.Chart;

namespace Controladores
{
    public class GenerarExcel
    {
        public void generarExcel() 
        {
            SqlCommand comand;
            string unidades = "select placa,marca,cant_carga,no_remolques from unidades";

            comand = new SqlCommand(unidades,Singleton.Instance.conectarBase());
            SqlDataReader reader = comand.ExecuteReader();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Unidades");

                

                // Escribir los encabezados de columna
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                }

                // Escribir los datos en las celdas
                int row = 2;
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        worksheet.Cells[row, i + 1].Value = reader[i];
                    }
                    row++;
                }

                // Escribir los encabezados de columna personalizados en negrita
                using (ExcelRange range = worksheet.Cells[1, 1, 1, reader.FieldCount])
                {
                    range.Style.Font.Bold = true;
                }

                // Escribir los encabezados de columna personalizados
                worksheet.Cells[1, 1].Value = "PLACA";
                worksheet.Cells[1, 2].Value = "MARCA";
                worksheet.Cells[1, 3].Value = "CAPACIDAD";
                worksheet.Cells[1, 4].Value = "#Remolque";

                // Ajustar automáticamente el ancho de cada columna
                worksheet.Cells.AutoFitColumns();

                // Agregar un gráfico de pastel
                ExcelChart chart = worksheet.Drawings.AddChart("PieChart", OfficeOpenXml.Drawing.Chart.eChartType.Pie3D) as ExcelChart;
                chart.Title.Text = "Distribución de Marcas";

                

                // Obtener el rango de datos para la gráfica de pastel (columna "MARCA")
                int rowCount = row - 1;
                ExcelRange dataRange = worksheet.Cells[2, 4, rowCount + 1, 4];
                ExcelRange labelRange = worksheet.Cells[2, 2, rowCount + 1, 2];

                // Agregar los datos y etiquetas a la gráfica
                chart.Series.Add(dataRange, labelRange);

                // Guardar el archivo de Excel
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "archivo.xlsx");
                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}
