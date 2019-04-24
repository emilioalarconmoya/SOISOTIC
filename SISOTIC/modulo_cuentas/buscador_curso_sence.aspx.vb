Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Imports System.Xml
Partial Class modulo_cursos_buscador_curso_sence
    Inherits System.Web.UI.Page
    Dim objWeb As CWeb
    Dim objSession As CSession
    Dim objMantenedor As CMantenedorCursos
    Dim objMantenedorINS As CMantenedorCursosSence
    Dim objOtec As COtec
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '***********************************************************************************
            objWeb = New CWeb
            objWeb.ChequeaSession(objSession)
            body.Attributes.Clear()
            '***********************************************************************************
            If Not Page.IsPostBack Then
                objWeb = New CWeb
                objWeb.SeteaGrilla(Me.grdCursosSence, TAM_PAG)
                objWeb = Nothing
                campo_padre.Value = Request("campo")
            End If
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_curso_sence.aspx.vb:Page_Load-->" & ex.Message)
        End Try
    End Sub
    Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        Try
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_curso_sence.aspx.vb:btnConsultar_Click-->" & ex.Message)
        End Try
    End Sub
    Private Sub consultar()
        Try
            If Me.txtCodSence.Text.Trim = "" And Me.txtNomCurso.Text.Trim = "" And Me.txtOtec.Text.Trim = "" Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar almenos uno de los filtros.');")
                Exit Sub
            End If
            If Me.txtNomCurso.Text.Trim <> "" And Me.txtNomCurso.Text.Trim.Length <= 2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre de curso a buscar');")
                Exit Sub
            End If
            If Me.txtOtec.Text.Trim <> "" And Me.txtOtec.Text.Trim.Length <= 2 Then
                body.Attributes.Add("onload", "alert('ATENCIÓN: Debe ingresar más de dos caracteres en el nombre Otec a buscar');")
                Exit Sub
            End If
            objMantenedor = New CMantenedorCursos
            objMantenedor.inicializarPopUpCursosSence()
            objMantenedor.CursosSenceCodCurso = Me.txtCodSence.Text.Trim
            objMantenedor.CursosSenceNombreCurso = Me.txtNomCurso.Text.Trim
            objMantenedor.CursosSenceOtec = Me.txtOtec.Text.Trim
            objMantenedor.ConsultarCursosSence()


            '*************************************************************************
            Dim respuesta_web As String
            Dim cs_web = New CHTML
            Dim xml_codSence As String
            Dim xml_HorTeoricas As String
            Dim xml_HorPracticas As String
            Dim xml_HorElearning As String
            Dim xml_ValImputable As String
            Dim xml_HorValor As String
            Dim xml_NomCurso As String
            Dim xml_Area As String
            Dim xml_Especialidad As String
            Dim xml_TotalCurso As String
            Dim xml_NumParticip As String
            Dim xml_RutOtec As String
            Dim xml_NombreSede As String
            Dim xml_FonoSede As String
            Dim xml_DireccionSede As String
            Dim xml_CodComunaSede As Long
            Dim xml_CodModalidad As Long
            Dim xml_NombreModalidad As String


            respuesta_web = cs_web.getHTML("http://pruebasphp.soleduc.cl/traedatos_sql.php?curso=" + txtCodSence.Text)

            If respuesta_web <> "SIN_DATA" Then

                Dim objXMLDoc As New XmlDocument
                objXMLDoc.LoadXml(respuesta_web)

                xml_codSence = objXMLDoc.LastChild.ChildNodes(0).InnerText
                xml_HorTeoricas = objXMLDoc.LastChild.ChildNodes(1).InnerText
                xml_HorPracticas = objXMLDoc.LastChild.ChildNodes(2).InnerText
                xml_HorElearning = objXMLDoc.LastChild.ChildNodes(3).InnerText
                xml_ValImputable = objXMLDoc.LastChild.ChildNodes(4).InnerText
                xml_HorValor = objXMLDoc.LastChild.ChildNodes(5).InnerText
                xml_NomCurso = objXMLDoc.LastChild.ChildNodes(6).InnerText
                xml_Area = objXMLDoc.LastChild.ChildNodes(7).InnerText
                xml_Especialidad = objXMLDoc.LastChild.ChildNodes(8).InnerText
                xml_TotalCurso = objXMLDoc.LastChild.ChildNodes(9).InnerText
                If xml_HorElearning > 0 Then
                    xml_NumParticip = "500"
                Else
                    xml_NumParticip = objXMLDoc.LastChild.ChildNodes(10).InnerText
                End If
                xml_RutOtec = RutUsrALng(objXMLDoc.LastChild.ChildNodes(11).InnerText)
                xml_NombreModalidad = objXMLDoc.LastChild.ChildNodes(12).InnerText

                objOtec = New COtec
                If Not objOtec.Inicializar1(CLng(xml_RutOtec)) Then
                    lblMensaje.Text = "No existe el rut de laotec en la base de datos del sistema"
                    Exit Sub
                Else
                    xml_NombreSede = objOtec.RazonSocial
                    xml_FonoSede = objOtec.Fono.Trim
                    xml_DireccionSede = objOtec.Direccion
                    xml_CodComunaSede = objOtec.CodComuna
                End If



                If xml_NombreModalidad.Contains("Presencial") Then
                    xml_CodModalidad = 1
                ElseIf xml_NombreModalidad.Contains("E-Learning") Then
                    xml_CodModalidad = 2
                ElseIf xml_NombreModalidad.Contains("Intrucción") Then
                    xml_CodModalidad = 3
                ElseIf xml_NombreModalidad.Contains("Distancia") Then
                    xml_CodModalidad = 4
                Else
                    xml_CodModalidad = 1
                End If




                If objMantenedor.CursosSenceListado.Rows.Count > 0 Then

                    If xml_HorValor <> Val(objMantenedor.CursosSenceListado.Rows(0).Item(5)) Then
                        lblMensaje.Text = "Valor Hora Sence Actual distinto al registrado... (SENCE : $" & xml_HorValor & " SISOTIC : $" & objMantenedor.CursosSenceListado.Rows(0).Item(5) & ") "
                    Else
                        lblMensaje.Text = ""
                    End If
                Else
                    objMantenedorINS = New CMantenedorCursosSence
                    objMantenedorINS.CodSence = Me.txtCodSence.Text
                    objMantenedorINS.NombreCurso = xml_NomCurso 'Me.txtNombreCurso.Text
                    objMantenedorINS.RutOtec = CLng(xml_RutOtec) 'Me.txtRutEmpresa.Text
                    objMantenedorINS.Area = xml_Area 'Me.txtArea.Text
                    objMantenedorINS.Especialidad = xml_Especialidad 'Me.txtEspecialidad.Text
                    objMantenedorINS.DurCurTeorico = CLng(xml_HorTeoricas) 'CLng(Me.txtDurCursoTeorico.Text.Trim)
                    objMantenedorINS.DurCurPractico = CLng(xml_HorPracticas) 'CLng(Me.txtDurCursoPractico.Text.Trim)
                    objMantenedorINS.NumMaxParticipantes = CLng(xml_NumParticip) 'CLng(Me.txtNumParticipantes.Text.Trim)
                    objMantenedorINS.NombreSede = xml_NombreSede
                    objMantenedorINS.FonoSede = xml_FonoSede.Trim
                    objMantenedorINS.Direccion = xml_DireccionSede
                    objMantenedorINS.CodComuna = CLng(xml_CodComunaSede) 'CLng(Me.ddlComuna.SelectedValue.Trim)
                    objMantenedorINS.ValorCurso = CLng(xml_TotalCurso) 'CLng(Me.txtValorTotal.Text.Trim)
                    objMantenedorINS.ValorHora = CLng(xml_HorValor)
                    objMantenedorINS.DurCurElearning = CLng(xml_HorElearning)
                    objMantenedorINS.CodModalidad = CLng(xml_CodModalidad)



                    If objMantenedorINS.Insertar() Then
                        lblMensaje.Text = "Curso SENCE no existía en la base pero si en SENCE ... y se agregó automaticamente.... Favor consulte nuevamente..."
                    Else
                        lblMensaje.Text = "Curso SENCE no existía en la base pero si en SENCE ... pero hubo problemas al insertar el curso...."
                    End If
                End If
            Else
                If objMantenedor.CursosSenceListado.Rows.Count = 0 Then
                    lblMensaje.Text = "Curso SENCE no existe en la base ni en SENCE"
                End If
                If Me.txtNomCurso.Text.Trim = "" And Me.txtOtec.Text.Trim = "" Then
                    lblMensaje.Text = "Respuesta NULA desde SENCE..."
                End If
            End If
            '*************************************************************************




            Dim bf As BoundField
            bf = CType(Me.grdCursosSence.Columns(1), BoundField)
            bf.DataField = "nombre_curso"

            bf = CType(Me.grdCursosSence.Columns(2), BoundField)
            bf.DataField = "horas"

            bf = CType(Me.grdCursosSence.Columns(3), BoundField)
            bf.DataField = "otec"
            objWeb = New CWeb
            objWeb.LlenaGrilla(Me.grdCursosSence, objMantenedor.CursosSenceListado)
            objWeb = Nothing
            objMantenedor = Nothing
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:consultar-->" & ex.Message)
        End Try
    End Sub
    Protected Sub grdCursosSence_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCursosSence.PageIndexChanging
        Try
            grdCursosSence.PageIndex = e.NewPageIndex
            consultar()
        Catch ex As Exception
            EnviaError("modulo_cursos/buscador_empresas.aspx.vb:grdEmpresas_PageIndexChanging-->" & ex.Message)
        End Try
    End Sub

    Protected Sub grdCursosSence_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCursosSence.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hpl As New HyperLink
            hpl = CType(e.Row.FindControl("hplCodSence"), HyperLink)
            hpl.Attributes.Add("onclick", "Cerrar('" & hpl.Text & "');")

            Dim lblValorCurso As Label
            lblValorCurso = CType(e.Row.FindControl("lblValorCurso"), Label)
            lblValorCurso.Text = FormatoPeso(lblValorCurso.Text)
        End If
    End Sub
End Class
