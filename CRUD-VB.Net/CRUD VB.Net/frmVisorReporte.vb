Public Class frmVisorReporte
    Private Sub frmVisorReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'DataSet1.visordetodo' Puede moverla o quitarla según sea necesario.
        Me.visordetodoTableAdapter.Fill(Me.DataSet1.visordetodo)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class