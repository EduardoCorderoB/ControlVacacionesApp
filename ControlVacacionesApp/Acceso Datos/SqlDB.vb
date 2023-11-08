Imports System.Data.SqlClient

Public Class SqlDB
    Private _StrConexion As String

    Sub New(ByVal CadenaConexion As String)
        _StrConexion = CadenaConexion
    End Sub

    Public Property StrConexion As String
        Get
            StrConexion = _StrConexion
        End Get
        Set(ByVal value As String)
            _StrConexion = value
        End Set
    End Property


    Public Function CrearConexion() As SqlConnection
        Try
            Dim cc As SqlConnection = New SqlConnection(_StrConexion)
            Dim cmd As New SqlCommand
            If cc.State <> ConnectionState.Open Then
                cc.Open()
            End If
            Return cc
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    Public Function GetDTable(ByVal StrSQL As String) As DataTable
        Try
            Dim dtRes As DataTable
            Dim daQry As SqlDataAdapter
            daQry = New SqlDataAdapter(StrSQL, CrearConexion())
            dtRes = New DataTable
            daQry.Fill(dtRes)
            daQry.Dispose()
            Return (dtRes)
        Catch ex As Exception
            Throw ex
            Return Nothing
        End Try
    End Function


    'Public Function GetDReader(ByVal StrSQL As String) As SqlDataReader
    '    Dim DR As SqlDataReader
    '    Dim cmd As New SqlCommand
    '    Try
    '        cmd.CommandType = CommandType.Text
    '        cmd.CommandText = StrSQL
    '        cmd.Connection = CrearConexion()
    '        DR = cmd.ExecuteReader
    '        Return DR
    '    Catch ex As Exception
    '        Throw ex
    '        Return Nothing
    '    End Try
    'End Function

    Public Function EjecutaSQL(ByVal StrSQL As String) As Boolean
        Dim cmd As New SqlCommand
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = StrSQL
            cmd.Connection = CrearConexion()
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function


    Public Function EjecutaSP(ByVal SPName As String, ByVal PEntrada() As SqlParameter) As Boolean
        Dim cmd As New SqlCommand
        Try
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = SPName
            cmd.Connection = CrearConexion()

            For i As Integer = 0 To UBound(PEntrada)
                cmd.Parameters.Add(PEntrada(i))
                Console.WriteLine(PEntrada(i).ParameterName)
            Next i
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            Throw ex
            Return False
        End Try

    End Function


    'Public Function EjecutaSP(ByVal SPName As String, ByVal PEntrada() As SqlParameter, ByRef PSalida() As SqlParameter) As String
    '    Dim cmd As New SqlCommand
    '    Try
    '        cmd.CommandType = CommandType.StoredProcedure
    '        cmd.CommandText = SPName
    '        cmd.Connection = CrearConexion()
    '        For i As Integer = 0 To UBound(PEntrada)
    '            cmd.Parameters.Add(PEntrada(i))
    '        Next i

    '        For j As Integer = 0 To UBound(PSalida)
    '            cmd.Parameters.Add(PSalida(j))
    '            cmd.Parameters(PSalida(j).ParameterName).Direction = ParameterDirection.Output
    '        Next j
    '        cmd.ExecuteNonQuery()
    '        Return cmd.Parameters(cmd.Parameters.Count - 1).Value.ToString
    '    Catch ex As Exception
    '        Throw ex
    '        Return ""
    '    End Try
    'End Function


    Public Function ExecuteScalar(ByVal StrSQL As String) As String
        Dim cmd As New SqlCommand
        Dim resultado As String
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = StrSQL
            cmd.Connection = CrearConexion()
            resultado = CType(cmd.ExecuteScalar(), String)
            Return resultado
        Catch ex As Exception
            Throw ex
            Return resultado
        End Try
    End Function



End Class
