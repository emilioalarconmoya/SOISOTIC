Imports Microsoft.VisualBasic
Imports Clases
Imports Modulos
Imports System.Data
Namespace Clases

    Public Class COtec
        Private objSession As New CSession
        'consultas sql y objetos de conexion
        Private mblnBajarXml As Boolean
        Private mstrXml As String
        Private mlngFilas As Long
        'objeto de coneccion a bd y de implements ireporte
        Private mobjSql As CSql

        'Rut Otec
        Private mlngRut As Long
        'Rut con Formato del Otec
        Private mstrRutFormato As String
        'Digito verificador Otec
        Private mstrDigitoOtec As String
        'Nombre Fantasia
        Private mstrNombreFantasia As String
        'Razon Social
        Private mstrRazonSocial As String
        'Sigla
        Private mstrSigla As String
        'Email Otec
        Private mstrEmail As String
        'Fono Otec
        Private mstrFono As String
        'Fono 2 Otec
        Private mstrFono2 As String
        'Fax Otec
        Private mstrFax As String
        'Direccion Otec
        Private mstrDireccion As String
        'Codigo Comuna
        Private mlngCodComuna As Long
        'Nombre Comuna
        Private mstrComuna As String
        'Nombre Region
        Private mstrRegion As String
        'Casilla
        Private mstrCasilla As String
        'Ciudad
        Private mstrCiudad As String
        'Sitio Web
        Private mstrSitioWeb As String
        'Nombre Contacto
        Private mstrContacto As String
        'Cargo Contacto
        Private mstrCargo As String
        'Fono Contacto
        Private mstrFonoContacto As String
        'Email Contacto
        Private mstrEmailContacto As String
        'Tasa de Descuento
        Private mdblTasaDescuento As Double
        'Fax Contacto
        Private mstrFaxContacto As String
        'Nombre Representante Legal 1
        Private mstrRep1 As String
        'Rut Representante Legal 1
        Private mlngRutRep1 As Long
        'Rut Representante Legal 1 con Formato
        Private mstrRutRep1Formato As String
        'Digito verificador Representante Legal 1
        Private mstrDigitoRep1 As String
        'Nombre Representante Legal 2
        Private mstrRep2 As String
        'Rut Representante Legal 2
        Private mlngRutRep2 As Long
        'Rut Representante Legal 2 con Formato
        Private mstrRutRep2Formato As String
        'Digito verificador Representante Legal 2
        Private mstrDigitoRep2 As String
        'Gerente General
        Private mstrGtegeneral As String
        'Gerente Recursos Humanos
        Private mstrGteRRHH As String
        'Area Cobranzas
        Private mstrAreaCobranzas As String
        'Giro
        Private mstrGiro As String
        'Cod actividad Economica
        Private mstrCodActEco As String
        'Codigo Rubro
        Private mintCodRubro As Integer
        'Nombre Rubro
        Private mstrNombreRubro As String
        'Numero Convenio
        Private mlngNumConvenio As Long
        'arreglo para el lookup de rubros
        Private mdtLookUpRubros As DataTable
        'arreglo para el lookup de comunas
        Private mdtLookUpComunas As DataTable
        'Observación Cambios efectuados
        Private mstrObservacion As String
        'rut del usuario conectado
        Private mlngRutUsuario As Long
        '--------------------------------------
        'nro de la direccion
        Private mstrNroDireccion As String
        'taza de descuento


        Private mdtOtec As DataTable

        Public Property Rut() As Long
            Get
                Return Me.mlngRut
            End Get
            Set(ByVal value As Long)
                Me.mlngRut = value
            End Set
        End Property
        'Public ReadOnly Property Rut() As Long
        '    Get
        '        Return mlngRut
        '    End Get
        'End Property
        Public Property Rutotec() As Long
            Get
                Return Me.mlngRut
            End Get
            Set(ByVal value As Long)
                Me.mlngRut = value
            End Set
        End Property
       
        'Public ReadOnly Property Rutotec() As String
        '    Get
        '        Rutotec = RutLngAUsr(mlngRut)
        '    End Get
        'End Property
        Public ReadOnly Property RutFormateadoOtec() As String
            Get
                RutFormateadoOtec = mlngRut
            End Get
        End Property

        Public ReadOnly Property RutFormato() As String
            Get
                Return mstrRutFormato
            End Get
        End Property
        Public ReadOnly Property DigitoOtec() As String
            Get
                Return mstrDigitoOtec
            End Get
        End Property
        Public ReadOnly Property NombreFantasia() As String
            Get
                Return mstrNombreFantasia
            End Get
        End Property
        'Public ReadOnly Property RazonSocial() As String
        '    Get
        '        Return mstrRazonSocial
        '    End Get
        'End Property
        Public Property RazonSocial() As String
            Get
                Return mstrRazonSocial
            End Get
            Set(ByVal value As String)
                mstrRazonSocial = value
            End Set
        End Property
        Public ReadOnly Property Sigla() As String
            Get
                Return mstrSigla
            End Get
        End Property
        Public Property Email() As String
            Get
                Return Me.mstrEmail
            End Get
            Set(ByVal value As String)
                Me.mstrEmail = value
            End Set
        End Property
        'Public ReadOnly Property Email() As String
        '    Get
        '        Return mstrEmail
        '    End Get
        'End Property
        Public ReadOnly Property Fono() As String
            Get
                Return mstrFono
            End Get
        End Property
        Public ReadOnly Property Fono2() As String
            Get
                Return mstrFono2
            End Get
        End Property
        Public ReadOnly Property Fax() As String
            Get
                Return mstrFax
            End Get
        End Property
        Public Property Direccion() As String
            Get
                Return Me.mstrDireccion
            End Get
            Set(ByVal value As String)
                Me.mstrDireccion = value
            End Set
        End Property
        'Public ReadOnly Property Direccion() As String
        '    Get
        '        Return mstrDireccion
        '    End Get
        'End Property
        Public ReadOnly Property CodComuna() As Long
            Get
                Return mlngCodComuna
            End Get
        End Property
        Public Property Comuna() As String
            Get
                Return Me.mstrComuna
            End Get
            Set(ByVal value As String)
                Me.mstrComuna = value
            End Set
        End Property
        'Public ReadOnly Property Comuna() As String
        '    Get
        '        Return mstrComuna
        '    End Get
        'End Property
        Public Property Region() As String
            Get
                Return Me.mstrRegion
            End Get
            Set(ByVal value As String)
                Me.mstrRegion = value
            End Set
        End Property
        'Public ReadOnly Property Region() As String
        '    Get
        '        Return mstrRegion
        '    End Get
        'End Property
        Public ReadOnly Property Casilla() As String
            Get
                Return mstrCasilla
            End Get
        End Property
        Public ReadOnly Property Ciudad() As String
            Get
                Return mstrCiudad
            End Get
        End Property
        Public ReadOnly Property SitioWeb() As String
            Get
                Return mstrSitioWeb
            End Get
        End Property
        Public Property Contacto() As String
            Get
                Return Me.mstrContacto
            End Get
            Set(ByVal value As String)
                Me.mstrContacto = value
            End Set
        End Property
        'Public ReadOnly Property Contacto() As String
        '    Get
        '        Return mstrContacto
        '    End Get
        'End Property
        Public Property Cargo() As String
            Get
                Return Me.mstrCargo
            End Get
            Set(ByVal value As String)
                Me.mstrCargo = value
            End Set
        End Property
        'Public ReadOnly Property Cargo() As String
        '    Get
        '        Return mstrCargo
        '    End Get
        'End Property
        Public Property FonoContacto() As String
            Get
                Return Me.mstrFonoContacto
            End Get
            Set(ByVal value As String)
                Me.mstrFonoContacto = value
            End Set
        End Property
        'Public ReadOnly Property FonoContacto() As String
        '    Get
        '        Return mstrFonoContacto
        '    End Get
        'End Property
        Public Property EmailContacto() As String
            Get
                Return Me.mstrEmailContacto
            End Get
            Set(ByVal value As String)
                Me.mstrEmailContacto = value
            End Set
        End Property
        'Public ReadOnly Property EmailContacto() As String
        '    Get
        '        Return mstrEmailContacto
        '    End Get
        'End Property
        Public Property TasaDescuento() As Double
            Get
                Return Me.mdblTasaDescuento
            End Get
            Set(ByVal value As Double)
                Me.mdblTasaDescuento = value
            End Set
        End Property
        'Public ReadOnly Property TasaDescuento() As Double
        '    Get
        '        Return mdblTasaDescuento
        '    End Get
        'End Property
        Public Property FaxContacto() As String
            Get
                Return Me.mstrFaxContacto
            End Get
            Set(ByVal value As String)
                Me.mstrFaxContacto = value
            End Set
        End Property
        'Public ReadOnly Property FaxContacto() As String
        '    Get
        '        Return mstrFaxContacto
        '    End Get
        'End Property
        Public Property Rep1() As String
            Get
                Return Me.mstrRep1
            End Get
            Set(ByVal value As String)
                Me.mstrRep1 = value
            End Set
        End Property
        'Public ReadOnly Property Rep1() As String
        '    Get
        '        Return mstrRep1
        '    End Get
        'End Property
        Public Property RutRep1() As Long
            Get
                Return Me.mlngRutRep1
            End Get
            Set(ByVal value As Long)
                Me.mlngRutRep1 = value
            End Set
        End Property
        'Public ReadOnly Property RutRep1() As Long
        '    Get
        '        Return mlngRutRep1
        '    End Get
        'End Property
        Public ReadOnly Property RutRep1Formato() As String
            Get
                Return mstrRutRep1Formato
            End Get
        End Property
        Public ReadOnly Property DigitoRep1() As String
            Get
                Return mstrDigitoRep1
            End Get
        End Property
        Public Property Rep2() As String
            Get
                Return Me.mstrRep2
            End Get
            Set(ByVal value As String)
                Me.mstrRep2 = value
            End Set
        End Property
        'Public ReadOnly Property Rep2() As String
        '    Get
        '        Return mstrRep2
        '    End Get
        'End Property
        Public Property RutRep2() As Long
            Get
                Return Me.mlngRutRep2
            End Get
            Set(ByVal value As Long)
                Me.mlngRutRep2 = value
            End Set
        End Property
        'Public ReadOnly Property RutRep2() As Long
        '    Get
        '        Return mlngRutRep2
        '    End Get
        'End Property
        Public ReadOnly Property RutRep2Formato() As Long
            Get
                Return mstrRutRep2Formato
            End Get
        End Property
        Public ReadOnly Property DigitoRep2() As String
            Get
                Return mstrDigitoRep2
            End Get
        End Property
        Public Property Gtegeneral() As String
            Get
                Return Me.mstrGtegeneral
            End Get
            Set(ByVal value As String)
                Me.mstrGtegeneral = value
            End Set
        End Property
        'Public ReadOnly Property Gtegeneral() As String
        '    Get
        '        Return mstrGtegeneral
        '    End Get
        'End Property
        Public Property GteRRHH() As String
            Get
                Return Me.mstrGteRRHH
            End Get
            Set(ByVal value As String)
                Me.mstrGteRRHH = value
            End Set
        End Property
        'Public ReadOnly Property GteRRHH() As String
        '    Get
        '        Return mstrGteRRHH
        '    End Get
        'End Property
        Public Property AreaCobranzas() As String
            Get
                Return Me.mstrAreaCobranzas
            End Get
            Set(ByVal value As String)
                Me.mstrAreaCobranzas = value
            End Set
        End Property
        'Public ReadOnly Property AreaCobranzas() As String
        '    Get
        '        Return mstrAreaCobranzas
        '    End Get
        'End Property
        Public Property Giro() As String
            Get
                Return Me.mstrGiro
            End Get
            Set(ByVal value As String)
                Me.mstrGiro = value
            End Set
        End Property
        'Public ReadOnly Property Giro() As String
        '    Get
        '        Return mstrGiro
        '    End Get
        'End Property
        Public Property CodActEco() As String
            Get
                Return Me.mstrCodActEco
            End Get
            Set(ByVal value As String)
                Me.mstrCodActEco = value
            End Set
        End Property
        'Public ReadOnly Property CodActEco() As String
        '    Get
        '        Return mstrCodActEco
        '    End Get
        'End Property
        Public ReadOnly Property CodRubro() As Integer
            Get
                Return mintCodRubro
            End Get
        End Property
        Public Property NombreRubro() As String
            Get
                Return Me.mstrNombreRubro
            End Get
            Set(ByVal value As String)
                Me.mstrNombreRubro = value
            End Set
        End Property
        'Public ReadOnly Property NombreRubro() As String
        '    Get
        '        Return mstrNombreRubro
        '    End Get
        'End Property
        Public Property NumConvenio() As Long
            Get
                Return Me.mlngNumConvenio
            End Get
            Set(ByVal value As Long)
                Me.mlngNumConvenio = value
            End Set
        End Property
        'Public ReadOnly Property NumConvenio() As Long
        '    Get
        '        Return mlngNumConvenio
        '    End Get
        'End Property
        Public ReadOnly Property LookUpRubros() As DataTable
            Get
                Return mdtLookUpRubros
            End Get
        End Property
        Public ReadOnly Property LookUpComunas() As DataTable
            Get
                Return mdtLookUpComunas
            End Get
        End Property
        Public ReadOnly Property Observacion() As String
            Get
                Return mstrObservacion
            End Get
        End Property
        Public Property RutUsuario() As Long
            Get
                Return Me.mlngRutUsuario
            End Get
            Set(ByVal value As Long)
                Me.mlngRutUsuario = value
            End Set
        End Property
        'Public ReadOnly Property RutUsuario() As Long
        '    Get
        '        Return mlngRutUsuario
        '    End Get
        'End Property
        Public ReadOnly Property NroDireccion() As String
            Get
                Return mstrNroDireccion
            End Get
        End Property
        Public ReadOnly Property Otec() As DataTable
            Get
                Return mdtOtec
            End Get
        End Property


        Public Sub New()

            mlngRut = 0
            mstrRutFormato = ""
            mstrDigitoOtec = ""
            mstrNombreFantasia = ""
            mstrRazonSocial = ""
            mstrSigla = ""
            mstrEmail = ""
            mstrFono = ""
            mstrFono2 = ""
            mstrFax = ""
            mstrDireccion = ""
            mlngCodComuna = 0
            mstrComuna = ""
            mstrCasilla = ""
            mstrCiudad = ""
            mstrRegion = ""
            mstrSitioWeb = ""
            mstrContacto = ""
            mstrCargo = ""
            mstrFonoContacto = ""
            mstrEmailContacto = ""
            mdblTasaDescuento = 0
            mstrFaxContacto = ""
            mstrRep1 = ""
            mlngRutRep1 = 0
            mstrRutRep1Formato = ""
            mstrDigitoRep1 = ""
            mstrRep2 = ""
            mlngRutRep2 = 0
            mstrRutRep2Formato = ""
            mstrDigitoRep2 = ""
            mstrGtegeneral = ""
            mstrGteRRHH = ""
            mstrAreaCobranzas = ""
            mstrGiro = ""
            mstrCodActEco = ""
            mintCodRubro = 0
            mstrNombreRubro = ""
            mlngNumConvenio = 0
            mstrObservacion = ""
            '------------------------
            mstrNroDireccion = ""
            '------------------------


        End Sub
        'Sub Carga_Lookup()
        '    mdtLookUpRubros = mobjSql.s_rubros_todos
        '    mdtLookUpComunas = mobjSql.s_comunas_todos
        'End Sub
        Public Sub Inicializar(ByRef objSql As CSql)
            mobjSql = objSql
            'Carga_Lookup()
        End Sub

        'inicialización del objeto
        Public Sub Inicializar0(ByRef objSql As CSql, _
                                ByVal lngRutUsuario As Long)
            mobjSql = objSql
            ' Carga_Lookup()
            If lngRutUsuario <= 0 Then
                EnviaError("cAporte:Inicializar0 Method - Usuario desconocido")
                Exit Sub
            End If
            mlngRutUsuario = lngRutUsuario
        End Sub


        'Constructor del objeto, recibe el rut buscado. Retorna False si el Rut no
        'corresponde a un Otec.
        Public Function Inicializar1(ByVal strRut) As Boolean


            Try
                Dim mobjSql As New CSql
                Dim lngRut As Long
                Dim dtOtec1 As DataTable

                lngRut = RutUsrALng(strRut)

                dtOtec1 = mobjSql.s_Otec_PersonaJuridica(lngRut)

                If mobjSql.Registros > 0 Then

                    'asignación de valores
                    mlngRut = lngRut
                    mstrRutFormato = RutLngAUsr(lngRut)
                    mstrDigitoOtec = dtOtec1.Rows(0)(0)
                    mstrNombreFantasia = dtOtec1.Rows(0)(1)
                    mstrRazonSocial = dtOtec1.Rows(0)(2)
                    mstrSigla = dtOtec1.Rows(0)(3)
                    mstrEmail = dtOtec1.Rows(0)(4)
                    mstrFono = dtOtec1.Rows(0)(5)
                    If IsDBNull(dtOtec1.Rows(0)(6)) Then
                        mstrFono2 = ""
                    Else
                        mstrFono2 = dtOtec1.Rows(0)(6)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(7)) Then
                        mstrFax = ""
                    Else
                        mstrFax = dtOtec1.Rows(0)(7)
                    End If
                    mstrDireccion = dtOtec1.Rows(0)(8)
                    mlngCodComuna = dtOtec1.Rows(0)(9)
                    mstrComuna = dtOtec1.Rows(0)(10)
                    If IsDBNull(dtOtec1.Rows(0)(11)) Then
                        mstrCasilla = ""
                    Else
                        mstrCasilla = dtOtec1.Rows(0)(11)
                    End If
                    mstrCiudad = dtOtec1.Rows(0)(12)
                    If IsDBNull(dtOtec1.Rows(0)(13)) Then
                        mstrSitioWeb = ""
                    Else
                        mstrSitioWeb = dtOtec1.Rows(0)(13)
                    End If
                    mstrRegion = dtOtec1.Rows(0)(14)
                    If IsDBNull(dtOtec1.Rows(0)(15)) Or IsNothing(dtOtec1.Rows(0)(15)) Then
                        mstrContacto = ""
                    Else
                        mstrContacto = dtOtec1.Rows(0)(15)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(16)) Or IsNothing(dtOtec1.Rows(0)(16)) Then
                        mstrCargo = ""
                    Else
                        mstrCargo = dtOtec1.Rows(0)(16)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(17)) Or IsNothing(dtOtec1.Rows(0)(17)) Then
                        mstrFonoContacto = ""
                    Else
                        mstrFonoContacto = dtOtec1.Rows(0)(17)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(18)) Or IsNothing(dtOtec1.Rows(0)(18)) Then
                        mstrEmailContacto = ""
                    Else
                        mstrEmailContacto = dtOtec1.Rows(0)(18)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(19)) Or IsNothing(dtOtec1.Rows(0)(19)) Then
                        mdblTasaDescuento = 0
                    Else
                        mdblTasaDescuento = dtOtec1.Rows(0)(19)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(20)) Or IsNothing(dtOtec1.Rows(0)(20)) Then
                        mstrFaxContacto = ""
                    Else
                        mstrFaxContacto = dtOtec1.Rows(0)(20)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(21)) Or IsNothing(dtOtec1.Rows(0)(21)) Then
                        mintCodRubro = 0
                    Else
                        mintCodRubro = dtOtec1.Rows(0)(21)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(22)) Or IsNothing(dtOtec1.Rows(0)(22)) Then
                        mstrRep1 = ""
                    Else
                        mstrRep1 = dtOtec1.Rows(0)(22)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(23)) Or IsNothing(dtOtec1.Rows(0)(23)) Then
                        mlngRutRep1 = 0
                        mstrRutRep1Formato = ""
                    Else
                        mlngRutRep1 = dtOtec1.Rows(0)(23)
                        mstrRutRep1Formato = RutLngAUsr(dtOtec1.Rows(0)(23))
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(24)) Or IsNothing(dtOtec1.Rows(0)(24)) Then
                        mstrDigitoRep1 = ""
                    Else
                        mstrDigitoRep1 = dtOtec1.Rows(0)(24)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(25)) Or IsNothing(dtOtec1.Rows(0)(25)) Then
                        mstrRep2 = ""
                    Else
                        mstrRep2 = dtOtec1.Rows(0)(25)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(26)) Or IsNothing(dtOtec1.Rows(0)(26)) Then
                        mlngRutRep2 = 0
                        mstrRutRep2Formato = ""
                    Else
                        mlngRutRep2 = dtOtec1.Rows(0)(26)
                        mstrRutRep2Formato = RutLngAUsr(dtOtec1.Rows(0)(26))
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(27)) Or IsNothing(dtOtec1.Rows(0)(27)) Then
                        mstrDigitoRep2 = ""
                    Else
                        mstrDigitoRep2 = dtOtec1.Rows(0)(27)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(28)) Or IsNothing(dtOtec1.Rows(0)(28)) Then
                        mstrGtegeneral = ""
                    Else
                        mstrGtegeneral = dtOtec1.Rows(0)(28)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(29)) Or IsNothing(dtOtec1.Rows(0)(29)) Then
                        mstrGteRRHH = ""
                    Else
                        mstrGteRRHH = dtOtec1.Rows(0)(29)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(30)) Or IsNothing(dtOtec1.Rows(0)(30)) Then
                        mstrAreaCobranzas = ""
                    Else
                        mstrAreaCobranzas = dtOtec1.Rows(0)(30)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(31)) Or IsNothing(dtOtec1.Rows(0)(31)) Then
                        mstrGiro = ""
                    Else
                        mstrGiro = dtOtec1.Rows(0)(31)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(32)) Or IsNothing(dtOtec1.Rows(0)(32)) Then
                        mstrCodActEco = ""
                    Else
                        mstrCodActEco = dtOtec1.Rows(0)(32)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(33)) Or IsNothing(dtOtec1.Rows(0)(33)) Then
                        mlngNumConvenio = 0
                    Else
                        mlngNumConvenio = dtOtec1.Rows(0)(33)
                    End If
                    If IsDBNull(dtOtec1.Rows(0)(34)) Or IsNothing(dtOtec1.Rows(0)(34)) Then
                        mstrNombreRubro = ""
                    Else
                        mstrNombreRubro = dtOtec1.Rows(0)(34)
                    End If
                    mstrNroDireccion = IIf(IsDBNull(dtOtec1.Rows(0)(35)), "", dtOtec1.Rows(0)(35))
                    Inicializar1 = True
                Else
                    Inicializar1 = False
                End If

            Catch ex As Exception
                EnviaError("COtec:Inicializar1-->" & ex.Message)
            End Try
        End Function

        'Inicializar2: Inicializa el objeto COtec
        '              dentro de la BD.
        Public Sub Inicializar2(ByVal strRutotec As String, _
                                ByVal strNomFantasia As String, _
                                ByVal strRazonSocial As String, ByVal strSigla As String, _
                                ByVal strEmailOtec As String, ByVal strFonoOtec As String, _
                                ByVal strFono2Otec As String, ByVal strFax As String, _
                                ByVal strDireccion As String, ByVal lngCodComuna As Long, _
                                ByVal strCasilla As String, _
                                ByVal strSitioWeb As String, _
                                ByVal strNomContacto As String, _
                                ByVal strCargoContacto As String, ByVal strFonoContacto As String, _
                                ByVal strEmailContacto As String, ByVal strAnexoContacto As String, _
                                ByVal intCodRubro As Integer, _
                                ByVal strNomRep1 As String, ByVal strRutRep1 As String, _
                                ByVal strNomRep2 As String, ByVal strRutRep2 As String, _
                                ByVal strGerenteGral As String, ByVal strGerenteRRHH As String, _
                                ByVal strAreaCobranzas As String, ByVal strGiro As String, _
                                ByVal strCodActEconomica As String, _
                                ByVal lngNumConvenio As Long, ByVal intTasaDescuento As Integer, _
                                ByVal strNroDireccion As String, ByVal strCiudad As String)


            Try
                Call QuitarFormato(strRutotec, "Otec")
                mstrNombreFantasia = strNomFantasia
                mstrRazonSocial = strRazonSocial
                mstrSigla = strSigla
                mstrEmail = strEmailOtec
                mstrFono = strFonoOtec
                mstrFono2 = strFono2Otec
                mstrFax = strFax
                mstrDireccion = strDireccion
                mlngCodComuna = lngCodComuna
                mstrCasilla = strCasilla
                mstrSitioWeb = strSitioWeb

                'valores que seran insertados en Otec
                mstrContacto = strNomContacto
                mstrCargo = strCargoContacto
                mstrFonoContacto = strFonoContacto
                mstrEmailContacto = strEmailContacto
                mstrFaxContacto = strAnexoContacto
                mintCodRubro = intCodRubro
                mstrRep1 = strNomRep1

                If strRutRep1 <> "" Then
                    Call QuitarFormato(strRutRep1, "Rep1")
                Else
                    mlngRutRep1 = -1
                    mstrDigitoRep1 = ""
                End If

                mstrRep2 = strNomRep2
                If strRutRep2 <> "" Then
                    Call QuitarFormato(strRutRep2, "Rep2")
                Else
                    mlngRutRep2 = -1
                    mstrRep2 = ""
                End If

                mstrGtegeneral = strGerenteGral
                mstrGteRRHH = strGerenteRRHH
                mstrAreaCobranzas = strAreaCobranzas
                mstrGiro = strGiro
                mstrCodActEco = strCodActEconomica
                mlngNumConvenio = lngNumConvenio
                mdblTasaDescuento = intTasaDescuento
                mstrNroDireccion = strNroDireccion
                mstrCiudad = strCiudad

                Call GrabarDatos()
            Catch ex As Exception

            End Try


            Exit Sub


        End Sub

        'Permite Modificar los datos existentes en persona_juridica , Otec
        Public Sub Inicializar3(ByVal strRutotec As String, _
                                ByVal strNomFantasia As String, _
                                ByVal strRazonSocial As String, ByVal strSigla As String, _
                                ByVal strEmailOtec As String, ByVal strFonoOtec As String, _
                                ByVal strFono2Otec As String, ByVal strFax As String, _
                                ByVal strDireccion As String, ByVal lngCodComuna As Long, _
                                ByVal strCasilla As String, _
                                ByVal strSitioWeb As String, _
                                ByVal strNomContacto As String, _
                                ByVal strCargoContacto As String, ByVal strFonoContacto As String, _
                                ByVal strEmailContacto As String, ByVal strFaxContacto As String, _
                                ByVal intCodRubro As Integer, _
                                ByVal strNomRep1 As String, ByVal strRutRep1 As String, _
                                ByVal strNomRep2 As String, ByVal strRutRep2 As String, _
                                ByVal strGerenteGral As String, ByVal strGerenteRRHH As String, _
                                ByVal strAreaCobranzas As String, ByVal strGiro As String, _
                                ByVal strCodActEconomica As String, _
                                ByVal lngNumConvenio As Long, ByVal intTasaDescuento As Integer, _
                                ByVal strNroDireccion As String, ByVal strCiudad As String)



            Try
                Dim lngRutOtec As Long
                lngRutOtec = RutUsrALng(strRutotec)
                'valores que seran insertados en persona_juridica
                mlngRut = lngRutOtec
                mstrNombreFantasia = strNomFantasia
                mstrRazonSocial = strRazonSocial
                mstrSigla = strSigla
                mstrEmail = strEmailOtec
                mstrFono = strFonoOtec
                mstrFono2 = strFono2Otec
                mstrFax = strFax
                mstrDireccion = strDireccion
                mlngCodComuna = lngCodComuna
                mstrCasilla = strCasilla
                mstrSitioWeb = strSitioWeb
                mintCodRubro = intCodRubro
                'Codigo del estado del cliente ==> 1 Activo / 0 Inactivo
                'mintCodEstadoCliente = intCodEstadoCliente

                mstrContacto = strNomContacto
                mstrCargo = strCargoContacto
                mstrFonoContacto = strFonoContacto
                mstrFaxContacto = strFaxContacto
                mstrEmailContacto = strEmailContacto
                mstrRep1 = strNomRep1

                'le quita el formato al rut que viene como 13.220.307-5 pasar a ==>13220307
                If strRutRep1 <> "" Then
                    Call QuitarFormato(strRutRep1, "Rep1")
                Else
                    mlngRutRep1 = -1
                    mstrDigitoRep1 = ""
                End If

                mstrRep2 = strNomRep2
                If strRutRep2 <> "" Then
                    Call QuitarFormato(strRutRep2, "Rep2")
                Else
                    mlngRutRep2 = -1
                    mstrRep2 = ""
                End If
                mstrGtegeneral = strGerenteGral
                mstrGteRRHH = strGerenteRRHH
                mstrAreaCobranzas = strAreaCobranzas
                mstrGiro = strGiro
                mstrCodActEco = strCodActEconomica
                mlngNumConvenio = lngNumConvenio
                mdblTasaDescuento = intTasaDescuento
                mstrNroDireccion = strNroDireccion
                mstrCiudad = strCiudad

                Call ModificarDatos()
            Catch ex As Exception

            End Try

            Exit Sub


        End Sub
        'Recibe el rut como string formateado y lo transforma  a long para llamar a inicializar1
        Public Function Inicializar4(ByVal strRut As String) As Boolean
            Try
                Dim Rut As Long
                Rut = RutUsrALng(strRut)
                If Inicializar1(Rut) = True Then
                    Inicializar4 = True
                Else
                    Inicializar4 = False
                End If
            Catch ex As Exception

            End Try


            Exit Function


        End Function
        'Permite actualizar información en las tablas persona_juridica, Otec
        Private Sub ModificarDatos()
            Try


                'abrir transaccion
                mobjSql.InicioTransaccion()

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
                                    mlngRutRep2, mstrDigitoRep2, mstrGtegeneral, _
                                    mstrGteRRHH, mstrAreaCobranzas, mstrGiro, _
                                    mstrCodActEco, mlngNumConvenio, mdblTasaDescuento)

                'cerrar transaccion
                mobjSql.FinTransaccion()
                Exit Sub


            Catch ex As Exception

            End Try

        End Sub

        'Recibe un rut con formato xx.xxx.xxx-x
        'y le asigna a las variables del modulo rut el numero sin formato
        Private Sub QuitarFormato(ByVal strRut As String, _
                                  ByVal Nombre As String)

            Try
                Dim posicion, largo, i As Integer
                Dim ValorRut, digito As String

                largo = Len(strRut)
                posicion = 0
                ValorRut = ""
                For i = 1 To largo
                    posicion = InStr(posicion + 1, strRut, ".")
                    If posicion = 0 Then
                        posicion = InStr(posicion + 1, strRut, "-")
                        ValorRut = ValorRut + Mid(strRut, 1, posicion - 1)
                        digito = CStr(Mid(strRut, Len(strRut), 1))
                        Exit For
                    Else
                        ValorRut = ValorRut + Mid(strRut, 1, posicion - 1)
                        strRut = Mid(strRut, posicion + 1, largo)
                    End If
                Next
                If Nombre = "Rep1" Then
                    mlngRutRep1 = CLng(ValorRut)
                    mstrDigitoRep1 = CStr(digito)
                End If
                If Nombre = "Rep2" Then
                    mlngRutRep2 = CLng(ValorRut)
                    mstrDigitoRep2 = CStr(digito)
                End If
                If Nombre = "Otec" Then
                    mlngRut = CLng(ValorRut)
                    mstrDigitoOtec = CStr(digito)
                End If
            Catch ex As Exception

            End Try

        End Sub

        'Graba la informacion en las tablas persona, persona_juridica , otec
        Private Sub GrabarDatos()
            Try
                'abrir transaccion
                mobjSql.InicioTransaccion()

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
                                            mstrDigitoRep2, mstrGtegeneral, mstrGteRRHH, _
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
                                            mstrDigitoRep2, mstrGtegeneral, mstrGteRRHH, _
                                            mstrAreaCobranzas, mstrGiro, mstrCodActEco, _
                                            mlngNumConvenio, mdblTasaDescuento)
                        End If
                    End If
                End If



                Dim i
                'Dim arrCuentas
                'arrCuentas = mobjSql.s_cuenta_todos
                'inserta en tabla cuenta_cliente n registros segun la cantidad de cuentas existentes
                'For i = 0 To TamanoArreglo2(arrCuentas) - 1
                '    Call mobjSql.i_CuentaCliente(mlngRut, arrCuentas(0, i))
                'Next

                'Inserta Registro en Bitacora
                'mstrObservacion = "Ingreso Nuevo Registro Otec: " & RutLngAUsr(mlngRut)
                'Call mobjSql.i_bitacora(mlngRutUsuario, "Ingreso", mstrObservacion, 5, mlngRut)

                'cerrar transaccion
                mobjSql.FinTransaccion()
            Catch ex As Exception

            End Try


        End Sub
        Public Function inicializarPopUpOtec()
            Try
                mlngRut = gValorNumNulo
                mstrRazonSocial = ""
                mdtOtec = New DataTable
                mdtOtec.Columns.Add("rut")
                mdtOtec.Columns.Add("razon_social")
                mdtOtec.Columns.Add("nombre_contacto")
                mdtOtec.Columns.Add("fono")
            Catch ex As Exception
                EnviaError("COtec.vb:inicializarPopUpOtec-->" & ex.Message)
            End Try
        End Function
        Public Function consultarOtec()
            Try
                mobjSql = New CSql
                Dim dt As New DataTable
                dt = mobjSql.s_Otec3(mlngRut, mstrRazonSocial)
                If mobjSql.Registros > 0 Then
                    Dim dr As DataRow
                    Dim drOtec As DataRow
                    For Each dr In dt.Rows
                        drOtec = mdtOtec.NewRow
                        drOtec("rut") = RutLngAUsr(dr("rut"))
                        drOtec("razon_social") = dr("razon_social")
                        drOtec("nombre_contacto") = dr("nombre_contacto")
                        drOtec("fono") = dr("fono")
                        mdtOtec.Rows.Add(drOtec)
                    Next
                End If
            Catch ex As Exception
                EnviaError("COtec.vb:consultarOtec-->" & ex.Message)
            End Try
        End Function

    End Class
End Namespace


