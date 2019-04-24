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
            If objSession.EsClienteIngresoCurso Then
                Me.hplIngresoCurso.Visible = True
            End If
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
        objCliente.Inicializar0(mobjsql, lngRut)
        objCliente.Inicializar1(strRut)
        'Cabecera Empresa
        lblRazonSocial.Text = objCliente.RazonSocial
        lblRut.Text = RutLngAUsr(objCliente.Rut)
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
            lblNombre1.Text = "-"
        End If
        lblRut1.Text = objCliente.RutRep1
        If lblRut1.Text = -1 Or lblRut1.Text = "" Then
            lblRut1.Text = "-"
        End If
        lblNombre2.Text = objCliente.NombreRep2
        If lblNombre2.Text = "" Then
            lblNombre2.Text = "-"
        End If
        lblRut2.Text = objCliente.RutRep2
        If lblRut2.Text = -1 Or lblRut2.Text = "" Then
            lblRut2.Text = "-"
        End If
        lblNumEmpleados.Text = FormatoMonto(objCliente.NumEmpleados)
        lblFranquicia.Text = FormatoPeso(objCliente.ObjInfoAdicional.FranquiciaActual)
        lblTasa.Text = objCliente.CostoAdm
        lblGiro.Text = objCliente.Giro
        lblCodActEco.Text = objCliente.CodActEconomica
        lblRubro.Text = objCliente.Rubro
        lblVentaAnual.Text = objCliente.VentaAnual
        lblGerenteG.Text = objCliente.GerenteGeneral
        lblGerenteRH.Text = objCliente.GerenteRRHH
        lblEmailGerenteRRHH.Text = objCliente.EmailGerenteRRHH
        lblGerenteF.Text = objCliente.GerenteFinanzas
        lblEmailGerenteF.Text = objCliente.EmailGerenteFinanzas
        lblAreaCob.Text = objCliente.AreaCobranzas
        lblFonoCob.Text = objCliente.FonoCobranzas
    End Sub

    'Protected Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
    '    Try
    '        Me.btnImprimir.Visible = False
    '        Me.btnVolver.Visible = False
    '        Response.Write("<script>window.print();</script>")
    '    Catch ex As Exception
    '        EnviaError("diploma.aspx->btnImprimir_Click->" & ex.Message)
    '    End Try
    'End Sub
End Class
