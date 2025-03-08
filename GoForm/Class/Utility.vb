
Imports System.Security.Cryptography    ' 暗号化
Imports System.Text                     ' StringBuilder

''' <summary>
''' ユーティリティクラス
''' </summary>
Public Class Utility
    ''' <summary>
    ''' 文字列をSHA256でハッシュ化
    ''' </summary>
    ''' <param name="input">ハッシュ化対象の文字列</param>
    ''' <returns>ハッシュ化された文字列（16進数小文字）</returns>
    Public Shared Function HashSHA256(input As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hash As Byte() = sha256.ComputeHash(bytes)

            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function
End Class
