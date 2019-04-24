Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_otec
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objGeneraFicha As New CGeneraPDF
    Dim objReporte As New COtec
    Dim Otec As New COtec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '**************Session***************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            'If Not objSession.AccesoObjeto(20) Then
            '    Response.Redirect("../Acceso_Denegado.aspx")
            '    Exit Sub
            'End If

            ViewState("rutOtec") = Request("rutOtec")
            '************************************
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
            consultar()
        Catch ex As Exception
            EnviaError("Reportes_ficha_otec--> Page_Load" & ex.Message)
        End Try
    End Sub

    Private Sub consultar()
        Try
            objReporte = New COtec
            objReporte.RutUsuario = objSession.Rut
            Dim lngRut As Long
            Dim strRut As String
            lngRut = ViewState("rutOtec")
            strRut = RutLngAUsr(lngRut)
            objReporte.Inicializar1(strRut)
            'objReporte.consultar()
            Otec = New COtec

            If objReporte.Direccion = "" Then
                Me.lblDIdireccion.Text = "-"
            Else
                Me.lblDIdireccion.Text = objReporte.Direccion
            End If
            If objReporte.Comuna = "" Then
                Me.lblDInombreComuna.Text = "-"
            Else
                Me.lblDInombreComuna.Text = objReporte.Comuna
            End If
            If objReporte.Region = "" Then
                Me.lblDIregion.Text = "-"
            Else
                Me.lblDIregion.Text = objReporte.Region
            End If
            If objReporte.Email = "" Then
                Me.lblDIemail.Text = "-"
            Else
                Me.lblDIemail.Text = objReporte.Email
            End If
            lblDIemail.NavigateUrl = "mailto:" & objReporte.Email

            If objReporte.Contacto = "" Then
                Me.lblCOnombreContacto.Text = "-"
            Else
                Me.lblCOnombreContacto.Text = objReporte.Contacto
            End If
            If objReporte.Cargo = "" Then
                Me.lblCOcargoOtec.Text = "-"
            Else
                Me.lblCOcargoOtec.Text = objReporte.Cargo
            End If
            If objReporte.FonoContacto = "" Then
                Me.lblCOfonoOtec.Text = "-"
            Else
                Me.lblCOfonoOtec.Text = objReporte.FonoContacto
            End If
            'If objReporte.FaxContacto = "" Then
            '    Me.lblCOfaxOtec.Text = "-"
            'Else
            '    Me.lblCOfaxOtec.Text = objReporte.FaxContacto
            'End If
            If objReporte.EmailContacto = "" Then
                Me.lblCOemailOtec.Text = "-"
            Else
                Me.lblCOemailOtec.Text = objReporte.EmailContacto

            End If

            If objReporte.Rep1 = "" Then
                Me.lblRLnombreRep1.Text = "-"
            Else
                Me.lblRLnombreRep1.Text = objReporte.Rep1
            End If
            If objReporte.RutRep1 = 0 Then
                Me.lblRLrutRep1.Text = "-"
            Else
                Me.lblRLrutRep1.Text = RutLngAUsr(objReporte.RutRep1)
            End If
            If objReporte.Rep2 = "" Then
                Me.lblRLnombreRep2.Text = "-"
            Else
                Me.lblRLnombreRep2.Text = objReporte.Rep2
            End If
            If objReporte.RutRep2 = 0 Then
                Me.lblRLrutRep2.Text = "-"
            Else
                Me.lblRLrutRep2.Text = RutLngAUsr(objReporte.RutRep2)
            End If
            If objReporte.NumConvenio = 0 Then
                Me.lblDCNumComvenio.Text = "-"
            Else
                Me.lblDCNumComvenio.Text = objReporte.NumConvenio
            End If
            If objReporte.TasaDescuento = 0 Then
                Me.lblDCtasaDescuento.Text = "-"
            Else
                Me.lblDCtasaDescuento.Text = objReporte.TasaDescuento & "%"
            End If

            If objReporte.Giro = "" Then
                Me.lblACgiro.Text = "-"
            Else
                Me.lblACgiro.Text = objReporte.Giro
            End If
            If objReporte.CodActEco = "" Then
                Me.lblACcodActEco.Text = "-"
            Else
                Me.lblACcodActEco.Text = objReporte.CodActEco
            End If
            If objReporte.NombreRubro = "" Then
                Me.lblACrubroInterno.Text = "-"
            Else
                Me.lblACrubroInterno.Text = objReporte.NombreRubro
            End If

            If objReporte.Gtegeneral = "" Then
                Me.lblOCgerenteGeneral.Text = "-"
            Else
                Me.lblOCgerenteGeneral.Text = objReporte.Gtegeneral
            End If
            If objReporte.GteRRHH = "" Then
                Me.lblOCgerenteRRHH.Text = "-"
            Else
                Me.lblOCgerenteRRHH.Text = objReporte.GteRRHH
            End If
            If objReporte.AreaCobranzas = "" Then
                Me.lblOCareaCobranza.Text = "-"
            Else
                Me.lblOCareaCobranza.Text = objReporte.AreaCobranzas
            End If

            If objReporte.RutFormateadoOtec = "" Then
                Me.lblDCrut.Text = "-"
            Else
                Me.lblDCrut.Text = RutLngAUsr(objReporte.RutFormateadoOtec)
            End If
            If objReporte.RazonSocial = "" Then
                Me.lblDCrazonSocial.Text = "-"
            Else
                Me.lblDCrazonSocial.Text = objReporte.RazonSocial
            End If
            If objReporte.Fono = "" Then
                Me.lblFono.Text = "-"
            Else
                Me.lblFono.Text = objReporte.Fono
            End If
            'If objReporte.Fax = "" Then
            '    Me.lblFax.Text = "-"
            'Else
            '    Me.lblFax.Text = objReporte.Fax
            'End If
            If objReporte.Email = "" Then
                Me.lblEmail.Text = "-"
            Else
                Me.lblEmail.Text = objReporte.Email
            End If
        Catch ex As Exception
            EnviaError("Reportes_ficha_otec--> consultar" & ex.Message)
        End Try
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        Response.Redirect("reporte_cursos_consolidado.aspx")
    End Sub

    Protected Sub btnFichaOtecPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFichaOtecPDF.Click
        'Try
        Dim filename As String

        ValoresPdf()
        objGeneraFicha.FichaOtec()

        filename = "Ficha_curso_sence.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        'Response.AppendHeader("content-disposition", "attachment; filename=CartaEvaluacion.pdf")
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
        'Catch ex As Exception
        '    EnviaError("Reportes_ficha_otec--> btnFichaOtecPDF_Click" & ex.Message)
        'End Try
    End Sub

    Protected Sub ValoresPdf()
        Try
            objGeneraFicha.RutOtec = Me.lblDCrut.Text
            objGeneraFicha.FonoOtec = Me.lblFono.Text
            objGeneraFicha.RazonSocial = Me.lblDCrazonSocial.Text
            'objGeneraFicha.FaxOtec = Me.lblFax.Text
            objGeneraFicha.MailOtec = Me.lblEmail.Text

            objGeneraFicha.DINombreDireccion = Me.lblDIdireccion.Text
            objGeneraFicha.DINombreComuna = lblDInombreComuna.Text
            objGeneraFicha.DIRegion = Me.lblDIregion.Text
            objGeneraFicha.DIEmail = Me.lblDIemail.Text

            objGeneraFicha.CONombreContacto = Me.lblCOnombreContacto.Text
            objGeneraFicha.COCargoOtec = Me.lblCOcargoOtec.Text
            objGeneraFicha.COFonoOtec = Me.lblCOfonoOtec.Text
            'objGeneraFicha.COFaxOtec = Me.lblCOfaxOtec.Text
            objGeneraFicha.COEmail = Me.lblCOemailOtec.Text

            objGeneraFicha.RLNombreRepresentante1 = Me.lblRLnombreRep1.Text
            objGeneraFicha.RLRutRepresentante1 = Me.lblRLrutRep1.Text
            objGeneraFicha.RLNombreRepresentante2 = Me.lblRLnombreRep2.Text
            objGeneraFicha.RLRutRepresentante2 = Me.lblRLrutRep2.Text

            objGeneraFicha.DCNroConvenio = Me.lblDCNumComvenio.Text
            objGeneraFicha.DCTasaDescuento = Me.lblDCtasaDescuento.Text

            objGeneraFicha.ACGiro = Me.lblACgiro.Text
            objGeneraFicha.ACCodigoActidadEconomica = Me.lblACcodActEco.Text
            objGeneraFicha.ACRubroInterno = Me.lblACrubroInterno.Text

            objGeneraFicha.OCGerenteGeneral = Me.lblOCgerenteGeneral.Text
            objGeneraFicha.OCGerenteRRHH = Me.lblOCgerenteRRHH.Text
            objGeneraFicha.OCAreaCobranza = Me.lblOCareaCobranza.Text

        Catch ex As Exception
            EnviaError("Reportes_ficha_otec--> ValoresPdf" & ex.Message)
        End Try
    End Sub
End Class
