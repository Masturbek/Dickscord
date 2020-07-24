using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Progect1.Controls
{
    public partial class VectorButton : UserControl
    {
        public VectorButton() => InitializeComponent();

        /*
         * Два свойства:
         * 1. Геометрия - некий векторный набор точек.
         * 2. Комманта - будет выполняться при клике.
         */

        public Geometry Path
        {
            get => (Geometry)GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(Geometry), typeof(VectorButton), new PropertyMetadata(Geometry.Parse("M13,14H11V10H13M13,18H11V16H13M1,21H23L12,2L1,21Z")));


        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(VectorButton));



        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(VectorButton));



    }
}
