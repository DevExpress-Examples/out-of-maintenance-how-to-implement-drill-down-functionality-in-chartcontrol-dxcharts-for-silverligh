using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Charts;

namespace DrillDownSL
{
    public partial class MainPage : UserControl
    {
        List<Resources> resources = new List<Resources>();
        List<WorkActivity> activity = new List<WorkActivity>();

        bool ShowDetails = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            BindChartData();
        }

        private void BindChartData()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            resources.Clear();

            resources.Add(new DrillDownSL.Resources() { ResourceName = "Louis Marilyn", ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20) });
            resources.Add(new DrillDownSL.Resources() { ResourceName = "Jem Carlisa", ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20) });
            resources.Add(new DrillDownSL.Resources() { ResourceName = "Jonquil Fenton", ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20) });
            resources.Add(new DrillDownSL.Resources() { ResourceName = "Bethney Meredith", ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20) });
            resources.Add(new DrillDownSL.Resources() { ResourceName = "Willis Spencer", ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20) });
            resources.Add(new DrillDownSL.Resources() { ResourceName = "Kent John", ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20) });

            chartControl1.Diagram.Series[0].ArgumentDataMember = "ResourceName";
            chartControl1.Diagram.Series[0].ValueDataMember = "ResourceValue";

            chartControl1.Diagram.Series[0].DataSource = resources;
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!ShowDetails)
            {
                ChartHitInfo hitInfo = this.chartControl1.CalcHitInfo(e.GetPosition(this.chartControl1));
                if (hitInfo.InSeries)
                {
                    BindDetailData(hitInfo.SeriesPoint.Argument, hitInfo.Series.Points.IndexOf(hitInfo.SeriesPoint));
                }
            }
        }

        private void BindDetailData(string resource, int index)
        {
            chartControl1.Diagram.Series[0].Visible = false;

            Random rnd = new Random(DateTime.Now.Millisecond);

            activity.Clear();
            for (int i = 9; i < 17; i++)
                activity.Add(new DrillDownSL.WorkActivity() { WorkHour = i,  ProcessedItems = Math.Round(rnd.NextDouble() * 10 + 5) });

            ((XYDiagram2D)chartControl1.Diagram).AxisX.GridSpacing = 1;
            ((XYDiagram2D)chartControl1.Diagram).AxisX.Label.Staggered = false;
            chartControl1.Diagram.Series[1].ArgumentDataMember = "WorkHour";
            chartControl1.Diagram.Series[1].ValueDataMember = "ProcessedItems";

            chartControl1.Diagram.Series[1].DataSource = activity;
            chartControl1.Diagram.Series[1].Visible = true;
            ((BarSideBySideSeries2D)chartControl1.Diagram.Series[1]).Color = chartControl1.Palette[index];
            chartControl1.Diagram.Series[1].Animate();
            chartControl1.Titles[0].Content = string.Format("{0} stats", resource);
            chartControl1.Titles[1].Visible = true;
            ShowDetails = true;
        }


        private void Title_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowDetails = false;
            chartControl1.Diagram.Series[0].Visible = true;
            chartControl1.Diagram.Series[0].Animate();
            chartControl1.Diagram.Series[1].Visible = false;
            chartControl1.Titles[0].Content = "Resources";
            chartControl1.Titles[1].Visible = false;
            ((XYDiagram2D)chartControl1.Diagram).AxisX.Label.Staggered = true;
        }
    }
}
