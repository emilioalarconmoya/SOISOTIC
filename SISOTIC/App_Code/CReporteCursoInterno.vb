Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CReporteCursoInterno
    Implements IReporte
    Private mstrXml As String
    Private mlngFilas As Long
    Private mblnBajarXml As Boolean
    'objeto con consultas a la base
    Private mobjSql As CSql
    'Rut Empresa
    Private mlngRutEmpresa As Long
    'Nombre Empresa
    Private mintAgno As Integer
    'Total
    Private mlngTotal As Long
    Private mlngRutUsuario As Long
    'Nombre del curso
    Private mstrNombreCurso As String
    'nombre empresa
    Private mstrRazonSocial As String
    'El Número Correlativo del Curso
    Private mlngCorrelativo As Long
    'El Número de que representa los perfiles que el usuario tiene
    Private mlngNroPerfil As Long
    'Nombre del ejecutor
    Private mstrEjecutor As String
    'horario del curso
    Private mstrHorario As String
    'Rut del Cliente
    Private mlngRutCliente As Long
    'Código del Estado del Curso
    Private mintCodEstadoCurso As Integer
    'Fecha de Inicio del Curso
    Private mdtmFechaInicio As Date
    'Fecha de Fin del Curso
    Private mdtmFechaTermino As Date
    'Valor del curso en el mercado
    Private mlngValorCurso As Long
    'Descuento
    Private mlngDescuento As Long
    'Indicador si el descuento es monto (0) o porcentaje (1)
    Private mintIndDescPorc As Integer
    'Direccion donde se dara el curso
    Private mlngValorTotalCurso As Long
    Private mstrDireccionCurso As String
    'Código de la Comuna
    Private mlngCodComuna As Long
    'Código de la Region
    Private mlngCodRegion As Long
    'Arreglo con todas las comunas
    Private mdtComunas As DataTable
    'Nombre de la Region
    Private mstrNomRegion As String
    'Correlativo Interno de la Empresa Cliente
    Private mstrCorrEmpresa As String
    'Observación
    Private mstrObservacion As String
    'Numero de Participantes del curso
    Private mlngNumAlumnos As Long
    'Objeto Cliente
    Private mobjCliente As CCliente
    'Declaracion de un arreglo de Alumnos
    Private mcolAlumnos As Collection
    Private mintHoras As Integer
    Private mstrNombreEstado As String
    'Etiquetas
    Private mdtEtiquetas As DataTable

    Public Property RutEmpresa() As Long
        Get
            RutEmpresa = mlngRutEmpresa
        End Get
        Set(ByVal value As Long)
            mlngRutEmpresa = value
        End Set
    End Property
    
    Public ReadOnly Property Total() As Long
        Get
            Return mlngTotal
        End Get
    End Property
    Public ReadOnly Property Etiquetas() As DataTable
        Get
            Return mdtEtiquetas
        End Get
    End Property
    Public Property RurUsuario() As Long
        Get
            Return mlngRutUsuario
        End Get
        Set(ByVal value As Long)
            mlngRutUsuario = value
        End Set
    End Property
    Public Property NombreCurso() As String
        Get
            Return mstrNombreCurso
        End Get
        Set(ByVal value As String)
            mstrNombreCurso = value
        End Set
    End Property
    Public Property RazonSocial() As String
        Get
            Return mstrRazonSocial
        End Get
        Set(ByVal value As String)
            mstrRazonSocial = value
        End Set
    End Property
    Public Property NombreEstado() As String
        Get
            Return mstrNombreEstado
        End Get
        Set(ByVal value As String)
            mstrNombreEstado = value
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
    Public Property NroPerfil() As Long
        Get
            Return mlngNroPerfil
        End Get
        Set(ByVal value As Long)
            mlngNroPerfil = value
        End Set
    End Property
    Public Property Ejecutor() As String
        Get
            Return mstrEjecutor
        End Get
        Set(ByVal value As String)
            mstrEjecutor = value
        End Set
    End Property
    Public Property Horario() As String
        Get
            Return mstrHorario
        End Get
        Set(ByVal value As String)
            mstrHorario = value
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
    Public Property CodEstadoCurso() As Integer
        Get
            Return mintCodEstadoCurso
        End Get
        Set(ByVal value As Integer)
            mintCodEstadoCurso = value
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
    Public Property FechaInicio() As Date
        Get
            Return mdtmFechaInicio
        End Get
        Set(ByVal value As Date)
            mdtmFechaInicio = value
        End Set
    End Property
    Public Property FechaTermino() As Date
        Get
            Return mdtmFechaTermino
        End Get
        Set(ByVal value As Date)
            mdtmFechaTermino = value
        End Set
    End Property
    Public Property ValorCurso() As Long
        Get
            Return mlngValorCurso
        End Get
        Set(ByVal value As Long)
            mlngValorCurso = value
        End Set
    End Property
    Public Property ValorTotalCurso() As Long
        Get
            Return mlngValorTotalCurso
        End Get
        Set(ByVal value As Long)
            mlngValorTotalCurso = value
        End Set
    End Property

    Public Property Descuento() As Long
        Get
            Return mlngDescuento
        End Get
        Set(ByVal value As Long)
            mlngDescuento = value
        End Set
    End Property
    Public Property IndDescPorc() As Integer
        Get
            Return mintIndDescPorc
        End Get
        Set(ByVal value As Integer)
            mintIndDescPorc = value
        End Set
    End Property
    Public Property DireccionCurso() As String
        Get
            Return mstrDireccionCurso
        End Get
        Set(ByVal value As String)
            mstrDireccionCurso = value
        End Set
    End Property
    Public Property CodComuna() As Long
        Get
            Return mlngCodComuna
        End Get
        Set(ByVal value As Long)
            mlngCodComuna = value
        End Set
    End Property
    Public Property CodRegion() As Long
        Get
            Return mlngCodRegion
        End Get
        Set(ByVal value As Long)
            mlngCodRegion = value
        End Set
    End Property
    Public ReadOnly Property LookUpComunas() As DataTable
        Get
            LookUpComunas = mdtComunas
        End Get
    End Property
    Public Property NomRegion() As String
        Get
            Return mstrNomRegion
        End Get
        Set(ByVal value As String)
            mstrNomRegion = value
        End Set
    End Property
    Public Property Alumnos() As Collection
        Get
            Return mcolAlumnos
        End Get
        Set(ByVal value As Collection)
            mcolAlumnos = value
        End Set
    End Property
    Public Property CorrEmpresa() As String
        Get
            Return mstrCorrEmpresa
        End Get
        Set(ByVal value As String)
            mstrCorrEmpresa = value
        End Set
    End Property
    Public Property Observacion() As String
        Get
            Return mstrObservacion
        End Get
        Set(ByVal value As String)
            mstrObservacion = value
        End Set
    End Property
    Public Property NumAlumnos() As Long
        Get
            Return mlngNumAlumnos
        End Get
        Set(ByVal value As Long)
            mlngNumAlumnos = value
        End Set
    End Property

    'Public Function Consultar() As Object


    '    'correlativo, ci.cod_estado_curso_interno, ec.nombre, nombre_curso, " _"
    '    '    & "ejecutor,num_participantes,inicio_curso, " _
    '    '    & "fin_curso , valor_curso, correlativo_empresa, ci.Rut, cl.razon_social


    '    'intFilas = mobjSql.Registros
    '    'If intFilas > 0 Then
    '    'ReDim dtConsulta(intFilas - 1)
    '    'asignar el resultado de la consulta al arreglo con campos

    '    'For i = 0 To intFilas - 1
    '    '    dtConsulta(i) = CreateObject("Scripting.Dictionary")
    '    '    dtConsulta(i).item("Correlativo") = dtConsulta(0, i)
    '    '    dtConsulta(i).item("CodEstado") = dtConsulta(1, i)
    '    '    dtConsulta(i).item("NombreEstado") = dtConsulta(2, i)
    '    '    dtConsulta(i).item("NombreCurso") = dtConsulta(3, i)
    '    '    dtConsulta(i).item("Ejecutor") = dtConsulta(4, i)
    '    '    dtConsulta(i).item("NumParticipantes") = dtConsulta(5, i)
    '    '    dtConsulta(i).item("InicioCurso") = MostrarFecha(dtConsulta(6, i))
    '    '    dtConsulta(i).item("FinCurso") = MostrarFecha(dtConsulta(7, i))
    '    '    dtConsulta(i).item("ValorCurso") = dtConsulta(8, i)
    '    '    dtConsulta(i).item("CorrEmpresa") = IIf(IsNull(dtConsulta(9, i)), "-", dtConsulta(9, i))
    '    '    dtConsulta(i).item("RutEmpresa") = dtConsulta(10, i)
    '    '    dtConsulta(i).item("NombreEmpresa") = dtConsulta(11, i)

    '    '    'Total, Suma los en estado ingresado
    '    '    If dtConsulta(i).item("CodEstado") = 1 Then
    '    '        mlngTotal = dtConsulta(i).item("ValorCurso") + mlngTotal
    '    '    End If
    '    'Next
    '    'Else
    '    'dtConsulta = New DataTable
    '    'End If

    '    'Consultar = dtConsulta

    '    'dtConsulta = Array()
    '    'dtConsulta = Array()
    'End Function

    'inicialización del objeto  ?????
    'Public Sub Inicializar(ByRef objSql As CSql)
    '    mobjSql = objSql
    'End Sub

    'inicialización de variables   ????
    Private Sub Initialize()
        mlngRutEmpresa = 0
        mintAgno = 0

        'Llenado de Etiquetas
        'ReDim marrEtiquetas(11)
        'mdtEtiquetas(0)= "Correlativo"
        'mdtEtiquetas(1) = "Cod. Estado"
        'mdtEtiquetas(2) = "Nombre Estado"
        'mdtEtiquetas(3) = "Nombre Curso"
        'mdtEtiquetas(4) = "Ejecutor"
        'mdtEtiquetas(5) = "Num. Participantes"
        'mdtEtiquetas(6) = "Inicio Curso"
        'mdtEtiquetas(7) = "Fin Curso"
        'mdtEtiquetas(8) = "Valor Curso"
        'mdtEtiquetas(9) = "Corr. Empresa"
        'mdtEtiquetas(10) = "Rut Empresa"
        'mdtEtiquetas(11) = "Nombre Empresa"
    End Sub

    'función para mostrar una fecha en formato usuario, puede recibir Null
    Private Function MostrarFecha(ByVal vntFecha As Object) As String
        If IsDBNull(vntFecha) Then
            MostrarFecha = ""
        ElseIf IsDate(vntFecha) Then
            MostrarFecha = FechaVbAUsr(vntFecha)
        Else
            MostrarFecha = "Error en la fecha!"
        End If
    End Function

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
    'inicialización del objeto
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    Public Function Consultar() As System.Data.DataTable Implements Clases.IReporte.Consultar
        Try
            Dim dtConsulta As DataTable
            'Dim objCurso As cCursoContratado
            Dim i As Integer
            Dim intFilas As Integer
            Dim strNombreArchivo As String

            mobjSql = New CSql

            dtConsulta = mobjSql.s_cursos_internos_todos(mlngRutCliente, mintAgno)
            intFilas = mobjSql.Registros
            If intFilas > 0 Then
                Dim dr As DataRow

                For Each dr In dtConsulta.Rows


                    mlngCorrelativo = dr("correlativo")
                    mintCodEstadoCurso = dr("cod_estado_curso_interno")
                    mstrNombreEstado = dr("nombre")
                    mstrNombreCurso = dr("nombre_curso")
                    mstrEjecutor = dr("ejecutor")
                    mlngNumAlumnos = dr("num_participantes")
                    mdtmFechaInicio = dr("inicio_curso")
                    mdtmFechaTermino = dr("fin_curso")
                    mlngValorCurso = dr("valor_curso")
                    mstrCorrEmpresa = ("correlativo_empresa")
                    mlngRutCliente = dr("Rut")
                    mstrRazonSocial = dr("razon_social")
                Next
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtConsulta.TableName = "Reporte Cursos"
                    ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If
            End If

            Return dtConsulta
        Catch ex As Exception
            EnviaError("CReporteCursoInterno: Consultar-->" & ex.Message)
        End Try

    End Function

    
End Class
