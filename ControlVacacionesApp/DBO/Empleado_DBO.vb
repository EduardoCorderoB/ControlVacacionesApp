Public Class Empleado_DBO

    Function GuardarEmpleado(ByVal emp As Empleado) As Boolean
        Dim resp As Boolean = False
        Try

        Catch ex As Exception
            MsgBox(ex.Message & " error al guardar empleado")
            Return False
        End Try
        Return resp
    End Function

    Function GetAcumuladoVacaciones(ByVal id_emp As Integer, ByVal fec As Date) As Decimal
        Dim dias As Decimal = 0
        Try

        Catch ex As Exception
            MsgBox(ex.Message & " error al obtener Vacaciones")
            Return 0
        End Try
        Return dias
    End Function

    Function GetDiasACV(ByVal id_emp As Integer, ByVal fec As Date) As Decimal
        Dim dias As Decimal = 0
        Try

        Catch ex As Exception
            MsgBox(ex.Message & " error al obtener dias ACV")
            Return 0
        End Try
        Return dias
    End Function

End Class
