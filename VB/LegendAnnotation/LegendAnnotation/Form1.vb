Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

Namespace LegendAnnotation
    Partial Public Class Form1
        Inherits Form
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            InitChartData()
            InitAnnotation()
        End Sub

        Private Sub InitAnnotation()
            Dim legendBitmap As New Bitmap(100, 50)
            Using fakeChart As ChartControl = CType(chartControl1.Clone(), ChartControl)
                fakeChart.Legend.Visible = True
                fakeChart.BorderOptions.Visible = False
                fakeChart.Padding.All = 0

                fakeChart.Legend.Border.Visible = False
                fakeChart.Legend.Margins.All = 0
                fakeChart.Legend.Padding.All = 0
                fakeChart.Legend.BackColor = Color.Transparent
                fakeChart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.LeftOutside
                fakeChart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside

                CType(fakeChart.Diagram, XYDiagram).DefaultPane.Visible = False


                fakeChart.DrawToBitmap(legendBitmap, New Rectangle(Point.Empty, legendBitmap.Size))

            End Using
            chartControl1.Annotations.Clear()
            chartControl1.Annotations.AddImageAnnotation("Legend", legendBitmap)
            chartControl1.Annotations(0).RuntimeMoving = True
            chartControl1.Annotations(0).Border.Thickness = 2
            chartControl1.Annotations(0).Border.Color = Color.Gray
            chartControl1.Annotations(0).ConnectorStyle = AnnotationConnectorStyle.None
        End Sub


        Private Sub InitChartData()
            Dim dataTable1 As DataTable = CreateChartData(20)


            Dim series As New Series("First Series", ViewType.Line)
            chartControl1.Series.Add(series)

            ' Generate a data table and bind the series to it.
            series.DataSource = dataTable1

            ' Specify data members to bind the series.
            series.ArgumentScaleType = ScaleType.Numerical
            series.ArgumentDataMember = "Argument"
            series.ValueScaleType = ScaleType.Numerical
            series.ValueDataMembers.AddRange(New String() {"Value"})


            Dim series2 As New Series("Second Series", ViewType.Line)
            chartControl1.Series.Add(series2)

            Dim dataTable2 As DataTable = CreateChartData(20)

            ' Generate a data table and bind the series to it.
            series2.DataSource = dataTable2

            ' Specify data members to bind the series.
            series2.ArgumentScaleType = ScaleType.Numerical
            series2.ArgumentDataMember = "Argument"

            series2.ValueScaleType = ScaleType.Numerical
            series2.ValueDataMembers.AddRange(New String() {"Value"})

            chartControl1.Legend.Visible = False
        End Sub


        Private Function CreateChartData(ByVal rowCount As Integer) As DataTable
            ' Create an empty table.
            Dim table As New DataTable("Table1")

            ' Add two columns to the table.
            table.Columns.Add("Argument", GetType(Int32))
            table.Columns.Add("Value", GetType(Int32))

            ' Add data rows to the table.
            Dim rnd As New Random(DateTime.Now.Millisecond)
            Dim row As DataRow = Nothing
            For i As Integer = 0 To rowCount - 1
                row = table.NewRow()
                row("Argument") = i
                row("Value") = rnd.Next(100)
                table.Rows.Add(row)
            Next i

            Return table
        End Function
    End Class
End Namespace
