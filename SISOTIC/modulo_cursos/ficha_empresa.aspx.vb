Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class Reportes_ficha_empresa
    Inherits System.Web.UI.Page
    Dim objWeb As New CWeb
    Dim objSession As CSession
    Dim objCliente As CCliente
    Dim objGeneraFicha As New CGeneraPDF

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)

        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        ViewState("CodRut") = Request("rutCliente")
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
        Consultar()
    End Sub

    Public Sub Consultar()
        objCliente = New CCliente
        Dim lngRut As Long
        Dim strRut As String
        lngRut = ViewState("CodRut")
        strRut = RutLngAUsr(lngRut)
        Dim mobjsql As New CSql
        objCliente.Inicializar(mobjsql)
        objCliente.Inicializar1(strRut)
        'Cabecera Empresa
        lblRazonSocial.Text = objCliente.RazonSocial
        lblRut.Text = rutlngausr(objCliente.Rut)
        lblFono.Text = objCliente.FonoOtec
        'lblFax.Text = objCliente.Fax
        lblEmail.Text = objCliente.EmailOtec
        lblSucursal.Text = objCliente.NombreSucursal
        lblEjecutivo.Text = objCliente.NombreEjecutivo
        'Datos de la empresa
        lblDireccion.Text = objCliente.Direccion & ", " & objCliente.NroDireccion
        lblComuna.Text = objCliente.Comuna
        lblCiudad.Text = objCliente.Ciudad
        lblRegion.Text = objCliente.Region
        lblSitioWeb.Text = objCliente.SitioWeb
        lblContacto.Text = objCliente.Contacto
        lblCargo.Text = objCliente.CargoContacto
        lblFonoContac.Text = objCliente.FonoContacto
        lblAnexo.Text = objCliente.AnexoContacto
        lblEmailContac.Text = objCliente.EmailContacto
        lblNombre1.Text = objCliente.NombreRep1
        If lblNombre1.Text = "" Then
            lblNombre1.Text = "--"
        End If
        lblRut1.Text = objCliente.RutRep1
        If lblRut1.Text = -1 Or lblRut1.Text = "" Then
            lblRut1.Text = "--"
        End If
        lblNombre2.Text = objCliente.NombreRep2
        If lblNombre2.Text = "" Then
            lblNombre2.Text = "--"
        End If
        lblRut2.Text = objCliente.RutRep2
        If lblRut2.Text = -1 Or lblRut2.Text = "" Then
            lblRut2.Text = "--"
        End If
        lblNumEmpleados.Text = FormatoMonto(objCliente.NumEmpleados)
        lblFranquicia.Text = FormatoPeso(objCliente.ObjInfoAdicional.FranquiciaActual)
        lblTasa.Text = objCliente.CostoAdm & "%"
        lblGiro.Text = objCliente.Giro
        If lblGiro.Text = "" Then
            lblGiro.Text = "--"
        End If
        lblCodActEco.Text = objCliente.CodActEconomica
        If lblCodActEco.Text = "" Then
            lblCodActEco.Text = "--"
        End If
        lblRubro.Text = objCliente.Rubro
        If lblRubro.Text = "" Then
            lblRubro.Text = "--"
        End If
        lblVentaAnual.Text = objCliente.VentaAnual
        lblGerenteG.Text = objCliente.GerenteGeneral
        If lblGerenteG.Text = "" Then
            lblGerenteG.Text = "--"
        End If
        lblGerenteRH.Text = objCliente.GerenteRRHH
        If lblGerenteRH.Text = "" Then
            lblGerenteRH.Text = "--"
        End If
        lblEmailGerenteRRHH.Text = objCliente.EmailGerenteRRHH
        If lblEmailGerenteRRHH.Text = "" Then
            lblEmailGerenteRRHH.Text = "--"
        End If
        lblGerenteF.Text = objCliente.GerenteFinanzas
        If lblGerenteF.Text = "" Then
            lblGerenteF.Text = "--"
        End If
        lblEmailGerenteF.Text = objCliente.EmailGerenteFinanzas
        If lblEmailGerenteF.Text = "" Then
            lblEmailGerenteF.Text = "--"
        End If
        lblAreaCob.Text = objCliente.AreaCobranzas
        If lblAreaCob.Text = "" Then
            lblAreaCob.Text = "--"
        End If
        lblFonoCob.Text = objCliente.FonoCobranzas
        If lblFonoCob.Text = "" Then
            lblFonoCob.Text = "--"
        End If
    End Sub
    Protected Sub btnGenerarPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerarPDF.Click
        Dim filename As String

        objGeneraFicha.FichaEmpresa(lblRazonSocial.Text, lblRut.Text, lblFono.Text, "", lblEmail.Text, lblSucursal.Text, _
                                    lblEjecutivo.Text, lblDireccion.Text, lblComuna.Text, lblCiudad.Text, lblRegion.Text, lblSitioWeb.Text, _
                                    lblContacto.Text, lblCargo.Text, lblFonoContac.Text, lblAnexo.Text, lblEmailContac.Text, lblNombre1.Text, _
                                    lblRut1.Text, lblNombre2.Text, lblRut2.Text, lblNumEmpleados.Text, lblFranquicia.Text, lblTasa.Text, _
                                    lblGiro.Text, lblCodActEco.Text, lblRubro.Text, lblVentaAnual.Text, lblGerenteG.Text, lblGerenteRH.Text, _
                                    lblEmailGerenteRRHH.Text, lblGerenteF.Text, lblEmailGerenteF.Text, lblAreaCob.Text, lblFonoCob.Text)


        filename = "Ficha_curso_sence.pdf"

        Response.AppendHeader("content-disposition", "attachment; filename=" & filename)
        'Response.AppendHeader("content-disposition", "attachment; filename=CartaEvaluacion.pdf")
        Response.Clear()
        Response.WriteFile(objGeneraFicha.RutaArchivo)
        Response.End()
        objGeneraFicha = Nothing
    End Sub
End Class
