Public Interface Acceso
    Sub crearComando(ByVal nombre As String)
    Sub addParam(ByVal nombre As String, ByVal parametro As Object)
    Sub transactionON()
    Sub transactionCancel()
    Sub transactionOK()
    Sub clearParams()
    Function executeSearchWithAdapter() As DataTable
    Function executeSearch() As Integer
    Function executeSearchWithStatus() As Integer
    Function executeSearchWithReturnValue() As Integer
    Sub conectar()
    Sub desconectar()
End Interface
