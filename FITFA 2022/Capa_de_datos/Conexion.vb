Imports System.Configuration

Public Class Conexion


    ''LOCAL
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=FitfaWeb;Data Source=(local)")


    ''local sin seguridad CHOCO RYZEN
    'NOTA: LA CADENA DE ABAJO ES LA QUE TIENE LA BD PRUEBA DONDE TIENE LOS ULTIMOS PROC ALMACENADOS
    Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=CHOCO;Initial Catalog=FitfaWeb;Data Source=DESKTOP-IPJ62B9\SQLEXPRESS_CHOK")

    'Conexion web Donweb
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLNCLI10;Server=localhost;Database=wi181976_fitfabd;Password=si24REzuki;Trusted_Connection=yes")

    'Conexion DON WEB SQL 2012
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLNCLI10;Server=sql2012;User Id=wi181976_fitfabd2;Password=lish5aengeiH;Database=wi181976_fitfabd2; Trusted_Connection=yes")

    'EVENTO DEL 03-09-2022
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=CHOCO;Initial Catalog=FitfaWeb;Data Source=DESKTOP-IPJ62B9\SQLEXPRESS_CHOK")

End Class
