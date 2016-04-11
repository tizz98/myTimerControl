'------------------------------------------------------------
'-                  File Name: myClock.vb                   -
'-                Part of Project: Assign10                 -
'------------------------------------------------------------
'-                Written By: Elijah Wilson                 -
'-                  Written On: 04/11/2016                  -
'------------------------------------------------------------
'- File Purpose:                                            -
'-                                                          -
'- The main file for the clock control.                     -
'------------------------------------------------------------
'- Program Purpose:                                         -
'-                                                          -
'- This program is a custom VB control that is a clock.     -
'------------------------------------------------------------
'- Global Variable Dictionary (alphabetically):             -
'- (None)                                                   -
'------------------------------------------------------------
Imports System.Drawing
Imports System.Windows.Forms

Public Class myClock
    Inherits UserControl

    Dim ArialFont As New Font("Arial", 12, FontStyle.Regular)
    Dim myBrush As New SolidBrush(Color.Black)
    Dim CurrentForeColor As Color = Color.Black

    ' My version of Visual Studio didn't have the Windows Forms Control Library
    ' template, so I improvised and it still seemed to work.
    Dim WithEvents timer As New Timer()

    '------------------------------------------------------------
    '-                   Subprogram Name: New                   -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 04/11/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Create a new instance of the class. Also sets up the     -
    '- timer.                                                   -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Public Sub New()
        timer.Interval = 1000
        timer.Enabled = True
    End Sub

    '------------------------------------------------------------
    '-               Subprogram Name: timer_Tick                -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 04/11/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- The event that is raised when the timer ticks. Refreshes -
    '- the control.                                             -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender - The object that raised the event                -
    '- e - The EventArgs sent with the event                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        Me.Refresh()
    End Sub

    Public Overrides Property ForeColor As Color
        Get
            Return (CurrentForeColor)
        End Get
        Set(value As Color)
            CurrentForeColor = value
            Me.Invalidate()
        End Set
    End Property

    '------------------------------------------------------------
    '-                 Subprogram Name: OnPaint                 -
    '------------------------------------------------------------
    '-                Written By: Elijah Wilson                 -
    '-                  Written On: 04/11/2016                  -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- Overrides when the OnPaint subroutine is called. Writes  -
    '- the text to the control area.                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- e - The PaintEventArgs sent with the event               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        myBrush.Color = CurrentForeColor
        e.Graphics.DrawString(DateTime.Now.ToLongTimeString, ArialFont, myBrush, 10, 10)
    End Sub
End Class
