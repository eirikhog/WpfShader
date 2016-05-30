
sampler2D input : register(s0);
sampler2D ascii : register(s1);

// TODO: Get input dimensions
//float2 dims : register(s2);

float4 main (float2 uv : TEXCOORD0) : COLOR {
    int characterSize = 64;
    int grayLevels = 8;
    int inputSize = 8192; // Size of the input. Take as input?
    int scale = inputSize / (characterSize);

    float4 pixel = tex2D(input, floor(uv*scale)/scale);
    int spriteIndex = floor((pixel.r + pixel.b + pixel.b)*grayLevels/3.0f);

    // Find the local offset for the current pixel
    int2 cellIdx = floor(uv * (inputSize - 1));
    float2 cellStart = (cellIdx/characterSize)*characterSize;

    // Calculate offset in ascii texture
    float2 offset = float2(cellIdx) - cellStart + 1;
    offset.x += spriteIndex*characterSize;
    offset /= (characterSize * grayLevels);

    return tex2D(ascii, offset);
}

