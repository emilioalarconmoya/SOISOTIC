Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data

Public Class CReporteCursosAlumno
    Implements IReporte
    Private objSession As New CSession
    Private mobjSql As New CSql
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String
    '
    'Parámetros del reporte
    '
    'rut del alunno
    Private mlngRutAlumno As Long

    'rut usuario
    Private mlngRutUsuario As Long

    'Rut Empresa
    Private mlngRutEmpresa As Long

    'Nombre Empresa
    Private mstrNombreEmpresa As String

    Private mlngTotales As Long

    Private mstrTipo As String
    Public Property Tipo() As String
        Get
            Return mstrTipo
        End Get
        Set(ByVal value As String)
            mstrTipo = value
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
    Public Property RutAlumno() As String
        Get
            Return mlngRutAlumno
        End Get
        Set(ByVal value As String)
            mlngRutAlumno = value
        End Set
    End Property

    Public Property RutEmpresa() As String
        Get
            Return mlngRutEmpresa
        End Get
        Set(ByVal value As String)
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

    Public Property Totales() As Long
        Get
            Return mlngTotales
        End Get
        Set(ByVal value As Long)
            mlngTotales = value
        End Set
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            If mstrTipo = "Interno" Then
                Dim dtConsultaInterno As DataTable
                dtConsultaInterno = mobjSql.s_curso_alumno_interno(mlngRutAlumno, mlngRutEmpresa)
                Me.mlngFilas = Me.mobjSql.Registros
                If Me.mlngFilas > 0 Then
                    dtConsultaInterno.Columns.Add("total")
                    Dim dr4 As DataRow
                    For Each dr4 In dtConsultaInterno.Rows
                        Dim totales4 As Long
                        totales4 = 0
                        dr4("total") = totales4 + dr4("CostoOticAl") + dr4("CostoEmpAl") + dr4("Viatico") + dr4("Traslado")
                    Next

                    Dim dtTemporal As DataTable
                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_pers_nat(mlngRutAlumno)
                    Dim drt As DataRow
                    For Each drt In dtTemporal.Rows
                        mlngRutEmpresa = drt("rut_empresa")
                    Next
                    'Return dtTemporal

                    dtTemporal = New DataTable
                    dtTemporal = mobjSql.s_persona_juridica2(mlngRutEmpresa)
                    Dim drt2 As DataRow
                    For Each drt2 In dtTemporal.Rows
                        mstrNombreEmpresa = drt2("nom_fantasia")
                    Next
                End If
                Return dtConsultaInterno
            ElseIf mstrTipo = "Sence" Then
                Dim dtConsulta As DataTable
                'Dim objCurso As cCursoContratado
                Dim i As Integer, intFilas As Integer
                Dim c, lngDescuento As Long
                Dim lngValorMercado, lngHoras, lngHorasCompl, lngCodCursoCompl As Long
                Dim dblGastoEmpresaAlumno As Double, dblCostoOticAlumno As Double
                Dim dblValHoraCurso, dblPorcAdm, dblValHoraCursoFranquiciable, dblPorcFranquicia, dblPorcAsistencia As Double
                Dim intCodEstadoCurso, intIndAcuComBip, intIndDescPorc As Integer
                Dim intNumAlumnos As Integer
                Dim lngValHoraSence As Double
                Dim strNombreArchivo As String
                'lngValHoraSence = mobjSql.s_val_hora_sence
                dtConsulta = mobjSql.s_curso_alumno_sence2(mlngRutAlumno, mlngRutEmpresa)
                Me.mlngFilas = Me.mobjSql.Registros
                If Me.mlngFilas > 0 Then
                    dtConsulta.Columns.Add("CostoOticAl")
                    dtConsulta.Columns.Add("CostoEmpAl")
                    dtConsulta.Columns.Add("total")
                    Dim dr As DataRow
                    For Each dr In dtConsulta.Rows
                        lngValHoraSence = dr("valor_hora") 'mobjSql.s_val_hora_curso(dr("valor_hora"))

                        intCodEstadoCurso = CInt(dr("cod_estado_curso"))
                        lngValorMercado = CLng(dr("valor_mercado"))
                        lngDescuento = CInt(dr("Descuento"))
                        dblPorcAdm = CDbl(dr("porc_adm"))
                        lngHoras = CLng(dr("horas"))
                        lngHorasCompl = CLng(dr("horas_compl"))
                        intIndAcuComBip = CInt(dr("ind_acu_com_bip"))
                        intIndDescPorc = CInt(dr("ind_desc_porc"))
                        intNumAlumnos = CInt(dr("num_alumnos"))
                        If CDbl(dr("porc_franquicia")) >= 0 And CDbl(dr("porc_franquicia")) <= 1 Then
                            dblPorcFranquicia = dr("porc_franquicia")
                        ElseIf CDbl(dr("porc_franquicia")) > 1 And CDbl(dr("porc_franquicia")) <= 100 Then
                            dblPorcFranquicia = dr("porc_franquicia") / 100
                        End If
                        'If CDbl(dr("porc_asistencia")) >= 0 And CDbl(dr("porc_asistencia")) <= 1 Then
                        dblPorcAsistencia = dr("porc_asistencia")
                        'ElseIf CDbl(dr("porc_asistencia")) > 1 And CDbl(dr("porc_asistencia")) <= 100 Then
                        'dblPorcAsistencia = dr("porc_asistencia") / 100
                        'End If

                        dblCostoOticAlumno = CalcularCostoOticAlumno(lngHoras, _
                                                                                     lngValHoraSence, intIndAcuComBip, _
                                                                                             lngHorasCompl, lngValorMercado, _
                                                                                             intIndDescPorc, _
                                                                                             lngDescuento, intNumAlumnos, _
                                                                                             CDbl(dr("porc_asistencia")), _
                                                                                             intCodEstadoCurso, _
                                                                                             dblGastoEmpresaAlumno, _
                                                                                             dblPorcFranquicia)

                        dr("CostoOticAl") = dblCostoOticAlumno
                        dr("CostoEmpAl") = dblGastoEmpresaAlumno

                        Dim totales As Long
                        totales = 0
                        dr("total") = totales + dr("CostoOticAl") + dr("CostoEmpAl") + dr("Viatico") + dr("Traslado")
                        ' mlngTotales = totales + dr("CostoOticAl") + dr("CostoEmpAl") + dr("Viatico") + dr("Traslado")
                    Next
                End If

                Dim dtTemporal As DataTable
                dtTemporal = New DataTable
                dtTemporal = mobjSql.s_pers_nat(mlngRutAlumno)
                Dim drt As DataRow
                For Each drt In dtTemporal.Rows
                    mlngRutEmpresa = drt("rut_empresa")
                Next
                'Return dtTemporal

                dtTemporal = New DataTable
                dtTemporal = mobjSql.s_persona_juridica2(mlngRutEmpresa)
                Dim drt2 As DataRow
                For Each drt2 In dtTemporal.Rows
                    mstrNombreEmpresa = drt2("nom_fantasia")
                Next
                'Return dtTemporal

                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtConsulta.TableName = "Reporte de Alumnos"
                    ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
                Return dtConsulta
            End If
        Catch ex As Exception
            EnviaError("CReporteCursosAlumno:Consultar->" & ex.Message)
        End Try
    End Function
End Class
