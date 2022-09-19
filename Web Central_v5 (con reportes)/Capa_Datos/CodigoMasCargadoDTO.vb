Public Class CodigoMasCargadoDTO
    'Dim _Cliente As Integer
    Dim _PID As String
    Dim _Zona As String
    Dim _Importe As Decimal

#Region "Propiedades"

    'Public Property Cliente As Integer
    '    Get
    '        Return _Cliente
    '    End Get
    '    Set(value As Integer)
    '        _Cliente = value
    '    End Set
    'End Property

    Public Property PID As String
        Get
            Return _PID
        End Get
        Set(value As String)
            _PID = value
        End Set
    End Property

    Public Property Zona As String
        Get
            Return _Zona
        End Get
        Set(value As String)
            _Zona = value
        End Set
    End Property

    Public Property Importe As Decimal
        Get
            Return _Importe
        End Get
        Set(value As Decimal)
            _Importe = value
        End Set
    End Property



#End Region

End Class
