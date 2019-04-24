Imports Clases
Imports Modulos
Imports System.Data
Public Class CMantenedorOtec
    Implements IMantenedor
    Private mlngFilas As Long
    Private mobjSql As New CSql
    Private mlngRut As Long
    Private mstrDigitoOtec As String
    Private mstrNombreFantasia As String
    Private mstrRazonSocial As String
    Private mstrSigla As String
    Private mstrEmail As String
    Private mstrFono As String
    Private mstrFono2 As String
    Private mstrFax As String
    Private mstrDireccion As String
    Private mlngCodComuna As Long
    Private mstrComuna As String
    Private mstrRegion As String
    Private mstrCasilla As String
    Private mstrCiudad As String
    Private mstrSitioWeb As String
    Private mstrContacto As String
    Private mstrCargo As String
    Private mstrFonoContacto As String
    Private mstrEmailContacto As String
    Private mdblTasaDescuento As Double
    Private mstrFaxContacto As String
    Private mstrRep1 As String
    Private mlngRutRep1 As Long
    Private mstrRutRep1Formato As String
    Private mstrDigitoRep1 As String
    Private mstrRep2 As String
    Private mlngRutRep2 As Long
    Private mstrRutRep2Formato As String
    Private mstrDigitoRep2 As String
    Private mstrgtegeneral As String
    Private mstrgteRRHH As String
    Private mstrAreaCobranzas As String
    Private mstrGiro As String
    Private mstrCodActEco As String
    Private mintCodRubro As Integer
    Private mstrNombreRubro As String
    Private mlngNumConvenio As Long
    Private mstrObservacion As String
    Private mlngRutUsuario As Long
    Private mstrNroDireccion As String
    Private mstrRutFormato As String
    Private mcolEliminados As System.Collections.ArrayList
    Private mstrXml As String
    'Private mlngFilas As Long
    Private mblnBajarXml As Boolean
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
    Public Property RutOtec() As Long
        Get
            Return mlngRut
        End Get
        Set(ByVal value As Long)
            mlngRut = value
        End Set
    End Property
    Public Property DigitoOtec() As String
        Get
            Return mstrDigitoOtec
        End Get
        Set(ByVal value As String)
            mstrDigitoOtec = value
        End Set
    End Property
    Public Property Nombre() As String
        Get
            Return Me.mstrNombreFantasia
        End Get
        Set(ByVal value As String)
            mstrNombreFantasia = value
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
    Public Property Sigla() As String
        Get
            Return mstrSigla
        End Get
        Set(ByVal value As String)
            mstrSigla = value
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
    Public Property Fono2() As String
        Get
            Return mstrFono2
        End Get
        Set(ByVal value As String)
            mstrFono2 = value
        End Set
    End Property
    Public Property Fax() As String
        Get
            Return mstrFax
        End Get
        Set(ByVal value As String)
            mstrFax = value
        End Set
    End Property
    Public Property Direccion() As String
        Get
            Return mstrDireccion
        End Get
        Set(ByVal value As String)
            mstrDireccion = value
        End Set
    End Property
    Public Property CodigoComuna() As Long
        Get
            Return mlngCodComuna
        End Get
        Set(ByVal value As Long)
            mlngCodComuna = value
        End Set
    End Property
    Public Property NombreComuna() As String
        Get
            Return mstrComuna
        End Get
        Set(ByVal value As String)
            mstrComuna = value
        End Set
    End Property
    Public Property Casilla() As String
        Get
            Return mstrCasilla
        End Get
        Set(ByVal value As String)
            mstrCasilla = value
        End Set
    End Property
    Public Property Ciudad() As String
        Get
            Return mstrCiudad
        End Get
        Set(ByVal value As String)
            mstrCiudad = value
        End Set
    End Property
    Public Property Region() As String
        Get
            Return mstrRegion
        End Get
        Set(ByVal value As String)
            mstrRegion = value
        End Set
    End Property
    Public Property SitioWeb() As String
        Get
            Return mstrSitioWeb
        End Get
        Set(ByVal value As String)
            mstrSitioWeb = value
        End Set
    End Property
    Public Property NombreContacto() As String
        Get
            Return mstrContacto
        End Get
        Set(ByVal value As String)
            mstrContacto = value
        End Set
    End Property
    Public Property CargoContacto() As String
        Get
            Return mstrCargo
        End Get
        Set(ByVal value As String)
            mstrCargo = value
        End Set
    End Property
    Public Property FonoContacto() As String
        Get
            Return mstrFonoContacto
        End Get
        Set(ByVal value As String)
            mstrFonoContacto = value
        End Set
    End Property

    Public Property EmailContacto() As String
        Get
            Return mstrEmailContacto
        End Get
        Set(ByVal value As String)
            mstrEmailContacto = value
        End Set
    End Property

    'Tasa de Descuento
    Public Property TasaDescuento() As Double
        Get
            Return mdblTasaDescuento
        End Get
        Set(ByVal value As Double)
            mdblTasaDescuento = value
        End Set
    End Property
    Public Property FaxContacto() As String
        Get
            Return mstrFaxContacto
        End Get
        Set(ByVal value As String)
            mstrFaxContacto = value
        End Set
    End Property

    Public Property NombreRep1() As String
        Get
            Return mstrRep1
        End Get
        Set(ByVal value As String)
            mstrRep1 = value
        End Set
    End Property
    Public Property RutRep1() As Long
        Get
            Return mlngRutRep1
        End Get
        Set(ByVal value As Long)
            mlngRutRep1 = value
        End Set
    End Property
    Public Property RutFormateadoRep1() As String
        Get
            Return mstrRutRep1Formato
        End Get
        Set(ByVal value As String)
            mstrRutRep1Formato = value
        End Set
    End Property
    Public Property DigitoRep1() As String
        Get
            Return mstrDigitoRep1
        End Get
        Set(ByVal value As String)
            mstrDigitoRep1 = value
        End Set
    End Property
    Public Property NombreRep2() As String
        Get
            Return mstrRep2
        End Get
        Set(ByVal value As String)
            mstrRep2 = value
        End Set
    End Property
    Public Property RutRep2() As Long
        Get
            Return mlngRutRep2
        End Get
        Set(ByVal value As Long)
            mlngRutRep2 = value
        End Set
    End Property
    Public Property RutFormateadoRep2() As String
        Get
            Return mstrRutRep2Formato
        End Get
        Set(ByVal value As String)
            mstrRutRep2Formato = value
        End Set
    End Property
    Public Property DigitoRep2() As String
        Get
            Return mstrDigitoRep2
        End Get
        Set(ByVal value As String)
            mstrDigitoRep2 = value
        End Set
    End Property

    Public Property GerenteGeneral() As String
        Get
            Return mstrgtegeneral
        End Get
        Set(ByVal value As String)
            mstrgtegeneral = value
        End Set
    End Property
    Public Property GerenteRRHH() As String
        Get
            Return mstrgteRRHH
        End Get
        Set(ByVal value As String)
            mstrgteRRHH = value
        End Set
    End Property
    Public Property AreaCobranzas() As String
        Get
            Return mstrAreaCobranzas
        End Get
        Set(ByVal value As String)
            mstrAreaCobranzas = value
        End Set
    End Property
    Public Property Giro() As String
        Get
            Return mstrGiro
        End Get
        Set(ByVal value As String)
            mstrGiro = value
        End Set
    End Property
    Public Property CodActEconomica() As String
        Get
            CodActEconomica = mstrCodActEco
        End Get
        Set(ByVal value As String)
            mstrCodActEco = value
        End Set
    End Property
    Public Property CodigoRubro() As Integer
        Get
            Return mintCodRubro
        End Get
        Set(ByVal value As Integer)
            mintCodRubro = value
        End Set
    End Property
    Public Property NombreRubro() As String
        Get
            Return mstrNombreRubro
        End Get
        Set(ByVal value As String)
            mstrNombreRubro = value
        End Set
    End Property
    Public Property NumConvenio() As Long
        Get
            Return mlngNumConvenio
        End Get
        Set(ByVal value As Long)
            mlngNumConvenio = value
        End Set
    End Property
    Public Property NroDireccion() As String
        Get
            Return mstrNroDireccion
        End Get
        Set(ByVal value As String)
            mstrNroDireccion = value
        End Set
    End Property
    Public Function Actualizar() As Boolean Implements Clases.IMantenedor.Actualizar
        Try
            Call mobjSql.InicioTransaccion()

            Call mobjSql.u_Persona_Juridica(mlngRut, mstrNombreFantasia, _
                                            mstrRazonSocial, mstrSigla, _
                                            mstrEmail, mstrFono, _
                                            mstrFono2, mstrFax, _
                                            mstrDireccion, mlngCodComuna, _
                                            mstrCasilla, mstrSitioWeb, mstrCiudad, mstrNroDireccion)

            Call mobjSql.u_Otec(mlngRut, mstrContacto, mstrCargo, _
                                mstrFonoContacto, mstrEmailContacto, _
                                mstrFaxContacto, mintCodRubro, mstrRep1, _
                                mlngRutRep1, mstrDigitoRep1, mstrRep2, _
                                mlngRutRep2, mstrDigitoRep2, mstrgtegeneral, _
                                mstrgteRRHH, mstrAreaCobranzas, mstrGiro, _
                                mstrCodActEco, mlngNumConvenio, mdblTasaDescuento)

            'cerrar transaccion
            Call mobjSql.FinTransaccion()
        Catch ex As Exception
            EnviaError("CMantenedorOtec.vb:Actualizar-->" & ex.Message)
        End Try
    End Function

    Public Property colEliminacion() As System.Collections.ArrayList Implements Clases.IMantenedor.colEliminacion
        Get
            Return mcolEliminados
        End Get
        Set(ByVal value As System.Collections.ArrayList)
            mcolEliminados = value
        End Set
    End Property

    Public Function Consultar() As System.Data.DataTable Implements Clases.IMantenedor.Consultar
        Dim dtConsulta As DataTable
        Dim strNombreArchivo As String
        dtConsulta = mobjSql.s_Otec2(mlngRut, mstrNombreFantasia, mstrRazonSocial)

        If Me.mblnBajarXml Then
            strNombreArchivo = NombreArchivoTmp("csv")
            dtConsulta.TableName = "Reporte Empresa"
            ConvierteDTaCSV(dtConsulta, DIRFISICOAPP() & "\contenido\tmp\", strNombreArchivo)
            Me.mstrXml = "~" & "/contenido/tmp/" & strNombreArchivo
        End If
        Return dtConsulta
    End Function

    Public Function Eliminar() As Boolean Implements Clases.IMantenedor.Eliminar
        Try
            Dim lngRutOtec As Long
            lngRutOtec = RutOtec
            mobjSql.InicioTransaccion()
            'mobjSql.d_rut(lngRutOtec)
            Call mobjSql.d_Otec(lngRutOtec)
            Call mobjSql.d_ejecutivo(lngRutOtec)

            'Call mobjSql.d_CuentaCliente(Datos(0, i))
            'Solo si no existe el mismo rut como empresa_cliente se permite borrar
            'en la tabla persona_juridica
            If mobjSql.ExisteRegistro(lngRutOtec, "Empresa_cliente") = False Then
                Call mobjSql.d_Persona_Juridica(lngRutOtec)
                If mobjSql.ExisteRegistro(lngRutOtec, "Usuario") = False Then
                    Call mobjSql.d_Persona(lngRutOtec)
                End If
            End If
            Eliminar = True
            mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            Eliminar = False
        End Try
    End Function

    Public ReadOnly Property Filas() As Integer Implements Clases.IMantenedor.Filas
        Get
            Return mlngFilas
        End Get
    End Property

    Public Sub InicializarNuevo() Implements Clases.IMantenedor.InicializarNuevo

        Dim dtOtec1 As DataTable

        dtOtec1 = mobjSql.s_Otec_PersonaJuridica(Me.mlngRut)

        If IsNothing(dtOtec1) Then
            Exit Sub
        End If

        'asignación de valores        
        mstrRutFormato = RutLngAUsr(mlngRut)
        If dtOtec1.Rows.Count > 0 Then
            mstrDigitoOtec = dtOtec1.Rows(0)("dig_verif")
            mstrNombreFantasia = dtOtec1.Rows(0)("nom_fantasia")
            mstrRazonSocial = dtOtec1.Rows(0)("razon_social")
            mstrSigla = dtOtec1.Rows(0)("sigla")
            mstrEmail = dtOtec1.Rows(0)("email")
            mstrFono = dtOtec1.Rows(0)("fono")
            If IsDBNull(dtOtec1.Rows(0)("fono2")) Then
                mstrFono2 = ""
            Else
                mstrFono2 = dtOtec1.Rows(0)("fono2")
            End If
            If IsDBNull(dtOtec1.Rows(0)("fax")) Then
                mstrFax = ""
            Else
                mstrFax = dtOtec1.Rows(0)("fax")
            End If
            mstrDireccion = dtOtec1.Rows(0)("direccion")
            mlngCodComuna = dtOtec1.Rows(0)("cod_comuna")
            mstrComuna = dtOtec1.Rows(0)("nombre_comuna")
            If IsDBNull(dtOtec1.Rows(0)("casilla")) Then
                mstrCasilla = ""
            Else
                mstrCasilla = dtOtec1.Rows(0)("casilla")
            End If
            mstrCiudad = dtOtec1.Rows(0)("ciudad")
            If IsDBNull(dtOtec1.Rows(0)("SitioWeb")) Then
                mstrSitioWeb = ""
            Else
                mstrSitioWeb = dtOtec1.Rows(0)("SitioWeb")
            End If
            mstrRegion = dtOtec1.Rows(0)("nombre_Region")

            If IsDBNull(dtOtec1.Rows(0)("nombre_contacto")) Then
                mstrContacto = ""
            Else
                mstrContacto = dtOtec1.Rows(0)("nombre_contacto")
            End If
            If IsDBNull(dtOtec1.Rows(0)("cargo_contacto")) Then
                mstrCargo = ""
            Else
                mstrCargo = dtOtec1.Rows(0)("cargo_contacto")
            End If
            If IsDBNull(dtOtec1.Rows(0)("fono_contacto")) Then
                mstrFonoContacto = ""
            Else
                mstrFonoContacto = dtOtec1.Rows(0)("fono_contacto")
            End If
            If IsDBNull(dtOtec1.Rows(0)("email_contacto")) Then
                mstrEmailContacto = ""
            Else
                mstrEmailContacto = dtOtec1.Rows(0)("email_contacto")
            End If
            If IsDBNull(dtOtec1.Rows(0)("tasa_descuento")) Then
                mdblTasaDescuento = 0
            Else
                mdblTasaDescuento = dtOtec1.Rows(0)("tasa_descuento")
            End If
            If IsDBNull(dtOtec1.Rows(0)("fax_contacto")) Then
                mstrFaxContacto = ""
            Else
                mstrFaxContacto = dtOtec1.Rows(0)("fax_contacto")
            End If
            If IsDBNull(dtOtec1.Rows(0)("cod_rubro")) Then
                mintCodRubro = 0
            Else
                mintCodRubro = dtOtec1.Rows(0)("cod_rubro")
            End If
            If IsDBNull(dtOtec1.Rows(0)("nom_rep1")) Then
                mstrRep1 = ""
            Else
                mstrRep1 = dtOtec1.Rows(0)("nom_rep1")
            End If
            If IsDBNull(dtOtec1.Rows(0)("rut_rep1")) Then
                mlngRutRep1 = -1
                mstrRutRep1Formato = ""
            Else
                mlngRutRep1 = dtOtec1.Rows(0)("rut_rep1")
                mstrRutRep1Formato = RutLngAUsr(dtOtec1.Rows(0)("rut_rep1"))
            End If
            If IsDBNull(dtOtec1.Rows(0)("dig_verif_rep1")) Then
                mstrDigitoRep1 = ""
            Else
                mstrDigitoRep1 = dtOtec1.Rows(0)("dig_verif_rep1")
            End If
            If IsDBNull(dtOtec1.Rows(0)("nom_rep2")) Then
                mstrRep2 = ""
            Else
                mstrRep2 = dtOtec1.Rows(0)("nom_rep2")
            End If
            If IsDBNull(dtOtec1.Rows(0)("rut_rep2")) Then
                mlngRutRep2 = -1
                mstrRutRep2Formato = ""
            Else
                mlngRutRep2 = dtOtec1.Rows(0)("rut_rep2")
                mstrRutRep2Formato = RutLngAUsr(dtOtec1.Rows(0)("rut_rep2"))
            End If
            If IsDBNull(dtOtec1.Rows(0)("dig_verif_rep2")) Then
                mstrDigitoRep2 = ""
            Else
                mstrDigitoRep2 = dtOtec1.Rows(0)("dig_verif_rep2")
            End If
            If IsDBNull(dtOtec1.Rows(0)("gerente_general")) Then
                mstrgtegeneral = ""
            Else
                mstrgtegeneral = dtOtec1.Rows(0)("gerente_general")
            End If
            If IsDBNull(dtOtec1.Rows(0)("gerente_RRHH")) Then
                mstrgteRRHH = ""
            Else
                mstrgteRRHH = dtOtec1.Rows(0)("gerente_RRHH")
            End If
            If IsDBNull(dtOtec1.Rows(0)("area_cobranzas")) Then
                mstrAreaCobranzas = ""
            Else
                mstrAreaCobranzas = dtOtec1.Rows(0)("area_cobranzas")
            End If
            If IsDBNull(dtOtec1.Rows(0)("giro")) Then
                mstrGiro = ""
            Else
                mstrGiro = dtOtec1.Rows(0)("giro")
            End If
            If IsDBNull(dtOtec1.Rows(0)("cod_act_economica")) Then
                mstrCodActEco = ""
            Else
                mstrCodActEco = dtOtec1.Rows(0)("cod_act_economica")
            End If
            If IsDBNull(dtOtec1.Rows(0)("num_convenio")) Then
                mlngNumConvenio = 0
            Else
                mlngNumConvenio = dtOtec1.Rows(0)("num_convenio")
            End If
            If IsDBNull(dtOtec1.Rows(0)("nombre_rubro")) Then
                mstrNombreRubro = ""
            Else
                mstrNombreRubro = dtOtec1.Rows(0)("nombre_rubro")
            End If
            mstrNroDireccion = IIf(IsDBNull(dtOtec1.Rows(0)("nro_direccion")), "", dtOtec1.Rows(0)("nro_direccion"))
        End If

    End Sub
    Public Function Insertar() As Boolean Implements Clases.IMantenedor.Insertar
        Try
            Call mobjSql.InicioTransaccion()

            If Not mobjSql.ExisteRegistro(mlngRut, "Persona") Then
                Call mobjSql.i_Persona(mlngRut, mstrDigitoOtec, "J")
            End If

            If mobjSql.ExisteRegistro(mlngRut, "Persona") Then
                If Not mobjSql.ExisteRegistro(mlngRut, "Persona_juridica") Then
                    Call mobjSql.i_Persona_Juridica(mlngRut, mstrNombreFantasia, _
                                            mstrRazonSocial, mstrSigla, _
                                            mstrEmail, mstrFono, _
                                            mstrFono2, mstrFax, _
                                            mstrDireccion, mlngCodComuna, _
                                            mstrCasilla, mstrCiudad, mstrSitioWeb, mstrNroDireccion)

                    Call mobjSql.i_otec(mlngRut, mstrContacto, _
                                        mstrCargo, mstrFonoContacto, _
                                        mstrEmailContacto, mstrFaxContacto, _
                                        mintCodRubro, mstrRep1, mlngRutRep1, _
                                        mstrDigitoRep1, mstrRep2, mlngRutRep2, _
                                        mstrDigitoRep2, mstrgtegeneral, mstrgteRRHH, _
                                        mstrAreaCobranzas, mstrGiro, mstrCodActEco, _
                                        mlngNumConvenio, mdblTasaDescuento)


                Else
                    'actualiza persona juridica
                    Call mobjSql.u_Persona_Juridica(mlngRut, mstrNombreFantasia, _
                                              mstrRazonSocial, mstrSigla, _
                                              mstrEmail, mstrFono, _
                                              mstrFono2, mstrFax, _
                                              mstrDireccion, mlngCodComuna, _
                                              mstrCasilla, mstrSitioWeb, mstrCiudad, mstrNroDireccion)
                    If Not mobjSql.ExisteRegistro(mlngRut, "Otec") Then
                        'inserta en Otec
                        Call mobjSql.i_otec(mlngRut, mstrContacto, _
                                        mstrCargo, mstrFonoContacto, _
                                        mstrEmailContacto, mstrFaxContacto, _
                                        mintCodRubro, mstrRep1, mlngRutRep1, _
                                        mstrDigitoRep1, mstrRep2, mlngRutRep2, _
                                        mstrDigitoRep2, mstrgtegeneral, mstrgteRRHH, _
                                        mstrAreaCobranzas, mstrGiro, mstrCodActEco, _
                                        mlngNumConvenio, mdblTasaDescuento)
                    End If
                End If
            End If

            Call mobjSql.FinTransaccion()
        Catch ex As Exception
            mobjSql.RollBackTransaccion()
            EnviaError("CMantenedorOtec.vb:Insertar-->" & ex.Message)
        End Try
    End Function
End Class
