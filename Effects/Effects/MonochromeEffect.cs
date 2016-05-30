using System;
using System.Windows;
using System.Windows.Media.Effects;

namespace Effects
{
    public class MonochromeEffect : ShaderEffect
    {
        private static PixelShader Shader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/Effects;component/Shaders/monochrome.fxo") };
        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(MonochromeEffect), 0);

        public MonochromeEffect()
        {
            PixelShader = Shader;
            UpdateShaderValue(InputProperty);
        }
    }
}
