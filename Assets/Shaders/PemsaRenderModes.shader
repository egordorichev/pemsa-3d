Shader "Custom/PemsaRenderModes"
{
    Properties
    {
        _StretchMultX ("Stretch Multiplier X", Float) = 1.0
        _StretchMultY ("Stretch Multiplier Y", Float) = 1.0

        _MirrorX ("Mirror X", Float) = 0.0
        _MirrorY ("Mirror Y", Float) = 0.0

        _FlipX ("Flip X", Float) = 0.0
        _FlipY ("Flip Y", Float) = 0.0

        _Rot("Rotation", Float) = 0.0

        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Unlit vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        float _StretchMultX;
        float _StretchMultY;
        float _MirrorX;
        float _MirrorY;
        float _FlipX;
        float _FlipY;
        float _Rot;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        fixed4 LightingUnlit(SurfaceOutput s, fixed3 lightDir, fixed atten)
        {
            return fixed4(s.Albedo, s.Alpha);
        }

        void vert(inout appdata_full v) {
            v.texcoord.xy -= 0.5;
            float s = sin(_Rot);
            float c = cos(_Rot);
            float2x2 rotationMatrix = float2x2(c, -s, s, c);
            rotationMatrix *= 0.5;
            rotationMatrix += 0.5;
            rotationMatrix = rotationMatrix * 2 - 1;
            v.texcoord.xy = mul(v.texcoord.xy, rotationMatrix);
            v.texcoord.xy += 0.5;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            // new texture coordinates.
            float2 newTexCoord; 
            
            // Stretch texture.
            newTexCoord = float2(IN.uv_MainTex.x * _StretchMultX, (IN.uv_MainTex.y-1) * -_StretchMultY);

            // Flip.
            newTexCoord = float2(
                _FlipX != 0 ? 1.0 - newTexCoord.x : newTexCoord.x,
                _FlipY != 0 ? 1.0 - newTexCoord.y : newTexCoord.y);

            // Mirror
            newTexCoord = float2(
                _MirrorX != 0 && newTexCoord.x > 0.5 ? 1.0 - newTexCoord.x : newTexCoord.x,
                _MirrorY != 0 && newTexCoord.y > 0.5 ? 1.0 - newTexCoord.y : newTexCoord.y);

            fixed4 c = tex2D (_MainTex, newTexCoord) * _Color;
            o.Albedo = c.rgb;

            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
