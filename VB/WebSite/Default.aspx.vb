Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub

	Protected Sub ASPxGridView1_CustomColumnSort(ByVal sender As Object, ByVal e As DevExpress.Web.CustomColumnSortEventArgs)
		CompareColumnValues(e)
	End Sub

	Protected Sub ASPxGridView1_CustomColumnGroup(ByVal sender As Object, ByVal e As DevExpress.Web.CustomColumnSortEventArgs)
		CompareColumnValues(e)
	End Sub

	Private Sub CompareColumnValues(ByVal e As DevExpress.Web.CustomColumnSortEventArgs)
		If e.Column.FieldName = "UnitPrice" Then
			Dim res As Integer = 0

			Dim x As Double = Math.Floor(Convert.ToDouble(e.Value1) / 10)
			Dim y As Double = Math.Floor(Convert.ToDouble(e.Value2) / 10)
			res = Comparer.Default.Compare(x, y)
			If res < 0 Then
				res = -1
			ElseIf res > 0 Then
				res = 1
			End If
			If res = 0 OrElse (x > 9 AndAlso y > 9) Then
				res = 0
			End If

			e.Result = res
			e.Handled = True
		End If
	End Sub

	Protected Sub ASPxGridView1_CustomGroupDisplayText(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs)
		If e.Column.FieldName = "UnitPrice" Then
			Dim d As Double = Math.Floor(Convert.ToDouble(e.Value) / 10)
			Dim displayText As String = String.Format("{0:c} - {1:c} ", d * 10, (d + 1) * 10)
			If d > 9 Then
				displayText = String.Format(">= {0:c} ", 100)
			End If
			e.DisplayText = displayText
		End If
	End Sub
End Class
