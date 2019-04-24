Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Public Class CReporteResumenCliente
    Implements IReporte
    Private mstrXml As String
    Private mblnBajarXml As Boolean
    Private mintFilas As Integer
    'rut del cliente
    Private mlngRutCliente As Long
    'Nombre del cliente
    Private mstrNombreCliente As String
    'Fecha inicio a considerar en las transacciones
    Private mdtmFechaIni As Date
    'Fecha fin a considerar para las transacciones
    Private mdtmFechaFin As Date
    Private mintAgno As Integer
    'Etiquetas para el archivo
    Private mdtEtiquetas As DataTable
    Private mdtTablaFinal As DataTable

    Private mobjSql As CSql

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
    Public Property FechaIni() As Date
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
    Public Property Agno() As Integer
        Get
            Return mintAgno
        End Get
        Set(ByVal value As Integer)
            mintAgno = value
        End Set
    End Property
    Public Property Etiquetas() As DataTable
        Get
            Return mdtEtiquetas
        End Get
        Set(ByVal value As DataTable)
            mdtEtiquetas = value
        End Set
    End Property
    Public Property TablaFinal() As DataTable
        Get
            Return mdtTablaFinal
        End Get
        Set(ByVal value As DataTable)
            mdtTablaFinal = value
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

    Public Function Consultar1() As System.Data.DataTable Implements Clases.IReporte.Consultar

    End Function

    Public ReadOnly Property Filas() As Integer Implements Clases.IReporte.Filas
        Get
            Return mintFilas
        End Get
    End Property
    Public Function Consultar() As DataTable
        Try
            Dim strNombreArchivo As String
            Dim dtConsulta As DataTable
            Dim dtNuevo As New DataTable
            mobjSql = New CSql
            'i->contador de arrreporte, j->contador de la consulta
            'Dim i As Integer ', intFilas As Integer, j As Integer, k As Integer, salir As Integer
            'Dim lngRutTemp As Long
            'Dim AbonoAdm, CargoAdm, AbonoExCap, CargoExCap, AbonoExRep, CargoExRep As Long
            dtConsulta = mobjSql.s_resumen_cliente(mlngRutCliente, mstrNombreCliente, mintAgno)
            mintFilas = mobjSql.Registros
            dtConsulta.Columns.Add("DV")
            If mintFilas > 0 Then
                dtNuevo.Columns.Add("rut_cliente")
                dtNuevo.Columns.Add("cod_cuenta")
                dtNuevo.Columns.Add("cod_tipo_tran")
                dtNuevo.Columns.Add("monto")
                dtNuevo.Columns.Add("razon_social")
                dtNuevo.Columns.Add("nom_contacto")
                dtNuevo.Columns.Add("fono_contacto")
                dtNuevo.Columns.Add("anexo_contacto")
                dtNuevo.Columns.Add("nombres")
                dtNuevo.Columns.Add("nombre")
                dtNuevo.Columns.Add("horas")
                dtNuevo.Columns.Add("hh")
                dtNuevo.Columns.Add("cant_part")

                dtNuevo.Columns.Add("abono_adm")
                dtNuevo.Columns.Add("cargo_adm")
                dtNuevo.Columns.Add("abono_ex_cap")
                dtNuevo.Columns.Add("cargo_ex_cap")
                dtNuevo.Columns.Add("abono_ex_rep")
                dtNuevo.Columns.Add("cargo_ex_rep")
                dtNuevo.Columns.Add("abono_cap")
                dtNuevo.Columns.Add("cargo_cap")
                dtNuevo.Columns.Add("saldo_cap")
                dtNuevo.Columns.Add("abono_rep")
                dtNuevo.Columns.Add("cargo_rep")
                dtNuevo.Columns.Add("saldo_rep")
                dtNuevo.Columns.Add("saldo_adm")
                dtNuevo.Columns.Add("saldo_ex_cap")
                dtNuevo.Columns.Add("saldo_ex_rep")
                dtNuevo.Columns.Add("saldo_ex")
                dtNuevo.Columns.Add("tras_fondos_cap")
                dtNuevo.Columns.Add("tras_fondos_rep")
                dtNuevo.Columns.Add("tras_fondos_adm")
                dtNuevo.Columns.Add("tras_fondos_ex_cap")
                dtNuevo.Columns.Add("tras_fondos_ex_rep")
                Dim i As Integer = 0
                Dim j As Integer = 0
                Dim strRutTmp As String = ""
                For i = 0 To mintFilas - 1
                    Dim salir As Integer = 0
                    Dim dr As DataRow
                    dr = dtNuevo.NewRow

                    strRutTmp = dtConsulta.Rows(i).Item(0)
                    dr("rut_cliente") = RutLngAUsr(dtConsulta.Rows(i).Item(0))
                    dr("razon_social") = dtConsulta.Rows(i).Item("razon_social")

                    If IsDBNull(dtConsulta.Rows(i).Item(5)) Then
                        dr("nom_contacto") = " "
                    Else
                        dr("nom_contacto") = dtConsulta.Rows(i).Item(5)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(6)) Then
                        dr("fono_contacto") = " "
                    Else
                        dr("fono_contacto") = dtConsulta.Rows(i).Item(6)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(7)) Then
                        dr("anexo_contacto") = " "
                    Else
                        dr("anexo_contacto") = dtConsulta.Rows(i).Item(7)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(8)) Then
                        dr("nombres") = " "
                    Else
                        dr("nombres") = dtConsulta.Rows(i).Item(8)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(9)) Then
                        dr("nombre") = " "
                    Else
                        dr("nombre") = dtConsulta.Rows(i).Item(9)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(10)) Then
                        dr("horas") = " "
                    Else
                        dr("horas") = dtConsulta.Rows(i).Item(10)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(11)) Then
                        dr("hh") = " "
                    Else
                        dr("hh") = dtConsulta.Rows(i).Item(11)
                    End If
                    If IsDBNull(dtConsulta.Rows(i).Item(12)) Then
                        dr("cant_part") = " "
                    Else
                        dr("cant_part") = dtConsulta.Rows(i).Item(12)
                    End If
                    dr("abono_cap") = 0
                    dr("cargo_cap") = 0
                    dr("tras_fondos_cap") = 0
                    dr("tras_fondos_cap") = 0
                    dr("abono_rep") = 0
                    dr("cargo_rep") = 0
                    dr("tras_fondos_rep") = 0
                    dr("abono_adm") = 0
                    dr("cargo_adm") = 0
                    dr("tras_fondos_adm") = 0
                    dr("abono_ex_cap") = 0
                    dr("cargo_ex_cap") = 0
                    dr("tras_fondos_ex_cap") = 0
                    dr("abono_ex_rep") = 0
                    dr("cargo_ex_rep") = 0
                    dr("tras_fondos_ex_rep") = 0
                    dr("saldo_cap") = 0
                    dr("saldo_rep") = 0
                    dr("saldo_adm") = 0
                    dr("saldo_ex_cap") = 0
                    dr("saldo_ex_rep") = 0
                    dr("saldo_ex") = 0

                    Do
                        dtConsulta.Rows(i).Item(13) = digito_verificador(strRutTmp)
                        'Cuenta Capacitacion
                        If CInt(dtConsulta.Rows(i).Item(1)) = 1 Then
                            'Aportes o ingreso de excedentes
                            If CInt(dtConsulta.Rows(i).Item(2) = 1) Or CInt(dtConsulta.Rows(i).Item(2) = 3) Then
                                dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Cargos por curso o VYT
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 2) Or CInt(dtConsulta.Rows(i).Item(2) = 5) Then
                                dr("cargo_cap") = dr("cargo_cap") + CLng(dtConsulta.Rows(i).Item(3))
                                'Traspasos de fondos
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 4) Then
                                dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dtConsulta.Rows(i).Item(3))
                            End If
                            'se contabilizan los traspasos de fondos
                        End If

                        'Cuenta de reparto
                        If CInt(dtConsulta.Rows(i).Item(1)) = 2 Then
                            'Aportes o ingreso de excedentes
                            If CInt(dtConsulta.Rows(i).Item(2) = 1) Or CInt(dtConsulta.Rows(i).Item(2) = 3) Then
                                dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Cargos por curso o VYT
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 2) Or CInt(dtConsulta.Rows(i).Item(2) = 5) Then
                                dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Traspasos de fondos
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 4) Then
                                dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dtConsulta.Rows(i).Item(3))
                            End If
                        End If

                        'Cuenta de Administracion
                        If CInt(dtConsulta.Rows(i).Item(1)) = 3 Then
                            'Aportes o ingreso de excedentes
                            If CInt(dtConsulta.Rows(i).Item(2) = 1) Or CInt(dtConsulta.Rows(i).Item(2) = 3) Then
                                dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Cargos por curso o VYT
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 2) Or CInt(dtConsulta.Rows(i).Item(2) = 5) Then
                                dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Traspasos de fondos
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 4) Then
                                dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dtConsulta.Rows(i).Item(3))
                            End If
                        End If

                        'Cuenta de excedentes de rep
                        If CInt(dtConsulta.Rows(i).Item(1)) = 5 Then
                            'Aportes o ingreso de excedentes
                            If CInt(dtConsulta.Rows(i).Item(2) = 1) Or CInt(dtConsulta.Rows(i).Item(2) = 3) Then
                                dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Cargos por curso o VYT
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 2) Or CInt(dtConsulta.Rows(i).Item(2) = 5) Then
                                dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Traspasos de fondos
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 4) Then
                                dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dtConsulta.Rows(i).Item(3))
                            End If
                        End If

                        'Cuenta de excedentes de cap
                        If CInt(dtConsulta.Rows(i).Item(1)) = 4 Then
                            'Aportes o ingreso de excedentes
                            If CInt(dtConsulta.Rows(i).Item(2) = 1) Or CInt(dtConsulta.Rows(i).Item(2) = 3) Then
                                dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Cargos por curso o VYT
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 2) Or CInt(dtConsulta.Rows(i).Item(2) = 5) Then
                                dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dtConsulta.Rows(i).Item(3))
                                'Traspasos de fondos
                            ElseIf CInt(dtConsulta.Rows(i).Item(2) = 4) Then
                                dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dtConsulta.Rows(i).Item(3))
                            End If
                        End If

                        i = i + 1
                        If Not i = mintFilas Then
                            If strRutTmp <> dtConsulta.Rows(i).Item(j) Then
                                salir = 1
                                i = i - 1
                            End If
                        Else
                            salir = 1
                        End If

                    Loop While salir = 0

                    dr("saldo_cap") = (CLng(dr("abono_cap")) - CLng(dr("cargo_cap"))) + CLng(dr("tras_fondos_cap"))
                    dr("saldo_rep") = (CLng(dr("abono_rep")) - CLng(dr("cargo_rep"))) + CLng(dr("tras_fondos_rep"))
                    dr("saldo_adm") = (CLng(dr("abono_adm")) - CLng(dr("cargo_adm"))) + CLng(dr("tras_fondos_adm"))
                    dr("saldo_ex_cap") = (CLng(dr("abono_ex_cap")) - CLng(dr("cargo_ex_cap"))) + CLng(dr("tras_fondos_ex_cap"))
                    dr("saldo_ex_rep") = (CLng(dr("abono_ex_rep")) - CLng(dr("cargo_ex_rep"))) + CLng(dr("tras_fondos_ex_rep"))
                    dr("saldo_ex") = CLng(dr("saldo_ex_cap")) + CLng(dr("saldo_ex_rep"))
                    dtNuevo.Rows.Add(dr)
                Next
                dtConsulta.Columns(13).SetOrdinal(1)
                If Me.mblnBajarXml Then
                    strNombreArchivo = NombreArchivoTmp("csv")
                    dtConsulta.TableName = "Reporte Cursos"
                    ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
                    Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
                End If

            End If

            Return dtNuevo

        Catch ex As Exception
            EnviaError("CReporteResumenCliente.vb:Consultar-->" & ex.Message)
        End Try

    End Function

    'Public Function Consultar() As DataTable
    '    Try
    '        Dim strNombreArchivo As String
    '        Dim dtConsulta As DataTable
    '        Dim dtNuevo As DataTable
    '        mobjSql = New CSql
    '        'i->contador de arrreporte, j->contador de la consulta
    '        Dim i As Integer ', intFilas As Integer, j As Integer, k As Integer, salir As Integer
    '        'Dim lngRutTemp As Long
    '        'Dim AbonoAdm, CargoAdm, AbonoExCap, CargoExCap, AbonoExRep, CargoExRep As Long
    '        dtConsulta = mobjSql.s_resumen_cliente2(mlngRutCliente, mstrNombreCliente, mintAgno)
    '        mintFilas = mobjSql.Registros
    '        If mintFilas > 0 Then
    '            dtConsulta.Columns.Add("abono_adm")
    '            dtConsulta.Columns.Add("cargo_adm")
    '            dtConsulta.Columns.Add("abono_ex_cap")
    '            dtConsulta.Columns.Add("cargo_ex_cap")
    '            dtConsulta.Columns.Add("abono_ex_rep")
    '            dtConsulta.Columns.Add("cargo_ex_rep")
    '            dtConsulta.Columns.Add("abono_cap")
    '            dtConsulta.Columns.Add("cargo_cap")
    '            dtConsulta.Columns.Add("saldo_cap")
    '            dtConsulta.Columns.Add("abono_rep")
    '            dtConsulta.Columns.Add("cargo_rep")
    '            dtConsulta.Columns.Add("saldo_rep")
    '            dtConsulta.Columns.Add("saldo_adm")
    '            dtConsulta.Columns.Add("saldo_ex_cap")
    '            dtConsulta.Columns.Add("saldo_ex_rep")
    '            dtConsulta.Columns.Add("saldo_ex")
    '            dtConsulta.Columns.Add("tras_fondos_cap")
    '            dtConsulta.Columns.Add("tras_fondos_rep")
    '            dtConsulta.Columns.Add("tras_fondos_adm")
    '            dtConsulta.Columns.Add("tras_fondos_ex_cap")
    '            dtConsulta.Columns.Add("tras_fondos_ex_rep")
    '            Dim dr As DataRow
    '            For Each dr In dtConsulta.Rows
    '                dr("abono_cap") = 0
    '                dr("cargo_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("abono_rep") = 0
    '                dr("cargo_rep") = 0
    '                dr("tras_fondos_rep") = 0
    '                dr("abono_adm") = 0
    '                dr("cargo_adm") = 0
    '                dr("tras_fondos_adm") = 0
    '                dr("abono_ex_cap") = 0
    '                dr("cargo_ex_cap") = 0
    '                dr("tras_fondos_ex_cap") = 0
    '                dr("abono_ex_rep") = 0
    '                dr("cargo_ex_rep") = 0
    '                dr("tras_fondos_ex_rep") = 0
    '                dr("saldo_cap") = 0
    '                dr("saldo_rep") = 0
    '                dr("saldo_adm") = 0
    '                dr("saldo_ex_cap") = 0
    '                dr("saldo_ex_rep") = 0
    '                dr("saldo_ex") = 0
    '                If CInt(dr("cod_cuenta1_cap_aporte")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto1_cap_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta1_cap_ins_curso")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto1_cap_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta1_cap_ingreso_exc")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto1_cap_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta1_cap_tras_fondos")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto1_cap_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta1_cap_VyT")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto1_cap_VyT"))
    '                    End If
    '                End If
    '                '******************************************************************************************************************************

    '                ''Cuenta de reparto

    '                If CInt(dr("cod_cuenta2_rep_aporte")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto2_rep_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta2_rep_ins_curso")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto2_rep_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta2_rep_ingreso_exc")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto2_rep_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta2_rep_tras_fondos")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto2_rep_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta2_rep_VyT")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto2_rep_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************

    '                ''administracion

    '                If CInt(dr("cod_cuenta3_adm_aporte")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto3_adm_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta3_adm_ins_curso")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto3_adm_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta3_adm_ingreso_exc")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto3_adm_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta3_adm_tras_fondos")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto3_adm_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta3_adm_VyT")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto3_adm_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************

    '                ''exc. capacitacion

    '                If CInt(dr("cod_cuenta4_exCap_aporte")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto4_exCap_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta4_exCap_ins_curso")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto4_exCap_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta4_exCap_ingreso_exc")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto4_exCap_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta4_exCap_tras_fondos")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto4_exCap_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta4_exCap_VyT")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto4_exCap_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************


    '                ''exc. reparto

    '                If CInt(dr("cod_cuenta5_exRep_aporte")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto5_exRep_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta5_exRep_ins_curso")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto5_exRep_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta5_exRep_ingreso_exc")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto5_exRep_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta5_exRep_tras_fondos")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto5_exRep_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta5_exRep_VyT")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto5_exRep_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************

    '                '**************************************************
    '                '**************************************************

    '                dr("saldo_cap") = (CLng(dr("abono_cap")) - CLng(dr("cargo_cap"))) + CLng(dr("tras_fondos_cap"))
    '                dr("saldo_rep") = (CLng(dr("abono_rep")) - CLng(dr("cargo_rep"))) + CLng(dr("tras_fondos_rep"))
    '                dr("saldo_adm") = (CLng(dr("abono_adm")) - CLng(dr("cargo_adm"))) + CLng(dr("tras_fondos_adm"))
    '                dr("saldo_ex_cap") = (CLng(dr("abono_ex_cap")) - CLng(dr("cargo_ex_cap"))) + CLng(dr("tras_fondos_ex_cap"))
    '                dr("saldo_ex_rep") = (CLng(dr("abono_ex_rep")) - CLng(dr("cargo_ex_rep"))) + CLng(dr("tras_fondos_ex_rep"))
    '                dr("saldo_ex") = CLng(dr("saldo_ex_cap")) + CLng(dr("saldo_ex_rep"))



    '            Next



    '            If Me.mblnBajarXml Then
    '                strNombreArchivo = NombreArchivoTmp("txt")
    '                dtConsulta.TableName = "Reporte Cursos"
    '                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
    '                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
    '            End If




    '        End If






    '        Return dtConsulta


    '    Catch ex As Exception
    '        EnviaError("CReporteResumenCliente.vb:Consultar-->" & ex.Message)
    '    End Try

    'End Function
    'Public Function Consultar() As DataTable
    '    Try
    '        Dim strNombreArchivo As String
    '        Dim dtConsulta As DataTable
    '        mobjSql = New CSql
    '        'i->contador de arrreporte, j->contador de la consulta
    '        Dim i As Integer ', intFilas As Integer, j As Integer, k As Integer, salir As Integer
    '        'Dim lngRutTemp As Long
    '        'Dim AbonoAdm, CargoAdm, AbonoExCap, CargoExCap, AbonoExRep, CargoExRep As Long
    '        dtConsulta = mobjSql.s_resumen_cliente2(mlngRutCliente, mstrNombreCliente, mintAgno)
    '        mintFilas = mobjSql.Registros
    '        If mintFilas > 0 Then
    '            dtConsulta.Columns.Add("abono_adm")
    '            dtConsulta.Columns.Add("cargo_adm")
    '            dtConsulta.Columns.Add("abono_ex_cap")
    '            dtConsulta.Columns.Add("cargo_ex_cap")
    '            dtConsulta.Columns.Add("abono_ex_rep")
    '            dtConsulta.Columns.Add("cargo_ex_rep")
    '            dtConsulta.Columns.Add("abono_cap")
    '            dtConsulta.Columns.Add("cargo_cap")
    '            dtConsulta.Columns.Add("saldo_cap")
    '            dtConsulta.Columns.Add("abono_rep")
    '            dtConsulta.Columns.Add("cargo_rep")
    '            dtConsulta.Columns.Add("saldo_rep")
    '            dtConsulta.Columns.Add("saldo_adm")
    '            dtConsulta.Columns.Add("saldo_ex_cap")
    '            dtConsulta.Columns.Add("saldo_ex_rep")
    '            dtConsulta.Columns.Add("saldo_ex")
    '            dtConsulta.Columns.Add("tras_fondos_cap")
    '            dtConsulta.Columns.Add("tras_fondos_rep")
    '            dtConsulta.Columns.Add("tras_fondos_adm")
    '            dtConsulta.Columns.Add("tras_fondos_ex_cap")
    '            dtConsulta.Columns.Add("tras_fondos_ex_rep")
    '            Dim dr As DataRow
    '            For Each dr In dtConsulta.Rows
    '                dr("abono_cap") = 0
    '                dr("cargo_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("abono_rep") = 0
    '                dr("cargo_rep") = 0
    '                dr("tras_fondos_rep") = 0
    '                dr("abono_adm") = 0
    '                dr("cargo_adm") = 0
    '                dr("tras_fondos_adm") = 0
    '                dr("abono_ex_cap") = 0
    '                dr("cargo_ex_cap") = 0
    '                dr("tras_fondos_ex_cap") = 0
    '                dr("abono_ex_rep") = 0
    '                dr("cargo_ex_rep") = 0
    '                dr("tras_fondos_ex_rep") = 0
    '                dr("saldo_cap") = 0
    '                dr("saldo_rep") = 0
    '                dr("saldo_adm") = 0
    '                dr("saldo_ex_cap") = 0
    '                dr("saldo_ex_rep") = 0
    '                dr("saldo_ex") = 0
    '                If CInt(dr("cod_cuenta1_cap_aporte")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto1_cap_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta1_cap_ins_curso")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto1_cap_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta1_cap_ingreso_exc")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto1_cap_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta1_cap_tras_fondos")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto1_cap_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta1_cap_VyT")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1_cap_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto1_cap_VyT"))
    '                    End If
    '                End If
    '                '******************************************************************************************************************************

    '                ''Cuenta de reparto

    '                If CInt(dr("cod_cuenta2_rep_aporte")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto2_rep_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta2_rep_ins_curso")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto2_rep_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta2_rep_ingreso_exc")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto2_rep_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta2_rep_tras_fondos")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto2_rep_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta2_rep_VyT")) = 2 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2_rep_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto2_rep_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************

    '                ''administracion

    '                If CInt(dr("cod_cuenta3_adm_aporte")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto3_adm_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta3_adm_ins_curso")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto3_adm_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta3_adm_ingreso_exc")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto3_adm_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta3_adm_tras_fondos")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto3_adm_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta3_adm_VyT")) = 3 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3_adm_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto3_adm_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************

    '                ''exc. capacitacion

    '                If CInt(dr("cod_cuenta4_exCap_aporte")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto4_exCap_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta4_exCap_ins_curso")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto4_exCap_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta4_exCap_ingreso_exc")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto4_exCap_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta4_exCap_tras_fondos")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto4_exCap_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta4_exCap_VyT")) = 4 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4_exCap_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto4_exCap_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************


    '                ''exc. reparto

    '                If CInt(dr("cod_cuenta5_exRep_aporte")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_aporte")) = 1 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto5_exRep_aporte"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos
    '                End If

    '                If CInt(dr("cod_cuenta5_exRep_ins_curso")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_ins_curso")) = 2 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        'If CLng(dr("monto1_cap_aporte")) > 0 Then
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto5_exRep_ins_curso"))
    '                    End If
    '                End If


    '                If CInt(dr("cod_cuenta5_exRep_ingreso_exc")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_ingreso_exc")) = 3 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto5_exRep_ingreso_exc"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta5_exRep_tras_fondos")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_tras_fondos")) = 4 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then

    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto5_exRep_tras_fondos"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta5_exRep_VyT")) = 5 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5_exRep_VyT")) = 5 Then 'Or CInt(dr("cod_tipo_tran1_cap_ingreso_exc")) = 3 Then
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto5_exRep_VyT"))
    '                    End If
    '                End If

    '                '**********************************************************************************

    '                '**************************************************
    '                '**************************************************

    '                dr("saldo_cap") = (CLng(dr("abono_cap")) - CLng(dr("cargo_cap"))) + CLng(dr("tras_fondos_cap"))
    '                dr("saldo_rep") = (CLng(dr("abono_rep")) - CLng(dr("cargo_rep"))) + CLng(dr("tras_fondos_rep"))
    '                dr("saldo_adm") = (CLng(dr("abono_adm")) - CLng(dr("cargo_adm"))) + CLng(dr("tras_fondos_adm"))
    '                dr("saldo_ex_cap") = (CLng(dr("abono_ex_cap")) - CLng(dr("cargo_ex_cap"))) + CLng(dr("tras_fondos_ex_cap"))
    '                dr("saldo_ex_rep") = (CLng(dr("abono_ex_rep")) - CLng(dr("cargo_ex_rep"))) + CLng(dr("tras_fondos_ex_rep"))
    '                dr("saldo_ex") = CLng(dr("saldo_ex_cap")) + CLng(dr("saldo_ex_rep"))



    '            Next



    '            If Me.mblnBajarXml Then
    '                strNombreArchivo = NombreArchivoTmp("txt")
    '                dtConsulta.TableName = "Reporte Cursos"
    '                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
    '                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
    '            End If




    '        End If






    '        Return dtConsulta


    '    Catch ex As Exception
    '        EnviaError("CReporteResumenCliente.vb:Consultar-->" & ex.Message)
    '    End Try

    'End Function

    '
    ' Consulta
    'Public Function Consultar() As DataTable
    '    Try
    '        Dim strNombreArchivo As String
    '        Dim dtConsulta As DataTable
    '        mobjSql = New CSql
    '        'i->contador de arrreporte, j->contador de la consulta
    '        Dim i As Integer ', intFilas As Integer, j As Integer, k As Integer, salir As Integer
    '        'Dim lngRutTemp As Long
    '        'Dim AbonoAdm, CargoAdm, AbonoExCap, CargoExCap, AbonoExRep, CargoExRep As Long
    '        dtConsulta = mobjSql.s_resumen_cliente2(mlngRutCliente, mstrNombreCliente, mintAgno)
    '        mintFilas = mobjSql.Registros
    '        If mintFilas > 0 Then
    '            dtConsulta.Columns.Add("abono_adm")
    '            dtConsulta.Columns.Add("cargo_adm")
    '            dtConsulta.Columns.Add("abono_ex_cap")
    '            dtConsulta.Columns.Add("cargo_ex_cap")
    '            dtConsulta.Columns.Add("abono_ex_rep")
    '            dtConsulta.Columns.Add("cargo_ex_rep")
    '            dtConsulta.Columns.Add("abono_cap")
    '            dtConsulta.Columns.Add("cargo_cap")
    '            dtConsulta.Columns.Add("saldo_cap")
    '            dtConsulta.Columns.Add("abono_rep")
    '            dtConsulta.Columns.Add("cargo_rep")
    '            dtConsulta.Columns.Add("saldo_rep")
    '            dtConsulta.Columns.Add("saldo_adm")
    '            dtConsulta.Columns.Add("saldo_ex_cap")
    '            dtConsulta.Columns.Add("saldo_ex_rep")
    '            dtConsulta.Columns.Add("saldo_ex")
    '            dtConsulta.Columns.Add("tras_fondos_cap")
    '            dtConsulta.Columns.Add("tras_fondos_rep")
    '            dtConsulta.Columns.Add("tras_fondos_adm")
    '            dtConsulta.Columns.Add("tras_fondos_ex_cap")
    '            dtConsulta.Columns.Add("tras_fondos_ex_rep")
    '            Dim dr As DataRow
    '            For Each dr In dtConsulta.Rows
    '                dr("abono_cap") = 0
    '                dr("cargo_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("abono_rep") = 0
    '                dr("cargo_rep") = 0
    '                dr("tras_fondos_rep") = 0
    '                dr("abono_adm") = 0
    '                dr("cargo_adm") = 0
    '                dr("tras_fondos_adm") = 0
    '                dr("abono_ex_cap") = 0
    '                dr("cargo_ex_cap") = 0
    '                dr("tras_fondos_ex_cap") = 0
    '                dr("abono_ex_rep") = 0
    '                dr("cargo_ex_rep") = 0
    '                dr("tras_fondos_ex_rep") = 0
    '                dr("saldo_cap") = 0
    '                dr("saldo_rep") = 0
    '                dr("saldo_adm") = 0
    '                dr("saldo_ex_cap") = 0
    '                dr("saldo_ex_rep") = 0
    '                dr("saldo_ex") = 0
    '                If CInt(dr("cod_cuenta1")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1")) = 1 Or CInt(dr("cod_tipo_tran1")) = 3 Then '(2, j)
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto1"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 2 Or CInt(dr("cod_tipo_tran1")) = 5 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto1"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 4 Then
    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto1"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos

    '                End If

    '                'Cuenta de reparto
    '                If CInt(dr("cod_cuenta1")) = 2 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1")) = 1 Or CInt(dr("cod_tipo_tran1")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto1"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 2 Or CInt(dr("cod_tipo_tran1")) = 5 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto1"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 4 Then
    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto1"))
    '                    End If
    '                End If

    '                'Cuenta de Administracion
    '                If CInt(dr("cod_cuenta1")) = 3 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1")) = 1 Or CInt(dr("cod_tipo_tran1")) = 3 Then
    '                        'arrReporte(i).item("AbonoAdm")
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto1"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 2 Or CInt(dr("cod_tipo_tran1")) = 5 Then
    '                        'arrReporte(i).item("CargoAdm")
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto1"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 4 Then
    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto1"))
    '                    End If
    '                End If

    '                'Cuenta de excedentes de cap
    '                If CInt(dr("cod_cuenta1")) = 4 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1")) = 1 Or CInt(dr("cod_tipo_tran1")) = 3 Then
    '                        'arrReporte(i).item("AbonoExCap")
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto1"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 2 Or CInt(dr("cod_tipo_tran1")) = 5 Then
    '                        'arrReporte(i).item("CargoExCap")
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto1"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 4 Then
    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto1"))
    '                    End If
    '                End If

    '                'Cuenta de Excedentes de reparto
    '                If CInt(dr("cod_cuenta1")) = 5 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran1")) = 1 Or CInt(dr("cod_tipo_tran1")) = 3 Then
    '                        'arrReporte(i).item("AbonoExRep")
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto1"))
    '                        'Cargos por curso o VYT)
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 2 Or CInt(dr("cod_tipo_tran1")) = 5 Then
    '                        'arrReporte(i).item("CargoExRep")
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto1"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran1")) = 4 Then
    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto1"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta2")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2")) = 1 Or CInt(dr("cod_tipo_tran2")) = 3 Then '(2, j)
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto2"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 2 Or CInt(dr("cod_tipo_tran2")) = 5 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto2"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 4 Then
    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto2"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos

    '                End If

    '                'Cuenta de reparto
    '                If CInt(dr("cod_cuenta2")) = 2 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2")) = 1 Or CInt(dr("cod_tipo_tran2")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto2"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 2 Or CInt(dr("cod_tipo_tran2")) = 5 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto2"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 4 Then
    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto2"))
    '                    End If
    '                End If

    '                'Cuenta de Administracion
    '                If CInt(dr("cod_cuenta2")) = 3 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2")) = 1 Or CInt(dr("cod_tipo_tran2")) = 3 Then
    '                        'arrReporte(i).item("AbonoAdm")
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto2"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 2 Or CInt(dr("cod_tipo_tran2")) = 5 Then
    '                        'arrReporte(i).item("CargoAdm")
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto2"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 4 Then
    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto2"))
    '                    End If
    '                End If

    '                'Cuenta de excedentes de cap
    '                If CInt(dr("cod_cuenta2")) = 4 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2")) = 1 Or CInt(dr("cod_tipo_tran2")) = 3 Then
    '                        'arrReporte(i).item("AbonoExCap")
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto2"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 2 Or CInt(dr("cod_tipo_tran2")) = 5 Then
    '                        'arrReporte(i).item("CargoExCap")
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto2"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 4 Then
    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto2"))
    '                    End If
    '                End If

    '                'Cuenta de Excedentes de reparto
    '                If CInt(dr("cod_cuenta2")) = 5 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran2")) = 1 Or CInt(dr("cod_tipo_tran2")) = 3 Then
    '                        'arrReporte(i).item("AbonoExRep")
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto2"))
    '                        'Cargos por curso o VYT)
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 2 Or CInt(dr("cod_tipo_tran2")) = 5 Then
    '                        'arrReporte(i).item("CargoExRep")
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto2"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran2")) = 4 Then
    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto2"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta3")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3")) = 1 Or CInt(dr("cod_tipo_tran3")) = 3 Then '(2, j)
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 2 Or CInt(dr("cod_tipo_tran3")) = 5 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto3"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 4 Then
    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto3"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos

    '                End If

    '                'Cuenta de reparto
    '                If CInt(dr("cod_cuenta3")) = 2 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3")) = 1 Or CInt(dr("cod_tipo_tran3")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto3"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 2 Or CInt(dr("cod_tipo_tran3")) = 5 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto3"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 4 Then
    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto3"))
    '                    End If
    '                End If

    '                'Cuenta de Administracion
    '                If CInt(dr("cod_cuenta3")) = 3 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3")) = 1 Or CInt(dr("cod_tipo_tran3")) = 3 Then
    '                        'arrReporte(i).item("AbonoAdm")
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto3"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 2 Or CInt(dr("cod_tipo_tran3")) = 5 Then
    '                        'arrReporte(i).item("CargoAdm")
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto3"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 4 Then
    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto3"))
    '                    End If
    '                End If

    '                'Cuenta de excedentes de cap
    '                If CInt(dr("cod_cuenta3")) = 4 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3")) = 1 Or CInt(dr("cod_tipo_tran3")) = 3 Then
    '                        'arrReporte(i).item("AbonoExCap")
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto3"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 2 Or CInt(dr("cod_tipo_tran3")) = 5 Then
    '                        'arrReporte(i).item("CargoExCap")
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto3"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 4 Then
    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto3"))
    '                    End If
    '                End If

    '                'Cuenta de Excedentes de reparto
    '                If CInt(dr("cod_cuenta3")) = 5 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran3")) = 1 Or CInt(dr("cod_tipo_tran3")) = 3 Then
    '                        'arrReporte(i).item("AbonoExRep")
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto3"))
    '                        'Cargos por curso o VYT)
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 2 Or CInt(dr("cod_tipo_tran3")) = 5 Then
    '                        'arrReporte(i).item("CargoExRep")
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto3"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran3")) = 4 Then
    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto3"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta4")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4")) = 1 Or CInt(dr("cod_tipo_tran4")) = 3 Then '(2, j)
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto4"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 2 Or CInt(dr("cod_tipo_tran4")) = 5 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto4"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 4 Then
    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto4"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos

    '                End If

    '                'Cuenta de reparto
    '                If CInt(dr("cod_cuenta4")) = 2 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4")) = 1 Or CInt(dr("cod_tipo_tran4")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto4"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 2 Or CInt(dr("cod_tipo_tran4")) = 5 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto4"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 4 Then
    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto4"))
    '                    End If
    '                End If

    '                'Cuenta de Administracion
    '                If CInt(dr("cod_cuenta4")) = 3 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4")) = 1 Or CInt(dr("cod_tipo_tran4")) = 3 Then
    '                        'arrReporte(i).item("AbonoAdm")
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto4"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 2 Or CInt(dr("cod_tipo_tran4")) = 5 Then
    '                        'arrReporte(i).item("CargoAdm")
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto4"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 4 Then
    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto4"))
    '                    End If
    '                End If

    '                'Cuenta de excedentes de cap
    '                If CInt(dr("cod_cuenta4")) = 4 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4")) = 1 Or CInt(dr("cod_tipo_tran4")) = 3 Then
    '                        'arrReporte(i).item("AbonoExCap")
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto4"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 2 Or CInt(dr("cod_tipo_tran4")) = 5 Then
    '                        'arrReporte(i).item("CargoExCap")
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto4"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 4 Then
    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto4"))
    '                    End If
    '                End If

    '                'Cuenta de Excedentes de reparto
    '                If CInt(dr("cod_cuenta4")) = 5 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran4")) = 1 Or CInt(dr("cod_tipo_tran4")) = 3 Then
    '                        'arrReporte(i).item("AbonoExRep")
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto4"))
    '                        'Cargos por curso o VYT)
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 2 Or CInt(dr("cod_tipo_tran4")) = 5 Then
    '                        'arrReporte(i).item("CargoExRep")
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto4"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran4")) = 4 Then
    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto4"))
    '                    End If
    '                End If

    '                If CInt(dr("cod_cuenta5")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5")) = 1 Or CInt(dr("cod_tipo_tran5")) = 3 Then '(2, j)
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto5"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 2 Or CInt(dr("cod_tipo_tran5")) = 5 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto5"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 4 Then
    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto5"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos

    '                End If

    '                'Cuenta de reparto
    '                If CInt(dr("cod_cuenta5")) = 2 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5")) = 1 Or CInt(dr("cod_tipo_tran5")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto5"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 2 Or CInt(dr("cod_tipo_tran5")) = 5 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto5"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 4 Then
    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto5"))
    '                    End If
    '                End If

    '                'Cuenta de Administracion
    '                If CInt(dr("cod_cuenta5")) = 3 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5")) = 1 Or CInt(dr("cod_tipo_tran5")) = 3 Then
    '                        'arrReporte(i).item("AbonoAdm")
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto5"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 2 Or CInt(dr("cod_tipo_tran5")) = 5 Then
    '                        'arrReporte(i).item("CargoAdm")
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto5"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 4 Then
    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto5"))
    '                    End If
    '                End If

    '                'Cuenta de excedentes de cap
    '                If CInt(dr("cod_cuenta5")) = 4 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5")) = 1 Or CInt(dr("cod_tipo_tran5")) = 3 Then
    '                        'arrReporte(i).item("AbonoExCap")
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto5"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 2 Or CInt(dr("cod_tipo_tran5")) = 5 Then
    '                        'arrReporte(i).item("CargoExCap")
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto5"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 4 Then
    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto5"))
    '                    End If
    '                End If

    '                'Cuenta de Excedentes de reparto
    '                If CInt(dr("cod_cuenta5")) = 5 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran5")) = 1 Or CInt(dr("cod_tipo_tran5")) = 3 Then
    '                        'arrReporte(i).item("AbonoExRep")
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto5"))
    '                        'Cargos por curso o VYT)
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 2 Or CInt(dr("cod_tipo_tran5")) = 5 Then
    '                        'arrReporte(i).item("CargoExRep")
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto5"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran5")) = 4 Then
    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto5"))
    '                    End If
    '                End If
    '                '**************************************************
    '                '**************************************************

    '                dr("saldo_cap") = (CLng(dr("abono_cap")) - CLng(dr("cargo_cap"))) + CLng(dr("tras_fondos_cap"))
    '                dr("saldo_rep") = (CLng(dr("abono_rep")) - CLng(dr("cargo_rep"))) + CLng(dr("tras_fondos_rep"))
    '                dr("saldo_adm") = (CLng(dr("abono_adm")) - CLng(dr("cargo_adm"))) + CLng(dr("tras_fondos_adm"))
    '                dr("saldo_ex_cap") = (CLng(dr("abono_ex_cap")) - CLng(dr("cargo_ex_cap"))) + CLng(dr("tras_fondos_ex_cap"))
    '                dr("saldo_ex_rep") = (CLng(dr("abono_ex_rep")) - CLng(dr("cargo_ex_rep"))) + CLng(dr("tras_fondos_ex_rep"))
    '                dr("saldo_ex") = CLng(dr("saldo_ex_cap")) + CLng(dr("saldo_ex_rep"))



    '            Next

    '            'Dim dt As DataTable
    '            'dt = New DataTable
    '            'dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("cod_cuenta", GetType(Integer)))
    '            'dt.Columns.Add(New DataColumn("cod_tipo_trans", GetType(Integer)))
    '            'dt.Columns.Add(New DataColumn("monto", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("razon_social", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("nom_contacto", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("fono_contacto", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("anexo_contacto", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("nombre_ejecutivo", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("nombre_sucursal", GetType(String)))
    '            'dt.Columns.Add(New DataColumn("horas", GetType(Integer)))
    '            'dt.Columns.Add(New DataColumn("hh", GetType(Integer)))
    '            'dt.Columns.Add(New DataColumn("cant_part", GetType(Integer)))
    '            'dt.Columns.Add(New DataColumn("abono_adm", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("cargo_adm", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("abono_ex_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("cargo_ex_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("abono_ex_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("cargo_ex_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("abono_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("cargo_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("saldo_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("abono_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("cargo_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("saldo_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("saldo_adm", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("saldo_ex_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("saldo_ex_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("saldo_ex", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("tras_fondos_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("tras_fondos_rep", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("tras_fondos_adm", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("tras_fondos_ex_cap", GetType(Long)))
    '            'dt.Columns.Add(New DataColumn("tras_fondos_ex_rep", GetType(Long)))
    '            ''Dim drConsulta As DataRow
    '            'Dim drFinal As DataRow
    '            'For i = 0 To mintFilas - 1
    '            '    If i = 0 Then
    '            '        'For Each drFinal In dtConsulta.Rows
    '            '        drFinal = dt.NewRow()
    '            '        'dr = dtConsulta.NewRow()
    '            '        drFinal("rut_cliente") = dtConsulta.Rows(i)(0)
    '            '        drFinal("cod_cuenta") = dtConsulta.Rows(i)(1)
    '            '        drFinal("cod_tipo_trans") = dtConsulta.Rows(i)(2)
    '            '        drFinal("monto") = dtConsulta.Rows(i)(3)
    '            '        drFinal("razon_social") = dtConsulta.Rows(i)(4)
    '            '        drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '            '        drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '            '        drFinal("anexo_contacto") = dtConsulta.Rows(i)(7)
    '            '        drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '            '        drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '            '        drFinal("horas") = dtConsulta.Rows(i)(10)
    '            '        drFinal("hh") = dtConsulta.Rows(i)(11)
    '            '        drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '            '        drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '            '        drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '            '        drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '            '        drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '            '        drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '            '        drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '            '        drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '            '        drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '            '        drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '            '        drFinal("abono_rep") = dtConsulta.Rows(i)(22)
    '            '        drFinal("cargo_rep") = dtConsulta.Rows(i)(23)
    '            '        drFinal("saldo_rep") = dtConsulta.Rows(i)(24)
    '            '        drFinal("saldo_adm") = dtConsulta.Rows(i)(25)
    '            '        drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(26)
    '            '        drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(27)
    '            '        drFinal("saldo_ex") = dtConsulta.Rows(i)(28)
    '            '        drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(29)
    '            '        drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(30)
    '            '        drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(31)
    '            '        drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(32)
    '            '        drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(33)
    '            '        dt.Rows.Add(drFinal)
    '            '    Else
    '            '        'For Each drFinal In dtConsulta.Rows
    '            '        drFinal = dt.NewRow()
    '            '        'dr = dtConsulta.NewRow()
    '            '        If dtConsulta.Rows(i)(0) <> dtConsulta.Rows(i - 1)(0) Then
    '            '            drFinal("rut_cliente") = dtConsulta.Rows(i)(0)
    '            '            drFinal("cod_cuenta") = dtConsulta.Rows(i)(1)
    '            '            drFinal("cod_tipo_trans") = dtConsulta.Rows(i)(2)
    '            '            drFinal("monto") = dtConsulta.Rows(i)(3)
    '            '            drFinal("razon_social") = dtConsulta.Rows(i)(4)
    '            '            drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '            '            drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '            '            drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '            '            drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '            '            drFinal("horas") = dtConsulta.Rows(i)(10)
    '            '            drFinal("hh") = dtConsulta.Rows(i)(11)
    '            '            drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '            '            drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '            '            drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '            '            drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '            '            drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '            '            drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '            '            drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '            '            drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '            '            drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '            '            drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '            '            drFinal("abono_rep") = dtConsulta.Rows(i)(22)
    '            '            drFinal("cargo_rep") = dtConsulta.Rows(i)(23)
    '            '            drFinal("saldo_rep") = dtConsulta.Rows(i)(24)
    '            '            drFinal("saldo_adm") = dtConsulta.Rows(i)(25)
    '            '            drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(26)
    '            '            drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(27)
    '            '            drFinal("saldo_ex") = dtConsulta.Rows(i)(28)
    '            '            drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(29)
    '            '            drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(30)
    '            '            drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(31)
    '            '            drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(32)
    '            '            drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(33)
    '            '            dt.Rows.Add(drFinal)
    '            '        Else
    '            '            If dtConsulta.Rows(i)(0) <> dtConsulta.Rows(i - 1)(0) Then

    '            '            End If
    '            '            drFinal("abono_adm") = drFinal("abono_adm") + dtConsulta.Rows(i)(13)
    '            '            drFinal("cargo_adm") = drFinal("cargo_adm") + dtConsulta.Rows(i)(14)
    '            '            drFinal("abono_ex_cap") = drFinal("abono_ex_cap") + dtConsulta.Rows(i)(15)
    '            '            drFinal("cargo_ex_cap") = drFinal("cargo_ex_cap") + dtConsulta.Rows(i)(16)
    '            '            drFinal("abono_ex_rep") = drFinal("abono_ex_rep") + dtConsulta.Rows(i)(17)
    '            '            drFinal("cargo_ex_rep") = drFinal("cargo_ex_rep") + dtConsulta.Rows(i)(18)
    '            '            drFinal("abono_cap") = drFinal("abono_cap") + dtConsulta.Rows(i)(19)
    '            '            drFinal("cargo_cap") = drFinal("cargo_cap") + dtConsulta.Rows(i)(20)
    '            '            drFinal("saldo_cap") = drFinal("saldo_cap") + dtConsulta.Rows(i)(21)
    '            '            drFinal("abono_rep") = drFinal("abono_rep") + dtConsulta.Rows(i)(22)
    '            '            drFinal("cargo_rep") = drFinal("cargo_rep") + dtConsulta.Rows(i)(23)
    '            '            drFinal("saldo_rep") = drFinal("saldo_rep") + dtConsulta.Rows(i)(24)
    '            '            drFinal("saldo_adm") = drFinal("saldo_adm") + dtConsulta.Rows(i)(25)
    '            '            drFinal("saldo_ex_cap") = drFinal("saldo_ex_cap") + dtConsulta.Rows(i)(26)
    '            '            drFinal("saldo_ex_rep") = drFinal("saldo_ex_rep") + dtConsulta.Rows(i)(27)
    '            '            drFinal("saldo_ex") = drFinal("saldo_ex") + dtConsulta.Rows(i)(28)
    '            '            drFinal("tras_fondos_cap") = drFinal("tras_fondos_cap") + dtConsulta.Rows(i)(29)
    '            '            drFinal("tras_fondos_rep") = drFinal("tras_fondos_rep") + dtConsulta.Rows(i)(30)
    '            '            drFinal("tras_fondos_adm") = drFinal("tras_fondos_adm") + dtConsulta.Rows(i)(31)
    '            '            drFinal("tras_fondos_ex_cap") = drFinal("tras_fondos_ex_cap") + dtConsulta.Rows(i)(32)
    '            '            drFinal("tras_fondos_ex_rep") = drFinal("tras_fondos_ex_rep") + dtConsulta.Rows(i)(33)
    '            '            'dt.Rows(i - 1)(13) = dtConsulta.Rows(i)(13)
    '            '            'dt.Rows(i - 1)(14) = dtConsulta.Rows(i)(14)
    '            '            'dt.Rows(i - 1)(15) = dtConsulta.Rows(i)(15)
    '            '            'dt.Rows(i - 1)(16) = dtConsulta.Rows(i)(16)
    '            '            'dt.Rows(i - 1)(17) = dtConsulta.Rows(i)(17)
    '            '            'dt.Rows(i - 1)(18) = dtConsulta.Rows(i)(18)
    '            '            'dt.Rows(i - 1)(19) = dtConsulta.Rows(i)(19)
    '            '            'dt.Rows(i - 1)(20) = dtConsulta.Rows(i)(20)
    '            '            'dt.Rows(i - 1)(21) = dtConsulta.Rows(i)(21)
    '            '            'dt.Rows(i - 1)(22) = dtConsulta.Rows(i)(22)
    '            '            'dt.Rows(i - 1)(23) = dtConsulta.Rows(i)(23)
    '            '            'dt.Rows(i - 1)(24) = dtConsulta.Rows(i)(24)
    '            '            'dt.Rows(i - 1)(25) = dtConsulta.Rows(i)(25)
    '            '            'dt.Rows(i - 1)(26) = dtConsulta.Rows(i)(26)
    '            '            'dt.Rows(i - 1)(27) = dtConsulta.Rows(i)(27)
    '            '            'dt.Rows(i - 1)(28) = dtConsulta.Rows(i)(28)
    '            '            'dt.Rows(i - 1)(29) = dtConsulta.Rows(i)(29)
    '            '            'dt.Rows(i - 1)(30) = dtConsulta.Rows(i)(30)
    '            '            'dt.Rows(i - 1)(31) = dtConsulta.Rows(i)(31)
    '            '            'dt.Rows(i - 1)(32) = dtConsulta.Rows(i)(32)
    '            '            'dt.Rows(i - 1)(33) = dtConsulta.Rows(i)(33)
    '            '        End If



    '            '        'drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '            '        'drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '            '        'drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '            '        'drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '            '        'drFinal("horas") = dtConsulta.Rows(i)(10)
    '            '        'drFinal("hh") = dtConsulta.Rows(i)(11)
    '            '        'drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '            '        'drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '            '        'drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '            '        'drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '            '        'drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '            '        'drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '            '        'drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '            '        'drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '            '        'drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '            '        'drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '            '        'drFinal("abono_rep") = dtConsulta.Rows(i)(21)
    '            '        'drFinal("cargo_rep") = dtConsulta.Rows(i)(22)
    '            '        'drFinal("saldo_rep") = dtConsulta.Rows(i)(23)
    '            '        'drFinal("saldo_adm") = dtConsulta.Rows(i)(24)
    '            '        'drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(25)
    '            '        'drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(26)
    '            '        'drFinal("saldo_ex") = dtConsulta.Rows(i)(27)
    '            '        'drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(28)
    '            '        'drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(29)
    '            '        'drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(30)
    '            '        'drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(31)
    '            '        'drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(32)
    '            '        ' dt.Rows.Add(drFinal)

    '            '    End If


    '            ' Next
    '            'Me.TablaFinal = dt

    '            '    If Me.mblnBajarXml Then
    '            '        strNombreArchivo = NombreArchivoTmp("txt")
    '            '        dtConsulta.TableName = "Reporte Cursos"
    '            '        ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
    '            '        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
    '            '    End If




    '            'End If

    '            If Me.mblnBajarXml Then
    '                strNombreArchivo = NombreArchivoTmp("txt")
    '                dtConsulta.TableName = "Reporte Cursos"
    '                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
    '                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
    '            End If




    '        End If






    '        Return dtConsulta


    '    Catch ex As Exception
    '        EnviaError("CReporteResumenCliente.vb:Consultar-->" & ex.Message)
    '    End Try

    'End Function
    '
    'Public Function Consultar() As DataTable
    '    Try
    '        Dim strNombreArchivo As String
    '        Dim dtConsulta As DataTable
    '        mobjSql = New CSql
    '        'i->contador de arrreporte, j->contador de la consulta
    '        Dim i As Integer ', intFilas As Integer, j As Integer, k As Integer, salir As Integer
    '        'Dim lngRutTemp As Long
    '        'Dim AbonoAdm, CargoAdm, AbonoExCap, CargoExCap, AbonoExRep, CargoExRep As Long
    '        dtConsulta = mobjSql.s_resumen_cliente(mlngRutCliente, mstrNombreCliente, mintAgno)
    '        mintFilas = mobjSql.Registros
    '        If mintFilas > 0 Then
    '            dtConsulta.Columns.Add("abono_adm")
    '            dtConsulta.Columns.Add("cargo_adm")
    '            dtConsulta.Columns.Add("abono_ex_cap")
    '            dtConsulta.Columns.Add("cargo_ex_cap")
    '            dtConsulta.Columns.Add("abono_ex_rep")
    '            dtConsulta.Columns.Add("cargo_ex_rep")
    '            dtConsulta.Columns.Add("abono_cap")
    '            dtConsulta.Columns.Add("cargo_cap")
    '            dtConsulta.Columns.Add("saldo_cap")
    '            dtConsulta.Columns.Add("abono_rep")
    '            dtConsulta.Columns.Add("cargo_rep")
    '            dtConsulta.Columns.Add("saldo_rep")
    '            dtConsulta.Columns.Add("saldo_adm")
    '            dtConsulta.Columns.Add("saldo_ex_cap")
    '            dtConsulta.Columns.Add("saldo_ex_rep")
    '            dtConsulta.Columns.Add("saldo_ex")
    '            dtConsulta.Columns.Add("tras_fondos_cap")
    '            dtConsulta.Columns.Add("tras_fondos_rep")
    '            dtConsulta.Columns.Add("tras_fondos_adm")
    '            dtConsulta.Columns.Add("tras_fondos_ex_cap")
    '            dtConsulta.Columns.Add("tras_fondos_ex_rep")
    '            Dim dr As DataRow
    '            For Each dr In dtConsulta.Rows
    '                dr("abono_cap") = 0
    '                dr("cargo_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("tras_fondos_cap") = 0
    '                dr("abono_rep") = 0
    '                dr("cargo_rep") = 0
    '                dr("tras_fondos_rep") = 0
    '                dr("abono_adm") = 0
    '                dr("cargo_adm") = 0
    '                dr("tras_fondos_adm") = 0
    '                dr("abono_ex_cap") = 0
    '                dr("cargo_ex_cap") = 0
    '                dr("tras_fondos_ex_cap") = 0
    '                dr("abono_ex_rep") = 0
    '                dr("cargo_ex_rep") = 0
    '                dr("tras_fondos_ex_rep") = 0
    '                dr("saldo_cap") = 0
    '                dr("saldo_rep") = 0
    '                dr("saldo_adm") = 0
    '                dr("saldo_ex_cap") = 0
    '                dr("saldo_ex_rep") = 0
    '                dr("saldo_ex") = 0
    '                If CInt(dr("cod_cuenta")) = 1 Then '(1, i)
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran")) = 1 Or CInt(dr("cod_tipo_tran")) = 3 Then '(2, j)
    '                        dr("abono_cap") = CLng(dr("abono_cap")) + CLng(dr("monto"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 2 Or CInt(dr("cod_tipo_tran")) = 5 Then
    '                        dr("cargo_cap") = CLng(dr("cargo_cap")) + CLng(dr("monto"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 4 Then
    '                        dr("tras_fondos_cap") = CLng(dr("tras_fondos_cap")) + CLng(dr("monto"))
    '                    End If
    '                    'se contabilizan los traspasos de fondos

    '                End If

    '                'Cuenta de reparto
    '                If CInt(dr("cod_cuenta")) = 2 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran")) = 1 Or CInt(dr("cod_tipo_tran")) = 3 Then
    '                        dr("abono_rep") = CLng(dr("abono_rep")) + CLng(dr("monto"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dtConsulta.Rows(i)(2)) = 2 Or CInt(dr("cod_tipo_tran")) = 5 Then
    '                        dr("cargo_rep") = CLng(dr("cargo_rep")) + CLng(dr("monto"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 4 Then
    '                        dr("tras_fondos_rep") = CLng(dr("tras_fondos_rep")) + CLng(dr("monto"))
    '                    End If
    '                End If

    '                'Cuenta de Administracion
    '                If CInt(dr("cod_cuenta")) = 3 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran")) = 1 Or CInt(dr("cod_tipo_tran")) = 3 Then
    '                        'arrReporte(i).item("AbonoAdm")
    '                        dr("abono_adm") = CLng(dr("abono_adm")) + CLng(dr("monto"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 2 Or CInt(dr("cod_tipo_tran")) = 5 Then
    '                        'arrReporte(i).item("CargoAdm")
    '                        dr("cargo_adm") = CLng(dr("cargo_adm")) + CLng(dr("monto"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 4 Then
    '                        dr("tras_fondos_adm") = CLng(dr("tras_fondos_adm")) + CLng(dr("monto"))
    '                    End If
    '                End If

    '                'Cuenta de excedentes de cap
    '                If CInt(dr("cod_cuenta")) = 4 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran")) = 1 Or CInt(dr("cod_tipo_tran")) = 3 Then
    '                        'arrReporte(i).item("AbonoExCap")
    '                        dr("abono_ex_cap") = CLng(dr("abono_ex_cap")) + CLng(dr("monto"))
    '                        'Cargos por curso o VYT
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 2 Or CInt(dr("cod_tipo_tran")) = 5 Then
    '                        'arrReporte(i).item("CargoExCap")
    '                        dr("cargo_ex_cap") = CLng(dr("cargo_ex_cap")) + CLng(dr("monto"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 4 Then
    '                        dr("tras_fondos_ex_cap") = CLng(dr("tras_fondos_ex_cap")) + CLng(dr("monto"))
    '                    End If
    '                End If

    '                'Cuenta de Excedentes de reparto
    '                If CInt(dr("cod_cuenta")) = 5 Then
    '                    'Aportes o ingreso de excedentes
    '                    If CInt(dr("cod_tipo_tran")) = 1 Or CInt(dr("cod_tipo_tran")) = 3 Then
    '                        'arrReporte(i).item("AbonoExRep")
    '                        dr("abono_ex_rep") = CLng(dr("abono_ex_rep")) + CLng(dr("monto"))
    '                        'Cargos por curso o VYT)
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 2 Or CInt(dr("cod_tipo_tran")) = 5 Then
    '                        'arrReporte(i).item("CargoExRep")
    '                        dr("cargo_ex_rep") = CLng(dr("cargo_ex_rep")) + CLng(dr("monto"))
    '                        'Traspasos de fondos
    '                    ElseIf CInt(dr("cod_tipo_tran")) = 4 Then
    '                        dr("tras_fondos_ex_rep") = CLng(dr("tras_fondos_ex_rep")) + CLng(dr("monto"))
    '                    End If
    '                End If

    '                dr("saldo_cap") = (CLng(dr("abono_cap")) - CLng(dr("cargo_cap"))) + CLng(dr("tras_fondos_cap"))
    '                dr("saldo_rep") = (CLng(dr("abono_rep")) - CLng(dr("cargo_rep"))) + CLng(dr("tras_fondos_rep"))
    '                dr("saldo_adm") = (CLng(dr("abono_adm")) - CLng(dr("cargo_adm"))) + CLng(dr("tras_fondos_adm"))
    '                dr("saldo_ex_cap") = (CLng(dr("abono_ex_cap")) - CLng(dr("cargo_ex_cap"))) + CLng(dr("tras_fondos_ex_cap"))
    '                dr("saldo_ex_rep") = (CLng(dr("abono_ex_rep")) - CLng(dr("cargo_ex_rep"))) + CLng(dr("tras_fondos_ex_rep"))
    '                dr("saldo_ex") = CLng(dr("saldo_ex_cap")) + CLng(dr("saldo_ex_rep"))

    '                '*******************************************************************
    '                '******************************************************************
    '                'Dim dt As DataTable
    '                'dt = New DataTable
    '                'dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '                'dt.Columns.Add(New DataColumn("monto1", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("monto2", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("monto3", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("monto4", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("monto5", GetType(Long)))
    '                ''dt.Columns.Add(New DataColumn("monto6", GetType(Long)))
    '                ''dt.Columns.Add(New DataColumn("monto7", GetType(Long)))
    '                ''dt.Columns.Add(New DataColumn("monto8", GetType(Long)))
    '                ''dt.Columns.Add(New DataColumn("monto9", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("razon_social", GetType(String)))
    '                'dt.Columns.Add(New DataColumn("nom_contacto", GetType(String)))
    '                'dt.Columns.Add(New DataColumn("fono_contacto", GetType(String)))
    '                'dt.Columns.Add(New DataColumn("nombre_ejecutivo", GetType(String)))
    '                'dt.Columns.Add(New DataColumn("nombre_sucursal", GetType(String)))
    '                'dt.Columns.Add(New DataColumn("horas", GetType(Integer)))
    '                'dt.Columns.Add(New DataColumn("hh", GetType(Integer)))
    '                'dt.Columns.Add(New DataColumn("cant_part", GetType(Integer)))
    '                'dt.Columns.Add(New DataColumn("abono_adm", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("cargo_adm", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("abono_ex_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("cargo_ex_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("abono_ex_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("cargo_ex_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("abono_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("cargo_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("saldo_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("abono_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("cargo_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("saldo_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("saldo_adm", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("saldo_ex_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("saldo_ex_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("saldo_ex", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("tras_fondos_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("tras_fondos_rep", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("tras_fondos_adm", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("tras_fondos_ex_cap", GetType(Long)))
    '                'dt.Columns.Add(New DataColumn("tras_fondos_ex_rep", GetType(Long)))
    '                'Dim drConsulta As DataRow
    '                'Dim drFinal As DataRow
    '                'For i = 0 To mintAgno
    '                '    'For Each drFinal In dtConsulta.Rows
    '                '    drFinal = dt.NewRow()
    '                '    dr = dtConsulta.NewRow()
    '                '    drFinal("rut_cliente") = dtConsulta.Rows(i)(0)
    '                '    'If dtConsulta.Rows(i)(0) <> dtConsulta.Rows(i - 1)(0) Then
    '                '    drFinal("monto1") = dtConsulta.Rows(i)(3)
    '                '    'End If
    '                '    'If dtConsulta.Rows(i)(0) = dtConsulta.Rows(i - 1)(0) Then
    '                '    drFinal("monto2") = dtConsulta.Rows(i)(3)
    '                '    'End If

    '                '    drFinal("monto2") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto3") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto4") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto5") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto6") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto7") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto8") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto9") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto10") = dtConsulta.Rows(i)(3)
    '                '    drFinal("monto11") = dtConsulta.Rows(i)(3)
    '                '    drFinal("razon_social") = dtConsulta.Rows(i)(4)
    '                '    drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '                '    drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '                '    drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '                '    drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '                '    drFinal("horas") = dtConsulta.Rows(i)(10)
    '                '    drFinal("hh") = dtConsulta.Rows(i)(11)
    '                '    drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '                '    drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '                '    drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '                '    drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '                '    drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '                '    drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '                '    drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '                '    drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '                '    drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '                '    drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '                '    drFinal("abono_rep") = dtConsulta.Rows(i)(21)
    '                '    drFinal("cargo_rep") = dtConsulta.Rows(i)(22)
    '                '    drFinal("saldo_rep") = dtConsulta.Rows(i)(23)
    '                '    drFinal("saldo_adm") = dtConsulta.Rows(i)(24)
    '                '    drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(25)
    '                '    drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(26)
    '                '    drFinal("saldo_ex") = dtConsulta.Rows(i)(27)
    '                '    drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(28)
    '                '    drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(29)
    '                '    drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(30)
    '                '    drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(31)
    '                '    drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(32)
    '                '    dt.Rows.Add(drFinal)

    '                'Next
    '                'Me.TablaFinal = dt

    '            Next

    '            Dim dt As DataTable
    '            dt = New DataTable
    '            dt.Columns.Add(New DataColumn("rut_cliente", GetType(String)))
    '            dt.Columns.Add(New DataColumn("cod_cuenta", GetType(Integer)))
    '            dt.Columns.Add(New DataColumn("cod_tipo_trans", GetType(Integer)))
    '            dt.Columns.Add(New DataColumn("monto", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("razon_social", GetType(String)))
    '            dt.Columns.Add(New DataColumn("nom_contacto", GetType(String)))
    '            dt.Columns.Add(New DataColumn("fono_contacto", GetType(String)))
    '            dt.Columns.Add(New DataColumn("anexo_contacto", GetType(String)))
    '            dt.Columns.Add(New DataColumn("nombre_ejecutivo", GetType(String)))
    '            dt.Columns.Add(New DataColumn("nombre_sucursal", GetType(String)))
    '            dt.Columns.Add(New DataColumn("horas", GetType(Integer)))
    '            dt.Columns.Add(New DataColumn("hh", GetType(Integer)))
    '            dt.Columns.Add(New DataColumn("cant_part", GetType(Integer)))
    '            dt.Columns.Add(New DataColumn("abono_adm", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("cargo_adm", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("abono_ex_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("cargo_ex_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("abono_ex_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("cargo_ex_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("abono_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("cargo_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("saldo_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("abono_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("cargo_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("saldo_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("saldo_adm", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("saldo_ex_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("saldo_ex_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("saldo_ex", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("tras_fondos_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("tras_fondos_rep", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("tras_fondos_adm", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("tras_fondos_ex_cap", GetType(Long)))
    '            dt.Columns.Add(New DataColumn("tras_fondos_ex_rep", GetType(Long)))
    '            'Dim drConsulta As DataRow
    '            Dim drFinal As DataRow
    '            For i = 0 To mintFilas - 1
    '                If i = 0 Then
    '                    'For Each drFinal In dtConsulta.Rows
    '                    drFinal = dt.NewRow()
    '                    'dr = dtConsulta.NewRow()
    '                    drFinal("rut_cliente") = dtConsulta.Rows(i)(0)
    '                    drFinal("cod_cuenta") = dtConsulta.Rows(i)(1)
    '                    drFinal("cod_tipo_trans") = dtConsulta.Rows(i)(2)
    '                    drFinal("monto") = dtConsulta.Rows(i)(3)
    '                    drFinal("razon_social") = dtConsulta.Rows(i)(4)
    '                    drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '                    drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '                    drFinal("anexo_contacto") = dtConsulta.Rows(i)(7)
    '                    drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '                    drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '                    drFinal("horas") = dtConsulta.Rows(i)(10)
    '                    drFinal("hh") = dtConsulta.Rows(i)(11)
    '                    drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '                    drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '                    drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '                    drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '                    drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '                    drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '                    drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '                    drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '                    drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '                    drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '                    drFinal("abono_rep") = dtConsulta.Rows(i)(22)
    '                    drFinal("cargo_rep") = dtConsulta.Rows(i)(23)
    '                    drFinal("saldo_rep") = dtConsulta.Rows(i)(24)
    '                    drFinal("saldo_adm") = dtConsulta.Rows(i)(25)
    '                    drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(26)
    '                    drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(27)
    '                    drFinal("saldo_ex") = dtConsulta.Rows(i)(28)
    '                    drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(29)
    '                    drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(30)
    '                    drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(31)
    '                    drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(32)
    '                    drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(33)
    '                    dt.Rows.Add(drFinal)
    '                Else
    '                    'For Each drFinal In dtConsulta.Rows
    '                    drFinal = dt.NewRow()
    '                    'dr = dtConsulta.NewRow()
    '                    If dtConsulta.Rows(i)(0) <> dtConsulta.Rows(i - 1)(0) Then
    '                        drFinal("rut_cliente") = dtConsulta.Rows(i)(0)
    '                        drFinal("cod_cuenta") = dtConsulta.Rows(i)(1)
    '                        drFinal("cod_tipo_trans") = dtConsulta.Rows(i)(2)
    '                        drFinal("monto") = dtConsulta.Rows(i)(3)
    '                        drFinal("razon_social") = dtConsulta.Rows(i)(4)
    '                        drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '                        drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '                        drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '                        drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '                        drFinal("horas") = dtConsulta.Rows(i)(10)
    '                        drFinal("hh") = dtConsulta.Rows(i)(11)
    '                        drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '                        drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '                        drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '                        drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '                        drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '                        drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '                        drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '                        drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '                        drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '                        drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '                        drFinal("abono_rep") = dtConsulta.Rows(i)(22)
    '                        drFinal("cargo_rep") = dtConsulta.Rows(i)(23)
    '                        drFinal("saldo_rep") = dtConsulta.Rows(i)(24)
    '                        drFinal("saldo_adm") = dtConsulta.Rows(i)(25)
    '                        drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(26)
    '                        drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(27)
    '                        drFinal("saldo_ex") = dtConsulta.Rows(i)(28)
    '                        drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(29)
    '                        drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(30)
    '                        drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(31)
    '                        drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(32)
    '                        drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(33)
    '                        dt.Rows.Add(drFinal)
    '                    Else
    '                        If dtConsulta.Rows(i)(0) <> dtConsulta.Rows(i - 1)(0) Then

    '                        End If
    '                        drFinal("abono_adm") = drFinal("abono_adm") + dtConsulta.Rows(i)(13)
    '                        drFinal("cargo_adm") = drFinal("cargo_adm") + dtConsulta.Rows(i)(14)
    '                        drFinal("abono_ex_cap") = drFinal("abono_ex_cap") + dtConsulta.Rows(i)(15)
    '                        drFinal("cargo_ex_cap") = drFinal("cargo_ex_cap") + dtConsulta.Rows(i)(16)
    '                        drFinal("abono_ex_rep") = drFinal("abono_ex_rep") + dtConsulta.Rows(i)(17)
    '                        drFinal("cargo_ex_rep") = drFinal("cargo_ex_rep") + dtConsulta.Rows(i)(18)
    '                        drFinal("abono_cap") = drFinal("abono_cap") + dtConsulta.Rows(i)(19)
    '                        drFinal("cargo_cap") = drFinal("cargo_cap") + dtConsulta.Rows(i)(20)
    '                        drFinal("saldo_cap") = drFinal("saldo_cap") + dtConsulta.Rows(i)(21)
    '                        drFinal("abono_rep") = drFinal("abono_rep") + dtConsulta.Rows(i)(22)
    '                        drFinal("cargo_rep") = drFinal("cargo_rep") + dtConsulta.Rows(i)(23)
    '                        drFinal("saldo_rep") = drFinal("saldo_rep") + dtConsulta.Rows(i)(24)
    '                        drFinal("saldo_adm") = drFinal("saldo_adm") + dtConsulta.Rows(i)(25)
    '                        drFinal("saldo_ex_cap") = drFinal("saldo_ex_cap") + dtConsulta.Rows(i)(26)
    '                        drFinal("saldo_ex_rep") = drFinal("saldo_ex_rep") + dtConsulta.Rows(i)(27)
    '                        drFinal("saldo_ex") = drFinal("saldo_ex") + dtConsulta.Rows(i)(28)
    '                        drFinal("tras_fondos_cap") = drFinal("tras_fondos_cap") + dtConsulta.Rows(i)(29)
    '                        drFinal("tras_fondos_rep") = drFinal("tras_fondos_rep") + dtConsulta.Rows(i)(30)
    '                        drFinal("tras_fondos_adm") = drFinal("tras_fondos_adm") + dtConsulta.Rows(i)(31)
    '                        drFinal("tras_fondos_ex_cap") = drFinal("tras_fondos_ex_cap") + dtConsulta.Rows(i)(32)
    '                        drFinal("tras_fondos_ex_rep") = drFinal("tras_fondos_ex_rep") + dtConsulta.Rows(i)(33)
    '                        'dt.Rows(i - 1)(13) = dtConsulta.Rows(i)(13)
    '                        'dt.Rows(i - 1)(14) = dtConsulta.Rows(i)(14)
    '                        'dt.Rows(i - 1)(15) = dtConsulta.Rows(i)(15)
    '                        'dt.Rows(i - 1)(16) = dtConsulta.Rows(i)(16)
    '                        'dt.Rows(i - 1)(17) = dtConsulta.Rows(i)(17)
    '                        'dt.Rows(i - 1)(18) = dtConsulta.Rows(i)(18)
    '                        'dt.Rows(i - 1)(19) = dtConsulta.Rows(i)(19)
    '                        'dt.Rows(i - 1)(20) = dtConsulta.Rows(i)(20)
    '                        'dt.Rows(i - 1)(21) = dtConsulta.Rows(i)(21)
    '                        'dt.Rows(i - 1)(22) = dtConsulta.Rows(i)(22)
    '                        'dt.Rows(i - 1)(23) = dtConsulta.Rows(i)(23)
    '                        'dt.Rows(i - 1)(24) = dtConsulta.Rows(i)(24)
    '                        'dt.Rows(i - 1)(25) = dtConsulta.Rows(i)(25)
    '                        'dt.Rows(i - 1)(26) = dtConsulta.Rows(i)(26)
    '                        'dt.Rows(i - 1)(27) = dtConsulta.Rows(i)(27)
    '                        'dt.Rows(i - 1)(28) = dtConsulta.Rows(i)(28)
    '                        'dt.Rows(i - 1)(29) = dtConsulta.Rows(i)(29)
    '                        'dt.Rows(i - 1)(30) = dtConsulta.Rows(i)(30)
    '                        'dt.Rows(i - 1)(31) = dtConsulta.Rows(i)(31)
    '                        'dt.Rows(i - 1)(32) = dtConsulta.Rows(i)(32)
    '                        'dt.Rows(i - 1)(33) = dtConsulta.Rows(i)(33)
    '                    End If



    '                    'drFinal("nom_contacto") = dtConsulta.Rows(i)(5)
    '                    'drFinal("fono_contacto") = dtConsulta.Rows(i)(6)
    '                    'drFinal("nombre_ejecutivo") = dtConsulta.Rows(i)(8)
    '                    'drFinal("nombre_sucursal") = dtConsulta.Rows(i)(9)
    '                    'drFinal("horas") = dtConsulta.Rows(i)(10)
    '                    'drFinal("hh") = dtConsulta.Rows(i)(11)
    '                    'drFinal("cant_part") = dtConsulta.Rows(i)(12)
    '                    'drFinal("abono_adm") = dtConsulta.Rows(i)(13)
    '                    'drFinal("cargo_adm") = dtConsulta.Rows(i)(14)
    '                    'drFinal("abono_ex_cap") = dtConsulta.Rows(i)(15)
    '                    'drFinal("cargo_ex_cap") = dtConsulta.Rows(i)(16)
    '                    'drFinal("abono_ex_rep") = dtConsulta.Rows(i)(17)
    '                    'drFinal("cargo_ex_rep") = dtConsulta.Rows(i)(18)
    '                    'drFinal("abono_cap") = dtConsulta.Rows(i)(19)
    '                    'drFinal("cargo_cap") = dtConsulta.Rows(i)(20)
    '                    'drFinal("saldo_cap") = dtConsulta.Rows(i)(21)
    '                    'drFinal("abono_rep") = dtConsulta.Rows(i)(21)
    '                    'drFinal("cargo_rep") = dtConsulta.Rows(i)(22)
    '                    'drFinal("saldo_rep") = dtConsulta.Rows(i)(23)
    '                    'drFinal("saldo_adm") = dtConsulta.Rows(i)(24)
    '                    'drFinal("saldo_ex_cap") = dtConsulta.Rows(i)(25)
    '                    'drFinal("saldo_ex_rep") = dtConsulta.Rows(i)(26)
    '                    'drFinal("saldo_ex") = dtConsulta.Rows(i)(27)
    '                    'drFinal("tras_fondos_cap") = dtConsulta.Rows(i)(28)
    '                    'drFinal("tras_fondos_rep") = dtConsulta.Rows(i)(29)
    '                    'drFinal("tras_fondos_adm") = dtConsulta.Rows(i)(30)
    '                    'drFinal("tras_fondos_ex_cap") = dtConsulta.Rows(i)(31)
    '                    'drFinal("tras_fondos_ex_rep") = dtConsulta.Rows(i)(32)
    '                    ' dt.Rows.Add(drFinal)

    '                    End If


    '            Next
    '            Me.TablaFinal = dt

    '            '    If Me.mblnBajarXml Then
    '            '        strNombreArchivo = NombreArchivoTmp("txt")
    '            '        dtConsulta.TableName = "Reporte Cursos"
    '            '        ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
    '            '        Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
    '            '    End If




    '            'End If

    '            If Me.mblnBajarXml Then
    '                strNombreArchivo = NombreArchivoTmp("txt")
    '                dtConsulta.TableName = "Reporte Cursos"
    '                ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
    '                Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
    '            End If




    '        End If






    '        Return dtConsulta


    '    Catch ex As Exception
    '        EnviaError("CReporteResumenCliente.vb:Consultar-->" & ex.Message)
    '    End Try

    'End Function

    'inicialización del objeto sql
    Public Sub Inicializar(ByRef objSql As CSql)
        mobjSql = objSql
    End Sub

    'inicialización de variables
    Private Sub Initialize()
        mlngRutCliente = 0
        mstrNombreCliente = ""
        mdtmFechaIni = DateSerial(Now.Year, 1, 1)  'primer día del año
        mdtmFechaFin = Now.Date   'hoy
        'Llenado de las Etiquetas para Impresión
        'ReDim marrEtiquetas(19)
        'marrEtiquetas(0) = "Rut Cliente"
        'marrEtiquetas(1) = "Nombre Cliente"
        'marrEtiquetas(2) = "Nombre Contacto"
        'marrEtiquetas(3) = "Fono Contacto"
        'marrEtiquetas(4) = "Anexo Contacto"
        'marrEtiquetas(5) = "Ejecutivo"
        'marrEtiquetas(6) = "Sucursal"
        'marrEtiquetas(7) = "Sucursal"
        'marrEtiquetas(8) = "Sucursal"
        'marrEtiquetas(9) = "Sucursal"
        'marrEtiquetas(10) = "Aportes Abonados Cuenta Cap."
        'marrEtiquetas(11) = "Cargos por Cursos Cuenta Cap."
        'marrEtiquetas(12) = "Saldo Cuenta Cap."
        'marrEtiquetas(13) = "Aportes Abonados Cuenta Rep."
        'marrEtiquetas(14) = "Cargos por Cursos Cuenta Rep."
        'marrEtiquetas(15) = "Saldo Cuenta Rep."
        ''marrEtiquetas(16) = "Abonos Cuenta Adm."
        ''marrEtiquetas(17) = "Cargos Cuenta Adm."
        'marrEtiquetas(16) = "Ganancias por Adm."
        ''marrEtiquetas(19) = "Abonos Cuenta Exed. Cap."
        ''marrEtiquetas(20) = "Cargos Cuenta Exed. Cap."
        'marrEtiquetas(17) = "Saldo Cuenta Exed. Cap."
        ''marrEtiquetas(22) = "Abonos Cuenta Exed. Rep."
        ''marrEtiquetas(23) = "Cargos Cuenta Exed. Rep."
        'marrEtiquetas(18) = "Saldo Cuenta Exed. Rep."
        '' marrEtiquetas(25) = "Deuda"
        'marrEtiquetas(19) = "Saldo Completo en Exed"
    End Sub

    
End Class
