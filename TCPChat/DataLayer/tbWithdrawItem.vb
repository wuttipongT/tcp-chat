Imports WMS_STD_Formula
Imports WMS_STD_Formula.W_Module
Public Class tbWithdrawItem : Inherits DBType_SQLServer
    Dim _dataTable As DataTable = New DataTable
#Region "ENBUM"
    Public objStatus As enuOperation_Type
    Public Enum enuOperation_Type
        INSERT
        DELETE
        UPDATE
        SEARCH
        NULL
    End Enum
#End Region
#Region "PROPERTIES"
    Public Property DataTable()
        Get
            Return _dataTable
        End Get
        Set(ByVal value)
            _dataTable = value
        End Set
    End Property
#End Region
#Region "CONSTRUCTOR DESTRUCTOR"
    Public Sub New(ByVal Operation_Type As enuOperation_Type)
        MyBase.New()

        objStatus = Operation_Type
    End Sub
#End Region

#Region "UPDATE"
    Public Sub Update_StatusPicToLight(ByVal Withdraw_Index As String, ByVal WithdrawItem_Index As String)
        Dim strSQL As String = ""
        Try
            strSQL = "UPDATE tb_WithdrawItem SET Status_PickToLight='2' WHERE Withdraw_Index = '" & Withdraw_Index & "' AND WithdrawItem_Index = '" & WithdrawItem_Index & "'"
            DBExeNonQuery(strSQL, eCommandType.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
#End Region
End Class
