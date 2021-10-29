Shader "Unlit/PortalCutoutShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent" "IgnoreProjector" = "True"}
        //portals are treated as transparent so they won't cast shadows and whatnot
        //ignoreprojector tells it not to be affected by projected textures like decals and whatnot
        LOD 100

        Pass
        {
            Tags { "LightMode" = "Always"}
            //prevents lighting from being applied, maybe? this might not help anything
            Cull Back //don't render the back of the texture, probably a good idea

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                //float2 uv : TEXCOORD0; //not using TEXCOORD0
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;

                float4 screenPos : TEXCOORD1; //creates screen position variable, sets it to UV coordinates 1
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                //o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);

                o.screenPos = ComputeScreenPos(o.vertex); //returns position of o vertex on the screen
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                i.screenPos /= i.screenPos.w; //divide screenpos by w ?

                // sample the texture
                fixed4 col = tex2D(_MainTex, float2(i.screenPos.x, i.screenPos.y)); //creates a uv with screenpos x and y
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
