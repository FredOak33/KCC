<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgTerm = New System.Windows.Forms.DataGridView()
        Me.dgCC = New System.Windows.Forms.DataGridView()
        Me.dgLevel = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.dgTeam = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTeam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.KCC.My.Resources.Resources.hn200x40dbtp
        Me.PictureBox1.Location = New System.Drawing.Point(16, 15)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(269, 59)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'dgTerm
        '
        Me.dgTerm.AllowUserToAddRows = False
        Me.dgTerm.AllowUserToDeleteRows = False
        Me.dgTerm.AllowUserToOrderColumns = True
        Me.dgTerm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTerm.GridColor = System.Drawing.Color.Blue
        Me.dgTerm.Location = New System.Drawing.Point(312, 134)
        Me.dgTerm.Margin = New System.Windows.Forms.Padding(4)
        Me.dgTerm.Name = "dgTerm"
        Me.dgTerm.RowHeadersWidth = 51
        Me.dgTerm.Size = New System.Drawing.Size(1190, 132)
        Me.dgTerm.TabIndex = 1
        '
        'dgCC
        '
        Me.dgCC.AllowUserToAddRows = False
        Me.dgCC.AllowUserToDeleteRows = False
        Me.dgCC.AllowUserToOrderColumns = True
        Me.dgCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCC.GridColor = System.Drawing.Color.Blue
        Me.dgCC.Location = New System.Drawing.Point(312, 267)
        Me.dgCC.Margin = New System.Windows.Forms.Padding(4)
        Me.dgCC.Name = "dgCC"
        Me.dgCC.RowHeadersWidth = 51
        Me.dgCC.Size = New System.Drawing.Size(1190, 132)
        Me.dgCC.TabIndex = 2
        '
        'dgLevel
        '
        Me.dgLevel.AllowUserToAddRows = False
        Me.dgLevel.AllowUserToDeleteRows = False
        Me.dgLevel.AllowUserToOrderColumns = True
        Me.dgLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLevel.GridColor = System.Drawing.Color.Blue
        Me.dgLevel.Location = New System.Drawing.Point(312, 400)
        Me.dgLevel.Margin = New System.Windows.Forms.Padding(4)
        Me.dgLevel.Name = "dgLevel"
        Me.dgLevel.RowHeadersWidth = 51
        Me.dgLevel.Size = New System.Drawing.Size(1190, 132)
        Me.dgLevel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(64, 145)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 31)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "TERMINATED"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(95, 260)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(171, 31)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cost Center"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 395)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 31)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Level 1 Supervisor"
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.Green
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.White
        Me.btnGo.Location = New System.Drawing.Point(1339, 43)
        Me.btnGo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(125, 69)
        Me.btnGo.TabIndex = 14
        Me.btnGo.Text = "Process"
        Me.btnGo.UseVisualStyleBackColor = False
        '
        'dgTeam
        '
        Me.dgTeam.AllowUserToAddRows = False
        Me.dgTeam.AllowUserToDeleteRows = False
        Me.dgTeam.AllowUserToOrderColumns = True
        Me.dgTeam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTeam.GridColor = System.Drawing.Color.Blue
        Me.dgTeam.Location = New System.Drawing.Point(312, 533)
        Me.dgTeam.Margin = New System.Windows.Forms.Padding(4)
        Me.dgTeam.Name = "dgTeam"
        Me.dgTeam.RowHeadersWidth = 51
        Me.dgTeam.Size = New System.Drawing.Size(1190, 132)
        Me.dgTeam.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(173, 541)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 31)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "TEAM"
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1515, 701)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgTeam)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgLevel)
        Me.Controls.Add(Me.dgCC)
        Me.Controls.Add(Me.dgTerm)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FrmMain"
        Me.Text = "KCC [Key Contact Compare]"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTerm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTeam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dgTerm As DataGridView
    Friend WithEvents dgCC As DataGridView
    Friend WithEvents dgLevel As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGo As Button
    Friend WithEvents dgTeam As DataGridView
    Friend WithEvents Label4 As Label
End Class
