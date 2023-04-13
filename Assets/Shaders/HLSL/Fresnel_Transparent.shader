Shader "Learning/Unlit/Fresnel_Transparent"
{
    Properties
    {   
        _Exp("Fresnel Exponent", Range(0.1, 20)) = 2
        _MainColor("Main Color", Color) = (0.34, 0.85, 0.92, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off

		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
            
            // Variables du bloc Properties
            float _Exp; 
            float4 _MainColor, _OutlineColor;
            
            struct vertexInput
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldSpaceNormal : TEXCOORD0;
                float3 worldSpacePos : TEXCOORD1;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
               
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex).xyz;
                o.worldSpaceNormal = normalize(mul(unity_ObjectToWorld, float4(v.normal, 0)).xyz);               
                
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
	            float3 fragmentToCamera = normalize(_WorldSpaceCameraPos - i.worldSpacePos);
                i.worldSpaceNormal = normalize(i.worldSpaceNormal);

	            float NdotV = dot(i.worldSpaceNormal, fragmentToCamera);
                NdotV = 1 - NdotV;
                float rim = pow(NdotV, _Exp);
	            
                return float4(_MainColor.rgb, rim);
            }
            ENDHLSL
        }
    }
}
