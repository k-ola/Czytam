using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Czytam.Extensions
{
    public static class ButtonExtensions
    {
        public static void CustomizeForDone(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            button.FontStyle = FontStyles.Italic;

            var margin = new Thickness();
            margin.Bottom = 20;
            button.Margin = margin;
            button.Width = 300;
            button.Height = 60;
        }

        public static void CustomizeForWordsDone(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            var margin = new Thickness();
            margin.Bottom = 5;
            button.Margin = margin;
            
        }

        public static void CustomizeForNotDone(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            button.FontWeight = FontWeights.Bold;
            var margin = new Thickness();
            margin.Bottom = 20;
            button.Margin = margin;
            button.Width = 300;
            button.Height = 60;

        }


        public static void CustomizeAsUserButton(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            var margin = new Thickness();
            margin.Bottom = 20;
            button.Margin = margin;
            button.Width = 300;
            button.Height = 60;
        }


        public static void CustomizeAsSyllableButton(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            var margin = new Thickness();
            margin.Bottom = 20;
            button.Margin = margin;
            button.Width = 40;
            button.Height = 40;

        }

        public static void CustomizeAsSoundButton(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            var margin = new Thickness();
            margin.Bottom = 5;
            button.Margin = margin;
            var padding = new Thickness();
            padding.Left = 10;
            padding.Right = 10;
            padding.Bottom = 3;
            padding.Top = 3;
            button.Padding = padding;
           
        }

        public static void CustomizeAsExerciseButton(this Button button)
        {
            var linearGradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0.5, 1)
            };
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("Violet"), 0));
            linearGradientBrush.GradientStops.Add(new GradientStop((Color)ColorConverter.ConvertFromString("#FF0F5FAE"), 1));
            button.Background = linearGradientBrush;
            button.FontFamily = new FontFamily("Nyala");
            button.FontSize = 22;
            button.FontWeight = FontWeights.Bold;
            var margin = new Thickness();
            margin.Bottom = 20;
            button.Margin = margin;
            button.Width = 300;
            button.Height = 60;
            
        }
    }
}
