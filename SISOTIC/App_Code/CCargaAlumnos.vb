Imports Modulos
Imports Clases
Imports System.Data
Imports System.Web
Imports System.io

Public Class CCargaAlumnos
    Private mobjCsql As CSql
    Private mlngRutUsuario As Long
    Private mstrXml As String
    Private mdtMensajes As DataTable
    Private mintCantIncorretos As Integer
    Private mintCantCorrectos As Integer
    Private mintCantAdvertencias As Integer
    Private lngAlumnosIncorrec As Integer = 0
    Private lngAlumnosCorrec As Integer = 0
    Private lngAlumnosAdvertencia As Integer = 0
    Private strRutsEmpresas As String = ""

    Public WriteOnly Property RutUsuario() As Long
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public ReadOnly Property Mensajes() As DataTable
        Get
            Return mdtMensajes
        End Get
    End Property
    Public ReadOnly Property Correctos() As Integer
        Get
            Return mintCantCorrectos
        End Get
    End Property
    Public ReadOnly Property Incorrectos() As Integer
        Get
            Return mintCantIncorretos
        End Get
    End Property
    Public ReadOnly Property Advertencias() As Integer
        Get
            Return mintCantAdvertencias
        End Get
    End Property

    Public Sub Inicializar()
        Try
            mdtMensajes = New DataTable
            mdtMensajes.Columns.Add("log")
        Catch ex As Exception
            EnviaError("CCargaAlumnos:Inicializar-->" & ex.Message)
        End Try
    End Sub
    Public Function CargarAlumnos(ByVal path As String) As Boolean
        Try
            Dim Rut As Long
            Dim digitoVerificador As String
            Dim apellido_paterno As String
            Dim apellido_materno As String
            Dim nombres As String
            Dim fecha_nacimiento As Date
            Dim sexo As String
            Dim franquicia As Integer
            Dim cod_nivel_ocupacional As Integer
            Dim cod_nivel_educacional As Integer
            Dim cod_region As Integer
            Dim rut_Empresa As Long
            Dim cod_comuna As Long
            Dim digitoVerificadorTemp As String

            Dim cod_pais As Long
            Dim fono As String
            Dim email As String

            Dim file As FileStream
            file = New FileStream(path, FileMode.Open)
            Dim reader As New StreamReader(file, System.Text.Encoding.UTF7)
            Dim strDatos As String = ""
            Dim arrDatos
            'Dim lngAlumnosIncorrec As Integer
            'Dim lngAlumnosCorrec As Integer
            'Dim lngAlumnosAdvertencia As Integer
            'lngAlumnosIncorrec = 0
            'lngAlumnosCorrec = 0
            'lngAlumnosAdvertencia = 0
            'Dim strRutsEmpresas As String = ""
            While Not reader.EndOfStream
                strDatos = reader.ReadLine
                arrDatos = strDatos.Split("|")
                If TamanoArreglo1(arrDatos) <> 16 Then
                    AgregaRegLogDt("ATENCIÓN: Número de campos es distinto al requerido (16).", mdtMensajes)
                    lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                    GoTo SiguienteAlumno
                Else
                    Rut = 0
                    digitoVerificador = ""
                    apellido_paterno = ""
                    apellido_materno = ""
                    nombres = ""
                    fecha_nacimiento = FechaMinSistema()
                    sexo = ""
                    franquicia = 0
                    cod_nivel_ocupacional = 0
                    cod_nivel_educacional = 0
                    cod_region = 0
                    rut_Empresa = 0
                    cod_comuna = 0
                    cod_pais = 1
                    fono = ""
                    email = ""
                    If IsDBNull(arrDatos(0)) And IsDBNull(arrDatos(1)) And IsDBNull(arrDatos(2)) And IsDBNull(arrDatos(3)) And IsDBNull(arrDatos(4)) _
                    And IsDBNull(arrDatos(5)) And IsDBNull(arrDatos(6)) And IsDBNull(arrDatos(7)) And IsDBNull(arrDatos(8)) And IsDBNull(arrDatos(9)) _
                    And IsDBNull(arrDatos(10)) And IsDBNull(arrDatos(11)) And IsDBNull(arrDatos(12)) Then
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN RUT
                    If IsNumeric(arrDatos(0)) Then
                        digitoVerificadorTemp = digito_verificador(arrDatos(0)).ToString.ToLower.Trim
                        If digitoVerificadorTemp = arrDatos(1).ToString.ToLower.Trim Then
                            Rut = arrDatos(0)
                            digitoVerificador = arrDatos(1)
                        Else
                            AgregaRegLogDt("ATENCIÓN: El rut o digito verificador ingresado para el empleado rut " & arrDatos(0) & "-" & arrDatos(1) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                    Else
                        AgregaRegLogDt("ATENCIÓN: El rut ingresado para el empleado rut " & arrDatos(0) & "-" & arrDatos(1) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN APELLIDOS
                    If Not arrDatos(2).ToString.Trim = "" Then
                        apellido_paterno = arrDatos(2)
                    Else
                        AgregaRegLogDt("ATENCIÓN: Debe ingresar un apellido paterno para el empleado rut " & RutLngAUsr(arrDatos(0)) & ".", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    If Not arrDatos(3).ToString.Trim = "" Then
                        apellido_materno = arrDatos(3)
                    Else
                        AgregaRegLogDt("ATENCIÓN: Debe ingresar un apellido materno para el empleado rut " & RutLngAUsr(arrDatos(0)) & ".", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN NOMBRES
                    If Not arrDatos(4).ToString.Trim = "" Then
                        nombres = arrDatos(4)
                    Else
                        AgregaRegLogDt("ATENCIÓN: Debe ingresar un nombre para el empleado rut " & RutLngAUsr(arrDatos(0)) & ".", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN FECHA NACIMIENTO
                    If IsDate(arrDatos(5)) Then
                        If Not CDate(arrDatos(5)) = FechaMinSistema() Then
                            fecha_nacimiento = CDate(arrDatos(5))
                            If DateDiff(DateInterval.Year, CDate(arrDatos(5)), Now.Date, Microsoft.VisualBasic.FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1) < 18 Then
                                AgregaRegLogDt("ADVERTENCIA: El empleado rut " & RutLngAUsr(arrDatos(0)) & " tiene menos de 18 años.", Me.mdtMensajes)
                                lngAlumnosAdvertencia = lngAlumnosAdvertencia + 1
                            End If
                        Else
                            AgregaRegLogDt("ATENCIÓN: La fecha de nacimiento ingresada para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valida.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                    Else
                        AgregaRegLogDt("ATENCIÓN: La fecha de nacimiento ingresada para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valida.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN SEXO
                    If arrDatos(6).ToString.ToUpper.Trim = "F" Or arrDatos(6).ToString.ToUpper.Trim = "M" Then
                        sexo = arrDatos(6).ToString.ToUpper.Trim
                    Else
                        AgregaRegLogDt("ATENCIÓN: El sexo ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN PORCENTAJE FRANQUICIA
                    If arrDatos(7).ToString.ToUpper.Trim = 15 Or arrDatos(7).ToString.ToUpper.Trim = 50 Or arrDatos(7).ToString.ToUpper.Trim = 100 Then
                        franquicia = arrDatos(7).ToString.ToUpper.Trim
                    Else
                        AgregaRegLogDt("ATENCIÓN: El porcentaje de franquicia ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN NIVEL OCUPACIONAL
                    If IsNumeric(arrDatos(8)) Then
                        mobjCsql = New CSql
                        If mobjCsql.ExisteRegistro(arrDatos(8), "nivel_ocupacional", "cod_nivel_ocup") Then
                            cod_nivel_ocupacional = arrDatos(8)
                        Else
                            AgregaRegLogDt("ATENCIÓN: El código de nivel ocupacional ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                        mobjCsql = Nothing
                    Else
                        AgregaRegLogDt("ATENCIÓN: El código de nivel ocupacional ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN NIVEL EDUCACIONAL
                    If IsNumeric(arrDatos(9)) Then
                        mobjCsql = New CSql
                        If mobjCsql.ExisteRegistro(arrDatos(9), "nivel_educacional", "cod_nivel_educ") Then
                            cod_nivel_educacional = arrDatos(9)
                        Else
                            AgregaRegLogDt("ATENCIÓN: El código de nivel ocupacional ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                        mobjCsql = Nothing
                    Else
                        AgregaRegLogDt("ATENCIÓN: El código de nivel educacional ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN REGIÓN
                    If IsNumeric(arrDatos(10)) Then
                        mobjCsql = New CSql
                        If mobjCsql.ExisteRegistro(arrDatos(10), "region", "cod_region") Then
                            cod_region = arrDatos(10)
                        Else
                            AgregaRegLogDt("ATENCIÓN: El código de región ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                        mobjCsql = Nothing
                    Else
                        AgregaRegLogDt("ATENCIÓN: El código de región ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                    'VALIDACIÓN EMPRESA
                    If EsRut(arrDatos(11)) Then
                        mobjCsql = New CSql
                        'If mobjCsql.ExisteRegistro(RutUsrALng(arrDatos(11)), "empresa_cliente", "rut") Then
                        If mobjCsql.ExisteRegistro(arrDatos(11), "empresa_cliente", "rut") Then
                            rut_Empresa = arrDatos(11)
                            If strRutsEmpresas = "" Then
                                strRutsEmpresas = arrDatos(11)
                            Else
                                If Not strRutsEmpresas.Contains(arrDatos(11)) Then
                                    strRutsEmpresas = strRutsEmpresas & ", " & arrDatos(11)
                                End If
                            End If
                        Else
                            AgregaRegLogDt("ATENCIÓN: El rut de empresa ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no existe en nuestros registros.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                        mobjCsql = Nothing
                    Else
                        If IsNumeric(arrDatos(11)) Then
                            mobjCsql = New CSql
                            If mobjCsql.ExisteRegistro(arrDatos(11), "empresa_cliente", "rut") Then
                                rut_Empresa = arrDatos(11)
                                If strRutsEmpresas = "" Then
                                    strRutsEmpresas = RutLngAUsr(arrDatos(11))
                                Else
                                    If Not strRutsEmpresas.Contains(RutLngAUsr(arrDatos(11))) Then
                                        strRutsEmpresas = strRutsEmpresas & ", " & RutLngAUsr(arrDatos(11))
                                    End If
                                End If
                            Else
                                AgregaRegLogDt("ATENCIÓN: El rut de empresa ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no existe en nuestros registros.", Me.mdtMensajes)
                                lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                                GoTo SiguienteAlumno
                            End If
                            mobjCsql = Nothing
                        End If
                    End If
                    'VALIDACIÓN COMUNA
                    If IsNumeric(arrDatos(12)) Then
                        mobjCsql = New CSql
                        If mobjCsql.ExisteRegistro(arrDatos(12), "comuna", "cod_comuna") Then
                            cod_comuna = arrDatos(12)
                        Else
                            AgregaRegLogDt("ATENCIÓN: El código de comuna ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no existe.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                        mobjCsql = Nothing
                    Else
                        AgregaRegLogDt("ATENCIÓN: El código de comuna ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If

                    'VALIDACION PAIS
                    If IsNumeric(arrDatos(13)) Then
                        mobjCsql = New CSql
                        If mobjCsql.ExisteRegistro(arrDatos(13), "pais", "cod_pais") Then
                            cod_pais = arrDatos(13)
                        Else
                            AgregaRegLogDt("ATENCIÓN: El código de pais ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                        mobjCsql = Nothing
                    Else
                        AgregaRegLogDt("ATENCIÓN: El código de pais ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If

                    'VALIDACION FONO
                    If arrDatos(14) = "" Then
                        fono = ""
                    Else
                        If IsNumeric(arrDatos(14)) Then
                            fono = Left(arrDatos(14), 8)
                        Else
                            AgregaRegLogDt("ATENCIÓN: el telefono ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                    End If

                    'VALIDACION EMAIL
                    If arrDatos(15) = "" Then
                        email = ""
                    Else
                        If validaMail(arrDatos(15)) Then
                            email = arrDatos(15).ToString.Trim
                        Else
                            AgregaRegLogDt("ATENCIÓN: El email ingresado para el empleado rut " & RutLngAUsr(arrDatos(0)) & " no es valido.", Me.mdtMensajes)
                            lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                            GoTo SiguienteAlumno
                        End If
                    End If

                    'INGRESA LOS DATOS 
                    If IngresaDatos(Rut, digitoVerificador, apellido_paterno, apellido_materno, nombres, fecha_nacimiento, sexo, _
                        franquicia, cod_nivel_ocupacional, cod_nivel_educacional, cod_region, rut_Empresa, cod_comuna, cod_pais, fono, email) Then
                        AgregaRegLogDt("ATENCIÓN: El empleado rut " & RutLngAUsr(arrDatos(0)) & " ha sido ingresado exitosamente.", Me.mdtMensajes)
                        lngAlumnosCorrec = lngAlumnosCorrec + 1
                        GoTo SiguienteAlumno
                    Else
                        AgregaRegLogDt("ATENCIÓN: Ha ocurrido un error al intentar ingresar al empleado rut " & RutLngAUsr(arrDatos(0)) & ", favor de revisar y volver a intentar.", Me.mdtMensajes)
                        lngAlumnosIncorrec = lngAlumnosIncorrec + 1
                        GoTo SiguienteAlumno
                    End If
                End If
SiguienteAlumno:
            End While

            mintCantIncorretos = lngAlumnosIncorrec
            mintCantCorrectos = lngAlumnosCorrec
            mintCantAdvertencias = lngAlumnosAdvertencia

        Catch ex As Exception
            EnviaError("CCargaAlumnos:CargarAlumnos-->" & ex.Message)
        End Try
    End Function
    'llena los logs de tipo datatable
    Private Sub AgregaRegLogDt(ByVal strMensaje As String, ByRef dt As System.Data.DataTable)
        Try
            Dim dr As System.Data.DataRow
            dr = dt.NewRow
            dr("log") = strMensaje
            dt.Rows.Add(dr)
        Catch ex As Exception
            EnviaError("CCargaAlumnos:AgregaRegLogDt-->" & ex.Message)
        End Try
    End Sub
    Public Function IngresaDatos(ByVal Rut As Long, _
                            ByVal digito_verificador As String, _
                            ByVal apellido_paterno As String, _
                            ByVal apellido_materno As String, _
                            ByVal nombres As String, _
                            ByVal fecha_nacimiento As Date, _
                            ByVal sexo As String, _
                            ByVal franquicia As Integer, _
                            ByVal cod_nivel_ocupacional As Integer, _
                            ByVal cod_nivel_educacional As Integer, _
                            ByVal cod_region As Integer, _
                            ByVal rut_Empresa As Long, _
                            ByVal cod_comuna As Long, _
                            ByVal cod_pais As Long, _
                            ByVal fono As String, _
                            ByVal email As String) As Boolean
        Try
            mobjCsql = New CSql
            mobjCsql.InicioTransaccion()
            If Not mobjCsql.ExisteRegistro(Rut, "persona", "rut") Then
                mobjCsql.i_Persona(Rut, digito_verificador, "N")
            End If
            If mobjCsql.ExisteRegistro(Rut, "persona_natural", "rut") Then
                Call mobjCsql.u_pers_nat2(Rut, apellido_paterno, apellido_materno, nombres, fecha_nacimiento, sexo, _
                                        franquicia, cod_nivel_ocupacional, cod_nivel_educacional, cod_region, _
                                        rut_Empresa, cod_comuna, cod_pais, fono, email)
            Else
                Call mobjCsql.i_PersonaNatural2(Rut, apellido_paterno, apellido_materno, nombres, fecha_nacimiento, sexo, _
                                         franquicia, cod_nivel_ocupacional, cod_nivel_educacional, cod_region, _
                                        rut_Empresa, cod_comuna, cod_pais, fono, email)
            End If
            Dim strGlosa As String = ""
            strGlosa = "Se realiza carga masiva de alumnos con los siguientes resultados: alumnos ingresados = " & _
                        lngAlumnosCorrec & ", alumnos con errores = " & lngAlumnosIncorrec & ", alumnos con advertencias = " & _
                        lngAlumnosAdvertencia & ". Esta carga se realizo para las empresas rut = " & strRutsEmpresas & "."
            If strGlosa.Length > 4000 Then
                strGlosa = Left(strGlosa, 3990) & "..."
            End If
            mobjCsql.i_bitacora(mlngRutUsuario, "Carga masiva de alumnos", strGlosa, 4, gValorNumNulo)
            mobjCsql.FinTransaccion()
            mobjCsql = Nothing
            IngresaDatos = True
        Catch ex As Exception
            mobjCsql.RollBackTransaccion()
            mobjCsql = Nothing
            IngresaDatos = False
        End Try
    End Function
End Class
