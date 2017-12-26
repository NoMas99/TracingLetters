Imports System.Drawing
Public Class Form1
    ' GRAPHICS VARIABLES
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap
    Dim r As Rectangle
    ' FTS COUNTER
    Dim tSec As Integer = TimeOfDay.Second
    Dim tTicks As Integer = 0
    Dim maxTicks As Integer = 0
    ' GAME RUNNING ?
    Dim isRunning As Boolean = True

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Show()
        Me.Focus()
        ' INTIALIZE GRAPHICS OBJECTS
        G = Me.CreateGraphics
        BB = New Bitmap(Me.Width, Me.Height)
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

        Loop
    End Sub

    Private Sub DrawGraphics()
        'FILL THE BACKBUFFER
        'DRAW TILES
        For x = 0 To 19
            For y = 0 To 14
                r = New Rectangle(x * 32, y * 32, 32, 32)
                G.FillRectangle(Brushes.BurlyWood, r)
                G.DrawRectangle(Pens.Black, r)
            Next
        Next
        'DRAW FINAL LAYERS
        'GUYS, MENUS, ETC
        G.DrawString("Ticks:  " & tTicks & vbCrLf &
                     "TPS:  " & maxTicks, Me.Font, Brushes.Black, 650, 0)
        'COPY BACKBUFFER TO GRAPHICS OBJECT
        G = Graphics.FromImage(BB)
        'DRAW BACKBUFFER TO SCREEN
        BBG = Me.CreateGraphics
        BBG.DrawImage(BB, 0, 0, Me.Width, Me.Height)
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
End Class
