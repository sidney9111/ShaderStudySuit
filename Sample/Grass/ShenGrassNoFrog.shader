Shader "Sample/Grass/ShenGrass"
{
	Properties{
		_Color("Color",color) = (1,1,1,1)
		_MainTex("Texture",2D) = "white"{}
	}
	
	SubShader{
		//Tags{}

		Pass{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
	#include "UnityCG.cginc"

			struct appdata {

				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float4 color : COLOR;
			};
			struct v2f {
				float2 uv: TEXCOORD0;
				float4 vertex : SV_POSITION;

			};
			v2f vert(appdata v) {
				v2f o;
				float vert = v.vertex;
				o.vertex = UnityObjectToClipPos(vert);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				return col;
			}
			ENDCG
		}
	}
}