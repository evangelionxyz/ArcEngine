// Copyright (c) Evangelion Manuhutu | ORigin Engine

#define MINIAUDIO_IMPLEMENTATION

#include "audio_engine.h"

#include <iostream>
#include <unordered_map>

#include <filesystem>

struct AudioEngineData
{
    ma_engine *Engine;
    ma_engine_config Config;
    std::unordered_map<std::string, ma_sound *> SoundsMap;
};

static AudioEngineData s_AudioData;

void AudioEngine_Init()
{
    s_AudioData.Config = ma_engine_config_init();
    s_AudioData.Config.channels = 2;
    s_AudioData.Config.sampleRate = 48000;
    s_AudioData.Config.noDevice = MA_FALSE;
    s_AudioData.Engine = new ma_engine();
    ma_result result = ma_engine_init(&s_AudioData.Config, s_AudioData.Engine);
    if (result != MA_SUCCESS)
        std::cerr << "Failed to initialize ma_engine" << '\n';
    else
        std::cout << "ma_engine_init success" << '\n';
}

void AudioEngine_Shutdown()
{
    ma_engine_uninit(s_AudioData.Engine);
    delete s_AudioData.Engine;
    s_AudioData.Engine = nullptr;
    std::cout << "ma_engine_shutdown success" << '\n';
}

void AudioEngine_LoadSource(const char *name, const char *filepath)
{
    if (!std::filesystem::exists(filepath))
    {
        std::cerr << "File " << filepath << " does not exist" << '\n';
        return;
    }
    
    ma_sound *sound = new ma_sound();
    ma_result result = ma_sound_init_from_file(s_AudioData.Engine, filepath, 0, nullptr, nullptr, sound);
    if (result == MA_SUCCESS)
    {
        std::cout << "Audio Source loaded" << '\n';
        s_AudioData.SoundsMap.insert({name, sound});
    }
    else
    {
        std::cerr << "Failed to load sound" << '\n';
    }
}

void AudioEngine_PlaySource(const char *name)
{
    auto it = s_AudioData.SoundsMap.find(name);
    if (it != s_AudioData.SoundsMap.end())
    {
        std::cout << "Playing sound " << name << '\n';
        ma_sound *sound = s_AudioData.SoundsMap.at(name);
        if (!ma_sound_is_playing(sound))
            ma_sound_start(sound);
    }
    else
    {
        std::cout << "No sound found" << '\n';
    }
}

void AudioEngine_StopSource(const char *name)
{
    if (s_AudioData.SoundsMap.count(name))
    {
        ma_sound *sound = s_AudioData.SoundsMap.at(name);
        ma_sound_stop(sound);
        ma_sound_seek_to_pcm_frame(sound, 0);
    }
}

void AudioEngine_PauseSource(const char *name)
{
    if (s_AudioData.SoundsMap.count(name))
    {
        ma_sound *sound = s_AudioData.SoundsMap.at(name);
        ma_sound_stop(sound);
    }
}
