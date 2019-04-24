Imports Modulos
Namespace Modulos

    Public Module modEncrypt
        Private Const CLAVE = "Soleduc"
        Private Const SEPARADOR = "-|-"

        'encriptar un texto
        Public Function EncryptINI$(ByVal Strg$)
            Dim b$
            Dim S$
            Dim i, j As Long
            Dim A1, A2, A3 As Long
            Dim P$
            Dim Password$

            Password$ = CLAVE

            j = 1
            For i = 1 To Len(Password$)
                P$ = P$ & Asc(Mid$(Password$, i, 1))
            Next

            For i = 1 To Len(Strg$)
                A1 = Asc(Mid$(P$, j, 1))
                j = j + 1 : If j > Len(P$) Then j = 1
                A2 = Asc(Mid$(Strg$, i, 1))
                A3 = A1 Xor A2
                b$ = Hex$(A3)
                If Len(b$) < 2 Then b$ = "0" + b$
                S$ = S$ + b$
            Next
            EncryptINI$ = S$
        End Function

        'desencriptar un string
        Public Function DecryptINI$(ByVal Strg$)
            Strg$ = Trim(Strg$)

            Dim b$
            Dim S$
            Dim i, j As Long
            Dim A1, A2, A3 As Long
            Dim P$
            Dim Password$
            Password$ = CLAVE

            j = 1
            For i = 1 To Len(Password$)
                P$ = P$ & Asc(Mid$(Password$, i, 1))
            Next

            For i = 1 To Len(Strg$) Step 2
                A1 = Asc(Mid$(P$, j, 1))
                j = j + 1 : If j > Len(P$) Then j = 1
                b$ = Mid$(Strg$, i, 2)
                A3 = Val("&H" + b$)
                A2 = A1 Xor A3
                S$ = S$ + Chr(A2)
            Next
            DecryptINI$ = S$
        End Function


        'function para encriptar varias palabras en un solo string, con la fecha-hora incluida
        Public Function GenerarToken(ByVal str1 As String, ByVal str2 As String) As String
            GenerarToken = EncryptINI$(str1 & SEPARADOR & str2 & SEPARADOR & CStr(Now()))
        End Function
        'chequea que no haya expirado el tiempo del token, y
        'separa las componentes del token (las devuelve por referencia)
        Public Function SepararToken(ByVal strToken As String, ByVal intMinutosExpiracion As Integer, _
                ByRef str1 As String, ByRef str2 As String) As Boolean
            Dim arrComponentes()
            Dim dtmFechaHora As Date
            'desencriptar y separar componentes
            arrComponentes = Split(DecryptINI$(strToken), SEPARADOR)
            If TamanoArreglo1(arrComponentes) <> 3 Then
                SepararToken = False
                Exit Function
            End If
            If Not IsDate(arrComponentes(2)) Then
                SepararToken = False
                Exit Function
            End If
            'chequear expiracion del token
            dtmFechaHora = CDate(arrComponentes(2))
            'diferencia en minutos
            If DateDiff("n", dtmFechaHora, Now) > intMinutosExpiracion Then
                SepararToken = False
                Exit Function
            End If
            'asignar componentes y terminar
            str1 = arrComponentes(0)
            str2 = arrComponentes(1)
            SepararToken = True
        End Function
        'Encripta
        'multiplica el número por 1313 y lo da vuelta
        Function EncryptSimple(ByVal curValor As Decimal) As String
            Dim strTmp As String, i As Integer
            Dim strTmpRes As String
            strTmp = CStr(curValor * 17)
            For i = Len(strTmp) To 1 Step -1
                strTmpRes = strTmpRes & Mid(strTmp, i, 1)
            Next
            EncryptSimple = strTmpRes
        End Function

        Function DecryptSimple(ByVal curValor As String) As Long
            Dim strTmp As String, i As Integer
            Dim strTmpRes As String
            strTmp = curValor
            For i = Len(strTmp) To 1 Step -1
                strTmpRes = strTmpRes & mid(strTmp, i, 1)
            Next
            DecryptSimple = CDec(strTmpRes) / 17
        End Function

    End Module

End Namespace
