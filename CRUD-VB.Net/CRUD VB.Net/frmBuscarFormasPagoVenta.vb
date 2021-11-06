Imports System.Data.SqlClient
Public Class frmBuscarFormasPagoVenta
    Private Sub frmBuscarFormasPagoVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select id_forma_pago as 'ID', 
descript_forma_pago as 'Forma de pago' from formas_pago")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select 
id_forma_pago as 'ID', descript_forma_pago as 'Forma de pago' from formas_pago")
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
id_forma_pago as 'ID', descript_forma_pago as 'Forma de pago' from formas_pago")
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
id_forma_pago as 'ID', descript_forma_pago as 'Forma de pago' from formas_pago
where id_forma_pago = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                frmCargarVentaProductos.TextBox3.Text = ds.Tables("clientes").Rows(0).Item(0)
                frmCargarVentaProductos.TextBox7.Text = ds.Tables("clientes").Rows(0).Item(1)
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select 
id_forma_pago as 'ID', descript_forma_pago as 'Forma de pago' from formas_pago
where descript_forma_pago
like '%" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "%'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "clientes")
                frmCargarVentaProductos.TextBox3.Text = ds.Tables("clientes").Rows(0).Item(0)
                frmCargarVentaProductos.TextBox7.Text = ds.Tables("clientes").Rows(0).Item(1)
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class