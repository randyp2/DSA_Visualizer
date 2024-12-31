using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    public class AnalysisManager
    {

        private Panel panel;
        public AnalysisManager(Panel analysisPanel) {
            
            this.panel = analysisPanel;
            InitializeChart();
        
        }


        private void InitializeChart() {
            int chartWidth = 500;
            int chartHeight = 500;

            Chart chart = new Chart
            {   
                Size = new Size(chartWidth, chartHeight),
                Location = new Point(panel.Width/2 - (chartWidth/2), panel.Height/2 - (chartHeight/2)),
                BackColor = System.Drawing.Color.Black
            };

            ChartArea chartArea = new ChartArea("MainArea");

            // Remove gridlines
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;

            // Change bg color
            chartArea.BackColor = System.Drawing.Color.Black;

            // Change line width and color
            chartArea.AxisX.LineColor = System.Drawing.Color.White;
            chartArea.AxisY.LineColor = System.Drawing.Color.White;

            chartArea.AxisX.LineWidth = 3;
            chartArea.AxisY.LineWidth = 3;

            // Change font colors
            chartArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;

            chart.ChartAreas.Add(chartArea);

            // Initialize sample series
            Series series = new Series("SampleData")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = System.Drawing.Color.Blue
            };

            series.Points.AddXY(0,0);
            series.Points.AddXY(1, 1);
            series.Points.AddXY(3, 9);
            series.Points.AddXY(4, 2);

            chart.Series.Add(series);

            panel.Controls.Add(chart);


        }
    }
}
