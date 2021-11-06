Imports System.Data.SqlClient
Public Class frmABMClientes
    Private Sub frmABMClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox2.Focus()
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "clientes")
            DataGridView1.DataSource = ds.Tables("clientes")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Close()
    End Sub

    Private Sub tbxBus_KeyDown(sender As Object, e As KeyEventArgs) Handles tbxBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(tbxBus.Text) Then
                Dim myConnectionString = My.Settings.myConnectionString3
                Dim con As New SqlConnection(myConnectionString)
                Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp
where id_cliente = '" & tbxBus.Text & "' or razon_social = '" & tbxBus.Text & "' or telefono = '" & tbxBus.Text & "'
or localidad = '" & tbxBus.Text & "'")
                Dim com As New SqlCommand(sql, con)
                Try
                    Dim ds As New DataSet
                    Dim da As New SqlDataAdapter(com)
                    da.Fill(ds, "Proveedores")
                    DataGridView1.DataSource = ds.Tables("Proveedores")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            ElseIf Not IsNumeric(tbxBus.text) Then
                Dim myConnectionString = My.Settings.myConnectionString3
                Dim con As New SqlConnection(myConnectionString)
                Dim sql As String = ("select cast(id_cliente as int)
as 'ID', razon_social as 'Nombre', telefono, localidad as 'Ciudad'
from clientes join localidades on localidades.cp = clientes.cp  where razon_social = '" & tbxBus.Text & "'
or domicilio = '" & tbxBus.Text & "' or telefono = '" & tbxBus.Text & "' or id_cliente = '" & tbxBus.Text & "'")
                Dim com As New SqlCommand(sql, con)
                Try
                    Dim ds As New DataSet
                    Dim da As New SqlDataAdapter(com)
                    da.Fill(ds, "Proveedores")
                    DataGridView1.DataSource = ds.Tables("Proveedores")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("No hay nada que buscar!")
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tbxBus.Select()
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "clientes")
            DataGridView1.DataSource = ds.Tables("clientes")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan campos por completar!")
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("insert into clientes values('" & TextBox2.Text & "', '" & TextBox3.Text & "', " & TextBox4.Text & ")")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                DataGridView1.DataSource = ds.Tables("clientes")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            tbxBus.Select()
            Dim myConnectionString2 = My.Settings.myConnectionString3
            Dim con2 As New SqlConnection(myConnectionString)
            Dim sql2 As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "clientes")
                DataGridView1.DataSource = ds2.Tables("clientes")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            TextBox5.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox2.Focus()
        End If
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan campos por completar!")
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("delete from clientes where id_cliente = " & TextBox1.Text & " 
and razon_social = '" & TextBox2.Text & "' and telefono = '" & TextBox3.Text & "' and cp = " & TextBox4.Text & "")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "proveedores")
                DataGridView1.DataSource = ds.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox("Hay datos cargados de ese cliente!")
            End Try

            Dim myConnectionString2 = My.Settings.myConnectionString3
            Dim con2 As New SqlConnection(myConnectionString)
            Dim sql2 As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "proveedores")
                DataGridView1.DataSource = ds2.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox2.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan campos por completar!")
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("update clientes
set razon_social = '" & TextBox2.Text & "', telefono = '" & TextBox3.Text & "',
cp = " & TextBox4.Text & " where id_cliente = " & TextBox1.Text & "")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                DataGridView1.DataSource = ds.Tables("clientes")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox2.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Dim myConnectionString2 = My.Settings.myConnectionString3
            Dim con2 As New SqlConnection(myConnectionString)
            Dim sql2 As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp ")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "clientes")
                DataGridView1.DataSource = ds2.Tables("clientes")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ClientesCP.Show()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = -1 Then
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                DataGridView1.DataSource = ds.Tables("clientes")
                DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
                DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Descending)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', cast(telefono as bigint) as 'Teléfono', 
localidad as 'Localidad', clientes.cp as 'CP' from clientes join localidades on localidades.cp = clientes.cp
where id_cliente = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "' or
localidades.cp = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'
or cast(telefono as bigint)  like '%" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "%'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")

                TextBox1.Text = ds.Tables("clientes").Rows(0).Item(0)
                TextBox2.Text = ds.Tables("clientes").Rows(0).Item(1)
                TextBox3.Text = ds.Tables("clientes").Rows(0).Item(2)
                TextBox5.Text = ds.Tables("clientes").Rows(0).Item(3)
                TextBox4.Text = ds.Tables("clientes").Rows(0).Item(4)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', cast(telefono as bigint) as 'Teléfono', 
localidad as 'Localidad',clientes.cp from clientes join localidades on localidades.cp = clientes.cp  
where razon_social = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'
or localidad = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")

                TextBox1.Text = ds.Tables("clientes").Rows(0).Item(0)
                TextBox2.Text = ds.Tables("clientes").Rows(0).Item(1)
                TextBox3.Text = ds.Tables("clientes").Rows(0).Item(2)
                TextBox5.Text = ds.Tables("clientes").Rows(0).Item(3)
                TextBox4.Text = ds.Tables("clientes").Rows(0).Item(4)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub tbxBus_TextChanged(sender As Object, e As EventArgs) Handles tbxBus.TextChanged
        If IsNumeric(tbxBus.Text) Then
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp
where concat(id_cliente, cast(telefono as bigint), clientes.cp)
like '%" & tbxBus.Text & "%' ORDER BY cast(id_cliente as int)")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "Proveedores")
                DataGridView1.DataSource = ds.Tables("Proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf Not IsNumeric(tbxBus.Text) Then
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', telefono as 'Teléfono', 
localidad as 'Localidad' from clientes join localidades on localidades.cp = clientes.cp
where concat(razon_social, localidad) like '%" & tbxBus.Text & "%' ORDER BY cast(id_cliente as int)")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "Proveedores")
                DataGridView1.DataSource = ds.Tables("Proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If (e.KeyCode = Keys.Tab) Then
            TextBox3.Focus()

        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If (e.KeyCode = Keys.Tab) Then
            PictureBox1.Focus()

        End If
    End Sub
End Class
