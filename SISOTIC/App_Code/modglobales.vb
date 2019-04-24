Imports System.IO
Imports Clases
Imports System.Data
Namespace Modulos
    'Parámetros de configuración
    Public Structure sParam
        Dim p_HOST As String
        Dim p_USER As String
        Dim p_PASS As String
        Dim p_BD As String
        Dim p_TIPOBD As String
        Dim p_DIRVIRTUAL As String
        Dim p_DIRFISICO As String
        Dim p_SERVIDORCORREO As String
        Dim p_USUARIOCORREO As String
        Dim p_MAILAVISOMDB As String
        Dim p_EMPRESA As String
        Dim p_NOMBREEMPRESALARGO As String
        Dim p_MODODEBUG As String
        Dim p_DIRVIRTUALMAIL As String
        Dim p_NONSECURE As String
        Dim p_SECCION As String
        Dim p_FIRMAMAIL As String
        Dim p_TIPOCONEXION As String
        Dim p_MAXPORCADMIN As String
        Dim p_PIE As String
        Dim p_DIRECIONEMPRESA As String
        Dim p_FONOEMPRESA As String
        Dim p_FAXEMPRESA As String
        Dim p_RUTEMPRESA As String
        Dim p_PERSONAFIRMA As String
        Dim p_GIROEMPRESA As String
        Dim p_REQUISITOSYCONDICIONES As String
        Dim p_TIPOENVIOCORREO As String
        Dim p_USUARIOCORREONET As String
        Dim p_PASSUSUARIOCORREONET As String
        Dim p_SERVIDORCORREOSMTP As String
        Dim p_NOMBREOC As String
        Dim p_CARGOOC As String
        Dim p_CUENTAEXCCAPACITACION As String
        Dim p_PASSWORDEXCEL As String
        Dim p_TAMANOFIRMA As String
        Dim p_TAMANOLINEA As String
        Dim p_DIACERTIFICADOAPORTE As String
        Dim p_DIASCOMUNICACION As String
        Dim p_EMAIL1OC As String
        Dim p_EMAIL2OC As String
        Dim p_EMAIL3OC As String
        Dim p_REDIRECCIONAR As String
    End Structure
    Public Structure sComprobanteAporte
        Dim p_TITULO As String
        Dim p_SUBTITULO As String
        Dim p_ORGANISMO As String
        Dim p_SUBORGANISMO As String
        Dim p_NUMEROCOMPROBANTETITULO As String
        Dim p_FECHATITULO As String
        Dim p_EMPRESATITULO As String
        Dim p_RUTTITULO As String
        Dim p_DIRECCIONTITULO As String
        Dim p_MONTOLETRASTITULO As String
        Dim p_DOCUMENTOTITULO As String
        Dim p_BANCO As String
        Dim p_OBSERVACIONES As String
        Dim p_FECHAAPORTETITULO As String
        Dim p_MONTONUMEROSTITULO As String
        Dim p_GLOSATITULO As String
        Dim p_TEXTOFINAL As String
        Dim p_SUBTEXTOFINAL As String
        Dim p_PIE As String
    End Structure

    Public Module modGlobales

        Public Const TAM_PAG As Integer = 20 'Tamaño paginas de reportes
        Public Const gValorNumNulo = -9998
        Public Const CLAVE_INVALIDA = "%$%$%$%$%$%$%$%$%$%$%$%$%$%$%$%$%$"

        Public Function TipoBd() As String
            Return Parametros.p_TIPOBD
        End Function

        'Entrega la raiz del sitio
        Public Function DIRFISICOAPP() As String
            Return System.AppDomain.CurrentDomain.BaseDirectory
        End Function
        'Función que carga los parámetros en la estructura definida (Definida en modGlobales)
        Public Function Parametros() As sParam
            Dim objXml As New CXml
            Dim sParametros As New sParam
            Dim objWeb As New Web.CWeb

            objXml.LeerXml(DIRFISICOAPP() & "\conf.xml") 'lee el XML
            sParametros.p_HOST = objXml.LeerNodoDato("configuracion", "host")
            sParametros.p_USER = objXml.LeerNodoDato("configuracion", "user")
            sParametros.p_PASS = DecryptINI$(objXml.LeerNodoDato("configuracion", "pass"))
            sParametros.p_BD = objXml.LeerNodoDato("configuracion", "bd")
            sParametros.p_TIPOBD = objXml.LeerNodoDato("configuracion", "bdconex")
            sParametros.p_DIRFISICO = DIRFISICOAPP()
            sParametros.p_SERVIDORCORREO = objXml.LeerNodoDato("configuracion", "servidorcorreo")
            sParametros.p_USUARIOCORREO = objXml.LeerNodoDato("configuracion", "usuariocorreo")
            sParametros.p_MAILAVISOMDB = objXml.LeerNodoDato("configuracion", "mailavisomdb")
            sParametros.p_EMPRESA = objXml.LeerNodoDato("configuracion", "empresa")
            sParametros.p_NOMBREEMPRESALARGO = objXml.LeerNodoDato("configuracion", "nombreempresalargo")
            sParametros.p_MODODEBUG = objXml.LeerNodoDato("configuracion", "mododebug")
            sParametros.p_DIRVIRTUALMAIL = objXml.LeerNodoDato("configuracion", "dirvirtualmail")
            sParametros.p_FIRMAMAIL = objXml.LeerNodoDato("configuracion", "firmamail")
            sParametros.p_TIPOCONEXION = objXml.LeerNodoDato("configuracion", "bdtipoconex")
            sParametros.p_MAXPORCADMIN = objXml.LeerNodoDato("configuracion", "maxporcadmin")
            sParametros.p_PIE = objXml.LeerNodoDato("configuracion", "pie")
            sParametros.p_DIRECIONEMPRESA = objXml.LeerNodoDato("configuracion", "direccionempresa")
            sParametros.p_FONOEMPRESA = objXml.LeerNodoDato("configuracion", "fonoempresa")
            sParametros.p_FAXEMPRESA = objXml.LeerNodoDato("configuracion", "faxempresa")
            sParametros.p_RUTEMPRESA = objXml.LeerNodoDato("configuracion", "rutempresa")
            sParametros.p_PERSONAFIRMA = objXml.LeerNodoDato("configuracion", "personafirma")
            sParametros.p_GIROEMPRESA = objXml.LeerNodoDato("configuracion", "giroempresa")
            sParametros.p_REQUISITOSYCONDICIONES = objXml.LeerNodoDato("configuracion", "requisitos_y_condiciones")
            sParametros.p_TIPOENVIOCORREO = objXml.LeerNodoDato("configuracion", "tipoenviocorreo")
            sParametros.p_USUARIOCORREONET = objXml.LeerNodoDato("configuracion", "usuariocorreonet")
            sParametros.p_PASSUSUARIOCORREONET = objXml.LeerNodoDato("configuracion", "passusuariocorreonet")
            sParametros.p_SERVIDORCORREOSMTP = objXml.LeerNodoDato("configuracion", "servidorcorreosmtp")
            sParametros.p_NOMBREOC = objXml.LeerNodoDato("configuracion", "nombreoc")
            sParametros.p_CARGOOC = objXml.LeerNodoDato("configuracion", "cargooc")
            sParametros.p_CUENTAEXCCAPACITACION = objXml.LeerNodoDato("configuracion", "cuentaexccapacitacion")
            sParametros.p_PASSWORDEXCEL = objXml.LeerNodoDato("configuracion", "passwordexcel")
            sParametros.p_TAMANOFIRMA = objXml.LeerNodoDato("configuracion", "tananofirma")
            sParametros.p_TAMANOLINEA = objXml.LeerNodoDato("configuracion", "tananolinea")
            sParametros.p_DIACERTIFICADOAPORTE = objXml.LeerNodoDato("configuracion", "diaCertificadoaporte")
            sParametros.p_DIASCOMUNICACION = objXml.LeerNodoDato("configuracion", "diasComunicacion")
            sParametros.p_EMAIL1OC = objXml.LeerNodoDato("configuracion", "email1OC")
            sParametros.p_EMAIL2OC = objXml.LeerNodoDato("configuracion", "email2OC")
            sParametros.p_EMAIL3OC = objXml.LeerNodoDato("configuracion", "email3OC")
            sParametros.p_REDIRECCIONAR = objXml.LeerNodoDato("configuracion", "redireccionar")
            objXml = Nothing
            objWeb = Nothing
            Return sParametros
        End Function
        'Función que carga los parámetros en la estructura definida (Definida en modGlobales)
        Public Function ComprobanteAporte() As sComprobanteAporte
            Dim objXml As New CXml
            Dim sComprobanteAporte As New sComprobanteAporte
            Dim objWeb As New Web.CWeb

            objXml.LeerXml(DIRFISICOAPP() & "\include\comprobateAporte.xml") 'lee el XML
            sComprobanteAporte.p_TITULO = objXml.LeerNodoDato("comprobanteAporte", "titulo")
            sComprobanteAporte.p_SUBTITULO = objXml.LeerNodoDato("comprobanteAporte", "subtitulo")
            sComprobanteAporte.p_ORGANISMO = objXml.LeerNodoDato("comprobanteAporte", "organismo")
            sComprobanteAporte.p_SUBORGANISMO = objXml.LeerNodoDato("comprobanteAporte", "suborganismo")
            sComprobanteAporte.p_NUMEROCOMPROBANTETITULO = objXml.LeerNodoDato("comprobanteAporte", "numeroComprobanteTitulo")
            sComprobanteAporte.p_FECHATITULO = objXml.LeerNodoDato("comprobanteAporte", "fechaTitulo")
            sComprobanteAporte.p_EMPRESATITULO = objXml.LeerNodoDato("comprobanteAporte", "empresaTitulo")
            sComprobanteAporte.p_RUTTITULO = objXml.LeerNodoDato("comprobanteAporte", "rutTitulo")
            sComprobanteAporte.p_DIRECCIONTITULO = objXml.LeerNodoDato("comprobanteAporte", "direccionTitulo")
            sComprobanteAporte.p_MONTOLETRASTITULO = objXml.LeerNodoDato("comprobanteAporte", "montoLetrasTitulo")
            sComprobanteAporte.p_DOCUMENTOTITULO = objXml.LeerNodoDato("comprobanteAporte", "documentoTitulo")
            sComprobanteAporte.p_BANCO = objXml.LeerNodoDato("comprobanteAporte", "bancoTitulo")
            sComprobanteAporte.p_OBSERVACIONES = objXml.LeerNodoDato("comprobanteAporte", "observaciones")
            sComprobanteAporte.p_FECHAAPORTETITULO = objXml.LeerNodoDato("comprobanteAporte", "fechaAporteTitulo")
            sComprobanteAporte.p_MONTONUMEROSTITULO = objXml.LeerNodoDato("comprobanteAporte", "montoNumerosTitulo")
            sComprobanteAporte.p_GLOSATITULO = objXml.LeerNodoDato("comprobanteAporte", "glosaTitulo")
            sComprobanteAporte.p_TEXTOFINAL = objXml.LeerNodoDato("comprobanteAporte", "textoFinal")
            sComprobanteAporte.p_SUBTEXTOFINAL = objXml.LeerNodoDato("comprobanteAporte", "subtextoFinal")
            sComprobanteAporte.p_PIE = objXml.LeerNodoDato("comprobanteAporte", "pie")

            objXml = Nothing
            objWeb = Nothing
            Return sComprobanteAporte
        End Function
        'Genera un nombre único, con la extensión que definan
        Public Function NombreArchivoTmp(Optional ByVal strExtension As String = "xml")
            Return Path.ChangeExtension(Path.GetRandomFileName(), strExtension)
        End Function

        Public Function digito_verificador(ByVal Rut As Long) As String
            Dim intValor, intLargo, intSuma, intContador, intResto As Integer
            Dim mstrDigVerif As String

            ' calculo digito verificador RUT
            intValor = 2
            intLargo = Len(Trim(Str(Rut)))
            intSuma = 0
            For intContador = intLargo To 1 Step -1
                intSuma = intSuma + Val(Mid(Rut, intContador, 1)) * intValor
                intValor = intValor + 1
                If intValor > 7 Then
                    intValor = 2
                End If
            Next intContador
            intResto = 11 - intSuma Mod 11
            If intResto = 11 Then
                mstrDigVerif = "0"
            Else
                If intResto = 10 Then
                    mstrDigVerif = "K"
                Else
                    mstrDigVerif = Str(intResto)
                End If
            End If
            digito_verificador = mstrDigVerif
        End Function

        Public Function RutLngAUsr(ByVal lngRutEmpl As Long) As String
            If lngRutEmpl = 0 Then
                Return ""
            End If
            Dim lngRutEmplLoc As Long
            Dim strTemp As String
            Dim strDigVerif As String
            Dim i, j As Integer
            Dim strSalida As String
            Dim intLargo As Integer

            lngRutEmplLoc = lngRutEmpl
            strDigVerif = digito_verificador(lngRutEmplLoc)

            strTemp = CStr(lngRutEmplLoc)
            intLargo = Len(Trim(strTemp))
            strSalida = ""
            j = 0

            For i = intLargo To 1 Step -1
                If j > 0 And (j Mod 3 = 0) Then
                    strSalida = "." & strSalida
                End If
                strSalida = Mid(strTemp, i, 1) & strSalida
                j = j + 1
            Next

            strSalida = Trim(strSalida) & "-" & Trim(strDigVerif)

            RutLngAUsr = strSalida
        End Function
        Public Function RutUsrALng(ByVal strRut As String) As Long
            If strRut = "" Then
                Return 0
            End If
            Dim strRutLoc As String
            Dim strTemp As String
            Dim i As Integer
            Dim lngSalida As Long
            Dim intLargo As Integer

            If strRut <> "" Then
                If Not EsRut(strRut) Then
                    RutUsrALng = 0
                    Exit Function
                End If
            Else
                RutUsrALng = 0
                Exit Function
            End If

            strRutLoc = strRut

            intLargo = Len(Trim(strRutLoc))
            strTemp = ""

            For i = 0 To (intLargo - 1)
                If Mid(strRutLoc, i + 1, 1) <> " " And Mid(strRutLoc, i + 1, 1) <> "." _
                   And Mid(strRutLoc, i + 1, 1) <> "-" Then
                    strTemp = strTemp & Mid(strRutLoc, i + 1, 1)
                End If
            Next

            intLargo = Len(Trim(strTemp))
            strTemp = Mid(strTemp, 1, intLargo - 1)
            If Trim(strTemp) <> "" Then
                If IsNumeric(strTemp) Then
                    lngSalida = CLng(strTemp)
                Else
                    Exit Function
                End If
            Else
                lngSalida = 0
            End If
            RutUsrALng = lngSalida
        End Function
        Sub AsignarSiNoEsNulo(ByRef variable As Object, ByVal valor As Object)
            If Not IsDBNull(valor) Then
                variable = valor
            End If
        End Sub
        'Función análoga a AsignarSiNoEsNulo
        Function AsignarSiNoEsNuloF(ByVal variable As Object, ByVal valor As Object) As Object
            If IsDBNull(variable) Then
                AsignarSiNoEsNuloF = valor
            Else
                AsignarSiNoEsNuloF = variable
            End If
        End Function
        'Elimina los archivos de la carpeta tmp con 1 día de antigüedad
        Public Sub EliminaTmp()
            Dim objArchivo As New CArchivos
            objArchivo.EliminarTodosFechaDir(DIRFISICOAPP() & "contenido\tmp", DateAdd(DateInterval.Day, -1, Now.Date))
        End Sub
        Public Function EsRut(ByVal strRutProv As String) As Boolean
            Dim i, j, l As Integer
            Dim bolfalso As Boolean
            bolfalso = True
            l = Len(Trim(strRutProv))
            If l <> 0 Then
                For i = 1 To l - 1
                    j = 0
                    If Mid(strRutProv, 1, 1) = "1" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "2" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "3" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "4" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "5" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "6" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "7" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "8" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "9" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "0" Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "." Then
                        j = j + 1
                    End If
                    If Mid(strRutProv, 1, 1) = "-" Then
                        j = j + 1
                    End If
                    If j = 0 Then
                        bolfalso = False
                    End If
                Next


                If Mid(strRutProv, l, 1) = "1" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "2" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "3" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "4" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "5" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "6" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "7" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "8" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "9" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "0" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "." Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "-" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "K" Then
                    j = j + 1
                End If
                If Mid(strRutProv, l, 1) = "k" Then
                    j = j + 1
                End If
            End If
            For i = 1 To l - 1
                If Mid(strRutProv, i, 1) = "." And Mid(strRutProv, i + 1, 1) = "." Then
                    j = 0
                End If
            Next
            If j = 0 Or l = 0 Then
                bolfalso = False
            End If
            Return bolfalso


        End Function
        'Función para mantener acceso
        Public Sub Acceder(ByRef objSession As CSession, ByVal intCodSeg As Integer)
            Dim objWeb As New Web.CWeb
            Select Case objWeb.ChequeaSession(objSession, intCodSeg)
                Case "On"

                Case "Off"

                Case "Out"

            End Select
        End Sub
        Public Function DoublePuntoaComa(ByVal strNumero As String) As Double
            DoublePuntoaComa = Replace(strNumero, ".", ",")
        End Function

        Public Sub ExportarDataTableACSV(ByVal dt As DataTable, ByVal strRutaArchivoGuardar As String)
            Dim sb As New System.Text.StringBuilder()
            Dim aux As String = String.Empty

            For Each col As DataColumn In dt.Columns
                aux = (String.Format("{0}{1};", aux, col.ColumnName))
            Next
            sb.AppendLine(aux.Substring(0, aux.Length - 1)) ' Elimino el último ;
            aux = String.Empty

            For Each row As DataRow In dt.Rows
                For Each col As DataColumn In dt.Columns
                    aux = (String.Format("{0}{1};", aux, row(col.ColumnName).ToString()))
                Next
                sb.AppendLine(aux.Substring(0, aux.Length - 1)) ' Elimino el último ;
                aux = String.Empty
            Next
            ' Creo un archivo CSV temporal
            Dim FILE_NAME As String = strRutaArchivoGuardar
            Dim stream As New System.IO.StreamWriter(FILE_NAME, False, System.Text.Encoding.UTF8) ' La codificación debe ser UTF8

            stream.Write(sb.ToString())
            stream.Close()
            stream = Nothing
        End Sub
    End Module
End Namespace