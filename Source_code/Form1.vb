Option Explicit On
Imports System.Runtime.InteropServices

Public Class Form1

    Public Const PROCESS_ALL_ACCESS As Integer = &HFFFF
    Public Const ARRAY_SIZE As Integer = 120

    <DllImport("psapi.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Shared Function EnumProcesses(<MarshalAs(UnmanagedType.LPArray, ArraySubType:=UnmanagedType.U4), [In](), [Out]()> ByVal processIds As Integer(), ByVal size As Integer, <[Out]()> ByRef needed As Integer) As Boolean
    End Function

    Private Declare Function OpenProcess Lib "kernel32" (ByVal dwDesiredAccess As Integer, ByVal blnheritHandle As Boolean, ByVal dwAppProcessId As Integer) As IntPtr
    Private Declare Function K32EmptyWorkingSet Lib "kernel32" (ByVal hProcess As IntPtr) As Integer
    Private Declare Function CloseHandle Lib "kernel32" (ByVal hObject As IntPtr) As Integer
    Private arrayBytesSize = ARRAY_SIZE * Marshal.SizeOf(CInt(0))
    Private processIds(ARRAY_SIZE) As Integer
    Private bytesCopied As Integer
    Private hProcess As IntPtr
    Private RunCount As Integer

    Dim MessageFail As String = "發生錯誤，請確認訊息。" & vbCrLf & vbCrLf & "Error. Check the message."
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Application.CommandLineArgs().Count > 0 Then
            If My.Application.CommandLineArgs(0).ToUpper = "GO" Then
                ClearSysRAM_All()
                Timer2.Enabled = True
                Me.Hide()
            End If
        Else
            RichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
            RichTextBox1.SelectAll()
            RichTextBox1.SelectionFont = New Font("Arial", 9)
            RichTextBox1.DeselectAll()

            Form2.RichTextBox1.LanguageOption = RichTextBoxLanguageOptions.UIFonts
            Form2.RichTextBox1.SelectAll()
            Form2.RichTextBox1.SelectionFont = New Font("Arial", 9)
            Form2.RichTextBox1.DeselectAll()

        End If


    End Sub

    Public Sub ClearSysRAM_All()

        If EnumProcesses(processIds, arrayBytesSize, bytesCopied) Then
            For Each thePID As Integer In processIds
                If thePID <> 0 Then
                    hProcess = OpenProcess(PROCESS_ALL_ACCESS, False, thePID)
                    K32EmptyWorkingSet(hProcess)
                    CloseHandle(hProcess)
                End If
            Next
        End If


    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        ClearSysRAM_All()
        RunCount += 1
        If RunCount = 7 Then End

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            Process.Start("schtasks", "/delete /TN IneedMoreRAM /F")
            MsgBox("已卸載。你可以直接刪除剩下檔案。" & vbCrLf & vbCrLf & "Uninstalled. You can just delete me now.", 0, "")
        Catch ex As Exception
            MsgBox(MessageFail + vbCrLf + vbCrLf + ex.Message, 0, "")
        End Try

    End Sub


    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If Form2.ShowDialog = DialogResult.Cancel Then
            Exit Sub
        End If


        If MsgBox("確認要安裝於此路徑嗎?" + vbCrLf + vbCrLf +
                  "Are you sure to install IneedMoreRAM in here?" + vbCrLf + vbCrLf + Application.StartupPath, MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim BIGxml As String
            BIGxml = My.Resources.XML1
            BIGxml = Replace(BIGxml, "$$PATH$$", Application.ExecutablePath)

            Dim objWriter As New System.IO.StreamWriter("IneedMoreRAM.XML", False, System.Text.UnicodeEncoding.Unicode)
            objWriter.Write(BIGxml)
            objWriter.Close()

            Process.Start("schtasks", "/create /TN IneedMoreRAM /XML IneedMoreRAM.XML")

            My.Application.DoEvents()
            System.Threading.Thread.Sleep(100)
            My.Application.DoEvents()

            My.Computer.FileSystem.DeleteFile("IneedMoreRAM.XML")

            MsgBox("已安裝完成，請不要刪除我。重啟系統後生效。" & vbCrLf & vbCrLf & "Install done. Don't delete me, and reboot system to take effect.", 0, "")

        Catch ex As Exception

            MsgBox(MessageFail + vbCrLf + vbCrLf + ex.Message, 0, "")

        End Try



    End Sub


End Class
