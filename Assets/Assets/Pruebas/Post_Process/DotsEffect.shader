using UnityEngine.Rendering;
usingUnityEngine.Rendering.HighDefinition;

Shader"Hidden/DotsEffectShader"

public Volume m_Volume;
public bool enableBloom;
public bool overrideBloom;


VolumeProfile profile = m_Volume.sharedProfile;
if (!profile.TryGet<Bloom>(out var bloom))
{
    bloom = profile.Add<Bloom>(false);
}

bloom.enabled.overrideState = overrideBloom;
bloom.enabled.value = enableBloom;

