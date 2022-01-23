Shader "Custom/outline"
{
    Properties{
        _Albedo ("Albedo", Color) = (1,1,1,1)
        _OutlineWidth ("Outline Width", float) = 0.1
        _color ("color",Color) = (1.0,0.0,0.0,1.0)
    }
    SubShader {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        ZWrite On

        Pass {
            Stencil {
                Ref 42
                Comp always
                Pass replace //ステンシル42を書き込む
            }

            Cull Front //面を内側に向ける
            ColorMask 0

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                half4 vertex : POSITION;
                half3 normal : NORMAL;
            };

            struct v2f {
                half4 pos : SV_POSITION;
            };

            half _OutlineWidth;

            v2f vert (appdata v) {
                v2f o = (v2f)0;
                o.pos = UnityObjectToClipPos(v.vertex + v.normal * _OutlineWidth);//オブジェクトを法線方向に膨らませる
                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                return 0;
            }
            ENDCG
        }

        Pass {
            Stencil {
                Ref 0
                Comp always
                Pass replace //ステンシルを0でリセット
            }

            Cull back
            ColorMask 0

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata {
                half4 vertex : POSITION;
            };

            struct v2f{
                half4 pos : SV_POSITION;
            };

            v2f vert (appdata v) {
                v2f o = (v2f)0;

                o.pos = UnityObjectToClipPos(v.vertex);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                return 0;
            }
            ENDCG
        }

        Pass {
            Stencil {
                Ref 42 
                Comp equal
                Pass keep //ステンシルが42なら描写
            }

            Cull back

           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag

           #include "UnityCG.cginc"

            struct appdata {
                half4 vertex : POSITION;
                half3 normal : NORMAL;
            };

            struct v2f {
                half4 pos : SV_POSITION;
            };

            half _OutlineWidth;
            fixed4 _color;

            v2f vert (appdata v) {
                v2f o = (v2f)0;

                o.pos = UnityObjectToClipPos(v.vertex + v.normal * _OutlineWidth);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target {
                return _color;
            }
            ENDCG
        }
    }
}