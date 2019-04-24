Imports clases
Imports system.data
Imports modulos
Imports InfoSoftGlobal
Imports System.IO

Public Class CChart
    Private objCsql As New CSql
    Private dtChart As DataTable
    Private intTipoChart As Integer
    Private strxAxisName As String
    Private stryAxisName As String
    Private strPreVal As String
    Private strPosVal As String
    Private strCaption As String
    Private strSubCaption As String
    Private intAncho As Integer
    Private intAlto As Integer
    Private intDecimales As Integer
    Private bolMostrarPorcentaje As Boolean
    Private strSeparadorDatos As String
    Public Property DtDatos() As DataTable
        Get
            DtDatos = dtChart
        End Get
        Set(ByVal value As DataTable)
            dtChart = value
        End Set
    End Property
    Public Property TipoChart() As Integer
        Get
            TipoChart = intTipoChart
        End Get
        Set(ByVal value As Integer)
            intTipoChart = value
        End Set
    End Property
    Public Property xAxisName() As String
        Get
            xAxisName = strxAxisName
        End Get
        Set(ByVal value As String)
            strxAxisName = value
        End Set
    End Property
    Public Property yAxisName() As String
        Get
            yAxisName = stryAxisName
        End Get
        Set(ByVal value As String)
            stryAxisName = value
        End Set
    End Property
    Public Property PreVal() As String
        Get
            PreVal = strPreVal
        End Get
        Set(ByVal value As String)
            strPreVal = value
        End Set
    End Property
    Public Property PosVal() As String
        Get
            PosVal = strPosVal
        End Get
        Set(ByVal value As String)
            strPosVal = value
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Titulo = strCaption
        End Get
        Set(ByVal value As String)
            strCaption = value
        End Set
    End Property
    Public Property SubTitulo() As String
        Get
            Titulo = strSubCaption
        End Get
        Set(ByVal value As String)
            strSubCaption = value
        End Set
    End Property
    Public Property Ancho() As Integer
        Get
            Ancho = intAncho
        End Get
        Set(ByVal value As Integer)
            intAncho = value
        End Set
    End Property
    Public Property Alto() As Integer
        Get
            Alto = intAlto
        End Get
        Set(ByVal value As Integer)
            intAlto = value
        End Set
    End Property
    Public Property Decimales() As Integer
        Get
            Decimales = intDecimales
        End Get
        Set(ByVal value As Integer)
            intDecimales = value
        End Set
    End Property
    Public Property MostrarPorcentaje() As Boolean
        Get
            MostrarPorcentaje = bolMostrarPorcentaje
        End Get
        Set(ByVal value As Boolean)
            bolMostrarPorcentaje = value
        End Set
    End Property
    Public Property SeparadorDatos() As String
        Get
            SeparadorDatos = strSeparadorDatos
        End Get
        Set(ByVal value As String)
            strSeparadorDatos = value
        End Set
    End Property
    
    Function CreaChart() As String
        Dim str As String
        Dim i, ind, Agno As Integer
        Dim mes As String
        Dim variablesMayorCero As Double
        Dim respuesta As String
        Dim blnNodoAgregado As Boolean
        Select Case intTipoChart
            Case 1 'Grafico tipo donuts
                str = "<chart showBorder='1' bgColor='99CCFF,FFFFFF' startingAngle='80'" _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " caption='" & strCaption & "'  numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' showSum='0' useRoundEdges='0' formatNumberScale='0'" _
                & " legendBorderAlpha='0' formatNumberScale='0' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"
                    variablesMayorCero += CDbl(dtChart.Rows(i)(1))
                Next
                If variablesMayorCero <> 0 Then 'Si el grafico es tipo donuts, a  lo menos uno de los valores tiene que ser distinto de cero 
                    str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                    & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                    & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                    & "</application></styles>"
                    str = str & "</chart>"
                    Dim strNomArchivo As String
                    strNomArchivo = NombreArchivoTmp("swf")
                    System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Doughnut3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                    respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
                End If
            Case 2 'Grafico tipo torta
                str = "<chart enableSmartLabels='1' enableRotation='1' decimals='" & intDecimales & "'" _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " bgColor='99CCFF,FFFFFF' bgAlpha='40,100' bgRatio='0,100' bgAngle='360' showBorder='1' " _
                & " startingAngle='70' caption='" & strCaption & "' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' showSum='0' useRoundEdges='0' legendBorderAlpha='0' formatNumberScale='0' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"
                    variablesMayorCero += CDbl(dtChart.Rows(i)(1))
                Next
                If variablesMayorCero <> 0 Then 'Si el grafico es tipo torta, a  lo menos uno de los valores tiene que ser distinto de cero 
                    str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                    & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                    & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                    & "</application></styles>"
                    str = str & "</chart>"
                    Dim strNomArchivo As String
                    strNomArchivo = NombreArchivoTmp("swf")
                    System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Pie3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                    respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
                End If
            Case 3 'Grafico barra normal
                str = "<chart caption='" & strCaption & "' xAxisName='" & strxAxisName & "' yAxisName='" & stryAxisName & "'" _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " showValues='1' decimals='" & intDecimales & "' formatNumberScale='0' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"
                Next
                str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                & "</application></styles>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Column3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 4
                str = "<chart caption='" & strCaption & "' xAxisName='" & strxAxisName & "' yAxisName='" & stryAxisName _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " showValues='0' decimals='" & intDecimales & "' formatNumberScale='0' chartRightMargin='30' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"
                Next
                str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                & "</application></styles>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Bar2D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 5 'Grafico barras triple meses
                str = "<chart caption='" & strCaption & "' shownames='1' showvalues='0' " _
                & " decimalSeparator=',' thousandSeparator='.' " _
                & "showSum='0' useRoundEdges='0' formatNumberScale='0'" _
                & "numberPrefix='" & strPreVal & "' decimals='0' overlapColumns='1' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"

                str = str & "<categories>"
                For i = 0 To dtChart.Rows.Count - 1

                    If i > 0 Then
                        If dtChart.Rows(i - 1)(0) <> dtChart.Rows(i)(0) Then
                            str = str & "<category label='" & dtChart.Rows(i)(0) & "'/>"

                        End If
                    ElseIf i = 0 Then
                        str = str & "<category label='" & dtChart.Rows(i)(0) & "'/>"
                    End If

                Next
                str = str & "</categories>"
                str = str & "<dataset seriesName='Costo Otic' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 2 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(1) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "<dataset seriesName='Gasto Emp.' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(2) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "<dataset seriesName='Total Aporte' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(3) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\Charts\ColumnDoble3D.swf", Parametros.p_DIRFISICO & "\contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
                'str = "<chart caption='" & strCaption & "' subcaption='" & strSubCaption & "' xAxisName='" & strxAxisName & "' yAxisName='" & stryAxisName & "'" _
                '& " decimalSeparator=',' thousandSeparator='.' labeldisplay='ROTATE' palette='2' slantLabels='1' " _
                '& " showValues='1' decimals='" & intDecimales & "' formatNumberScale='0' " _
                '& " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' >"
                'For i = 0 To dtChart.Rows.Count - 1
                '    str = str & "<set label='" & dtChart.Rows(i)(1) & "' value='" & dtChart.Rows(i)(2).ToString.Replace(",", ".") & "' " _
                '              & " link='reporte_cursos.aspx?tipo=" & dtChart.Rows(i)(3) & "' />"
                'Next
                'str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                '& "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                '& "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                '& "</application></styles>"
                'str = str & "</chart>"
                'Dim strNomArchivo As String
                'strNomArchivo = NombreArchivoTmp("swf")
                'System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Column3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                'respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 6 'Grafico tipo torta
                str = "<chart enableSmartLabels='1' enableRotation='1' decimals='" & intDecimales & "'" _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " bgColor='99CCFF,FFFFFF' bgAlpha='40,100' bgRatio='0,100' bgAngle='360' showBorder='1' " _
                & " startingAngle='70' caption='" & strCaption & "' subcaption='" & strSubCaption & "' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' showSum='0' useRoundEdges='0' legendBorderAlpha='0' formatNumberScale='0' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    str = str & "<set label='" & dtChart.Rows(i)(1) & "' value='" & dtChart.Rows(i)(2).ToString.Replace(",", ".") _
                    & "' link='reporte_cursos.aspx?estados=" & dtChart.Rows(i)(3) & "'  />"
                    variablesMayorCero += CDbl(dtChart.Rows(i)(2))
                Next
                If variablesMayorCero <> 0 Then 'Si el grafico es tipo torta, a  lo menos uno de los valores tiene que ser distinto de cero 
                    str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                    & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                    & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                    & "</application></styles>"
                    str = str & "</chart>"
                    Dim strNomArchivo As String
                    strNomArchivo = NombreArchivoTmp("swf")
                    System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Pie3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                    respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
                End If
            Case 7 ' grafico barra triple años
                str = "<chart caption='" & strCaption & "' shownames='1' showvalues='0' " _
                & " decimalSeparator=',' thousandSeparator='.' " _
                & "showSum='0' useRoundEdges='0' formatNumberScale='0'" _
                & "numberPrefix='" & strPreVal & "' decimals='0' overlapColumns='1' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"

                str = str & "<categories>"
                For i = 0 To dtChart.Rows.Count - 1

                    If i > 0 Then
                        If dtChart.Rows(i - 1)(0) <> dtChart.Rows(i)(0) Then
                            str = str & "<category label='" & dtChart.Rows(i)(0) & "'/>"

                        End If
                    ElseIf i = 0 Then
                        str = str & "<category label='" & dtChart.Rows(i)(0) & "'/>"
                    End If

                Next
                str = str & "</categories>"
                str = str & "<dataset seriesName='Costo Otic' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 2 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(1) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "<dataset seriesName='Gasto Emp.' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(2) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "<dataset seriesName='Total Aporte' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(3) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\Charts\ColumnDoble3D.swf", Parametros.p_DIRFISICO & "\contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 8 'Grafico barra triple normal
                str = "<chart caption='" & strCaption & "' xAxisName='" & strxAxisName & "' yAxisName='" & stryAxisName & "'" _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " showValues='1' decimals='" & intDecimales & "' formatNumberScale='0' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    'str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"
                    str = str & "<set label='" & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"
                    str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(2).ToString.Replace(",", ".") & "'  />"
                    str = str & "<set label='" & "' value='" & dtChart.Rows(i)(3).ToString.Replace(",", ".") & "'  />"
                Next
                str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                & "</application></styles>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Column3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 9
                str = "<chart caption='" & strCaption & "' shownames='1' showvalues='0' " _
                & " decimalSeparator=',' thousandSeparator='.' " _
                & "showSum='0' useRoundEdges='0' formatNumberScale='0'" _
                & "numberPrefix='" & strPreVal & "' decimals='0' overlapColumns='1' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"

                str = str & "<categories>"
                If dtChart Is Nothing Then
                    dtChart = New DataTable
                    dtChart.Columns.Add("label")
                    dtChart.Columns.Add("valor")
                    dtChart.Columns.Add("valor1")
                    Dim dr As DataRow
                    dr = dtChart.NewRow
                    dr("label") = ""
                    dr("valor") = 0
                    dr("valor1") = 0
                    dtChart.Rows.Add(dr)
                End If

                If dtChart.Rows.Count > 0 Then
                    For i = 0 To dtChart.Rows.Count - 1

                        If i > 0 Then
                            If dtChart.Rows(i - 1)(1) <> dtChart.Rows(i)(1) Then
                                str = str & "<category label='" & dtChart.Rows(i)(1) & "'/>"

                            End If
                        ElseIf i = 0 Then
                            str = str & "<category label='" & dtChart.Rows(i)(1) & "'/>"
                        End If
                    Next
                Else
                    str = str & "<category label='0'/>"
                End If

                str = str & "</categories>"
                str = str & "<dataset seriesName='Cursos Sence' showValues='0'>"
                If dtChart.Rows.Count > 0 Then
                    Agno = dtChart.Rows(0)(1)

                    For i = 0 To dtChart.Rows.Count - 1
                        blnNodoAgregado = False
                        If Not dtChart.Rows(i)(1) = Agno Or i = 0 Then
                            For ind = 0 To dtChart.Rows.Count - 1
                                If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 2 Then
                                    str = str & "<set value='" & dtChart.Rows(ind)(0) & "'/>"
                                    blnNodoAgregado = True
                                    Exit For
                                End If
                            Next
                        End If
                        If Not blnNodoAgregado And (Not dtChart.Rows(i)(1) = Agno Or i = 0) Then
                            str = str & "<set value='0'/>"
                        End If
                        Agno = dtChart.Rows(i)(1)
                    Next
                Else
                    str = str & "<set value='0'/>"
                End If

                str = str & "</dataset>"
                str = str & "<dataset seriesName='Cursos No Sence' showValues='0'>"
                If dtChart.Rows.Count > 0 Then
                    Agno = dtChart.Rows(0)(1)
                    For i = 0 To dtChart.Rows.Count - 1
                        blnNodoAgregado = False
                        If Not dtChart.Rows(i)(1) = Agno Or i = 0 Then
                            For ind = 0 To dtChart.Rows.Count - 1
                                If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                                    str = str & "<set value='" & dtChart.Rows(ind)(0) & "'/>"
                                    blnNodoAgregado = True
                                    Exit For
                                End If
                            Next
                        End If
                        If Not blnNodoAgregado And (Not dtChart.Rows(i)(1) = Agno Or i = 0) Then
                            str = str & "<set value='0'/>"
                        End If
                        Agno = dtChart.Rows(i)(1)
                    Next
                Else
                    str = str & "<set value='0'/>"
                End If
                str = str & "</dataset>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\Charts\ColumnDoble3D.swf", Parametros.p_DIRFISICO & "\contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 10 'Grafico barras triple meses
                'str = "<chart palette='1' caption='" & strCaption & "' shownames='1' showvalues='0' " _
                '& " decimalSeparator=',' thousandSeparator='.' " _
                '& "showSum='0' useRoundEdges='0' formatNumberScale='0'" _
                '& "numberPrefix='" & strPreVal & "' decimals='0' overlapColumns='1'>"

                'str = str & "<categories>"
                'For i = 0 To dtChart.Rows.Count - 1

                '    If i > 0 Then
                '        If dtChart.Rows(i - 1)(0) <> dtChart.Rows(i)(0) Then
                '            str = str & "<category label='" & dtChart.Rows(i)(0) & "'/>"

                '        End If
                '    ElseIf i = 0 Then
                '        str = str & "<category label='" & dtChart.Rows(i)(0) & "'/>"
                '    End If

                'Next
                'str = str & "</categories>"
                'str = str & "<dataset seriesName='Costo Otic' showValues='0'>"
                'mes = dtChart.Rows(0)(0)
                'For i = 0 To dtChart.Rows.Count - 1
                '    blnNodoAgregado = False
                '    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                '        For ind = 0 To dtChart.Rows.Count - 1
                '            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 2 Then
                '            str = str & "<set value='" & dtChart.Rows(ind)(1) & "'/>"
                '            blnNodoAgregado = True
                '            'Exit For
                '            'End If
                '        Next
                '    End If
                '    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                '        str = str & "<set value='0'/>"
                '    End If
                '    mes = dtChart.Rows(i)(0)
                'Next
                'str = str & "</dataset>"
                'str = str & "<dataset seriesName='Gasto Emp.' showValues='0'>"
                'mes = dtChart.Rows(0)(0)
                'For i = 0 To dtChart.Rows.Count - 1
                '    blnNodoAgregado = False
                '    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                '        For ind = 0 To dtChart.Rows.Count - 1
                '            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                '            str = str & "<set value='" & dtChart.Rows(ind)(2) & "'/>"
                '            blnNodoAgregado = True
                '            'Exit For
                '            'End If
                '        Next
                '    End If
                '    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                '        str = str & "<set value='0'/>"
                '    End If
                '    mes = dtChart.Rows(i)(0)
                'Next
                'str = str & "</dataset>"
                'str = str & "<dataset seriesName='Total Aporte' showValues='0'>"
                'mes = dtChart.Rows(0)(0)
                'For i = 0 To dtChart.Rows.Count - 1
                '    blnNodoAgregado = False
                '    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                '        For ind = 0 To dtChart.Rows.Count - 1
                '            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                '            str = str & "<set value='" & dtChart.Rows(ind)(3) & "'/>"
                '            blnNodoAgregado = True
                '            'Exit For
                '            'End If
                '        Next
                '    End If
                '    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                '        str = str & "<set value='0'/>"
                '    End If
                '    mes = dtChart.Rows(i)(0)
                'Next
                'str = str & "</dataset>"
                'str = str & "</chart>"
                'Dim strNomArchivo As String
                'strNomArchivo = NombreArchivoTmp("swf")
                'System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\Charts\ColumnDoble3D.swf", Parametros.p_DIRFISICO & "\contenido\tmp\" & strNomArchivo)
                'respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)


                str = "<chart caption='" & strCaption & "' subcaption='" & strSubCaption & "' xAxisName='" & strxAxisName & "' yAxisName='" & stryAxisName & "'" _
                & " decimalSeparator=',' thousandSeparator='.' labeldisplay='ROTATE' slantLabels='1' " _
                & " showValues='1' decimals='" & intDecimales & "' formatNumberScale='0' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    str = str & "<set label='" & dtChart.Rows(i)(1) & "' value='" & dtChart.Rows(i)(2).ToString.Replace(",", ".") & "' " _
                              & " link='reporte_cursos.aspx?tipo=" & dtChart.Rows(i)(3) & "' />"
                Next
                str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                & "</application></styles>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Column3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 11 'Grafico barras resumen modulo cursos
                str = "<chart caption='" & strCaption & "' shownames='1' showvalues='0' " _
                & " decimalSeparator=',' thousandSeparator='.' " _
                & "showSum='0' useRoundEdges='0' formatNumberScale='0'" _
                & "numberPrefix='" & strPreVal & "' decimals='0' overlapColumns='1' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"

                str = str & "<categories>"
                For i = 0 To dtChart.Rows.Count - 1

                    If i > 0 Then
                        If dtChart.Rows(i - 1)(0) <> dtChart.Rows(i)(0) Then
                            str = str & "<category label='" & dtChart.Rows(i)(1) _
                             & "' link='reporte_cursos.aspx?estados=" & dtChart.Rows(i)(3) & "'  />"

                        End If
                    ElseIf i = 0 Then
                        str = str & "<category label='" & dtChart.Rows(i)(1) _
                             & "' link='reporte_cursos.aspx?estados=" & dtChart.Rows(i)(3) & "'  />"
                    End If

                Next
                str = str & "</categories>"
                str = str & "<dataset seriesName='Costo Otic' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 2 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(1) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "<dataset seriesName='Gasto Emp.' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(2) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "<dataset seriesName='Total Aporte' showValues='0'>"
                mes = dtChart.Rows(0)(0)
                For i = 0 To dtChart.Rows.Count - 1
                    blnNodoAgregado = False
                    If Not dtChart.Rows(i)(0) = mes Or i = 0 Then
                        For ind = 0 To dtChart.Rows.Count - 1
                            'If dtChart.Rows(i)(1) = dtChart.Rows(ind)(1) And dtChart.Rows(ind)(2) = 1 Then
                            str = str & "<set value='" & dtChart.Rows(ind)(3) & "'/>"
                            blnNodoAgregado = True
                            'Exit For
                            'End If
                        Next
                    End If
                    If Not blnNodoAgregado And (Not dtChart.Rows(i)(0) = mes Or i = 0) Then
                        str = str & "<set value='0'/>"
                    End If
                    mes = dtChart.Rows(i)(0)
                Next
                str = str & "</dataset>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "\contenido\Charts\ColumnDoble3D.swf", Parametros.p_DIRFISICO & "\contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
            Case 12 'Grafico barra normal para resumen modulo cursos
                str = "<chart caption='" & strCaption & "' xAxisName='" & strxAxisName & "' yAxisName='" & stryAxisName & "'" _
                & " decimalSeparator=',' thousandSeparator='.'" _
                & " showValues='1' decimals='" & intDecimales & "' formatNumberScale='0' " _
                & " numberPrefix='" & strPreVal & "' numberSuffix='" & strPosVal & "' paletteColors='FFC400,5CB425,E4002D,00A5C4,00246C' >"
                For i = 0 To dtChart.Rows.Count - 1
                    If i > 0 Then
                        If dtChart.Rows(i - 1)(0) <> dtChart.Rows(i)(0) Then
                            str = str & "<set label='" & dtChart.Rows(i)(1) & "' value='" & dtChart.Rows(i)(2).ToString.Replace(",", ".") _
                            & "' link='reporte_cursos.aspx?Tipo=" & dtChart.Rows(i)(3) & "'  />"

                        End If
                    ElseIf i = 0 Then
                        str = str & "<set label='" & dtChart.Rows(i)(1) & "' value='" & dtChart.Rows(i)(2).ToString.Replace(",", ".") _
                             & "' link='reporte_cursos.aspx?Tipo=" & dtChart.Rows(i)(3) & "'  />"
                    End If

                Next
                    'str = str & "<set label='" & dtChart.Rows(i)(0) & "' value='" & dtChart.Rows(i)(1).ToString.Replace(",", ".") & "'  />"

                str = str & "<styles><definition><style type='font' name='CaptionFont' color='666666' size='18' bold='1' />" _
                & "<style type='font' name='SubCaptionFont' bold='0' /></definition><application>" _
                & "<apply toObject='caption' styles='CaptionFont' /><apply toObject='SubCaption' styles='SubCaptionFont' /> " _
                & "</application></styles>"
                str = str & "</chart>"
                Dim strNomArchivo As String
                strNomArchivo = NombreArchivoTmp("swf")
                System.IO.File.Copy(Parametros.p_DIRFISICO & "contenido\Charts\Column3D.swf", Parametros.p_DIRFISICO & "contenido\tmp\" & strNomArchivo)
                respuesta = FusionCharts.RenderChart("../contenido/tmp/" & strNomArchivo, "", str, "Chart", intAncho, intAlto, False, False)
        End Select


        Return respuesta
    End Function
End Class
