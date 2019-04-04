<!-- default file list -->
*Files to look at*:

* [MainPage.xaml](./CS/DrillDownSL/MainPage.xaml) (VB: [MainPage.xaml](./VB/DrillDownSL/MainPage.xaml))
* [MainPage.xaml.cs](./CS/DrillDownSL/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/DrillDownSL/MainPage.xaml.vb))
* [Resources.cs](./CS/DrillDownSL/Resources.cs) (VB: [Resources.vb](./VB/DrillDownSL/Resources.vb))
* [WorkActivity.cs](./CS/DrillDownSL/WorkActivity.cs) (VB: [WorkActivity.vb](./VB/DrillDownSL/WorkActivity.vb))
<!-- default file list end -->
# How to implement drill-down functionality in ChartControl (DXCharts for Silverlight)


<p>This example illustrates how to implement drill-down functionality by handling the chart's MouseLeftButtonDown event and use the  ChartControl.CalcHitInfo method to obtain the ChartHitInfo object.<br />
In the example, two Series are added to the chart. When the first Series is clicked, it becomes hidden. Then, the second Series data is displayed using the information extracted from the first Series' data point.</p>

<br/>


