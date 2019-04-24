Imports Clases
Imports Clases.Web
Imports Modulos
Imports System.Data
Partial Class modulo_cursos_carga_cursos_mdb
    Inherits System.Web.UI.Page
    Private ObjCarga As New CCargaCursosMDB
    Private objSession As CSession
    Private objWeb As CWeb

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '**************Session***************
        objWeb = New CWeb
        objWeb.ChequeaSession(objSession)
        'If Not objSession.AccesoObjeto(20) Then
        '    Response.Redirect("../Acceso_Denegado.aspx")
        '    Exit Sub
        'End If
        '************************************
        Try
            If Not Page.IsPostBack Then
                lblPie.Text = Parametros.p_PIE
                objWeb = New CWeb
                objWeb.SeteaGrilla(grdLogs, TAM_PAG)
                If ViewState("PaginasAtras") Is Nothing Then
                    ViewState("PaginasAtras") = 1
                End If
            Else
                ViewState("PaginasAtras") = ViewState("PaginasAtras") + 1

            End If

            Me.btnVolver.OnClientClick = "javascript:window.history.go(-" & ViewState("PaginasAtras") & ");return false;"

        Catch ex As Exception
            EnviaError("carga_cursos_mdb:Page_Load-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnCarga_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCarga.Click
        Try
            Dim fileName As String
            Dim savePath As String = Server.MapPath("~/contenido/tmp/")
            fileName = Me.fulCarga.FileName

            If Me.fulCarga.HasFile Then
                If fileName.Substring(fileName.Length - 3).ToLower = "mdb" Then
                    fileName = NombreArchivoTmp("mdb")
                    savePath += fileName
                    Me.fulCarga.SaveAs(savePath) 'graba archivo
                    ObjCarga.Archivo = savePath
                    ObjCarga.NombreUsuario = objSession.Nombre
                    ObjCarga.EmailUsuario = objSession.Email
                    If objSession.EsAdmin _
                    Or objSession.EsEjecutivo _
                    Or objSession.EsOperaciones _
                    Or objSession.EsSupervisor And Not objSession.EsCliente Then
                        ObjCarga.Inicializar(objSession.Rut)
                        ObjCarga.RutEmpresaUsuario = objSession.Rut
                        ObjCarga.RestringirCursoEmpresa = True
                    Else
                        ObjCarga.Inicializar(-1)
                        ObjCarga.RutEmpresaUsuario = -1
                        ObjCarga.RestringirCursoEmpresa = False
                    End If
                    ObjCarga.RestringirCursoEmpresa = False
                    ObjCarga.CargarCursos()
                    objWeb.LlenaGrilla(Me.grdLogs, ObjCarga.DtLog)

                    If ObjCarga.Filas > 0 Then
                        hlkBajar.Target = "_Blank"
                        hlkBajar.Text = "Botón Derecho: " & Chr(34) & "Guardar Destino Como..." & Chr(34) & " Puede abrirlo en EXCEL."
                        hlkBajar.NavigateUrl = ObjCarga.ArchivoXml
                        hlkBajar.Visible = True
                    End If
                Else
                    Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " & _
                          "alert('¡ATENCIÓN: El archivo debe ser en formato MDB!');" & _
                          "</script>")
                End If
            End If
        Catch ex As Exception
            EnviaError("carga_cursos_mdb:btnCarga_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click

    End Sub
End Class
