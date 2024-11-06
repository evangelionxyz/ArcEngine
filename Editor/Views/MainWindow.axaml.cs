using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Editor.Models;


namespace Editor.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
        Unloaded += OnUnloaded;
    }

    private void OnLoaded(object? sender, RoutedEventArgs e)
    {
        Loaded -= OnLoaded;
        EngineApi.AudioEngine_Init();
        EngineApi.AudioEngine_LoadSource("bullet", "Resources/Audio/bullet.mp3");
    }
    
    private void OnUnloaded(object? sender, RoutedEventArgs e)
    {
        Unloaded -= OnUnloaded;
        EngineApi.AudioEngine_Shutdown();
    }

    private void PlayBt_OnClick(object? sender, RoutedEventArgs e)
    {
        EngineApi.AudioEngine_PlaySource("bullet");
    }
}