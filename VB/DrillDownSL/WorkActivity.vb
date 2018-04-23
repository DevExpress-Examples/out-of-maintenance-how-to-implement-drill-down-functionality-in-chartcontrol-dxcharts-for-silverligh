Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DrillDownSL
	Public Class WorkActivity
		Private privateWorkHour As Integer
		Public Property WorkHour() As Integer
			Get
				Return privateWorkHour
			End Get
			Set(ByVal value As Integer)
				privateWorkHour = value
			End Set
		End Property
		Private privateProcessedItems As Double
		Public Property ProcessedItems() As Double
			Get
				Return privateProcessedItems
			End Get
			Set(ByVal value As Double)
				privateProcessedItems = value
			End Set
		End Property
	End Class
End Namespace
