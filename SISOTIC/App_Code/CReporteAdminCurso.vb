Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteAdminCurso
#Region "Declaraciones de variables"
    Implements IReporte
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    'Indicador del tipo de SubReporte
    Private mintTipo As Integer
    'estados 1 , 2
    Private mintEstados As Integer
    'rut del cliente
    Private mlngRutCliente As Long
    'Ejecutivo
    Private mlngEjecutivo As Long
    'rut del usuario
    Private mlngRutUsuario As Long
    'estado de los aportes: lista de códigos separada por comas
    Private mstrEstados As String
    'Indica si se buscaran los cursos propios de un ejecutivo(true) o no (false)
    Private mstrCursosPropios As String
    '
    'Criterios de búsqueda
    '
    'Correlativo CST
    Private mlngCorrCST As Long
    'Correlativo Empresa
    Private mstrCorrEmp As String
    'Nro. Registro
    Private mlngNroReg As Long
    'Rut Empresa
    Private mlngRutEmp As Long
    'Año Curso
    Private mlngAgnoCurso As Long
    'Nombre Empresa
    Private mstrNombreEmp As String
    'Condición Correlativo CST
    Private mstrCondCorrCST As String
    'Condición Correlativo Empresa
    Private mstrCondCorrEmp As String
    'Condición Nro. Reg
    Private mstrCondNroReg As String
    'Condición Rut Empresa
    Private mstrCondRutEmp As String
    'indicador de cálculo de montos cargados a la diferentes cuentas
    Private mblnMostrarCuentas As Boolean
    'lookups
    'objeto con consultas SQL
    'Private mobjSql As CSql
    'fecha inicial y final del período
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    'Numero de perfil
    Private mlngNroPerfil As Long
    'Nombre estado
    Private mstrNomEstado As String
    'Filtros de Busqueda
    Private mstrWhere As String

    Private mblnProximoDiaHabil As Boolean

    Private mintCuentaTercero As Integer

    Private mlngCorrelativo As Long

    Private mstrVoucher As String

    Private mlngCodCurso As Long



#End Region
#Region "Propiedades"
    Public WriteOnly Property ProximoDiaHabil() As Boolean
        Set(ByVal value As Boolean)
            mblnProximoDiaHabil = value
        End Set
    End Property
    Public Property Voucher() As String
        Get
            Return mstrVoucher
        End Get
        Set(ByVal value As String)
            mstrVoucher = value
        End Set
    End Property
    Public Property Tipo() As Integer
        Get
            Return mintTipo
        End Get
        Set(ByVal value As Integer)
            mintTipo = value
        End Set
    End Property
    Public Property Correlativo() As Long
        Get
            Return mlngCorrelativo
        End Get
        Set(ByVal value As Long)
            mlngCorrelativo = value
        End Set
    End Property
    Public Property CuentaTercero() As Integer
        Get
            Return mintCuentaTercero
        End Get
        Set(ByVal value As Integer)
            mintCuentaTercero = value
        End Set
    End Property
    Public Property EstadosCur() As Integer
        Get
            Return mintEstados
        End Get
        Set(ByVal value As Integer)
            mintEstados = value
        End Set
    End Property
    'nombre estado
    Public Property NombreEstado() As String
        Get
            Return mstrNomEstado
        End Get
        Set(ByVal value As String)
            mstrNomEstado = value
        End Set
    End Property
    'número de perfil
    Public Property NumeroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
        Set(ByVal value As Long)
            mlngNroPerfil = value
        End Set
    End Property

    'fecha de inicio
    Public Property FechaInicio() As String
        Get
            Return FechaVbAUsr(mdtmFechaIni)
        End Get
        Set(ByVal value As String)
            mdtmFechaIni = FechaUsrAVb(value)
        End Set
    End Property

    'fecha de fin del periodo
    Public Property FechaFin() As String
        Get
            Return FechaVbAUsr(mdtmFechaFin)
        End Get
        Set(ByVal value As String)
            mdtmFechaFin = FechaVbAUsr(value)
        End Set
    End Property

    'rut del cliente que hizo el aporte
    Public Property RutCliente() As String
        Get
            Return RutLngAUsr(mlngRutCliente)
        End Get
        Set(ByVal value As String)
            mlngRutCliente = RutUsrALng(value)
        End Set
    End Property

    'rut del cliente que hizo el aporte
    Public Property EjecutivoSelec() As Long
        Get
            Return mlngEjecutivo
        End Get
        Set(ByVal value As Long)
            mlngEjecutivo = value
        End Set
    End Property

    Public Property AgnoCurso() As Long
        Get
            Return mlngAgnoCurso
        End Get
        Set(ByVal value As Long)
            mlngAgnoCurso = value
        End Set
    End Property

    'rut del cliente que hizo el aporte
    Public Property RutUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property

    'estados: lista de códigos de estados separadas por comas
    Public Property Estados() As String
        Get
            Return mstrEstados
        End Get
        Set(ByVal value As String)
            mstrEstados = value
        End Set
    End Property

    'Cursos Propios:Indica si se buscaran los cursos propios de un ejecutivo o no
    Public Property CursosPropios() As String
        Get
            Return mstrCursosPropios
        End Get
        Set(ByVal value As String)
            mstrCursosPropios = value
        End Set
    End Property

    'Criterio de búsqueda, Correlativo CST
    Public Property CorrCST() As Long
        Get
            Return mlngCorrCST
        End Get
        Set(ByVal value As Long)
            mlngCorrCST = value
        End Set
    End Property

    'Criterio de búsqueda, Correlativo Empresa
    Public Property CorrEmp() As String
        Get
            Return mstrCorrEmp
        End Get
        Set(ByVal value As String)
            mstrCorrEmp = value
        End Set
    End Property
    'Criterio de búsqueda, Nro. Registro
    Public Property NroReg() As Long
        Get
            Return mlngNroReg
        End Get
        Set(ByVal value As Long)
            mlngNroReg = value
        End Set
    End Property
    'Criterio de búsqueda, Rut Empresa
    Public Property RutEmp() As String
        Get
            Return mlngRutEmp
        End Get
        Set(ByVal value As String)
            If (Trim(value) = "") Then
                mlngRutEmp = -1
            Else
                mlngRutEmp = RutUsrALng(value)
            End If
        End Set
    End Property
    'Criterio de búsqueda, Nombre empresa
    Public Property NombreEmp() As String
        Get
            Return mstrNombreEmp
        End Get
        Set(ByVal value As String)
            mstrNombreEmp = value
        End Set
    End Property
    'Criterio de búsqueda, Condición Correlativo CST
    Public WriteOnly Property CondCorrCST() As String
        Set(ByVal value As String)
            mstrCondCorrCST = value
        End Set
    End Property
    'Criterio de búsqueda, Condición Correlativo Empresa
    Public WriteOnly Property CondCorrEmp() As String
        Set(ByVal value As String)
            mstrCondCorrEmp = value
        End Set
    End Property
    'Criterio de búsqueda, Condición Nro. Registro
    Public WriteOnly Property CondNroReg() As String
        Set(ByVal value As String)
            mstrCondNroReg = value
        End Set
    End Property
    'Criterio de búsqueda, Condición Rut Empresa
    Public WriteOnly Property CondRutEmp() As String
        Set(ByVal value As String)
            mstrCondRutEmp = value
        End Set
    End Property
    'setea el indicador para calcular o no los montos por cuentas
    Public WriteOnly Property MostrarCuentas() As Boolean
        Set(ByVal value As Boolean)
            mblnMostrarCuentas = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String Implements Clases.IReporte.ArchivoXml
        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean Implements Clases.IReporte.BajarXml
        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mlngFilas
        End Get
    End Property
    'Where
    Public Property Where() As String
        Get
            Return mstrWhere
        End Get
        Set(ByVal value As String)
            mstrWhere = value
        End Set
    End Property


    Public Property CodCurso() As Long
        Get
            Return mlngCodCurso
        End Get
        Set(ByVal value As Long)
            mlngCodCurso = value
        End Set
    End Property

#End Region

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim strCondicion As String

            Select Case mintTipo
                Case 0
                    'Cursos en los diferentes estados'
                    strCondicion = fstrCursos(mlngRutCliente, mstrEstados, mlngRutUsuario, mintEstados, mstrCursosPropios)
                    'mlngAgnoCurso, 
                Case 1
                    'Cursos con complemento'
                    'strCondicion = fstrComplementos(mlngRutUsuario)
                    strCondicion = fstrParciales(mlngRutUsuario)
                Case 2
                    'Cursos complementarios'
                    strCondicion = fstrComplementos(mlngRutUsuario)
                Case 3
                    'Cursos iniciados sin comunicar'
                    strCondicion = fstrCursoIniNoCom(mlngRutUsuario)
                Case 4
                    'Cursos iniciados sin autorizar'
                    strCondicion = fstrCursosIniNoAut(mlngRutUsuario)
                Case 5
                    'Cursos terminados sin asistencia'
                    strCondicion = fstrCursosTerSinAsis(mlngRutUsuario)
                Case 6
                    'Cursos terminados con asistencia sin liquidar'
                    strCondicion = fstrCursosTerConAsisSinLiq(mlngRutUsuario)
                Case 7
                    'Cursos con comunicación atrazada'
                    strCondicion = fstrCursosAtrasados(mlngRutUsuario)
                Case 8
                    'Cursos con fecha de término mayor a hoy + 55'
                    strCondicion = fstrCursosFechaTermino(mlngRutUsuario)
                Case 9
                    'Cursos con pago de terceros'
                    strCondicion = fstrCursosPagoTerceros(mlngRutUsuario, mintEstados, mstrCursosPropios)
                Case 10
                    'Cursos pagados sólo con cuenta de capacitación'
                    strCondicion = fstrCursosPagadosCtaCap(mlngRutUsuario, 1, mintEstados, mstrCursosPropios)
                Case 11
                    'Cursos pagados con cuenta de excedente de capacitación'
                    strCondicion = fstrCursosPagadosCtaExcCap(mlngRutUsuario, 4, mintEstados, mstrCursosPropios)
                Case 12
                    'Cursos con V&T'
                    strCondicion = fstrCursosVYT(mlngRutUsuario)
                Case 13
                    'Cursos no liquidados con fecha término menor a hoy - 50'
                    strCondicion = fstrCursosTerNoLiq(mlngRutUsuario, mlngAgnoCurso)
                Case 14
                    'Cursos con precontrato'
                    strCondicion = fstrCursosPreContrato(mlngRutUsuario)
                Case 15
                    'Cursos con postcontrato'
                    strCondicion = fstrCursosPostContrato(mlngRutUsuario)
                Case 16
                    'Cursos con Precenciales'
                    strCondicion = fstrCursosPrecenciales(mlngRutUsuario)
                Case 17
                    'Cursos con E-Learning'
                    strCondicion = fstrCursosELearning(mlngRutUsuario)
                Case 18
                    'Cursos con E-Learning'
                    strCondicion = fstrCursosADistancia(mlngRutUsuario)
                Case Else
                    strCondicion = ""
            End Select
            Dim strNombreArchivo As String
            Dim dtconsulta As DataTable
            Dim strCondicionFinal As String
            If strCondicion <> "" Then
                strCondicionFinal = "(select distinct cc.cod_curso " & strCondicion & ")"
            Else
                strCondicionFinal = ""
            End If
            Dim intCodEstadoCurso As Integer
            intCodEstadoCurso = mobjSql.s_codigo_curso(Me.mlngCorrelativo, mlngAgnoCurso)

            dtconsulta = mobjSql.s_cursos_contratados(strCondicionFinal, mlngRutUsuario, mstrWhere, mdtmFechaIni, _
                                                      mdtmFechaFin, mlngAgnoCurso, Me.CuentaTercero, Me.mlngCorrelativo, _
                                                      Me.mblnProximoDiaHabil, intCodEstadoCurso, mstrVoucher, mlngCodCurso, mlngNroReg)

            Me.mlngFilas = Me.mobjSql.Registros
            If Me.mlngFilas > 0 Then
                

                

                'dtconsulta = mobjSql.s_cursos_contratados(strCondicionFinal, _
                '   mlngRutUsuario, mstrWhere, mdtmFechaIni, mdtmFechaFin, mlngAgnoCurso, _
                '   Me.CuentaTercero, Me.mlngCorrelativo, Me.mblnProximoDiaHabil, intCodEstadoCurso, mstrVoucher)
                Dim drConsulta As DataRow
                dtconsulta.Columns.Add("diferenciacionCurso")
                For Each drConsulta In dtconsulta.Rows
                    mstrEstados = drConsulta("cod_estado_curso")
                    mlngNroPerfil = drConsulta("nro_perfil")
                    mstrNomEstado = drConsulta("estado_curso")
                    If drConsulta("cod_curso_compl") > 0 Then
                        drConsulta("diferenciacionCurso") = "P"
                    ElseIf drConsulta("cod_curso_parcial") > 0 Then
                        drConsulta("diferenciacionCurso") = "C"
                    Else
                        drConsulta("diferenciacionCurso") = ""
                    End If
                Next



                If Me.mblnBajarXml Then
                    Dim dc As DataColumn
                    Dim i As Integer = 0
                    Dim dt As DataTable
                    dt = dtconsulta

                    'dt.Columns.Remove("nFila")
                    'dt.Columns.Remove("cod_curso")
                    'dt.Columns.Remove("cod_estado_curso")
                    'dt.Columns.Remove("origen")
                    'dt.Columns.Remove("cod_curso_compl")
                    'dt.Columns.Remove("nro_perfil")
                    'dt.Columns.Remove("cod_curso_parcial")
                    'dt.AcceptChanges()

                    strNombreArchivo = NombreArchivoTmp("csv")
                    dt.TableName = "Reporte Cursos"

                    ConvierteDTaCSV(dt, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If


            End If
            
            Return dtconsulta
        Catch ex As Exception
            EnviaError("CReporteAdminCurso.vb:Consultar---> " & ex.Message)
        End Try
        
    End Function
    
End Class
