Imports Clases
Imports Clases.Web
Imports Modulos
Imports System.Data
Partial Class contenido_ascx_cabeceraCurso
    Inherits System.Web.UI.UserControl
    Private objSession As CSession
    Dim objReporte As New CFichaCursoContratado
    Private objWeb As CWeb
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        '************************************
        ViewState("CodCurso") = Request("codCurso")
        If Not Page.IsPostBack Then
            cargacabecera()
            'Me.lblFechaActual.Text = Now.Date()
            'Me.lblHoraActual.Text = Now.Hour & ":" & Now.Minute
        End If
    End Sub

    Public Sub cargacabecera()
        objReporte = New CFichaCursoContratado
        objReporte.CodCurso = ViewState("CodCurso")
        objReporte.RutCliente = objSession.Rut
        objReporte.Agno = objSession.Agno
        objReporte.Consultar()


        Me.lblCorrelativo.Text = objReporte.Correlativo
        Me.lblFecha.Text = FechaVbAUsr(objReporte.FechaModificacion)
        'If Trim(objReporte.CodOrigen) = "0" Then
        '    lblOrigen.Text = "Interno"
        'ElseIf Trim(objReporte.CodOrigen) = "1" Then
        '    lblOrigen.Text = "Cliente"
        'Else
        '    lblOrigen.Text = "--"
        'End If
        If objReporte.NroRegistro <> "-1" Then
            Me.lblRegSence.Text = objReporte.NroRegistro
        Else
            Me.lblRegSence.Text = "--"
        End If
        Me.lblFechIngreso.Text = objReporte.FechaIngreso
        Me.lblRegSenCompl.Text = "--"
        Dim strEstado As String
        strEstado = ViewState("EstadoCurso")
        'Me.hplEstado.Text = ViewState("EstadoCurso")
        If objReporte.CodEstadoCurso = 0 Then
            Me.hplEstado.Text = "Incompleto"
        ElseIf objReporte.CodEstadoCurso = 1 Then
            Me.hplEstado.Text = "Ingresado"
        ElseIf objReporte.CodEstadoCurso = 2 Then
            Me.hplEstado.Text = "Rechazado"
        ElseIf objReporte.CodEstadoCurso = 3 Then
            Me.hplEstado.Text = "Autorizado"
        ElseIf objReporte.CodEstadoCurso = 4 Then
            Me.hplEstado.Text = "Comunicado"
        ElseIf objReporte.CodEstadoCurso = 5 Then
            Me.hplEstado.Text = "Liquidado"
        ElseIf objReporte.CodEstadoCurso = 6 Then
            Me.hplEstado.Text = "Pago por Autorizar"
        ElseIf objReporte.CodEstadoCurso = 7 Then
            Me.hplEstado.Text = "En comunicación"
        ElseIf objReporte.CodEstadoCurso = 8 Then
            Me.hplEstado.Text = "Eliminados"
        ElseIf objReporte.CodEstadoCurso = 9 Then
            Me.hplEstado.Text = "En liquidación"
        ElseIf objReporte.CodEstadoCurso = 10 Then
            Me.hplEstado.Text = "Anulados"
        ElseIf objReporte.CodEstadoCurso = 11 Then
            Me.hplEstado.Text = "Con asistencia"
        End If
        
        hplEstado.NavigateUrl = "~/modulo_cuentas/reporte_bitacoras.aspx?codCurso=" & ViewState("CodCurso") & "&tipo=1" & "&estado=" & hplEstado.Text

    End Sub
End Class

