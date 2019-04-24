Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class menu
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objSessionCliente As CSession

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        objWeb.ChequeaCliente(objSessionCliente)
        If Not Page.IsPostBack Then
            lblPie.Text = Parametros.p_PIE
            'Ingreso a modulo de administracion 
            'If objSession.EsAdmin Then
            '    Me.liModAdm.Visible = True
            'Else
            '    Me.liModAdm.Visible = False
            'End If
            'Ingreso a modulo de cuentas
            'If objSession.EsCliente Or objSession.EsOperaciones Or objSession.EsEjecutivo Or objSession.EsSupervisor Or objSession.EsDirectorSucursal Or objSession.EsEjecutivoReg Or objSession.EsEjecutivoAutorizacion Then
            '    Me.liModCue.Visible = True
            'Else
            '    Me.liModCue.Visible = False
            'End If
            'Ingreso de cursos de clientes
            'If objSession.EsClienteIngresoCurso Then
            '    Me.liModCueCurso.Visible = True
            'Else
            '    Me.liModCueCurso.Visible = False
            'End If
            ''Ingreso a módulo de gestión
            'If objSession.EsGestion Or objSession.EsDirector Or objSession.EsDirectorSucursal Then
            '    Me.liModGes.Visible = True
            'Else
            '    Me.liModGes.Visible = False
            'End If
            ''Ingreso a modulo de cursos
            If objSession.EsOperaciones Or objSession.EsEjecutivo Or objSession.EsSupervisor Or objSession.EsEjecutivoReg Or objSession.EsEjecutivoAutorizacion Then
                Me.liModCur.Visible = True
            Else
                Me.liModCur.Visible = False
            End If
            '' Ingreso a modulo de aportes
            If objSession.EsOperaciones Or objSession.EsSupervisor Or objSession.EsFinanzas Or objSession.EsFinanzaRegiones Then
                Me.liModApo.Visible = True
            Else
                Me.liModApo.Visible = False
            End If
            If objSession.EsCliente Then
                Me.liModAdm.Visible = False
                Me.liModGes.Visible = False

            End If

            'If objSession.EsEjecutivo Then
            '    'Me.liModAdm.Visible = True
            'End If

            objSession = Nothing

        End If

    End Sub
End Class
