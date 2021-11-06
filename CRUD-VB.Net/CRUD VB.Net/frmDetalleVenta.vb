Imports System.Data.SqlClient
Public Class frmDetalleVenta
    Private Sub frmDetalleVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Focus()
        Dim myConnectionString1 = My.Settings.myConnectionString3
        Dim con1 As New SqlConnection(myConnectionString1)
        Dim sql1 As String = ("select max(id_venta) from ventas")
        Dim com1 As New SqlCommand(sql1, con1)
        Try
            Dim ds1 As New DataSet
            Dim da1 As New SqlDataAdapter(com1)
            da1.Fill(ds1, "clientes")
            TextBox2.Text = ds1.Tables("clientes").Rows(0).Item(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("select id_venta as 'Número de venta', fecha as 'Fecha', razon_social as 'Nombre de cliente',
descript_forma_pago as 'Forma de pago', usuario as 'Usuario', importe as 'Importe total' from ventas
join clientes on clientes.id_cliente = ventas.id_cliente
join formas_pago on formas_pago.id_forma_pago = ventas.id_forma_pago
join usuarios on usuarios.id_usuario = ventas.id_usuario
where id_venta = '" & TextBox2.Text & "'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "clientes")
            cabecera.DataSource = ds.Tables("clientes")
            cabecera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim myConnectionString2 = My.Settings.myConnectionString3
        Dim con2 As New SqlConnection(myConnectionString2)
        Dim sql2 As String = ("select id_venta as 'Numero de venta', descripcion as 'Producto', detalle_venta.importe as 'Importe', cantidad as 'Cantidad', importe_r as 'Total'
from detalle_venta
join productos on productos.id_producto = detalle_venta.id_producto
where id_venta = '" & TextBox2.Text & "'")
        Dim com2 As New SqlCommand(sql2, con2)
        Try
            Dim ds2 As New DataSet
            Dim da2 As New SqlDataAdapter(com2)
            da2.Fill(ds2, "clientes")
            detalleview.DataSource = ds2.Tables("clientes")
            detalleview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles tbxBus.TextChanged
        If (tbxBus.Text = "") Then
            Dim myConnectionString2 = My.Settings.myConnectionString3
            Dim con2 As New SqlConnection(myConnectionString2)
            Dim sql2 As String = ("select id_venta as 'Numero de venta', descripcion as 'Producto', detalle_venta.importe as 'Importe', cantidad as 'Cantidad', importe_r as 'Total'
from detalle_venta
join productos on productos.id_producto = detalle_venta.id_producto
where id_venta = '" & TextBox2.Text & "'")
            Dim com2 As New SqlCommand(sql2, con2)
            Try
                Dim ds2 As New DataSet
                Dim da2 As New SqlDataAdapter(com2)
                da2.Fill(ds2, "clientes")
                detalleview.DataSource = ds2.Tables("clientes")
                detalleview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                TextBox2.Focus()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Dim myConnectionString = My.Settings.myConnectionString3
            Dim con As New SqlConnection(myConnectionString)
            Dim sql As String = ("select id_venta as 'Numero de venta', 
descripcion as 'Producto', detalle_venta.importe as 'Importe', cantidad as 'Cantidad', importe_r as 'Total'
from detalle_venta
join productos on productos.id_producto = detalle_venta.id_producto
where descripcion like '%" & tbxBus.Text & "%' and id_venta = '" & TextBox2.Text & "'")
            Dim com As New SqlCommand(sql, con)
            Try
                Dim ds As New DataSet
                Dim da As New SqlDataAdapter(com)
                da.Fill(ds, "Proveedores")
                detalleview.DataSource = ds.Tables("Proveedores")
                detalleview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        frmProductosVentaBuscar.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim myConnectionString2 = My.Settings.myConnectionString3
        Dim con2 As New SqlConnection(myConnectionString2)
        Dim sql2 As String = ("delete from detalle_venta where id_Venta = '" & TextBox2.Text & "'")
        Dim com2 As New SqlCommand(sql2, con2)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com2)
            da.Fill(ds, "proveedores")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("delete from ventas where id_Venta = '" & TextBox2.Text & "'")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "proveedores")
            frmCargarVentaProductos.Close()
            Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If (IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) And Not TextBox6.Text.Contains(".")) Then
            Dim importe = CInt(TextBox5.Text)
            Dim cantidad = CInt(TextBox6.Text)
            TextBox7.Text = importe * cantidad
        ElseIf (TextBox5.Text = "") Then
            TextBox7.Text = TextBox5.Text
        ElseIf (TextBox6.Text = "")
            TextBox6.Text = "1"
            TextBox6.SelectAll()
        ElseIf (TextBox6.Text.Contains("."))
            Dim decimporte = Convert.ToDouble(TextBox5.Text)
            Dim decantidad = Val(TextBox6.Text.ToString)
            TextBox7.Text = decimporte * decantidad
        ElseIf TextBox6.Text.Contains(",")
            MsgBox("Los decimales van con '.'!")
        Else
            MsgBox("Introduzca sólo 'NÚMEROS'!!!")
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (TextBox2.Text <> "") Then
            If (TextBox3.Text <> "") Then
                If (TextBox5.Text <> "") Then
                    If (TextBox6.Text <> "") Then
                        If (TextBox7.Text <> "") Then
                            Dim myConnectionString = My.Settings.myConnectionString3
                            Dim con As New SqlConnection(myConnectionString)
                            Dim sql As String = ("insert into detalle_venta values
('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')")
                            Dim com As New SqlCommand(sql, con)
                            Try
                                Dim ds As New DataSet
                                Dim da As New SqlDataAdapter(com)
                                da.Fill(ds, "clientes")
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                            tbxBus.Select()
                            Dim myConnectionString2 = My.Settings.myConnectionString3
                            Dim con2 As New SqlConnection(myConnectionString2)
                            Dim sql2 As String = ("select id_venta as 'Numero de venta', descripcion as 'Producto', detalle_venta.importe as 'Importe', cantidad as 'Cantidad', importe_r as 'Total'
from detalle_venta
join productos on productos.id_producto = detalle_venta.id_producto
where id_venta = '" & TextBox2.Text & "'")
                            Dim com2 As New SqlCommand(sql2, con2)
                            Try
                                Dim ds2 As New DataSet
                                Dim da2 As New SqlDataAdapter(com2)
                                da2.Fill(ds2, "clientes")
                                detalleview.DataSource = ds2.Tables("clientes")
                                detalleview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                                TextBox2.Focus()
                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try
                            TextBox3.Text = ""
                            TextBox4.Text = ""
                            TextBox5.Text = ""
                            TextBox6.Text = "1"
                            TextBox7.Text = ""
                            TextBox3.Focus()


                        Else
                            MsgBox("Falta el total!")
                        End If
                    Else
                        MsgBox("Falta la cantidad!!")
                    End If
                Else
                    MsgBox("Falta el importe del producto?")

                End If
            Else
                MsgBox("No se seleccionó un producto!!")
            End If
        Else
            MsgBox("Falta el numero de venta?")
        End If

    End Sub

    Private Sub TextBox6_Click(sender As Object, e As EventArgs) Handles TextBox6.Click
        TextBox6.SelectAll()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myConnectionString = My.Settings.myConnectionString3
        Dim con As New SqlConnection(myConnectionString)
        Dim sql As String = ("update ventas 
set importe = (select sum(importe_r) from detalle_venta where id_venta = (select max(id_venta) from ventas))
where id_venta = (select max(id_venta) from ventas)")
        Dim com As New SqlCommand(sql, con)
        Try
            Dim ds As New DataSet
            Dim da As New SqlDataAdapter(com)
            da.Fill(ds, "clientes")
            frmCargarVentaProductos.Close()
            Close()
            frmVisorReporte.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class