Shader "Learning/Unlit/DemoWeek2"
{
    Properties
    {   
        _Exp("Exponent", Range(0.1, 20)) = 2
        _Bands("Number of bands", Range(1, 20)) = 2
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" }

		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
            float _Exp, _Bands;

			struct vertexInput
            {
                float4 vertex : POSITION;	
                float2 uv : TEXCOORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                return o;
            }
            
            // Pour un meilleur résultat, à appliquer sur une primitive de type Quad
            float4 frag(v2f i) : SV_Target
            {       
                return i.uv.x;
                //return 1 - i.uv.x;
                //return pow(1 - i.uv.x, _Exp);
                //return floor(i.uv.x * _Bands) / _Bands;    // ceil
            }
            
            ENDHLSL
        }
    }
}
