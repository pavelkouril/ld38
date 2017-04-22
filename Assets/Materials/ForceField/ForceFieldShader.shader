Shader "Custom/ForceFieldShader"
{
	Properties
	{
		_DuDvTex("DuDvTexture", 2D) = "white" {}
		_GradTex("GradTexture", 2D) = "white" {}
		_MaskTex("MaskTexture", 2D) = "white" {}
		_FreqTex("FreqTexture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_Offset("Offset", Float) = 0.0
		_DuDvScale("DuDvScale", Range(0.0, 1.0)) = 0.87
		_OffsetSpeed("OffsetSpeed", Range(0.0, 1.0)) = 1.63
		_OffsetScale("OffsetScale", Range(0.0, 1.0)) = 0.074
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100

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

			sampler2D _DuDvTex;
			sampler2D _GradTex;
			sampler2D _MaskTex;
			sampler2D _FreqTex;
			float4 _Color;
			float _Offset;
			float _DuDvScale;
			float _OffsetScale;
			float _OffsetSpeed;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 offset = float2(_Offset * 0.025, _Offset * 0.1);
				float2 dudvOffset = tex2D(_DuDvTex, i.uv + offset * 3.0 * float2(0.63, -0.34)).xy * _DuDvScale;
				float2 dudvColor = tex2D(_DuDvTex, i.uv + offset * 2.8 * float2(0.37, 0.46)).xy * _OffsetScale;
				float2 coord = i.uv + (dudvOffset + dudvColor) * 0.5;

				float4 col = tex2D(_MaskTex, coord);

				float freqMult = cos((i.uv.y * 6.283185308 - 3.141592654) - _Offset) * 0.5 + 0.5;
				float freq = tex2D(_FreqTex, i.uv * 2.0).x * freqMult;

				float sourceGrad = abs(i.uv.x * 2.0 - 1.0);
				float sourceScale = pow(sourceGrad, 4.0);
				float sourceDir = sourceGrad > 0.0 ? 1.0 : -1.0;
				float2 sourceOffset = tex2D(_DuDvTex, i.uv * 1.0 + float2(_Offset * 0.1, 0.0)).xy * _DuDvScale;
				float sourceMult = pow(sourceGrad + 0.5 * sourceOffset * sourceDir, 4.0);

				float field = sourceMult + freq * freq * 0.8 + (freq * 0.3 + col.x) * max(sourceScale, 0.2) * (1.0 - freq);

				return float4(_Color.xyz, field);
			}
			ENDCG
		}
	}
}
