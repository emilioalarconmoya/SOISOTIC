Imports System.Web
Imports System.Web.UI.Page
Imports Clases
Imports Modulos
Imports System.Data
Imports System.Net
'Clase de interfaz, sólo se sirve para ser instanciada desde ASP.NET

Namespace Clases.Web
    Public Class CWeb
        Inherits System.Web.UI.Page 'Para que herede la 1era página
        Private srtcodigo As String
        Public Property trcodigo1() As String
            Get
                trcodigo1 = srtcodigo
            End Get
            Set(ByVal value As String)
                srtcodigo = value
            End Set
        End Property
        '***dropdownlist
        Public Sub LlenaDDL(ByRef ddlObjeto As DropDownList, ByRef dtTable As DataTable, _
        ByVal strValorCodigo As String, ByVal strValorTexto As String, _
        Optional ByVal strValorDefault As String = "0")
            'Para dejarlo en la selección: strValorSeleccionado
            If Not dtTable Is Nothing Then
                ddlObjeto.Items.Clear() 'limpia
                ddlObjeto.DataSource = dtTable.DefaultView
                ddlObjeto.DataValueField = strValorCodigo
                ddlObjeto.DataTextField = strValorTexto

                ddlObjeto.DataBind()
                'ddlObjeto.SelectedValue = strValorDefault
            End If
        End Sub
        Public Sub LlenaLST(ByRef lstObjeto As ListBox, ByRef dtTable As DataTable, _
               ByVal strValorCodigo As String, ByVal strValorTexto As String)
            'Para dejarlo en la selección: strValorSeleccionado
            If Not dtTable Is Nothing Then
                lstObjeto.DataSource = dtTable.DefaultView
                lstObjeto.DataValueField = strValorCodigo
                lstObjeto.DataTextField = strValorTexto
                lstObjeto.DataBind()
            End If
        End Sub
        Public Sub LlenaLSTaux(ByRef lstObjeto As ListBox, ByRef dtTable As DataTable, _
              ByVal strValorCodigo As String, ByVal strValorTexto As String)
            'Para dejarlo en la selección: strValorSeleccionado
            If Not dtTable Is Nothing Then
                lstObjeto.DataSource = dtTable.DefaultView
                lstObjeto.DataValueField = strValorCodigo
                lstObjeto.DataTextField = strValorTexto

                lstObjeto.DataBind()
            End If
        End Sub
        Public Sub CargaLstcompleta(ByRef lbxInicio As ListBox, ByRef lbxLlegadaAdos As ListBox)
            Dim strCod, strText As String
            Dim i, j As Integer
            If lbxInicio.Items.Count > 0 Then
                j = lbxInicio.Items.Count - 1
                i = 0
                While i <= j
                    lbxInicio.SelectedIndex = i
                    If lbxInicio.SelectedValue <> "" Then
                        strCod = lbxInicio.SelectedValue
                        strText = lbxInicio.SelectedItem.ToString
                        AgregaValorLST(lbxLlegadaAdos, strText, strCod)
                        EliminaValorLST(lbxInicio, strText, strCod)
                        j = j - 1
                    End If
                End While
            End If
        End Sub

        Public Sub CargaLst(ByRef lbxInicio As ListBox, ByRef lbxLlegadaados As ListBox)
            Dim strCod, strText As String
            If lbxInicio.SelectedValue <> "" Then
                strCod = lbxInicio.SelectedValue
                strText = lbxInicio.SelectedItem.ToString
                AgregaValorLST(lbxLlegadaados, strText, strCod)
                EliminaValorLST(lbxInicio, strText, strCod)
            Else
                Exit Sub
            End If
        End Sub

        Public Sub AgregaValorDDL(ByRef ddlList As DropDownList, ByVal strTexto As String, ByVal strValue As String)
            Dim lit As New ListItem
            lit.Text = strTexto
            lit.Value = strValue
            ddlList.Items.Add(lit)
        End Sub

        Public Sub AgregaValorLST(ByRef lstList As ListBox, ByVal strTexto As String, ByVal strValue As String)
            Dim lit As New ListItem
            lit.Text = strTexto
            lit.Value = strValue
            lstList.Items.Add(lit)
        End Sub
        Public Sub AgregaValorLSTCompleto(ByRef lstList As ListBox, ByVal strTexto As String, ByVal strValue As String)
            Dim lit As New ListItem
            lit.Text = strTexto
            lit.Value = strValue
            lstList.Items.Add(lit)
        End Sub

        Public Sub EliminaValorLST(ByRef lstList As ListBox, ByVal strTexto As String, ByVal strValue As String)
            Dim lit As New ListItem
            lit.Text = strTexto
            lit.Value = strValue
            lstList.Items.Remove(lit)
        End Sub

        'gridview*************
        'Setea la información de una grilla para paginación
        Public Sub SeteaGrilla(ByRef grdGrilla As GridView, ByVal intTamPag As Integer, _
        Optional ByVal strMensajeSinDatos As String = "La consulta no arrojó resultados", _
        Optional ByVal grdPosicion As PagerPosition = PagerPosition.TopAndBottom)
            grdGrilla.AllowPaging = True
            grdGrilla.EmptyDataText = strMensajeSinDatos
            grdGrilla.PagerSettings.Position = grdPosicion
            grdGrilla.PagerSettings.Mode = PagerButtons.NumericFirstLast
            grdGrilla.PagerSettings.NextPageText = "Siguiente"
            grdGrilla.PagerSettings.PreviousPageText = "Anterior"
            grdGrilla.PageSize = intTamPag

        End Sub

        'Llena la grilla con un datatable
        Public Sub LlenaGrilla(ByRef grdGrilla As GridView, ByRef dtDataTable As DataTable)
            'grdGrilla.Columns.Clear()
            grdGrilla.DataSource = dtDataTable
            grdGrilla.DataBind()
        End Sub

        'Busca un texto determinado en un ListBox
        Public Sub Busca_ValorLST(ByRef lstBox_ As ListBox, ByRef strTxt_Buscar As String, _
            ByRef strVal_LstTxt As String)
            Dim item_ As ListItem

            'Recorremos el ListBox en busca del
            'Texto ingresado por el Usr.
            For Each item_ In lstBox_.Items
                'Almaceno en una variable el valor del texto
                'en la posiciòn x del ListBox
                strVal_LstTxt = lstBox_.SelectedItem.Text
                'Comparo el valor ingresado por el usuario
                'por el hallado en el ListBox
                If strTxt_Buscar = strVal_LstTxt Then

                End If
            Next
        End Sub
        'Mantiene la session
        Public Function ChequeaSession(ByRef objSession As CSession, Optional ByVal intCodObjAcceso As Integer = 0) As String
            If objSession Is Nothing And TypeName(Session("session")) <> "CSession" Then
                Session.Abandon()
                Return "Off" 'perdió session
            ElseIf Not Session("session") Is Nothing Then
                'Mantiene la session activa
                objSession = Session("session")
                Return "On" 'ok
            Else
                'viene la 1era vez
                Session("session") = objSession
                Return "On" 'ok
            End If

            'Si no está conectado lanza false (Logueado)
            If Not objSession.Conectado Then
                Session.Abandon()
                Return "Off" 'perdió session
            End If

            'Acceso a objetos de seguridad
            If Not objSession.AccesoObjeto(intCodObjAcceso) Then
                Session.Abandon()
                Return "Out" 'sin permiso
            End If
        End Function
        'Mantiene la session
        Public Function ChequeaCliente(ByRef objSessionCliente As CSession, Optional ByVal intCodObjAcceso As Integer = 0) As String
            If objSessionCliente Is Nothing And TypeName(Session("cliente")) <> "CSession" Then
                'Session.Abandon()
                Return "Off" 'perdió session
            ElseIf Not Session("cliente") Is Nothing Then
                'Mantiene la session activa
                objSessionCliente = Session("cliente")
                Return "On" 'ok
            Else
                'viene la 1era vez
                Session("cliente") = objSessionCliente
                Return "On" 'ok
            End If

            'Si no está conectado lanza false (Logueado)
            If Not objSessionCliente.Conectado Then
                'Session.Abandon()
                Return "Off" 'perdió session
            End If

            'Acceso a objetos de seguridad
            If Not objSessionCliente.AccesoObjeto(intCodObjAcceso) Then
                'Session.Abandon()
                Return "Out" 'sin permiso
            End If
        End Function

        Public Sub EliminaVarsSession()
            Dim objTmp As CSession
            objTmp = Session("session")
            Session.Contents.RemoveAll()
            Session("session") = objTmp
        End Sub
    End Class
End Namespace
