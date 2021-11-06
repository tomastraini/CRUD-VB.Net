Imports System.Data.SqlClient
Public Class frmCargarVentaProductos
    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub
    Private Sub Cargar_consulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreVentFlicker()
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Text = DateTime.Now.ToShortDateString
        TextBox5.Text = 0
        Label1.Text = frmLogin.Label2.Text
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select * from usuarios where usuario like '%" & Label1.Text & "%'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "usuarios")
            TextBox4.Text = ds.Tables("usuarios").Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frmBuscarClienteVenta.Show()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        frmBuscarFormasPagoVenta.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                If (TextBox3.Text <> "") Then
                    Dim con As New SqlConnection(My.Settings.myConnectionString3)
                    Dim sql As String = ("insert into ventas values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "')")
                    Dim com As New SqlCommand(sql, con)
                    Try
                        Dim ds As New DataSet
                        Dim da As New SqlDataAdapter(com)
                        da.Fill(ds, "turnos")
                        Hide()
                        frmDetalleVenta.Show()
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try



                Else
                    MsgBox("No se ha seleccionado una forma de pago!")
                End If
            Else
                MsgBox("No se ha seleccionado un cliente!")
            End If
        Else
            MsgBox("No se ha seleccionado una fecha!")
        End If

    End Sub
End Class