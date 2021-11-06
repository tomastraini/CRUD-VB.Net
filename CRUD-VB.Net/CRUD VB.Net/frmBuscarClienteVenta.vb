Imports System.Data.SqlClient
Public Class frmBuscarClienteVenta
    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub frmBuscarClienteVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
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
localidades.cp = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "' or
cast(telefono as bigint) = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                frmCargarVentaProductos.TextBox2.Text = ds.Tables("clientes").Rows(0).Item(0)
                frmCargarVentaProductos.TextBox6.Text = ds.Tables("clientes").Rows(0).Item(1)
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select
id_cliente AS 'ID', razon_social as 'Razón social', cast(telefono as bigint) as 'Teléfono', 
localidad as 'Localidad',clientes.cp from clientes join localidades on localidades.cp = clientes.cp  
where concat(razon_social, localidad) like '%" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "%'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                frmCargarVentaProductos.TextBox2.Text = ds.Tables("clientes").Rows(0).Item(0)
                frmCargarVentaProductos.TextBox6.Text = ds.Tables("clientes").Rows(0).Item(1)
                Close()
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
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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
End Class