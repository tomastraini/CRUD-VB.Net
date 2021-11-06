Imports System.Data.SqlClient
Public Class frmMenu

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmLogin.Close()
        Close()
    End Sub


    Private Sub ABMClientesToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CambiarContraseñasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarContraseñasToolStripMenuItem.Click
        Dim frm As New frmUsuarios
        frm.ShowDialog()

    End Sub
    Private Sub frmMenu_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Back Then
            Button1.PerformClick()
        End If
    End Sub




    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreVentFlicker()
        Timer1.Start()
        Label3.Text = frmLogin.Label2.Text
        If (frmLogin.Label5.Text = "User") Or (frmLogin.Label5.Text = "user") Then
            CambiarContraseñasToolStripMenuItem.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmLogin.tbxCon.Text = ""
        frmLogin.tbxUs.Text = ""
        Hide()
        frmLogin.tbxUs.Focus()
        frmLogin.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = DateTime.Now.ToShortDateString

        Dim t As Date = Date.Now
        Label4.Text = t.ToString("h:mm:ss tt")
    End Sub

    Private Sub CargarProvinciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarProvinciasToolStripMenuItem.Click
        frmProvincias.Show()

    End Sub

    Private Sub CargarLocalidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarLocalidadesToolStripMenuItem.Click
        frmLocalidades.Show()

    End Sub

    Private Sub ABMClientesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ABMClientesToolStripMenuItem.Click
        frmABMClientes.Show()
    End Sub

    Private Sub CargarProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarProductosToolStripMenuItem.Click
        frmAgregarProductos.Show()
    End Sub

    Private Sub CargarVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarVentasToolStripMenuItem.Click
        frmCargarVentaProductos.Show()
    End Sub

    Private Sub ReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem.Click
        frmVisorReporte.Show()
    End Sub
End Class