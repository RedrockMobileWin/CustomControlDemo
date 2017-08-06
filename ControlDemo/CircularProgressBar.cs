using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ControlDemo
{
    public sealed class CircularProgressBar : Control
    {
        private static DoubleCollection _RingInitNum = new DoubleCollection();
        public CircularProgressBar()
        {
            //让样式和逻辑代码联系起来
            this.DefaultStyleKey = typeof(CircularProgressBar);
            //_RingInitNum.Add(0);
            //_RingInitNum.Add(Width * 3);
        }
        public static readonly DependencyProperty ProgressNumProperty = DependencyProperty.Register("ProgressNum", typeof(double),
            typeof(CircularProgressBar), new PropertyMetadata(.0, OnProgressNumChanged));
        public static readonly DependencyProperty ProgressNumTextProperty = DependencyProperty.Register("ProgressNumText", typeof(string),
            typeof(CircularProgressBar), new PropertyMetadata("0"));
        public static readonly DependencyProperty CircularWidthProperty = DependencyProperty.Register("CircularWidth", typeof(double),
            typeof(CircularProgressBar), new PropertyMetadata(0,OnCircularWidthChanged));

        public static readonly DependencyProperty RingLengthProperty = DependencyProperty.Register("RingLength", typeof(DoubleCollection),
            typeof(CircularProgressBar), new PropertyMetadata(_RingInitNum));
        public static readonly DependencyProperty RingForegroundColorProperty = DependencyProperty.Register("RingForegroundColor", typeof(Brush),
           typeof(CircularProgressBar), new PropertyMetadata(null));
        public static readonly DependencyProperty RingBackgroundColorProperty = DependencyProperty.Register("RingBackgroundColor", typeof(Brush),
            typeof(CircularProgressBar), new PropertyMetadata(null));
        public static readonly DependencyProperty RingWidthProperty = DependencyProperty.Register("RingWidth", typeof(double),
            typeof(CircularProgressBar), new PropertyMetadata(150));
        public double CircularWidth
        {
            get { return (double)GetValue(CircularWidthProperty); }
            set { SetValue(CircularWidthProperty, value); }
        }
        public double ProgressNum
        {
            get { return (double)GetValue(ProgressNumProperty); }
            set { SetValue(ProgressNumProperty, value); }
        }
        public string ProgressNumText
        {
            get { return (string)GetValue(ProgressNumTextProperty); }
            private set { SetValue(ProgressNumTextProperty, value); }
        }
        public DoubleCollection RingLength
        {
            get { return (DoubleCollection)GetValue(RingLengthProperty); }
            set { SetValue(RingLengthProperty, value); }
        }
        public Brush RingForegroundColor
        {
            get { return (Brush)GetValue(RingForegroundColorProperty); }
            set { SetValue(RingForegroundColorProperty, value); }
        }
        public Brush RingBackgroundColor
        {
            get { return (Brush)GetValue(RingBackgroundColorProperty); }
            set { SetValue(RingBackgroundColorProperty, value); }
        }
        public double RingWidth
        {
            get { return (double)GetValue(RingWidthProperty); }
            set { SetValue(RingWidthProperty, value); }
        }
        private static void OnProgressNumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CircularProgressBar cpb = d as CircularProgressBar;
            cpb.ProgressNumText = (cpb.ProgressNum * 100).ToString("0.00") + "%";

            //圆形直径
            double diameter = cpb.Width - cpb.RingWidth;

            //环形长度
            double cirLength = diameter * 3.14 * cpb.ProgressNum / cpb.RingWidth;
            DoubleCollection dc = new DoubleCollection();
            dc.Add(cirLength);
            //填充间隔长度 远大于周长
            dc.Add(cpb.Width * 3.14*3);
            cpb.RingLength = dc;
        }

        private static void OnCircularWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CircularProgressBar cpb = d as CircularProgressBar;
            cpb.Width =cpb.Height = cpb.CircularWidth;
        }

    }
}
