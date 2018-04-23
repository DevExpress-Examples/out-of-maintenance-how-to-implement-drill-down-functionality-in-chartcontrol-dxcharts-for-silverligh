Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Charts

Namespace DrillDownSL
	Partial Public Class MainPage
		Inherits UserControl
		Private resources As New List(Of Resources)()
		Private activity As New List(Of WorkActivity)()

		Private ShowDetails As Boolean = False

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub UserControl_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			BindChartData()
		End Sub

		Private Sub BindChartData()
			Dim rnd As New Random(DateTime.Now.Millisecond)

			resources.Clear()

			resources.Add(New DrillDownSL.Resources() With {.ResourceName = "Louis Marilyn", .ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20)})
			resources.Add(New DrillDownSL.Resources() With {.ResourceName = "Jem Carlisa", .ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20)})
			resources.Add(New DrillDownSL.Resources() With {.ResourceName = "Jonquil Fenton", .ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20)})
			resources.Add(New DrillDownSL.Resources() With {.ResourceName = "Bethney Meredith", .ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20)})
			resources.Add(New DrillDownSL.Resources() With {.ResourceName = "Willis Spencer", .ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20)})
			resources.Add(New DrillDownSL.Resources() With {.ResourceName = "Kent John", .ResourceValue = Math.Round(rnd.NextDouble() * 10 + 20)})

			chartControl1.Diagram.Series(0).ArgumentDataMember = "ResourceName"
			chartControl1.Diagram.Series(0).ValueDataMember = "ResourceValue"

			chartControl1.Diagram.Series(0).DataSource = resources
		End Sub

		Private Sub UserControl_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			If (Not ShowDetails) Then
				Dim hitInfo As ChartHitInfo = Me.chartControl1.CalcHitInfo(e.GetPosition(Me.chartControl1))
				If hitInfo.InSeries Then
					BindDetailData(hitInfo.SeriesPoint.Argument, hitInfo.Series.Points.IndexOf(hitInfo.SeriesPoint))
				End If
			End If
		End Sub

		Private Sub BindDetailData(ByVal resource As String, ByVal index As Integer)
			chartControl1.Diagram.Series(0).Visible = False

			Dim rnd As New Random(DateTime.Now.Millisecond)

			activity.Clear()
			For i As Integer = 9 To 16
				activity.Add(New DrillDownSL.WorkActivity() With {.WorkHour = i, .ProcessedItems = Math.Round(rnd.NextDouble() * 10 + 5)})
			Next i

			CType(chartControl1.Diagram, XYDiagram2D).AxisX.GridSpacing = 1
			CType(chartControl1.Diagram, XYDiagram2D).AxisX.Label.Staggered = False
			chartControl1.Diagram.Series(1).ArgumentDataMember = "WorkHour"
			chartControl1.Diagram.Series(1).ValueDataMember = "ProcessedItems"

			chartControl1.Diagram.Series(1).DataSource = activity
			chartControl1.Diagram.Series(1).Visible = True
			CType(chartControl1.Diagram.Series(1), BarSideBySideSeries2D).Color = chartControl1.Palette(index)
			chartControl1.Diagram.Series(1).Animate()
			chartControl1.Titles(0).Content = String.Format("{0} stats", resource)
			chartControl1.Titles(1).Visible = True
			ShowDetails = True
		End Sub


		Private Sub Title_MouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			ShowDetails = False
			chartControl1.Diagram.Series(0).Visible = True
			chartControl1.Diagram.Series(0).Animate()
			chartControl1.Diagram.Series(1).Visible = False
			chartControl1.Titles(0).Content = "Resources"
			chartControl1.Titles(1).Visible = False
			CType(chartControl1.Diagram, XYDiagram2D).AxisX.Label.Staggered = True
		End Sub
	End Class
End Namespace
