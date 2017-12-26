Imports System.Drawing
Public Class Form1
    ' VIEW PORT VARIABLES
    Dim resWidth As Integer = 750
    Dim resHeight As Integer = 550
    Dim tileSize As Integer = 32

    ' GRAPHICS VARIABLES
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap
    Dim r As Rectangle
    ' FTS COUNTER
    Dim tSec As Integer = TimeOfDay.Second
    Dim tTicks As Integer = 0
    Dim maxTicks As Integer = 0
    'MAP VARIABLES
    Dim Map(100, 100, 10) As Integer
    Dim MapX As Integer = 20
    Dim MapY As Integer = 20
    ' GAME RUNNING ?
    Dim isRunning As Boolean = True
    'MOUSE LOCATIONS
    Dim mouseX As Integer 'these next four added in Lesson 2
    Dim mouseY As Integer
    Dim mMapX As Integer
    Dim mMapY As Integer
    'PAINT BRUSH
    Dim PaintBrush As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Show()
        Me.Focus()
        ' INTIALIZE GRAPHICS OBJECTS
        G = Me.CreateGraphics
        'BB = New Bitmap(Me.Width, Me.Height)  'from lesson 1
        BB = New Bitmap(resWidth, resHeight) 'from lesson 2
        StartGameLoop()

    End Sub
    Private Sub StartGameLoop()
        Do While isRunning = True
            ' KEEP APP RESPONSIVE
            Application.DoEvents()

            '1) Check user input
            '2) Run AI
            '3) Update Object Data (Object positions, Status, etc)
            '4) Check Triggeres and Conditions
            '5) Draw Graphics 
            DrawGraphics()
            '6) Playing Sound Effects and Music

            ' UPDATE TICK COUNTER
            TickCounter()
        Loop
    End Sub

    Private Sub DrawGraphics()
        'FILL THE BACKBUFFER
        'DRAW TILES
        For X = 0 To 19
            For Y = 0 To 14
                r = New Rectangle(X * tileSize, Y * tileSize, tileSize, tileSize)
                Select Case Map(MapX + X, MapY + Y, 0)
                    Case 0
                        G.FillRectangle(Brushes.BurlyWood, r)
                    Case 1
                        G.FillRectangle(Brushes.Red, r)
                    Case 2
                        G.FillRectangle(Brushes.Blue, r)
                End Select
                ' G.FillRectangle(Brushes.BurlyWood, r)
                G.DrawRectangle(Pens.Black, r)
                'If mouseX = 10 Then
                '    ' MsgBox("10")
                '    G.FillRectangle(Brushes.Red, r)
                '    mouseX = 11
                'End If
            Next
        Next
        'If mouseX = 10 Then
        '    ' MsgBox("10")
        '    G.FillRectangle(Brushes.Red, r)
        '    mouseX = 11
        'End If
        'DRAW FINAL LAYERS
        'GUYS, MENUS, ETC
        G.FillRectangle(Brushes.Red, 21 * tileSize, 4 * tileSize, tileSize, tileSize)
        G.FillRectangle(Brushes.Blue, 21 * tileSize, 6 * tileSize, tileSize, tileSize)
        G.DrawRectangle(Pens.Red, mouseX * tileSize, mouseY * tileSize, tileSize, tileSize)


        G.DrawString("Ticks:  " & tTicks & vbCrLf &
                     "TPS:  " & maxTicks & vbCrLf &
                     "Mouse X:  " & mouseX & vbCrLf &
                     "Mouse Y:  " & mouseY & vbCrLf &
                     "M Map X:  " & mMapX & vbCrLf &
                     "M Map Y:  " & mMapY, Me.Font, Brushes.Black, 650, 0)
        'COPY BACKBUFFER TO GRAPHICS OBJECT
        G = Graphics.FromImage(BB)
        'DRAW BACKBUFFER TO SCREEN
        BBG = Me.CreateGraphics
        BBG.DrawImage(BB, 0, 0, resWidth, resHeight) 'modified from lesson 1 to lesson 2
        'FIX OVERDRAW
        G.Clear(Color.Wheat)

    End Sub

    Private Sub TickCounter()
        If tSec = TimeOfDay.Second And isRunning = True Then
            tTicks = tTicks + 1
        Else
            maxTicks = tTicks
            tTicks = 0
            tSec = TimeOfDay.Second
        End If
    End Sub
    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'MsgBox("you attacked " & mMapX & ":" & mMapY)
        'If mouseX = 21 And mouseY = 4 Then
        '    PaintBrush = 1
        'ElseIf mouseX = 21 And mouseY = 6 Then
        '    PaintBrush = 2
        'End If
        'Select Case PaintBrush
        '    Case 0
        '    Case 1 'Red
        '        Map(mMapX, mMapY, 0) = 1
        '    Case 2 'Blue
        '        Map(mMapX, mMapY, 0) = 2

        'End Select


    End Sub


    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        mouseX = Math.Floor(e.X / tileSize) 'this sub is new in lesson 2
        mouseY = Math.Floor(e.Y / tileSize)

        mMapX = MapX + mouseX
        mMapY = MapY + mouseY

        If MouseButtons.HasFlag(MouseButtons.Left) = True Then
            ' If System.Windows.Input.Mouse.LeftButton.HasFlag(MouseButtonState.Pressed) Then
            'If MouseButtons.Left = True Then
            ' If MouseButtons( = True Then
            ' If (e.Button = MouseButtons.Left) Then
            If mouseX = 21 And mouseY = 4 Then
                PaintBrush = 1
            ElseIf mouseX = 21 And mouseY = 6 Then
                PaintBrush = 2
            End If
            Select Case PaintBrush
                Case 0
                Case 1 'Red
                    Map(mMapX, mMapY, 0) = 1
                Case 2 'Blue
                    Map(mMapX, mMapY, 0) = 2

            End Select

        End If






    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        'If (e.Button = MouseButtons.Left) Then
        '    If mouseX = 21 And mouseY = 4 Then
        '    PaintBrush = 1
        'ElseIf mouseX = 21 And mouseY = 6 Then
        '    PaintBrush = 2
        'End If
        '    Select Case PaintBrush
        '        Case 0
        '        Case 1 'Red
        '            Map(mMapX, mMapY, 0) = 1
        '        Case 2 'Blue
        '            Map(mMapX, mMapY, 0) = 2

        '    End Select
        'End If
    End Sub
End Class
