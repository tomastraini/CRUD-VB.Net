Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Public Class frmLogin
    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbxUs.Focus()
        PreVentFlicker()
        Timer1.Start()
    End Sub
    Private Sub txtUs_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles tbxUs.PreviewKeyDown
        If e.KeyCode = Keys.Tab Then

            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("use empresa select * from usuarios where usuario = '" & tbxUs.Text & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "usuarios")
                Label2.Text = CStr(ds.Tables(0).Rows(0).Item(1))
                Label3.Text = CStr(ds.Tables(0).Rows(0).Item(2))
                Label5.Text = CStr(ds.Tables(0).Rows(0).Item(3))
                Label4.Visible = True
                Label2.Visible = True
            Catch ex As Exception
                MsgBox("No existe ese usuario!")
            End Try
        End If
    End Sub
    Private Sub txtCon_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles tbxCon.PreviewKeyDown
        If e.KeyCode = Keys.Enter Then
            If (tbxUs.Text = "" Or tbxCon.Text = "") Then
                MsgBox("Introduce algún valor", vbCritical, "Sin información")

            ElseIf (tbxUs.Text = Label2.Text) And (tbxCon.Text = Label3.Text) Then
                Dim frm As New frmMenu
                Hide()

                frm.ShowDialog()
            ElseIf (tbxUs.Text <> Label2.Text) Or (tbxCon.Text <> Label3.Text) Then
                MsgBox("Contraseña incorrecta!")
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        Close()
    End Sub

    '  Private Sub tbxUs_Click(sender As Object, e As EventArgs) Handles tbxUs.Click

    ' Dim con As New SqlConnection(My.Settings.myConnectionString3)
    'Dim sql As String = ("select * from usuarios where usuario = '" & tbxUs.Text & "'")
    'Dim com As New SqlCommand(sql, con)
    'Try
    'Dim ds As New DataSet
    'Dim da As New SqlDataAdapter(com)
    '       da.Fill(ds, "usuarios")
    '      Label2.Text = CStr(ds.Tables(0).Rows(0).Item(1))
    '     Label3.Text = CStr(ds.Tables(0).Rows(0).Item(2))
    '    Label5.Text = CStr(ds.Tables(0).Rows(0).Item(3))
    '   Label4.Visible = True
    '  Label2.Visible = True
    'Catch ex As Exception
    '       MsgBox("No existe ese usuario!")
    'End Try
    'End Sub

    Private Sub tbxCon_Click(sender As Object, e As EventArgs) Handles tbxCon.Click

        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select * from usuarios where usuario = '" & tbxUs.Text & "'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "usuarios")
            Label2.Text = CStr(ds.Tables(0).Rows(0).Item(1))
            Label3.Text = CStr(ds.Tables(0).Rows(0).Item(2))
            Label5.Text = CStr(ds.Tables(0).Rows(0).Item(3))
            Label4.Visible = True
            Label2.Visible = True
        Catch ex As Exception
            MsgBox("No existe ese usuario!")
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        frmLoginUS.ShowDialog()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox("Te tengo la solución!")
        Dim webAddress As String = "https://www.youtube.com/watch?v=oHg5SJYRHA0"
        Process.Start(webAddress)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (tbxUs.Text = "" Or tbxCon.Text = "") Then
            MsgBox("Introduce algún valor", vbCritical, "Sin información")
        ElseIf (tbxUs.Text = Label2.Text) And (tbxCon.Text = Label3.Text) Then
            Dim frm As New frmMenu
            Hide()
            frm.ShowDialog()
        ElseIf (tbxUs.Text <> Label2.Text) Or (tbxCon.Text <> Label3.Text) Then
            MsgBox("Contraseña incorrecta!")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Label1.Text = DateTime.Now.ToShortDateString

        Dim t As Date = Date.Now
        Label6.Text = t.ToString("h:mm:ss tt")
    End Sub

    Private Sub frmLogin_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        tbxUs.Focus()
    End Sub

    Private Sub frmLogin_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        tbxUs.Focus()

    End Sub
End Class
