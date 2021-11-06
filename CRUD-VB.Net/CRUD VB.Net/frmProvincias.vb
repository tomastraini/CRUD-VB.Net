Imports System.Data.SqlClient

Public Class frmProvincias
    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub
    Private Sub frmProvincias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreVentFlicker()
        TextBox2.Focus()

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

        Dim con3 As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql3 As String = ("select max(cast(id_provincia as int)) from provincias")
        Dim com3 As New SqlCommand(sql3, con3)
        Try
            Dim ds3 As New DataSet
            Dim da3 As New SqlDataAdapter(com3)
            da3.Fill(ds3, "provincias")
            TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
            TextBox1.Text = TextBox1.Text + 1
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
                TextBox1.Text = ds.Tables("provincia").Rows(0).Item(0)
                TextBox2.Text = ds.Tables("provincia").Rows(0).Item(1)

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
                TextBox1.Text = ds.Tables("provincia").Rows(0).Item(0)
                TextBox2.Text = ds.Tables("provincia").Rows(0).Item(1)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim con3 As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql3 As String = ("select max(cast(id_provincia as int)) from provincias")
        Dim com3 As New SqlCommand(sql3, con3)
        Try
            Dim ds3 As New DataSet
            Dim da3 As New SqlDataAdapter(com3)
            da3.Fill(ds3, "provincias")
            TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
            TextBox1.Text = TextBox1.Text + 1
            TextBox2.Text = ""
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

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                Dim con As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql As String = ("update provincias set provincia= '" & TextBox2.Text & "' where id_provincia = " & TextBox1.Text & "")
                Dim com As New SqlCommand(sql, con)
                Try
                    Dim ds As New DataSet
                    Dim da As New SqlDataAdapter(com)
                    da.Fill(ds, "usuarios")
                    DataGridView1.DataSource = ds.Tables("usuarios")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox2.Focus()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Dim con2 As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql2 As String = ("select id_provincia as ID, provincia as 'Provincia'from provincias")
                Dim com2 As New SqlCommand(sql2, con2)
                Try
                    Dim ds2 As New DataSet
                    Dim da2 As New SqlDataAdapter(com2)
                    da2.Fill(ds2, "usuarios")
                    DataGridView1.DataSource = ds2.Tables("usuarios")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Dim con3 As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql3 As String = ("select max(cast(id_provincia as int)) from provincias")
                Dim com3 As New SqlCommand(sql3, con3)
                Try
                    Dim ds3 As New DataSet
                    Dim da3 As New SqlDataAdapter(com3)
                    da3.Fill(ds3, "usuarios")
                    TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
                    TextBox1.Text = TextBox1.Text + 1
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else
                MsgBox("No ha llenado el campo de provincias!")



            End If
        Else
            MsgBox("No ha llenado el campo de ID de provincias!")
        End If
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                Dim con As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql As String = ("insert into provincias
values('" & TextBox1.Text & "', '" & TextBox2.Text & "')")
                Dim com As New SqlCommand(sql, con)
                Try
                    Dim ds As New DataSet
                    Dim da As New SqlDataAdapter(com)
                    da.Fill(ds, "usuarios")
                    DataGridView1.DataSource = ds.Tables("usuarios")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox2.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Dim con2 As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql2 As String = ("select id_provincia as ID, provincia as 'Provincia'from provincias")
                Dim com2 As New SqlCommand(sql2, con2)
                Try
                    Dim ds2 As New DataSet
                    Dim da2 As New SqlDataAdapter(com2)
                    da2.Fill(ds2, "usuarios")
                    DataGridView1.DataSource = ds2.Tables("usuarios")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Dim con3 As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql3 As String = ("select max(cast(id_provincia as int)) from provincias")
                Dim com3 As New SqlCommand(sql3, con3)
                Try
                    Dim ds3 As New DataSet
                    Dim da3 As New SqlDataAdapter(com3)
                    da3.Fill(ds3, "usuarios")
                    TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
                    TextBox1.Text = TextBox1.Text + 1
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else
                MsgBox("No ha llenado el campo de provincias!")



            End If
        Else
            MsgBox("No ha llenado el campo de ID de provincias!")
        End If
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                Dim con As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql As String = ("delete from provincias
where id_provincia = " & TextBox1.Text & "")
                Dim com As New SqlCommand(sql, con)
                Try
                    Dim ds As New DataSet
                    Dim da As New SqlDataAdapter(com)
                    da.Fill(ds, "usuarios")
                    DataGridView1.DataSource = ds.Tables("usuarios")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox2.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Dim con2 As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql2 As String = ("select id_provincia as ID, provincia as 'Provincia'from provincias")
                Dim com2 As New SqlCommand(sql2, con2)
                Try
                    Dim ds2 As New DataSet
                    Dim da2 As New SqlDataAdapter(com2)
                    da2.Fill(ds2, "usuarios")
                    DataGridView1.DataSource = ds2.Tables("usuarios")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

                Dim con3 As New SqlConnection(My.Settings.myConnectionString3)
                Dim sql3 As String = ("select max(cast(id_provincia as int)) from provincias")
                Dim com3 As New SqlCommand(sql3, con3)
                Try
                    Dim ds3 As New DataSet
                    Dim da3 As New SqlDataAdapter(com3)
                    da3.Fill(ds3, "usuarios")
                    TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
                    TextBox1.Text = TextBox1.Text + 1
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Else
                MsgBox("No ha llenado el campo de provincias!")



            End If
        Else
            MsgBox("No ha llenado el campo de ID de provincias!")
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnA.PerformClick()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PreVentFlicker()
        TextBox2.Focus()

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

        Dim con3 As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql3 As String = ("select max(cast(id_provincia as int)) from provincias")
        Dim com3 As New SqlCommand(sql3, con3)
        Try
            Dim ds3 As New DataSet
            Dim da3 As New SqlDataAdapter(com3)
            da3.Fill(ds3, "provincias")
            TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
            TextBox1.Text = TextBox1.Text + 1
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class