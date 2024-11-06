using System;
using System.Runtime.InteropServices;

namespace Editor.Models;

public class EngineApi
{
    private const string DllName = "Engine.dll";
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AudioEngine_Init();
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
    public static extern void AudioEngine_Shutdown();
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void AudioEngine_LoadSource(string name, string filepath);
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void AudioEngine_PlaySource(string name);
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void AudioEngine_StopSource(string name);
    
    [DllImport(DllName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void AudioEngine_PauseSource(string name);
}