Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CAlumnoInterno
    'consultas sql y objetos de conexion
    Private mobjSql As CSql
    'correlativo del curso
    Private mlngCorrelativoCurso As Long
    'agno del curso
    Private mintAgno As Integer
    'Rut alumno
    Private mlngRut As Long
    Private mstrApPaterno As String
    Private mstrApMaterno As String
    Private mstrNombres As String
    'M ó F
    Private mstrSexo As String
    Private mlngRutEmpresa As Long
    Private mstrNombreEmpresa As String
    Private mlngViatico As Long
    Private mlngTraslado As Long
    Private mdblPorcAsistencia As Double
    'Private mblnAprobado As Boolean
    Private mblnAprobado As Integer
    Public Property Aprobado() As Integer
        Get
            Return mblnAprobado
        End Get
        Set(ByVal value As Integer)
            mblnAprobado = value
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
    Public Property CorrelativoCurso() As Long
        Get
            Return mlngCorrelativoCurso
        End Get
        Set(ByVal value As Long)
            mlngCorrelativoCurso = value
        End Set
    End Property
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property Rut() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    Public Property ApPaterno() As String
        Get
            Return mstrApPaterno
        End Get
        Set(ByVal value As String)
            mstrApPaterno = value
        End Set
    End Property
    Public Property ApMaterno() As String
        Get
            Return mstrApMaterno
        End Get
        Set(ByVal value As String)
            mstrApMaterno = value
        End Set
    End Property
    Public Property Nombres() As String
        Get
            Return mstrNombres
        End Get
        Set(ByVal value As String)
            mstrNombres = value
        End Set
    End Property
    Public Property Sexo() As String
        Get
            Return mstrSexo
        End Get
        Set(ByVal value As String)
            mstrSexo = value
        End Set
    End Property
    Public Property RutEmpresa() As Long
        Get
            Return mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
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

    'Inicialización del objeto
    Public Sub Initialize()
        Try
            mlngCorrelativoCurso = -1
            mlngRut = -1
            mstrApPaterno = ""
            mstrApMaterno = ""
            mstrNombres = ""
            mstrSexo = ""


        Catch ex As Exception
            EnviaError("CAlumnointerno:Initialize ------>" & ex.Message)
        End Try

    End Sub

    Public Sub Inicializar0(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    'Constructor del objeto. Da valores al nuevo objeto obteniendo la
    'informacion de una persona existente en la BD.
    Public Function Inicializar(ByVal strRut As String) As Boolean
        Try
            Dim dtTemporal As DataTable
            Dim dtNomNivelReg As DataTable
            Dim tam_arrtemp1, tam_arrtemp2 As Integer
            Dim blnExisteAlumno As Boolean
            Dim lngRut As Long
            lngRut = RutUsrALng(strRut)

            dtTemporal = New DataTable
            dtTemporal = mobjSql.s_partic_curso_interno(mlngCorrelativoCurso, mintAgno, _
                                                lngRut)

            tam_arrtemp1 = mobjSql.Registros 'TamanoArreglo1(arrTemporal)
            ' tam_arrtemp2 = mobjSql.Registros2 'TamanoArreglo2(arrTemporal)


            If Me.mobjSql.Registros > 0 Then
                mlngRut = dtTemporal.Rows(0)("rut") '(0, 0)
                mstrNombres = dtTemporal.Rows(0)("nombre") '(1, 0)
                mstrApPaterno = dtTemporal.Rows(0)("ap_paterno") '(2, 0)
                mstrApMaterno = dtTemporal.Rows(0)("ap_materno") '(3, 0)
                mstrSexo = dtTemporal.Rows(0)("sexo") '(6, 0)
                'mlngRutEmpresa = dtTemporal.Rows(0)(10) '(10, 0)
                'mstrNombreEmpresa = dtTemporal.Rows(0)(11) '(11, 0)
                mlngViatico = dtTemporal.Rows(0)("viatico")
                mlngTraslado = dtTemporal.Rows(0)("traslado")
                mblnAprobado = dtTemporal.Rows(0)("COD_ESTADO_PART")
                blnExisteAlumno = True
            Else
                Dim dtTemporal2 As DataTable
                dtTemporal2 = mobjSql.s_pers_nat(lngRut)
                'if2 ..........................................................................
                'tam_arrtemp1 = TamanoArreglo1(dtConsulta)
                'tam_arrtemp2 = TamanoArreglo2(dtConsulta)

                If Me.mobjSql.Registros > 0 Then
                    Dim drt As DataRow
                    For Each drt In dtTemporal2.Rows
                        mlngRut = drt("rut")
                        mstrNombres = drt("nombre")
                        mstrApPaterno = drt("ap_paterno")
                        mstrApMaterno = drt("ap_materno")
                        'mstrNombreCompleto = mstrNombres & " " & mstrApPaterno & " " & mstrApMaterno
                        'mdtmFechaNac = drt("fecha_nacim")
                        'mintCodNivelEduc = drt("cod_nivel_educ")
                        mstrSexo = drt("sexo")
                        'mdblPorcFranquicia = drt("porc_franquicia")
                        'mintCodNivelOcup = drt("cod_nivel_ocup")
                        'mintCodRegion = drt("cod_region")
                        'mlngRutEmpresa = drt("rut_empresa")
                        'mstrNombreEmpresa = drt("razon_social")
                        'dtNomNivelReg = mobjSql.s_nombre_niv_reg(mintCodNivelEduc, _
                        ' mintCodNivelOcup, mintCodRegion)
                        'mlngCodComuna = IIf(IsDBNull(drt("cod_comuna")), 0, drt("cod_comuna"))
                        'If IsDBNull(drt("cod_comuna")) Then
                        '    mstrComuna = ""
                        'Else
                        '    mstrComuna = mobjSql.s_nom_comuna(drt("cod_comuna"))
                        'End If

                        'mstrCodClasificador = IIf(IsNull(dtTemporal(13, 0)), "", dtTemporal(13, 0))
                        'Dim drn As DataRow
                        'For Each drn In dtNomNivelReg.Rows
                        '    mstrNivelEduc = drn("nivel_educ")
                        '    mstrNivelOcup = drn("nivel_ocup")
                        '    mstrRegion = drn("nom_region")
                        'Next
                        blnExisteAlumno = True
                    Next

                Else
                    mlngRut = lngRut
                    blnExisteAlumno = False
                End If
            End If
            Inicializar = blnExisteAlumno
        Catch ex As Exception
            EnviaError("CAlumnointerno:Inicializar ----->>" & ex.Message)
        End Try
    End Function

    'Modifica el objeto con la informacion que recibe de la capa de usuario
    Public Sub Modificar(ByVal strRut As String, ByVal strApPaterno As String, _
                        ByVal strApMaterno As String, ByVal strNombres As String, _
                        ByVal strSexo As String)
        Try
            Dim arrNomNivelReg() As Object

            mlngRut = RutUsrALng(strRut)
            mstrApPaterno = strApPaterno
            mstrApMaterno = strApMaterno
            mstrNombres = strNombres
            mstrSexo = strSexo
        Catch ex As Exception
            EnviaError("CAlumnointerno:Modificar ----->" & ex.Message)
        End Try

        
    End Sub
    Public Function Eliminar() As Boolean

        Try
            mobjSql.d_participante_interno(mlngCorrelativoCurso, mintAgno, mlngRut)
        Catch ex As Exception
            EnviaError("CAlumnointerno:Eliminar ---->" & ex.Message)
        End Try


    End Function
End Class
