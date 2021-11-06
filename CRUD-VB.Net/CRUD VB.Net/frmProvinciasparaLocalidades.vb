Imports System.Data.SqlClient
Public Class frmProvinciasparaLocalidades
    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With
    End Sub

    Private Sub frmProvinciasparaLocalidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreVentFlicker()
        tbxBus.Focus()
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select id_provincia as 'ID', provincia as 'Provincia' from provincias")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "usuarios")
            DataGridView1.DataSource = ds.Tables("usuarios")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tbxBus_TextChanged(sender As Object, e As EventArgs) Handles tbxBus.TextChanged
        If (tbxBus.Text = "") Then

            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("select id_provincia as 'ID', provincia as 'Provincia' from provincias")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "usuarios")
                DataGridView1.DataSource = ds.Tables("usuarios")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("select id_provincia as 'ID', provincia as 'Provincia' from provincias where concat(id_provincia, provincia) like '%" & tbxBus.Text & "%'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "usuarios")
                DataGridView1.DataSource = ds.Tables("usuarios")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PreVentFlicker()
        tbxBus.Focus()
        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select id_provincia as 'ID', provincia as 'Provincia' from provincias")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "usuarios")
            DataGridView1.DataSource = ds.Tables("usuarios")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex = -1 Then

            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("select id_provincia as ID, provincia as 'Provincia from provincias")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "provincias")
                DataGridView1.DataSource = ds.Tables("provincias")
                DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
                DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Descending)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then

            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("select * from provincias
where id_provincia = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "provincia")
                frmLocalidades.TextBox2.Text = ds.Tables("provincia").Rows(0).Item(0)
                frmLocalidades.TextBox4.Text = ds.Tables("provincia").Rows(0).Item(1)
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else

            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("select * from provincias
where provincia = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "provincia")
                frmLocalidades.TextBox2.Text = ds.Tables("provincia").Rows(0).Item(0)
                frmLocalidades.TextBox4.Text = ds.Tables("provincia").Rows(0).Item(1)
                Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class