Shader "Hidden/Bataryy"
{
    Properties
    {
        _MainTex ("Texture 1", 2D) = "white" {}
        _SecondTex ("Texture 2", 2D) = "black" {}
        _Fill ("Fill Amount", Range(0,1)) = 0.5
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent" "RenderType"="Transparent"
        }
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off Lighting Off ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            sampler2D _SecondTex;
            float _Fill;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Плавное переключение между текстурами, при _Fill = 0 показывается только первая текстура
                float blendFactor = (i.uv.y > _Fill) ? 1.0 : 0.0;

                // Получаем цвета из двух текстур
                fixed4 tex1 = tex2D(_MainTex, i.uv) * i.color;
                fixed4 tex2 = tex2D(_SecondTex, i.uv) * i.color;

                // Возвращаем плавное смешивание текстур
                return lerp(tex1, tex2, blendFactor);
            }
            ENDCG
        }
    }
}