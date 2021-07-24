using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TitleBar : MonoBehaviour
{
    [DllImport("user32.dll")] private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")] private static extern IntPtr GetActiveWindow();

    public void Minimize()
    {
        ShowWindow(GetActiveWindow(), 2);
    }

    public void Close()
    {
        Application.Quit();
    }
}
