Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub grid_HtmlRowPrepared(ByVal sender As Object, ByVal e As ASPxGridViewTableRowEventArgs)
        Dim g As ASPxGridView = TryCast(sender, ASPxGridView)
        Dim groupIndex As Integer = g.GetRowLevel(e.VisibleIndex)
        If (e.RowType = GridViewRowType.Group) AndAlso (groupIndex > 0) Then

            If e.Row.Cells.Count > groupIndex AndAlso e.Row.Cells(groupIndex) IsNot Nothing AndAlso e.Row.Cells(groupIndex).Controls.Count > 0 Then
                e.Row.Cells(groupIndex).Controls(0).Visible = False
            End If
        End If
    End Sub
    Protected Sub grid_BeforeGetCallbackResult(ByVal sender As Object, ByVal e As EventArgs)
        Dim g As ASPxGridView = TryCast(sender, ASPxGridView)
        For i As Integer = 0 To g.VisibleRowCount - 1
            If g.IsGroupRow(i) AndAlso (Not g.IsRowExpanded(i)) AndAlso g.GetRowLevel(i) > 0 Then
                g.ExpandRow(i, True)
            End If
        Next i

    End Sub
End Class