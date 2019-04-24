Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_pop_up_empresa
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objMantenedor As CMantenedorCursos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'ViewState("rut") = Request("rut")
            consultar()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub consultar()
        'objMantenedor = New CMantenedorCursos
        'If objMantenedor.EsMoroso(ViewState("rut"), "") Then
        '    objWeb = New CWeb
        '    Dim bf As BoundField
        '    bf = CType(Me.grdEmpresa.Columns(0), BoundField)
        '    bf.DataField = "cuenta"
        '    bf = CType(Me.grdEmpresa.Columns(1), BoundField)
        '    bf.DataField = "saldo"
        '    objWeb.LlenaGrilla(grdEmpresa, objMantenedor.dtClienteMoroso)
        'End If

        objWeb = New CWeb
        Dim bf As BoundField
        bf = CType(Me.grdEmpresa.Columns(0), BoundField)
        bf.DataField = "cuenta"
        bf = CType(Me.grdEmpresa.Columns(1), BoundField)
        bf.DataField = "saldo"
        objWeb.LlenaGrilla(grdEmpresa, Session("dtClienteMoroso"))
    End Sub
End Class
