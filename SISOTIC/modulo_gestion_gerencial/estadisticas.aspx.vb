Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_gestion_gerencial_estadisticas
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As New CSession
    Dim objInforme As CInformeEstadistica
    Dim curso As New CCursoInterno
    Dim objLookups As New Clookups
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '*********************************** 
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            Dim lngRut As Long
            lngRut = objSession.Rut
            objWeb.LlenaDDL(ddlAgnos, objLookups.Agnos2, "Agno_v", "Agno_t")
            objWeb.LlenaDDL(Me.ddlEjecutivo, objLookups.EjecutivosTodos, "rut", "nombres")
            objWeb.LlenaDDL(Me.ddlSucursal, objLookups.sucursales, "cod_sucursal", "nombre")
            objWeb.AgregaValorDDL(Me.ddlEjecutivo, "Todos", 0)
            objWeb.AgregaValorDDL(Me.ddlSucursal, "Todas", 0)
            ddlAgnos.SelectedValue = Now.Year()
            ddlEjecutivo.SelectedValue = 0
            ddlSucursal.SelectedValue = 0
            Me.btnPopUpEmpresa.Attributes.Add("onClick", "popup_pos('../modulo_administracion/buscador_empresas.aspx?campo=txtRutEmpresa', 'NewWindow1', 380, 700, 100, 100);return false;")

            Consultar()

            'ddlAgnos.SelectedValue = objSession.Agno
            'objWeb.SeteaGrilla(GridResultados, TAM_PAG)
        End If
    End Sub
    Private Sub Consultar()
        objInforme = New CInformeEstadistica

        objInforme.RutUsuario = objSession.Rut
        If Me.txtRutEmpresa.Text = "" Then
            objInforme.RutCliente = 0
        Else
            objInforme.RutCliente = RutUsrALng(Me.txtRutEmpresa.Text)
        End If


        If Me.ddlEjecutivo.SelectedValue = 0 Then
            objInforme.RutEjecutivo = 0
        Else
            objInforme.RutEjecutivo = Me.ddlEjecutivo.SelectedValue
        End If

        If Me.ddlSucursal.SelectedValue = 0 Then
            objInforme.CodSucursal = 0
        Else
            objInforme.CodSucursal = Me.ddlSucursal.SelectedValue
        End If

        objInforme.Agno = Me.ddlAgnos.SelectedValue

        objInforme.Holding = Me.chkEmp.Checked


        'Dim dt As DataTable
        objInforme.Cargar(Me.chkEmp.Checked, Me.txtRutEmpresa.Text, Me.ddlSucursal.SelectedValue, Me.ddlEjecutivo.SelectedValue, Me.ddlAgnos.SelectedValue)

        Me.lblNivelEdu1.Text = objInforme.NombreNivelEduc1
        Me.lblNivelEdu2.Text = objInforme.NombreNivelEduc2
        Me.lblNivelEdu3.Text = objInforme.NombreNivelEduc3
        Me.lblNivelEdu4.Text = objInforme.NombreNivelEduc4
        Me.lblNivelEdu5.Text = objInforme.NombreNivelEduc5
        Me.lblNivelEdu6.Text = objInforme.NombreNivelEduc6
        Me.lblNivelEdu7.Text = objInforme.NombreNivelEduc7
        Me.lblNivelEdu8.Text = objInforme.NombreNivelEduc8
        Me.lblNivelEdu9.Text = objInforme.NombreNivelEduc9
        Me.lblNivelEdu10.Text = objInforme.NombreNivelEduc1
        Me.lblNivelEdu11.Text = objInforme.NombreNivelEduc2
        Me.lblNivelEdu12.Text = objInforme.NombreNivelEduc3
        Me.lblNivelEdu13.Text = objInforme.NombreNivelEduc4
        Me.lblNivelEdu14.Text = objInforme.NombreNivelEduc5
        Me.lblNivelEdu15.Text = objInforme.NombreNivelEduc6
        Me.lblNivelEdu16.Text = objInforme.NombreNivelEduc7
        Me.lblNivelEdu17.Text = objInforme.NombreNivelEduc8
        Me.lblNivelEdu18.Text = objInforme.NombreNivelEduc9

        Me.lblCursosInscritos1.Text = FormatoMonto(objInforme.CursosInscritos1)
        Me.lblCursosInscritos2.Text = FormatoMonto(objInforme.CursosInscritos2)
        Me.lblCursosInscritos3.Text = FormatoMonto(objInforme.CursosInscritos3)
        Me.lblCursosInscritos4.Text = FormatoMonto(objInforme.CursosInscritos4)
        Me.lblCursosInscritos5.Text = FormatoMonto(objInforme.CursosInscritos5)
        Me.lblCursosInscritos6.Text = FormatoMonto(objInforme.CursosInscritos6)
        Me.lblCursosInscritos7.Text = FormatoMonto(objInforme.CursosInscritos7)
        Me.lblCursosInscritos8.Text = FormatoMonto(objInforme.CursosInscritos8)
        Me.lblCursosInscritos9.Text = FormatoMonto(objInforme.CursosInscritos9)
        Me.lblCursosInscritos10.Text = FormatoMonto(objInforme.CursosInscritos10)
        Me.lblCursosInscritos11.Text = FormatoMonto(objInforme.CursosInscritos11)
        Me.lblCursosInscritos12.Text = FormatoMonto(objInforme.CursosInscritos12)
        Me.lblTotalCursosInscritos.Text = FormatoMonto(objInforme.TotalCursosInscritos)

        Me.lblSinEscolaridadPart1.Text = FormatoMonto(objInforme.SinEScolaridadPart1)
        Me.lblSinEscolaridadPart2.Text = FormatoMonto(objInforme.SinEScolaridadPart2)
        Me.lblSinEscolaridadPart3.Text = FormatoMonto(objInforme.SinEScolaridadPart3)
        Me.lblSinEscolaridadPart4.Text = FormatoMonto(objInforme.SinEScolaridadPart4)
        Me.lblSinEscolaridadPart5.Text = FormatoMonto(objInforme.SinEScolaridadPart5)
        Me.lblSinEscolaridadPart6.Text = FormatoMonto(objInforme.SinEScolaridadPart6)
        Me.lblSinEscolaridadPart7.Text = FormatoMonto(objInforme.SinEScolaridadPart7)
        Me.lblSinEscolaridadPart8.Text = FormatoMonto(objInforme.SinEScolaridadPart8)
        Me.lblSinEscolaridadPart9.Text = FormatoMonto(objInforme.SinEScolaridadPart9)
        Me.lblSinEscolaridadPart10.Text = FormatoMonto(objInforme.SinEScolaridadPart10)
        Me.lblSinEscolaridadPart11.Text = FormatoMonto(objInforme.SinEScolaridadPart11)
        Me.lblSinEscolaridadPart12.Text = FormatoMonto(objInforme.SinEScolaridadPart12)
        Me.lblTotalSinEscolaridadPart.Text = FormatoMonto(objInforme.SinEScolaridadPart1 + objInforme.SinEScolaridadPart2 + objInforme.SinEScolaridadPart3 + objInforme.SinEScolaridadPart4 + objInforme.SinEScolaridadPart5 + objInforme.SinEScolaridadPart6 + objInforme.SinEScolaridadPart7 + objInforme.SinEScolaridadPart8 + objInforme.SinEScolaridadPart9 + objInforme.SinEScolaridadPart10 + objInforme.SinEScolaridadPart11 + objInforme.SinEScolaridadPart12)

        Me.lblBasicaInComplPart1.Text = FormatoMonto(objInforme.BasicaIncomplPart1)
        Me.lblBasicaInComplPart2.Text = FormatoMonto(objInforme.BasicaIncomplPart2)
        Me.lblBasicaInComplPart3.Text = FormatoMonto(objInforme.BasicaIncomplPart3)
        Me.lblBasicaInComplPart4.Text = FormatoMonto(objInforme.BasicaIncomplPart4)
        Me.lblBasicaInComplPart5.Text = FormatoMonto(objInforme.BasicaIncomplPart5)
        Me.lblBasicaInComplPart6.Text = FormatoMonto(objInforme.BasicaIncomplPart6)
        Me.lblBasicaInComplPart7.Text = FormatoMonto(objInforme.BasicaIncomplPart7)
        Me.lblBasicaInComplPart8.Text = FormatoMonto(objInforme.BasicaIncomplPart8)
        Me.lblBasicaInComplPart9.Text = FormatoMonto(objInforme.BasicaIncomplPart9)
        Me.lblBasicaInComplPart10.Text = FormatoMonto(objInforme.BasicaIncomplPart10)
        Me.lblBasicaInComplPart11.Text = FormatoMonto(objInforme.BasicaIncomplPart11)
        Me.lblBasicaInComplPart12.Text = FormatoMonto(objInforme.BasicaIncomplPart12)
        Me.lblTotalBasicaInComplPart.Text = FormatoMonto(objInforme.BasicaIncomplPart1 + objInforme.BasicaIncomplPart2 + objInforme.BasicaIncomplPart3 + objInforme.BasicaIncomplPart4 + objInforme.BasicaIncomplPart5 + objInforme.BasicaIncomplPart6 + objInforme.BasicaIncomplPart7 + objInforme.BasicaIncomplPart8 + objInforme.BasicaIncomplPart9 + objInforme.BasicaIncomplPart10 + objInforme.BasicaIncomplPart11 + objInforme.BasicaIncomplPart12)

        Me.lblBasicaComplPart1.Text = FormatoMonto(objInforme.BasicaComplPart1)
        Me.lblBasicaComplPart2.Text = FormatoMonto(objInforme.BasicaComplPart2)
        Me.lblBasicaComplPart3.Text = FormatoMonto(objInforme.BasicaComplPart3)
        Me.lblBasicaComplPart4.Text = FormatoMonto(objInforme.BasicaComplPart4)
        Me.lblBasicaComplPart5.Text = FormatoMonto(objInforme.BasicaComplPart5)
        Me.lblBasicaComplPart6.Text = FormatoMonto(objInforme.BasicaComplPart6)
        Me.lblBasicaComplPart7.Text = FormatoMonto(objInforme.BasicaComplPart7)
        Me.lblBasicaComplPart8.Text = FormatoMonto(objInforme.BasicaComplPart8)
        Me.lblBasicaComplPart9.Text = FormatoMonto(objInforme.BasicaComplPart9)
        Me.lblBasicaComplPart10.Text = FormatoMonto(objInforme.BasicaComplPart10)
        Me.lblBasicaComplPart11.Text = FormatoMonto(objInforme.BasicaComplPart11)
        Me.lblBasicaComplPart12.Text = FormatoMonto(objInforme.BasicaComplPart12)
        Me.lblTotalBasicaComplPart.Text = FormatoMonto(objInforme.BasicaComplPart1 + objInforme.BasicaComplPart2 + objInforme.BasicaComplPart3 + objInforme.BasicaComplPart4 + objInforme.BasicaComplPart5 + objInforme.BasicaComplPart6 + objInforme.BasicaComplPart7 + objInforme.BasicaComplPart8 + objInforme.BasicaComplPart9 + objInforme.BasicaComplPart10 + objInforme.BasicaComplPart11 + objInforme.BasicaComplPart12)

        Me.lblMediaIncomplPart1.Text = FormatoMonto(objInforme.MediaIncomplPart1)
        Me.lblMediaIncomplPart2.Text = FormatoMonto(objInforme.MediaIncomplPart2)
        Me.lblMediaIncomplPart3.Text = FormatoMonto(objInforme.MediaIncomplPart3)
        Me.lblMediaIncomplPart4.Text = FormatoMonto(objInforme.MediaIncomplPart4)
        Me.lblMediaIncomplPart5.Text = FormatoMonto(objInforme.MediaIncomplPart5)
        Me.lblMediaIncomplPart6.Text = FormatoMonto(objInforme.MediaIncomplPart6)
        Me.lblMediaIncomplPart7.Text = FormatoMonto(objInforme.MediaIncomplPart7)
        Me.lblMediaIncomplPart8.Text = FormatoMonto(objInforme.MediaIncomplPart8)
        Me.lblMediaIncomplPart9.Text = FormatoMonto(objInforme.MediaIncomplPart9)
        Me.lblMediaIncomplPart10.Text = FormatoMonto(objInforme.MediaIncomplPart10)
        Me.lblMediaIncomplPart11.Text = FormatoMonto(objInforme.MediaIncomplPart11)
        Me.lblMediaIncomplPart12.Text = FormatoMonto(objInforme.MediaIncomplPart12)
        Me.lblTotalMediaIncomplPart.Text = FormatoMonto(objInforme.MediaIncomplPart1 + objInforme.MediaIncomplPart2 + objInforme.MediaIncomplPart3 + objInforme.MediaIncomplPart4 + objInforme.MediaIncomplPart5 + objInforme.MediaIncomplPart6 + objInforme.MediaIncomplPart7 + objInforme.MediaIncomplPart8 + objInforme.MediaIncomplPart9 + objInforme.MediaIncomplPart10 + objInforme.MediaIncomplPart11 + objInforme.MediaIncomplPart12)

        Me.lblMediaComplPart1.Text = FormatoMonto(objInforme.MediaComplPart1)
        Me.lblMediaComplPart2.Text = FormatoMonto(objInforme.MediaComplPart2)
        Me.lblMediaComplPart3.Text = FormatoMonto(objInforme.MediaComplPart3)
        Me.lblMediaComplPart4.Text = FormatoMonto(objInforme.MediaComplPart4)
        Me.lblMediaComplPart5.Text = FormatoMonto(objInforme.MediaComplPart5)
        Me.lblMediaComplPart6.Text = FormatoMonto(objInforme.MediaComplPart6)
        Me.lblMediaComplPart7.Text = FormatoMonto(objInforme.MediaComplPart7)
        Me.lblMediaComplPart8.Text = FormatoMonto(objInforme.MediaComplPart8)
        Me.lblMediaComplPart9.Text = FormatoMonto(objInforme.MediaComplPart9)
        Me.lblMediaComplPart10.Text = FormatoMonto(objInforme.MediaComplPart10)
        Me.lblMediaComplPart11.Text = FormatoMonto(objInforme.MediaComplPart11)
        Me.lblMediaComplPart12.Text = FormatoMonto(objInforme.MediaComplPart12)
        Me.lblTotalMediaComplPart.Text = FormatoMonto(objInforme.MediaComplPart1 + objInforme.MediaComplPart2 + objInforme.MediaComplPart3 + objInforme.MediaComplPart4 + objInforme.MediaComplPart5 + objInforme.MediaComplPart6 + objInforme.MediaComplPart7 + objInforme.MediaComplPart8 + objInforme.MediaComplPart9 + objInforme.MediaComplPart10 + objInforme.MediaComplPart11 + objInforme.MediaComplPart12)

        Me.lblTecnicaIncomplPart1.Text = FormatoMonto(objInforme.TecnicaIncoplPart1)
        Me.lblTecnicaIncomplPart2.Text = FormatoMonto(objInforme.TecnicaIncoplPart2)
        Me.lblTecnicaIncomplPart3.Text = FormatoMonto(objInforme.TecnicaIncoplPart3)
        Me.lblTecnicaIncomplPart4.Text = FormatoMonto(objInforme.TecnicaIncoplPart4)
        Me.lblTecnicaIncomplPart5.Text = FormatoMonto(objInforme.TecnicaIncoplPart5)
        Me.lblTecnicaIncomplPart6.Text = FormatoMonto(objInforme.TecnicaIncoplPart6)
        Me.lblTecnicaIncomplPart7.Text = FormatoMonto(objInforme.TecnicaIncoplPart7)
        Me.lblTecnicaIncomplPart8.Text = FormatoMonto(objInforme.TecnicaIncoplPart8)
        Me.lblTecnicaIncomplPart9.Text = FormatoMonto(objInforme.TecnicaIncoplPart9)
        Me.lblTecnicaIncomplPart10.Text = FormatoMonto(objInforme.TecnicaIncoplPart10)
        Me.lblTecnicaIncomplPart11.Text = FormatoMonto(objInforme.TecnicaIncoplPart11)
        Me.lblTecnicaIncomplPart12.Text = FormatoMonto(objInforme.TecnicaIncoplPart12)
        Me.lblTotalTecnicaIncomplPart.Text = FormatoMonto(objInforme.TecnicaIncoplPart1 + objInforme.TecnicaIncoplPart2 + objInforme.TecnicaIncoplPart3 + objInforme.TecnicaIncoplPart4 + objInforme.TecnicaIncoplPart5 + objInforme.TecnicaIncoplPart6 + objInforme.TecnicaIncoplPart7 + objInforme.TecnicaIncoplPart8 + objInforme.TecnicaIncoplPart9 + objInforme.TecnicaIncoplPart10 + objInforme.TecnicaIncoplPart11 + objInforme.TecnicaIncoplPart12)

        Me.lblTecnicaComplPart1.Text = FormatoMonto(objInforme.TenicaComplPart1)
        Me.lblTecnicaComplPart2.Text = FormatoMonto(objInforme.TenicaComplPart2)
        Me.lblTecnicaComplPart3.Text = FormatoMonto(objInforme.TenicaComplPart3)
        Me.lblTecnicaComplPart4.Text = FormatoMonto(objInforme.TenicaComplPart4)
        Me.lblTecnicaComplPart5.Text = FormatoMonto(objInforme.TenicaComplPart5)
        Me.lblTecnicaComplPart6.Text = FormatoMonto(objInforme.TenicaComplPart6)
        Me.lblTecnicaComplPart7.Text = FormatoMonto(objInforme.TenicaComplPart7)
        Me.lblTecnicaComplPart8.Text = FormatoMonto(objInforme.TenicaComplPart8)
        Me.lblTecnicaComplPart9.Text = FormatoMonto(objInforme.TenicaComplPart9)
        Me.lblTecnicaComplPart10.Text = FormatoMonto(objInforme.TenicaComplPart10)
        Me.lblTecnicaComplPart11.Text = FormatoMonto(objInforme.TenicaComplPart11)
        Me.lblTecnicaComplPart12.Text = FormatoMonto(objInforme.TenicaComplPart12)
        Me.lblTotalTecnicaComplPart.Text = FormatoMonto(objInforme.TenicaComplPart1 + objInforme.TenicaComplPart2 + objInforme.TenicaComplPart3 + objInforme.TenicaComplPart4 + objInforme.TenicaComplPart5 + objInforme.TenicaComplPart6 + objInforme.TenicaComplPart7 + objInforme.TenicaComplPart8 + objInforme.TenicaComplPart9 + objInforme.TenicaComplPart10 + objInforme.TenicaComplPart11 + objInforme.TenicaComplPart12)

        Me.lblUniversitarioIncomplPart1.Text = FormatoMonto(objInforme.UniversitarioIncomplpart1)
        Me.lblUniversitarioIncomplPart2.Text = FormatoMonto(objInforme.UniversitarioIncomplpart2)
        Me.lblUniversitarioIncomplPart3.Text = FormatoMonto(objInforme.UniversitarioIncomplpart3)
        Me.lblUniversitarioIncomplPart4.Text = FormatoMonto(objInforme.UniversitarioIncomplpart4)
        Me.lblUniversitarioIncomplPart5.Text = FormatoMonto(objInforme.UniversitarioIncomplpart5)
        Me.lblUniversitarioIncomplPart6.Text = FormatoMonto(objInforme.UniversitarioIncomplpart6)
        Me.lblUniversitarioIncomplPart7.Text = FormatoMonto(objInforme.UniversitarioIncomplpart7)
        Me.lblUniversitarioIncomplPart8.Text = FormatoMonto(objInforme.UniversitarioIncomplpart8)
        Me.lblUniversitarioIncomplPart9.Text = FormatoMonto(objInforme.UniversitarioIncomplpart9)
        Me.lblUniversitarioIncomplPart10.Text = FormatoMonto(objInforme.UniversitarioIncomplpart10)
        Me.lblUniversitarioIncomplPart11.Text = FormatoMonto(objInforme.UniversitarioIncomplpart11)
        Me.lblUniversitarioIncomplPart12.Text = FormatoMonto(objInforme.UniversitarioIncomplpart12)
        Me.lblTotalUniversitarioIncomplPart.Text = FormatoMonto(objInforme.UniversitarioIncomplpart1 + objInforme.UniversitarioIncomplpart2 + objInforme.UniversitarioIncomplpart3 + objInforme.UniversitarioIncomplpart4 + objInforme.UniversitarioIncomplpart5 + objInforme.UniversitarioIncomplpart6 + objInforme.UniversitarioIncomplpart7 + objInforme.UniversitarioIncomplpart8 + objInforme.UniversitarioIncomplpart9 + objInforme.UniversitarioIncomplpart10 + objInforme.UniversitarioIncomplpart11 + objInforme.UniversitarioIncomplpart12)

        Me.lblUniversitarioComplPart1.Text = FormatoMonto(objInforme.UniversitarioComplPart1)
        Me.lblUniversitarioComplPart2.Text = FormatoMonto(objInforme.UniversitarioComplPart2)
        Me.lblUniversitarioComplPart3.Text = FormatoMonto(objInforme.UniversitarioComplPart3)
        Me.lblUniversitarioComplPart4.Text = FormatoMonto(objInforme.UniversitarioComplPart4)
        Me.lblUniversitarioComplPart5.Text = FormatoMonto(objInforme.UniversitarioComplPart5)
        Me.lblUniversitarioComplPart6.Text = FormatoMonto(objInforme.UniversitarioComplPart6)
        Me.lblUniversitarioComplPart7.Text = FormatoMonto(objInforme.UniversitarioComplPart7)
        Me.lblUniversitarioComplPart8.Text = FormatoMonto(objInforme.UniversitarioComplPart8)
        Me.lblUniversitarioComplPart9.Text = FormatoMonto(objInforme.UniversitarioComplPart9)
        Me.lblUniversitarioComplPart10.Text = FormatoMonto(objInforme.UniversitarioComplPart10)
        Me.lblUniversitarioComplPart11.Text = FormatoMonto(objInforme.UniversitarioComplPart11)
        Me.lblUniversitarioComplPart12.Text = FormatoMonto(objInforme.UniversitarioComplPart12)
        Me.lblTotalUniversitarioComplPart.Text = FormatoMonto(objInforme.UniversitarioComplPart1 + objInforme.UniversitarioComplPart2 + objInforme.UniversitarioComplPart3 + objInforme.UniversitarioComplPart4 + objInforme.UniversitarioComplPart5 + objInforme.UniversitarioComplPart6 + objInforme.UniversitarioComplPart7 + objInforme.UniversitarioComplPart8 + objInforme.UniversitarioComplPart9 + objInforme.UniversitarioComplPart10 + objInforme.UniversitarioComplPart11 + objInforme.UniversitarioComplPart12)

        Me.lblParticipantes1.Text = FormatoMonto(objInforme.SinEScolaridadPart1 + objInforme.BasicaIncomplPart1 + objInforme.BasicaComplPart1 + objInforme.MediaIncomplPart1 + objInforme.MediaComplPart1 + objInforme.TecnicaIncoplPart1 + objInforme.TenicaComplPart1 + objInforme.UniversitarioIncomplpart1 + objInforme.UniversitarioComplPart1)
        Me.lblParticipantes2.Text = FormatoMonto(objInforme.SinEScolaridadPart2 + objInforme.BasicaIncomplPart2 + objInforme.BasicaComplPart2 + objInforme.MediaIncomplPart2 + objInforme.MediaComplPart2 + objInforme.TecnicaIncoplPart2 + objInforme.TenicaComplPart2 + objInforme.UniversitarioIncomplpart2 + objInforme.UniversitarioComplPart2)
        Me.lblParticipantes3.Text = FormatoMonto(objInforme.SinEScolaridadPart3 + objInforme.BasicaIncomplPart3 + objInforme.BasicaComplPart3 + objInforme.MediaIncomplPart3 + objInforme.MediaComplPart3 + objInforme.TecnicaIncoplPart3 + objInforme.TenicaComplPart3 + objInforme.UniversitarioIncomplpart3 + objInforme.UniversitarioComplPart3)
        Me.lblParticipantes4.Text = FormatoMonto(objInforme.SinEScolaridadPart4 + objInforme.BasicaIncomplPart4 + objInforme.BasicaComplPart4 + objInforme.MediaIncomplPart4 + objInforme.MediaComplPart4 + objInforme.TecnicaIncoplPart4 + objInforme.TenicaComplPart4 + objInforme.UniversitarioIncomplpart4 + objInforme.UniversitarioComplPart4)
        Me.lblParticipantes5.Text = FormatoMonto(objInforme.SinEScolaridadPart5 + objInforme.BasicaIncomplPart5 + objInforme.BasicaComplPart5 + objInforme.MediaIncomplPart5 + objInforme.MediaComplPart5 + objInforme.TecnicaIncoplPart5 + objInforme.TenicaComplPart5 + objInforme.UniversitarioIncomplpart5 + objInforme.UniversitarioComplPart5)
        Me.lblParticipantes6.Text = FormatoMonto(objInforme.SinEScolaridadPart6 + objInforme.BasicaIncomplPart6 + objInforme.BasicaComplPart6 + objInforme.MediaIncomplPart6 + objInforme.MediaComplPart6 + objInforme.TecnicaIncoplPart6 + objInforme.TenicaComplPart6 + objInforme.UniversitarioIncomplpart6 + objInforme.UniversitarioComplPart6)
        Me.lblParticipantes7.Text = FormatoMonto(objInforme.SinEScolaridadPart7 + objInforme.BasicaIncomplPart7 + objInforme.BasicaComplPart7 + objInforme.MediaIncomplPart7 + objInforme.MediaComplPart7 + objInforme.TecnicaIncoplPart7 + objInforme.TenicaComplPart7 + objInforme.UniversitarioIncomplpart7 + objInforme.UniversitarioComplPart7)
        Me.lblParticipantes8.Text = FormatoMonto(objInforme.SinEScolaridadPart8 + objInforme.BasicaIncomplPart8 + objInforme.BasicaComplPart8 + objInforme.MediaIncomplPart8 + objInforme.MediaComplPart8 + objInforme.TecnicaIncoplPart8 + objInforme.TenicaComplPart8 + objInforme.UniversitarioIncomplpart8 + objInforme.UniversitarioComplPart8)
        Me.lblParticipantes9.Text = FormatoMonto(objInforme.SinEScolaridadPart9 + objInforme.BasicaIncomplPart9 + objInforme.BasicaComplPart9 + objInforme.MediaIncomplPart9 + objInforme.MediaComplPart9 + objInforme.TecnicaIncoplPart9 + objInforme.TenicaComplPart9 + objInforme.UniversitarioIncomplpart9 + objInforme.UniversitarioComplPart9)
        Me.lblParticipantes10.Text = FormatoMonto(objInforme.SinEScolaridadPart10 + objInforme.BasicaIncomplPart10 + objInforme.BasicaComplPart10 + objInforme.MediaIncomplPart10 + objInforme.MediaComplPart10 + objInforme.TecnicaIncoplPart10 + objInforme.TenicaComplPart10 + objInforme.UniversitarioIncomplpart10 + objInforme.UniversitarioComplPart10)
        Me.lblParticipantes11.Text = FormatoMonto(objInforme.SinEScolaridadPart11 + objInforme.BasicaIncomplPart11 + objInforme.BasicaComplPart11 + objInforme.MediaIncomplPart11 + objInforme.MediaComplPart11 + objInforme.TecnicaIncoplPart11 + objInforme.TenicaComplPart11 + objInforme.UniversitarioIncomplpart11 + objInforme.UniversitarioComplPart11)
        Me.lblParticipantes12.Text = FormatoMonto(objInforme.SinEScolaridadPart12 + objInforme.BasicaIncomplPart12 + objInforme.BasicaComplPart12 + objInforme.MediaIncomplPart12 + objInforme.MediaComplPart12 + objInforme.TecnicaIncoplPart12 + objInforme.TenicaComplPart12 + objInforme.UniversitarioIncomplpart12 + objInforme.UniversitarioComplPart12)
        Me.lblTotalParticipantes.Text = FormatoMonto(objInforme.TotalParticipantes)

        '****************************

        Me.lblSinEscolaridadHH1.Text = FormatoMonto(objInforme.SinEScolaridadHH1)
        Me.lblSinEscolaridadHH2.Text = FormatoMonto(objInforme.SinEScolaridadHH2)
        Me.lblSinEscolaridadHH3.Text = FormatoMonto(objInforme.SinEScolaridadHH3)
        Me.lblSinEscolaridadHH4.Text = FormatoMonto(objInforme.SinEScolaridadHH4)
        Me.lblSinEscolaridadHH5.Text = FormatoMonto(objInforme.SinEScolaridadHH5)
        Me.lblSinEscolaridadHH6.Text = FormatoMonto(objInforme.SinEScolaridadHH6)
        Me.lblSinEscolaridadHH7.Text = FormatoMonto(objInforme.SinEScolaridadHH7)
        Me.lblSinEscolaridadHH8.Text = FormatoMonto(objInforme.SinEScolaridadHH8)
        Me.lblSinEscolaridadHH9.Text = FormatoMonto(objInforme.SinEScolaridadHH9)
        Me.lblSinEscolaridadHH10.Text = FormatoMonto(objInforme.SinEScolaridadHH10)
        Me.lblSinEscolaridadHH11.Text = FormatoMonto(objInforme.SinEScolaridadHH11)
        Me.lblSinEscolaridadHH12.Text = FormatoMonto(objInforme.SinEScolaridadHH12)
        Me.lblTotalSinEscolaridadHH.Text = FormatoMonto(objInforme.SinEScolaridadHH1 + objInforme.SinEScolaridadHH2 + objInforme.SinEScolaridadHH3 + objInforme.SinEScolaridadHH4 + objInforme.SinEScolaridadHH5 + objInforme.SinEScolaridadHH6 + objInforme.SinEScolaridadHH7 + objInforme.SinEScolaridadHH8 + objInforme.SinEScolaridadHH9 + objInforme.SinEScolaridadHH10 + objInforme.SinEScolaridadHH11 + objInforme.SinEScolaridadHH12)

        Me.lblBasicaIncomplHH1.Text = FormatoMonto(objInforme.BasicaIncomplHH1)
        Me.lblBasicaIncomplHH2.Text = FormatoMonto(objInforme.BasicaIncomplHH2)
        Me.lblBasicaIncomplHH3.Text = FormatoMonto(objInforme.BasicaIncomplHH3)
        Me.lblBasicaIncomplHH4.Text = FormatoMonto(objInforme.BasicaIncomplHH4)
        Me.lblBasicaIncomplHH5.Text = FormatoMonto(objInforme.BasicaIncomplHH5)
        Me.lblBasicaIncomplHH6.Text = FormatoMonto(objInforme.BasicaIncomplHH6)
        Me.lblBasicaIncomplHH7.Text = FormatoMonto(objInforme.BasicaIncomplHH7)
        Me.lblBasicaIncomplHH8.Text = FormatoMonto(objInforme.BasicaIncomplHH8)
        Me.lblBasicaIncomplHH9.Text = FormatoMonto(objInforme.BasicaIncomplHH9)
        Me.lblBasicaIncomplHH10.Text = FormatoMonto(objInforme.BasicaIncomplHH10)
        Me.lblBasicaIncomplHH11.Text = FormatoMonto(objInforme.BasicaIncomplHH11)
        Me.lblBasicaIncomplHH12.Text = FormatoMonto(objInforme.BasicaIncomplHH12)
        Me.lblTotalBasicaIncomplHH.Text = FormatoMonto(objInforme.BasicaIncomplHH1 + objInforme.BasicaIncomplHH2 + objInforme.BasicaIncomplHH3 + objInforme.BasicaIncomplHH4 + objInforme.BasicaIncomplHH5 + objInforme.BasicaIncomplHH6 + objInforme.BasicaIncomplHH7 + objInforme.BasicaIncomplHH8 + objInforme.BasicaIncomplHH9 + objInforme.BasicaIncomplHH10 + objInforme.BasicaIncomplHH11 + objInforme.BasicaIncomplHH12)

        Me.lblBasicaComplHH1.Text = FormatoMonto(objInforme.BasicaComplHH1)
        Me.lblBasicaComplHH2.Text = FormatoMonto(objInforme.BasicaComplHH2)
        Me.lblBasicaComplHH3.Text = FormatoMonto(objInforme.BasicaComplHH3)
        Me.lblBasicaComplHH4.Text = FormatoMonto(objInforme.BasicaComplHH4)
        Me.lblBasicaComplHH5.Text = FormatoMonto(objInforme.BasicaComplHH5)
        Me.lblBasicaComplHH6.Text = FormatoMonto(objInforme.BasicaComplHH6)
        Me.lblBasicaComplHH7.Text = FormatoMonto(objInforme.BasicaComplHH7)
        Me.lblBasicaComplHH8.Text = FormatoMonto(objInforme.BasicaComplHH8)
        Me.lblBasicaComplHH9.Text = FormatoMonto(objInforme.BasicaComplHH9)
        Me.lblBasicaComplHH10.Text = FormatoMonto(objInforme.BasicaComplHH10)
        Me.lblBasicaComplHH11.Text = FormatoMonto(objInforme.BasicaComplHH11)
        Me.lblBasicaComplHH12.Text = FormatoMonto(objInforme.BasicaComplHH12)
        Me.lblTotalBasicaComplHH.Text = FormatoMonto(objInforme.BasicaComplHH1 + objInforme.BasicaComplHH2 + objInforme.BasicaComplHH3 + objInforme.BasicaComplHH4 + objInforme.BasicaComplHH5 + objInforme.BasicaComplHH6 + objInforme.BasicaComplHH7 + objInforme.BasicaComplHH8 + objInforme.BasicaComplHH9 + objInforme.BasicaComplHH10 + objInforme.BasicaComplHH11 + objInforme.BasicaComplHH12)

        Me.lblMediaIncomplHH1.Text = FormatoMonto(objInforme.MediaIncomplHH1)
        Me.lblMediaIncomplHH2.Text = FormatoMonto(objInforme.MediaIncomplHH2)
        Me.lblMediaIncomplHH3.Text = FormatoMonto(objInforme.MediaIncomplHH3)
        Me.lblMediaIncomplHH4.Text = FormatoMonto(objInforme.MediaIncomplHH4)
        Me.lblMediaIncomplHH5.Text = FormatoMonto(objInforme.MediaIncomplHH5)
        Me.lblMediaIncomplHH6.Text = FormatoMonto(objInforme.MediaIncomplHH6)
        Me.lblMediaIncomplHH7.Text = FormatoMonto(objInforme.MediaIncomplHH7)
        Me.lblMediaIncomplHH8.Text = FormatoMonto(objInforme.MediaIncomplHH8)
        Me.lblMediaIncomplHH9.Text = FormatoMonto(objInforme.MediaIncomplHH9)
        Me.lblMediaIncomplHH10.Text = FormatoMonto(objInforme.MediaIncomplHH10)
        Me.lblMediaIncomplHH11.Text = FormatoMonto(objInforme.MediaIncomplHH11)
        Me.lblMediaIncomplHH12.Text = FormatoMonto(objInforme.MediaIncomplHH12)
        Me.lblTotalMediaIncomplHH.Text = FormatoMonto(objInforme.MediaIncomplHH1 + objInforme.MediaIncomplHH2 + objInforme.MediaIncomplHH3 + objInforme.MediaIncomplHH4 + objInforme.MediaIncomplHH5 + objInforme.MediaIncomplHH6 + objInforme.MediaIncomplHH7 + objInforme.MediaIncomplHH8 + objInforme.MediaIncomplHH9 + objInforme.MediaIncomplHH10 + objInforme.MediaIncomplHH11 + objInforme.MediaIncomplHH12)

        Me.lblMediaComplHH1.Text = FormatoMonto(objInforme.MediaComplHH1)
        Me.lblMediaComplHH2.Text = FormatoMonto(objInforme.MediaComplHH2)
        Me.lblMediaComplHH3.Text = FormatoMonto(objInforme.MediaComplHH3)
        Me.lblMediaComplHH4.Text = FormatoMonto(objInforme.MediaComplHH4)
        Me.lblMediaComplHH5.Text = FormatoMonto(objInforme.MediaComplHH5)
        Me.lblMediaComplHH6.Text = FormatoMonto(objInforme.MediaComplHH6)
        Me.lblMediaComplHH7.Text = FormatoMonto(objInforme.MediaComplHH7)
        Me.lblMediaComplHH8.Text = FormatoMonto(objInforme.MediaComplHH8)
        Me.lblMediaComplHH9.Text = FormatoMonto(objInforme.MediaComplHH9)
        Me.lblMediaComplHH10.Text = FormatoMonto(objInforme.MediaComplHH10)
        Me.lblMediaComplHH11.Text = FormatoMonto(objInforme.MediaComplHH11)
        Me.lblMediaComplHH12.Text = FormatoMonto(objInforme.MediaComplHH12)
        Me.lblTotalMediaComplHH.Text = FormatoMonto(objInforme.MediaComplHH1 + objInforme.MediaComplHH2 + objInforme.MediaComplHH3 + objInforme.MediaComplHH4 + objInforme.MediaComplHH5 + objInforme.MediaComplHH6 + objInforme.MediaComplHH7 + objInforme.MediaComplHH8 + objInforme.MediaComplHH9 + objInforme.MediaComplHH10 + objInforme.MediaComplHH11 + objInforme.MediaComplHH12)

        Me.lblTecnicaIncomplHH1.Text = FormatoMonto(objInforme.TecnicaIncoplHH1)
        Me.lblTecnicaIncomplHH2.Text = FormatoMonto(objInforme.TecnicaIncoplHH2)
        Me.lblTecnicaIncomplHH3.Text = FormatoMonto(objInforme.TecnicaIncoplHH3)
        Me.lblTecnicaIncomplHH4.Text = FormatoMonto(objInforme.TecnicaIncoplHH4)
        Me.lblTecnicaIncomplHH5.Text = FormatoMonto(objInforme.TecnicaIncoplHH5)
        Me.lblTecnicaIncomplHH6.Text = FormatoMonto(objInforme.TecnicaIncoplHH6)
        Me.lblTecnicaIncomplHH7.Text = FormatoMonto(objInforme.TecnicaIncoplHH7)
        Me.lblTecnicaIncomplHH8.Text = FormatoMonto(objInforme.TecnicaIncoplHH8)
        Me.lblTecnicaIncomplHH9.Text = FormatoMonto(objInforme.TecnicaIncoplHH9)
        Me.lblTecnicaIncomplHH10.Text = FormatoMonto(objInforme.TecnicaIncoplHH10)
        Me.lblTecnicaIncomplHH11.Text = FormatoMonto(objInforme.TecnicaIncoplHH11)
        Me.lblTecnicaIncomplHH12.Text = FormatoMonto(objInforme.TecnicaIncoplHH12)
        Me.lblTotalTecnicaIncomplHH.Text = FormatoMonto(objInforme.TecnicaIncoplHH1 + objInforme.TecnicaIncoplHH2 + objInforme.TecnicaIncoplHH3 + objInforme.TecnicaIncoplHH4 + objInforme.TecnicaIncoplHH5 + objInforme.TecnicaIncoplHH6 + objInforme.TecnicaIncoplHH7 + objInforme.TecnicaIncoplHH8 + objInforme.TecnicaIncoplHH9 + objInforme.TecnicaIncoplHH10 + objInforme.TecnicaIncoplHH11 + objInforme.TecnicaIncoplHH12)

        Me.lblTecnicaComplHH1.Text = FormatoMonto(objInforme.TenicaComplHH1)
        Me.lblTecnicaComplHH2.Text = FormatoMonto(objInforme.TenicaComplHH2)
        Me.lblTecnicaComplHH3.Text = FormatoMonto(objInforme.TenicaComplHH3)
        Me.lblTecnicaComplHH4.Text = FormatoMonto(objInforme.TenicaComplHH4)
        Me.lblTecnicaComplHH5.Text = FormatoMonto(objInforme.TenicaComplHH5)
        Me.lblTecnicaComplHH6.Text = FormatoMonto(objInforme.TenicaComplHH6)
        Me.lblTecnicaComplHH7.Text = FormatoMonto(objInforme.TenicaComplHH7)
        Me.lblTecnicaComplHH8.Text = FormatoMonto(objInforme.TenicaComplHH8)
        Me.lblTecnicaComplHH9.Text = FormatoMonto(objInforme.TenicaComplHH9)
        Me.lblTecnicaComplHH10.Text = FormatoMonto(objInforme.TenicaComplHH10)
        Me.lblTecnicaComplHH11.Text = FormatoMonto(objInforme.TenicaComplHH11)
        Me.lblTecnicaComplHH12.Text = FormatoMonto(objInforme.TenicaComplHH12)
        Me.lblTotalTecnicaComplHH.Text = FormatoMonto(objInforme.TenicaComplHH1 + objInforme.TenicaComplHH2 + objInforme.TenicaComplHH3 + objInforme.TenicaComplHH4 + objInforme.TenicaComplHH5 + objInforme.TenicaComplHH6 + objInforme.TenicaComplHH7 + objInforme.TenicaComplHH8 + objInforme.TenicaComplHH9 + objInforme.TenicaComplHH10 + objInforme.TenicaComplHH11 + objInforme.TenicaComplHH12)

        Me.lblUniversitarioIncomplHH1.Text = FormatoMonto(objInforme.UniversitarioIncomplHH1)
        Me.lblUniversitarioIncomplHH2.Text = FormatoMonto(objInforme.UniversitarioIncomplHH2)
        Me.lblUniversitarioIncomplHH3.Text = FormatoMonto(objInforme.UniversitarioIncomplHH3)
        Me.lblUniversitarioIncomplHH4.Text = FormatoMonto(objInforme.UniversitarioIncomplHH4)
        Me.lblUniversitarioIncomplHH5.Text = FormatoMonto(objInforme.UniversitarioIncomplHH5)
        Me.lblUniversitarioIncomplHH6.Text = FormatoMonto(objInforme.UniversitarioIncomplHH6)
        Me.lblUniversitarioIncomplHH7.Text = FormatoMonto(objInforme.UniversitarioIncomplHH7)
        Me.lblUniversitarioIncomplHH8.Text = FormatoMonto(objInforme.UniversitarioIncomplHH8)
        Me.lblUniversitarioIncomplHH9.Text = FormatoMonto(objInforme.UniversitarioIncomplHH9)
        Me.lblUniversitarioIncomplHH10.Text = FormatoMonto(objInforme.UniversitarioIncomplHH10)
        Me.lblUniversitarioIncomplHH11.Text = FormatoMonto(objInforme.UniversitarioIncomplHH11)
        Me.lblUniversitarioIncomplHH12.Text = FormatoMonto(objInforme.UniversitarioIncomplHH12)
        Me.lblTotalUniversitarioIncomplHH.Text = FormatoMonto(objInforme.UniversitarioIncomplHH1 + objInforme.UniversitarioIncomplHH2 + objInforme.UniversitarioIncomplHH3 + objInforme.UniversitarioIncomplHH4 + objInforme.UniversitarioIncomplHH5 + objInforme.UniversitarioIncomplHH6 + objInforme.UniversitarioIncomplHH7 + objInforme.UniversitarioIncomplHH8 + objInforme.UniversitarioIncomplHH9 + objInforme.UniversitarioIncomplHH10 + objInforme.UniversitarioIncomplHH11 + objInforme.UniversitarioIncomplHH12)

        Me.lblUniversitarioComplHH1.Text = FormatoMonto(objInforme.UniversitarioComplHH1)
        Me.lblUniversitarioComplHH2.Text = FormatoMonto(objInforme.UniversitarioComplHH2)
        Me.lblUniversitarioComplHH3.Text = FormatoMonto(objInforme.UniversitarioComplHH3)
        Me.lblUniversitarioComplHH4.Text = FormatoMonto(objInforme.UniversitarioComplHH4)
        Me.lblUniversitarioComplHH5.Text = FormatoMonto(objInforme.UniversitarioComplHH5)
        Me.lblUniversitarioComplHH6.Text = FormatoMonto(objInforme.UniversitarioComplHH6)
        Me.lblUniversitarioComplHH7.Text = FormatoMonto(objInforme.UniversitarioComplHH7)
        Me.lblUniversitarioComplHH8.Text = FormatoMonto(objInforme.UniversitarioComplHH8)
        Me.lblUniversitarioComplHH9.Text = FormatoMonto(objInforme.UniversitarioComplHH9)
        Me.lblUniversitarioComplHH10.Text = FormatoMonto(objInforme.UniversitarioComplHH10)
        Me.lblUniversitarioComplHH11.Text = FormatoMonto(objInforme.UniversitarioComplHH11)
        Me.lblUniversitarioComplHH12.Text = FormatoMonto(objInforme.UniversitarioComplHH12)
        Me.lblTotalUniversitarioComplHH.Text = FormatoMonto(objInforme.UniversitarioComplHH1 + objInforme.UniversitarioComplHH2 + objInforme.UniversitarioComplHH3 + objInforme.UniversitarioComplHH4 + objInforme.UniversitarioComplHH5 + objInforme.UniversitarioComplHH6 + objInforme.UniversitarioComplHH7 + objInforme.UniversitarioComplHH8 + objInforme.UniversitarioComplHH9 + objInforme.UniversitarioComplHH10 + objInforme.UniversitarioComplHH11 + objInforme.UniversitarioComplHH12)

        Me.lblHorasHombre1.Text = FormatoMonto(objInforme.SinEScolaridadHH1 + objInforme.BasicaIncomplHH1 + objInforme.BasicaComplHH1 + objInforme.MediaIncomplHH1 + objInforme.MediaComplHH1 + objInforme.TecnicaIncoplHH1 + objInforme.TenicaComplHH1 + objInforme.UniversitarioIncomplHH1 + objInforme.UniversitarioComplHH1)
        Me.lblHorasHombre2.Text = FormatoMonto(objInforme.SinEScolaridadHH2 + objInforme.BasicaIncomplHH2 + objInforme.BasicaComplHH2 + objInforme.MediaIncomplHH2 + objInforme.MediaComplHH2 + objInforme.TecnicaIncoplHH2 + objInforme.TenicaComplHH2 + objInforme.UniversitarioIncomplHH2 + objInforme.UniversitarioComplHH2)
        Me.lblHorasHombre3.Text = FormatoMonto(objInforme.SinEScolaridadHH3 + objInforme.BasicaIncomplHH3 + objInforme.BasicaComplHH3 + objInforme.MediaIncomplHH3 + objInforme.MediaComplHH3 + objInforme.TecnicaIncoplHH3 + objInforme.TenicaComplHH3 + objInforme.UniversitarioIncomplHH3 + objInforme.UniversitarioComplHH3)
        Me.lblHorasHombre4.Text = FormatoMonto(objInforme.SinEScolaridadHH4 + objInforme.BasicaIncomplHH4 + objInforme.BasicaComplHH4 + objInforme.MediaIncomplHH4 + objInforme.MediaComplHH4 + objInforme.TecnicaIncoplHH4 + objInforme.TenicaComplHH4 + objInforme.UniversitarioIncomplHH4 + objInforme.UniversitarioComplHH4)
        Me.lblHorasHombre5.Text = FormatoMonto(objInforme.SinEScolaridadHH5 + objInforme.BasicaIncomplHH5 + objInforme.BasicaComplHH5 + objInforme.MediaIncomplHH5 + objInforme.MediaComplHH5 + objInforme.TecnicaIncoplHH5 + objInforme.TenicaComplHH5 + objInforme.UniversitarioIncomplHH5 + objInforme.UniversitarioComplHH5)
        Me.lblHorasHombre6.Text = FormatoMonto(objInforme.SinEScolaridadHH6 + objInforme.BasicaIncomplHH6 + objInforme.BasicaComplHH6 + objInforme.MediaIncomplHH6 + objInforme.MediaComplHH6 + objInforme.TecnicaIncoplHH6 + objInforme.TenicaComplHH6 + objInforme.UniversitarioIncomplHH6 + objInforme.UniversitarioComplHH6)
        Me.lblHorasHombre7.Text = FormatoMonto(objInforme.SinEScolaridadHH7 + objInforme.BasicaIncomplHH7 + objInforme.BasicaComplHH7 + objInforme.MediaIncomplHH7 + objInforme.MediaComplHH7 + objInforme.TecnicaIncoplHH7 + objInforme.TenicaComplHH7 + objInforme.UniversitarioIncomplHH7 + objInforme.UniversitarioComplHH7)
        Me.lblHorasHombre8.Text = FormatoMonto(objInforme.SinEScolaridadHH8 + objInforme.BasicaIncomplHH8 + objInforme.BasicaComplHH8 + objInforme.MediaIncomplHH8 + objInforme.MediaComplHH8 + objInforme.TecnicaIncoplHH8 + objInforme.TenicaComplHH8 + objInforme.UniversitarioIncomplHH8 + objInforme.UniversitarioComplHH8)
        Me.lblHorasHombre9.Text = FormatoMonto(objInforme.SinEScolaridadHH9 + objInforme.BasicaIncomplHH9 + objInforme.BasicaComplHH9 + objInforme.MediaIncomplHH9 + objInforme.MediaComplHH9 + objInforme.TecnicaIncoplHH9 + objInforme.TenicaComplHH9 + objInforme.UniversitarioIncomplHH9 + objInforme.UniversitarioComplHH9)
        Me.lblHorasHombre10.Text = FormatoMonto(objInforme.SinEScolaridadHH10 + objInforme.BasicaIncomplHH10 + objInforme.BasicaComplHH10 + objInforme.MediaIncomplHH10 + objInforme.MediaComplHH10 + objInforme.TecnicaIncoplHH10 + objInforme.TenicaComplHH10 + objInforme.UniversitarioIncomplHH10 + objInforme.UniversitarioComplHH10)
        Me.lblHorasHombre11.Text = FormatoMonto(objInforme.SinEScolaridadHH11 + objInforme.BasicaIncomplHH11 + objInforme.BasicaComplHH11 + objInforme.MediaIncomplHH11 + objInforme.MediaComplHH11 + objInforme.TecnicaIncoplHH11 + objInforme.TenicaComplHH11 + objInforme.UniversitarioIncomplHH11 + objInforme.UniversitarioComplHH11)
        Me.lblHorasHombre12.Text = FormatoMonto(objInforme.SinEScolaridadHH12 + objInforme.BasicaIncomplHH12 + objInforme.BasicaComplHH12 + objInforme.MediaIncomplHH12 + objInforme.MediaComplHH12 + objInforme.TecnicaIncoplHH12 + objInforme.TenicaComplHH12 + objInforme.UniversitarioIncomplHH12 + objInforme.UniversitarioComplHH12)
        Me.lblTotalHorasHombre.Text = FormatoMonto(objInforme.TotalHorasHombre)




    End Sub

    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Consultar()
    End Sub
End Class
