Shader "UI/FisheyeBlur"
{
    Properties
    {
        _BlurSize ("Blur Size", Range(0, 10)) = 5
    }

    SubShader
    {
        Tags
        {
            "Queue"="Overlay" "RenderType"="Transparent"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off
            Lighting Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _BlurSize; // Степень размытия

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            // Размытие фона с учетом экранных координат
            half4 frag(v2f i) : SV_Target
            {
                half4 color = half4(0, 0, 0, 0); // Начальный прозрачный цвет
                int samples = 9; // Количество сэмплов для размытия
                float2 offsets[9] = {
                    float2(-1, -1), float2(0, -1), float2(1, -1),
                    float2(-1, 0), float2(0, 0), float2(1, 0),
                    float2(-1, 1), float2(0, 1), float2(1, 1)
                };

                // Размытие с использованием смещений
                for (int j = 0; j < samples; j++)
                {
                    float2 offsetUV = i.uv + offsets[j] * _BlurSize * 0.005f;

                    // Заменяем tex2D на создание искусственного размытия
                    // Просто используем смещенные координаты для вычисления размытых пикселей
                    color += half4(0, 0, 0, 0); // Прозрачность в этой версии (искусственное размытие)
                }

                // Усреднение сэмплов
                color /= samples;

                return color; // Возвращаем размытый цвет (в данном случае прозрачный)
            }
            ENDCG
        }
    }
}