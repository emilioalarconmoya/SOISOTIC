Imports Modulos
Imports System.Data

Namespace Clases
    Public Class Clookups
        'indica si algun usuario esta conectado
        Private mobjCsql As Clases.CSql
       
        Public Function Agnos() As DataTable
            Try
                'Call Me.AgnosConSantoral.Columns.Add(New DataColumn("con Archibo", GetType(String)))
                Dim dt As New DataTable
                Dim intAgno, i As Integer
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("Agno_v", GetType(String)))
                dt.Columns.Add(New DataColumn("Agno_t", GetType(String)))

                intAgno = Now.Year

                For i = intAgno - 2 To intAgno + 2
                    dr = dt.NewRow()
                    dr("Agno_v") = i
                    dr("Agno_t") = i
                    dt.Rows.Add(dr)
                Next

                Agnos = dt

                dt.Dispose()
                dt = Nothing

            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        Public Function Seleccion() As DataTable
            Try
                'Call Me.AgnosConSantoral.Columns.Add(New DataColumn("con Archibo", GetType(String)))
                Dim dt As New DataTable
                Dim intAgno, i As Integer
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("valor", GetType(String)))
                dt.Columns.Add(New DataColumn("texto", GetType(String)))

                dr = dt.NewRow()
                dr("valor") = 0
                dr("texto") = "Elegir selección"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("valor") = 1
                dr("texto") = "Seleccionar todos"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("valor") = 2
                dr("texto") = "Deseleccionar todos"
                dt.Rows.Add(dr)

                Seleccion = dt

                dt.Dispose()
                dt = Nothing

            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        Public Function Agnos2() As DataTable
            Try
                'Call Me.AgnosConSantoral.Columns.Add(New DataColumn("con Archibo", GetType(String)))
                Dim dt As New DataTable
                Dim intAgno, i As Integer
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("Agno_v", GetType(String)))
                dt.Columns.Add(New DataColumn("Agno_t", GetType(String)))

                intAgno = Now.Year

                For i = intAgno - 15 To intAgno + 1
                    dr = dt.NewRow()
                    dr("Agno_v") = i
                    dr("Agno_t") = i
                    dt.Rows.Add(dr)
                Next

                Agnos2 = dt

                dt.Dispose()
                dt = Nothing

            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function

        Public Function Meses() As DataTable
            Try

                Dim dt As New DataTable

                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("Mes_v", GetType(Integer)))
                dt.Columns.Add(New DataColumn("Mes_t", GetType(String)))

                dr = dt.NewRow()
                dr("Mes_v") = 1
                dr("Mes_t") = "Ene"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 2
                dr("Mes_t") = "Feb"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 3
                dr("Mes_t") = "Mar"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 4
                dr("Mes_t") = "Abr"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 5
                dr("Mes_t") = "May"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 6
                dr("Mes_t") = "Jun"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 7
                dr("Mes_t") = "Jul"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 8
                dr("Mes_t") = "Ago"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 9
                dr("Mes_t") = "Sep"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 10
                dr("Mes_t") = "Oct"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 11
                dr("Mes_t") = "Nov"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("Mes_v") = 12
                dr("Mes_t") = "Dic"
                dt.Rows.Add(dr)
                Meses = dt
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        Public Function sexo() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("sexo_v", GetType(String)))
                dt.Columns.Add(New DataColumn("sexo_t", GetType(String)))

                dr = dt.NewRow()
                dr("sexo_v") = "M"
                dr("sexo_t") = "M"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("sexo_v") = "F"
                dr("sexo_t") = "F"
                dt.Rows.Add(dr)
                sexo = dt
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        Public Function corte() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("corte_v", GetType(String)))
                dt.Columns.Add(New DataColumn("corte_t", GetType(String)))

                dr = dt.NewRow()
                dr("corte_v") = "1"
                dr("corte_t") = "Mes anterior"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("corte_v") = "2"
                dr("corte_t") = "todo el año"
                dt.Rows.Add(dr)
                corte = dt
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        ' rango de 10 en 10
        Public Function rango() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("rango_v", GetType(String)))
                dt.Columns.Add(New DataColumn("rango_t", GetType(String)))

                dr = dt.NewRow()
                dr("rango_v") = "1"
                dr("rango_t") = "1-10"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "2"
                dr("rango_t") = "11-20"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "3"
                dr("rango_t") = "21-30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "4"
                dr("rango_t") = "31-40"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "5"
                dr("rango_t") = "41-50"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "6"
                dr("rango_t") = "51-60"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "7"
                dr("rango_t") = "61-70"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "8"
                dr("rango_t") = "71-80"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "9"
                dr("rango_t") = "81-90"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("rango_v") = "10"
                dr("rango_t") = "91-100"
                dt.Rows.Add(dr)
                rango = dt
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        Public Function Aporte() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("aporte_v", GetType(String)))
                dt.Columns.Add(New DataColumn("aporte_t", GetType(String)))

                dr = dt.NewRow()
                dr("aporte_v") = "1"
                dr("aporte_t") = "Por Cobrar"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("aporte_v") = "2"
                dr("aporte_t") = "Cobrados"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("aporte_v") = "3"
                dr("aporte_t") = "Anulados"
                dt.Rows.Add(dr)
                Aporte = dt
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        Public Function franquicia() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("franquicia_v", GetType(Integer)))
                dt.Columns.Add(New DataColumn("franquicia_t", GetType(Integer)))

                dr = dt.NewRow()
                dr("franquicia_v") = 100
                dr("franquicia_t") = 100
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("franquicia_v") = 50
                dr("franquicia_t") = 50
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("franquicia_v") = 15
                dr("franquicia_t") = 15
                dt.Rows.Add(dr)
                franquicia = dt
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError(ex.Message)
            End Try
        End Function
        'Días
        Public Function Dias() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("dia_v", GetType(Integer)))
                dt.Columns.Add(New DataColumn("dia_t", GetType(String)))

                dr = dt.NewRow()
                dr("dia_v") = 1
                dr("dia_t") = "Lun"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("dia_v") = 2
                dr("dia_t") = "Mar"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("dia_v") = 3
                dr("dia_t") = "Mie"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("dia_v") = 4
                dr("dia_t") = "Jue"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("dia_v") = 5
                dr("dia_t") = "Vie"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("dia_v") = 6
                dr("dia_t") = "Sab"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("dia_v") = 7
                dr("dia_t") = "Dom"
                dt.Rows.Add(dr)

                Dias = dt

                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError("CLookups:Dias - >" & ex.Message)
            End Try
        End Function
        Public Function Horas() As DataTable
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add(New DataColumn("hora_v", GetType(Integer)))
                dt.Columns.Add(New DataColumn("hora_t", GetType(String)))

                dr = dt.NewRow()
                dr("hora_v") = 1
                dr("hora_t") = "00:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 2
                dr("hora_t") = "00:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 3
                dr("hora_t") = "01:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 4
                dr("hora_t") = "01:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 5
                dr("hora_t") = "02:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 6
                dr("hora_t") = "02:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 7
                dr("hora_t") = "03:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 8
                dr("hora_t") = "03:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 9
                dr("hora_t") = "04:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 10
                dr("hora_t") = "04:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 11
                dr("hora_t") = "05:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 12
                dr("hora_t") = "05:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 13
                dr("hora_t") = "06:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 14
                dr("hora_t") = "06:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 15
                dr("hora_t") = "07:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 16
                dr("hora_t") = "07:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 17
                dr("hora_t") = "08:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 18
                dr("hora_t") = "08:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 19
                dr("hora_t") = "09:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 20
                dr("hora_t") = "09:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 21
                dr("hora_t") = "10:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 22
                dr("hora_t") = "10:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 23
                dr("hora_t") = "11:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 24
                dr("hora_t") = "11:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 25
                dr("hora_t") = "12:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 26
                dr("hora_t") = "12:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 27
                dr("hora_t") = "13:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 28
                dr("hora_t") = "13:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 29
                dr("hora_t") = "14:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 30
                dr("hora_t") = "14:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 35
                dr("hora_t") = "15:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 36
                dr("hora_t") = "15:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 37
                dr("hora_t") = "16:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 38
                dr("hora_t") = "16:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 39
                dr("hora_t") = "17:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 40
                dr("hora_t") = "17:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 41
                dr("hora_t") = "18:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 42
                dr("hora_t") = "18:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 43
                dr("hora_t") = "19:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 44
                dr("hora_t") = "19:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 45
                dr("hora_t") = "20:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 46
                dr("hora_t") = "20:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 47
                dr("hora_t") = "21:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 48
                dr("hora_t") = "21:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 49
                dr("hora_t") = "22:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 50
                dr("hora_t") = "22:30"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 51
                dr("hora_t") = "23:00"
                dt.Rows.Add(dr)
                dr = dt.NewRow()
                dr("hora_v") = 52
                dr("hora_t") = "23:30"
                dt.Rows.Add(dr)

                Horas = dt

                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                Call EnviaError("CLookups:Horas - >" & ex.Message)
            End Try
        End Function
        Public Function tipo_actividad() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_tipos_activ_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    tipo_actividad = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function estado_participante_interno() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_estado_part_interno

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    estado_participante_interno = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function tipo_documentos() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_tipo_documentos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    tipo_documentos = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function sucursales() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_sucursales_todos2

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    sucursales = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function empresas() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_empresa_cliente_todas

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    empresas = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function comunas() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_comunas_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    comunas = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function pais() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_pais_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    pais = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function comunasRegion(ByVal intCodregion As Integer) As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_comunas_region(intCodregion)

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    comunasRegion = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function RegionComunas(ByVal intCodComuna As Integer) As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_region_comunas(intCodComuna)

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    RegionComunas = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function regiones() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_regiones_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    regiones = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        'muestra en el dll los codigos las regiones
        Public Function regionesPorCodigos() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_regiones_todos_por_codigo

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    regionesPorCodigos = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function directores() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_director_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    directores = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function nivel_ocupacional() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_nivel_ocupacional_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    nivel_ocupacional = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function nivel_ocupacional_por_codigo() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_nivel_ocupacional_todos_por_codigo

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    nivel_ocupacional_por_codigo = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function nivel_educacional() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_nivel_educacional_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    nivel_educacional = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function nivel_educacional_por_codigo() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_nivel_educacional_todos_por_codigo

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    nivel_educacional_por_codigo = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function modalidad() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_modalidades_todos

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    modalidad = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function encargado(ByVal lngRurempresa As Long) As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_encargado_empresa(lngRurempresa)

                If mobjCsql.Registros <= 0 Then  'Si no tiene datos
                    encargado = Nothing
                    Exit Function
                End If

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function EjecutivosTodos() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_ejecutivo_todos

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function SupervisoresTodos() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_supervisor_todos

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function Ejecutivo(ByVal lngRut) As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql
            Try
                dt = mobjCsql.s_ejecutivo_supervisor(lngRut)

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function EstadoFactura() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql
            Try
                dt = mobjCsql.s_estados_factura

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        '
        Public Function Cuentas() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql
            Try
                dt = mobjCsql.s_cuentas_traspaso

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function Cuentas2() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql
            Try
                dt = mobjCsql.s_cuentas_traspaso2

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function Rubros() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql
            Try
                dt = mobjCsql.s_rubros_todos

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function ClientesAsociados(ByVal lngRut As Long) As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_clientes_asociados(lngRut)

                Return dt
            Catch ex As Exception
                Call EnviaError(ex.Message)
            Finally
                'Libera
                mobjCsql = Nothing
                dt = Nothing
            End Try
        End Function
        Public Function EstadosAporte() As DataTable
            Dim dt As DataTable
            mobjCsql = New Clases.CSql

            Try
                dt = mobjCsql.s_estados_aporte
                Return dt
            Catch ex As Exception
                EnviaError("Clookups:EstadosAporte-->" & ex.Message)
            End Try
        End Function
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            mobjCsql = Nothing
        End Sub

        Public Function cuentaDestino()
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add("cuentaDestino_v", GetType(String))
                dt.Columns.Add("cuentaDestino_t", GetType(String))

                dr = dt.NewRow
                dr("cuentaDestino_v") = 0
                dr("cuentaDestino_t") = "Ambas"
                dt.Rows.Add(dr)
                dr = dt.NewRow
                dr("cuentaDestino_v") = 1
                dr("cuentaDestino_t") = "Capacitacion"
                dt.Rows.Add(dr)
                dr = dt.NewRow
                dr("cuentaDestino_v") = 2
                dr("cuentaDestino_t") = "Capacitacion"
                dt.Rows.Add(dr)
                dt.Dispose()
                dt = Nothing
            Catch ex As Exception
                EnviaError("Clookups:cuentaDestino-->" & ex.Message)
            End Try
        End Function
        Public Function cuentasAportes()
            Try
                Dim dt As New DataTable
                Dim dr As DataRow

                dt.Columns.Add("cuenta_v", GetType(String))
                dt.Columns.Add("cuenta_t", GetType(String))

                dr = dt.NewRow
                dr("cuenta_v") = 1
                dr("cuenta_t") = "Capacitacion"
                dt.Rows.Add(dr)
                dr = dt.NewRow
                dr("cuenta_v") = 2
                dr("cuenta_t") = "Reparto"
                dt.Rows.Add(dr)
                dr = dt.NewRow
                dr("cuenta_v") = 8
                dr("cuenta_t") = "Certificación de competencias laborales"
                dt.Rows.Add(dr)
                Return dt
            Catch ex As Exception
                EnviaError("Clookups:cuentasAportes-->" & ex.Message)
            End Try
        End Function
    End Class
End Namespace


