
Shader "2D/Unlit TileMap"
{
    Properties
    {
        [MainTexture][NoScaleOffset] _MapPixels ("Map Data", 2D) = "black" {}
        [NoScaleOffset] _TilePalette ("Tile Palette SpriteSheet (ARGB)", 2D) = "black" {}
        _MapDataSize ("Map Data Size in tiles", vector) = (10.,10.,0.,0.) // Size of the tilemap data in tiles e.g. 10x10 = 100 tiles each tile is 1 pixel
        _TilePaletteSize ("Tile Palete size in tiles", vector) = (23.,21.,0.,0.) // Size of the tileset in columns and rows (here are stored the tiles textures in a grid)
    }
 
    SubShader
    {
        Tags {"RenderType"="Transparent" "Queue"="Transparent"}
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha 
 
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
 
            uniform sampler2D _MapPixels; // Map data texture
            uniform sampler2D _TilePalette; // Tile palette texture
            uniform fixed2 _MapDataSize;
            fixed2 _TilePaletteSize;
            struct MeshData
            {
                float4 pos   : POSITION;
                float2 uv    : TEXCOORD0;
                // Custom vertex attributes
            };
 
            struct v2f
            {
                float4 pos   : SV_POSITION;
                float2 uv     : TEXCOORD0;
            };
            // Vertex shader (For each vertex in the mesh)
            v2f vert(MeshData input)
            {
                v2f output;
                output.pos = UnityObjectToClipPos(input.pos);
                output.uv = input.uv;
                // Here you can do some custom vertex manipulation
                
                return output;
            }
            // After Vertex Shader, RASTERIZATION
            // Thn Fragment Shader (For each pixel inside a triangle)
            fixed4 frag(v2f i) : SV_Target
            {
                // Get the tile position from the map texture
                float4 tilePosition255 = tex2D(_MapPixels, i.uv);
                if (tilePosition255.a < 0.2) discard;
                
                // Convert tile position to range 0-1 and scale by _TilePaletteSize
                float2 tilePosition = tilePosition255.xy * 255.0f / (_TilePaletteSize.xy);
                if (tilePosition255.x > 1 || tilePosition255.y > 1) {
                    return float4(1, 0, 1, 1); // Magenta for out of bounds
                }
            
                // Convert to isometric coordinates
                float2 isoTilePosition;
                isoTilePosition.x = (tilePosition.x - tilePosition.y) * 0.5;
                isoTilePosition.y = (tilePosition.x + tilePosition.y) * 0.25;
            
                // Get the UV offset inside the tile
                float2 offsetInsideTile = frac(i.uv * _MapDataSize.yx) / _TilePaletteSize.xy;
                
                // Calculate the UV coordinates within the tile palette
                float2 uvTileInSet = isoTilePosition + offsetInsideTile.xy; 
            
                // Get the color from the tile palette texture
                float4 colorFromTileSet = tex2D(_TilePalette, uvTileInSet);
            
                return colorFromTileSet;
            }
            
            
            
            ENDCG
        }
    }
 
    Fallback off
}