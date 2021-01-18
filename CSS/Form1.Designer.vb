Imports System.Security.AccessControl
Imports System.IO

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.txtInp = New System.Windows.Forms.Label()
        Me.lblInp = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnLock = New System.Windows.Forms.Button()
        Me.btnUnlock = New System.Windows.Forms.Button()
        Me.FBD1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.SuspendLayout()
        '
        'txtInp
        '
        Me.txtInp.AutoSize = True
        Me.txtInp.Location = New System.Drawing.Point(241, 80)
        Me.txtInp.Name = "txtInp"
        Me.txtInp.Size = New System.Drawing.Size(55, 13)
        Me.txtInp.TabIndex = 0
        Me.txtInp.Text = "Text Input"
        '
        'lblInp
        '
        Me.lblInp.Location = New System.Drawing.Point(244, 97)
        Me.lblInp.Name = "lblInp"
        Me.lblInp.Size = New System.Drawing.Size(237, 20)
        Me.lblInp.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(244, 124)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnLock
        '
        Me.btnLock.Location = New System.Drawing.Point(325, 124)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(75, 23)
        Me.btnLock.TabIndex = 3
        Me.btnLock.Text = "Lock"
        Me.btnLock.UseVisualStyleBackColor = True
        '
        'btnUnlock
        '
        Me.btnUnlock.Location = New System.Drawing.Point(406, 124)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(75, 23)
        Me.btnUnlock.TabIndex = 4
        Me.btnUnlock.Text = "Unlock"
        Me.btnUnlock.UseVisualStyleBackColor = True
        '
        'FBD1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnUnlock)
        Me.Controls.Add(Me.btnLock)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblInp)
        Me.Controls.Add(Me.txtInp)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtInp As Label
    Friend WithEvents lblInp As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnLock As Button
    Friend WithEvents btnUnlock As Button
    Friend WithEvents FBD1 As FolderBrowserDialog

    Private Sub FolderBrowserDialog1_HelpRequest(sender As Object, e As EventArgs) Handles FBD1.HelpRequest

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        With FBD1
            If .ShowDialog() = DialogResult.OK Then
                txtInp.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnLock.Click
        Dim fs As FileSystemSecurity = File.GetAccessControl(txtInp.Text)
        fs.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        File.SetAccessControl(txtInp.Text, fs)
        MessageBox.Show("Folder is now LOCKED!")
    End Sub

    Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
        Dim fs As FileSystemSecurity = File.GetAccessControl(txtInp.Text)
        fs.RemoveAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        File.SetAccessControl(txtInp.Text, fs)
        MessageBox.Show("Folder is now UNLOCKED!")
    End Sub
End Class
