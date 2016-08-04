Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports System.Net.NetworkInformation


Public Class frmPickToLight
    Private WithEvents myChat As New TCPChat

    Private strHostName As String
    Private addr() As IPAddress
    Private Const remotePort As String = "9999", hostPort As String = "9999"
    Private hostIP As String = "", remoteIP As String = ""

    Public Shared countErrRec As Integer = 0, countErrRecVal As Integer
    Dim listWithdrawIndexCurrent As New List(Of String)
    Dim DTCollect As New DataTable

    Private Const Success As String = "Y", ErrorMessage As String = "E"


    Private Sub frmGetData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim appSet As New System.Configuration.AppSettingsReader()

        WMS_STD_Formula.W_Module.WV_ConnectionString = appSet.GetValue("ConnectionString", GetType(String))

        strHostName = Dns.GetHostName()
        Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)
        addr = ipEntry.AddressList

        Dim i As Integer
        For i = 0 To addr.Length - 1
            If addr(i).AddressFamily = AddressFamily.InterNetwork Then
                StatusLabel_adapter.Text = "host " & AddressFamily.InterNetwork & _
                                            String.Format(" IP: {0}", addr(i).ToString)
                Exit For
            End If
        Next

        hostIP = addr(i).ToString
        remoteIP = appSet.GetValue("Config_remoteIP", GetType(String))
        LabelIP.Text = "IP : " & hostIP
        LabelRemote.Text = "Remote : " & remoteIP
        LabelPort.Text = "Port : " & remotePort
        countErrRecVal = appSet.GetValue("Config_TotalErrorMessage", GetType(Integer))
        Timer1.Interval = appSet.GetValue("Config_IntervalTime", GetType(Integer))


        If My.Computer.Network.Ping(remoteIP) Then Connect_Socket()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'If sendStatus = False Then Timer1.Stop()

        Dim tbWithdrawPickToLight As New tbWithdrawPickToLight(tbWithdrawPickToLight.enuOperation_Type.SEARCH)
        Dim DTTemporary As New DataTable

        tbWithdrawPickToLight.SelectData()
        DTTemporary = tbWithdrawPickToLight.DataTable
        Try
            If DTCollect.Rows.Count > 0 Then
                Dim drDTCollect As DataRow() = DTCollect.Select("Status_Send = '0' AND OrderBy Is Not NULL")
                If Not DTTemporary.Columns.Contains("OrderBy") Then DTTemporary.Columns.Add("OrderBy", GetType(String))

                For Each DTCollect As DataRow In drDTCollect
                    Dim drDTTemporary As DataRow() = DTTemporary.Select("Index_Table ='" & DTCollect("Index_Table") & "'")
                    drDTTemporary(0)("OrderBy") = DTCollect("OrderBy")
                Next

                DTCollect = DTTemporary
            Else
                DTCollect = DTTemporary
                DTCollect.Columns.Add("OrderBy", GetType(String))
            End If

            Dim textSender As String = ""
            'Dim arrTextSender() As String

            If DTCollect.Rows.Count > 0 Then
                Dim Search_Index As Integer

                If countErrRec = countErrRecVal Then

                    Dim drFullOrderBy As DataRow() = DTCollect.Select("OrderBy Is Null")
                    If drFullOrderBy.Length = 0 Then

                        For Each drClear As DataRow In DTCollect.Rows
                            drClear("OrderBy") = Nothing
                        Next

                    End If

                    For Each drDTCollect As DataRow In DTCollect.Rows
                        If (listWithdrawIndexCurrent.Item(0) = drDTCollect.Item("Index_Table")) And drDTCollect.Item("OrderBy").ToString = String.Empty Then Search_Index = CInt(drDTCollect.Item("Index_Table")) : Exit For
                    Next

                    Dim drDTCollectAddValue As DataRow() = DTCollect.Select("Index_Table = '" & Search_Index & "'")
                    Dim drTotalOrderBy As DataRow() = DTCollect.Select(" ", "OrderBy DESC", DataViewRowState.CurrentRows)
                    If (drTotalOrderBy(0)("OrderBy").ToString = "") Then drDTCollectAddValue(0)("OrderBy") = DTCollect.Rows.Count Else drDTCollectAddValue(0)("OrderBy") = drTotalOrderBy(0)("OrderBy") + 1

                    countErrRec = 0
                    listWithdrawIndexCurrent.Clear()

                End If

                Dim dataView As New DataView(DTCollect)
                dataView.Sort = "OrderBy ASC"
                DTCollect = dataView.ToTable()

                textSender = DTCollect.Rows(0)("TCP_Data")
                StatusLabel_send.Image = My.Resources.ledCornerGray

                myChat.SendData(textSender.Trim)
                'arrTextSender = textSender.Split("|")
                lbout.Items.Add("> " & textSender)
                lbout.SelectedIndex = lbout.Items.Count - 1
                listWithdrawIndexCurrent.Add(DTCollect.Rows(0)("Index_Table"))
                Timer1.Stop()
              
                
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Connect_Socket()
        Try
            myChat.connect(remoteIP, remotePort)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    '
    ' connection status
    '
    Private Sub connection(ByVal status As Boolean) Handles myChat.connection
        If status Then
            StatusLabel_adapter.Image = My.Resources.ledCornerGreen
            StatusLabel_receive.Image = My.Resources.ledCornerOrange

            Timer1.Start()
            btnConnect.Enabled = False
            btnDisconnect.Enabled = True
        Else
            StatusLabel_adapter.Image = My.Resources.ledCornerGray
            StatusLabel_receive.Image = My.Resources.ledCornerGray
            StatusLabel_send.Image = My.Resources.ledCornerGray
            btnConnect.Enabled = True
            btnDisconnect.Enabled = False
        End If
    End Sub

    Private Sub txtOut(ByVal txt As String) Handles myChat.Datareceived
        'If txt = String.Empty Then Exit Sub
        lbout.Items.Add("< " & txt)
        lbout.SelectedIndex = lbout.Items.Count - 1
        'listWithdrawIndexCurrent.Add(txt)
        If txt.Trim.Equals("Hello client") Then Exit Sub

        Dim tbWithdrawPickToLight As New tbWithdrawPickToLight(tbWithdrawPickToLight.enuOperation_Type.UPDATE)
        Dim chk_Withdraw_PickToLight As String = tbWithdrawPickToLight.chk_Withdraw_PickToLight()

        Try
            If txt.Trim.Equals(ErrorMessage) Then
                tbWithdrawPickToLight.Update_StatusSend(listWithdrawIndexCurrent.Item(0), "2") ' Is Error
                Dim drUpdaateStatus As DataRow() = DTCollect.Select("Index_Table = '" & listWithdrawIndexCurrent.Item(0) & "'")
                Dim index As Integer = DTCollect.Rows.IndexOf(drUpdaateStatus(0))
                DTCollect.Rows(index).Delete()
                Timer1.Start()
                listWithdrawIndexCurrent.Clear()
                Exit Sub
            End If

            If txt.Split("|")(4).Equals(Success) Then 'Y คือ ส่งสำเร็จ

                tbWithdrawPickToLight.Update_StatusSend(listWithdrawIndexCurrent.Item(0), "1")
                Dim drUpdaateStatus As DataRow() = DTCollect.Select("Index_Table = '" & listWithdrawIndexCurrent.Item(0) & "'")
                drUpdaateStatus(0)("Status_Send") = "1"
                listWithdrawIndexCurrent.Clear()
                If countErrRec > 0 Then countErrRec = 0
                Timer1.Start()

            Else
                If txt.Split("|")(4).Equals(ErrorMessage) Then countErrRec += 1 : Timer1.Start() 'Else Timer1.Stop() 'E คือ Error รอ การส่งใหม่ อีกรอบ
            End If

            If txt.Split("|")(4).Equals("R") Then
                'System.Threading.Thread.Sleep(1000)
                myChat.SendData(txt.Split("|")(0) & "|" & txt.Split("|")(1) & "|" & txt.Split("|")(2) & "|" & txt.Split("|")(3) & "|Y|")
                lbout.Items.Add("> " & txt.Split("|")(0) & "|" & txt.Split("|")(1) & "|" & txt.Split("|")(2) & "|" & txt.Split("|")(3) & "|Y|")
                lbout.SelectedIndex = lbout.Items.Count - 1
                Dim tbWithdrawItem As New tbWithdrawItem(tbWithdrawItem.enuOperation_Type.UPDATE)
                tbWithdrawItem.Update_StatusPicToLight(txt.Split("|")(0), txt.Split("|")(1))
                If countErrRec > 0 Then countErrRec = 0
                Timer1.Start()
            End If

            If listWithdrawIndexCurrent.Count > 1 Then listWithdrawIndexCurrent.RemoveAt(listWithdrawIndexCurrent.Count - 1)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    '
    '  senda data OK NOK
    '
    Private Sub sendata(ByVal sendStatus As Boolean) Handles myChat.sendOK
        If sendStatus Then
            StatusLabel_send.Image = My.Resources.ledCornerGreen
        Else
            StatusLabel_send.Image = My.Resources.ledCornerRed
        End If
    End Sub
    '
    ' receive data OK NOK
    '
    Private Sub rdata(ByVal receiveStatus As Boolean) Handles myChat.recOK
        If receiveStatus Then
            StatusLabel_receive.Image = My.Resources.ledCornerGreen
            StatusLabel_adapter.Text = "local " & myChat.Local.ToString & _
                                       " remote" & myChat.Remote.ToString

        Else
            StatusLabel_receive.Image = My.Resources.ledCornerRed
        End If

    End Sub

    Private Sub TabControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.Click
        getWithdrawPickToLightView()
    End Sub

    Public Sub grdBindData()
        Dim tbWithdrawPickToLight As New tbWithdrawPickToLight(tbWithdrawPickToLight.enuOperation_Type.SEARCH)
        tbWithdrawPickToLight.getAlldata()

        DataGridView1.DataSource = tbWithdrawPickToLight.DataTable
    End Sub

    Private Sub frmGetData_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        myChat.disconnect()
        Timer1.Stop()

        listWithdrawIndexCurrent.Clear()
        countErrRec = 0
        DTCollect.Rows.Clear()
        ' myChat2.disconnect()
    End Sub

    Private Sub Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Search.Click
        getWithdrawPickToLightView()
    End Sub

    Private Sub getWithdrawPickToLightView()
        Dim strWhere As String = ""
        If Me.rdbWithdrawIndex.Checked = True Then
            strWhere = " AND Withdraw_Index = '" & txtKeySearch.Text & "'"
        ElseIf Me.rdbWithdrawItemIndex.Checked = True Then
            strWhere = " AND WithdrawItem_Index = '" & txtKeySearch.Text & "'"
        ElseIf Me.rdbTCPData.Checked = True Then
            strWhere = " AND TCP_Data = '" & txtKeySearch.Text & "'"
        ElseIf Me.rdbStatus.Checked = True Then
            strWhere = " AND Status = '" & txtKeySearch.Text & "'"
        ElseIf Me.rdbStatusSend.Checked = True Then
            strWhere = " AND Status_Send = '" & cboKeySearch.SelectedValue.ToString & "'"
        ElseIf Me.rboAddStep.Checked = True Then
            strWhere = " AND Add_Step LIKE '%" & cboKeySearch.SelectedValue.ToString & "%'"
        End If
        Dim tbWithdrawPickToLight As New tbWithdrawPickToLight(tbWithdrawPickToLight.enuOperation_Type.SEARCH)
        tbWithdrawPickToLight.getAlldata(strWhere)

        DataGridView1.DataSource = tbWithdrawPickToLight.DataTable
    End Sub

    Private Sub rboAddStep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rboAddStep.Click
        Dim dtCboKeySearch As New DataTable
        dtCboKeySearch.Columns.Add("Index", GetType(Integer))
        dtCboKeySearch.Columns.Add("Value", GetType(String))

        dtCboKeySearch.Rows.Add(1, "Add Or Update")
        dtCboKeySearch.Rows.Add(2, "Delete Item")
        dtCboKeySearch.Rows.Add(3, "Cancel")

        With cboKeySearch
            .ValueMember = "Value"
            .DisplayMember = "Value"
            .DataSource = dtCboKeySearch
            .SelectedIndex = 0
        End With
        cboKeySearch.Visible = True
    End Sub

    Private Sub rboAddStep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rboAddStep.CheckedChanged
        clearCBO()
    End Sub

    Private Sub clearCBO()
        cboKeySearch.Visible = False
        cboKeySearch.DataSource = Nothing
        cboKeySearch.Items.Clear()
    End Sub

    Private Sub rdbStatusSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbStatusSend.Click
        Dim dtCboKeySearch As New DataTable
        dtCboKeySearch.Columns.Add("Index", GetType(Integer))
        dtCboKeySearch.Columns.Add("Value", GetType(String))

        dtCboKeySearch.Rows.Add(1, "ถูกส่งข้อมูลแล้ว")
        dtCboKeySearch.Rows.Add(0, "ยังไม่ส่งข้อมูล")

        With cboKeySearch
            .ValueMember = "Index"
            .DisplayMember = "Value"
            .DataSource = dtCboKeySearch
            .SelectedIndex = 0
        End With
        cboKeySearch.Visible = True
    End Sub

    Private Sub rdbStatusSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbStatusSend.CheckedChanged
        clearCBO()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Connect_Socket()
    End Sub

    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        myChat.disconnect()
        Timer1.Stop()
        listWithdrawIndexCurrent.Clear()
        countErrRec = 0
        DTCollect.Rows.Clear()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        lbout.Items.Clear()
    End Sub


End Class

''' <summary>
''' TCP sevices. Ellen Ramcke 2010
''' sends and receives Encoding.ASCII data
''' the max length of one data frame is 8196 bytes
''' last update: 8.1.2011
''' 10.5.2011 - remote/local  IP Endpoint
''' update 24.6.2011 DNS 
''' </summary>
''' <remarks></remarks>
''' 

Public Class TCPChat

#Region "EVENT"
    ''' <summary>
    ''' Event data send back to calling form
    ''' </summary>
    Public Event Datareceived(ByVal txt As String)
    ''' <summary>
    ''' connection status back to form True: ok
    ''' </summary>
    Public Event connection(ByVal cStatus As Boolean)
    ''' <summary>
    ''' data send successfull (True)
    ''' </summary>
    Public Event sendOK(ByVal sStatus As Boolean)
    ''' <summary>
    ''' data receive successfull (True)
    ''' </summary>
    Public Event recOK(ByVal sReceive As Boolean)
#End Region

#Region "Variable"
    'Private serverRuns As Boolean
    'Private server As TcpListener
    Private sc As SynchronizationContext
    Private isConnected, receiveStatus, sendStatus As Boolean
    Private iRemote, pLocal As EndPoint

    Private TCPClient As Sockets.TcpClient
    Private ListenerStream As Sockets.NetworkStream
    Dim flag As Boolean = False

    Private Const BYTES_TO_READ As Integer = 255
    Private readBuffer(BYTES_TO_READ) As Byte
#End Region

#Region "Constructor Destructor"
    Public Sub New()
        MyBase.New()
        '_timer = New System.Timers.Timer()
        'AddHandler _timer.Elapsed, New System.Timers.ElapsedEventHandler(AddressOf Handler)
    End Sub
#End Region

#Region "Property"
    ''' <summary>
    ''' reads endpoints
    ''' </summary>
    Public ReadOnly Property Remote() As EndPoint
        Get
            Return iRemote
        End Get
    End Property
    ''' <summary>
    ''' reads local point
    ''' </summary>
    Public ReadOnly Property Local() As EndPoint
        Get
            Return pLocal
        End Get
    End Property

    Public ReadOnly Property Connected() As Boolean
        Get
            Return isConnected
        End Get
    End Property

    Public ReadOnly Property ResponseTxt() As Boolean
        Get
            Return ListenerStream.DataAvailable
        End Get
    End Property
#End Region

#Region "Connect, Disconnect"
    ''' <summary>
    ''' TCP connect with server
    ''' </summary>
    ''' 
    Public Sub connect(ByVal clientAdress As String, ByVal clientPort As Integer)
        'Try
        '    If Not (TCPClient.Client.Poll(1, SelectMode.SelectRead) And TCPClient.Client.Available = 0) Then RaiseEvent connection(True) : Exit Sub
        'Catch e As Exception

        sc = SynchronizationContext.Current

        Try

            TCPClient = New TcpClient()
            'ListenerStream = TCPClient.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)

        Catch ex As Exception
            MsgBox("TCP Client Create: " & ex.Message, MsgBoxStyle.Exclamation)
            isConnected = False

        End Try

        Try
            With TCPClient
                .Connect(clientAdress, clientPort)
                .GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing)
                isConnected = True
            End With

        Catch ex As Exception
            MsgBox("TCP Client listen: " & ex.Message, MsgBoxStyle.Exclamation)
            isConnected = False
        Finally
            RaiseEvent connection(isConnected)
        End Try
        'End Try
    End Sub

    Private Sub doRead(ByVal ar As System.IAsyncResult)
        Dim totalRead As Integer
        Dim sb As New StringBuilder
        Try
            'If ar.IsCompleted = False Then System.Threading.Thread.Sleep(1000 * 60 * 2)
            'If Not My.Computer.Network.Ping("192.168.1.145") Then System.Threading.Thread.Sleep(1000 * 60 * 2)
            totalRead = TCPClient.GetStream.EndRead(ar)

            iRemote = TCPClient.Client.RemoteEndPoint
            pLocal = TCPClient.Client.LocalEndPoint

        Catch ex As ObjectDisposedException
            MsgBox("DoAccept ObjectDisposedException " & ex.Message, MsgBoxStyle.Exclamation)
        End Try

        If totalRead > 0 Then
            Dim receivedString As String = System.Text.Encoding.UTF8.GetString(readBuffer, 0, totalRead)
            sb.Append(receivedString)
            receiveStatus = True
        End If

        Try
            TCPClient.GetStream.BeginRead(readBuffer, 0, BYTES_TO_READ, AddressOf doRead, Nothing) 'Begin the 

        Catch ex As TimeoutException
            MsgBox("doAcceptData timeout: " & ex.Message, MsgBoxStyle.Exclamation)
            receiveStatus = False
            Exit Sub
        Catch ex As Exception
            MsgBox("doAcceptData: " & ex.Message, MsgBoxStyle.Exclamation)
            receiveStatus = False
            Exit Sub
        Finally
            RaiseEvent recOK(receiveStatus)
        End Try

        sc.Post(New SendOrPostCallback(AddressOf OnDatareceived), sb.ToString)
    End Sub

    ''' <summary>
    ''' disConnect server
    ''' </summary>
    Public Sub disconnect()
        Try
            isConnected = False

        Catch ex As Exception
            MsgBox("disConnect tcp client: " & ex.Message, MsgBoxStyle.Exclamation)
            isConnected = True
        Finally
            RaiseEvent connection(isConnected)
        End Try
    End Sub
#End Region

#Region "Send, Receive"
    ''' <summary>
    ''' TCP send data
    ''' </summary>

    Public Sub SendData(ByVal txt As String)
        'Try
        '    txt = txt & vbNewLine
        '    Dim SendByte() As Byte = System.Text.Encoding.ASCII.GetBytes(txt)
        '    TCPClient.Client.Send(SendByte)
        '    TCPClient.ReceiveTimeout = 500

        '    sendStatus = True
        '    '_timer.Enabled = True
        'Catch ex As Exception
        '    sendStatus = False
        '    MsgBox("sendData: " & ex.Message, MsgBoxStyle.Exclamation)
        'Finally
        '    RaiseEvent sendOK(sendStatus)
        'End Try

        Dim sw As IO.StreamWriter
        Try
            SyncLock TCPClient.GetStream
                sw = New IO.StreamWriter(TCPClient.GetStream)
                sw.Write(txt & vbNewLine)
                sw.Flush()

                sendStatus = True
            End SyncLock
        Catch ex As Exception
            sendStatus = False
            MsgBox("sendData: " & ex.Message, MsgBoxStyle.Exclamation)
        Finally
            RaiseEvent sendOK(sendStatus)
        End Try
    End Sub
    '
    ' now data to calling class and UI thread
    '
    Private Sub OnDatareceived(ByVal state As Object)
        RaiseEvent Datareceived(state.ToString)

    End Sub
    ''' <summary>
    ''' TCP asynchronous receive on secondary timer
    ''' last update 10.5.2011
    ''' </summary>
    ''' 
    Public Sub Handler(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)
        '' _list.Add(DateTime.Now.ToString())

        Try

            If ListenerStream.DataAvailable = False Then Exit Sub

            If ListenerStream.CanRead = True Then
                Dim sb As New StringBuilder
                'System.Threading.Thread.Sleep(1000)
                iRemote = TCPClient.Client.RemoteEndPoint
                pLocal = TCPClient.Client.LocalEndPoint

                Dim ReciveByte(TCPClient.ReceiveBufferSize) As Byte

                ListenerStream.Read(ReciveByte, 0, TCPClient.ReceiveBufferSize)
                'Dim arr() = System.Text.Encoding.ASCII.GetString(ReciveByte).Split("|")
                'If arr.Length > 1 Then
                '    If (Not arr(0).ToString.Substring(0, arr(0).Length - 5 - 8).Trim.Equals("Hello client")) Then
                '        sb.Append(arr(0) & "|" & arr(1) & "|" & arr(2) & "|" & arr(3) & "|" & arr(4) & "|") 'Encoding.ASCII.GetString(buf, 0, buf.Length)

                '    Else
                '        sb.Append(arr(0).ToString.Substring(12, arr(0).Length - 12) & "|" & arr(1) & "|" & arr(2) & "|" & arr(3) & "|" & arr(4) & "|") 'Encoding.ASCII.GetString(buf, 0, buf.Length)

                '    End If
                '    'sb.Append(System.Text.Encoding.ASCII.GetString(ReciveByte) & vbNewLine)
                '    ' post data
                '    receiveStatus = True
                '    sc.Post(New SendOrPostCallback(AddressOf OnDatareceived), sb.ToString)
                'Else
                '    Dim ar As String() = System.Text.Encoding.ASCII.GetString(ReciveByte).Split(vbNewLine)

                '    For i As Integer = 0 To ar.Length - 1
                '        If ar(i).Contains("E") Then
                '            sb.Append(ar(i))
                '            receiveStatus = True
                '            sc.Post(New SendOrPostCallback(AddressOf OnDatareceived), sb.ToString)
                '        End If
                '    Next
                'End If

                'sb.Append(System.Text.Encoding.ASCII.GetString(ReciveByte))
                'sc.Post(New SendOrPostCallback(AddressOf OnDatareceived), System.Text.Encoding.ASCII.GetString(ReciveByte).ToString)
            End If


        Catch ex As Exception
            MsgBox("doAcceptData: " & ex.Message, MsgBoxStyle.Exclamation)
            receiveStatus = False
        Finally
            RaiseEvent recOK(receiveStatus)
        End Try
    End Sub ' No Use

#End Region

End Class
