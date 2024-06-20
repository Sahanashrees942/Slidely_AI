Public Class Form1
    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        Dim createForm As New CreateSubmissionForm()
        createForm.ShowDialog()
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New ViewSubmissionsForm()
        viewForm.ShowDialog()
    End Sub
End Class

' CreateSubmissionForm.vb
Public Class CreateSubmissionForm
    ' Code for the CreateSubmissionForm
End Class

' ViewSubmissionsForm.vb
Public Class ViewSubmissionsForm
    ' Code for the ViewSubmissionsForm
End Class