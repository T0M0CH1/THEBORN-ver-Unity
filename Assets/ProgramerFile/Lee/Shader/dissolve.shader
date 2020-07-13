Shader "Custom/dissplve"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_noise("Texture", 2D) = "white" {}
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
			sampler2D _noise;

            fixed4 frag (v2f i) : SV_Target
            {
				fixed3 col = tex2D(_MainTex, i.uv).rgb;
				float height = tex2D(_noise, i.uv.xy).r;

				float condition = step(height, sin(_Time * 10));
                // just invert the colors

				col = col * (1 - condition);
				
                //col.rgb = 1 - col.rgb;
                return fixed4(col, 0.0f);
            }
            ENDCG
        }
    }
}
