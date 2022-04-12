Imports System.Configuration
Public Class Conexion
    'BD MARTIN CHOCO-RYZEN - hamachi
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=choco;Initial Catalog=Martin;Data Source=25.112.197.145\SQLEXPRESS_CHOK")

    ''LOCAL
    ' Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=choco;Initial Catalog=WebCentral;Data Source=(local)")

    ''SERVIDOR
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WebCentral;Data Source=SRVSQL-CENTRAL;Password=webcentral123; user ID=webcentral")

    'BD WEB-CENTRAL CHOCO-RYZEN -. hamachi
    Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=choco;Initial Catalog=WebCentral;Data Source=25.112.197.145\SQLEXPRESS_CHOK")

    ''SERVIDOR con WinNT
    ' Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=WebCentral;Data Source=SRVSQL-CENTRAL")

End Class
