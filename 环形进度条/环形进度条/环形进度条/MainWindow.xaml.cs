using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 环形进度条
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }


    class PercentConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double value = System.Convert.ToDouble(values[0]);
            double min = System.Convert.ToDouble(values[1]);
            double max = System.Convert.ToDouble(values[2]);
            if(value < min)
            {
                return 0.ToString() + "%";
            }
            if (value > max)
            {
                return 100.ToString() +"%";
            }
            return (((value - min) / (max - min)) * 100d).ToString("0") + "%";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    class EndAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double value = System.Convert.ToDouble(values[0]);
            double min = System.Convert.ToDouble(values[1]);
            double max = System.Convert.ToDouble(values[2]);
            if (value < min)
            {
                return 0d;
            }
            if (value > max)
            {
                return 360;
            }
            return ((value - min) / (max - min)) * 360;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
