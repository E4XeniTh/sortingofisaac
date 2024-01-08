Imports System.IO
Imports System.Xml

Public Class Form1

    Dim metadataFiles As String()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler TextBox1.KeyDown, AddressOf TextBox1_KeyDown
        LocationPathTextBox.Text = ""
    End Sub

    Private Sub SetLocationBtn_Click(sender As Object, e As EventArgs) Handles SetLocationBtn.Click
        InitializeListView()
    End Sub

    Private Sub InitializeListView()
        ' Set up the ListView
        If Directory.Exists(LocationPathTextBox.Text) Then
            ListView1.Columns.Add("Name (Load order)", 240)
            ListView1.Columns.Add("Status", 80)
            metadataFiles = Directory.GetFiles(LocationPathTextBox.Text, "metadata.xml", SearchOption.AllDirectories)
            LocationPathTextBox.Enabled = False
            SetLocationBtn.Enabled = False
            LoadData()
            SortListViewItems(0)
        Else
            MessageBox.Show("Location doesn't exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            With LocationPathTextBox
                .Focus()
                .SelectAll()
            End With
            Exit Sub
        End If
    End Sub

    Private Sub LoadData()
        ListView1.Items.Clear()

        For Each metadataFile As String In metadataFiles
            Dim doc As New XmlDocument()
            doc.Load(metadataFile)

            Dim nameNode As XmlNode = doc.SelectSingleNode("/metadata/name")
            If nameNode IsNot Nothing Then
                Dim subfolderPath = Path.GetDirectoryName(metadataFile)
                Dim isEnabled As Boolean = Not File.Exists(Path.Combine(subfolderPath, "disable.it"))

                Dim item As New ListViewItem(nameNode.InnerText)
                item.SubItems.Add(If(isEnabled, "Enabled", "Disabled"))

                ListView1.Items.Add(item)
            End If
        Next
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count = 1 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)
            Dim selectedName As String = selectedItem.SubItems(0).Text
            TextBox1.Text = selectedName
            btnUpdate.Enabled = True
            TextBox1.Enabled = True
            BtnToggleStatus.Enabled = True
        ElseIf ListView1.SelectedItems.Count > 1 Then
            TextBox1.Text = ""
            TextBox1.Enabled = False
            btnUpdate.Enabled = False
            BtnToggleStatus.Enabled = True
        Else
            TextBox1.Text = ""
            TextBox1.Enabled = False
            btnUpdate.Enabled = False
            BtnToggleStatus.Enabled = False
        End If
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If ListView1.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = ListView1.SelectedItems(0)
            Dim selectedName As String = selectedItem.SubItems(0).Text
            Dim newName As String = TextBox1.Text

            For Each metadataFile As String In Directory.GetFiles(LocationPathTextBox.Text, "metadata.xml", SearchOption.AllDirectories)
                Dim doc As New XmlDocument()
                doc.Load(metadataFile)

                Dim nameNode As XmlNode = doc.SelectSingleNode("/metadata/name")
                If nameNode IsNot Nothing AndAlso nameNode.InnerText = selectedName Then
                    ' Update the <name> tag
                    nameNode.InnerText = newName
                    doc.Save(metadataFile)
                End If
            Next

            LoadData()
            TextBox1.Text = ""
            TextBox1.Enabled = False
            btnUpdate.Enabled = False
            BtnToggleStatus.Enabled = False
        End If
    End Sub

    Private Sub btnToggleStatus_Click(sender As Object, e As EventArgs) Handles BtnToggleStatus.Click
        For Each selectedItem As ListViewItem In ListView1.SelectedItems
            Dim selectedName As String = selectedItem.SubItems(0).Text

            For Each metadataFile As String In Directory.GetFiles(LocationPathTextBox.Text, "metadata.xml", SearchOption.AllDirectories)
                Dim doc As New XmlDocument()
                doc.Load(metadataFile)

                Dim nameNode As XmlNode = doc.SelectSingleNode("/metadata/name")
                If nameNode IsNot Nothing AndAlso nameNode.InnerText = selectedName Then
                    ' Enable/disable the subfolder based on the current status
                    Dim subfolderPath = Path.GetDirectoryName(metadataFile)
                    Dim disableFilePath = Path.Combine(subfolderPath, "disable.it")

                    If selectedItem.SubItems(1).Text = "Disabled" Then
                        If File.Exists(disableFilePath) Then
                            File.Delete(disableFilePath)
                        End If
                    Else
                        File.Create(disableFilePath).Dispose()
                    End If
                End If
            Next
        Next

        LoadData()
        TextBox1.Text = ""
        TextBox1.Enabled = False
        btnUpdate.Enabled = False
        BtnToggleStatus.Enabled = False
    End Sub
    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        If e.Column = 0 Then
            SortListViewItems(0) ' Sort by Name column
        ElseIf e.Column = 1 Then
            SortListViewItems(1) ' Sort by Status column
        End If
    End Sub

    Private Sub SortListViewItems(columnIndex As Integer)
        Dim comparer As New ListViewItemComparer(columnIndex)
        ListView1.ListViewItemSorter = comparer
        ListView1.Sort()
    End Sub
    Public Class ListViewItemComparer
        Implements IComparer

        Private columnIndex As Integer

        Public Sub New(columnIndex As Integer)
            Me.columnIndex = columnIndex
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Dim itemX As ListViewItem = DirectCast(x, ListViewItem)
            Dim itemY As ListViewItem = DirectCast(y, ListViewItem)

            Dim valueX As String = itemX.SubItems(columnIndex).Text
            Dim valueY As String = itemY.SubItems(columnIndex).Text

            If columnIndex = 1 Then ' Status column
                Return String.Compare(valueY, valueX) ' Reverse the order
            Else
                Return String.Compare(valueX, valueY)
            End If
        End Function
    End Class
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, LocationPathTextBox.KeyDown
        If e.KeyCode = Keys.Enter And ListView1.SelectedItems.Count = 1 Then
            ' Trigger the click event of the Rename button
            btnUpdate.PerformClick()
            e.SuppressKeyPress = True ' Suppress the Enter key press event
        End If
    End Sub
End Class