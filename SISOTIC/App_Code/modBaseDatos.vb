Imports System.Data
Imports Clases
Imports Modulos
Imports System.IO

Namespace Modulos

    Public Module modBaseDatos
        Public RutaSimple As String

        ' Funcion que transforma un string SQL
        Function StringSql(ByVal valor As String) As String
            If valor = "" Then
                StringSql = "''"
                Exit Function
            End If
            valor = SinTilde(valor)
            valor = valor.ToUpper
            Select Case TipoBd().ToUpper
                Case "SQL"
                    StringSql = "'" & Replace(Trim(valor.ToUpper), "'", "''") & "'"
                Case "ORACLE"
                    If valor = "" Then
                        StringSql = "'" & Replace(Trim(valor.ToUpper), "'", "''") & "'"
                    Else
                        StringSql = "'" & Replace(Trim(valor.ToUpper), "'", "''") & "'"
                    End If
            End Select
        End Function
        Function LeftJoin() As String
            Select Case TipoBd().ToUpper
                Case "SQL"
                    LeftJoin = "*="
                Case "ORACLE"
                    LeftJoin = "(+)="
            End Select
        End Function
        ' Funcion que concatena textos (Campos)
        Function Mas() As String
            Select Case TipoBd().ToUpper
                Case "SQL"
                    Mas = "+"
                Case "ORACLE"
                    Mas = "||"
            End Select
        End Function
        ' Función que transforma un string para que pueda ser buscado
        ' dentro de una consulta o SP de sql
        Function SubStringSql(ByVal valor As String) As String
            If Trim(valor) = "" Then
                SubStringSql = "'%'"
            Else
                SubStringSql = "'%" & Replace(valor, "'", "''") & "%'"
            End If
        End Function
        'Función para busquedas
        'Pone el caracter % sólo al final del criterio
        Function SubStringSql2(ByVal valor As String) As String
            If Trim(valor) = "" Then
                SubStringSql2 = "'%'"
            Else
                SubStringSql2 = "'" & Replace(valor, "'", "''") & "%'"
            End If
        End Function
        'Función para busquedas
        'no agrega el caracter % 
        Function SubStringSql3(ByVal valor As String) As String
            If Trim(valor) = "" Then
                SubStringSql3 = "'%'"
            Else
                SubStringSql3 = "'" & Replace(valor, "'", "''") & "'"
            End If
        End Function
        Public Function FechaVbABd(ByVal dtmFecha As Date) As String
            Dim agno, mes, Dia As String
            agno = dtmFecha.Year
            mes = dtmFecha.Month
            Dia = dtmFecha.Day
            If Len(mes) < 2 Then mes = "0" & mes
            If Len(Dia) < 2 Then Dia = "0" & Dia
            Select Case TipoBd().ToUpper
                Case "SQL"
                    FechaVbABd = "'" & agno & mes & Dia & "'"
                Case "ORACLE"
                    FechaVbABd = "TO_DATE('" & agno & mes & Dia & "', 'yyyymmdd')"
            End Select

        End Function
        Public Function FechaVbABdAccess(ByVal dtmFecha As Date) As String
            Dim agno, mes, Dia As String
            agno = dtmFecha.Year
            mes = dtmFecha.Month
            Dia = dtmFecha.Day
            If Len(mes) < 2 Then mes = "0" & mes
            If Len(Dia) < 2 Then Dia = "0" & Dia
            FechaVbABdAccess = "'" & Dia & "-" & mes & "-" & agno & "'"
        End Function
        'retorna la resta en días de dos fechas
        Function DiffDiasFechasBd(ByVal f1 As String, ByVal f2 As String) As String
            Select Case TipoBd().ToUpper
                Case "SQL"
                    DiffDiasFechasBd = "DATEDIFF(Day," & f2 & "," & f1 & ")"
                Case "ORACLE"
                    DiffDiasFechasBd = f1 & " - " & f2
            End Select
        End Function

        'retorna la resta en días de dos fechas
        Function DiffSegFechasBd(ByVal f1 As String, ByVal f2 As String) As String
            Select Case TipoBd().ToUpper
                Case "SQL"
                    DiffSegFechasBd = "DATEDIFF(ss," & f2 & "," & f1 & ")"
                Case "ORACLE"
                    DiffSegFechasBd = "(" & f1 & " - " & f2 & ") * 86400"
            End Select
        End Function

        'retorna el dia de hoy
        Function HoyBd() As String
            Select Case TipoBd().ToUpper
                Case "SQL"
                    HoyBd = "GETDATE()"
                Case "ORACLE"
                    HoyBd = "SYSDATE"
            End Select
        End Function

        Function IsNullCampo(ByVal strNombreCampo As String, ByVal vntValorNulo As Object) As String
            If Not IsNumeric(vntValorNulo) Then
                vntValorNulo = "'" & vntValorNulo & "'"
            End If
            Select Case TipoBd().ToUpper
                Case "SQL"
                    IsNullCampo = " IsNull(" & strNombreCampo & "," & vntValorNulo & ") "
                Case "ORACLE"
                    IsNullCampo = " NVL(" & strNombreCampo & "," & vntValorNulo & ") "
            End Select
        End Function

        ' funcion para truncar campos de texto, para Sql Server
        Function Convert4000(ByVal campo As String)
            Select Case TipoBd().ToUpper
                Case "SQL"
                    Convert4000 = "convert(varchar(4000)," & campo & ")"
                Case "ORACLE"
                    Convert4000 = campo
            End Select
        End Function
        'funcion para Concatenar strings en sql
        Function ConcatenarSql(ByVal ParamArray arr() As Object) As String
            Dim strOper As String
            If TipoBd().ToUpper = "SQL" Then
                strOper = " + "
            ElseIf TipoBd().ToUpper = "ORACLE" Then
                strOper = " || "
            End If

            Dim i As Integer
            Dim strTmp As String
            strTmp = ""
            For i = 0 To UBound(arr)
                If i > 0 Then
                    strTmp = strTmp & strOper & arr(i)
                Else
                    strTmp = arr(i)
                End If
            Next
            ConcatenarSql = strTmp
        End Function
        Public Function WhereSinCursoAnulado(ByVal adicional As Boolean, ByVal seudonimo As String) As String

            If adicional Then
                If Trim(seudonimo) = "" Then
                    WhereSinCursoAnulado = " and cod_estado_curso <> 2 "
                Else
                    WhereSinCursoAnulado = " and " & seudonimo & " .cod_estado_curso <> 2 "
                End If
            Else
                If Trim(seudonimo) = "" Then
                    WhereSinCursoAnulado = " where cod_estado_curso <> 2 "
                Else
                    WhereSinCursoAnulado = " where " & seudonimo & " .cod_estado_curso <> 2 "
                End If
            End If
        End Function
        ' Función que transforma un número double a formato BD.
        Function DoubleVbABd(ByVal valor As Double) As String
            Dim strNumero As String
            strNumero = CStr(valor)
            strNumero = Replace(Trim(strNumero), ",", ".")
            DoubleVbABd = strNumero
        End Function
        Public Function BooleanVbAbd(ByVal estadoPreguntas As Boolean) As String
            If estadoPreguntas Then
                BooleanVbAbd = "1"
            Else
                BooleanVbAbd = "0"
            End If
        End Function

        'funcion para obtener el 1er valor retornado por una consulta
        Public Function PrimerValorDT(ByRef dt As DataTable) As Object
            Try
                If dt.Rows.Count <= 0 Then
                    Return Nothing
                Else
                    Return dt.Rows(0)(0)
                End If

            Catch ex As System.Exception
                EnviaError(ex.Message)
                Return Nothing
            End Try
        End Function
        'transforma variable de tipo boolean a bit
        Function BooleanAspAbd(ByVal estadoPreguntas As Boolean) As String
            If estadoPreguntas Then
                BooleanAspAbd = "1"
            Else
                BooleanAspAbd = "0"
            End If
        End Function
        ' Conversión de datetime desde formato VB a BD
        '
        Function FechaHoraVbABd(ByVal dtmFecha As Date) As String
            Dim Agno As String, mes As String, dia As String
            Dim hora As String, min As String, seg As String
            Agno = dtmFecha.Year
            mes = dtmFecha.Month
            dia = dtmFecha.Day
            hora = Hour(dtmFecha)
            min = Minute(dtmFecha)
            seg = Second(dtmFecha)
            If Len(mes) < 2 Then mes = "0" & mes
            If Len(dia) < 2 Then dia = "0" & dia
            If Len(hora) < 2 Then hora = "0" & hora
            If Len(min) < 2 Then min = "0" & min

            Select Case TipoBd().ToUpper
                Case "SQL"
                    FechaHoraVbABd = "'" & Agno & mes & dia _
                                     & " " & hora & ":" & min & ":" & seg & "'"
                Case "ORACLE"
                    FechaHoraVbABd = "TO_DATE('" & Agno & mes & dia & hora & min & seg & "', 'yyyymmddhh24miss')"
            End Select
        End Function
        Function FechaHoraBdAVb(ByVal strFechaEnSelectSql As String, Optional ByVal strAlias As String = "") As String
            Select Case TipoBd().ToUpper
                Case "SQL"
                    Return strFechaEnSelectSql & " " & strAlias
                Case "ORACLE"
                    Return "to_char(" & strFechaEnSelectSql & ",'dd/mm/yyyy hh:mi:ss')" & " " & strAlias
                Case Else
                    Return strFechaEnSelectSql
            End Select
        End Function
        'Función de Conversión a CSV
        'Ideal usarla para reportes de gran tamaño
        Public Function ConvierteDTaCSV(ByRef dtDatos As DataTable, _
            ByVal strRuta As String, _
            ByVal strNombreArchivo As String, _
            Optional ByVal strDelimitadorColumnas As String = ";", _
            Optional ByVal strDelimitadorRegistros As String = vbNewLine) As Boolean

            'Variables Locales
            Dim strSalida As String = ""
            Dim strRegistro As String
            Dim lngContadorRegistros As Integer = 0
            Dim intContadorColumnas As Integer = 0
            Dim strValor As String = ""
            Dim strNombreColumna As String = ""

            Try
                'Solo si hay datos
                If Not IsNothing(dtDatos) Then
                    'fila de titulos de columna
                    intContadorColumnas = 0
                    strRegistro = ""
                    'para cada columna
                    While intContadorColumnas < dtDatos.Columns.Count

                        strNombreColumna = dtDatos.Columns(intContadorColumnas).ColumnName

                        If strRegistro <> "" Then
                            strRegistro = strRegistro & strDelimitadorColumnas
                        End If

                        strValor = """" & strNombreColumna & """"
                        strRegistro = strRegistro & strValor

                        intContadorColumnas = intContadorColumnas + 1

                    End While
                    strSalida = strSalida & strRegistro

                    'procesa los registros del dataset
                    While lngContadorRegistros < dtDatos.Rows.Count
                        If strSalida <> "" Then
                            strSalida = strSalida & strDelimitadorRegistros
                        End If
                        strRegistro = ""
                        intContadorColumnas = 0
                        'para cada columna	
                        While intContadorColumnas < dtDatos.Columns.Count
                            If strRegistro <> "" Then
                                strRegistro = strRegistro & strDelimitadorColumnas
                            End If

                            If IsDBNull(dtDatos.Rows(lngContadorRegistros)(intContadorColumnas)) Then
                                strValor = ""
                            Else
                                strValor = dtDatos.Rows(lngContadorRegistros)(intContadorColumnas)
                            End If

                            If InStr(strValor, strDelimitadorColumnas) > 0 Then
                                strValor = """" & strValor & """"
                            End If
                            strRegistro = strRegistro & SinTilde(strValor)
                            intContadorColumnas = intContadorColumnas + 1
                        End While
                        'añade el registro
                        strSalida = strSalida & strRegistro.ToUpper
                        lngContadorRegistros = lngContadorRegistros + 1
                    End While
                End If
                GrabarSTRaTXT(strSalida, strRuta & strNombreArchivo)
                Return True
            Catch ex As Exception
                EnviaError("modBaeDatos.vb:ConvierteDTaCSV->" & ex.Message & " Fila: " & lngContadorRegistros & " Columna: " & intContadorColumnas)
            End Try
        End Function
        'Graba una variable string en un archivo de texto
        Public Sub GrabarSTRaTXT(ByRef strVar As String, ByVal strPath As String)
            Dim fp As TextWriter = New _
            StreamWriter(strPath, False, System.Text.Encoding.UTF8)

            fp.WriteLine(strVar)
            fp.Close()
        End Sub
        'Sirve para ser utilizado dentro de un SELECT y que el resultado de la fecha
        'venga en el formato dd/mm/aaaa
        Public Function FechaBDaUSR(ByVal strNombreCampoFecha As String) As String

            Select Case TipoBd().ToUpper
                Case "SQL"
                    FechaBDaUSR = "Convert(varchar(10)," & strNombreCampoFecha & ", 103) "
                Case "ORACLE"
                    FechaBDaUSR = "to_char(" & strNombreCampoFecha & ",'dd/mm/yyyy') "
            End Select
        End Function
    End Module
End Namespace
