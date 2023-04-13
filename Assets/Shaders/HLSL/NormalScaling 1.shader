Shader "Learning/Unlit/Normal Scaling"
{
    Properties
    {   
		_NormalScalingFactor("Normal Scaling Factor", Float) = 1
        _ScrollingSpeed("Scrolling Speed", Float) = 1.0
        _NoiseMap("Noise Map", 2D) = "white" {}
    }
    SubShader
    {
    
        Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
            float _NormalScalingFactor, _ScrollingSpeed;
			sampler2D _NoiseMap;
			
			struct vertexInput
            {
                float4 vertex : POSITION;  // object space						
                float3 normal : NORMAL;    // normal in object space
                float4 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
                // le scrolling peut bien sûr être fait dans le vertex shader
                // Plus optimisé car il y a bien plus souvent, moins de vertices que de pixels affichés
                // => exemple: un quad a seulement 4 vertices mais recouvre certainement des centaines voir milliers de pixels à l'écran
                v.uv.xy += float2(_Time.x * _ScrollingSpeed, 0);  
                
                // Si tex2Dlod(_NoiseMap, uvs).r retourne une couleur noire, le vertex n'est pas offseté
                // Si tex2Dlod(_NoiseMap, uvs).r = n avec n > 0, plus n sera grand, plus le vertex sera "offseté"
	            v.vertex.xyz += v.normal * _NormalScalingFactor * tex2Dlod(_NoiseMap, v.uv).r; 
	            
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv.xy;
    
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return tex2D(_NoiseMap, i.uv);
            }
            ENDHLSL
        }
    }
}
