Shader "Learning/Unlit/Fresnel_Opaque"
{
    Properties
    {   
        _Exp("Fresnel Exponent", Range(0.1, 20)) = 2
        _MainColor("Main Color", Color) = (0.34, 0.85, 0.92, 1)
        _OutlineColor("Outline Color", Color) = (0.34, 0.85, 0.92, 1)
		// Fresnel Exponent : float entre 0.1 & 20
        // 2 couleurs : une BaseColor (celle du mesh) et une pour l'effet du fresnel       
    }
    SubShader
    {
		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"
			
            
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
                
                // Calculer le vecteur PixelToCamera puis le normaliser
	            float3 fragmentToCamera = normalize(_WorldSpaceCameraPos - i.worldSpacePos); 
                // Normaliser de nouveau la normale de la struct v2f
                i.worldSpaceNormal = normalize(i.worldSpaceNormal);
                
                // Calcul du produit scalaire entre le vecteur PixelToCamera (View vector) & la normale
	            float NdotV = dot(i.worldSpaceNormal, fragmentToCamera);
                
                // Visualiser le résultat de NdotV  => ligne temporaire, juste pour comprendre l'effet à cette étape
                //return NdotV;
                
                // "Ajuster" le résultat obtenu
                NdotV = 1 - NdotV;
                
                // Utiliser la fonction pow(valueToRaise, FresnelExponent)
                float rim = pow(NdotV, _Exp);
	            
                // lerp entre BaseColor, FresnelColor et le rim calculé ci-dessus.
	            return lerp(_MainColor, _OutlineColor, rim);
            }
            ENDHLSL
        }
    }
}
