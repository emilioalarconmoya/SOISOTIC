Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CResumenCobranza
    'Parámetros del reporte
    Private mlngRutCliente As Long
    Private mstrNombreCliente As String
    Private mdtmFechaIni As Date
    Private mdtmFechaFin As Date
    Private mlngFilas As Long
    Private mdtFiliales As DataTable
    Private mdtFonoContacto As String
    Private mintAnexoContacto As String
    Private mstrNombreEjecutivo As String
    Private mstrSucursal As String
    Private mlngFranquicia As Long

    Private mstrXml As String
    Private mblnBajarXml As Boolean
    Private mstrArchivo As String

    Private mlngAbonoCap As Long
    Private mlngCargoCap As Long
    Private mlngCargoCapVyT As Long
    Private mlngCargoCapCompl As Long
    Private mlngCargoCapParcial As Long
    Private mlngSaldoCap As Long
    Private mlngAbonoRep As Long
    Private mlngCargoRep As Long
    Private mlngCargoRepVyT As Long
    Private mlngCargoRepCompl As Long
    Private mlngCargoRepParcial As Long
    Private mlngSaldoRep As Long
    Private mlngAbonoAdm As Long
    Private mlngCargoAdm As Long
    Private mlngCargoAdmVyT As Long
    Private mlngCargoAdmCompl As Long
    Private mlngCargoAdmParcial As Long
    Private mlngSaldoAdm As Long
    Private mlngAbonoExCap As Long
    Private mlngCargoExCap As Long
    Private mlngCargoExCapVyT As Long
    Private mlngCargoExCapCompl As Long
    Private mlngCargoExCapParcial As Long
    Private mlngSaldoExCap As Long
    Private mlngAbonoExRep As Long
    Private mlngCargoExRep As Long
    Private mlngCargoExRepVyT As Long
    Private mlngCargoExRepCompl As Long
    Private mlngCargoExRepParcial As Long
    Private mlngSaldoExRep As Long
    Private mlngDeuda As Long
    Private mlngSaldoEx As Long

    Dim objReporte As CReporteResumen

    Private mobjSql As New CSql
#Region "set y get"
    Public Property AbonoCap() As Long
        Get
            Return mlngAbonoCap
        End Get
        Set(ByVal value As Long)
            mlngAbonoCap = value
        End Set
    End Property
    Public Property CargoCap() As Long
        Get
            Return mlngCargoCap
        End Get
        Set(ByVal value As Long)
            mlngCargoCap = value
        End Set
    End Property
    Public Property CargoCapVyT() As Long
        Get
            Return mlngCargoCapVyT
        End Get
        Set(ByVal value As Long)
            mlngCargoCapVyT = value
        End Set
    End Property
    Public Property CargoCapCompl() As Long
        Get
            Return mlngCargoCapCompl
        End Get
        Set(ByVal value As Long)
            mlngCargoCapCompl = value
        End Set
    End Property
    Public Property CargoCapParcial() As Long
        Get
            Return mlngCargoCapParcial
        End Get
        Set(ByVal value As Long)
            mlngCargoCapParcial = value
        End Set
    End Property
    Public Property SaldoCap() As Long
        Get
            Return mlngSaldoCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoCap = value
        End Set
    End Property
    Public Property AbonoRep() As Long
        Get
            Return mlngAbonoRep
        End Get
        Set(ByVal value As Long)
            mlngAbonoRep = value
        End Set
    End Property
    Public Property CargoRep() As Long
        Get
            Return mlngCargoRep
        End Get
        Set(ByVal value As Long)
            mlngCargoRep = value
        End Set
    End Property
    Public Property CargoRepVyT() As Long
        Get
            Return mlngCargoRepVyT
        End Get
        Set(ByVal value As Long)
            mlngCargoRepVyT = value
        End Set
    End Property
    Public Property CargoRepCompl() As Long
        Get
            Return mlngCargoRepCompl
        End Get
        Set(ByVal value As Long)
            mlngCargoRepCompl = value
        End Set
    End Property
    Public Property CargoRepParcial() As Long
        Get
            Return mlngCargoRepParcial
        End Get
        Set(ByVal value As Long)
            mlngCargoRepParcial = value
        End Set
    End Property
    Public Property SaldoRep() As Long
        Get
            Return mlngSaldoRep
        End Get
        Set(ByVal value As Long)
            mlngSaldoRep = value
        End Set
    End Property
    Public Property AbonoAdm() As Long
        Get
            Return mlngAbonoAdm
        End Get
        Set(ByVal value As Long)
            mlngAbonoAdm = value
        End Set
    End Property
    Public Property CargoAdm() As Long
        Get
            Return mlngCargoAdm
        End Get
        Set(ByVal value As Long)
            mlngCargoAdm = value
        End Set
    End Property

    Public Property CargoAdmVyT() As Long
        Get
            Return mlngCargoAdmVyT
        End Get
        Set(ByVal value As Long)
            mlngCargoAdmVyT = value
        End Set
    End Property

    Public Property CargoAdmCompl() As Long
        Get
            Return mlngCargoAdmCompl
        End Get
        Set(ByVal value As Long)
            mlngCargoAdmCompl = value
        End Set
    End Property
    Public Property CargoAdmParcial() As Long
        Get
            Return mlngCargoAdmParcial
        End Get
        Set(ByVal value As Long)
            mlngCargoAdmParcial = value
        End Set
    End Property
    Public Property SaldoAdm() As Long
        Get
            Return mlngSaldoAdm
        End Get
        Set(ByVal value As Long)
            mlngSaldoAdm = value
        End Set
    End Property
    Public Property AbonoExCap() As Long
        Get
            Return mlngAbonoExCap
        End Get
        Set(ByVal value As Long)
            mlngAbonoExCap = value
        End Set
    End Property
    Public Property CargoExCap() As Long
        Get
            Return mlngCargoExCap
        End Get
        Set(ByVal value As Long)
            mlngCargoExCap = value
        End Set
    End Property
    Public Property CargoExCapVyT() As Long
        Get
            Return mlngCargoExCapVyT
        End Get
        Set(ByVal value As Long)
            mlngCargoExCapVyT = value
        End Set
    End Property
    Public Property CargoExCapCompl() As Long
        Get
            Return mlngCargoExCapCompl
        End Get
        Set(ByVal value As Long)
            mlngCargoExCapCompl = value
        End Set
    End Property
    Public Property CargoExCapParcial() As Long
        Get
            Return mlngCargoExCapParcial
        End Get
        Set(ByVal value As Long)
            mlngCargoExCapParcial = value
        End Set
    End Property
    Public Property SaldoExCap() As Long
        Get
            Return mlngSaldoExCap
        End Get
        Set(ByVal value As Long)
            mlngSaldoExCap = value
        End Set
    End Property
    Public Property AbonoExRep() As Long
        Get
            Return mlngAbonoExRep
        End Get
        Set(ByVal value As Long)
            mlngAbonoExRep = value
        End Set
    End Property
    Public Property CargoExRep() As Long
        Get
            Return mlngCargoExRep
        End Get
        Set(ByVal value As Long)
            mlngCargoExRep = value
        End Set
    End Property
    Public Property CargoExRepVyT() As Long
        Get
            Return mlngCargoExRepVyT
        End Get
        Set(ByVal value As Long)
            mlngCargoExRepVyT = value
        End Set
    End Property
    Public Property CargoExRepCompl() As Long
        Get
            Return mlngCargoExRepCompl
        End Get
        Set(ByVal value As Long)
            mlngCargoExRepCompl = value
        End Set
    End Property
    Public Property CargoExRepParcial() As Long
        Get
            Return mlngCargoExRepParcial
        End Get
        Set(ByVal value As Long)
            mlngCargoExRepParcial = value
        End Set
    End Property
    Public Property SaldoExRep() As Long
        Get
            Return mlngSaldoExRep
        End Get
        Set(ByVal value As Long)
            mlngSaldoExRep = value
        End Set
    End Property
    Public Property Deuda() As Long
        Get
            Return mlngDeuda
        End Get
        Set(ByVal value As Long)
            mlngDeuda = value
        End Set
    End Property
    Public Property SaldoEx() As Long
        Get
            Return mlngSaldoEx
        End Get
        Set(ByVal value As Long)
            mlngSaldoEx = value
        End Set
    End Property
    Public ReadOnly Property ArchivoXml() As String

        Get
            Return Me.mstrXml
        End Get
    End Property

    Public Property BajarXml() As Boolean

        Get
            Return mblnBajarXml
        End Get
        Set(ByVal value As Boolean)
            mblnBajarXml = value
        End Set
    End Property

    Public ReadOnly Property Filas() As Integer
        Get
            Return mlngFilas
        End Get
    End Property
   
#End Region
   
#Region "set y get"
    Public Property RutCliente() As Long
        Get
            Return mlngRutCliente
        End Get
        Set(ByVal value As Long)
            mlngRutCliente = value
        End Set
    End Property
    Public Property NombreCliente() As String
        Get
            Return mstrNombreCliente
        End Get
        Set(ByVal value As String)
            mstrNombreCliente = value
        End Set
    End Property
    Public Property FechaInicio() As Date
        Get
            Return mdtmFechaIni
        End Get
        Set(ByVal value As Date)
            mdtmFechaIni = value
        End Set
    End Property
    Public Property FechaFin() As Date
        Get
            Return mdtmFechaFin
        End Get
        Set(ByVal value As Date)
            mdtmFechaFin = value
        End Set
    End Property

    Public Property FonoContacto() As String
        Get
            Return mdtFonoContacto
        End Get
        Set(ByVal value As String)
            mdtFonoContacto = value
        End Set
    End Property

    Public Property AnexoContacto() As String
        Get
            Return mintAnexoContacto
        End Get
        Set(ByVal value As String)
            mintAnexoContacto = value
        End Set
    End Property

    Public Property NombreEjecutivo() As String
        Get
            Return mstrNombreEjecutivo
        End Get
        Set(ByVal value As String)
            mstrNombreEjecutivo = value
        End Set
    End Property
    Public Property Sucursal() As String
        Get
            Return mstrSucursal
        End Get
        Set(ByVal value As String)
            mstrSucursal = value
        End Set
    End Property
     Public Property Franquicia() As long 
        Get
            Return mlngFranquicia
        End Get
        Set(ByVal value As Long)
            mlngFranquicia = value
        End Set
    End Property

    'Public Property Filas() As Integer
    '    Get
    '        Return mdtFilas
    '    End Get
    '    Set(ByVal value As Integer)
    '        mdtFilas = value
    '    End Set
    'End Property
    Public ReadOnly Property Filiales() As DataTable
        Get
            Return mdtFiliales
        End Get
    End Property
#End Region

    Public Function consultar() As DataTable
  
        Try
            Dim dtNuevo As New DataTable
            Dim dt As New DataTable
            Dim strNombreArchivo As String
            'Dim dtConsultaFiliales As DataTable

            dt = mobjSql.s_reporte_cobranza(mlngRutCliente, mstrNombreCliente, mdtmFechaIni, mdtmFechaFin)
            Me.mlngFilas = Me.mobjSql.Registros

            If Me.mlngFilas > 0 Then

                dtNuevo.Columns.Add("rut_cliente")
                dtNuevo.Columns.Add("razon_social")
                dtNuevo.Columns.Add("nom_contacto")
                dtNuevo.Columns.Add("fono_contacto")
                dtNuevo.Columns.Add("Nom_ejecutivo")
                dtNuevo.Columns.Add("Sucursal")
                'dtNuevo.Columns.Add("dig_verif")
                dtNuevo.Columns.Add("costo_admin")
                'dtNuevo.Columns.Add("adm")
                'Cuenta Capacitacion
                dtNuevo.Columns.Add("AbonoCap")
                dtNuevo.Columns.Add("CargoCap")
                dtNuevo.Columns.Add("CargoCapVyT")
                dtNuevo.Columns.Add("CargoCapCompl")
                dtNuevo.Columns.Add("CargoCapParcial")
                dtNuevo.Columns.Add("SaldoCap")
                'Cuenta de reparto
                dtNuevo.Columns.Add("AbonoRep")
                dtNuevo.Columns.Add("CargoRep")
                dtNuevo.Columns.Add("CargoRepVyT")
                dtNuevo.Columns.Add("CargoRepCompl")
                dtNuevo.Columns.Add("CargoRepParcial")
                dtNuevo.Columns.Add("SaldoRep")
                'Cuenta de Administracion
                dtNuevo.Columns.Add("AbonoAdm")
                dtNuevo.Columns.Add("CargoAdm")
                dtNuevo.Columns.Add("CargoAdmVyT")
                dtNuevo.Columns.Add("CargoAdmCompl")
                dtNuevo.Columns.Add("CargoAdmParcial")
                dtNuevo.Columns.Add("SaldoAdm")
                'Cuenta de excedentes de cap
                dtNuevo.Columns.Add("AbonoExCap")
                dtNuevo.Columns.Add("CargoExCap")
                dtNuevo.Columns.Add("CargoExCapVyT")
                dtNuevo.Columns.Add("CargoExCapCompl")
                dtNuevo.Columns.Add("CargoExCapParcial")
                dtNuevo.Columns.Add("SaldoExCap")
                'Cuenta de Excedentes de reparto
                dtNuevo.Columns.Add("AbonoExRep")
                dtNuevo.Columns.Add("CargoExRep")
                dtNuevo.Columns.Add("CargoExRepVyT")
                dtNuevo.Columns.Add("CargoExRepCompl")
                dtNuevo.Columns.Add("CargoExRepParcial")
                dtNuevo.Columns.Add("SaldoExRep")
                'Cuenta de becas
                dtNuevo.Columns.Add("AbonoAporteBeca")
                dtNuevo.Columns.Add("AbonoMandatoBeca")
                dtNuevo.Columns.Add("SaldoBeca")

                dtNuevo.Columns.Add("Deuda")
                dtNuevo.Columns.Add("SaldoEx")

                'Dim drConsulta As DataRow
                Dim i As Integer = 0
                Dim j As Integer = 0
                Dim strRutTmp As String = ""
                For i = 0 To mlngFilas - 1
                    Dim salir As Integer = 0
                    Dim dr As DataRow
                    dr = dtNuevo.NewRow

                    strRutTmp = dt.Rows(i).Item(0)
                    dr("rut_cliente") = dt.Rows(i).Item(0)
                    dr("razon_social") = dt.Rows(i).Item("razon_social")

                    If IsDBNull(dt.Rows(i).Item(5)) Then
                        dr("nom_contacto") = " "
                    Else
                        dr("nom_contacto") = dt.Rows(i).Item(5)
                    End If
                    If IsDBNull(dt.Rows(i).Item(6)) Then
                        dr("fono_contacto") = " "
                    Else
                        dr("fono_contacto") = dt.Rows(i).Item(6)
                    End If
                    If IsDBNull(dt.Rows(i).Item(8)) Then
                        dr("Nom_ejecutivo") = " "
                    Else
                        dr("Nom_ejecutivo") = dt.Rows(i).Item(8)
                    End If
                    If IsDBNull(dt.Rows(i).Item(9)) Then
                        dr("Sucursal") = " "
                    Else
                        dr("Sucursal") = dt.Rows(i).Item(9)
                    End If
                    'If IsDBNull(dt.Rows(i).Item(13)) Then
                    '    dr("dig_verif") = " "
                    'Else
                    '    dr("dig_verif") = dt.Rows(i).Item(13)
                    'End If
                    If IsDBNull(dt.Rows(i).Item(13)) Then
                        dr("costo_admin") = " "
                    Else
                        dr("costo_admin") = (dt.Rows(i).Item(13) / 100)
                    End If
                    
                    
                    'dtNuevo.Rows(i).Item("adm") = dt.Rows(i).Item()

                    'Cuenta Capacitacion
                    dr("AbonoCap") = 0
                    dr("CargoCap") = 0
                    dr("CargoCapCompl") = 0
                    dr("CargoCapParcial") = 0
                    dr("CargoCapVyT") = 0
                    'Cuenta de reparto
                    dr("AbonoRep") = 0
                    dr("CargoRep") = 0
                    dr("CargoRepVyT") = 0
                    dr("CargoRepCompl") = 0
                    dr("CargoRepParcial") = 0
                    dr("SaldoRep") = 0
                    'Cuenta de Administracion
                    dr("AbonoAdm") = 0
                    dr("CargoAdm") = 0
                    dr("CargoAdmVyT") = 0
                    dr("CargoAdmCompl") = 0
                    dr("CargoAdmParcial") = 0
                    dr("SaldoAdm") = 0
                    'Cuenta de excedentes de cap
                    dr("AbonoExCap") = 0
                    dr("CargoExCap") = 0
                    dr("CargoExCapVyT") = 0
                    dr("CargoExCapCompl") = 0
                    dr("CargoExCapParcial") = 0
                    dr("SaldoExCap") = 0
                    dr("AbonoExRep") = 0
                    'Cuenta de Excedentes de reparto
                    dr("AbonoExRep") = 0
                    dr("CargoExRep") = 0
                    dr("CargoExRepVyT") = 0
                    dr("CargoExRepCompl") = 0
                    dr("CargoExRepParcial") = 0
                    dr("SaldoExRep") = 0
                    'cuenta becas
                    dr("AbonoAporteBeca") = 0
                    dr("AbonoMandatoBeca") = 0
                    dr("SaldoBeca") = 0

                    dr("Deuda") = 0
                    dr("SaldoEx") = 0

                    Do
                        'Cuenta Capacitacion
                        If (dt.Rows(i).Item(1) = 1) Then
                            If (dt.Rows(i).Item(2) = 1) Or (dt.Rows(i).Item(2) = 3) Then
                                dr("AbonoCap") = dr("AbonoCap") + dt.Rows(i).Item(3)
                            ElseIf (dt.Rows(i).Item(2) = 2) Or (dt.Rows(i).Item(2) = 5) Then
                                dr("CargoCap") = dr("CargoCap") + dt.Rows(i).Item(3)
                                'dr("CargoCapCompl") = dr("CargoCapCompl") + (dr("CargoCap") + dt.Rows(i).Item("gasto_curso_complementario"))
                                dr("CargoCapCompl") = dr("CargoCapCompl") + dt.Rows(i).Item("gasto_curso_complementario")
                                dr("CargoCapParcial") = dr("CargoCapParcial") + dt.Rows(i).Item("gasto_curso_parcial")
                                'solo VyT
                                If (dt.Rows(i).Item(2) = 5) Then
                                    dr("CargoCapVyT") = dr("CargoCapVyT") + dt.Rows(i).Item(3)
                                End If
                            End If
                        End If
                        'Cuenta de reparto
                        If (dt.Rows(i).Item(1) = 2) Then
                            If (dt.Rows(i).Item(2) = 1) Or (dt.Rows(i).Item(2) = 3) Then
                                dr("AbonoRep") = dr("AbonoRep") + dt.Rows(i).Item(3)
                            ElseIf (dt.Rows(i).Item(2) = 2) Or (dt.Rows(i).Item(2) = 5) Then
                                dr("CargoRep") = dr("CargoRep") + dt.Rows(i).Item(3)
                                dr("CargoRepCompl") = dr("CargoRepCompl") + dt.Rows(i).Item("gasto_curso_complementario")
                                dr("CargoRepParcial") = dr("CargoRepParcial") + dt.Rows(i).Item("gasto_curso_parcial")
                                If (dt.Rows(i).Item(2) = 5) Then
                                    dr("CargoRepVyT") = dr("CargoRepVyT") + dt.Rows(i).Item(3)
                                End If
                            End If
                        End If
                        'Cuenta de Administracion
                        If (dt.Rows(i).Item(1) = 3) Then
                            If (dt.Rows(i).Item(2) = 1) Or (dt.Rows(i).Item(2) = 3) Then
                                dr("AbonoAdm") = dr("AbonoAdm") + dt.Rows(i).Item(3)
                            ElseIf (dt.Rows(i).Item(2) = 2) Or (dt.Rows(i).Item(2) = 5) Then
                                dr("CargoAdm") = dr("CargoAdm") + dt.Rows(i).Item(3)
                                dr("CargoAdmCompl") = dr("CargoAdmCompl") + dt.Rows(i).Item("gasto_curso_complementario")
                                dr("CargoAdmParcial") = dr("CargoAdmParcial") + dt.Rows(i).Item("gasto_curso_parcial")
                                If (dt.Rows(i).Item(2) = 5) Then
                                    dr("CargoAdmVyT") = dr("CargoAdmVyT") + dt.Rows(i).Item(3)
                                End If
                            End If
                        End If
                        'Cuenta de excedentes de cap
                        If (dt.Rows(i).Item(1) = 4) Then
                            If (dt.Rows(i).Item(2) = 1) Or (dt.Rows(i).Item(2) = 3) Then
                                dr("AbonoExCap") = dr("AbonoExCap") + dt.Rows(i).Item(3)
                            ElseIf (dt.Rows(i).Item(2) = 2) Or (dt.Rows(i).Item(2) = 5) Then
                                dr("CargoExCap") = dr("CargoExCap") + dt.Rows(i).Item(3)
                                dr("CargoExCapCompl") = dr("CargoExCapCompl") + dt.Rows(i).Item("gasto_curso_complementario")
                                dr("CargoExCapParcial") = dr("CargoExCapParcial") + dt.Rows(i).Item("gasto_curso_parcial")
                                If (dt.Rows(i).Item(2) = 5) Then
                                    dr("CargoExCapVyT") = dr("CargoExCapVyT") + dt.Rows(i).Item(3)
                                End If
                            ElseIf (dt.Rows(i).Item(2) = 4) Then
                                dr("AbonoExCap") = dr("AbonoExCap") + dt.Rows(i).Item(3)
                            End If
                        End If
                        'Cuenta de Excedentes de reparto
                        If (dt.Rows(i).Item(1) = 5) Then
                            If (dt.Rows(i).Item(2) = 1) Or (dt.Rows(i).Item(2) = 3) Then
                                dr("AbonoExRep") = dr("AbonoExRep") + dt.Rows(i).Item(3)
                            ElseIf (dt.Rows(i).Item(2) = 2) Or (dt.Rows(i).Item(2) = 5) Then
                                dr("CargoExRep") = dr("CargoExRep") + dt.Rows(i).Item(3)
                                dr("CargoExRepCompl") = dr("CargoExRepCompl") + dt.Rows(i).Item("gasto_curso_complementario")
                                dr("CargoExRepParcial") = dr("CargoExRepParcial") + dt.Rows(i).Item("gasto_curso_parcial")
                                If (dt.Rows(i).Item(2) = 5) Then
                                    dr("CargoExRepVyT") = dr("CargoExRepVyT") + dt.Rows(i).Item(3)
                                End If
                            ElseIf (dt.Rows(i).Item(2) = 4) Then
                                dr("AbonoExRep") = dr("AbonoExRep") + dt.Rows(i).Item(3)
                            End If
                        End If

                        'Cuenta de becas
                        If (dt.Rows(i).Item(1) = 6) Then
                            If (dt.Rows(i).Item(2) = 3) Then
                                dr("AbonoAporteBeca") = dr("AbonoAporteBeca") + dt.Rows(i).Item(3)
                            ElseIf (dt.Rows(i).Item(2) = 4) Then
                                dr("AbonoMandatoBeca") = dr("AbonoMandatoBeca") + dt.Rows(i).Item(3)
                            End If
                        End If

                        i = i + 1
                        If Not i = mlngFilas Then
                            If strRutTmp <> dt.Rows(i).Item(0) Then
                                salir = 1
                                i = i - 1
                            End If
                        Else
                            salir = 1
                        End If

                    Loop While salir = 0

                    dr("SaldoCap") = (CLng(dr("AbonoCap")) - CLng(dr("CargoCap")))
                    dr("SaldoRep") = (CLng(dr("AbonoRep")) - CLng(dr("CargoRep")))
                    dr("SaldoAdm") = (CLng(dr("AbonoAdm")) - CLng(dr("CargoAdm")))
                    dr("SaldoExCap") = (CLng(dr("AbonoExCap")) - CLng(dr("CargoExCap")))
                    dr("SaldoExRep") = (CLng(dr("AbonoExRep")) - CLng(dr("CargoExRep")))
                    dr("SaldoBeca") = (CLng(dr("AbonoAporteBeca")) + CLng(dr("AbonoMandatoBeca")))

                    dr("SaldoEx") = (CLng(dr("SaldoExCap")) + CLng(dr("SaldoExRep")))

                    dr("Deuda") = (CLng(dr("SaldoCap")) + CLng(dr("SaldoRep"))) + CLng(dr("SaldoAdm"))

                    ' '' '' '' ''*********validacion vyt

                    Dim dblPorcAdm As Double = 0.0
                    dblPorcAdm = (100 - (dr("costo_admin") * 100)) / 100
                    Dim lngDeudaConVyt As Long = 0

                    If CLng(dr("CargoCapVyT")) > (CLng(dr("AbonoCap")) + CLng(dr("AbonoRep"))) * 0.10000000000000001 Then
                        dblPorcAdm = (100 - (dr("costo_admin") * 100)) / 100

                        'Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal + ((objReporte.CCvtCursosPropios - objReporte.CCvtDisponible) / dblPorcAdm) * 10)
                        lngDeudaConVyt = ((CLng(dr("CargoCapVyT")) - (CLng(dr("AbonoCap") * 0.10000000000000001))) / dblPorcAdm) * 10
                        'Me.lblAPEcapacitacion.Text = FormatoMonto(objReporte.APEcapacitacion + Me.lblAPETotal.Text)
                        'dr("Deuda") = FormatoMonto(objReporte.APEcapacitacion)
                    Else
                        dr("Deuda") = (CLng(dr("SaldoCap")) + CLng(dr("SaldoRep"))) + CLng(dr("SaldoAdm"))
                    End If
                    'Me.lblAPETotal.Text = FormatoMonto(objReporte.APEtotal)

                    If CLng(dr("CargoCap")) = CLng(dr("CargoCapVyT")) Then
                        dr("Deuda") = -lngDeudaConVyt
                    Else
                        If CLng(dr("CargoCap")) > (CLng(dr("CargoCapVyT")) * 10) And CLng(dr("CargoCapVyT")) > 0 Then
                            'dblPorcAdm = (100 - objReporte.CostoAdministracion) / 100
                            dr("Deuda") = (CLng(dr("CargoCap")) / dblPorcAdm) - (CLng(dr("AbonoCap")) + CLng(dr("AbonoAdm")))
                            If dr("Deuda") = "Infinito" Then
                                dr("Deuda") = 0
                            End If
                            If dr("Deuda") < 0 Then
                                dr("Deuda") = 0
                            End If
                            If (CLng(dr("SaldoCap")) + CLng(dr("SaldoRep"))) + CLng(dr("SaldoAdm")) < 0 Then
                                dr("Deuda") = -dr("Deuda")
                            End If


                        Else
                            If CLng(dr("CargoCapVyT")) > (CLng(dr("AbonoCap") * 0.1)) Then
                                dr("Deuda") = -lngDeudaConVyt
                            Else
                                dr("Deuda") = (CLng(dr("SaldoCap")) + CLng(dr("SaldoRep")) + CLng(dr("SaldoAdm")) + lngDeudaConVyt)

                            End If
                        End If


                    End If


                    dtNuevo.Rows.Add(dr)
                Next

                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtNuevo.TableName = "Reporte de Alumnos"
                    ConvierteDTaCSV(dtNuevo, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If

            End If
            Return dtNuevo
        Catch ex As Exception
            EnviaError("CResumenCobranza.vd:Consultar->" & ex.Message)
        End Try
    End Function

End Class
