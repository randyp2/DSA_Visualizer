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
        private const double X_MIN = 1;
        private const double X_MAX = 1000;

        private Panel panel;
        private List<double> xValues;
        public AnalysisManager(Panel analysisPanel) {
            
            this.panel = analysisPanel;
            this.xValues = new List<double>();

            for (double i = X_MIN; i <= X_MAX; i++) xValues.Add(i);
            
            InitializeChart();
        
        }


        private void InitializeChart() {
            int chartWidth = 300;
            int chartHeight = 300;

            Chart chart = new Chart
            {   
                Size = new Size(chartWidth, chartHeight),
                Location = new Point(panel.Width/2 - (chartWidth/2), panel.Height/2 - (chartHeight/2)),
                BackColor = System.Drawing.Color.Black
            };

            customizeChartArea(chart);
            customizeSeries(chart);

            

            panel.Controls.Add(chart);


        }

        private void customizeChartArea(Chart chart) {
            ChartArea chartArea = new ChartArea("MainArea");

            

            

            // Remove gridlines
            chartArea.AxisX.MajorGrid.LineWidth = 0;
            chartArea.AxisY.MajorGrid.LineWidth = 0;

            // Change bg color
            chartArea.BackColor = System.Drawing.Color.Black;

            // Change line width and color
            chartArea.AxisX.LineColor = System.Drawing.Color.White;
            chartArea.AxisY.LineColor = System.Drawing.Color.White;

            chartArea.AxisX.LineWidth = 5;
            chartArea.AxisY.LineWidth = 5;

            // Customize X Axis
            chartArea.AxisX.LabelStyle.Enabled = true;
            chartArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea.AxisX.Title = "Time";
            chartArea.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);


            // Customize Y Axis
            chartArea.AxisY.LabelStyle.Enabled = true;
            chartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea.AxisY.Title = "Input Size";
            chartArea.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            chart.ChartAreas.Add(chartArea);
        }

        private void customizeSeries(Chart chart) {
            

            // Add series for runtimes
            addSeries(chart, "O(n)", Color.Blue, x => x); // Takes in lambda expression for function to use
            addSeries(chart, "O(n^2)", Color.Red, x => 0.005 * (x*x));
            addSeries(chart, "O(logn)", Color.Green, x => 30 * Math.Log(x));
            addSeries(chart, "O(nlogn)", Color.Yellow, x => 0.0025 * (x * x));

            //for (double i = X_MIN; i < X_MAX; i++) {
            //    x.Add(i);
            //    //y.Add(0.2 * quadraticFunc(i));
            //    y.Add(10 * logFunc(i));
            //}

            //series.Points.DataBindXY(x, y);

            ChartArea chartArea = chart.ChartAreas[0];
            chartArea.AxisX.Minimum = X_MIN;
            chartArea.AxisX.Maximum = X_MAX;
            chartArea.AxisX.Interval = 2;

            //chartArea.AxisY.IsLogarithmic = true;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1500;



            //chart.Series.Add(series);
            
        }

        /*
         * @brief ...
         * 
         * @details Run ...
         * 
         * @params 
         *  1) Chart - chart to plot on
         *  2) String - series name (O(n), O(nlogn), ...)
         *  3) Func<double, double> - Delegate that takes in a double and returns double 
         *     i.e) Func(T, TResult)
         */
        private void addSeries(Chart chart, string seriesName, Color color, Func<double, double> func) {

            // Initialize sample series/functions
            Series series = new Series(seriesName)
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = color
            };

            // Plot points
            List<double> yValues = new List<double>();
            foreach(double x in xValues) yValues.Add(func(x));   
            
            series.Points.DataBindXY(xValues, yValues);
            chart.Series.Add(series);
        }

        
        
        
        
    }
}
