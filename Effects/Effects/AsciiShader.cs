using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace Effects
{
    public class AsciiShader : ShaderEffect
    {
        private static PixelShader Shader = new PixelShader() { UriSource = new Uri(@"pack://application:,,,/Effects;component/Shaders/ascii.fxo") };
        private static BitmapImage AsciiTextureBitmap = new BitmapImage(new Uri("pack://application:,,,/Effects;component/Resources/ascii.png"));

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("InputTexture", typeof(AsciiShader), 0);
        public static readonly DependencyProperty AsciiProperty = RegisterPixelShaderSamplerProperty("AsciiTexture", typeof(AsciiShader), 1);

        public AsciiShader()
        {
            PixelShader = Shader;
            var brush = new ImageBrush() { ImageSource = AsciiTextureBitmap };
            SetValue(AsciiProperty, brush);

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(AsciiProperty);
            //UpdateShaderValue(DimensionsProperty);
        }

        //public Size Dimensions
        //{
        //    get { return (Size)GetValue(DimensionsProperty); }
        //    set { SetValue(DimensionsProperty, value); }
        //}

        //public static readonly DependencyProperty DimensionsProperty = DependencyProperty.Register("Dimensions", typeof(Size), typeof(AsciiShader),
        //    new UIPropertyMetadata(new Size(1024, 768), PixelShaderConstantCallback(2)));
    }
}
