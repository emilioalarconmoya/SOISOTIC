Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CInformeEstadistica
#Region "declaraciones"
    Const ESTADO_CURSOS = "1,2,3,4,5,6,7,9,11"
    'rut del usuario conectado
    Private mlngRutUsuario As Long
    'rut de la empresa y flag que indica si es Holding
    Private mlngRutCliente As Long
    Private mblnHolding As Boolean
    Private mintAgno As Integer
    'código de la sucursal seleccionada
    Private mintCodSucursal As Integer ' todos = 0
    'rut del ejecutivo
    Private mlngRutEjecutivo As Long ' todos = 0
    'arreglo con los niveles educacionales
    Private mdtNivelEduc As DataTable
    'meses del año
    Private mdtMeses As DataTable
    '
    'Arreglos y variables con las estadísticas
    '
    'cursos inscritos
    Private mdtCursos As DataTable
    Private mlngTotalCursosInscritos As Long
    Private mlngCursosInscritos1 As Long
    Private mlngCursosInscritos2 As Long
    Private mlngCursosInscritos3 As Long
    Private mlngCursosInscritos4 As Long
    Private mlngCursosInscritos5 As Long
    Private mlngCursosInscritos6 As Long
    Private mlngCursosInscritos7 As Long
    Private mlngCursosInscritos8 As Long
    Private mlngCursosInscritos9 As Long
    Private mlngCursosInscritos10 As Long
    Private mlngCursosInscritos11 As Long
    Private mlngCursosInscritos12 As Long

    'arreglo de objetos de tipos diccionario con los participantes por nivel, por cada mes
    Private mdtParticipantes As DataTable
    'arreglo de objetos de tipos diccionario con las horas-hombre por nivel, por cada mes
    Private mdtHorasHombre As DataTable
    'sumas mensuales de todas los niveles
    Private mdtTotalParticipantesMes As DataTable
    Private mdtTotalHorasHombreMes As DataTable
    'sumas anuales por nivel
    Private mobjTotalParticipantesNivel As DataTable
    Private mobjTotalHorasHombreNivel As DataTable
    'total de participantes y horas-hombre
    Private mlngTotalParticipantes As Long
    Private mlngTotalHorasHombre As Long
    'objeto con consultas SQL
    Private mobjSql As CSql
    Private mstrNombreNivelEduc1 As String
    Private mstrNombreNivelEduc2 As String
    Private mstrNombreNivelEduc3 As String
    Private mstrNombreNivelEduc4 As String
    Private mstrNombreNivelEduc5 As String
    Private mstrNombreNivelEduc6 As String
    Private mstrNombreNivelEduc7 As String
    Private mstrNombreNivelEduc8 As String
    Private mstrNombreNivelEduc9 As String

    Private mlngSinEScolaridadPart1 As Long
    Private mlngSinEScolaridadPart2 As Long
    Private mlngSinEScolaridadPart3 As Long
    Private mlngSinEScolaridadPart4 As Long
    Private mlngSinEScolaridadPart5 As Long
    Private mlngSinEScolaridadPart6 As Long
    Private mlngSinEScolaridadPart7 As Long
    Private mlngSinEScolaridadPart8 As Long
    Private mlngSinEScolaridadPart9 As Long
    Private mlngSinEScolaridadPart10 As Long
    Private mlngSinEScolaridadPart11 As Long
    Private mlngSinEScolaridadPart12 As Long

    Private mlngBasicaIncomplPart1 As Long
    Private mlngBasicaIncomplPart2 As Long
    Private mlngBasicaIncomplPart3 As Long
    Private mlngBasicaIncomplPart4 As Long
    Private mlngBasicaIncomplPart5 As Long
    Private mlngBasicaIncomplPart6 As Long
    Private mlngBasicaIncomplPart7 As Long
    Private mlngBasicaIncomplPart8 As Long
    Private mlngBasicaIncomplPart9 As Long
    Private mlngBasicaIncomplPart10 As Long
    Private mlngBasicaIncomplPart11 As Long
    Private mlngBasicaIncomplPart12 As Long

    Private mlngBasicaComplPart1 As Long
    Private mlngBasicaComplPart2 As Long
    Private mlngBasicaComplPart3 As Long
    Private mlngBasicaComplPart4 As Long
    Private mlngBasicaComplPart5 As Long
    Private mlngBasicaComplPart6 As Long
    Private mlngBasicaComplPart7 As Long
    Private mlngBasicaComplPart8 As Long
    Private mlngBasicaComplPart9 As Long
    Private mlngBasicaComplPart10 As Long
    Private mlngBasicaComplPart11 As Long
    Private mlngBasicaComplPart12 As Long

    Private mlngMediaIncomplPart1 As Long
    Private mlngMediaIncomplPart2 As Long
    Private mlngMediaIncomplPart3 As Long
    Private mlngMediaIncomplPart4 As Long
    Private mlngMediaIncomplPart5 As Long
    Private mlngMediaIncomplPart6 As Long
    Private mlngMediaIncomplPart7 As Long
    Private mlngMediaIncomplPart8 As Long
    Private mlngMediaIncomplPart9 As Long
    Private mlngMediaIncomplPart10 As Long
    Private mlngMediaIncomplPart11 As Long
    Private mlngMediaIncomplPart12 As Long

    Private mlngMediaComplPart1 As Long
    Private mlngMediaComplPart2 As Long
    Private mlngMediaComplPart3 As Long
    Private mlngMediaComplPart4 As Long
    Private mlngMediaComplPart5 As Long
    Private mlngMediaComplPart6 As Long
    Private mlngMediaComplPart7 As Long
    Private mlngMediaComplPart8 As Long
    Private mlngMediaComplPart9 As Long
    Private mlngMediaComplPart10 As Long
    Private mlngMediaComplPart11 As Long
    Private mlngMediaComplPart12 As Long

    Private mlngTecnicaIncoplPart1 As Long
    Private mlngTecnicaIncoplPart2 As Long
    Private mlngTecnicaIncoplPart3 As Long
    Private mlngTecnicaIncoplPart4 As Long
    Private mlngTecnicaIncoplPart5 As Long
    Private mlngTecnicaIncoplPart6 As Long
    Private mlngTecnicaIncoplPart7 As Long
    Private mlngTecnicaIncoplPart8 As Long
    Private mlngTecnicaIncoplPart9 As Long
    Private mlngTecnicaIncoplPart10 As Long
    Private mlngTecnicaIncoplPart11 As Long
    Private mlngTecnicaIncoplPart12 As Long

    Private mlngTenicaComplPart1 As Long
    Private mlngTenicaComplPart2 As Long
    Private mlngTenicaComplPart3 As Long
    Private mlngTenicaComplPart4 As Long
    Private mlngTenicaComplPart5 As Long
    Private mlngTenicaComplPart6 As Long
    Private mlngTenicaComplPart7 As Long
    Private mlngTenicaComplPart8 As Long
    Private mlngTenicaComplPart9 As Long
    Private mlngTenicaComplPart10 As Long
    Private mlngTenicaComplPart11 As Long
    Private mlngTenicaComplPart12 As Long

    Private mlngUniversitarioIncomplpart1 As Long
    Private mlngUniversitarioIncomplpart2 As Long
    Private mlngUniversitarioIncomplpart3 As Long
    Private mlngUniversitarioIncomplpart4 As Long
    Private mlngUniversitarioIncomplpart5 As Long
    Private mlngUniversitarioIncomplpart6 As Long
    Private mlngUniversitarioIncomplpart7 As Long
    Private mlngUniversitarioIncomplpart8 As Long
    Private mlngUniversitarioIncomplpart9 As Long
    Private mlngUniversitarioIncomplpart10 As Long
    Private mlngUniversitarioIncomplpart11 As Long
    Private mlngUniversitarioIncomplpart12 As Long

    Private mlngUniversitarioComplPart1 As Long
    Private mlngUniversitarioComplPart2 As Long
    Private mlngUniversitarioComplPart3 As Long
    Private mlngUniversitarioComplPart4 As Long
    Private mlngUniversitarioComplPart5 As Long
    Private mlngUniversitarioComplPart6 As Long
    Private mlngUniversitarioComplPart7 As Long
    Private mlngUniversitarioComplPart8 As Long
    Private mlngUniversitarioComplPart9 As Long
    Private mlngUniversitarioComplPart10 As Long
    Private mlngUniversitarioComplPart11 As Long
    Private mlngUniversitarioComplPart12 As Long

    '**************************************
    Private mlngSinEScolaridadHH1 As Long
    Private mlngSinEScolaridadHH2 As Long
    Private mlngSinEScolaridadHH3 As Long
    Private mlngSinEScolaridadHH4 As Long
    Private mlngSinEScolaridadHH5 As Long
    Private mlngSinEScolaridadHH6 As Long
    Private mlngSinEScolaridadHH7 As Long
    Private mlngSinEScolaridadHH8 As Long
    Private mlngSinEScolaridadHH9 As Long
    Private mlngSinEScolaridadHH10 As Long
    Private mlngSinEScolaridadHH11 As Long
    Private mlngSinEScolaridadHH12 As Long

    Private mlngBasicaIncomplHH1 As Long
    Private mlngBasicaIncomplHH2 As Long
    Private mlngBasicaIncomplHH3 As Long
    Private mlngBasicaIncomplHH4 As Long
    Private mlngBasicaIncomplHH5 As Long
    Private mlngBasicaIncomplHH6 As Long
    Private mlngBasicaIncomplHH7 As Long
    Private mlngBasicaIncomplHH8 As Long
    Private mlngBasicaIncomplHH9 As Long
    Private mlngBasicaIncomplHH10 As Long
    Private mlngBasicaIncomplHH11 As Long
    Private mlngBasicaIncomplHH12 As Long

    Private mlngBasicaComplHH1 As Long
    Private mlngBasicaComplHH2 As Long
    Private mlngBasicaComplHH3 As Long
    Private mlngBasicaComplHH4 As Long
    Private mlngBasicaComplHH5 As Long
    Private mlngBasicaComplHH6 As Long
    Private mlngBasicaComplHH7 As Long
    Private mlngBasicaComplHH8 As Long
    Private mlngBasicaComplHH9 As Long
    Private mlngBasicaComplHH10 As Long
    Private mlngBasicaComplHH11 As Long
    Private mlngBasicaComplHH12 As Long

    Private mlngMediaIncomplHH1 As Long
    Private mlngMediaIncomplHH2 As Long
    Private mlngMediaIncomplHH3 As Long
    Private mlngMediaIncomplHH4 As Long
    Private mlngMediaIncomplHH5 As Long
    Private mlngMediaIncomplHH6 As Long
    Private mlngMediaIncomplHH7 As Long
    Private mlngMediaIncomplHH8 As Long
    Private mlngMediaIncomplHH9 As Long
    Private mlngMediaIncomplHH10 As Long
    Private mlngMediaIncomplHH11 As Long
    Private mlngMediaIncomplHH12 As Long

    Private mlngMediaComplHH1 As Long
    Private mlngMediaComplHH2 As Long
    Private mlngMediaComplHH3 As Long
    Private mlngMediaComplHH4 As Long
    Private mlngMediaComplHH5 As Long
    Private mlngMediaComplHH6 As Long
    Private mlngMediaComplHH7 As Long
    Private mlngMediaComplHH8 As Long
    Private mlngMediaComplHH9 As Long
    Private mlngMediaComplHH10 As Long
    Private mlngMediaComplHH11 As Long
    Private mlngMediaComplHH12 As Long

    Private mlngTecnicaIncoplHH1 As Long
    Private mlngTecnicaIncoplHH2 As Long
    Private mlngTecnicaIncoplHH3 As Long
    Private mlngTecnicaIncoplHH4 As Long
    Private mlngTecnicaIncoplHH5 As Long
    Private mlngTecnicaIncoplHH6 As Long
    Private mlngTecnicaIncoplHH7 As Long
    Private mlngTecnicaIncoplHH8 As Long
    Private mlngTecnicaIncoplHH9 As Long
    Private mlngTecnicaIncoplHH10 As Long
    Private mlngTecnicaIncoplHH11 As Long
    Private mlngTecnicaIncoplHH12 As Long

    Private mlngTenicaComplHH1 As Long
    Private mlngTenicaComplHH2 As Long
    Private mlngTenicaComplHH3 As Long
    Private mlngTenicaComplHH4 As Long
    Private mlngTenicaComplHH5 As Long
    Private mlngTenicaComplHH6 As Long
    Private mlngTenicaComplHH7 As Long
    Private mlngTenicaComplHH8 As Long
    Private mlngTenicaComplHH9 As Long
    Private mlngTenicaComplHH10 As Long
    Private mlngTenicaComplHH11 As Long
    Private mlngTenicaComplHH12 As Long

    Private mlngUniversitarioIncomplHH1 As Long
    Private mlngUniversitarioIncomplHH2 As Long
    Private mlngUniversitarioIncomplHH3 As Long
    Private mlngUniversitarioIncomplHH4 As Long
    Private mlngUniversitarioIncomplHH5 As Long
    Private mlngUniversitarioIncomplHH6 As Long
    Private mlngUniversitarioIncomplHH7 As Long
    Private mlngUniversitarioIncomplHH8 As Long
    Private mlngUniversitarioIncomplHH9 As Long
    Private mlngUniversitarioIncomplHH10 As Long
    Private mlngUniversitarioIncomplHH11 As Long
    Private mlngUniversitarioIncomplHH12 As Long

    Private mlngUniversitarioComplHH1 As Long
    Private mlngUniversitarioComplHH2 As Long
    Private mlngUniversitarioComplHH3 As Long
    Private mlngUniversitarioComplHH4 As Long
    Private mlngUniversitarioComplHH5 As Long
    Private mlngUniversitarioComplHH6 As Long
    Private mlngUniversitarioComplHH7 As Long
    Private mlngUniversitarioComplHH8 As Long
    Private mlngUniversitarioComplHH9 As Long
    Private mlngUniversitarioComplHH10 As Long
    Private mlngUniversitarioComplHH11 As Long
    Private mlngUniversitarioComplHH12 As Long

    'Private mlngParicipantes1 As Long
    'Private mlngParicipantes2 As Long
    'Private mlngParicipantes3 As Long
    'Private mlngParicipantes4 As Long
    'Private mlngParicipantes5 As Long
    'Private mlngParicipantes6 As Long
    'Private mlngParicipantes7 As Long
    'Private mlngParicipantes8 As Long
    'Private mlngParicipantes9 As Long
    'Private mlngParicipantes10 As Long
    'Private mlngParicipantes11 As Long
    'Private mlngParicipantes12 As Long



#End Region
#Region "propiedades"

    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property Holding() As Boolean
        Get
            Return mblnHolding
        End Get
        Set(ByVal value As Boolean)
            mblnHolding = value
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
    Public Property CodSucursal() As Integer
        Get
            Return mintCodSucursal
        End Get
        Set(ByVal value As Integer)
            mintCodSucursal = value
        End Set
    End Property
    Public Property RutEjecutivo() As Long
        Get
            Return mlngRutEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngRutEjecutivo = value
        End Set
    End Property
    Public Property TotalParticipantes() As Long
        Get
            Return mlngTotalParticipantes
        End Get
        Set(ByVal value As Long)
            mlngTotalParticipantes = value
        End Set
    End Property
    Public Property TotalHorasHombre() As Long
        Get
            Return mlngTotalHorasHombre
        End Get
        Set(ByVal value As Long)
            mlngTotalHorasHombre = value
        End Set
    End Property

    Public Property NombreNivelEduc1() As String
        Get
            Return mstrNombreNivelEduc1
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc1 = value
        End Set
    End Property
    Public Property NombreNivelEduc2() As String
        Get
            Return mstrNombreNivelEduc2
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc2 = value
        End Set
    End Property
    Public Property NombreNivelEduc3() As String
        Get
            Return mstrNombreNivelEduc3
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc3 = value
        End Set
    End Property
    Public Property NombreNivelEduc4() As String
        Get
            Return mstrNombreNivelEduc4
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc4 = value
        End Set
    End Property
    Public Property NombreNivelEduc5() As String
        Get
            Return mstrNombreNivelEduc5
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc5 = value
        End Set
    End Property
    Public Property NombreNivelEduc6() As String
        Get
            Return mstrNombreNivelEduc6
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc6 = value
        End Set
    End Property
    Public Property NombreNivelEduc7() As String
        Get
            Return mstrNombreNivelEduc7
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc7 = value
        End Set
    End Property
    Public Property NombreNivelEduc8() As String
        Get
            Return mstrNombreNivelEduc8
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc8 = value
        End Set
    End Property
    Public Property NombreNivelEduc9() As String
        Get
            Return mstrNombreNivelEduc9
        End Get
        Set(ByVal value As String)
            mstrNombreNivelEduc9 = value
        End Set
    End Property
    Public Property TotalCursosInscritos() As Long
        Get
            Return mlngTotalCursosInscritos
        End Get
        Set(ByVal value As Long)
            mlngTotalCursosInscritos = value
        End Set
    End Property
    Public Property CursosInscritos1() As Long
        Get
            Return mlngCursosInscritos1
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos1 = value
        End Set
    End Property
    Public Property CursosInscritos2() As Long
        Get
            Return mlngCursosInscritos2
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos2 = value
        End Set
    End Property
    Public Property CursosInscritos3() As Long
        Get
            Return mlngCursosInscritos3
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos3 = value
        End Set
    End Property
    Public Property CursosInscritos4() As Long
        Get
            Return mlngCursosInscritos4
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos4 = value
        End Set
    End Property
    Public Property CursosInscritos5() As Long
        Get
            Return mlngCursosInscritos5
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos5 = value
        End Set
    End Property
    Public Property CursosInscritos6() As Long
        Get
            Return mlngCursosInscritos6
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos6 = value
        End Set
    End Property
    Public Property CursosInscritos7() As Long
        Get
            Return mlngCursosInscritos7
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos7 = value
        End Set
    End Property
    Public Property CursosInscritos8() As Long
        Get
            Return mlngCursosInscritos8
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos8 = value
        End Set
    End Property
    Public Property CursosInscritos9() As Long
        Get
            Return mlngCursosInscritos9
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos9 = value
        End Set
    End Property
    Public Property CursosInscritos10() As Long
        Get
            Return mlngCursosInscritos10
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos10 = value
        End Set
    End Property
    Public Property CursosInscritos11() As Long
        Get
            Return mlngCursosInscritos11
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos11 = value
        End Set
    End Property
    Public Property CursosInscritos12() As Long
        Get
            Return mlngCursosInscritos12
        End Get
        Set(ByVal value As Long)
            mlngCursosInscritos12 = value
        End Set
    End Property
    Public Property SinEScolaridadPart1() As Long
        Get
            Return mlngSinEScolaridadPart1
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart1 = value
        End Set
    End Property
    Public Property SinEScolaridadPart2() As Long
        Get
            Return mlngSinEScolaridadPart2
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart2 = value
        End Set
    End Property
    Public Property SinEScolaridadPart3() As Long
        Get
            Return mlngSinEScolaridadPart3
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart3 = value
        End Set
    End Property
    Public Property SinEScolaridadPart4() As Long
        Get
            Return mlngSinEScolaridadPart4
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart4 = value
        End Set
    End Property
    Public Property SinEScolaridadPart5() As Long
        Get
            Return mlngSinEScolaridadPart5
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart5 = value
        End Set
    End Property
    Public Property SinEScolaridadPart6() As Long
        Get
            Return mlngSinEScolaridadPart6
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart6 = value
        End Set
    End Property
    Public Property SinEScolaridadPart7() As Long
        Get
            Return mlngSinEScolaridadPart7
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart7 = value
        End Set
    End Property
    Public Property SinEScolaridadPart8() As Long
        Get
            Return mlngSinEScolaridadPart8
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart8 = value
        End Set
    End Property
    Public Property SinEScolaridadPart9() As Long
        Get
            Return mlngSinEScolaridadPart9
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart9 = value
        End Set
    End Property
    Public Property SinEScolaridadPart10() As Long
        Get
            Return mlngSinEScolaridadPart10
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart10 = value
        End Set
    End Property
    Public Property SinEScolaridadPart11() As Long
        Get
            Return mlngSinEScolaridadPart11
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart11 = value
        End Set
    End Property
    Public Property SinEScolaridadPart12() As Long
        Get
            Return mlngSinEScolaridadPart12
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadPart12 = value
        End Set
    End Property
    Public Property BasicaIncomplPart1() As Long
        Get
            Return mlngBasicaIncomplPart1
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart1 = value
        End Set
    End Property
    Public Property BasicaIncomplPart2() As Long
        Get
            Return mlngBasicaIncomplPart2
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart2 = value
        End Set
    End Property
    Public Property BasicaIncomplPart3() As Long
        Get
            Return mlngBasicaIncomplPart3
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart3 = value
        End Set
    End Property
    Public Property BasicaIncomplPart4() As Long
        Get
            Return mlngBasicaIncomplPart4
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart4 = value
        End Set
    End Property
    Public Property BasicaIncomplPart5() As Long
        Get
            Return mlngBasicaIncomplPart5
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart5 = value
        End Set
    End Property
    Public Property BasicaIncomplPart6() As Long
        Get
            Return mlngBasicaIncomplPart6
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart6 = value
        End Set
    End Property
    Public Property BasicaIncomplPart7() As Long
        Get
            Return mlngBasicaIncomplPart7
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart7 = value
        End Set
    End Property
    Public Property BasicaIncomplPart8() As Long
        Get
            Return mlngBasicaIncomplPart8
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart8 = value
        End Set
    End Property
    Public Property BasicaIncomplPart9() As Long
        Get
            Return mlngBasicaIncomplPart9
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart9 = value
        End Set
    End Property
    Public Property BasicaIncomplPart10() As Long
        Get
            Return mlngBasicaIncomplPart10
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart10 = value
        End Set
    End Property
    Public Property BasicaIncomplPart11() As Long
        Get
            Return mlngBasicaIncomplPart11
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart11 = value
        End Set
    End Property
    Public Property BasicaIncomplPart12() As Long
        Get
            Return mlngBasicaIncomplPart12
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplPart12 = value
        End Set
    End Property
    Public Property BasicaComplPart1() As Long
        Get
            Return mlngBasicaComplPart1
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart1 = value
        End Set
    End Property
    Public Property BasicaComplPart2() As Long
        Get
            Return mlngBasicaComplPart2
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart2 = value
        End Set
    End Property
    Public Property BasicaComplPart3() As Long
        Get
            Return mlngBasicaComplPart3
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart3 = value
        End Set
    End Property
    Public Property BasicaComplPart4() As Long
        Get
            Return mlngBasicaComplPart4
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart4 = value
        End Set
    End Property
    Public Property BasicaComplPart5() As Long
        Get
            Return mlngBasicaComplPart5
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart5 = value
        End Set
    End Property
    Public Property BasicaComplPart6() As Long
        Get
            Return mlngBasicaComplPart6
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart6 = value
        End Set
    End Property
    Public Property BasicaComplPart7() As Long
        Get
            Return mlngBasicaComplPart7
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart7 = value
        End Set
    End Property
    Public Property BasicaComplPart8() As Long
        Get
            Return mlngBasicaComplPart8
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart8 = value
        End Set
    End Property
    Public Property BasicaComplPart9() As Long
        Get
            Return mlngBasicaComplPart9
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart9 = value
        End Set
    End Property
    Public Property BasicaComplPart10() As Long
        Get
            Return mlngBasicaComplPart10
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart10 = value
        End Set
    End Property
    Public Property BasicaComplPart11() As Long
        Get
            Return mlngBasicaComplPart11
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart11 = value
        End Set
    End Property
    Public Property BasicaComplPart12() As Long
        Get
            Return mlngBasicaComplPart12
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplPart12 = value
        End Set
    End Property
    Public Property MediaIncomplPart1() As Long
        Get
            Return mlngMediaIncomplPart1
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart1 = value
        End Set
    End Property
    Public Property MediaIncomplPart2() As Long
        Get
            Return mlngMediaIncomplPart2
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart2 = value
        End Set
    End Property
    Public Property MediaIncomplPart3() As Long
        Get
            Return mlngMediaIncomplPart3
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart3 = value
        End Set
    End Property
    Public Property MediaIncomplPart4() As Long
        Get
            Return mlngMediaIncomplPart4
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart4 = value
        End Set
    End Property
    Public Property MediaIncomplPart5() As Long
        Get
            Return mlngMediaIncomplPart5
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart5 = value
        End Set
    End Property
    Public Property MediaIncomplPart6() As Long
        Get
            Return mlngMediaIncomplPart6
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart6 = value
        End Set
    End Property
    Public Property MediaIncomplPart7() As Long
        Get
            Return mlngMediaIncomplPart7
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart7 = value
        End Set
    End Property
    Public Property MediaIncomplPart8() As Long
        Get
            Return mlngMediaIncomplPart8
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart8 = value
        End Set
    End Property
    Public Property MediaIncomplPart9() As Long
        Get
            Return mlngMediaIncomplPart9
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart9 = value
        End Set
    End Property
    Public Property MediaIncomplPart10() As Long
        Get
            Return mlngMediaIncomplPart10
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart10 = value
        End Set
    End Property
    Public Property MediaIncomplPart11() As Long
        Get
            Return mlngMediaIncomplPart11
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart11 = value
        End Set
    End Property
    Public Property MediaIncomplPart12() As Long
        Get
            Return mlngMediaIncomplPart12
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplPart12 = value
        End Set
    End Property
    Public Property MediaComplPart1() As Long
        Get
            Return mlngMediaComplPart1
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart1 = value
        End Set
    End Property
    Public Property MediaComplPart2() As Long
        Get
            Return mlngMediaComplPart2
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart2 = value
        End Set
    End Property
    Public Property MediaComplPart3() As Long
        Get
            Return mlngMediaComplPart3
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart3 = value
        End Set
    End Property
    Public Property MediaComplPart4() As Long
        Get
            Return mlngMediaComplPart4
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart4 = value
        End Set
    End Property
    Public Property MediaComplPart5() As Long
        Get
            Return mlngMediaComplPart5
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart5 = value
        End Set
    End Property
    Public Property MediaComplPart6() As Long
        Get
            Return mlngMediaComplPart6
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart6 = value
        End Set
    End Property
    Public Property MediaComplPart7() As Long
        Get
            Return mlngMediaComplPart7
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart7 = value
        End Set
    End Property
    Public Property MediaComplPart8() As Long
        Get
            Return mlngMediaComplPart8
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart8 = value
        End Set
    End Property
    Public Property MediaComplPart9() As Long
        Get
            Return mlngMediaComplPart9
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart9 = value
        End Set
    End Property
    Public Property MediaComplPart10() As Long
        Get
            Return mlngMediaComplPart10
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart10 = value
        End Set
    End Property
    Public Property MediaComplPart11() As Long
        Get
            Return mlngMediaComplPart11
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart11 = value
        End Set
    End Property
    Public Property MediaComplPart12() As Long
        Get
            Return mlngMediaComplPart12
        End Get
        Set(ByVal value As Long)
            mlngMediaComplPart12 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart1() As Long
        Get
            Return mlngTecnicaIncoplPart1
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart1 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart2() As Long
        Get
            Return mlngTecnicaIncoplPart2
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart2 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart3() As Long
        Get
            Return mlngTecnicaIncoplPart3
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart3 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart4() As Long
        Get
            Return mlngTecnicaIncoplPart4
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart4 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart5() As Long
        Get
            Return mlngTecnicaIncoplPart5
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart5 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart6() As Long
        Get
            Return mlngTecnicaIncoplPart6
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart6 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart7() As Long
        Get
            Return mlngTecnicaIncoplPart7
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart7 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart8() As Long
        Get
            Return mlngTecnicaIncoplPart8
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart8 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart9() As Long
        Get
            Return mlngTecnicaIncoplPart9
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart9 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart10() As Long
        Get
            Return mlngTecnicaIncoplPart10
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart10 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart11() As Long
        Get
            Return mlngTecnicaIncoplPart11
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart11 = value
        End Set
    End Property
    Public Property TecnicaIncoplPart12() As Long
        Get
            Return mlngTecnicaIncoplPart12
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplPart12 = value
        End Set
    End Property
    Public Property TenicaComplPart1() As Long
        Get
            Return mlngTenicaComplPart1
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart1 = value
        End Set
    End Property
    Public Property TenicaComplPart2() As Long
        Get
            Return mlngTenicaComplPart2
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart2 = value
        End Set
    End Property
    Public Property TenicaComplPart3() As Long
        Get
            Return mlngTenicaComplPart3
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart3 = value
        End Set
    End Property
    Public Property TenicaComplPart4() As Long
        Get
            Return mlngTenicaComplPart4
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart4 = value
        End Set
    End Property
    Public Property TenicaComplPart5() As Long
        Get
            Return mlngTenicaComplPart5
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart5 = value
        End Set
    End Property
    Public Property TenicaComplPart6() As Long
        Get
            Return mlngTenicaComplPart6
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart6 = value
        End Set
    End Property
    Public Property TenicaComplPart7() As Long
        Get
            Return mlngTenicaComplPart7
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart7 = value
        End Set
    End Property
    Public Property TenicaComplPart8() As Long
        Get
            Return mlngTenicaComplPart8
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart8 = value
        End Set
    End Property
    Public Property TenicaComplPart9() As Long
        Get
            Return mlngTenicaComplPart9
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart9 = value
        End Set
    End Property
    Public Property TenicaComplPart10() As Long
        Get
            Return mlngTenicaComplPart10
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart10 = value
        End Set
    End Property
    Public Property TenicaComplPart11() As Long
        Get
            Return mlngTenicaComplPart11
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart11 = value
        End Set
    End Property
    Public Property TenicaComplPart12() As Long
        Get
            Return mlngTenicaComplPart12
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplPart12 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart1() As Long
        Get
            Return mlngUniversitarioIncomplpart1
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart1 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart2() As Long
        Get
            Return mlngUniversitarioIncomplpart2
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart2 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart3() As Long
        Get
            Return mlngUniversitarioIncomplpart3
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart3 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart4() As Long
        Get
            Return mlngUniversitarioIncomplpart4
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart4 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart5() As Long
        Get
            Return mlngUniversitarioIncomplpart5
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart5 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart6() As Long
        Get
            Return mlngUniversitarioIncomplpart6
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart6 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart7() As Long
        Get
            Return mlngUniversitarioIncomplpart7
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart7 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart8() As Long
        Get
            Return mlngUniversitarioIncomplpart8
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart8 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart9() As Long
        Get
            Return mlngUniversitarioIncomplpart9
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart9 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart10() As Long
        Get
            Return mlngUniversitarioIncomplpart10
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart10 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart11() As Long
        Get
            Return mlngUniversitarioIncomplpart11
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart11 = value
        End Set
    End Property
    Public Property UniversitarioIncomplpart12() As Long
        Get
            Return mlngUniversitarioIncomplpart12
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplpart12 = value
        End Set
    End Property
    Public Property UniversitarioComplPart1() As Long
        Get
            Return mlngUniversitarioComplPart1
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart1 = value
        End Set
    End Property
    Public Property UniversitarioComplPart2() As Long
        Get
            Return mlngUniversitarioComplPart2
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart2 = value
        End Set
    End Property
    Public Property UniversitarioComplPart3() As Long
        Get
            Return mlngUniversitarioComplPart3
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart3 = value
        End Set
    End Property
    Public Property UniversitarioComplPart4() As Long
        Get
            Return mlngUniversitarioComplPart4
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart4 = value
        End Set
    End Property
    Public Property UniversitarioComplPart5() As Long
        Get
            Return mlngUniversitarioComplPart5
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart5 = value
        End Set
    End Property
    Public Property UniversitarioComplPart6() As Long
        Get
            Return mlngUniversitarioComplPart6
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart6 = value
        End Set
    End Property
    Public Property UniversitarioComplPart7() As Long
        Get
            Return mlngUniversitarioComplPart7
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart7 = value
        End Set
    End Property
    Public Property UniversitarioComplPart8() As Long
        Get
            Return mlngUniversitarioComplPart8
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart8 = value
        End Set
    End Property
    Public Property UniversitarioComplPart9() As Long
        Get
            Return mlngUniversitarioComplPart9
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart9 = value
        End Set
    End Property
    Public Property UniversitarioComplPart10() As Long
        Get
            Return mlngUniversitarioComplPart10
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart10 = value
        End Set
    End Property
    Public Property UniversitarioComplPart11() As Long
        Get
            Return mlngUniversitarioComplPart11
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart11 = value
        End Set
    End Property
    Public Property UniversitarioComplPart12() As Long
        Get
            Return mlngUniversitarioComplPart12
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplPart12 = value
        End Set
    End Property

    '**************************************

    Public Property SinEScolaridadHH1() As Long
        Get
            Return mlngSinEScolaridadHH1
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH1 = value
        End Set
    End Property
    Public Property SinEScolaridadHH2() As Long
        Get
            Return mlngSinEScolaridadHH2
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH2 = value
        End Set
    End Property
    Public Property SinEScolaridadHH3() As Long
        Get
            Return mlngSinEScolaridadHH3
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH3 = value
        End Set
    End Property
    Public Property SinEScolaridadHH4() As Long
        Get
            Return mlngSinEScolaridadHH4
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH4 = value
        End Set
    End Property
    Public Property SinEScolaridadHH5() As Long
        Get
            Return mlngSinEScolaridadHH5
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH5 = value
        End Set
    End Property
    Public Property SinEScolaridadHH6() As Long
        Get
            Return mlngSinEScolaridadHH6
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH6 = value
        End Set
    End Property
    Public Property SinEScolaridadHH7() As Long
        Get
            Return mlngSinEScolaridadHH7
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH7 = value
        End Set
    End Property
    Public Property SinEScolaridadHH8() As Long
        Get
            Return mlngSinEScolaridadHH8
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH8 = value
        End Set
    End Property
    Public Property SinEScolaridadHH9() As Long
        Get
            Return mlngSinEScolaridadHH9
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH9 = value
        End Set
    End Property
    Public Property SinEScolaridadHH10() As Long
        Get
            Return mlngSinEScolaridadHH10
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH10 = value
        End Set
    End Property
    Public Property SinEScolaridadHH11() As Long
        Get
            Return mlngSinEScolaridadHH11
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH11 = value
        End Set
    End Property
    Public Property SinEScolaridadHH12() As Long
        Get
            Return mlngSinEScolaridadHH12
        End Get
        Set(ByVal value As Long)
            mlngSinEScolaridadHH12 = value
        End Set
    End Property
    Public Property BasicaIncomplHH1() As Long
        Get
            Return mlngBasicaIncomplHH1
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH1 = value
        End Set
    End Property
    Public Property BasicaIncomplHH2() As Long
        Get
            Return mlngBasicaIncomplHH2
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH2 = value
        End Set
    End Property
    Public Property BasicaIncomplHH3() As Long
        Get
            Return mlngBasicaIncomplHH3
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH3 = value
        End Set
    End Property
    Public Property BasicaIncomplHH4() As Long
        Get
            Return mlngBasicaIncomplHH4
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH4 = value
        End Set
    End Property
    Public Property BasicaIncomplHH5() As Long
        Get
            Return mlngBasicaIncomplHH5
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH5 = value
        End Set
    End Property
    Public Property BasicaIncomplHH6() As Long
        Get
            Return mlngBasicaIncomplHH6
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH6 = value
        End Set
    End Property
    Public Property BasicaIncomplHH7() As Long
        Get
            Return mlngBasicaIncomplHH7
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH7 = value
        End Set
    End Property
    Public Property BasicaIncomplHH8() As Long
        Get
            Return mlngBasicaIncomplHH8
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH8 = value
        End Set
    End Property
    Public Property BasicaIncomplHH9() As Long
        Get
            Return mlngBasicaIncomplHH9
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH9 = value
        End Set
    End Property
    Public Property BasicaIncomplHH10() As Long
        Get
            Return mlngBasicaIncomplHH10
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH10 = value
        End Set
    End Property
    Public Property BasicaIncomplHH11() As Long
        Get
            Return mlngBasicaIncomplHH11
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH11 = value
        End Set
    End Property
    Public Property BasicaIncomplHH12() As Long
        Get
            Return mlngBasicaIncomplHH12
        End Get
        Set(ByVal value As Long)
            mlngBasicaIncomplHH12 = value
        End Set
    End Property
    Public Property BasicaComplHH1() As Long
        Get
            Return mlngBasicaComplHH1
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH1 = value
        End Set
    End Property
    Public Property BasicaComplHH2() As Long
        Get
            Return mlngBasicaComplHH2
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH2 = value
        End Set
    End Property
    Public Property BasicaComplHH3() As Long
        Get
            Return mlngBasicaComplHH3
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH3 = value
        End Set
    End Property
    Public Property BasicaComplHH4() As Long
        Get
            Return mlngBasicaComplHH4
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH4 = value
        End Set
    End Property
    Public Property BasicaComplHH5() As Long
        Get
            Return mlngBasicaComplHH5
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH5 = value
        End Set
    End Property
    Public Property BasicaComplHH6() As Long
        Get
            Return mlngBasicaComplHH6
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH6 = value
        End Set
    End Property
    Public Property BasicaComplHH7() As Long
        Get
            Return mlngBasicaComplHH7
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH7 = value
        End Set
    End Property
    Public Property BasicaComplHH8() As Long
        Get
            Return mlngBasicaComplHH8
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH8 = value
        End Set
    End Property
    Public Property BasicaComplHH9() As Long
        Get
            Return mlngBasicaComplHH9
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH9 = value
        End Set
    End Property
    Public Property BasicaComplHH10() As Long
        Get
            Return mlngBasicaComplHH10
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH10 = value
        End Set
    End Property
    Public Property BasicaComplHH11() As Long
        Get
            Return mlngBasicaComplHH11
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH11 = value
        End Set
    End Property
    Public Property BasicaComplHH12() As Long
        Get
            Return mlngBasicaComplHH12
        End Get
        Set(ByVal value As Long)
            mlngBasicaComplHH12 = value
        End Set
    End Property
    Public Property MediaIncomplHH1() As Long
        Get
            Return mlngMediaIncomplHH1
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH1 = value
        End Set
    End Property
    Public Property MediaIncomplHH2() As Long
        Get
            Return mlngMediaIncomplHH2
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH2 = value
        End Set
    End Property
    Public Property MediaIncomplHH3() As Long
        Get
            Return mlngMediaIncomplHH3
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH3 = value
        End Set
    End Property
    Public Property MediaIncomplHH4() As Long
        Get
            Return mlngMediaIncomplHH4
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH4 = value
        End Set
    End Property
    Public Property MediaIncomplHH5() As Long
        Get
            Return mlngMediaIncomplHH5
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH5 = value
        End Set
    End Property
    Public Property MediaIncomplHH6() As Long
        Get
            Return mlngMediaIncomplHH6
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH6 = value
        End Set
    End Property
    Public Property MediaIncomplHH7() As Long
        Get
            Return mlngMediaIncomplHH7
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH7 = value
        End Set
    End Property
    Public Property MediaIncomplHH8() As Long
        Get
            Return mlngMediaIncomplHH8
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH8 = value
        End Set
    End Property
    Public Property MediaIncomplHH9() As Long
        Get
            Return mlngMediaIncomplHH9
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH9 = value
        End Set
    End Property
    Public Property MediaIncomplHH10() As Long
        Get
            Return mlngMediaIncomplHH10
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH10 = value
        End Set
    End Property
    Public Property MediaIncomplHH11() As Long
        Get
            Return mlngMediaIncomplHH11
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH11 = value
        End Set
    End Property
    Public Property MediaIncomplHH12() As Long
        Get
            Return mlngMediaIncomplHH12
        End Get
        Set(ByVal value As Long)
            mlngMediaIncomplHH12 = value
        End Set
    End Property
    Public Property MediaComplHH1() As Long
        Get
            Return mlngMediaComplHH1
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH1 = value
        End Set
    End Property
    Public Property MediaComplHH2() As Long
        Get
            Return mlngMediaComplHH2
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH2 = value
        End Set
    End Property
    Public Property MediaComplHH3() As Long
        Get
            Return mlngMediaComplHH3
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH3 = value
        End Set
    End Property
    Public Property MediaComplHH4() As Long
        Get
            Return mlngMediaComplHH4
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH4 = value
        End Set
    End Property
    Public Property MediaComplHH5() As Long
        Get
            Return mlngMediaComplHH5
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH5 = value
        End Set
    End Property
    Public Property MediaComplHH6() As Long
        Get
            Return mlngMediaComplHH6
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH6 = value
        End Set
    End Property
    Public Property MediaComplHH7() As Long
        Get
            Return mlngMediaComplHH7
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH7 = value
        End Set
    End Property
    Public Property MediaComplHH8() As Long
        Get
            Return mlngMediaComplHH8
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH8 = value
        End Set
    End Property
    Public Property MediaComplHH9() As Long
        Get
            Return mlngMediaComplHH9
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH9 = value
        End Set
    End Property
    Public Property MediaComplHH10() As Long
        Get
            Return mlngMediaComplHH10
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH10 = value
        End Set
    End Property
    Public Property MediaComplHH11() As Long
        Get
            Return mlngMediaComplHH11
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH11 = value
        End Set
    End Property
    Public Property MediaComplHH12() As Long
        Get
            Return mlngMediaComplHH12
        End Get
        Set(ByVal value As Long)
            mlngMediaComplHH12 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH1() As Long
        Get
            Return mlngTecnicaIncoplHH1
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH1 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH2() As Long
        Get
            Return mlngTecnicaIncoplHH2
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH2 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH3() As Long
        Get
            Return mlngTecnicaIncoplHH3
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH3 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH4() As Long
        Get
            Return mlngTecnicaIncoplHH4
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH4 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH5() As Long
        Get
            Return mlngTecnicaIncoplHH5
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH5 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH6() As Long
        Get
            Return mlngTecnicaIncoplHH6
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH6 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH7() As Long
        Get
            Return mlngTecnicaIncoplHH7
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH7 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH8() As Long
        Get
            Return mlngTecnicaIncoplHH8
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH8 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH9() As Long
        Get
            Return mlngTecnicaIncoplHH9
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH9 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH10() As Long
        Get
            Return mlngTecnicaIncoplHH10
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH10 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH11() As Long
        Get
            Return mlngTecnicaIncoplHH11
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH11 = value
        End Set
    End Property
    Public Property TecnicaIncoplHH12() As Long
        Get
            Return mlngTecnicaIncoplHH12
        End Get
        Set(ByVal value As Long)
            mlngTecnicaIncoplHH12 = value
        End Set
    End Property
    Public Property TenicaComplHH1() As Long
        Get
            Return mlngTenicaComplHH1
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH1 = value
        End Set
    End Property
    Public Property TenicaComplHH2() As Long
        Get
            Return mlngTenicaComplHH2
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH2 = value
        End Set
    End Property
    Public Property TenicaComplHH3() As Long
        Get
            Return mlngTenicaComplHH3
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH3 = value
        End Set
    End Property
    Public Property TenicaComplHH4() As Long
        Get
            Return mlngTenicaComplHH4
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH4 = value
        End Set
    End Property
    Public Property TenicaComplHH5() As Long
        Get
            Return mlngTenicaComplHH5
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH5 = value
        End Set
    End Property
    Public Property TenicaComplHH6() As Long
        Get
            Return mlngTenicaComplHH6
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH6 = value
        End Set
    End Property
    Public Property TenicaComplHH7() As Long
        Get
            Return mlngTenicaComplHH7
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH7 = value
        End Set
    End Property
    Public Property TenicaComplHH8() As Long
        Get
            Return mlngTenicaComplHH8
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH8 = value
        End Set
    End Property
    Public Property TenicaComplHH9() As Long
        Get
            Return mlngTenicaComplHH9
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH9 = value
        End Set
    End Property
    Public Property TenicaComplHH10() As Long
        Get
            Return mlngTenicaComplHH10
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH10 = value
        End Set
    End Property
    Public Property TenicaComplHH11() As Long
        Get
            Return mlngTenicaComplHH11
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH11 = value
        End Set
    End Property
    Public Property TenicaComplHH12() As Long
        Get
            Return mlngTenicaComplHH12
        End Get
        Set(ByVal value As Long)
            mlngTenicaComplHH12 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH1() As Long
        Get
            Return mlngUniversitarioIncomplHH1
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH1 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH2() As Long
        Get
            Return mlngUniversitarioIncomplHH2
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH2 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH3() As Long
        Get
            Return mlngUniversitarioIncomplHH3
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH3 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH4() As Long
        Get
            Return mlngUniversitarioIncomplHH4
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH4 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH5() As Long
        Get
            Return mlngUniversitarioIncomplHH5
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH5 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH6() As Long
        Get
            Return mlngUniversitarioIncomplHH6
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH6 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH7() As Long
        Get
            Return mlngUniversitarioIncomplHH7
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH7 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH8() As Long
        Get
            Return mlngUniversitarioIncomplHH8
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH8 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH9() As Long
        Get
            Return mlngUniversitarioIncomplHH9
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH9 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH10() As Long
        Get
            Return mlngUniversitarioIncomplHH10
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH10 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH11() As Long
        Get
            Return mlngUniversitarioIncomplHH11
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH11 = value
        End Set
    End Property
    Public Property UniversitarioIncomplHH12() As Long
        Get
            Return mlngUniversitarioIncomplHH12
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioIncomplHH12 = value
        End Set
    End Property
    Public Property UniversitarioComplHH1() As Long
        Get
            Return mlngUniversitarioComplHH1
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH1 = value
        End Set
    End Property
    Public Property UniversitarioComplHH2() As Long
        Get
            Return mlngUniversitarioComplHH2
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH2 = value
        End Set
    End Property
    Public Property UniversitarioComplHH3() As Long
        Get
            Return mlngUniversitarioComplHH3
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH3 = value
        End Set
    End Property
    Public Property UniversitarioComplHH4() As Long
        Get
            Return mlngUniversitarioComplHH4
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH4 = value
        End Set
    End Property
    Public Property UniversitarioComplHH5() As Long
        Get
            Return mlngUniversitarioComplHH5
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH5 = value
        End Set
    End Property
    Public Property UniversitarioComplHH6() As Long
        Get
            Return mlngUniversitarioComplHH6
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH6 = value
        End Set
    End Property
    Public Property UniversitarioComplHH7() As Long
        Get
            Return mlngUniversitarioComplHH7
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH7 = value
        End Set
    End Property
    Public Property UniversitarioComplHH8() As Long
        Get
            Return mlngUniversitarioComplHH8
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH8 = value
        End Set
    End Property
    Public Property UniversitarioComplHH9() As Long
        Get
            Return mlngUniversitarioComplHH9
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH9 = value
        End Set
    End Property
    Public Property UniversitarioComplHH10() As Long
        Get
            Return mlngUniversitarioComplHH10
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH10 = value
        End Set
    End Property
    Public Property UniversitarioComplHH11() As Long
        Get
            Return mlngUniversitarioComplHH11
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH11 = value
        End Set
    End Property
    Public Property UniversitarioComplHH12() As Long
        Get
            Return mlngUniversitarioComplHH12
        End Get
        Set(ByVal value As Long)
            mlngUniversitarioComplHH12 = value
        End Set
    End Property
#End Region




    Public Sub Cargar(ByVal blnHolding As Boolean, ByVal strRutCliente As String, _
                  ByVal intCodSucursal As Integer, ByVal lngRutEjecutivo As Long, _
                  ByVal intAgno As Integer)
        Try
            'listado de ruts asociados a una empresa
            Dim strRuts As String, i As Integer
            strRuts = ""
            If Trim(strRutCliente) <> "" Then
                strRuts = Trim(RutUsrALng(strRutCliente))
                If blnHolding Then  'si hay que buscar las filiales
                    Dim dtRut As DataTable
                    mobjSql = New CSql
                    dtRut = mobjSql.s_clientes_asociados(strRuts)
                    For i = 0 To TamanoArreglo2(dtRut) - 1
                        strRuts = strRuts & "," & Trim(dtRut.Rows(i)(0)) '(0, i)
                    Next
                End If
            End If

            Dim j As Integer

            'consulta los niveles educacionales
            Dim intTotalNivelEduc As Integer
            Dim dtNiveles As DataTable
            mobjSql = New CSql
            dtNiveles = mobjSql.s_niveles_educacionales_todos
            intTotalNivelEduc = mobjSql.Registros 'TamanoArreglo2(arrNiveles)
            If intTotalNivelEduc > 0 Then
                'ReDim marrNivelEduc(intTotalNivelEduc - 1)
                Dim dr As DataRow
                'For i = 0 To intTotalNivelEduc - 1
                For Each dr In dtNiveles.Rows
                    Select Case dr("cod_nivel_educ")
                        Case 1
                            mstrNombreNivelEduc1 = dr("nombre")
                        Case 2
                            mstrNombreNivelEduc2 = dr("nombre")
                        Case 3
                            mstrNombreNivelEduc3 = dr("nombre")
                        Case 4
                            mstrNombreNivelEduc4 = dr("nombre")
                        Case 5
                            mstrNombreNivelEduc5 = dr("nombre")
                        Case 6
                            mstrNombreNivelEduc6 = dr("nombre")
                        Case 7
                            mstrNombreNivelEduc7 = dr("nombre")
                        Case 8
                            mstrNombreNivelEduc8 = dr("nombre")
                        Case 9
                            mstrNombreNivelEduc9 = dr("nombre")
                    End Select

                    'mdtNivelEduc.Rows(i)(1) = dtNiveles.Rows(i)(1) '(1, i)
                Next
            Else
                mdtNivelEduc = New DataTable
            End If

            'inicializar arreglo con los nombres de niveles educacionales y
            'los totales por categoría
            'mobjTotalParticipantesNivel = CreateObject("Scripting.Dictionary")
            'mobjTotalHorasHombreNivel = CreateObject("Scripting.Dictionary")
            'For i = 0 To intTotalNivelEduc - 1
            'mdtNivelEduc.Rows(i)(1) = mdtNivelEduc.Rows(i)(1) '(1, i)
            'mobjTotalParticipantesNivel.item(mdtNivelEduc(i)) = 0
            'mobjTotalHorasHombreNivel.item(mdtNivelEduc(i)) = 0
            'Next

            'inicialización de valores a cero
            'For i = 0 To 11
            'totales
            'mdtCursos = 0
            'marrTotalParticipantesMes(i) = 0
            'marrTotalHorasHombreMes(i) = 0
            'arreglos
            'marrParticipantes(i) = CreateObject("Scripting.Dictionary")
            'marrHorasHombre(i) = CreateObject("Scripting.Dictionary")
            'For j = 0 To intTotalNivelEduc - 1
            'marrParticipantes(i).item(marrNivelEduc(j)) = 0
            'marrHorasHombre(i).item(marrNivelEduc(j)) = 0
            'Next
            'Next

            'variables auxiliares
            Dim dtConsulta As DataTable
            Dim intFilas As Integer, intMes As Integer, strNivelEduc As String, lngCantidad As Long

            'consulta de cursos contratados
            dtConsulta = mobjSql.s_total_cursos_contratados(intAgno, ESTADO_CURSOS, strRuts, _
                                                             intCodSucursal, lngRutEjecutivo, _
                                                             mlngRutUsuario)
            intFilas = mobjSql.Registros 'TamanoArreglo2(dtConsulta)
            mlngTotalCursosInscritos = 0
            If intFilas > 0 Then
                Dim dr As DataRow
                For Each dr In dtConsulta.Rows
                    Select Case dr("cod_mes")
                        Case 1
                            mlngCursosInscritos1 = dr("total")
                        Case 2
                            mlngCursosInscritos2 = dr("total")
                        Case 3
                            mlngCursosInscritos3 = dr("total")
                        Case 4
                            mlngCursosInscritos4 = dr("total")
                        Case 5
                            mlngCursosInscritos5 = dr("total")
                        Case 6
                            mlngCursosInscritos6 = dr("total")
                        Case 7
                            mlngCursosInscritos7 = dr("total")
                        Case 8
                            mlngCursosInscritos8 = dr("total")
                        Case 9
                            mlngCursosInscritos9 = dr("total")
                        Case 10
                            mlngCursosInscritos10 = dr("total")
                        Case 11
                            mlngCursosInscritos11 = dr("total")
                        Case 12
                            mlngCursosInscritos12 = dr("total")

                    End Select
                    mlngTotalCursosInscritos = mlngTotalCursosInscritos + dr("total") 'dtConsulta.Rows(i)(1)
                Next
            End If
            'For i = 0 To intFilas - 1
            'intMes = dtConsulta.Rows(i)(0) - 1 '(0, i) - 1
            'mdtCursos.Rows(intMes) = dtConsulta.Rows(i)(1) '(1, i)
            'mlngTotalCursosInscritos = mlngTotalCursosInscritos + dtConsulta.Rows(i)(1) '(1, i)
            'Next

            'consulta de total de participantes
            dtConsulta = mobjSql.s_participantes_niveleduc(intAgno, ESTADO_CURSOS, strRuts, _
                                                            intCodSucursal, lngRutEjecutivo, _
                                                            mlngRutUsuario)
            intFilas = mobjSql.Registros '(arrConsulta)
            mlngTotalParticipantes = 0
            For i = 0 To intFilas - 1
                intMes = dtConsulta.Rows(i)(1) - 1 '(1, i) - 1
                strNivelEduc = dtConsulta.Rows(i)(0) '(0, i)
                lngCantidad = CLng(dtConsulta.Rows(i)(2)) '(2, i))
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngSinEScolaridadPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngSinEScolaridadPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngSinEScolaridadPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngSinEScolaridadPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngSinEScolaridadPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngSinEScolaridadPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngSinEScolaridadPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngSinEScolaridadPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngSinEScolaridadPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngSinEScolaridadPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngSinEScolaridadPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngSinEScolaridadPart12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngBasicaIncomplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngBasicaIncomplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngBasicaIncomplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngBasicaIncomplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngBasicaIncomplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngBasicaIncomplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngBasicaIncomplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngBasicaIncomplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngBasicaIncomplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngBasicaIncomplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngBasicaIncomplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngBasicaIncomplPart12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngBasicaComplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngBasicaComplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngBasicaComplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngBasicaComplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngBasicaComplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngBasicaComplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngBasicaComplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngBasicaComplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngBasicaComplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngBasicaComplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngBasicaComplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngBasicaComplPart12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngMediaIncomplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngMediaIncomplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngMediaIncomplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngMediaIncomplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngMediaIncomplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngMediaIncomplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngMediaIncomplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngMediaIncomplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngMediaIncomplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngMediaIncomplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngMediaIncomplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngMediaIncomplPart12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngMediaComplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngMediaComplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngMediaComplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngMediaComplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngMediaComplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngMediaComplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngMediaComplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngMediaComplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngMediaComplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngMediaComplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngMediaComplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngMediaComplPart12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngTecnicaIncoplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngTecnicaIncoplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngTecnicaIncoplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngTecnicaIncoplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngTecnicaIncoplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngTecnicaIncoplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngTecnicaIncoplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngTecnicaIncoplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngTecnicaIncoplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngTecnicaIncoplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngTecnicaIncoplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngTecnicaIncoplPart12 = lngCantidad
                End If
                'If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) =  Then
                '    mlngTenicaComplPart = lngCantidad
                'End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngTenicaComplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngTenicaComplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngTenicaComplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngTenicaComplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngTenicaComplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngTenicaComplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngTenicaComplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngTenicaComplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngTenicaComplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngTenicaComplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngTenicaComplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngTenicaComplPart12 = lngCantidad
                End If
                'If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) =  Then
                '    UniversitarioIncomplpart = lngCantidad
                'End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 1 Then
                    UniversitarioIncomplpart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 2 Then
                    UniversitarioIncomplpart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 3 Then
                    UniversitarioIncomplpart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 4 Then
                    UniversitarioIncomplpart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 5 Then
                    UniversitarioIncomplpart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 6 Then
                    UniversitarioIncomplpart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 7 Then
                    UniversitarioIncomplpart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 8 Then
                    UniversitarioIncomplpart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 9 Then
                    UniversitarioIncomplpart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 10 Then
                    UniversitarioIncomplpart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 11 Then
                    UniversitarioIncomplpart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 12 Then
                    UniversitarioIncomplpart12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngUniversitarioComplPart1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngUniversitarioComplPart2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngUniversitarioComplPart3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngUniversitarioComplPart4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngUniversitarioComplPart5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngUniversitarioComplPart6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngUniversitarioComplPart7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngUniversitarioComplPart8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngUniversitarioComplPart9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngUniversitarioComplPart10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngUniversitarioComplPart11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngUniversitarioComplPart12 = lngCantidad
                End If
                'valor
                'mdtParticipantes.Rows(intMes).Item(strNivelEduc) = lngCantidad
                'totales
                'mdtTotalParticipantesMes.Rows(intMes) = mdtTotalParticipantesMes.Rows(intMes) + lngCantidad
                'mobjTotalParticipantesNivel.item(strNivelEduc) = mobjTotalParticipantesNivel.item(strNivelEduc) + lngCantidad
                mlngTotalParticipantes = mlngTotalParticipantes + lngCantidad
            Next

            'consulta de horas-hombre
            dtConsulta = mobjSql.s_horashombre_niveleduc(intAgno, ESTADO_CURSOS, strRuts, _
                                                          intCodSucursal, lngRutEjecutivo, _
                                                          mlngRutUsuario)
            intFilas = mobjSql.Registros 'TamanoArreglo2(arrConsulta)
            mlngTotalHorasHombre = 0
            For i = 0 To intFilas - 1
                intMes = dtConsulta.Rows(i)(1) - 1 '(1, i) - 1
                strNivelEduc = dtConsulta.Rows(i)(0) '(0, i)
                lngCantidad = CLng(dtConsulta.Rows(i)(2)) '(2, i))
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngSinEScolaridadHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngSinEScolaridadHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngSinEScolaridadHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngSinEScolaridadHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngSinEScolaridadHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngSinEScolaridadHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngSinEScolaridadHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngSinEScolaridadHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngSinEScolaridadHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngSinEScolaridadHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngSinEScolaridadHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Sin Escolaridad" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngSinEScolaridadHH12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngBasicaIncomplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngBasicaIncomplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngBasicaIncomplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngBasicaIncomplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngBasicaIncomplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngBasicaIncomplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngBasicaIncomplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngBasicaIncomplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngBasicaIncomplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngBasicaIncomplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngBasicaIncomplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Incompleta" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngBasicaIncomplHH12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngBasicaComplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngBasicaComplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngBasicaComplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngBasicaComplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngBasicaComplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngBasicaComplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngBasicaComplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngBasicaComplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngBasicaComplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngBasicaComplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngBasicaComplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Basica Completa" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngBasicaComplHH12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngMediaIncomplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngMediaIncomplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngMediaIncomplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngMediaIncomplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngMediaIncomplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngMediaIncomplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngMediaIncomplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngMediaIncomplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngMediaIncomplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngMediaIncomplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngMediaIncomplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Incompleta" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngMediaIncomplHH12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngMediaComplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngMediaComplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngMediaComplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngMediaComplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngMediaComplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngMediaComplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngMediaComplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngMediaComplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngMediaComplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngMediaComplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngMediaComplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Licencia Media Completa" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngMediaComplHH12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngTecnicaIncoplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngTecnicaIncoplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngTecnicaIncoplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngTecnicaIncoplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngTecnicaIncoplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngTecnicaIncoplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngTecnicaIncoplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngTecnicaIncoplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngTecnicaIncoplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngTecnicaIncoplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngTecnicaIncoplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Incompleta" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngTecnicaIncoplHH12 = lngCantidad
                End If
                'If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) =  Then
                '    mlngTenicaComplHH = lngCantidad
                'End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngTenicaComplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngTenicaComplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngTenicaComplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngTenicaComplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngTenicaComplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngTenicaComplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngTenicaComplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngTenicaComplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngTenicaComplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngTenicaComplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngTenicaComplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Superior Técnica  Profesional Completa" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngTenicaComplHH12 = lngCantidad
                End If
                'If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) =  Then
                '    UniversitarioIncomplHH = lngCantidad
                'End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 1 Then
                    UniversitarioIncomplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 2 Then
                    UniversitarioIncomplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 3 Then
                    UniversitarioIncomplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 4 Then
                    UniversitarioIncomplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 5 Then
                    UniversitarioIncomplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 6 Then
                    UniversitarioIncomplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 7 Then
                    UniversitarioIncomplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 8 Then
                    UniversitarioIncomplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 9 Then
                    UniversitarioIncomplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 10 Then
                    UniversitarioIncomplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 11 Then
                    UniversitarioIncomplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Incompleto" And dtConsulta.Rows(i)(1) = 12 Then
                    UniversitarioIncomplHH12 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 1 Then
                    mlngUniversitarioComplHH1 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 2 Then
                    mlngUniversitarioComplHH2 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 3 Then
                    mlngUniversitarioComplHH3 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 4 Then
                    mlngUniversitarioComplHH4 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 5 Then
                    mlngUniversitarioComplHH5 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 6 Then
                    mlngUniversitarioComplHH6 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 7 Then
                    mlngUniversitarioComplHH7 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 8 Then
                    mlngUniversitarioComplHH8 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 9 Then
                    mlngUniversitarioComplHH9 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 10 Then
                    mlngUniversitarioComplHH10 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 11 Then
                    mlngUniversitarioComplHH11 = lngCantidad
                End If
                If dtConsulta.Rows(i)(0) = "Universitario Completo" And dtConsulta.Rows(i)(1) = 12 Then
                    mlngUniversitarioComplHH12 = lngCantidad
                End If
                'valor
                'mdtHorasHombre.Rows(intMes).Item(strNivelEduc) = lngCantidad
                'totales
                'marrTotalHorasHombreMes(intMes) = marrTotalHorasHombreMes(intMes) + lngCantidad
                'mobjTotalHorasHombreNivel.item(strNivelEduc) = mobjTotalHorasHombreNivel.item(strNivelEduc) + lngCantidad
                mlngTotalHorasHombre = mlngTotalHorasHombre + lngCantidad
            Next

        Catch ex As Exception
            EnviaError("CInformeEstadistica.vb:Cargar-->" & ex.Message)
        End Try




    End Sub
End Class
