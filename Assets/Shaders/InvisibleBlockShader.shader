Shader "Custom/InvisibleBlockerShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,0)
    }
    SubShader
    {
        Tags { "Queue"="Geometry+1" "IgnoreProjector"="True" "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Blend Zero One
            ZWrite On

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                // Rende il frammento completamente trasparente
                return half4(0,0,0,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
