using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace LegendAnnotation {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e) {
            InitChartData();
            InitAnnotation();
        }

        private void InitAnnotation () {
            Bitmap legendBitmap = new Bitmap(100, 50);
            using (ChartControl fakeChart = (ChartControl)chartControl1.Clone()) {
                fakeChart.Legend.Visible = true;
                fakeChart.BorderOptions.Visible = false;
                fakeChart.Padding.All = 0;

                fakeChart.Legend.Border.Visible = false;
                fakeChart.Legend.Margins.All = 0;
                fakeChart.Legend.Padding.All = 0;
                fakeChart.Legend.BackColor = Color.Transparent;
                fakeChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.LeftOutside;
                fakeChart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;

                ((XYDiagram)fakeChart.Diagram).DefaultPane.Visible = false;


                fakeChart.DrawToBitmap(legendBitmap, new Rectangle(Point.Empty, legendBitmap.Size));

            }
            chartControl1.Annotations.Clear();
            chartControl1.Annotations.AddImageAnnotation("Legend", legendBitmap);
            chartControl1.Annotations[0].RuntimeMoving = true;
            chartControl1.Annotations[0].Border.Thickness = 2;
            chartControl1.Annotations[0].Border.Color = Color.Gray;
            chartControl1.Annotations[0].ConnectorStyle = AnnotationConnectorStyle.None;
        }

        #region Providing Data
        private void InitChartData () {
            DataTable dataTable1 = CreateChartData(20);

            Series series = new Series("First Series", ViewType.Line);
            chartControl1.Series.Add(series);

            // Generate a data table and bind the series to it.
            series.DataSource = dataTable1;

            // Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Numerical;
            series.ArgumentDataMember = "Argument";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "Value" });

            Series series2 = new Series("Second Series", ViewType.Line);
            chartControl1.Series.Add(series2);

            DataTable dataTable2 = CreateChartData(20);

            // Generate a data table and bind the series to it.
            series2.DataSource = dataTable2;

            // Specify data members to bind the series.
            series2.ArgumentScaleType = ScaleType.Numerical;
            series2.ArgumentDataMember = "Argument";

            series2.ValueScaleType = ScaleType.Numerical;
            series2.ValueDataMembers.AddRange(new string[] { "Value" });

            chartControl1.Legend.Visible = false;
        }


        private DataTable CreateChartData (int rowCount) {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add two columns to the table.
            table.Columns.Add("Argument", typeof(Int32));
            table.Columns.Add("Value", typeof(Int32));

            // Add data rows to the table.
            Random rnd = new Random(DateTime.Now.Millisecond);
            DataRow row = null;
            for (int i = 0; i < rowCount; i++) {
                row = table.NewRow();
                row["Argument"] = i;
                row["Value"] = rnd.Next(100);
                table.Rows.Add(row);
            }

            return table;
        }
        #endregion


    }
}
