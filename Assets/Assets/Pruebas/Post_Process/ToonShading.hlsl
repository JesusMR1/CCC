void MainLight_half(out half3 Direction)
{
#if SHADERGRAPH_PREVIEW
        Direction = half3(0,1,0);
#else
        Light light = GetMainLight();
        Direction = light.direction;
#endif
}
/*void ToonShading_float(in float3 Normal, in float ToonRampSmoothness, in float3 ClipSpacePos, in float3 WorldSpacePos, in float4 ToonRampTinting, in float ToonRampOffset, out float3 ToonRampOutput, out float3 Direction);
{
#ifdef SHADERGRAPH_PREVIEW
ToonRampOutput = float (0.5,0.5,0);
Direction = float(0.5,0.5,0);
#else

}*/