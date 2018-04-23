Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace DrillDownSL
	Public Class Resources
		Private privateResourceName As String
		Public Property ResourceName() As String
			Get
				Return privateResourceName
			End Get
			Set(ByVal value As String)
				privateResourceName = value
			End Set
		End Property
		Private privateResourceValue As Double
		Public Property ResourceValue() As Double
			Get
				Return privateResourceValue
			End Get
			Set(ByVal value As Double)
				privateResourceValue = value
			End Set
		End Property
	End Class
End Namespace
