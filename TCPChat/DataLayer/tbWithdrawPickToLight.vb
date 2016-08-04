Imports WMS_STD_Formula
Imports WMS_STD_Formula.W_Module

Public Class tbWithdrawPickToLight : Inherits DBType_SQLServer
    Private _dataTable As DataTable = New DataTable
    Private _Index_Table As String
    Private _Withdraw_Index As String
    Private _WithdrawItem_Index As String
    Private _TCP_Data As String
    Private _Status As Integer
    Private _Status_Send As Integer
    Private _Add_Step As String
#Region "ENUM"
    Private objStatus As enuOperation_Type

    Public Enum enuOperation_Type
        SEARCH
        UPDATE
        NULL
    End Enum
#End Region
#Region "PROPERTIES"
    Public Property DataTable() As DataTable
        Get
            Return _dataTable
        End Get
        Set(ByVal value As DataTable)
            _dataTable = value
        End Set
    End Property
#End Region
#Region "CONSTRUCTOR, DESTRUCTOR"
    Public Sub New(ByVal Operation_Type As enuOperation_Type)
        MyBase.New()

        objStatus = Operation_Type

    End Sub

    Public Sub New()
        'Intailize Without a course
    End Sub


#End Region

#Region "SEARCH"
    Public Sub SelectData(Optional ByVal pFilterValue As String = "")

        Dim strSQL As String
        Dim strWhere As String

        Try

            'SQLServerCommand.Connection = Connection

            strSQL = "SELECT TOP 1 * FROM tb_Withdraw_PickToLight WHERE Status = 1 AND Status_Send = 0 ORDER BY Index_Table"
            'strWhere = ""
            ' strWhere += "WHERE Withdraw_Index = '" & pFilterValue & "'"

            _dataTable = DBExeQuery(strSQL, eCommandType.Text, eData.DataReader)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub getAlldata(Optional ByVal pFilterValue As String = "")
        Dim strSQL As String
        Dim strWhere As String
        Try

            'SQLServerCommand.Connection = Connection

            strSQL = "SELECT * FROM tb_Withdraw_PickToLight WHERE 1=1"
            strWhere = ""
            If Not pFilterValue = "" Then
                strWhere = pFilterValue
            End If

            strSQL = strSQL + strWhere & " ORDER BY Index_Table"
            _dataTable = DBExeQuery(strSQL, eCommandType.Text, eData.DataReader)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function chk_Withdraw_PickToLight() As String
        Dim strSQL As String
        Try
            strSQL = "SELECT case when COUNT(Index_Table) > 0 then 0 else 1 end as Rows FROM tb_Withdraw_PickToLight WHERE Status_Send = 0"
            Return DBExeQuery_Scalar(strSQL, eCommandType.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return Nothing

    End Function
#End Region

#Region "UPDATE"
    Public Sub Update_StatusSend(ByVal Index_Table As String, ByVal Status_Send As String)
        Dim strSQL As String = ""

        Try
            strSQL = "UPDATE tb_Withdraw_PickToLight SET Status_Send = '" & Status_Send & "' WHERE Index_Table = '" & Index_Table & "'"
            DBExeNonQuery(strSQL, eCommandType.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

#End Region

End Class
