Shader "Unlit/Textured" {
    Properties {
        _BlocksTex ("Texture", 2D) = "white" {}
		_BlockPxSize ("BlockPxSize", Float) = 32
        _MipSampleLevel ("MIP", Float) = 0
		_TilemapTex ("TilemapTex", 2D) = "white" {}
		
    }
    SubShader {
        Tags { "RenderType"="Opaque" }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"


            struct MeshData {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _BlocksTex;
			float4 _BlocksTex_TexelSize;
			sampler2D _TilemapTex;
            float _MipSampleLevel;
			float _BlockPxSize;
            //VERTEX SHADER
            Interpolators vert (MeshData v) {
                Interpolators o;
                o.worldPos = mul( UNITY_MATRIX_M, v.vertex ); // object to world
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }
			//FRAGMENT SHADER (PIXELS INSIDE TRIANGLES)
            float4 frag (Interpolators i) : SV_Target {
				float TextureWidth = _BlocksTex_TexelSize.w/1024*_BlockPxSize;
				// TextureWidth = 2;

				return float4( floor(i.uv.x*TextureWidth)/TextureWidth,0,0, 1 );
            }
            ENDCG
        }
    }
}
