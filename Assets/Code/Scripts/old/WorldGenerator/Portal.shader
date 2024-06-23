Shader "Unlit/PortalTexture"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100
		Cull Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog //Make fog work.
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
				float2 preclampdepth : TEXCOORD1;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);

				//Save screen pos as that's how we render the given render texture.
				float2 scrpos = ComputeScreenPos(o.vertex);
				o.uv.x = scrpos.x;
				o.uv.y = (scrpos.y / _ScreenParams.w);

				//Cache depth before clamping vertices so we can restore that depth in the frag shader. 
				o.preclampdepth.x = o.vertex.z;

				//Clamp the vertex's depth so it can't be behind the near plane. Homogenous coordinates make this simple. 
				o.vertex.z = clamp(o.vertex.z, -1, 0);

				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i, out float depth : SV_Depth) : SV_Target
			{
				float2 scrpos = i.uv.xy / i.vertex.w; //Sample the texture.
				fixed4 col = tex2D(_MainTex, float2(scrpos.x, 1 - scrpos.y)); //Flip to account for flipped textures.
				UNITY_APPLY_FOG(i.fogCoord, col); //Apply fog.
				depth = i.preclampdepth.x / i.vertex.w; //Convert to NDC, which happens between vert and frag shaders. 

				return col;
			}
			ENDCG
		}
		
	}
	Fallback "Diffuse"
}
