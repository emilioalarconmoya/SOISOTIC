Imports Clases
Imports Modulos
Imports System.Data
Namespace Clases
    Public Class CAlumno
        'consultas sql y objetos de conexion
        Private mobjSql As New CSql
        Private mlngFilas As Long

        Private mlngCodCursoInscrito As Long

        Private mlngRut As Long

        Private mstrApPaterno As String

        Private mstrApMaterno As String

        Private mstrNombres As String

        Private mdtmFechaNac As Date

        'M ó F
        Private mstrSexo As String

        'entre 0 y 100%
        Private mdblPorcFranquicia As Double

        Private mintCodNivelOcup As Integer

        Private mstrNivelOcup As String

        Private mintCodNivelEduc As Integer

        Private mstrNivelEduc As String

        Private mintCodRegion As Integer

        Private mstrRegion As String

        Private mlngViatico As Long

        Private mlngTraslado As Long

        Private mlngRutEmpresa As Long

        Private mstrNombreEmpresa As String

        Private mstrNombreCompleto As String

        'porcentaje de asistencia al curso, debe ingresarse al liquidar el curso
        Private mdblPorcAsistencia As Double ' = 0

        Private mstrObservaciones As String

        Private mdblCostoOticAlumno As Double

        Private mdblGastoEmpresaAlumno As Double

        'costos por viatico y traslado-------
        Private mdblCostoOticAlumnoVYT As Double

        Private mdblGastoEmpresaAlumnoVYT As Double
        '------------------------------------

        '-------CAMBIOS PARA COMUNICACION BATCH ---------
        'Código de la comuna
        Private mlngCodComuna As Long
        Private mlngCodPais As Long

        'Nombre comuna
        Private mstrComuna As String
        Private mstrPais As String
        '------------------------------------------------
        Private mstrCodClasificador As String
        Private mlngCorrelativo As Long
        Private mintAgno As Integer

        Private mstrFono As String
        Private mstrEmail As String

        Private mdtAlumno As DataTable
        Public Property Alumnodt() As DataTable
            Get
                Return mdtAlumno
            End Get
            Set(ByVal value As DataTable)
                mdtAlumno = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return mstrEmail
            End Get
            Set(ByVal value As String)
                mstrEmail = value
            End Set
        End Property
        Public Property Fono() As String
            Get
                Return mstrFono
            End Get
            Set(ByVal value As String)
                mstrFono = value
            End Set
        End Property

        Public ReadOnly Property Filas() As Integer
            Get
                Return mlngFilas
            End Get
        End Property
        Public ReadOnly Property Rut() As String
            Get
                Return Trim(RutLngAUsr(mlngRut))
            End Get
        End Property
        Public ReadOnly Property DigVerificador() As String
            Get
                Dim dig_verif As String
                dig_verif = digito_verificador(mlngRut)
                Return Trim(dig_verif)
            End Get
        End Property
        Public ReadOnly Property ApPaterno() As String
            Get
                Return mstrApPaterno
            End Get
        End Property
        Public ReadOnly Property ApMaterno() As String
            Get
                Return mstrApMaterno
            End Get
        End Property
        Public ReadOnly Property Nombres() As String
            Get
                Return mstrNombres
            End Get
        End Property
        Public ReadOnly Property FechaNacimiento() As String
            Get
                Return FechaVbAUsr(mdtmFechaNac)
            End Get
        End Property
        Public ReadOnly Property Sexo() As String
            Get
                Return mstrSexo
            End Get
        End Property
        Public Property PorcFranquicia() As Long
            Get
                If mdblPorcFranquicia >= 0 And mdblPorcFranquicia <= 1 Then
                    PorcFranquicia = mdblPorcFranquicia * 100
                Else
                    PorcFranquicia = mdblPorcFranquicia
                End If
                Return PorcFranquicia
            End Get
            Set(ByVal value As Long)
                If value > 1 Then
                    mdblPorcFranquicia = value / 100
                ElseIf value >= 0 And value <= 1 Then
                    mdblPorcFranquicia = value
                End If

            End Set
        End Property
        Public ReadOnly Property CodigoNivelOcup() As Integer
            Get
                Return mintCodNivelOcup
            End Get
        End Property
        Public ReadOnly Property NivelOcup() As String
            Get
                Return mstrNivelOcup
            End Get
        End Property
        Public ReadOnly Property CodigoNivelEduc() As Integer
            Get
                Return mintCodNivelEduc
            End Get
        End Property
        Public ReadOnly Property NivelEduc() As String
            Get
                Return mstrNivelEduc
            End Get
        End Property
        Public ReadOnly Property CodigoRegion() As Integer
            Get
                Return mintCodRegion
            End Get
        End Property
        Public ReadOnly Property Region() As String
            Get
                Return mstrRegion
            End Get
        End Property
        Public Property Viatico() As Long
            Get
                Return mlngViatico
            End Get
            Set(ByVal value As Long)
                mlngViatico = value
            End Set
        End Property
        Public Property Traslado() As Long
            Get
                Return mlngTraslado
            End Get
            Set(ByVal value As Long)
                mlngTraslado = value
            End Set
        End Property
        Public Property PorcAsistencia() As Long
            Get
                If mdblPorcAsistencia >= 0 And mdblPorcAsistencia <= 1 Then
                    PorcAsistencia = mdblPorcAsistencia * 100
                Else
                    PorcAsistencia = mdblPorcAsistencia
                End If
                Return PorcAsistencia
            End Get
            Set(ByVal value As Long)
                If value > 1 Then
                    mdblPorcAsistencia = value / 100
                ElseIf value >= 0 And value <= 1 Then
                    mdblPorcAsistencia = value
                End If

            End Set
        End Property
        Public ReadOnly Property Observaciones() As String
            Get
                Return mstrObservaciones
            End Get
        End Property
        Public Property RutEmpresa() As String
            Get
                Return Trim(RutLngAUsr(mlngRutEmpresa))
            End Get
            Set(ByVal value As String)
                mlngRutEmpresa = RutUsrALng(value)
            End Set
        End Property
        Public Property NombreEmpresa() As String
            Get
                Return mstrNombreEmpresa
            End Get
            Set(ByVal value As String)
                mstrNombreEmpresa = value
            End Set
        End Property
        Public Property CodCursoInscrito() As Long
            Get
                Return mlngCodCursoInscrito
            End Get
            Set(ByVal value As Long)
                mlngCodCursoInscrito = value
            End Set
        End Property
        Public ReadOnly Property CostoOticAlumno() As Double
            Get
                Return mdblCostoOticAlumno
            End Get
        End Property
        Public ReadOnly Property GastoEmpresaAlumno() As Double
            Get
                Return mdblGastoEmpresaAlumno
            End Get
        End Property
        Public ReadOnly Property GastoEmpresaAlumnoVYT() As Double
            Get
                Return mdblGastoEmpresaAlumnoVYT
            End Get
        End Property
        Public ReadOnly Property CostoOticAlumnoVYT() As Double
            Get
                Return mdblCostoOticAlumnoVYT
            End Get
        End Property
        Public ReadOnly Property CodigoComuna() As Long
            Get
                Return mlngCodComuna
            End Get
        End Property
        Public ReadOnly Property Comuna() As String
            Get
                Return mstrComuna
            End Get
        End Property
        Public ReadOnly Property CodigoPais() As Long
            Get
                Return mlngCodPais
            End Get
        End Property
        Public ReadOnly Property Pais() As String
            Get
                Return mstrPais
            End Get
        End Property
        Public ReadOnly Property CodigoClasificador() As String
            Get
                Return mstrCodClasificador
            End Get
        End Property
        Public Property NombreCompleto() As String
            Get
                Return mstrNombreCompleto
            End Get
            Set(ByVal value As String)
                mstrNombreCompleto = value
            End Set
        End Property
        Public Property CorrelativoCurso() As Long
            Get
                Return mlngCorrelativo
            End Get
            Set(ByVal value As Long)
                mlngCorrelativo = value
            End Set
        End Property
        Public Property Agno() As Long
            Get
                Return mintAgno
            End Get
            Set(ByVal value As Long)
                mintAgno = value
            End Set
        End Property
        'Public Sub Initialize()
        '    mlngCodCursoInscrito = -1
        '    mlngRut = -1
        '    mstrApPaterno = ""
        '    mstrApMaterno = ""
        '    mstrNombres = ""
        '    mdtmFechaNac = ""
        '    mstrSexo = ""
        '    mdblPorcFranquicia = -1
        '    mintCodNivelOcup = 0
        '    mstrNivelOcup = ""
        '    mintCodNivelEduc = 0
        '    mstrNivelEduc = ""
        '    mintCodRegion = 0
        '    mstrRegion = ""
        '    mlngViatico = 0
        '    mlngTraslado = 0
        '    mdblPorcAsistencia = 0
        '    mstrObservaciones = ""
        '    '--------------------
        '    mstrComuna = ""
        '    mstrCodClasificador = ""
        'End Sub
        Public Sub Inicializar0(ByRef objSql As CSql)
            mobjSql = objSql
        End Sub
        Public Function Inicializar(ByVal strRut As String) As Boolean

            Dim dtConsulta As DataTable
            Dim dtNomNivelReg As DataTable
            Dim tam_arrtemp1, tam_arrtemp2 As Integer
            Dim blnExisteAlumno As Boolean
            Dim lngRut As Long
            lngRut = RutUsrALng(strRut)

            dtConsulta = mobjSql.s_partic_curso(mlngCodCursoInscrito, _
                                                lngRut)
            'If.......................................................................
            'tam_arrtemp1 = TamanoArreglo1(dtConsulta)
            'tam_arrtemp2 = TamanoArreglo2(dtConsulta)
            Me.mlngFilas = Me.mobjSql.Registros
            If Me.mlngFilas > 0 Then
                Dim dr As DataRow
                mdtAlumno = New DataTable
                For Each dr In dtConsulta.Rows
                    mlngRut = dr("rut_alumno")
                    mstrNombres = dr("nombre")
                    mstrApPaterno = dr("ap_paterno")
                    mstrApMaterno = dr("ap_materno")
                    mstrNombreCompleto = mstrNombres & " " & mstrApPaterno & " " & mstrApMaterno
                    mdtmFechaNac = dr("fecha_nacim")
                    mintCodNivelEduc = dr("cod_nivel_educ")
                    mstrSexo = dr("sexo")
                    mdblPorcFranquicia = dr("porc_franquicia")
                    mintCodNivelOcup = dr("cod_nivel_ocup")
                    mintCodRegion = dr("cod_region")
                    mlngViatico = dr("viatico")
                    mlngTraslado = dr("traslado")
                    mdblPorcAsistencia = dr("porc_asistencia") * 100
                    dtNomNivelReg = mobjSql.s_nombre_niv_reg(mintCodNivelEduc, _
                                            mintCodNivelOcup, mintCodRegion)
                    mlngCodComuna = IIf(IsDBNull(dr("cod_comuna")), 0, dr("cod_comuna"))
                    If IsDBNull(dr("cod_comuna")) Then
                        mstrComuna = ""
                    Else
                        mstrComuna = mobjSql.s_nom_comuna(dr("cod_comuna"))
                    End If
                    mlngCodPais = IIf(IsDBNull(dr("cod_pais")), 1, dr("cod_pais"))
                    If IsDBNull(dr("cod_pais")) Then
                        mstrPais = ""
                    Else
                        mstrPais = mobjSql.s_nom_pais(dr("cod_pais"))
                    End If

                    mstrFono = IIf(IsDBNull(dr("fono")), "", dr("fono"))
                    mstrEmail = IIf(IsDBNull(dr("email")), "", dr("email"))
                    Dim drn As DataRow
                    For Each drn In dtNomNivelReg.Rows
                        mstrNivelEduc = drn("nivel_educ")
                        mstrNivelOcup = drn("nivel_ocup")
                        mstrRegion = drn("nom_region")
                    Next
                    blnExisteAlumno = True
                Next
            Else

                Dim dtTemporal As DataTable
                dtTemporal = mobjSql.s_pers_nat(lngRut)
                'if2 ..........................................................................
                'tam_arrtemp1 = TamanoArreglo1(dtConsulta)
                'tam_arrtemp2 = TamanoArreglo2(dtConsulta)
                Me.mlngFilas = Me.mobjSql.Registros
                If Me.mlngFilas > 0 Then
                    Dim drt As DataRow
                    For Each drt In dtTemporal.Rows
                        mlngRut = drt("rut")
                        mstrNombres = drt("nombre")
                        mstrApPaterno = drt("ap_paterno")
                        mstrApMaterno = drt("ap_materno")
                        mstrNombreCompleto = mstrNombres & " " & mstrApPaterno & " " & mstrApMaterno
                        mdtmFechaNac = drt("fecha_nacim")
                        mintCodNivelEduc = drt("cod_nivel_educ")
                        mstrSexo = drt("sexo")
                        mdblPorcFranquicia = drt("porc_franquicia")
                        mintCodNivelOcup = drt("cod_nivel_ocup")
                        mintCodRegion = drt("cod_region")
                        mlngRutEmpresa = drt("rut_empresa")
                        mstrNombreEmpresa = drt("razon_social")
                        dtNomNivelReg = mobjSql.s_nombre_niv_reg(mintCodNivelEduc, _
                                                mintCodNivelOcup, mintCodRegion)
                        mlngCodComuna = IIf(IsDBNull(drt("cod_comuna")), 0, drt("cod_comuna"))
                        If IsDBNull(drt("cod_comuna")) Then
                            mstrComuna = ""
                        Else
                            mstrComuna = mobjSql.s_nom_comuna(drt("cod_comuna"))
                        End If

                        mlngCodPais = IIf(IsDBNull(drt("cod_pais")), 0, drt("cod_pais"))
                        If IsDBNull(drt("cod_pais")) Then
                            mstrPais = ""
                        Else
                            mstrPais = mobjSql.s_nom_pais(drt("cod_pais"))
                        End If
                        mstrFono = IIf(IsDBNull(drt("fono")), "", drt("fono"))
                        mstrEmail = IIf(IsDBNull(drt("email")), "", drt("email"))
                        'mstrCodClasificador = IIf(IsNull(dtTemporal(13, 0)), "", dtTemporal(13, 0))
                        Dim drn As DataRow
                        For Each drn In dtNomNivelReg.Rows
                            mstrNivelEduc = drn("nivel_educ")
                            mstrNivelOcup = drn("nivel_ocup")
                            mstrRegion = drn("nom_region")
                        Next

                        blnExisteAlumno = True
                    Next

                Else
                    mlngRut = lngRut
                    blnExisteAlumno = False
                End If
            End If
            Inicializar = blnExisteAlumno


        End Function

        'Modifica el objeto con la informacion que recibe de la capa de usuario
        Public Sub Modificar(ByVal strRut As String, ByVal strApPaterno As String, _
                            ByVal strApMaterno As String, ByVal strNombres As String, _
                            ByVal dtmFechaNac As String, ByVal strSexo As String, _
                            ByVal dblPorcFranquicia As Double, ByVal intCodNivelOcup As Integer, _
                            ByVal intCodNivelEduc As Integer, ByVal intCodRegion As Integer, _
                            ByVal lngViatico As Long, ByVal lngTraslado As Long, ByVal lngCodComuna As Long, _
                            ByVal strCodClasificador As String, ByVal lngCodPais As Long, _
                            ByVal strFono As String, ByVal strEmail As String)

            Dim dtNomNivelReg As DataTable

            mlngRut = RutUsrALng(strRut)
            mstrApPaterno = strApPaterno
            mstrApMaterno = strApMaterno
            mstrNombres = strNombres
            mdtmFechaNac = FechaUsrAVb(dtmFechaNac)
            mstrSexo = strSexo
            mdblPorcFranquicia = dblPorcFranquicia
            mintCodNivelOcup = intCodNivelOcup
            mintCodNivelEduc = intCodNivelEduc
            mintCodRegion = intCodRegion
            mlngViatico = lngViatico
            mlngTraslado = lngTraslado

            dtNomNivelReg = mobjSql.s_nombre_niv_reg(mintCodNivelEduc, _
                                    mintCodNivelOcup, mintCodRegion)
            Dim drn As DataRow
            For Each drn In dtNomNivelReg.Rows
                mstrNivelEduc = drn("nivel_educ")
                mstrNivelOcup = drn("nivel_ocup")
                mstrRegion = drn("nom_region")
            Next
            mlngCodComuna = lngCodComuna

            If lngCodComuna <> 0 Then
                mstrComuna = mobjSql.s_nom_comuna(lngCodComuna)
            End If

            mstrCodClasificador = strCodClasificador

            mlngCodPais = lngCodPais

            mstrFono = strFono
            mstrEmail = strEmail

            If lngCodPais <> 0 Then
                mstrPais = mobjSql.s_nom_pais(lngCodPais)
            End If
        End Sub
        Public Sub CalcularCostosAl(ByVal lngHoras As Double, _
                                ByVal lngValHoraSence As Double, _
                                ByVal bolIndAcuComBip As Boolean, _
                                ByVal lngHorasCompl As Double, _
                                ByVal lngValorMercado As Long, _
                                ByVal intIndDescPorc As Integer, _
                                ByVal lngDescuento As Long, _
                                ByVal intNumAlumnos As Integer, _
                                ByVal intCodEstadoCurso As Integer)

            Dim intIndAcuComBip As Integer

            If bolIndAcuComBip Then
                intIndAcuComBip = 1
            Else
                intIndAcuComBip = 0
            End If

            'esta función calcula el costo otic del alumno y además devuelve el gasto empresa,
            'que se pasa por referencia
            mdblCostoOticAlumno = CalcularCostoOticAlumno(lngHoras, lngValHoraSence, intIndAcuComBip, _
                                    lngHorasCompl, lngValorMercado, intIndDescPorc, lngDescuento, _
                                    intNumAlumnos, mdblPorcAsistencia, intCodEstadoCurso, _
                                    mdblGastoEmpresaAlumno, mdblPorcFranquicia)
            mdblCostoOticAlumnoVYT = CalcularCostoOticAlumnoVYT(lngHoras, lngHorasCompl, mlngViatico + mlngTraslado, _
                                                                mdblPorcAsistencia, intCodEstadoCurso, _
                                                                mdblGastoEmpresaAlumnoVYT, mdblPorcFranquicia)

        End Sub
        'solo par la craga de asistencia historica
        Public Sub CalcularCostosAl2(ByVal lngHoras As Long, _
                                ByVal lngValHoraSence As Double, _
                                ByVal bolIndAcuComBip As Boolean, _
                                ByVal lngHorasCompl As Long, _
                                ByVal lngValorMercado As Long, _
                                ByVal intIndDescPorc As Integer, _
                                ByVal lngDescuento As Long, _
                                ByVal intNumAlumnos As Integer, _
                                ByVal intCodEstadoCurso As Integer)

            Dim intIndAcuComBip As Integer

            If bolIndAcuComBip Then
                intIndAcuComBip = 1
            Else
                intIndAcuComBip = 0
            End If

            'esta función calcula el costo otic del alumno y además devuelve el gasto empresa,
            'que se pasa por referencia
            mdblCostoOticAlumno = CalcularCostoOticAlumno2(lngHoras, lngValHoraSence, intIndAcuComBip, _
                                    lngHorasCompl, lngValorMercado, intIndDescPorc, lngDescuento, _
                                    intNumAlumnos, mdblPorcAsistencia, intCodEstadoCurso, _
                                    mdblGastoEmpresaAlumno, mdblPorcFranquicia)
            mdblCostoOticAlumnoVYT = CalcularCostoOticAlumnoVYT2(lngHoras, lngHorasCompl, mlngViatico + mlngTraslado, _
                                                                mdblPorcAsistencia, intCodEstadoCurso, _
                                                                mdblGastoEmpresaAlumnoVYT, mdblPorcFranquicia)

        End Sub
        Public Function Eliminar() As Boolean
            'Try
            '    mobjSql.d_participante(mlngCodCursoInscrito, mlngRut)
            'Catch ex As Exception

            'End Try

        End Function

        Public Function CalcularCostoOticAlumno(ByVal lngHoras As Double, _
                                            ByVal lngValHoraSence As Double, _
                                            ByVal intIndAcuComBip As Integer, _
                                            ByVal lngHorasCompl As Double, _
                                            ByVal lngValorMercado As Long, _
                                            ByVal intIndDescPorc As Integer, _
                                            ByVal lngDescuento As Long, _
                                            ByVal intNumAlumnos As Integer, _
                                            ByVal dblPorcAsistencia As Double, _
                                            ByVal intCodEstadoCurso As Integer, _
                                            ByRef dblGastoEmpresaAlumno As Double, _
                                            ByVal dblPorcFranquicia As Double)

            Dim dblMinimo As Double, dblAuxiliar As Double
            Dim dblValHoraCurso As Double, dblValHoraCursoFranquiciable As Double
            Dim lngValRealCurso As Long
            Dim dblValorParticipante As Double

            If dblPorcAsistencia = 100.0 Then
                dblPorcAsistencia = 1.0
            End If

            'curso con complemento: hay que calcular el valor de mercado y descuento,
            'redondeado al número de horas
            If lngHorasCompl > 0 Then
                Dim dblFactorHoras As Double
                dblFactorHoras = (lngHoras - lngHorasCompl) / lngHoras
                lngValorMercado = Math.Round(dblFactorHoras * lngValorMercado)
                If intIndDescPorc = 0 Then  'si el descuento es en monto
                    lngDescuento = Math.Round(lngDescuento * dblFactorHoras)
                End If

                'considerar las horas correspondientes al año actual
                lngHoras = lngHoras - lngHorasCompl
            End If

            lngValRealCurso = Math.Round(lngValorMercado - (1 - intIndDescPorc) * lngDescuento - intIndDescPorc * lngDescuento * lngValorMercado / 100)
            If lngHoras <> 0 And intNumAlumnos <> 0 Then
                dblValHoraCurso = (lngValRealCurso / lngHoras) / intNumAlumnos
                dblValorParticipante = lngValRealCurso / intNumAlumnos
            Else
                dblValHoraCurso = -1
                dblValorParticipante = 0
            End If
            dblAuxiliar = lngValHoraSence * (1 + (0.2 * intIndAcuComBip)) ' lngValHoraSence * (1 + (0.2 * intIndAcuComBip))

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
        'solo para la carga de asistencia historica
        Public Function CalcularCostoOticAlumno2(ByVal lngHoras As Long, _
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
                                            ByVal dblPorcFranquicia As Double)

            Dim dblMinimo As Double, dblAuxiliar As Double
            Dim dblValHoraCurso As Double, dblValHoraCursoFranquiciable As Double
            Dim lngValRealCurso As Long
            Dim dblValorParticipante As Double

            'curso con complemento: hay que calcular el valor de mercado y descuento,
            'redondeado al número de horas
            If lngHorasCompl > 0 Then
                Dim dblFactorHoras As Double
                dblFactorHoras = (lngHoras - lngHorasCompl) / lngHoras
                lngValorMercado = Math.Round(dblFactorHoras * lngValorMercado)
                If intIndDescPorc = 0 Then  'si el descuento es en monto
                    lngDescuento = Math.Round(lngDescuento * dblFactorHoras)
                End If

                'considerar las horas correspondientes al año actual
                lngHoras = lngHoras - lngHorasCompl
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
            If dblPorcAsistencia >= 75 Then
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

            CalcularCostoOticAlumno2 = dblTmpCostoOticAl
        End Function

        Public Function CalcularCostoOticAlumnoVYT(ByVal lngHoras As Double, _
                                            ByVal lngHorasCompl As Double, _
                                            ByVal dblVYT As Double, _
                                            ByVal dblPorcAsistencia As Double, _
                                            ByVal intCodEstadoCurso As Integer, _
                                            ByRef dblGastoEmpresaAlumnoVYT As Double, _
                                            ByVal dblPorcFranquicia As Double) As Double


            '    If lngHorasCompl > 0 Then
            '        Dim dblFactorHoras As Double
            '        dblFactorHoras = (lngHoras - lngHorasCompl) / lngHoras
            '        'hago la proporcion con respecto a las horas
            '        dblVYT = Round(dblFactorHoras * dblVYT)
            '        'considerar las horas correspondientes al año actual
            '        lngHoras = lngHoras - lngHorasCompl
            '    End If


            If dblPorcAsistencia <= 1 Then dblPorcAsistencia = 100 * dblPorcAsistencia

            Dim dblTmpCostoOticAl As Double

            'chequeo de la asistencia del alumno, si corresponde.
            If (intCodEstadoCurso <> 5 And intCodEstadoCurso <> 9 And _
                intCodEstadoCurso <> 10 And intCodEstadoCurso <> 11) _
                Or dblPorcAsistencia >= 75 Then
                'costo franquiciable
                dblTmpCostoOticAl = dblVYT
            Else
                dblTmpCostoOticAl = 0
            End If

            Dim lngTmpCostoOticRealVYT As Long

            'OTIC AGRO DEJA TODOS LOS VYT CON FRANQUICIA 100% Y NO POR LA FRANQUICIA DE CADA PARTICIPANTE

            'lngTmpCostoOticRealVYT = Math.Round(dblTmpCostoOticAl * 1.0)


            lngTmpCostoOticRealVYT = Math.Round(dblTmpCostoOticAl * dblPorcFranquicia)

            CalcularCostoOticAlumnoVYT = lngTmpCostoOticRealVYT

            'cálculo del gasto empresa (se devuelve por referencia)
            dblGastoEmpresaAlumnoVYT = dblTmpCostoOticAl - lngTmpCostoOticRealVYT

        End Function
        Public Function CalcularCostoOticAlumnoVYT2(ByVal lngHoras As Long, _
                                            ByVal lngHorasCompl As Long, _
                                            ByVal dblVYT As Double, _
                                            ByVal dblPorcAsistencia As Double, _
                                            ByVal intCodEstadoCurso As Integer, _
                                            ByRef dblGastoEmpresaAlumnoVYT As Double, _
                                            ByVal dblPorcFranquicia As Double) As Double


            '    If lngHorasCompl > 0 Then
            '        Dim dblFactorHoras As Double
            '        dblFactorHoras = (lngHoras - lngHorasCompl) / lngHoras
            '        'hago la proporcion con respecto a las horas
            '        dblVYT = Round(dblFactorHoras * dblVYT)
            '        'considerar las horas correspondientes al año actual
            '        lngHoras = lngHoras - lngHorasCompl
            '    End If


            If dblPorcAsistencia <= 1 Then dblPorcAsistencia = 100 * dblPorcAsistencia

            Dim dblTmpCostoOticAl As Double

            'chequeo de la asistencia del alumno, si corresponde.
            If (intCodEstadoCurso <> 5 And intCodEstadoCurso <> 9 And _
                intCodEstadoCurso <> 10 And intCodEstadoCurso <> 11) _
                Or dblPorcAsistencia >= 75 Then
                'costo franquiciable
                dblTmpCostoOticAl = dblVYT
            Else
                dblTmpCostoOticAl = 0
            End If

            Dim lngTmpCostoOticRealVYT As Long

            lngTmpCostoOticRealVYT = Math.Round(dblTmpCostoOticAl * dblPorcFranquicia)

            CalcularCostoOticAlumnoVYT2 = lngTmpCostoOticRealVYT

            'cálculo del gasto empresa (se devuelve por referencia)
            dblGastoEmpresaAlumnoVYT = dblTmpCostoOticAl - lngTmpCostoOticRealVYT

        End Function

        Public Function ValidacionAlumnoConTopeFechas(ByVal RutAlumno As Long, ByVal FechaInicio As Date, _
                                                    ByVal FechaFin As Date, ByVal CodCurso As Long) As Boolean
            Dim blnResultado As Boolean = False
            Try
                mobjSql = New CSql
                Return mobjSql.s_alumno_con_tope_fechas(RutAlumno, FechaInicio, FechaFin, CodCurso)
            Catch ex As Exception
                EnviaError("CAlumno:ValidacionAlumnoConTopeFechas-->" & ex.Message)
                Return blnResultado
            End Try
        End Function

        Public Function ValidacionAlumnoConCursoRepetido(ByVal RutAlumno As Long, ByVal Agno As Integer, _
                                                    ByVal CodSence As Long, ByVal CodCurso As Long) As Integer
            Dim blnResultado As Boolean = False
            Try
                mobjSql = New CSql
                Return mobjSql.s_alumno_con_curso_repetido(RutAlumno, Agno, CodSence, CodCurso)
            Catch ex As Exception
                EnviaError("CAlumno:ValidacionAlumnoConCursoRepetido-->" & ex.Message)
                Return blnResultado
            End Try
        End Function



    End Class
End Namespace


