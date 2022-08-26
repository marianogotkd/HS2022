Imports System.Configuration

Public Class Conexion

    'hamer conexion
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=choco; password=123choco;Initial Catalog=fitfaBD;Data Source=MARIANO-HOME-PC\HAMERSERVER")

    'Conexion Local choco
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=FitfaBD;Data Source=CHOCO-PC")

    ''LOCAL
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=fitfaBD;Data Source=(local)")

    ''LOCAL Con BKP desde la WEB (otro nombre de BD)
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=CHOCO;Initial Catalog=wi181976_fitfabd;Data Source=DESKTOP-IPJ62B9\SQLEXPRESS_CHOK")


    ''local sin seguridad CHOCO RYZEN
    Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=CHOCO;Initial Catalog=fitfa_prueba;Data Source=DESKTOP-IPJ62B9\SQLEXPRESS_CHOK")
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=CHOCO;Initial Catalog=fitfaBD_mariano;Data Source=DESKTOP-IPJ62B9\SQLEXPRESS_CHOK")
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Password=123choco;Persist Security Info=True;User ID=CHOCO;Initial Catalog=fitfaBD;Data Source=DESKTOP-IPJ62B9\SQLEXPRESS_CHOK")



    'hamer conexion
    ' Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=choco; password=123choco;Initial Catalog=fitfaBD;Data Source=HAMER")

    'Conexion WEB
    ' Public dbconn As New OleDb.OleDbConnection("Provider=SQLOLEDB.1;workstation id=fitfaBD.mssql.somee.com;packet size=4096;user id=hamerbd;pwd=choco1218;data source=fitfaBD.mssql.somee.com;persist security info=False;initial catalog=fitfaBD")

    'Conexion web Donweb
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLNCLI10;Server=localhost;Database=wi181976_fitfabd;Password=si24REzuki;Trusted_Connection=yes")

    'Conexion DON WEB SQL 2012
    'Public dbconn As New OleDb.OleDbConnection("Provider=SQLNCLI10;Server=sql2012;User Id=wi181976_fitfabd2;Password=lish5aengeiH;Database=wi181976_fitfabd2; Trusted_Connection=yes")
End Class
