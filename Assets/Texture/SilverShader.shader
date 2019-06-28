// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Unlit/SilverShader"
{
    Properties
    {
       _DiffuseColor("Diffuse Color",Color)=(1,1,1,1)//漫反射属性_让人眼有立体感
	   _Gloss("Gloss",Range(8,128))=8//光泽度属性
    }
    SubShader
    {
        Tags { 
				"LightMode"="ForwardBase"//单一光源的有向光
	          }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
          

            #include "UnityCG.cginc"
			#include "Lighting.cginc"//用到了光的一下方法，需要include lighting.cg

            

            struct v2f
            {
                float4 vertex : SV_POSITION;//传位置
				float4 world_pos : TEXCOORD8;//传世界位置
				float3 world_normal : TEXCOORD9;//传世界法向量
            };

            sampler2D _MainTex;
			float3 _DiffuseColor;
			float _Gloss;

            v2f vert (appdata_full i)
            {
                v2f o=(v2f)0;
                o.vertex = UnityObjectToClipPos(i.vertex);
				o.world_pos = mul(unity_ObjectToWorld, i.vertex);
				//o.world_normal = mul((float3x3)_Object2World, i.normal);//将法线方向转换到世界坐标系下
				//o.world_normal = normalize(o.world_normal);
				//参照上次shader作业
				o.world_normal = UnityObjectToWorldNormal(i.normal);
				return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				float3 N = normalize(i.world_normal);
				float3 L = normalize(UnityWorldSpaceLightDir(i.world_pos));
				float3 V = normalize(UnityWorldSpaceViewDir(i.world_pos)); //视线方向 V 计算
				float3 diffuse_col = _LightColor0.rgb*_DiffuseColor*(saturate(dot(N,L))*0.5+0.5);
                
				float3 H = normalize(V + L);//半矢量 H 可以计算
				float3 specular_col = _LightColor0.rgb * pow(saturate(dot(H, N)), _Gloss);
                return fixed4(diffuse_col + specular_col,1);
            }
            ENDCG
        }
    }
}
