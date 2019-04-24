Imports Clases
Namespace Modulos
    Public Module modFunciones
        'Manejador de Errores
        Public Sub EnviaError(ByVal strError As String)
            Dim objFile As New CArchivoTxt
            objFile.Ruta = DIRFISICOAPP() & "contenido\logs\errapp.txt"
            objFile.AgregarLinea(Now.ToString & "|" & strError)
            objFile = Nothing

            'Si el modo debus está activa, la aplicación caerá feamente
            'Hago caer la aplicación para mostrar el error en web
            Throw New Exception("Error controlado por Sistema!!")
        End Sub
        Public Function FechaMaxSistema() As Date
            FechaMaxSistema = DateSerial(3000, 1, 1)
        End Function
        Public Function FechaMinSistema() As Date
            FechaMinSistema = DateSerial(1900, 1, 1)
        End Function
        Public Function FechaMaxAgno(ByVal intAgno As Integer) As Date
            FechaMaxAgno = DateSerial(intAgno, 12, 31) & " 23:59:59"
        End Function
        Public Function FechaMinAgno(ByVal intAgno As Integer) As Date
            FechaMinAgno = DateSerial(intAgno, 1, 1) & " 0:00:00"
        End Function
        'Rellena a la derecha del caracter seleccionado, dejando el tamano del string uniforme
        Public Function LlenaCarDer(ByVal strTexto As String, ByVal intTamanoTotal As Integer, ByVal strCaracter As String) As String
            If intTamanoTotal < 0 Or strCaracter.Length < 1 Or intTamanoTotal < strTexto.Length Then
                Return strTexto
            End If
            Dim i As Integer
            Dim strResultado As String = strTexto
            For i = strTexto.Length + 1 To intTamanoTotal
                strResultado &= strCaracter
            Next
            Return strResultado
        End Function
        'Rellena a la derecha del caracter seleccionado, dejando el tamano del string uniforme
        Public Function LlenaCarIzq(ByVal strTexto As String, ByVal intTamanoTotal As Integer, ByVal strCaracter As String) As String
            If intTamanoTotal < 0 Or strCaracter.Length < 1 Or intTamanoTotal < strTexto.Length Then
                Return strTexto
            End If
            Dim i As Integer
            Dim strResultado As String = strTexto
            For i = strTexto.Length + 1 To intTamanoTotal
                strResultado = strCaracter & strResultado
            Next
            Return strResultado
        End Function
        Public Function EsNumero(ByVal strValor As String) As Boolean
            If IsNumeric(strValor) Then
                Return True
            Else
                Return False
            End If
        End Function
        Function FechaUsrAVb(ByVal strFecha As String) As Date
            Try
                If strFecha = "" Then
                    Return FechaMinSistema()
                End If
                Dim Agno, mes, dia As String
                Dim arrFecha
                arrFecha = Split(strFecha, "/")
                If TamanoArreglo1(arrFecha) < 3 Then
                    arrFecha = Split(strFecha, "-")
                End If

                Agno = Left(arrFecha(2), 4)
                mes = arrFecha(1)
                dia = arrFecha(0)
                FechaUsrAVb = DateSerial(CInt(Agno), CInt(mes), CInt(dia))
            Catch ex As Exception
                EnviaError("modFunciones:FechaUsrAVb->" & ex.Message)
            End Try
        End Function
        ' Conversión de fechas desde formato VB a usuario
        Function FechaVbAUsr(ByVal dtmFecha As Date) As String
            Try
                If (dtmFecha = FechaMaxSistema()) Or (dtmFecha = FechaMinSistema()) Then
                    FechaVbAUsr = ""
                Else
                    Dim Agno, mes, dia As String
                    Agno = DatePart("yyyy", dtmFecha)
                    mes = DatePart("m", dtmFecha)
                    dia = DatePart("d", dtmFecha)
                    If Len(mes) < 2 Then mes = "0" & mes
                    If Len(dia) < 2 Then dia = "0" & dia
                    FechaVbAUsr = dia & "/" & mes & "/" & Agno
                End If
            Catch ex As Exception
                EnviaError("modFunciones:FechaVbAUsr->" & ex.Message)
            End Try
        End Function

        Public Function DiaUsrAInt(ByVal strDia As String) As Integer
            Select Case strDia.ToUpper
                Case "LUN"
                    Return 1
                Case "MAR"
                    Return 2
                Case "MIE"
                    Return 3
                Case "JUE"
                    Return 4
                Case "VIE"
                    Return 5
                Case "SAB"
                    Return 6
                Case "DOM"
                    Return 7
            End Select
        End Function
        Public Function DiaIntAUsr(ByVal intDia As Integer) As String
            Select Case intDia
                Case 1
                    Return "Lun"
                Case 2
                    Return "Mar"
                Case 3
                    Return "Mie"
                Case 4
                    Return "Jue"
                Case 5
                    Return "Vie"
                Case 6
                    Return "Sab"
                Case 7
                    Return "Dom"
            End Select
        End Function
        Public Function DiaIntAUsrC(ByVal intDia As Integer) As String
            Select Case intDia
                Case 1
                    Return "Lunes"
                Case 2
                    Return "Martes"
                Case 3
                    Return "Miércoles"
                Case 4
                    Return "Jueves"
                Case 5
                    Return "Viernes"
                Case 6
                    Return "Sábado"
                Case 7
                    Return "Domingo"
            End Select
        End Function
        Public Function MesIntAUsr(ByVal intMes As Integer) As String
            Select Case intMes
                Case 1
                    Return "Enero"
                Case 2
                    Return "Febrero"
                Case 3
                    Return "Marzo"
                Case 4
                    Return "Abril"
                Case 5
                    Return "Mayo"
                Case 6
                    Return "Junio"
                Case 7
                    Return "Julio"
                Case 8
                    Return "Agosto"
                Case 9
                    Return "Septiembre"
                Case 10
                    Return "Octubre"
                Case 11
                    Return "Noviembre"
                Case 12
                    Return "Diciembre"
            End Select
        End Function

        'Devuelve la fecha escrita, DD XX de MMMMMMMM del AAAA
        Public Function FechaEscrita(ByVal dtmFecha As Date) As String
            Dim strFecha As String = ""
            strFecha &= DiaIntAUsrC(dtmFecha.DayOfWeek)
            strFecha = strFecha & " " & dtmFecha.Day
            strFecha = strFecha & " de " & MesIntAUsr(dtmFecha.Month)
            strFecha = strFecha & " del " & dtmFecha.Year
            Return strFecha
        End Function
        'Devuelve solo el año AAAA
        Public Function fncAnoSolo(ByVal dtmFecha As Date) As String
            Dim strFecha As String = ""
            'strFecha &= DiaIntAUsrC(dtmFecha.DayOfWeek)
            'strFecha = strFecha & " " & dtmFecha.Day
            'strFecha = strFecha & " de " & MesIntAUsr(dtmFecha.Month)
            strFecha = strFecha & dtmFecha.Year
            Return strFecha
        End Function
        'Pasa los datos de un arreglo a un DataTable
        Function Arreglo_DT(ByVal arrArreglo As System.Collections.ArrayList, ByVal grdGrilla As GridView) As Data.DataTable

        End Function

        'Eliminar un registro de una Colección
        Function Eliminar_Reg(ByVal colColeccion As Collection, ByVal lngRutEmpl As Long)

        End Function

        'Agregar un registro de una Colección
        Function Agregar_Reg(ByVal colColeccion As Collection, ByVal lngRutEmpl As Long)

        End Function

        'Remplazar caracteres no permitidos
        Function SinTilde(ByVal strTexto As String) As String
            'Reemplza los siguientes caracteres :
            'Ñ,ñ=n - á,à=a - é,è=e - í,ì=i ó,ò=o - ú,ù=u
            'todo esto a la cadena strTexto
            strTexto = Replace(strTexto, "ñ", "n")
            strTexto = Replace(strTexto, "Ñ", "n")
            strTexto = Replace(strTexto, "á", "a")
            strTexto = Replace(strTexto, "Á", "A")
            strTexto = Replace(strTexto, "à", "a")
            strTexto = Replace(strTexto, "À", "A")
            strTexto = Replace(strTexto, "é", "e")
            strTexto = Replace(strTexto, "É", "E")
            strTexto = Replace(strTexto, "è", "e")
            strTexto = Replace(strTexto, "È", "E")
            strTexto = Replace(strTexto, "í", "i")
            strTexto = Replace(strTexto, "Í", "I")
            strTexto = Replace(strTexto, "ì", "i")
            strTexto = Replace(strTexto, "Ì", "I")
            strTexto = Replace(strTexto, "ó", "o")
            strTexto = Replace(strTexto, "Ó", "O")
            strTexto = Replace(strTexto, "ò", "o")
            strTexto = Replace(strTexto, "Ò", "O")
            strTexto = Replace(strTexto, "ú", "u")
            strTexto = Replace(strTexto, "Ú", "U")
            strTexto = Replace(strTexto, "ù", "u")
            strTexto = Replace(strTexto, "Ù", "U")

            'Regreso la variable
            Return strTexto
        End Function
        Public Function validarut(ByVal strrut As String) As Boolean
            Dim digito As String
            Dim digito2 As String
            Dim lngRutEmplusuario As Long
            Dim m As Integer
            m = Len(strrut)
            digito = ""
            digito2 = ""
            If EsRut(strrut) And m > 0 Then
                lngRutEmplusuario = RutUsrALng(strrut)
                digito2 = Trim(digito_verificador(lngRutEmplusuario)).ToString.ToUpper
                digito = Mid(strrut, m, 1).ToString.ToUpper
                ' 
            End If
            If digito.Trim = digito2 And digito <> "" And EsRut(strrut) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function EsFechaValidaVB(ByVal strFecha As String) As Boolean

            Dim arrfecha2()
            Try

                arrfecha2 = strFecha.Split("/")

                If (arrfecha2(0) > 31 Or arrfecha2(0) < 1) Then
                    Return False
                End If

                If (arrfecha2(1) > 12 Or arrfecha2(1) < 1) Then
                    Return False
                End If

                If (arrfecha2(2) > (Now.Year + 100) Or arrfecha2(2) < (Now.Year - 100)) Then
                    Return False
                End If

                Return True
            Catch
                'Grabar en log de error
            End Try

        End Function
        Public Function validaSimbolo(ByVal str As String) As Boolean

        End Function

        'Reemplaza los parámetros por valores
        Private Function SqlParam(ByVal strQuery As String, ByRef arrParam As Array) As String
            Try
                Dim intMaxParam, i As Integer
                intMaxParam = arrParam.GetLength(0)  'tamaño del arreglo
                For i = 0 To intMaxParam - 1
                    strQuery = Replace(strQuery, "[" & i & "]", arrParam(i))
                Next

                SqlParam = strQuery
            Catch ex As Exception
                EnviaError(ex.Message)
            End Try
        End Function
        Public Function FormatoMonto(ByVal Monto As Double) As String
            FormatoMonto = Format(Monto, "###,###,###,##0")
        End Function
        Public Function FormatoPeso(ByVal Monto As Double) As String
            FormatoPeso = "$" & Format(Monto, "###,###,###,##0")
        End Function
        Public Function FormatoSexo(ByVal sexo As String) As String
            sexo = Replace(sexo, "F", "Femenino")
            sexo = Replace(sexo, "M", "Masculino")

            Return sexo
        End Function
        Public Function Numero_a_Letras(ByVal numero As String) As String
            '********Declara variables de tipo cadena************
            Dim palabras, entero, dec, flag As String

            '********Declara variables de tipo entero***********
            Dim num, x, y As Integer

            flag = "N"

            '**********Número Negativo***********
            If Mid(numero, 1, 1) = "-" Then
                numero = Mid(numero, 2, numero.ToString.Length - 1).ToString
                palabras = "menos "
            End If

            '**********Si tiene ceros a la izquierda*************
            For x = 1 To numero.ToString.Length
                If Mid(numero, 1, 1) = "0" Then
                    numero = Trim(Mid(numero, 2, numero.ToString.Length).ToString)
                    If Trim(numero.ToString.Length) = 0 Then palabras = ""
                Else
                    Exit For
                End If
            Next

            '*********Dividir parte entera y decimal************
            For y = 1 To Len(numero)
                If Mid(numero, y, 1) = "." Then
                    flag = "S"
                Else
                    If flag = "N" Then
                        entero = entero + Mid(numero, y, 1)
                    Else
                        dec = dec + Mid(numero, y, 1)
                    End If
                End If
            Next y

            If Len(dec) = 1 Then dec = dec & "0"

            '**********proceso de conversión***********
            flag = "N"

            If Val(numero) <= 999999999 Then
                For y = Len(entero) To 1 Step -1
                    num = Len(entero) - (y - 1)
                    Select Case y
                        Case 3, 6, 9
                            '**********Asigna las palabras para las centenas***********
                            Select Case Mid(entero, num, 1)
                                Case "1"
                                    If Mid(entero, num + 1, 1) = "0" And Mid(entero, num + 2, 1) = "0" Then
                                        palabras = palabras & "cien "
                                    Else
                                        palabras = palabras & "ciento "
                                    End If
                                Case "2"
                                    palabras = palabras & "doscientos "
                                Case "3"
                                    palabras = palabras & "trescientos "
                                Case "4"
                                    palabras = palabras & "cuatrocientos "
                                Case "5"
                                    palabras = palabras & "quinientos "
                                Case "6"
                                    palabras = palabras & "seiscientos "
                                Case "7"
                                    palabras = palabras & "setecientos "
                                Case "8"
                                    palabras = palabras & "ochocientos "
                                Case "9"
                                    palabras = palabras & "novecientos "
                            End Select
                        Case 2, 5, 8
                            '*********Asigna las palabras para las decenas************
                            Select Case Mid(entero, num, 1)
                                Case "1"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        flag = "S"
                                        palabras = palabras & "diez "
                                    End If
                                    If Mid(entero, num + 1, 1) = "1" Then
                                        flag = "S"
                                        palabras = palabras & "once "
                                    End If
                                    If Mid(entero, num + 1, 1) = "2" Then
                                        flag = "S"
                                        palabras = palabras & "doce "
                                    End If
                                    If Mid(entero, num + 1, 1) = "3" Then
                                        flag = "S"
                                        palabras = palabras & "trece "
                                    End If
                                    If Mid(entero, num + 1, 1) = "4" Then
                                        flag = "S"
                                        palabras = palabras & "catorce "
                                    End If
                                    If Mid(entero, num + 1, 1) = "5" Then
                                        flag = "S"
                                        palabras = palabras & "quince "
                                    End If
                                    If Mid(entero, num + 1, 1) > "5" Then
                                        flag = "N"
                                        palabras = palabras & "dieci"
                                    End If
                                Case "2"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "veinte "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "veinti"
                                        flag = "N"
                                    End If
                                Case "3"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "treinta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "treinta y "
                                        flag = "N"
                                    End If
                                Case "4"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "cuarenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "cuarenta y "
                                        flag = "N"
                                    End If
                                Case "5"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "cincuenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "cincuenta y "
                                        flag = "N"
                                    End If
                                Case "6"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "sesenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "sesenta y "
                                        flag = "N"
                                    End If
                                Case "7"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "setenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "setenta y "
                                        flag = "N"
                                    End If
                                Case "8"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "ochenta "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "ochenta y "
                                        flag = "N"
                                    End If
                                Case "9"
                                    If Mid(entero, num + 1, 1) = "0" Then
                                        palabras = palabras & "noventa "
                                        flag = "S"
                                    Else
                                        palabras = palabras & "noventa y "
                                        flag = "N"
                                    End If
                            End Select
                        Case 1, 4, 7
                            '*********Asigna las palabras para las unidades*********
                            Select Case Mid(entero, num, 1)
                                Case "1"
                                    If flag = "N" Then
                                        If y = 1 Then
                                            palabras = palabras & "uno "
                                        Else
                                            palabras = palabras & "un "
                                        End If
                                    End If
                                Case "2"
                                    If flag = "N" Then palabras = palabras & "dos "
                                Case "3"
                                    If flag = "N" Then palabras = palabras & "tres "
                                Case "4"
                                    If flag = "N" Then palabras = palabras & "cuatro "
                                Case "5"
                                    If flag = "N" Then palabras = palabras & "cinco "
                                Case "6"
                                    If flag = "N" Then palabras = palabras & "seis "
                                Case "7"
                                    If flag = "N" Then palabras = palabras & "siete "
                                Case "8"
                                    If flag = "N" Then palabras = palabras & "ocho "
                                Case "9"
                                    If flag = "N" Then palabras = palabras & "nueve "
                            End Select
                    End Select

                    '***********Asigna la palabra mil***************
                    If y = 4 Then
                        If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                        (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                        Len(entero) <= 6) Then palabras = palabras & "mil "
                    End If

                    '**********Asigna la palabra millón*************
                    If y = 7 Then
                        If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                            palabras = palabras & "millón "
                        Else
                            palabras = palabras & "millones "
                        End If
                    End If
                Next y

                '**********Une la parte entera y la parte decimal*************
                If dec <> "" Then
                    Numero_a_Letras = palabras.ToUpper & "CON " & dec.ToUpper
                Else
                    Numero_a_Letras = palabras.ToUpper
                End If
            Else
                Numero_a_Letras = ""
            End If
        End Function
        Public Function Num2Text(ByVal value As Double) As String
            Select Case value
                Case 0 : Num2Text = "CERO"
                Case 1 : Num2Text = "UN"
                Case 2 : Num2Text = "DOS"
                Case 3 : Num2Text = "TRES"
                Case 4 : Num2Text = "CUATRO"
                Case 5 : Num2Text = "CINCO"
                Case 6 : Num2Text = "SEIS"
                Case 7 : Num2Text = "SIETE"
                Case 8 : Num2Text = "OCHO"
                Case 9 : Num2Text = "NUEVE"
                Case 10 : Num2Text = "DIEZ"
                Case 11 : Num2Text = "ONCE"
                Case 12 : Num2Text = "DOCE"
                Case 13 : Num2Text = "TRECE"
                Case 14 : Num2Text = "CATORCE"
                Case 15 : Num2Text = "QUINCE"
                Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
                Case 20 : Num2Text = "VEINTE"
                Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
                Case 30 : Num2Text = "TREINTA"
                Case 40 : Num2Text = "CUARENTA"
                Case 50 : Num2Text = "CINCUENTA"
                Case 60 : Num2Text = "SESENTA"
                Case 70 : Num2Text = "SETENTA"
                Case 80 : Num2Text = "OCHENTA"
                Case 90 : Num2Text = "NOVENTA"
                Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
                Case 100 : Num2Text = "CIEN"
                Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
                Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
                Case 500 : Num2Text = "QUINIENTOS"
                Case 700 : Num2Text = "SETECIENTOS"
                Case 900 : Num2Text = "NOVECIENTOS"
                Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
                Case 1000 : Num2Text = "MIL"
                Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
                Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                    If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
                Case 1000000 : Num2Text = "UN MILLON"
                Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
                Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                    If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
                Case 1000000000000.0# : Num2Text = "UN BILLON"
                Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
                Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                    If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            End Select
        End Function
        Public Function validaMail(ByVal strEmail As String) As Boolean
            Dim email As String
            Dim bandera3 As Integer
            email = strEmail
            If email <> "" Then
                Dim partes, parte, letra
                Dim i As Integer
                partes = Split(email, "@")
                If UBound(partes) <> 1 Then
                    'lblerroremail.Text = "FORMATO PARA EMAIL INCORRECTO, ASEGURESE QUE SEA COMO EL EJEMPLO: email@dominio.pop"
                    bandera3 = 0
                    Return False
                    Exit Function
                Else
                    For Each parte In partes
                        bandera3 = 1
                        For i = 1 To Len(parte)
                            letra = LCase(Mid(parte, i, 1))
                            If InStr("._-abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ", letra) <= 0 Then
                                'lblerroremail.Text = "NO SE ACEPTA EL USO DE CARACTERES ESPECIALES COMO ñ,&,*,+,/,%,$"
                                bandera3 = 0
                                Return False
                                Exit Function
                                Exit For
                            End If
                        Next i
                        'si la parte actual acaba o empieza en punto la dirección no es válida
                        If Left(parte, 1) = "." Or Right(parte, 1) = "." Then
                            'lblerroremail.Text = "EL CORREO TIENE EL SIMBOLO ''.'' MAL COLOCADO, VERIFIQUE SU ESCRITURA"
                            bandera3 = 0
                            Return False
                            Exit Function
                        End If
                        If bandera3 = 0 Then
                            Exit For
                        End If
                    Next parte
                    'va.lidar la segunda mitad donde hay el . mas 2 o 3 caracteres
                    'si en la segunda mitad no existe un punto
                    If Not bandera3 = 0 Then
                        If InStr(partes(1), ".") <= 0 Then
                            'lblerroremail.Text = "FORMATO PARA EMAIL INCORRECTO, ASEGURESE QUE SEA COMO EL EJEMPLO: email@dominio.pop"
                            bandera3 = 0
                            Return False
                            Exit Function

                        End If

                        i = Len(partes(1)) - InStrRev(partes(1), ".")
                        'si el número de caracteres despues del punto es distinto de 2 y 3

                        If Not (i = 2 Or i = 3) Then
                            'lblerroremail.Text = "FORMATO PARA EMAIL INCORRECTO, ASEGURESE QUE SEA COMO EL EJEMPLO: email@dominio.pop"
                            bandera3 = 0
                            Return False
                            Exit Function
                        Else
                            'si encuentra dos puntos seguidos
                            If InStr(email, "..") > 0 Then
                                'lblerroremail.Text = "FORMATO PARA EMAIL INCORRECTO, ASEGURESE QUE SEA COMO EL EJEMPLO: email@dominio.pop"
                                bandera3 = 0
                                Return False
                                Exit Function
                            Else

                            End If
                        End If
                    End If

                End If
                Return True
                'lblerroremail.Text = "FORMATO PARA EMAIL INCORRECTO, ASEGURESE QUE SEA COMO EL EJEMPLO: email@dominio.pop"
            Else
                'si no hay texto encendemos la bandera
                bandera3 = 1
                Return False
            End If
        End Function
        Public Function ProximoDiaHabil() As Date
            Try
                Dim Dia As Date
                Dia = DateAdd(DateInterval.Day, 1, Now.Date)
                Dim mobjCsql As New CSql
                Dim Habil As Boolean = False
                Do While Habil = False
                    If mobjCsql.s_es_dia_habil(Dia) Then
                        Habil = True
                    Else
                        Habil = False
                        Dia = DateAdd(DateInterval.Day, 1, Dia)
                    End If
                Loop
                Return Dia
            Catch ex As Exception
                EnviaError("modFunciones:ProximoDiaHabil-->" & ex.Message)
            End Try
        End Function

#Region "Funciones Cursos Consolidados"

        Public Function fstrCursosPagadosMixCuentas(ByVal lngRutUsuario As Long) As String


            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutUsuario

            strQuery = _
                      " From curso_contratado cc " _
                      & " where cc.cod_curso in (Select cc1.cod_curso " _
                      & " From Transaccion tr1 , Curso_Contratado cc1 ,v_cliente_permiso vcp" _
                      & " Where vcp.rut_usuario = [0] " _
                      & " And vcp.rut_empresa =cc1.rut_cliente " _
                      & " and cc1.rut_cliente=tr1.rut_cliente " _
                      & " and cc1.cod_curso = tr1.cod_curso " _
                      & " And nro_transaccion = (Select Max(tr2.nro_transaccion) " _
                      & " From Transaccion tr2 " _
                      & " Where tr2.cod_curso = tr1.cod_curso " _
                      & " and tr2.cod_cuenta = tr1.cod_cuenta " _
                      & " And tr2.rut_cliente = tr1.rut_cliente " _
                      & " and tr2.cod_cuenta <> 3 ) And monto > 0 " _
                      & " group by cc1.cod_curso " _
                      & " having count(*) > 1 ) "

            fstrCursosPagadosMixCuentas = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosPagadosCtaExcCap(ByVal lngRutUsuario As Long, _
                                           ByVal lngCodCuenta As Long, _
                                           ByVal intEstados As Integer, _
                                           ByVal strCursosPropios As String, _
                                          Optional ByVal intAgno As Integer = 0 _
                                          ) As String


            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutUsuario
            arrParam(1) = lngCodCuenta
            'arrParam(2) = intAgno
            

            Dim strFrom, strWhere As String
            strFrom = ""
            strWhere = ""

            If intEstados = 1 And strCursosPropios = "SI" Then
                strWhere = " And  e.rut_ejecutivo = [0]  " & strWhere
            End If

            '2: Cuando esta marcada la opcion Todos los ejecutivos en el combobox
            If intEstados = 2 And strCursosPropios = "NO" Then
                strWhere = " And s.rut_supervisor=[0] " _
                        & " And s.rut_ejecutivo=e.rut_ejecutivo " & strWhere
                strFrom = " ,supervisor s " & strFrom
            End If

            'If intAgno <> 0 Then
            '    strWhere = " And cc1.agno = [2] " & strWhere
            'End If

            strQuery = _
                      " From curso_contratado cc " _
                      & " where cc.cod_curso in (Select cc1.cod_curso " _
                      & " From Transaccion tr1 , Curso_Contratado cc1,v_cliente_permiso vcp, " _
                      & " ejecutivo e  " _
                      & strFrom _
                      & " Where vcp.rut_usuario = [0] " _
                      & " And vcp.rut_empresa =cc1.rut_cliente " _
                      & " and cc1.rut_cliente=tr1.rut_cliente " _
                      & " And cc1.rut_cliente=e.rut_empresa " _
                      & " and cc1.cod_curso = tr1.cod_curso " _
                      & strWhere _
                      & " And nro_transaccion = (Select Max(tr2.nro_transaccion) " _
                      & " From Transaccion tr2 " _
                      & " Where tr2.cod_curso = tr1.cod_curso " _
                      & " And tr2.cod_cuenta = tr1.cod_cuenta " _
                      & " And tr2.rut_cliente = tr1.rut_cliente " _
                      & " and tr2.cod_cuenta <> 3 ) " _
                      & " And monto > 0 and tr1.cod_cuenta = [1])"

            fstrCursosPagadosCtaExcCap = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosPagadosCtaCap(ByVal lngRutUsuario As Long, _
                                                ByVal lngCodCuenta As Long, _
                                                ByVal intEstados As Integer, _
                                                ByVal strCursosPropios As String, _
                                                Optional ByVal intAgno As Integer = 0) As String

            Dim strQuery As String, arrParam(1)
            arrParam(0) = lngRutUsuario
            arrParam(1) = lngCodCuenta
            'arrParam(2) = intAgno

            Dim strFrom, strWhere As String
            strFrom = ""
            strWhere = ""

            If intEstados = 1 And strCursosPropios = "SI" Then
                strWhere = " And  e.rut_ejecutivo = [0]  " & strWhere
            End If

            '2: Cuando esta marcada la opcion Todos los ejecutivos en el combobox
            If intEstados = 2 And strCursosPropios = "NO" Then
                strWhere = " And s.rut_supervisor=[0] " _
                        & " And s.rut_ejecutivo=e.rut_ejecutivo " & strWhere
                strFrom = " ,supervisor s " & strFrom
            End If
            'If intAgno <> 0 Then
            '    strWhere = " And cc1.agno = [2] " & strWhere
            'End If
            strQuery = _
                        " From curso_contratado cc  " _
                        & "where cc.cod_curso in ( Select cc1.cod_curso " _
                        & "From Transaccion tr1 , Curso_Contratado cc1 , v_cliente_permiso vcp, " _
                        & " ejecutivo e " _
                        & strFrom _
                        & "Where vcp.rut_usuario  = [0] " _
                        & "And vcp.rut_empresa =cc1.rut_cliente " _
                        & "And cc1.rut_cliente=e.rut_empresa " _
                        & strWhere _
                        & "and cc1.rut_cliente=tr1.rut_cliente " _
                        & "and cc1.cod_curso = tr1.cod_curso " _
                        & "And nro_transaccion = (Select Max(tr2.nro_transaccion) " _
                        & "From Transaccion tr2 " _
                        & "Where tr2.cod_curso = tr1.cod_curso " _
                        & "and tr2.cod_cuenta = tr1.cod_cuenta " _
                        & "and tr2.rut_cliente = tr1.rut_cliente " _
                        & "and tr2.cod_cuenta <> 3 ) And monto > 0 " _
                        & "group by cc1.cod_curso " _
                        & "HAVING (min(tr1.cod_cuenta)=[1]) and max(tr1.cod_cuenta)=[1]) "

            fstrCursosPagadosCtaCap = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosPagoTerceros(ByVal lngRutUsuario As Long, _
                                               ByVal intEstados As Integer, _
                                               ByVal strCursosPropios As String, _
                                               Optional ByVal intAgno As Integer = 0) As String

            Dim strQuery As String, arrParam(2)
            arrParam(0) = 8         'Código estado curso Eliminado
            arrParam(1) = 10         'Código estado curso Anulado
            arrParam(2) = lngRutUsuario
            ' arrParam(3) = intAgno

            Dim strFrom, strWhere As String
            strFrom = ""
            strWhere = ""

            If intEstados = 1 And strCursosPropios = "SI" Then
                strWhere = " And  e.rut_ejecutivo = [2]  " & strWhere
            End If

            '2: Cuando esta marcada la opcion Todos los ejecutivos en el combobox
            If intEstados = 2 And strCursosPropios = "NO" Then
                strWhere = " And s.rut_supervisor=[2] " _
                        & " And s.rut_ejecutivo=e.rut_ejecutivo " & strWhere
                strFrom = " ,supervisor s " & strFrom
            End If
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [3] " & strWhere
            'End If


            strQuery = _
                    " From Curso_Contratado cc , Solicitud_Pago_Terceros spt ,v_cliente_permiso vcp, " _
                  & " ejecutivo e " _
                  & strFrom _
                  & " Where vcp.rut_usuario = [2] " _
                  & " And vcp.rut_empresa=cc.rut_cliente " _
                  & " And e.rut_empresa=cc.rut_cliente " _
                  & " And cc.cod_curso=spt.cod_curso " _
                  & " And cc.cod_estado_curso <> [0] " _
                  & " And cc.cod_estado_curso <> [1] " _
                  & strWhere

            fstrCursosPagoTerceros = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosFechaTermino(ByVal lngRutUsuario As Long, _
                                               Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(4)

            arrParam(0) = 5         'Código estado curso Liquidado
            arrParam(1) = 8         'Código estado curso Eliminado
            arrParam(2) = 10         'Código estado curso Anulado
            arrParam(3) = FechaVbABd(Now())   'Fecha Actual
            arrParam(4) = lngRutUsuario
            'arrParam(5) = intAgno

            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [5] "
            'End If
            strQuery = _
                " From Curso_Contratado cc , v_cliente_permiso vcp " _
                & "Where (DateAdd(day, 55, cc.fecha_termino )) >= [3] and " _
                & " cc.cod_estado_curso <> [0] and cc.cod_estado_curso <> [1] " _
                & " and cc.cod_estado_curso <> [2] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [4]" _
                & strWhere

            fstrCursosFechaTermino = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosAtrasados(ByVal lngRutUsuario As Long, _
                                            Optional ByVal intAgno As Integer = 0) As String
            Dim strWhere As String
            Dim strQuery As String, arrParam(6)
            arrParam(0) = 0         'Código estado curso incompleto
            arrParam(1) = 1         'Código estado curso ingresado
            arrParam(2) = 2         'Código estado curso rechazado
            arrParam(3) = 3         'Código estado curso autorizado
            arrParam(4) = 7         'Código estado curso En Comunicacion
            arrParam(5) = FechaVbABd(DateAdd("w", 1, Now()))      'Fecha Actual + 1 día hábil
            arrParam(6) = lngRutUsuario
            'arrParam(7) = intAgno

            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [7] "
            'End If

            strQuery = _
                " From Curso_Contratado cc , v_cliente_permiso vcp " _
                & "Where (cc.cod_estado_curso = [0] Or " _
                & "cc.cod_estado_curso = [1] Or cc.cod_estado_curso = [2] " _
                & " Or cc.cod_estado_curso = [3] or cc.cod_estado_curso = [4]) " _
                & " And cc.fecha_inicio >= [5] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [6]" _
                & strWhere

            fstrCursosAtrasados = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosTerConAsisSinLiq(ByVal lngRutUsuario As Long, _
                                                   Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(7)
            arrParam(0) = FechaVbABd(Now())         'Fecha Actual
            arrParam(1) = 5
            arrParam(2) = 9
            arrParam(3) = 8
            arrParam(4) = 10
            arrParam(5) = 0
            arrParam(6) = 2
            arrParam(7) = lngRutUsuario
            'arrParam(8) = intAgno

            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [8] "
            'End If
            strQuery = _
                " From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.Fecha_Termino < [0] And cc.num_alumnos <> (Select Count(*) From participante p " _
                & "Where p.cod_curso = cc.cod_curso And p.porc_asistencia = 0.0) " _
                & "And cc.Cod_estado_curso <> [1] And cc.Cod_Estado_Curso <> [2] " _
                & "And cc.Cod_estado_curso <> [3] And cc.Cod_Estado_Curso <> [4] " _
                & "And cc.Cod_estado_curso <> [5] And cc.Cod_Estado_Curso <> [6] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [7]" _
                & strWhere

            fstrCursosTerConAsisSinLiq = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosTerSinAsis(ByVal lngRutUsuario As Long, _
                                            Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(5)
            arrParam(0) = FechaVbABd(Now())         'Fecha Actual
            arrParam(1) = 0                        'Código de curso incompleto
            arrParam(2) = 2                        'Código de curso rechazado
            arrParam(3) = 8                        'Código de curso eliminado
            arrParam(4) = 10                       'Código de curso anulado
            arrParam(5) = lngRutUsuario
            'arrParam(6) = intAgno

            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [6] "
            'End If
            strQuery = _
                "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.Fecha_Termino < [0] And cc.num_alumnos = (Select Count(*) From participante p " _
                & "Where p.cod_curso = cc.cod_curso And porc_asistencia = 0.0) " _
                & "And cc.cod_estado_curso <> [1] And cc.Cod_estado_curso <> [2] " _
                & "And cc.cod_estado_curso <> [3] And cc.Cod_estado_curso <> [4] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [5]" _
                & strWhere

            fstrCursosTerSinAsis = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursosIniNoAut(ByVal lngRutUsuario As Long, _
                                            Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(3)
            arrParam(0) = 1         'Código de curso ingresado
            arrParam(1) = 6         'Código de curso pago por autorizar
            arrParam(2) = FechaVbABd(Now())        'Fecha Actual
            arrParam(3) = lngRutUsuario
            'arrParam(4) = intAgno


            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [4] "
            'End If
            strQuery = _
                "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where (cc.cod_estado_curso = [0] Or " _
                & "cc.cod_estado_curso = [1]) And cc.fecha_inicio < [2] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [3] " _
                & strWhere


            fstrCursosIniNoAut = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los curso que tienen viáticos o traslado mayor que 0
        Public Function fstrCursosVYT(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String

            Dim strQuery As String, arrParam(0)
            Dim strWhere As String
            arrParam(0) = lngRutUsuario
            ' arrParam(1) = intAgno

            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [1] "
            'End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where (cc.total_viatico > 0 OR cc.total_traslado > 0) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "And vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosVYT = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los cursos que tienen más de 50 días pasada la fecha de término y no han sido liquidados
        Public Function fstrCursosTerNoLiq(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String

            Dim strQuery As String, arrParam(2)
            Dim strWhere As String
            Dim fechaMenos50 As String
            fechaMenos50 = FechaVbABd(DateAdd("d", -50, Now()))
            arrParam(0) = lngRutUsuario
            arrParam(2) = intAgno
            arrParam(1) = fechaMenos50
            strWhere = ""
            If intAgno <> 0 Then
                strWhere = " And cc.agno = [2] "
            End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where [1] > cc.fecha_termino " _
                & "And cc.cod_estado_curso not in (5,10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosTerNoLiq = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los cursos que tienen precontrato
        Public Function fstrCursosPreContrato(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String

            Dim strQuery As String, arrParam(0)
            Dim strWhere As String
            arrParam(0) = lngRutUsuario
            'arrParam(1) = intAgno
            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [1] "
            'End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_tipo_activ = 2 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosPreContrato = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los cursos que tienen postcontrato
        Public Function fstrCursosPostContrato(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String
            Dim strQuery As String, arrParam(0)
            Dim strWhere As String
            arrParam(0) = lngRutUsuario
            'arrParam(1) = intAgno
            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [1] "
            'End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_tipo_activ = 3 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosPostContrato = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los cursos que tienen Precenciales
        Public Function fstrCursosPrecenciales(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String
            Dim strQuery As String, arrParam(0)
            Dim strWhere As String
            arrParam(0) = lngRutUsuario
            'arrParam(1) = intAgno
            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [1] "
            'End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_modalidad = 1 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosPrecenciales = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los cursos que tienen ELearning
        Public Function fstrCursosELearning(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String
            Dim strQuery As String, arrParam(0)
            Dim strWhere As String
            arrParam(0) = lngRutUsuario
            'arrParam(1) = intAgno
            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [1] "
            'End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_modalidad = 2 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosELearning = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta por los cursos que tienen ELearning
        Public Function fstrCursosADistancia(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String
            Dim strQuery As String, arrParam(0)
            Dim strWhere As String
            arrParam(0) = lngRutUsuario
            'arrParam(1) = intAgno
            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [1] "
            'End If
            strQuery = _
                " From curso_contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_modalidad = 4 " _
                & "And cc.cod_estado_curso not in (10,8) " _
                & "And vcp.rut_empresa = cc.rut_cliente " _
                & "AND vcp.rut_usuario = [0] " _
                & strWhere
            fstrCursosADistancia = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        Public Function fstrCursoIniNoCom(ByVal lngRutUsuario As Long, _
                                          Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(4)
            arrParam(0) = 1         'Código de curso ingresado
            arrParam(1) = 3         'Código de curso autorizado
            arrParam(2) = 6         'Código de curso Pago Por autorizar
            arrParam(3) = FechaVbABd(Now())      'Fecha Actual
            arrParam(4) = lngRutUsuario
            'arrParam(5) = intAgno
            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And cc.agno = [5] "
            'End If

            strQuery = _
                "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where (cc.cod_estado_curso = [0] Or " _
                & "cc.cod_estado_curso = [1] Or cc.cod_estado_curso = [2]) " _
                & "And cc.fecha_inicio < [3] " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [4] " _
                & strWhere

            fstrCursoIniNoCom = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        'cursos parciales
        Public Function fstrParciales(ByVal lngRutUsuario As Long, _
                                      Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutUsuario
            'arrParam(1) = intAgno


            strWhere = ""
            'If intAgno <> 0 Then
            '    strWhere = " And year(cc.fecha_inicio) = [1] "
            'End If
            'no se cuentan los incompletos=0, rechazados=2, eliminados=8, anulados=10
            strQuery = _
                "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_curso_compl Is Not Null " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] " _
                & "And cc.cod_estado_curso Not In (0,2,8,10) " _
                & strWhere
            fstrParciales = SqlParam(strQuery, arrParam)
            Exit Function
        End Function

        'cursos complementarios
        Public Function fstrComplementos(ByVal lngRutUsuario As Long, _
                                         Optional ByVal intAgno As Integer = 0) As String

            Dim strWhere As String
            Dim strQuery As String, arrParam(0)
            arrParam(0) = lngRutUsuario
            'If intAgno <> 0 Then
            '    arrParam(1) = intAgno + 1
            'Else
            '    arrParam(1) = Year(Now()) + 1 'agno siguiente
            'End If

            'no se cuentan los incompletos=0, rechazados=2, eliminados=8, anulados=10
            strQuery = _
                "From Curso_Contratado cc, v_cliente_permiso vcp " _
                & "Where cc.cod_curso_parcial Is Not Null " _
                & "And cc.rut_cliente = vcp.rut_empresa " _
                & "And vcp.rut_usuario = [0] " _
                & "And cc.cod_estado_curso Not In (0,2,8,10) "

            '"From Curso_Contratado cc, v_cliente_permiso vcp " _
            '    & "Where cc.cod_curso_parcial Is Not Null " _
            '    & "And cc.rut_cliente = vcp.rut_empresa " _
            '    & "And vcp.rut_usuario = [0] " _
            '    & "And cc.agno = [1] " _
            '    & "And cc.cod_estado_curso Not In (0,2,8,10) "

            fstrComplementos = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'genera SQL (string) con los cursos indicados en los criterios
        Public Function fstrCursos(ByVal lngRutCliente As Long, _
                                        ByVal strEstados As String, _
                                        ByVal lngRutUsuario As Long, _
                                        Optional ByVal intEstados As Integer = 0, _
                                        Optional ByVal strCursosPropios As String = "") _
                                        As String

            'ByVal lngAgnoCurso As Long, _

            Dim strQuery As String, arrParam(3)
            arrParam(0) = lngRutCliente
            arrParam(1) = strEstados
            arrParam(2) = lngRutUsuario
            arrParam(3) = intEstados
            'arrParam(4) = lngAgnoCurso


            Dim strWhere, strFrom As String
            strFrom = ""
            strWhere = ""

            If lngRutCliente > 0 Then strWhere = " And cc.rut_cliente = [0] " & strWhere
            If strEstados <> "" Then strWhere = " And cc.cod_estado_curso IN ([1]) " & strWhere

            'filtros por período
            'If lngAgnoCurso <> 0 Then strWhere = "  And cc.agno = [4]  " & strWhere

            If intEstados = 1 And strCursosPropios = "SI" Then
                strWhere = " And  e.rut_ejecutivo = [2]  " & strWhere
            End If

            '2: Cuando esta marcada la opcion Todos los ejecutivos en el combobox
            'If intEstados = 2 Or strCursosPropios = "SI" Then
            If intEstados = 2 And strCursosPropios = "NO" Then
                strWhere = " And s.rut_supervisor=[2] " _
                         & " And s.rut_ejecutivo=e.rut_ejecutivo " & strWhere
                strFrom = " ,supervisor s " & strFrom
            End If


            strQuery = _
                "From Curso_Contratado cc, ejecutivo e " _
                & strFrom _
                & "Where e.rut_empresa=cc.rut_cliente " _
                & strWhere

            fstrCursos = SqlParam(strQuery, arrParam)
            Exit Function
        End Function


        'genera SQL (string) con los cursos indicados en los criterios
        Public Function fstrCursosContr(ByVal lngRutCliente As Long, _
                                        ByVal strEstados As String, _
                                        ByVal lngRutUsuario As Long, _
                                        ByVal lngCorrCST As Long, _
                                        ByVal strCorrEmp As String, _
                                        ByVal lngNroReg As Long, _
                                        ByVal lngRutEmp As Long, _
                                        ByVal strNombreEmp As String, _
                                        ByVal strCondCorrCST As String, _
                                        ByVal strCondCorrEmp As String, _
                                        ByVal strCondNroReg As String, _
                                        ByVal strCondRutEmp As String, _
                                        ByVal dtmFechaIni As Date, _
                                        ByVal dtmFechaFin As Date, _
                                        Optional ByVal intEstados As Integer = 0, _
                                        Optional ByVal strCursosPropios As String = "") _
                                        As String


            ' ByVal lngAgnoCurso As Long, _

            Dim strQuery As String, arrParam(14)
            arrParam(0) = lngRutCliente
            arrParam(1) = strEstados
            arrParam(2) = lngRutUsuario
            arrParam(3) = lngCorrCST
            arrParam(4) = StringSql(strCorrEmp)
            arrParam(5) = lngNroReg
            arrParam(6) = lngRutEmp
            arrParam(7) = SubStringSql(strNombreEmp)
            arrParam(8) = strCondCorrCST
            arrParam(9) = strCondCorrEmp
            arrParam(10) = strCondNroReg
            arrParam(11) = intEstados

            If strCondRutEmp = "" Or IsDBNull(strCondRutEmp) Then
                arrParam(11) = "="
            Else
                arrParam(11) = strCondRutEmp
            End If
            'arrParam(12) = lngAgnoCurso


            Dim strWhere, strFrom As String
            strFrom = ""
            strWhere = ""

            If lngRutCliente > 0 Then strWhere = " And cc.rut_cliente = [0] " & strWhere
            If strEstados <> "" Then strWhere = " And cc.cod_estado_curso IN ([1]) " & strWhere
            If lngCorrCST <> -1 Then strWhere = " And cc.correlativo [8] [3] " & strWhere
            If strCorrEmp <> "-1" Then strWhere = " And cc.correlativo_empresa [9] [4] " & strWhere
            If lngNroReg <> -1 Then strWhere = " And cc.nro_registro [10] [5] " & strWhere
            If lngRutEmp <> -1 Then strWhere = " And cc.rut_cliente [11] [6] " & strWhere
            If strNombreEmp <> "-1" Then
                strWhere = " And pj.rut = cc.rut_cliente And pj.razon_social like [7] " & strWhere
                strFrom = strFrom & " , persona_juridica pj "
            End If

            'filtros por período
            'If lngAgnoCurso <> 0 Then strWhere = "  And cc.agno = [12]  " & strWhere
            arrParam(14) = FechaVbABd(dtmFechaIni)
            arrParam(15) = FechaVbABd(DateAdd("d", 1, dtmFechaFin))  'sumar un día
            If dtmFechaIni <> FechaMinSistema() Or dtmFechaFin <> FechaMaxSistema() Then
                strWhere = " And cc.fecha_inicio >= [14] and cc.fecha_inicio < [15] " & strWhere
            End If

            If intEstados = 1 And strCursosPropios = "SI" Then
                strWhere = " And  e.rut_ejecutivo = [2]  " & strWhere
            End If

            '2: Cuando esta marcada la opcion Todos los ejecutivos en el combobox
            'If intEstados = 2 Or strCursosPropios = "SI" Then
            If intEstados = 2 And strCursosPropios = "NO" Then
                strWhere = " And s.rut_supervisor=[2] " _
                         & " And s.rut_ejecutivo=e.rut_ejecutivo " & strWhere
                strFrom = " ,supervisor s " & strFrom
            End If


            strQuery = _
                "From Curso_Contratado cc, ejecutivo e " _
                & strFrom _
                & "Where e.rut_empresa=cc.rut_cliente " _
                & strWhere

            fstrCursosContr = SqlParam(strQuery, arrParam)
            Exit Function
        End Function
        'Consulta el codigo de la comuna
        Public Function CodigoComuna(ByVal strNombreComuna As String) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = StringSql(strNombreComuna)

            strQuery = _
                " Select cod_comuna from comuna where nombre = [0] "

            CodigoComuna = SqlParam(strQuery, arrParam)
        End Function

        Public Function CodigoModalidad(ByVal strNombreModalidad As String) As Long
            Dim strQuery As String, arrParam(0)
            arrParam(0) = SubStringSql(strNombreModalidad)

            strQuery = _
                " Select cod_comuna from comuna where nombre like [0] "

            CodigoModalidad = SqlParam(strQuery, arrParam)
        End Function
        Public Function fSubStringSql1(ByVal valor As String) As String
            If Trim(valor) = "" Then
                fSubStringSql1 = "' '"
            Else
                fSubStringSql1 = "'" & valor & "'"
            End If
            fSubStringSql1 = Replace(fSubStringSql1, " ", " ")
        End Function

        Public Function CalcularCostoOticAlumno(ByVal lngHoras As Long, _
                                        ByVal lngValHoraSence As Double, _
                                        ByVal intIndAcuComBip As Integer, _
                                        ByVal lngHorasCompl As Long, _
                                        ByVal lngValorMercado As Long, _
                                        ByVal intIndDescPorc As Integer, _
                                        ByVal lngDescuento As Long, _
                                        ByVal intNumAlumnos As Integer, _
                                        ByVal dblPorcAsistencia As Double, _
                                        ByVal intCodEstadoCurso As Integer, _
                                        ByRef dblGastoEmpresaAlumno As Double, _
                                        ByVal dblPorcFranquicia As Double) As Double

            Dim dblMinimo As Double, dblAuxiliar As Double
            Dim dblValHoraCurso As Double, dblValHoraCursoFranquiciable As Double
            Dim lngValRealCurso As Long
            Dim dblValorParticipante As Double

            'curso con complemento: hay que calcular el valor de mercado y descuento,
            'redondeado al número de horas
            If lngHorasCompl > 0 Then
                Dim dblFactorHoras As Double
                'dblFactorHoras = (lngHoras - lngHorasCompl) / lngHoras
                'lngValorMercado = Math.Round(dblFactorHoras * lngValorMercado)
                If intIndDescPorc = 0 Then  'si el descuento es en monto
                    lngDescuento = Math.Round(lngDescuento * dblFactorHoras)
                End If

                'considerar las horas correspondientes al año actual
                'lngHoras = lngHoras - lngHorasCompl
            End If

            lngValRealCurso = Math.Round(lngValorMercado - (1 - intIndDescPorc) * lngDescuento - intIndDescPorc * lngDescuento * lngValorMercado / 100)
            If lngHoras <> 0 And intNumAlumnos <> 0 Then
                dblValHoraCurso = (lngValRealCurso / lngHoras) / intNumAlumnos
                dblValorParticipante = lngValRealCurso / intNumAlumnos
            Else
                dblValHoraCurso = -1
                dblValorParticipante = 0
            End If
            dblAuxiliar = lngValHoraSence * (1 + (0.2 * intIndAcuComBip))

            '    If dblAuxiliar <= dblValHoraCurso Then
            '        dblMinimo = dblAuxiliar
            '    Else
            '        dblMinimo = dblValHoraCurso
            '    End If


            If intIndAcuComBip = 1 Then
                'Toma el valor con comite Bº, si se excede del tope por participante se ajusta.
                'El valor hora del curso también es multiplicado por 1.2 (O sea se le suma el 20%)
                If dblAuxiliar <= (dblValHoraCurso * 1.2) Then
                    dblMinimo = dblAuxiliar
                Else
                    dblMinimo = dblValHoraCurso * 1.2
                End If
            Else
                'Si no toma el menor valor, si no es el curso...toma el tope por participante
                If dblAuxiliar <= dblValHoraCurso Then
                    dblMinimo = dblAuxiliar
                Else
                    dblMinimo = dblValHoraCurso
                End If
            End If

            dblValHoraCursoFranquiciable = dblMinimo

            If dblPorcAsistencia <= 1 Then dblPorcAsistencia = 100 * dblPorcAsistencia

            'chequeo de la asistencia del alumno, si corresponde.
            If (intCodEstadoCurso <> 5 And intCodEstadoCurso <> 9 And _
                intCodEstadoCurso <> 10 And intCodEstadoCurso <> 11) _
                Or dblPorcAsistencia >= 75 Then
                dblValHoraCursoFranquiciable = dblMinimo
            Else
                dblValHoraCursoFranquiciable = 0
            End If

            Dim dblTmpCostoOticAl As Double
            dblTmpCostoOticAl = (lngHoras * dblValHoraCursoFranquiciable * dblPorcFranquicia)
            'Si por com. Bº el valor se sobrepasa del tope...se toma hasta el valor del participante
            If dblTmpCostoOticAl > dblValorParticipante Then
                dblTmpCostoOticAl = dblValorParticipante
            End If

            'cálculo del gasto empresa (se devuelve por referencia)
            dblGastoEmpresaAlumno = lngValRealCurso / intNumAlumnos - dblTmpCostoOticAl

            CalcularCostoOticAlumno = dblTmpCostoOticAl
        End Function


#End Region
#Region "funciones validaciones"
        Public Function NombreCuenta(ByVal intCodCuenta As Integer) As String
            Select Case intCodCuenta
                Case 1
                    NombreCuenta = "Capacitación"
                Case 2
                    NombreCuenta = "Reparto"
                Case 3
                    NombreCuenta = "Administración"
                Case 4
                    NombreCuenta = "Ex. de Capacitación"
                Case 5
                    NombreCuenta = "Ex. de Reparto"
                Case 6
                    NombreCuenta = "Becas"
                Case Else
                    NombreCuenta = "Cod. Desconocido"
            End Select
        End Function

        Public Function ValidaDiasInscripcion(ByVal FechaIngreso As Date, ByVal FechaInicio As Date) As Boolean
            Dim objCSql As New CSql
            Dim blnResultado As Boolean = False
            Try
                Dim i As Integer = 0
                Dim dtmTmp As Date = FechaIngreso
                Dim intDias As Integer = 0
                For i = 0 To DateDiff(DateInterval.Day, FechaIngreso, FechaInicio)
                    If dtmTmp.DayOfWeek = 0 Or dtmTmp.DayOfWeek = 6 Or objCSql.ExisteDiaFeriado(dtmTmp) Then
                        intDias = intDias + 1
                    End If
                    dtmTmp = DateAdd(DateInterval.Day, 1, dtmTmp)
                Next
                If (DateDiff(DateInterval.Day, FechaIngreso, FechaInicio) - intDias) > CInt(Parametros.p_DIASCOMUNICACION) Then
                    blnResultado = True
                Else
                    blnResultado = False
                End If
                Return blnResultado
            Catch ex As Exception
                EnviaError("modFunciones:ValidaDiasInscripcion-->" & ex.Message)
                Return blnResultado
            End Try
        End Function

#End Region
#Region "funciones Curso contratado"

        'Estado curso
        Function NombreEstadoCurso(ByVal intCodEstado As Integer)
            Select Case CInt(intCodEstado)
                Case 0
                    NombreEstadoCurso = "Incompleto"
                Case 1
                    NombreEstadoCurso = "Ingresado"
                Case 2
                    NombreEstadoCurso = "Rechazado"
                Case 3
                    NombreEstadoCurso = "Autorizado"
                Case 4, 11
                    NombreEstadoCurso = "Comunicado"
                Case 5
                    NombreEstadoCurso = "Liquidado"
                Case 6
                    NombreEstadoCurso = "Pago por autorizar"
                Case 7
                    NombreEstadoCurso = "En comunicación"
                Case 8
                    NombreEstadoCurso = "Eliminado"
                Case 9
                    NombreEstadoCurso = "En Liquidación"
                Case 10
                    NombreEstadoCurso = "Anulado"
            End Select
        End Function





#End Region
    End Module
End Namespace
