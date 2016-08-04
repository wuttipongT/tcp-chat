<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPickToLight
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.StatusLabel_adapter = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusLabel_send = New System.Windows.Forms.ToolStripStatusLabel
        Me.StatusLabel_receive = New System.Windows.Forms.ToolStripStatusLabel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lbout = New System.Windows.Forms.ListBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelPort = New System.Windows.Forms.Label
        Me.LabelIP = New System.Windows.Forms.Label
        Me.LabelRemote = New System.Windows.Forms.Label
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.btnDisconnect = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Withdraw_Index = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WithdrawItem_Index = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TCP_Data = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status_Send = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Add_Step = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.col_Index_Table = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cboKeySearch = New System.Windows.Forms.ComboBox
        Me.Search = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rboAddStep = New System.Windows.Forms.RadioButton
        Me.rdbTCPData = New System.Windows.Forms.RadioButton
        Me.rdbStatusSend = New System.Windows.Forms.RadioButton
        Me.rdbWithdrawIndex = New System.Windows.Forms.RadioButton
        Me.rdbStatus = New System.Windows.Forms.RadioButton
        Me.rdbWithdrawItemIndex = New System.Windows.Forms.RadioButton
        Me.txtKeySearch = New System.Windows.Forms.TextBox
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 600
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel_adapter, Me.StatusLabel_send, Me.StatusLabel_receive})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 367)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(852, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusLabel_adapter
        '
        Me.StatusLabel_adapter.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.StatusLabel_adapter.Image = Global.PickToLight.My.Resources.Resources.ledCornerGray
        Me.StatusLabel_adapter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StatusLabel_adapter.Name = "StatusLabel_adapter"
        Me.StatusLabel_adapter.Size = New System.Drawing.Size(96, 17)
        Me.StatusLabel_adapter.Text = "adapter name"
        Me.StatusLabel_adapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusLabel_send
        '
        Me.StatusLabel_send.AutoSize = False
        Me.StatusLabel_send.Image = Global.PickToLight.My.Resources.Resources.ledCornerGray
        Me.StatusLabel_send.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.StatusLabel_send.Name = "StatusLabel_send"
        Me.StatusLabel_send.Size = New System.Drawing.Size(70, 17)
        Me.StatusLabel_send.Text = "send data"
        '
        'StatusLabel_receive
        '
        Me.StatusLabel_receive.AutoSize = False
        Me.StatusLabel_receive.Image = Global.PickToLight.My.Resources.Resources.ledCornerGray
        Me.StatusLabel_receive.Name = "StatusLabel_receive"
        Me.StatusLabel_receive.Size = New System.Drawing.Size(70, 17)
        Me.StatusLabel_receive.Text = "receive"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(1, 30)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(852, 367)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(844, 329)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TCP Send"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbout)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnClear)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnConnect)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnDisconnect)
        Me.SplitContainer1.Size = New System.Drawing.Size(838, 323)
        Me.SplitContainer1.SplitterDistance = 286
        Me.SplitContainer1.TabIndex = 14
        '
        'lbout
        '
        Me.lbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbout.FormattingEnabled = True
        Me.lbout.Location = New System.Drawing.Point(0, 0)
        Me.lbout.Name = "lbout"
        Me.lbout.Size = New System.Drawing.Size(838, 277)
        Me.lbout.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.LabelPort)
        Me.Panel2.Controls.Add(Me.LabelIP)
        Me.Panel2.Controls.Add(Me.LabelRemote)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(533, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(305, 33)
        Me.Panel2.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.Label1.Location = New System.Drawing.Point(-3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 26)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "|"
        '
        'LabelPort
        '
        Me.LabelPort.AutoSize = True
        Me.LabelPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LabelPort.Location = New System.Drawing.Point(241, 12)
        Me.LabelPort.Name = "LabelPort"
        Me.LabelPort.Size = New System.Drawing.Size(59, 13)
        Me.LabelPort.TabIndex = 2
        Me.LabelPort.Text = "Port : 9999"
        '
        'LabelIP
        '
        Me.LabelIP.AutoSize = True
        Me.LabelIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LabelIP.Location = New System.Drawing.Point(11, 12)
        Me.LabelIP.Name = "LabelIP"
        Me.LabelIP.Size = New System.Drawing.Size(95, 13)
        Me.LabelIP.TabIndex = 0
        Me.LabelIP.Text = "IP : 192.168.1.106"
        '
        'LabelRemote
        '
        Me.LabelRemote.AutoSize = True
        Me.LabelRemote.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        Me.LabelRemote.Location = New System.Drawing.Point(114, 12)
        Me.LabelRemote.Name = "LabelRemote"
        Me.LabelRemote.Size = New System.Drawing.Size(100, 13)
        Me.LabelRemote.TabIndex = 1
        Me.LabelRemote.Text = "Remote : 192.168.1"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(226, 2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(63, 30)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnConnect
        '
        Me.btnConnect.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnConnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnConnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Location = New System.Drawing.Point(0, 2)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(105, 30)
        Me.btnConnect.TabIndex = 11
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = False
        '
        'btnDisconnect
        '
        Me.btnDisconnect.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnDisconnect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDisconnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control
        Me.btnDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisconnect.Location = New System.Drawing.Point(112, 2)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(105, 30)
        Me.btnDisconnect.TabIndex = 10
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(844, 329)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Database Data Information"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Withdraw_Index, Me.WithdrawItem_Index, Me.TCP_Data, Me.Status, Me.Status_Send, Me.Add_Step, Me.col_Index_Table})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(198, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(643, 323)
        Me.DataGridView1.TabIndex = 2
        '
        'Withdraw_Index
        '
        Me.Withdraw_Index.DataPropertyName = "Withdraw_Index"
        Me.Withdraw_Index.FillWeight = 150.0!
        Me.Withdraw_Index.HeaderText = "Withdraw Index"
        Me.Withdraw_Index.Name = "Withdraw_Index"
        Me.Withdraw_Index.Width = 150
        '
        'WithdrawItem_Index
        '
        Me.WithdrawItem_Index.DataPropertyName = "WithdrawItem_Index"
        Me.WithdrawItem_Index.FillWeight = 180.0!
        Me.WithdrawItem_Index.HeaderText = "WithdrawItem Index"
        Me.WithdrawItem_Index.Name = "WithdrawItem_Index"
        Me.WithdrawItem_Index.Width = 180
        '
        'TCP_Data
        '
        Me.TCP_Data.DataPropertyName = "TCP_Data"
        Me.TCP_Data.FillWeight = 300.0!
        Me.TCP_Data.HeaderText = "TCP Data"
        Me.TCP_Data.Name = "TCP_Data"
        Me.TCP_Data.Width = 300
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'Status_Send
        '
        Me.Status_Send.DataPropertyName = "Status_Send"
        Me.Status_Send.HeaderText = "Status Send"
        Me.Status_Send.Name = "Status_Send"
        '
        'Add_Step
        '
        Me.Add_Step.DataPropertyName = "Add_Step"
        Me.Add_Step.HeaderText = "Add Step"
        Me.Add_Step.Name = "Add_Step"
        '
        'col_Index_Table
        '
        Me.col_Index_Table.DataPropertyName = "Index_Table"
        Me.col_Index_Table.HeaderText = "Index_Table"
        Me.col_Index_Table.Name = "col_Index_Table"
        Me.col_Index_Table.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.cboKeySearch)
        Me.Panel1.Controls.Add(Me.Search)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtKeySearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(195, 323)
        Me.Panel1.TabIndex = 1
        '
        'cboKeySearch
        '
        Me.cboKeySearch.FormattingEnabled = True
        Me.cboKeySearch.Location = New System.Drawing.Point(3, 177)
        Me.cboKeySearch.Name = "cboKeySearch"
        Me.cboKeySearch.Size = New System.Drawing.Size(185, 21)
        Me.cboKeySearch.TabIndex = 8
        Me.cboKeySearch.Visible = False
        '
        'Search
        '
        Me.Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Search.Location = New System.Drawing.Point(52, 203)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(89, 30)
        Me.Search.TabIndex = 7
        Me.Search.Text = "ค้นหา"
        Me.Search.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.rboAddStep)
        Me.GroupBox1.Controls.Add(Me.rdbTCPData)
        Me.GroupBox1.Controls.Add(Me.rdbStatusSend)
        Me.GroupBox1.Controls.Add(Me.rdbWithdrawIndex)
        Me.GroupBox1.Controls.Add(Me.rdbStatus)
        Me.GroupBox1.Controls.Add(Me.rdbWithdrawItemIndex)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 168)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Fillter"
        '
        'rboAddStep
        '
        Me.rboAddStep.AutoSize = True
        Me.rboAddStep.Location = New System.Drawing.Point(7, 137)
        Me.rboAddStep.Name = "rboAddStep"
        Me.rboAddStep.Size = New System.Drawing.Size(69, 17)
        Me.rboAddStep.TabIndex = 6
        Me.rboAddStep.TabStop = True
        Me.rboAddStep.Text = "Add Step"
        Me.rboAddStep.UseVisualStyleBackColor = True
        '
        'rdbTCPData
        '
        Me.rdbTCPData.AutoSize = True
        Me.rdbTCPData.Location = New System.Drawing.Point(7, 68)
        Me.rdbTCPData.Name = "rdbTCPData"
        Me.rdbTCPData.Size = New System.Drawing.Size(72, 17)
        Me.rdbTCPData.TabIndex = 3
        Me.rdbTCPData.TabStop = True
        Me.rdbTCPData.Text = "TCP Data"
        Me.rdbTCPData.UseVisualStyleBackColor = True
        '
        'rdbStatusSend
        '
        Me.rdbStatusSend.AutoSize = True
        Me.rdbStatusSend.Location = New System.Drawing.Point(7, 114)
        Me.rdbStatusSend.Name = "rdbStatusSend"
        Me.rdbStatusSend.Size = New System.Drawing.Size(83, 17)
        Me.rdbStatusSend.TabIndex = 5
        Me.rdbStatusSend.TabStop = True
        Me.rdbStatusSend.Text = "Status Send"
        Me.rdbStatusSend.UseVisualStyleBackColor = True
        '
        'rdbWithdrawIndex
        '
        Me.rdbWithdrawIndex.AutoSize = True
        Me.rdbWithdrawIndex.Location = New System.Drawing.Point(7, 22)
        Me.rdbWithdrawIndex.Name = "rdbWithdrawIndex"
        Me.rdbWithdrawIndex.Size = New System.Drawing.Size(99, 17)
        Me.rdbWithdrawIndex.TabIndex = 1
        Me.rdbWithdrawIndex.TabStop = True
        Me.rdbWithdrawIndex.Text = "Withdraw Index"
        Me.rdbWithdrawIndex.UseVisualStyleBackColor = True
        '
        'rdbStatus
        '
        Me.rdbStatus.AutoSize = True
        Me.rdbStatus.Location = New System.Drawing.Point(7, 91)
        Me.rdbStatus.Name = "rdbStatus"
        Me.rdbStatus.Size = New System.Drawing.Size(55, 17)
        Me.rdbStatus.TabIndex = 4
        Me.rdbStatus.TabStop = True
        Me.rdbStatus.Text = "Status"
        Me.rdbStatus.UseVisualStyleBackColor = True
        '
        'rdbWithdrawItemIndex
        '
        Me.rdbWithdrawItemIndex.AutoSize = True
        Me.rdbWithdrawItemIndex.Location = New System.Drawing.Point(7, 45)
        Me.rdbWithdrawItemIndex.Name = "rdbWithdrawItemIndex"
        Me.rdbWithdrawItemIndex.Size = New System.Drawing.Size(122, 17)
        Me.rdbWithdrawItemIndex.TabIndex = 2
        Me.rdbWithdrawItemIndex.TabStop = True
        Me.rdbWithdrawItemIndex.Text = "Withdraw Item Index"
        Me.rdbWithdrawItemIndex.UseVisualStyleBackColor = True
        '
        'txtKeySearch
        '
        Me.txtKeySearch.Location = New System.Drawing.Point(3, 177)
        Me.txtKeySearch.Name = "txtKeySearch"
        Me.txtKeySearch.Size = New System.Drawing.Size(185, 20)
        Me.txtKeySearch.TabIndex = 0
        '
        'frmPickToLight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 389)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmPickToLight"
        Me.Text = "PickToLight"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel_adapter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusLabel_send As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusLabel_receive As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents rdbWithdrawItemIndex As System.Windows.Forms.RadioButton
    Friend WithEvents rdbWithdrawIndex As System.Windows.Forms.RadioButton
    Friend WithEvents txtKeySearch As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbTCPData As System.Windows.Forms.RadioButton
    Friend WithEvents rdbStatusSend As System.Windows.Forms.RadioButton
    Friend WithEvents rdbStatus As System.Windows.Forms.RadioButton
    Friend WithEvents Search As System.Windows.Forms.Button
    Friend WithEvents rboAddStep As System.Windows.Forms.RadioButton
    Friend WithEvents cboKeySearch As System.Windows.Forms.ComboBox
    Friend WithEvents Withdraw_Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WithdrawItem_Index As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TCP_Data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status_Send As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Add_Step As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_Index_Table As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelIP As System.Windows.Forms.Label
    Friend WithEvents LabelRemote As System.Windows.Forms.Label
    Friend WithEvents LabelPort As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbout As System.Windows.Forms.ListBox
End Class
