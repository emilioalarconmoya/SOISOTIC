Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_aporte_aviso_inscripcion_de_cursos
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objReporte As New CFichaCursoContratado
    Dim objSession As CSession
    Dim objAlumno As New CReporteAlumnos
    Dim objCurso As New CCursoContratado




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        ViewState("CodCurso") = Request("codCurso")
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            btnImprimir.Attributes.Add("onclick", "Imprimir();")
            If ViewState("PaginasAtras") Is Nothing Then
                ViewState("PaginasAtras") = 1
            End If
        Else
            ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

        End If
        Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"
        cosultar()


    End Sub

    Public Sub cosultar()
        Try

            'Dim mlngAgno As Long
            Dim CodCurso As Long
            CodCurso = ViewState("CodCurso")
            objCurso = New CCursoContratado
            objAlumno = New CReporteAlumnos
            objReporte = New CFichaCursoContratado

            Dim objcliente As New CCliente
            

            'Dim ccursocontratado As New CCursoContratado
            objReporte.CodCurso = ViewState("CodCurso")
            objCurso.CodCurso = ViewState("CodCurso")

            objReporte.RutCliente = objSession.Rut
            objReporte.Consultar()

            'datos de la empreza

            Me.lblContacto.Text = objReporte.NombreContacto
            Me.lblCargo.Text = objReporte.CargoContacto
            Me.lblRazonSocial.Text = objReporte.RazonSocial
            Me.lblFehca.Text = Now.Date
            Me.lblCorrelativo1.Text = objReporte.Correlativo
            Me.lblCorrelativoEmp.Text = objReporte.CorrEmpresa

            'datos del curso 
            Me.LblNombreCurso.Text = objReporte.NombreCurso
            Me.lblCorrelativo.Text = objReporte.Correlativo
            Me.lblCUdireccion.Text = objReporte.DireccionCurso
            Me.lblCUnumero.Text = objReporte.NroDireccionCurso
            Me.lblCUciudad.Text = objReporte.Ciudad
            Me.lblCUcomuna.Text = objReporte.NombreComuna
            Me.lblCUregion.Text = objReporte.NomRegion
            Me.lblCUfechaInicio.Text = objReporte.FechaInicio
            Me.lblCUfechaTermino.Text = objReporte.FechaTermino
            Me.LblTotalParticipantes.Text = objReporte.NumAlumnos
            Me.LblCodigoSence.Text = objReporte.CodSence
            Me.LblDuracion.Text = objReporte.Horas
            Me.LblorganismoEjecutor.Text = objReporte.NombreOtec
            'Me.LblRegistroSence.Text = objReporte.NroRegistro
            If (objReporte.NroRegistro = -1) Then
                Me.LblRegistroSence.Text = "--"
            Else
                Me.LblRegistroSence.Text = objReporte.NroRegistro
            End If


            If (objReporte.IndAcuComBip = 0) Then
                Me.LblComite.Text = "No"
            Else
                Me.LblComite.Text = "Si"
            End If

            'valores asociados
            Me.LblValorCurso.Text = FormatoMonto(objReporte.ValorMercado)
            Me.LblCostoOtic.Text = FormatoMonto(objReporte.CostoOtic)
            Me.LblCostoOticCom.Text = FormatoMonto(objReporte.CostoOticComplemento)
            Me.LblCostoEmp.Text = FormatoMonto(objReporte.ValorMercado - objReporte.CostoOtic)
            Me.LblTotalVyT.Text = FormatoMonto(objReporte.TotalTraslado + objReporte.TotalViatico)
            Me.LblCostoOticVyT.Text = FormatoMonto(objReporte.CostoOticVYT)
            Me.LblCostoEmpVyT.Text = FormatoMonto(objReporte.CostoOticVYT)
            'cargos
            Me.LblCuentaCapa.Text = FormatoMonto(objReporte.MontoCtaCap)
            Me.LblExDeCap.Text = FormatoMonto(objReporte.MontoCtaExcCap)
            Me.LblBecasDeCapa.Text = FormatoMonto(objReporte.MontoCtaBecas)
            Me.LblCuentasDeTerceros.Text = FormatoMonto(objReporte.TotMontoTerc)


            objCurso.Inicializar1(CodCurso)

            Dim dt As DataTable
            dt = objCurso.ConsultarListado
            objWeb.LlenaGrilla(grdResultados, dt)

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub grdResultados_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdResultados.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
           

            Dim lblRut As Label
            lblRut = CType(e.Row.FindControl("lblRutAlumno"), Label)
            lblRut.Text = lblRut.Text

            Dim lblFech As Label
            lblFech = CType(e.Row.FindControl("LblFechaNac"), Label)
            lblFech.Text = FechaVbAUsr(lblFech.Text)

            Dim lbl As Label
            lbl = CType(e.Row.FindControl("lblCostoOtic"), Label)
            lbl.Text = FormatoPeso(lbl.Text)

            Dim lbl1 As Label
            lbl1 = CType(e.Row.FindControl("lblCostoEmp"), Label)
            lbl1.Text = FormatoPeso(lbl1.Text)

            Dim lbl2 As Label
            lbl2 = CType(e.Row.FindControl("lblViatico"), Label)
            lbl2.Text = FormatoPeso(lbl2.Text)

            Dim lbl3 As Label
            lbl3 = CType(e.Row.FindControl("lblTraslado"), Label)
            lbl3.Text = FormatoPeso(lbl3.Text)

            Dim lbl4 As Label
            lbl4 = CType(e.Row.FindControl("LblFranq"), Label)
            lbl4.Text = CLng(lbl4.Text)

            Dim lbl5 As Label
            lbl5 = CType(e.Row.FindControl("LblSexo"), Label)
            lbl5.Text = FormatoSexo(lbl5.Text)

            Dim lblTotal As Label
            lblTotal = CType(e.Row.FindControl("LblTotal"), Label)
            lblTotal.Text = FormatoPeso(lblTotal.Text)


        End If
    End Sub

End Class
