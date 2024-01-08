<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TextBox1 = New TextBox()
        btnUpdate = New Button()
        BtnToggleStatus = New Button()
        ListView1 = New ListView()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        LocationPathTextBox = New TextBox()
        SetLocationBtn = New Button()
        GroupBox1 = New GroupBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TextBox1
        ' 
        TextBox1.Enabled = False
        TextBox1.Location = New Point(12, 546)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(256, 23)
        TextBox1.TabIndex = 1
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Enabled = False
        btnUpdate.Location = New Point(272, 545)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(100, 25)
        btnUpdate.TabIndex = 2
        btnUpdate.Text = "Rename"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' BtnToggleStatus
        ' 
        BtnToggleStatus.Enabled = False
        BtnToggleStatus.Location = New Point(12, 494)
        BtnToggleStatus.Name = "BtnToggleStatus"
        BtnToggleStatus.Size = New Size(360, 25)
        BtnToggleStatus.TabIndex = 2
        BtnToggleStatus.Text = "Toggle"
        BtnToggleStatus.UseVisualStyleBackColor = True
        ' 
        ' ListView1
        ' 
        ListView1.FullRowSelect = True
        ListView1.Location = New Point(12, 78)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(360, 410)
        ListView1.TabIndex = 5
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' LocationPathTextBox
        ' 
        LocationPathTextBox.Location = New Point(18, 29)
        LocationPathTextBox.Name = "LocationPathTextBox"
        LocationPathTextBox.Size = New Size(294, 23)
        LocationPathTextBox.TabIndex = 1
        ' 
        ' SetLocationBtn
        ' 
        SetLocationBtn.Location = New Point(304, 19)
        SetLocationBtn.Name = "SetLocationBtn"
        SetLocationBtn.Size = New Size(51, 23)
        SetLocationBtn.TabIndex = 9
        SetLocationBtn.Text = "Set"
        SetLocationBtn.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(SetLocationBtn)
        GroupBox1.Location = New Point(12, 9)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(361, 54)
        GroupBox1.TabIndex = 10
        GroupBox1.TabStop = False
        GroupBox1.Text = "Mod Path"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(384, 581)
        Controls.Add(ListView1)
        Controls.Add(btnUpdate)
        Controls.Add(LocationPathTextBox)
        Controls.Add(TextBox1)
        Controls.Add(BtnToggleStatus)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        MaximumSize = New Size(400, 700)
        MinimumSize = New Size(400, 600)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Sorting of Isaac"
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnUpdate As Button
    Friend WithEvents BtnToggleStatus As Button
    Friend WithEvents btnMoveUp As Button
    Friend WithEvents btnMoveDown As Button
    Friend WithEvents btnMoveTop As Button
    Friend WithEvents btnMoveBottom As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents LocationPathTextBox As TextBox
    Friend WithEvents SetLocationBtn As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
