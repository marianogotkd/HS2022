Public Class formasdasd
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNumeric(TextBox1.Text) Then
            TextBox1.BorderColor = Drawing.Color.Red
        Else
            TextBox1.BorderColor = Drawing.Color.Green

        End If
        If Not IsNumeric(TextBox2.Text) Then
            TextBox2.BorderColor = Drawing.Color.Red
        Else
            TextBox2.BorderColor = Drawing.Color.Green

        End If
        If Not IsNumeric(TextBox3.Text) Then
            TextBox3.BorderColor = Drawing.Color.Red
        Else
            TextBox3.BorderColor = Drawing.Color.Green
        End If


    End Sub
End Class