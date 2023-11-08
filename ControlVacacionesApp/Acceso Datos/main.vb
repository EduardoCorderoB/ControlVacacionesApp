Public Class Main
    Public StrSQL As String = ""

    Sub CrearConexion(ByVal clave As String)
        StrSQL = $"Provider=SQLOLEDB;Data Source=ECORDERO_LPT;Persist Security Info=True;User ID=MACESA\ecordero;Initial Catalog=ControlVacacionesBD;Password={clave};"
    End Sub

End Class
