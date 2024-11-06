using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Editor.Models;


namespace Editor.Views;

public partial class MainWindow : Window
{
    private string currentAudio = "loading_screen";
    
    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    private void TitleBar_OnClick(object? sender, PointerPressedEventArgs e)
    {
        var point = e.GetCurrentPoint(this);
        if (point.Properties.IsLeftButtonPressed)
        {
            if (e.ClickCount == 2) // double-click
            {
                var window = (Window)this.VisualRoot!;
                window.WindowState = window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            }
            else
            {
                BeginMoveDrag(e);
            }
        }
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        Loaded -= OnLoaded;
        EngineApi.AudioEngine_Init();
        EngineApi.AudioEngine_LoadSource(currentAudio, "Resources/Audio/loading_screen.wav");
    }
    
    private void OnUnloaded(object? sender, RoutedEventArgs e)
    {
        Unloaded -= OnUnloaded;
        EngineApi.AudioEngine_Shutdown();
    }

    private void PlayBt_OnClick(object? sender, RoutedEventArgs e)
    {
        EngineApi.AudioEngine_PlaySource(currentAudio);
        SetStatusBar($"Playing '{currentAudio}'");
    }
    
    private void StopBt_OnClick(object? sender, RoutedEventArgs e)
    {
        EngineApi.AudioEngine_StopSource("loading_screen");
        SetStatusBar("'loading_screen.wav' Stopped");
    }
    
    private void PauseBt_OnClick(object? sender, RoutedEventArgs e)
    {
        EngineApi.AudioEngine_PauseSource("loading_screen");
        SetStatusBar("'loading_screen.wav' Paused");
    }

    public void SetStatusBar(string message)
    {
        StatusBarTb.Text = message;
    }

    private void PlayStop_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Space) return;
        if (EngineApi.AudioEngine_IsPlaying(currentAudio))
            EngineApi.AudioEngine_StopSource(currentAudio);
        else
            EngineApi.AudioEngine_PlaySource(currentAudio);
    }
}