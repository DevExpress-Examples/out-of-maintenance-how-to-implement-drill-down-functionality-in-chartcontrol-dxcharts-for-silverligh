<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128568096/10.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3048)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


