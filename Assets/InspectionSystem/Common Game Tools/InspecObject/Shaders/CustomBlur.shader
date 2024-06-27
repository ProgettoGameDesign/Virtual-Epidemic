Shader "CGT/CustomBlur"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_BlurSize("Blur Size", Range(0,15)) = 10	
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;			
			uniform int _BlurSize;
			uniform float4 _MainTex_TexelSize;

			fixed4 frag(v2f i) : SV_Target{
			
				//init color variable
				float measurments = 1;
				float4 col = tex2D(_MainTex, i.uv);
				for(float index=1; index<_BlurSize; index++) {
					float uvx = _MainTex_TexelSize.x*index;
					float uvy = _MainTex_TexelSize.y*index;
					col += tex2D(_MainTex, i.uv+float2(uvx,uvy));
					col += tex2D(_MainTex, i.uv+float2(uvx,-uvy));
					col += tex2D(_MainTex, i.uv+float2(-uvx,uvy));
					col += tex2D(_MainTex, i.uv+float2(-uvx,-uvy));
                    measurments += 4;
				}
				col = col / measurments;
				
				return col;
			}
			ENDCG
		}
	}
}
