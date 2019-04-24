Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_administracion_carga_asistencia
    Inherits System.Web.UI.Page
    Dim objManteAsistencia As CCargaAsistencia
    Dim objWeb As New CWeb
    Dim objLookup As New Clookups

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            objWeb.LlenaDDL(Me.ddlAgno, objLookup.Agnos2, "Agno_v", "Agno_t")
        End If
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        objManteAsistencia = New CCargaAsistencia
        'Dim lngCodCurso As Long
        'Dim lngRutUsuario As Long
        'lngCodCurso = ViewState("CodCurso")
        'lngRutUsuario = ViewState("RutUsuario")
        'objManteAsistencia.CodCurso = lngCodCurso
        'objManteAsistencia.RutUsuario = lngRutUsuario
        Dim fileName As String
        Dim savePath As String = Server.MapPath("~/contenido/tmp/")
        fileName = fulAsistencia.FileName
        savePath += fileName
        If fulAsistencia.HasFile Then
            If fileName.Substring(fileName.Length - 3) = "xls" Then
                fileName = NombreArchivoTmp("xls")
                Me.fulAsistencia.SaveAs(savePath)
                objManteAsistencia.CargaArchivo(savePath, ddlAgno.SelectedValue)
                'objWeb = New CWeb
                'objWeb.LlenaGrilla(Me.grdAsistencia, objManteAsistencia.DtParticipantes)
            Else
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " & _
                      "alert('¡Error con el formato del archivo tiene que ser un txt!');" & _
                      "</script>")
            End If
        End If
    End Sub
End Class
