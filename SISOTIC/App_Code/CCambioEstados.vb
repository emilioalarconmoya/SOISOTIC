Imports Clases
Imports Modulos
Imports Clases.Web
Imports System
Imports System.Data
Imports Microsoft.VisualBasic

Public Class CCambioEstados
    Private mobjCurso As CCursoContratado
    Private mobjCSql As CSql
    Private mlngCodCurso As Long
    Private mstrCodigos As String
    Private mlngRut As Long
    Private mintCodEstadoCurso As Integer
    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property
    Public Property RutUsuario() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    Public Property Codigos() As String
        Get
            Return mstrCodigos
        End Get
        Set(ByVal value As String)
            mstrCodigos = value
        End Set
    End Property
    Public ReadOnly Property Curso() As CCursoContratado
        Get
            Return mobjCurso
        End Get
    End Property
    Public Sub Inicializar(ByVal mlngRut, ByVal mlngCodCurso)
        mobjCurso = New CCursoContratado
        mobjCSql = New CSql
        Call mobjCurso.Inicializar0(mobjCSql, mlngRut)
        Call mobjCurso.Inicializar1(mlngCodCurso)
    End Sub
    Public Function AnularCurso(ByVal strGlosa, ByVal mlngRut, ByVal mlngCodCurso) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            Call mobjCurso.Inicializar0(mobjCSql, mlngRut)
            Call mobjCurso.Inicializar1(mlngCodCurso)
            mobjCSql.InicioTransaccion()
            mobjCurso.CambiarEstAnulado(strGlosa)
            mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:AnularCurso-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function EliminarCurso(ByVal strGlosa, ByVal mlngRut, ByVal mlngCodCurso) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            Call mobjCurso.Inicializar0(mobjCSql, mlngRut)
            Call mobjCurso.Inicializar1(mlngCodCurso)
            mobjCSql.InicioTransaccion()
            mobjCurso.CambiarEstEliminado(strGlosa)
            mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:EliminarCurso-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function LiquidarCurso(ByVal strGlosa, ByVal mlngRut, ByVal mlngCodCurso) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            Call mobjCurso.Inicializar0(mobjCSql, mlngRut)
            Call mobjCurso.Inicializar1(mlngCodCurso)
            'mobjCSql.InicioTransaccion()
            mobjCurso.CambiarEstLiquidado(strGlosa)
            'mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            'mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:LiquidarCurso-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function ComunicacionManual(ByVal strFechaComunicacion, ByVal lngNroRegistro, ByVal strGlosa, ByVal mlngRut, ByVal mlngCodCurso) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            'mobjCSql.InicioTransaccion()
            mobjCurso.Inicializar0(mobjCSql, mlngRut)
            mobjCurso.Inicializar1(mlngCodCurso)
            mobjCurso.ComunicacionManual(strFechaComunicacion, lngNroRegistro, strGlosa)
            'mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            'mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:ComunicacionManual-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function CambiarEstComunicar(ByVal strGlosa, ByVal lngRegistro, ByVal mlngRut, ByVal mstrCodigos) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            mobjCSql.InicioTransaccion()
            mobjCurso.Inicializar0(mobjCSql, mlngRut)
            mobjCurso.Inicializar1(mstrCodigos)
            mobjCurso.CambiarEstComunicado(mstrCodigos, lngRegistro)
            mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstComunicar-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function CambiarEstAutorizar(ByVal strGlosa, ByVal mlngRut, ByVal mstrCodigos) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            mobjCSql.InicioTransaccion()
            mobjCurso.Inicializar0(mobjCSql, mlngRut)
            mobjCurso.Inicializar1(mstrCodigos)
            mobjCurso.CambiarEstAutorizado(strGlosa)
            mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstAutorizar-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function CambiarEstRechazar(ByVal strGlosa, ByVal mlngRut, ByVal mstrCodigos) As Boolean
        Try
            mobjCurso = New CCursoContratado
            mobjCSql = New CSql
            mobjCSql.InicioTransaccion()
            mobjCurso.Inicializar0(mobjCSql, mlngRut)
            mobjCurso.Inicializar1(mstrCodigos)
            mobjCurso.CambiarEstRechazado(strGlosa)
            mobjCSql.FinTransaccion()
            Return True
        Catch ex As Exception
            mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstRechazar-->" & ex.Message)
            Return False
        End Try
    End Function
    Public Function CambiarEstAutorizadoMasivo(ByVal strCodigos As String, ByVal strGlosa As String, ByVal lngRutUsuario As Long) As Boolean
        Try
            Dim dtEstadoTrans As DataTable
            Dim dtRutClientes As DataTable
            Dim strRuts As String
            Dim i, intTamArr, intContador As Integer
            mobjCSql = New CSql

            dtRutClientes = mobjCSql.s_rut_clientes(strCodigos)
            Dim dr As DataRow
            For Each dr In dtRutClientes.Rows
                strRuts = strRuts & dr("rut_cliente") & ","
                mintCodEstadoCurso = dr("cod_estado_curso")
            Next
            strRuts = Left(strRuts, strRuts.Length - 1)

            If mobjCSql.Registros > 0 Then
                If mintCodEstadoCurso = 1 Then
                    mintCodEstadoCurso = 3  '3 es el codigo del estado "Autorizado"
                    Dim dtRow As DataRow
                    For Each dtRow In dtRutClientes.Rows
                        'abrir conexion y transaccion
                        Call mobjCSql.InicioTransaccion()
                        Call mobjCSql.u_estado_curso_masivo(dtRow("cod_curso"), mintCodEstadoCurso)
                        Call mobjCSql.i_bitacora(lngRutUsuario, "Autorizado", _
                                                           "El Curso cambia a estado Autorizado. Cliente: " _
                                                           & RutLngAUsr(dtRow("rut_cliente")) & ". " & strGlosa, _
                                                           1, dtRow("cod_curso"))
                        'cerrar transacción y conexion
                        Call mobjCSql.FinTransaccion()
                    Next
                    CambiarEstAutorizadoMasivo = True
                Else
                    'Call CambiarEstPagoPorAut("")
                    CambiarEstAutorizadoMasivo = False
                End If
            End If
            Exit Function
        Catch ex As Exception
            Call mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstAutorizadoMasivo-->" & ex.Message)
        End Try
    End Function

    Public Function CambiarEstRechazadoMasivo(ByVal strCodigos As String, ByVal strGlosa As String, ByVal lngRutUsuario As Long) As Boolean
        Try
            mobjCSql = New CSql
            Dim dtRutClientes As DataTable
            mintCodEstadoCurso = 2  '2 es el codigo del estado "Rechazado"
            dtRutClientes = mobjCSql.s_rut_clientes(strCodigos)
            'abrir conexion y transaccion
           
            Dim dtRow As DataRow
            For Each dtRow In dtRutClientes.Rows
                Call mobjCSql.InicioTransaccion()
                Call mobjCSql.u_estado_curso_masivo(dtRow("cod_curso"), mintCodEstadoCurso)
                Call mobjCSql.i_bitacora(lngRutUsuario, "Rechazado", _
                                "El Curso cambia a estado Rechazado. Cliente: " _
                                & RutLngAUsr(dtRow("rut_cliente")) & ". " & strGlosa, _
                                1, dtRow("cod_curso"))
                'cerrar transacción y conexion
                Call mobjCSql.FinTransaccion()
            Next
            
            CambiarEstRechazadoMasivo = True
            Exit Function
        Catch ex As Exception
            Call mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstRechazadoMasivo-->" & ex.Message)
        End Try
    End Function

    Public Function CambiarEstEnComunicaMasivo(ByVal strCodigos As String, ByVal strGlosa As String, ByVal lngRutUsuario As Long) As Boolean
        Try
            mobjCSql = New CSql
            Dim dtRutClientes As DataTable
            dtRutClientes = mobjCSql.s_rut_clientes(strCodigos)
            Dim dtRow As DataRow
            For Each dtRow In dtRutClientes.Rows
                mintCodEstadoCurso = dtRow("cod_estado_curso")
                If mintCodEstadoCurso = 3 Then
                    mintCodEstadoCurso = 7  '7 es el codigo del estado "En Comunicacion"
                    Call mobjCSql.InicioTransaccion()
                    Call mobjCSql.u_estado_curso(dtRow("cod_curso"), mintCodEstadoCurso)
                    Call mobjCSql.i_bitacora(lngRutUsuario, "En Comunicación", _
                                "El Curso cambia a estado En Comunicación. Cliente: " _
                              & RutLngAUsr(dtRow("rut_cliente")) & ". Fecha: " & FechaVbAUsr(Date.Now) _
                              & ". " & strGlosa, _
                                1, dtRow("cod_curso"))
                    Call mobjCSql.FinTransaccion()
                Else
                    CambiarEstEnComunicaMasivo = False
                    Exit Function
                End If
            Next
            CambiarEstEnComunicaMasivo = True
        Catch ex As Exception
            Call mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstEnComunicaMasivo-->" & ex.Message)
        End Try
    End Function

    Public Function CambiarEstEnLiquidaMasivo(ByVal strCodigos As String, ByVal strGlosa As String, ByVal lngRutUsuario As Long) As Boolean
        Try
            mobjCSql = New CSql
            Dim dtRutClientes As DataTable
            dtRutClientes = mobjCSql.s_rut_clientes(strCodigos)
            Dim dtRow As DataRow
            For Each dtRow In dtRutClientes.Rows
                mintCodEstadoCurso = dtRow("cod_estado_curso")
                If mintCodEstadoCurso = 11 Then '11 estado con asistencia
                    mintCodEstadoCurso = 9 '9 estado en liquidacion
                    Call mobjCSql.InicioTransaccion()
                    Call mobjCSql.i_bitacora(lngRutUsuario, "En Liquidación", _
                              "El Curso cambia a estado En Liquidacion. Cliente: " _
                              & RutLngAUsr(dtRow("rut_cliente")) & ". Fecha: " & FechaVbAUsr(Date.Now) _
                              & ". " & strGlosa, _
                              1, dtRow("cod_curso"))
                    Call mobjCSql.u_estado_curso(dtRow("cod_curso"), mintCodEstadoCurso)
                    Call mobjCSql.FinTransaccion()
                Else
                    CambiarEstEnLiquidaMasivo = False
                    Exit Function
                End If
            Next
            CambiarEstEnLiquidaMasivo = True
        Catch ex As Exception
            Call mobjCSql.RollBackTransaccion()
            EnviaError("CCambioEstados:CambiarEstEnLiquidaMasivo-->" & ex.Message)
        End Try
    End Function
    Public Function ListadoCursos() As DataTable
        mobjCSql = New CSql
        Dim dtListadoCursos As DataTable
        dtListadoCursos = mobjCSql.s_lista_cursos(mstrCodigos)
        Return dtListadoCursos
    End Function

End Class
