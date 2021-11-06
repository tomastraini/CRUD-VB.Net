Imports System.Data.SqlClient
Public Class frmAgregarProductos
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim frmAx = New frmBuscarProductos
        frmAx.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select max(cast(id_producto as int)) from productos")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "productos")
            Dim inx As Integer
            TextBox4.Text = ds.Tables("productos").Rows(0).Item(0)
            inx = TextBox4.Text
            inx = inx + 1
            TextBox4.Text = inx
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("insert into productos values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "')")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "turnos")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            Button2.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("
update productos 
set descripcion = '" & TextBox1.Text & "', 
stock = '" & TextBox2.Text & "', 
importe = '" & TextBox3.Text & "' 
where id_producto = '" & TextBox4.Text & "'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "turnos")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            Button2.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("delete from productos where id_producto = '" & TextBox4.Text & "'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "clientes")
            MsgBox("Eliminación exitosa!")
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            Button2.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class