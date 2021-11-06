Imports System.Data.SqlClient
Public Class frmLocalidades
    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub
    Private Sub frmLocalidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PreVentFlicker()
        TextBox1.Focus()

        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "localidades")
            DataGridView1.DataSource = ds.Tables("localidades")
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
            Dim sql As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
From localidades
Join provincias On provincias.id_provincia = localidades.id_provincia")
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
            Dim sql As String = ("Select * From localidades
where cp = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
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
            Dim sql As String = ("select cp as 'Código postal', provincia as 'Provincia',
localidad as 'Localidad', provincias.id_provincia
From localidades
Join provincias On provincias.id_provincia = localidades.id_provincia
where concat(localidad, provincia) like '%" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "%'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "provincia")
                TextBox1.Text = ds.Tables("provincia").Rows(0).Item(0)
                TextBox4.Text = ds.Tables("provincia").Rows(0).Item(1)
                TextBox3.Text = ds.Tables("provincia").Rows(0).Item(2)
                TextBox2.Text = ds.Tables("provincia").Rows(0).Item(3)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox1.Focus()

    End Sub

    Private Sub tbxBus_TextChanged(sender As Object, e As EventArgs) Handles tbxBus.TextChanged
        If (tbxBus.Text = "") Then

            Dim con As New SqlConnection(My.Settings.myConnectionString3)
            Dim sql As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia")
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
            Dim sql As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia
where concat(cp, provincia, localidad) like '%" & tbxBus.Text & "%'")
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

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                If (TextBox3.Text <> "") Then
                    If (TextBox4.Text <> "") Then

                        Dim con As New SqlConnection(My.Settings.myConnectionString3)
                        Dim sql As String = ("insert into localidades
values('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "')")
                        Dim com As New SqlCommand(sql, con)
                        Try
                            Dim ds As New DataSet
                            Dim da As New SqlDataAdapter(com)
                            da.Fill(ds, "usuarios")
                            DataGridView1.DataSource = ds.Tables("usuarios")
                            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            TextBox1.Focus()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        Dim con2 As New SqlConnection(My.Settings.myConnectionString3)
                        Dim sql2 As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia")
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
                    Else
                        MsgBox("No ha llenado el campo de provincia!")
                    End If
                Else
                    MsgBox("No ha llenado el campo de nombre de localidad!")
                End If

            Else
                MsgBox("No ha llenado el campo de ID de provincia! Seleccione una provincia con la lupa")
            End If
        Else
            MsgBox("No ha llenado el campo de código postal!")
        End If
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                If (TextBox3.Text <> "") Then
                    If (TextBox4.Text <> "") Then
                        Dim con As New SqlConnection(My.Settings.myConnectionString3)
                        Dim sql As String = ("update localidades
set id_provincia = '" + TextBox2.Text + "', localidad = '" + TextBox3.Text + "' where cp = " + TextBox1.Text + "")
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
                        Dim sql2 As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia")
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
                    Else
                        MsgBox("No ha llenado el campo de provincia!")
                    End If
                Else
                    MsgBox("No ha llenado el campo de nombre de localidad!")
                End If

            Else
                MsgBox("No ha llenado el campo de ID de provincia! Seleccione una provincia con la lupa")
            End If
        Else
            MsgBox("No ha llenado el campo de código postal!")
        End If
    End Sub



    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If (TextBox1.Text <> "") Then
            If (TextBox2.Text <> "") Then
                If (TextBox3.Text <> "") Then
                    If (TextBox4.Text <> "") Then
                        Dim con As New SqlConnection(My.Settings.myConnectionString3)
                        Dim sql As String = ("delete from localidades
where id_provincia = '" & TextBox2.Text & "'
and cp = '" & TextBox1.Text & "'")
                        Dim com As New SqlCommand(sql, con)
                        Try
                            Dim ds As New DataSet
                            Dim da As New SqlDataAdapter(com)
                            da.Fill(ds, "usuarios")
                            DataGridView1.DataSource = ds.Tables("usuarios")
                            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                            TextBox1.Text = ""
                            TextBox2.Text = ""
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            TextBox1.Focus()
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try

                        Dim con2 As New SqlConnection(My.Settings.myConnectionString3)
                        Dim sql2 As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia")
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
                    Else
                        MsgBox("No ha llenado el campo de provincia!")
                    End If
                Else
                    MsgBox("No ha llenado el campo de nombre de localidad!")
                End If

            Else
                MsgBox("No ha llenado el campo de ID de provincia! Seleccione una provincia con la lupa")
            End If
        Else
            MsgBox("No ha llenado el campo de código postal!")
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnA.PerformClick()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PreVentFlicker()
        TextBox1.Focus()

        Dim con As New SqlConnection(My.Settings.myConnectionString3)
        Dim sql As String = ("select cp as 'Código postal', localidad as 'Localidad', provincia as 'Provincia'
from localidades 
join provincias on provincias.id_provincia = localidades.id_provincia")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "localidades")
            DataGridView1.DataSource = ds.Tables("localidades")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        frmProvinciasparaLocalidades.ShowDialog()
    End Sub
End Class