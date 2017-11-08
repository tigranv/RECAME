using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BisolUITest.v1
{
    public class MyButton : Button
    {

        static MyButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyButton), new FrameworkPropertyMetadata(typeof(MyButton)));
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource),
            typeof(MyButton), new FrameworkPropertyMetadata(null));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceHoverProperty = DependencyProperty.Register("ImageSourceHover", typeof(ImageSource),
            typeof(MyButton), new FrameworkPropertyMetadata(null));

        public ImageSource ImageSourceHover
        {
            get { return (ImageSource)GetValue(ImageSourceHoverProperty); }
            set { SetValue(ImageSourceHoverProperty, value); }
        }

        public static readonly DependencyProperty ImageSourcePressedProperty = DependencyProperty.Register("ImageSourcePressed", typeof(ImageSource),
            typeof(MyButton), new FrameworkPropertyMetadata(null));

        public ImageSource ImageSourcePressed
        {
            get { return (ImageSource)GetValue(ImageSourcePressedProperty); }
            set { SetValue(ImageSourcePressedProperty, value); }
        }

    }
}
