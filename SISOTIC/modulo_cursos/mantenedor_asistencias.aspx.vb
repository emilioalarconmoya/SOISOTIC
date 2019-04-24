Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Partial Class modulo_cursos_mantenedor_asistencias
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objManteAsistencia As CMantenedorAsistencias

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            If Not Page.IsPostBack Then
                Me.lblPie.Text = Parametros.p_PIE
                ViewState("CodCurso") = Request("codCurso")
                ViewState("RutUsuario") = objSession.Rut
                ViewState("CodEstado") = Request("codEstado")
                btnIngresar.Attributes.Add("onClick", "return ConfirmDelete();")
                Consultar()
            End If
            body.Attributes.Clear()
        Catch ex As Exception
            EnviaError("mantenedor_asistencias:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Public Sub Consultar()
        objManteAsistencia = New CMantenedorAsistencias
        Dim lngCodCurso As Long
        lngCodCurso = ViewState("CodCurso")
        objManteAsistencia.CodCurso = lngCodCurso
        objManteAsistencia.Agno = objSession.Agno
        Dim dt As DataTable
        dt = objManteAsistencia.ListadoParticipantes
        hdfNumParticipantes.Value = objManteAsistencia.NumAlumnos
        Me.lblCorrelativo.Text = objManteAsistencia.Correlativo
        objWeb = New CWeb
        objWeb.LlenaGrilla(grdAsistencia, dt)
        Dim grdRow As GridViewRow
        For Each grdRow In grdAsistencia.Rows
            Dim txtAsistencia As TextBox
            txtAsistencia = CType(grdRow.FindControl("txtAsistencia"), TextBox)
            Dim txtNotaObtenida As TextBox
            txtNotaObtenida = CType(grdRow.FindControl("txtNotaObtenida"), TextBox)
            'If ViewState("CodEstado") = 4 Then
            '    txtAsistencia.Text = 100
            'End If
            'txtAsistencia = CType(grdRow.FindControl("txtAsistencia"), TextBox)
            'If txtAsistencia.Text <= 75 Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: Los alumnos con un porcentaje de asistencia\ninferior a 75% no serán cubiertos por SENCE');")
            'End If
        Next
    End Sub

    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        objManteAsistencia = New CMantenedorAsistencias
        Dim lngCodCurso As Long
        Dim lngRutUsuario As Long
        lngCodCurso = ViewState("CodCurso")
        lngRutUsuario = ViewState("RutUsuario")
        objManteAsistencia.CodCurso = lngCodCurso
        objManteAsistencia.RutUsuario = lngRutUsuario
        Dim grdRow As GridViewRow
        Dim grdRow2 As GridViewRow
        Dim dblPorcentaje As Double
        Dim lngRutAlumno As Long
        Dim blnProceso As Boolean
        Dim txtDetalleAsistencia As String
        Dim dblNotaAlum As Double
        Dim dblNotaObtenida As Double
        For Each grdRow In grdAsistencia.Rows

            Dim hplRutAlumno As HyperLink
            hplRutAlumno = CType(grdRow.FindControl("hplRutAlumno"), HyperLink)
            lngRutAlumno = RutUsrALng(hplRutAlumno.Text)

            Dim txtAsistencia As TextBox
            txtAsistencia = CType(grdRow.FindControl("txtAsistencia"), TextBox)
            If IsNumeric(txtAsistencia.Text) Then
                If txtAsistencia.Text >= 0 Then
                    If txtAsistencia.Text <= 100 Then
                        dblPorcentaje = txtAsistencia.Text
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia debe ser igual o menor a cien');")
                        Exit Sub
                    End If
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia debe ser igual o mayor a cero');")
                    Exit Sub
                End If
            Else
                body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia debe ser un número entero.');")
                Exit Sub
            End If

            Dim txtNotaObtenida As TextBox
            txtNotaObtenida = CType(grdRow.FindControl("txtNotaObtenida"), TextBox)
            If IsNumeric(txtNotaObtenida.Text) Then
                If txtNotaObtenida.Text >= 0 Then
                    If txtNotaObtenida.Text <= 100 Then
                        dblNotaObtenida = Replace(txtNotaObtenida.Text, ".", ",")
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: La nota evaluación debe ser igual o menor a cien');")
                        Exit Sub
                    End If
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: La nota evaluación debe ser igual o mayor a cero');")
                    Exit Sub
                End If
            Else
                body.Attributes.Add("onload", "alert('ATENCIÓN: La nota evaluación debe ser un número entero.');")
                Exit Sub
            End If

            'txtDetalleAsistencia = CType(grdRow.FindControl("txtDetalleAsistencia"), TextBox).Text
            'If IsNumeric(CType(grdRow.FindControl("txtNotaAlum"), TextBox).Text) Then
            '    dblNotaAlum = CType(grdRow.FindControl("txtNotaAlum"), TextBox).Text
            'Else
            '    dblNotaAlum = 0
            'End If
            objManteAsistencia.ActualizarAsistencia2(lngRutAlumno, dblPorcentaje, dblNotaObtenida, txtDetalleAsistencia)
        Next
        If objManteAsistencia.RegistrarAsistencia Then
            blnProceso = True
        Else
            objManteAsistencia.AnularCurso()
            blnProceso = False
        End If
        If Not objManteAsistencia.ChequearMontoCuentasAsignada() Then
            Response.Redirect("mantenedor_cursos.aspx?CodCurso=" & lngCodCurso & "&CambioxAsistencia=si")
            Exit Sub
        End If
        If blnProceso Then
            body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia ha sido actualizada exitosamente');")
            btnVolver.Visible = True
            btnIngresar.Visible = False
            For Each grdRow2 In grdAsistencia.Rows
                Dim txtAsistencia As TextBox
                txtAsistencia = CType(grdRow2.FindControl("txtAsistencia"), TextBox)
            Next
        Else
            body.Attributes.Add("onload", "alert('ATENCIÓN: El curso ha sido anulado');")
            btnVolver.Visible = True
            btnIngresar.Visible = False
            For Each grdRow2 In grdAsistencia.Rows
                Dim txtAsistencia As TextBox
                txtAsistencia = CType(grdRow2.FindControl("txtAsistencia"), TextBox)
            Next
        End If
        Response.Redirect("mantenedor_factura.aspx?CodCurso=" & lngCodCurso)
    End Sub

    Protected Sub btnVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVolver.Click
        'Response.Redirect("reporte_cursos.aspx?estados=4,11")
        Response.Redirect("reporte_cursos.aspx?Origen=BuscarCursos&Filtros= And cc.cod_curso = " & ViewState("CodCurso"))
    End Sub
    Public Function ValidarAsistencia() As Boolean
        Dim grdRow As GridViewRow
        objManteAsistencia = New CMantenedorAsistencias
        Dim lngCodCurso As Long
        Dim intContador As Integer
        Dim lngNumParticipantes As Long
        lngCodCurso = ViewState("CodCurso")
        objManteAsistencia.CodCurso = lngCodCurso
        For Each grdRow In grdAsistencia.Rows
            Dim txtAsistencia As TextBox
            txtAsistencia = CType(grdRow.FindControl("txtAsistencia"), TextBox)
            intContador = 0
            If txtAsistencia.Text < 75 Then
                intContador = intContador + 1
            End If
        Next
        objManteAsistencia.ListadoParticipantes()
        lngNumParticipantes = objManteAsistencia.NumAlumnos
        If intContador = lngNumParticipantes Then
            ValidarAsistencia = True
        Else
            ValidarAsistencia = False
        End If
    End Function
    Protected Sub grdAsistencia_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAsistencia.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hplRutAlumno As HyperLink
            hplRutAlumno = CType(e.Row.FindControl("hplRutAlumno"), HyperLink)
            hplRutAlumno.Text = RutLngAUsr(hplRutAlumno.Text)
            Dim txtNotaObtenida As TextBox
            txtNotaObtenida = CType(e.Row.FindControl("txtNotaObtenida"), TextBox)
            txtNotaObtenida.Text = txtNotaObtenida.Text

            Dim lblFranquicia As Label
            lblFranquicia = CType(e.Row.FindControl("lblFranquicia"), Label)
            lblFranquicia.Text = lblFranquicia.Text & "%"

            Dim lblViatico As Label
            lblViatico = CType(e.Row.FindControl("lblViatico"), Label)
            lblViatico.Text = FormatoPeso(lblViatico.Text)

            Dim lblTraslado As Label
            lblTraslado = CType(e.Row.FindControl("lblTraslado"), Label)
            lblTraslado.Text = FormatoPeso(lblTraslado.Text)

        End If
    End Sub

    Protected Sub btnCargar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargar.Click
        objManteAsistencia = New CMantenedorAsistencias
        Dim lngCodCurso As Long
        Dim lngRutUsuario As Long
        lngCodCurso = ViewState("CodCurso")
        lngRutUsuario = ViewState("RutUsuario")
        objManteAsistencia.CodCurso = lngCodCurso
        objManteAsistencia.RutUsuario = lngRutUsuario
        Dim fileName As String
        Dim savePath As String = Server.MapPath("~/contenido/tmp/")
        fileName = fulAsistencia.FileName
        savePath += fileName
        If fulAsistencia.HasFile Then
            If fileName.Substring(fileName.Length - 3) = "txt" Then
                fileName = NombreArchivoTmp("txt")
                Me.fulAsistencia.SaveAs(savePath)
                objManteAsistencia.CargaArchivo(savePath)
                objWeb = New CWeb
                objWeb.LlenaGrilla(Me.grdAsistencia, objManteAsistencia.DtParticipantes)
            Else
                Me.ClientScript.RegisterStartupScript(Me.GetType(), "ClientScript", "<script language='javascript' type='text/javascript'> " & _
                      "alert('¡Error con el formato del archivo tiene que ser un .txt!');" & _
                      "</script>")
            End If
        End If
    End Sub

    Protected Sub btnCalcularPromedio_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim btnCalcularPromedio As Button = CType(sender, Button)
            Dim row As GridViewRow = CType(btnCalcularPromedio.NamingContainer, GridViewRow)

            Dim intNumAsistencia As Integer = Me.grdAsistencia.Rows.Count

            Dim txtMediaAsistencia As TextBox
            txtMediaAsistencia = CType(row.FindControl("txtMediaAsistencia"), TextBox)
            Dim grdRow As GridViewRow
            For Each grdRow In grdAsistencia.Rows
                Dim txtAsistencia As TextBox
                txtAsistencia = CType(grdRow.FindControl("txtAsistencia"), TextBox)
                ViewState("intTotalAsistencia") = ViewState("intTotalAsistencia") + CInt(txtAsistencia.Text)
            Next
        
            txtMediaAsistencia.Text = ViewState("intTotalAsistencia") / intNumAsistencia

            ViewState("intTotalAsistencia") = 0

        Catch ex As Exception
            EnviaError("mantenedor_asistencias:btnCalcularPromedio_Click-->" & ex.Message)
        End Try
    End Sub

    Protected Sub btnCargarAsistencia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCargarAsistencia.Click
        Try
            If IsNumeric(Me.txtAsistenciaTodos.Text) Then
                If Me.txtAsistenciaTodos.Text >= 0 Then
                    If Me.txtAsistenciaTodos.Text <= 100 Then
                        Dim grdRow As GridViewRow
                        For Each grdRow In grdAsistencia.Rows
                            Dim txtAsistencia As TextBox
                            txtAsistencia = CType(grdRow.FindControl("txtAsistencia"), TextBox)
                            txtAsistencia.Text = txtAsistenciaTodos.Text
                        Next
                    Else
                        body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia debe ser igual o menor a cien');")
                        Me.hdfEnvioDatos.Value = 0
                        Exit Sub
                    End If
                Else
                    body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia debe ser igual o mayor a cero');")
                    Me.hdfEnvioDatos.Value = 0
                    Exit Sub
                End If
            Else
                body.Attributes.Add("onload", "alert('ATENCIÓN: La asistencia debe ser un número entero.');")
                Me.hdfEnvioDatos.Value = 0
                Exit Sub
            End If
        Catch ex As Exception
            EnviaError("mantenedor_asistencias:btnCargarAsistencia_Click-->" & ex.Message)
        End Try
    End Sub
End Class
