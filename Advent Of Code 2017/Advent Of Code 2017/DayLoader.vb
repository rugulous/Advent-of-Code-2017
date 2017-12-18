﻿Imports System.Windows.Forms

Module DayLoader

    Sub Main()
        Dim dayNo As Integer = -1
        Dim part As String = "?"

        Dim day As Day
        Dim input As String
        Dim key As System.ConsoleKeyInfo

        Try
            While (True)
                Console.WriteLine("Please enter a day (1-24):")
                While (Not Integer.TryParse(Console.ReadLine(), dayNo) Or dayNo < 0 Or dayNo > 24)
                    Console.WriteLine("Invalid day. Please enter a day between 1 and 24:")
                End While

                Console.WriteLine("Please select a part ([A] or [B]):")
                part = Console.ReadLine().ToLower()

                While (Not part = "a" And Not part = "b")
                    Console.WriteLine("Invalid part (" + part + "). Please choose either part [A] or part [B]:")
                    part = Console.ReadLine().ToLower()
                End While

                'TODO: reflection
                day = New Day1()

                Console.WriteLine("Please enter the Puzzle Input:")
                key = Console.ReadKey(True)

                If (key.Key = ConsoleKey.V And (key.Modifiers And ConsoleModifiers.Control) = ConsoleModifiers.Control) Then
                    If Clipboard.ContainsText Then
                        input = Clipboard.GetText
                    Else
                        Console.Write(key.KeyChar)
                    End If
                End If

                If (IsNothing(input) Or input = "v" Or input = "") Then
                    input = Console.ReadLine()
                End If

                If (part = "a") Then
                    Console.WriteLine(day.PartA(input))
                Else
                    Console.WriteLine(day.PartB(input))
                End If
            End While


        Catch ex As Exception
            MsgBox("An error occurred: " + ex.Message)
        End Try
    End Sub

End Module