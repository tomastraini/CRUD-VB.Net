Imports System.Data.SqlClient
Public Class frmAMBProveedores
    Private Sub frmAMBProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbxBus.Select()
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' from proveedores join localidades on localidades.cp = proveedores.cp")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "proveedores")
            DataGridView1.DataSource = ds.Tables("proveedores")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim myConnectionString3 = My.Settings.myConnectionString3
        Dim con3 As New SqlConnection(myConnectionString3)
        Dim sql3 As String = ("select max(cast(id_proveedor as int)) from proveedores ")

        Dim com3 As New SqlCommand(sql3, con3)
        Try
            Dim ds3 As New DataSet
            Dim da3 As New SqlDataAdapter(com3)
            da3.Fill(ds3, "proveedores")
            TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
            TextBox1.Text = TextBox1.Text + 1
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
        frmMenu.Show()
    End Sub
    Private Sub tbxBus_TextChanged(sender As Object, e As EventArgs) Handles tbxBus.TextChanged
        If IsNumeric(tbxBus.Text) Then
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' 
from proveedores join localidades on localidades.cp = proveedores.cp
where concat(id_proveedor, telefono_proveedor) like '%" & tbxBus.Text & "%' ORDER BY cast(id_proveedor as int)")
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
        ElseIf Not IsNumeric(tbxBus) Then
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' 
from proveedores join localidades on localidades.cp = proveedores.cp 
where concat(razon_social_proveedor, telefono_proveedor, localidad) like '%" & tbxBus.Text & "%' ORDER BY cast(id_proveedor as int)")
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
        Else
            MsgBox("No hay nada que buscar!")
        End If
    End Sub
    Private Sub tbxBus_KeyDown(sender As Object, e As KeyEventArgs) Handles tbxBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(tbxBus.Text) Then
                Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
    "Initial Catalog=bd_proy4;" &
    "Integrated Security=True"
                Dim con As New SqlConnection(myConnectionString)
                Dim sql As String = ("use bd_proy4 select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', cp as 'Código postal' from proveedores where id_proveedor = '" & tbxBus.Text & "' or telefono_proveedor = '" & tbxBus.Text & "' or cp = '" & tbxBus.Text & "'")
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
            ElseIf Not IsNumeric(tbxBus) Then
                Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
                Dim con As New SqlConnection(myConnectionString)
                Dim sql As String = ("use bd_proy4 select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', cp as 'Código postal' from proveedores where razon_social_proveedor = '" & tbxBus.Text & "'")
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
            Else
                MsgBox("No hay nada que buscar!")
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
      "Initial Catalog=bd_proy4;" &
      "Integrated Security=True"
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' from proveedores join localidades on localidades.cp = proveedores.cp")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "proveedores")
            DataGridView1.DataSource = ds.Tables("proveedores")
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan campos por completar!")
        Else
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
     "Initial Catalog=bd_proy4;" &
     "Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("use bd_proy4 insert into proveedores values(" & TextBox1.Text & ", '" & TextBox2.Text & "', '" & TextBox3.Text & "', " & TextBox4.Text & ")")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "proveedores")
                DataGridView1.DataSource = ds.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Dim myConnectionString2 = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
                 "Initial Catalog=bd_proy4;" &
                 "Integrated Security=True"
            Dim con2 As New SqlConnection(myConnectionString)
            Dim sql2 As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' from proveedores join localidades on localidades.cp = proveedores.cp")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "proveedores")
                DataGridView1.DataSource = ds2.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Dim myConnectionString3 = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con3 As New SqlConnection(myConnectionString3)
            Dim sql3 As String = ("use bd_proy4 select max(cast(id_proveedor as int)) from proveedores ")

            Dim com3 As New SqlCommand(sql3, con3)
            Try
                Dim ds3 As New DataSet
                Dim da3 As New SqlDataAdapter(com3)
                da3.Fill(ds3, "proveedores")
                TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
                TextBox1.Text = TextBox1.Text + 1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan campos por completar!")
        Else
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("use bd_proy4 delete from proveedores where id_proveedor = '" & TextBox1.Text & "' and razon_social_proveedor = '" & TextBox2.Text & "' and telefono_proveedor = '" & TextBox3.Text & "' and cp = " & TextBox4.Text & "")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "proveedores")
                DataGridView1.DataSource = ds.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox("Hay datos cargados de ese proveedor!")
            End Try
            Dim myConnectionString2 = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
                 "Initial Catalog=bd_proy4;" &
                 "Integrated Security=True"
            Dim con2 As New SqlConnection(myConnectionString)
            Dim sql2 As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' from proveedores join localidades on localidades.cp = proveedores.cp")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "proveedores")
                DataGridView1.DataSource = ds2.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Dim myConnectionString3 = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con3 As New SqlConnection(myConnectionString3)
            Dim sql3 As String = ("use bd_proy4 select max(cast(id_proveedor as int)) from proveedores ")

            Dim com3 As New SqlCommand(sql3, con3)
            Try
                Dim ds3 As New DataSet
                Dim da3 As New SqlDataAdapter(com3)
                da3.Fill(ds3, "proveedores")
                TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
                TextBox1.Text = TextBox1.Text + 1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan campos por completar!")
        Else
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("use bd_proy4 update proveedores set id_proveedor = " & TextBox1.Text & ", razon_social_proveedor = '" & TextBox2.Text & "', telefono_proveedor= '" & TextBox3.Text & "', cp = " & TextBox4.Text & " where id_proveedor = " & TextBox1.Text & "")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "proveedores")
                DataGridView1.DataSource = ds.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox("Hay datos cargados de ese proveedor!")
            End Try
            Dim myConnectionString2 = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
                 "Initial Catalog=bd_proy4;" &
                 "Integrated Security=True"
            Dim con2 As New SqlConnection(myConnectionString)
            Dim sql2 As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' from proveedores join localidades on localidades.cp = proveedores.cp")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "proveedores")
                DataGridView1.DataSource = ds2.Tables("proveedores")
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Dim myConnectionString3 = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con3 As New SqlConnection(myConnectionString3)
            Dim sql3 As String = ("use bd_proy4 select max(cast(id_proveedor as int)) from proveedores ")

            Dim com3 As New SqlCommand(sql3, con3)
            Try
                Dim ds3 As New DataSet
                Dim da3 As New SqlDataAdapter(com3)
                da3.Fill(ds3, "proveedores")
                TextBox1.Text = ds3.Tables(0).Rows(0).Item(0)
                TextBox1.Text = TextBox1.Text + 1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim frm As New frmProveedCP
        Hide()
        frm.ShowDialog()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex = -1 Then
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
        "Initial Catalog=bd_proy4;" &
        "Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', localidad as 'Ciudad' from proveedores join localidades on localidades.cp = proveedores.cp")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "proveedores")
                DataGridView1.DataSource = ds.Tables("proveedores")
                DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Ascending)
                DataGridView1.Sort(DataGridView1.Columns(e.ColumnIndex), System.ComponentModel.ListSortDirection.Descending)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf IsNumeric(DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("use bd_proy4 select id_proveedor as 'ID del proveedor', 
razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', cp as 'Código postal' from proveedores where 
id_proveedor = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "' or cp = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "' or telefono_proveedor = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "proveedores")
                TextBox1.Text = ds.Tables("proveedores").Rows(0).Item(0)
                TextBox2.Text = ds.Tables("proveedores").Rows(0).Item(1)
                TextBox3.Text = ds.Tables("proveedores").Rows(0).Item(2)
                TextBox4.Text = ds.Tables("proveedores").Rows(0).Item(3)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim myConnectionString = "Data Source=DESKTOP-K6OA7P5\SQLEXPRESS;" &
"Initial Catalog=bd_proy4;" &
"Integrated Security=True"
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("use bd_proy4 select id_proveedor as 'ID del proveedor', razon_social_proveedor as 'Nombre', telefono_proveedor as 'Teléfono', cp as 'Código postal' from proveedores where 
razon_social_proveedor = '" & DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value & "'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "proveedores")
            TextBox1.Text = ds.Tables("proveedores").Rows(0).Item(0)
            TextBox2.Text = ds.Tables("proveedores").Rows(0).Item(1)
            TextBox3.Text = ds.Tables("proveedores").Rows(0).Item(2)
            TextBox4.Text = ds.Tables("proveedores").Rows(0).Item(3)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        End If


    End Sub


End Class
