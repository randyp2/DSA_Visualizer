using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using DSA_Visualizer.Sorting_Forms.SortingVisualizer.Sorting_Algorithms;

namespace DSA_Visualizer.Sorting_Forms.SortingVisualizer
{
    public class AnalysisManager
    {
        // Constants for chart
        private const int CHART_WIDTH = 300;
        private const int CHART_HEIGHT = 300;
        private const int OFFSET = 25;

        private const double X_MIN = 1;
        private const double X_MAX = 1000;

        private ChartArea mainChartArea;

        private Panel panel;
        private List<double> xValues;
        public AnalysisManager(Panel analysisPanel)
        {

            this.panel = analysisPanel;
            this.xValues = new List<double>();

            Control titleLbl = panel.Controls.Find("sortingTitleLbl", true).FirstOrDefault();
            titleLbl.Text = "Choose sorting algorithm";
            titleLbl.Location = new Point(this.panel.Width / 2 - (titleLbl.Width / 2), 2 * OFFSET + CHART_HEIGHT);
       

            for (double i = X_MIN; i <= X_MAX; i++) xValues.Add(i);

            
            InitializeChart();

        }

        public void setSortingTitle(string sortType) {
           

            // Get title label control
            Control titleLbl = panel.Controls.Find("sortingTitleLbl", true).FirstOrDefault();
            titleLbl.Text = sortType;

            titleLbl.Location = new Point(this.panel.Width / 2 - (titleLbl.Width / 2), 2 * OFFSET + CHART_HEIGHT);



        }

        public void setSortingDescription(string sortType)
        {
            Control descriptionLbl = panel.Controls.Find("descriptionOutputTxtBox", true).FirstOrDefault();
            string rtfDescription = "";
            switch (sortType)
            {
                case "Insertion Sort":
                    // Rtf string
                    // cf0 = black fore color
                    // cf1 = blue fore color
                    // cf2 = red fore color
                    // qc = text-align
                    
                    rtfDescription = @"{\rtf1\ansi{\colortbl ;\red0\green0\blue255; \red255\green0\blue0;}" +
                        @"\qc Insertion sort works by choosing a \""Key\"" and making space to insert that \""Key\"" " +
                        @"into it's correct position. We let each element (starting at index 1) be the key. In the worst case, " +
                        @"a rectangle's correct position is the very front of the list. This makes the algorithm take on Gauss' formula " +
                        @"making the runtime " +
                        @"\cf1O(n\super 2\nosupersub)\cf0 " + // Apply red color then reset to default color
                        @". No additional space is needed so space complexity is " +
                        @"\cf2O(1)\cf0 " +
                        @".";
                    
                    setRuntime("n^2");
                    setSpace("1");

                    break;

                case "Bubble Sort":

                    rtfDescription = @"{\rtf1\ansi{\colortbl ;\red0\green0\blue255; \red255\green0\blue0;}" +
                        @"\qc Bubble sort works by \""bubbling up\"" each element into it's correct position. It \n" +
                        @"compares adjacent elements in the list and performs a series of swaps until it is \n" +
                        @"in it's sorted position. We can optimize this algorithm by adding a swapped boolean flag, and adjust the \n" +
                        @"bound after each iteration. In the worst case a rectangle's sorted position is the very end of the list. \n" +
                        @"This makes the algorithm perform {\b n-1} comparisons in the first pass, {\b n-2} comparisons in the second pass, " +
                        @"and so on, resulting in a total of {\b n(n-1)/2} comparisons. The resulting runtime is " +
                        @"\cf1O(n\super 2\nosupersub)\cf0 " +
                        @". No additional space is needed so space complexity is " +
                        @"\cf2O(1)\cf0.";

                    setRuntime("n^2");
                    setSpace("1");

                    break;

                case "Selection Sort":

                    rtfDescription = @"{\rtf1\ansi{\colortbl ;\red0\green0\blue255; \red255\green0\blue0;}" +
                        @"\qc Selection sort works by finding the minimum element in the list and swapping it with the leftmost " +
                        @"unsorted element. We do this for each element in the list. In the worst case the minimum value is always " +
                        @"towards the end of the list, causing us to traverse the entire list for each leftmost unsorted element. " +
                        @"This algorithm peforms {\b n-1} comparisions in the first pass, {\b n-2} ocmparisons in the second pass, " +
                        @"and so on, resulting in a total of {\b n(n-1)/2} comparisons. The resulting runtime is " +
                        @"\cf1O(n\super 2\nosupersub)\cf0 " +
                        @". No additional space is needed so space complexity is " +
                        @"\cf2O(1)\cf0.";
                    setRuntime("n^2");
                    setSpace("1");

                    break;

                case "Quick Sort":

                    rtfDescription = @"{\rtf1\ansi{\colortbl ;\red0\green0\blue255; \red255\green0\blue0;}" +
                        @"\qc QuickSort is a divide and conquer algorithm that utilizes a left pointer, right pointer, and a pivot. " +
                        @"It then partitions the array so that it inserts the pivot in it's sorted position. Elements left of the " +
                        @"pivot will be lesser and elements right of the pivot is greater. We then recursively sort the left subarray " +
                        @"and right subarray. In the worst case the pivot is the minimum or maximum leading to unbalanced partitions. " +
                        @"This would cause {\b n-1} levels of recursive calls while the partitioning step takes {\b O(n)} time. " +
                        @"Therefore, in the worst case the runtime is " +
                        @"\cf1O(n\super 2\nosupersub)\cf0 " +
                        @"However, the worst case is highly unlikely to occur so on average therew ould be {\b logn} levels of recursive " +
                        @"calls. This makes the run time " +
                        @"\cf1O(nlogn)\cf0. " +
                        @"Because there are {\b logn} levels of recursive calls the space complexity is " +
                        @"\cf2O(logn)\cf0 in the average case";
                    setRuntime("nlogn");
                    setSpace("logn");

                    break;

                case "Merge Sort":

                    rtfDescription = @"{\rtf1\ansi{\colortbl ;\red0\green0\blue255; \red255\green0\blue0;}" +
                        @"\qc MergeSort is a divide and conquer algorithm that separates the array into two subarrays until the length " +
                        @"of each subarray is 1. It then recursively backtracks to merge each subarray into a sorted array. It does this " +
                        @"until the entire array is fully sorted. The merge operation itself takes {\b O(n)} time. MergeSort divides " + 
                        @"the array in half until it's length is 1 or 0 so the division is logarithmic. The resulting runtime is " +
                        @"\cf1O(nlogn)\cf0. " +
                        @"Merge sort utilizes two temporary arrays to merge the two subarrays. This makes the space complextiy " +
                        @"\cf2O(n)\cf0.";
                    setRuntime("nlogn");
                    setSpace("n");

                    break;
                


            }

            // Add rtf description text and adjust location
            if (descriptionLbl is RichTextBox richTextBox) richTextBox.Rtf = rtfDescription;
            descriptionLbl.Location = new Point(this.panel.Width / 2 - (descriptionLbl.Width / 2), 4 * OFFSET + CHART_HEIGHT);
        }

        public void setRuntime(string runtime) {
            
            Control runtimeTxtBox = panel.Controls.Find("runtimeOutputTxtBox", true).FirstOrDefault();

            if (runtime == "n^2")
            {
                // Rtf text for superscript text
                string rtfRuntime = @"{\rtf1\ansi O(n\super 2\nosupersub )}";
                if (runtimeTxtBox is RichTextBox richTextBox) richTextBox.Rtf = rtfRuntime;

            }
            else {
                runtimeTxtBox.Text = "O(" + runtime + ")";
            }

            // Highlight the series corresponding to the runtime
            
            // Get chart
            Chart chart = panel.Controls.OfType<Chart>().FirstOrDefault();

            foreach (var series in chart.Series) {
                Console.WriteLine("Runtime: " + runtime + " Series name: " + series.Name);
                if (series.Name != runtime)
                {
                    Console.WriteLine("This is running for " + series.Name + "!!");
                    series.Color = Color.FromArgb(15, series.Color);
                }
                else { 
                    series.Color = Color.FromArgb(255, series.Color);
                }
            }
            
        }

        public void setSpace(string space) {

            Control spaceTxtBox = panel.Controls.Find("spaceOutputTxtBox", true).FirstOrDefault();

            spaceTxtBox.Text = "O(" + space + ")";

            
        }

        public void InitializeInformation(string title) {
           
            setSortingTitle(title);
            setSortingDescription(title);
            
        }

        private void InitializeChart() {
            

            Console.WriteLine("Panel width: " + this.panel.Width);
            Console.WriteLine("Panel height: " + this.panel.Height);

            Chart chart = new Chart
            {   
                Size = new Size(CHART_WIDTH, CHART_HEIGHT),
                Location = new Point(OFFSET, OFFSET),
                BackColor = System.Drawing.Color.Black
            };

            customizeChartArea(chart);
            customizeSeries(chart);

            panel.Controls.Add(chart);


        }

        private void customizeChartArea(Chart chart) {
            mainChartArea = new ChartArea("MainArea");

            // Remove gridlines
            mainChartArea.AxisX.MajorGrid.LineWidth = 0;
            mainChartArea.AxisY.MajorGrid.LineWidth = 0;

            // Change bg color
            mainChartArea.BackColor = System.Drawing.Color.Black;

            // Change line width and color
            mainChartArea.AxisX.LineColor = System.Drawing.Color.White;
            mainChartArea.AxisY.LineColor = System.Drawing.Color.White;

            mainChartArea.AxisX.LineWidth = 5;
            mainChartArea.AxisY.LineWidth = 5;

            // Customize X Axis
            mainChartArea.AxisX.LabelStyle.Enabled = true;
            mainChartArea.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            mainChartArea.AxisX.Title = "Time";
            mainChartArea.AxisX.TitleForeColor = System.Drawing.Color.White;
            mainChartArea.AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);


            // Customize Y Axis
            mainChartArea.AxisY.LabelStyle.Enabled = true;
            mainChartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            mainChartArea.AxisY.Title = "Input Size";
            mainChartArea.AxisY.TitleForeColor = System.Drawing.Color.White;
            mainChartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            chart.ChartAreas.Add(mainChartArea);
        }

        private void customizeSeries(Chart chart) {


            // Add series for runtimes
            addSeries(chart, "n", Color.Blue, x => x); // Takes in lambda expression for function to use
            addSeries(chart, "n^2", Color.Red, x => 0.005 * (x * x));
            addSeries(chart, "logn", Color.Green, x => 30 * Math.Log(x));
            addSeries(chart, "nlogn", Color.Yellow, x => 0.0025 * (x * x));
            addSeries(chart, "2^n", Color.Orange, x => 0.03 * (x*x));
            

            // Set x Axis range and interval
            ChartArea chartArea = chart.ChartAreas[0];
            chartArea.AxisX.Minimum = X_MIN;
            chartArea.AxisX.Maximum = X_MAX;
            chartArea.AxisX.Interval = 2;

            //chartArea.AxisY.IsLogarithmic = true;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1500;
            
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

           
            foreach (double x in xValues) yValues.Add(func(x));


            series.Points.DataBindXY(xValues, yValues);           
           
            chart.Series.Add(series);
        }

        
        
        
        
    }
}
