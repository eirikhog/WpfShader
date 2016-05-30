
sampler2D input : register(s0);

float4 main(float2 uv : TEXCOORD) : COLOR {
    float4 color = tex2D(input, uv);
    float4 newColor = { 1.0f, 1.0f, 1.0f, 1.0f };
    newColor *= (color.r + color.b + color.g)/3.0f;
    newColor.a = color.a;
    return newColor;
}

