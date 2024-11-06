// Copyright (c) Evangelion Manuhutu | ORigin Engine

#ifndef AUDIO_ENGINE_H
#define AUDIO_ENGINE_H

#include "miniaudio.h"
#include "core/base.h"

extern "C" {
    ENGINE_API void AudioEngine_Init();
    ENGINE_API void AudioEngine_Shutdown();
    ENGINE_API void AudioEngine_LoadSource(const char *name, const char *filepath);
    ENGINE_API void AudioEngine_PlaySource(const char *name);
    ENGINE_API void AudioEngine_StopSource(const char *name);
    ENGINE_API void AudioEngine_PauseSource(const char *name);
}

#endif