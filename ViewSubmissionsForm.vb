Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private httpClient As HttpClient = New HttpClient()
    Private currentIndex As Integer = 0

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Function LoadSubmission(index As Integer) As Task
        Try
            Dim response As HttpResponseMessage = Await httpClient.GetAsync($"http://localhost:3000/read?index={index}")

            If response.IsSuccessStatusCode Then
                Dim json As String = Await response.Content.ReadAsStringAsync()
                Dim submission As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(json)

                If submission IsNot Nothing Then
                    lblName.Text = submission("name")
                    lblEmail.Text = submission("email")
                    lblPhone.Text = submission("phone")
                    lblGitHubLink.Text = submission("github_link")
                    lblStopwatch.Text = submission("stopwatch_time")
                End If
            Else
                MessageBox.Show("No more submissions.")
            End If
        Catch ex As Exception
            MessageBox.Show($"Error loading submission: {ex.Message}")
        End Try
    End Function

    Private Async Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        currentIndex += 1
        Await LoadSubmission(currentIndex)
    End Sub

    Private Async Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            Await LoadSubmission(currentIndex)
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub
End Class
