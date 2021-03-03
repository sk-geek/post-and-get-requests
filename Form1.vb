Imports System.Net
Imports System.Text
Imports System.IO

Public Class Form1
    Dim logincookie As CookieContainer
    Dim rqtp As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create(TextBox1.Text), HttpWebRequest)
        Select Case rqtp
            Case 1
                Dim postData As String = TextBox1.Text
                Dim encoding As New UTF8Encoding
                Dim byteData As Byte() = encoding.GetBytes(postData)
                Dim tempCookies As New CookieContainer
                postReq.Method = "GET"
                postReq.KeepAlive = True
                postReq.CookieContainer = tempCookies
                postReq.ContentType = "application/xml"
                postReq.Referer = TextBox1.Text
                postReq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
                postReq.ContentLength = byteData.Length
                Dim postreqstream As Stream = postReq.GetRequestStream()
                postreqstream.Write(byteData, 0, byteData.Length)
                postreqstream.Close()
                Dim postresponse As HttpWebResponse

                postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                tempCookies.Add(postresponse.Cookies)
                logincookie = tempCookies
                Dim postreqreader As New StreamReader(postresponse.GetResponseStream())

                Dim thepage As String = postreqreader.ReadToEnd

                response.Text = thepage
                Clipboard.Clear()
                Clipboard.SetText(thepage)
                MsgBox(thepage, vbInformation + vbOK, "result")




                REM Dim webClient As New System.Net.WebClient
                REM Dim result As String = webClient.DownloadString(TextBox1.Text)
                REM If Not result = "" Then
                REM    Clipboard.Clear()
                REM    Clipboard.SetText(result)
                REM MsgBox(result, vbInformation + vbOK, "result")
                REM    response.Text = (result)
                REM End If
            Case 2
                Dim postData As String = TextBox1.Text
                Dim tempCookies As New CookieContainer
                Dim encoding As New UTF8Encoding
                Dim byteData As Byte() = encoding.GetBytes(postData)
                postReq.Method = "POST"
                postReq.KeepAlive = True
                postReq.CookieContainer = tempCookies
                postReq.ContentType = "application/xml"
                postReq.Referer = TextBox1.Text
                postReq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
                postReq.ContentLength = byteData.Length

                Dim postreqstream As Stream = postReq.GetRequestStream()
                postreqstream.Write(byteData, 0, byteData.Length)
                postreqstream.Close()
                Dim postresponse As HttpWebResponse

                postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
                tempCookies.Add(postresponse.Cookies)
                logincookie = tempCookies
                Dim postreqreader As New StreamReader(postresponse.GetResponseStream())

                Dim thepage As String = postreqreader.ReadToEnd

                response.Text = thepage
                Clipboard.Clear()
                Clipboard.SetText(thepage)
                MsgBox(thepage, vbInformation + vbOK, "result")
        End Select
    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        rqtp = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        rqtp = 2
    End Sub
End Class
