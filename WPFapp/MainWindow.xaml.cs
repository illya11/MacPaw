using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFapp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Ellipse> Red = new List<Ellipse>();
        List<Ellipse> Blue = new List<Ellipse>();
        List<Ellipse> Green = new List<Ellipse>();
        station From = null;
        station To = null;
        List<station> way = new List<station>();

        public MainWindow()
        {
            InitializeComponent();
            Red = new List<Ellipse> { M110, M111, M112, M113, M114, M115, M116, M117, M118, M119, M120, M121, M122, M123, M124, M125, M126, M127 };
            Blue = new List<Ellipse> { M210, M211, M212, M213, M214, M215, M216, M217, M218, M219, M220, M221, M222, M223, M224, M225, M226, M227 };
            Green = new List<Ellipse> { M310, M311, M312, M313, M314, M315, M316, M317, M318, M319, M320, M321, M322, M323, M324, M325, M326, M327 };

        }
        
        private void changed_first_box(object sender, SelectionChangedEventArgs e)
        {
            stop_all_animation();
            way.Clear();
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string s = selectedItem.Content.ToString();
            From = new station(get_by_name(s), color_line(get_by_name(s)));
            if (To != null) build_way();
            do_animation();
        }

        private void changed_second_box(object sender, SelectionChangedEventArgs e)
        {
            stop_all_animation();
            way.Clear();
            ComboBox comboBox2 = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox2.SelectedItem;
            string s =  selectedItem.Content.ToString();
            To = new station(get_by_name(s), color_line(get_by_name(s)));
            if (From != null) build_way();
            do_animation();
        }

        private void stop_all_animation ()
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = 0;
            buttonAnimation.To = 1;
            buttonAnimation.Duration = TimeSpan.FromSeconds(1);
            buttonAnimation.AutoReverse = true;
            buttonAnimation.RepeatBehavior = new RepeatBehavior(0);
            M210.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M211.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M212.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M213.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M214.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M215.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M216.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M217.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M218.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M219.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M220.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M221.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M222.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M223.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M224.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M225.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M226.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M227.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M110.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M111.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M112.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M113.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M114.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M115.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M116.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M117.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M118.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M119.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M120.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M121.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M122.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M123.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M124.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M125.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M126.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M127.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M310.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M311.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M312.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M313.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M314.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M315.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M316.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M317.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M318.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M319.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M320.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M321.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M322.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M323.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M324.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M325.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M326.BeginAnimation(Button.OpacityProperty, buttonAnimation);
            M327.BeginAnimation(Button.OpacityProperty, buttonAnimation);
        }

        private void do_animation () // starting animation on our way
        {
            DoubleAnimation pointAnimation = new DoubleAnimation();
            pointAnimation.From = 0;
            pointAnimation.To = 1;
            pointAnimation.Duration = TimeSpan.FromSeconds(1);
            pointAnimation.AutoReverse = true;
            pointAnimation.RepeatBehavior = new RepeatBehavior(86400);
            foreach (station st in way)
            {
                st.M.BeginAnimation(Button.OpacityProperty, pointAnimation);
            }
        }

        private Ellipse get_by_name(string s) // return ellipse by the name of station
        {
            switch (s)
            {
                case "Академмістечко":
                    return Red[0];
                case "Житомирська":
                    return Red[1];
                case "Святошин":
                    return Red[2];
                case "Нивки":
                    return Red[3];
                case "Берестейська":
                    return Red[4];
                case "Шулявська":
                    return Red[5];
                case "Політехнічний інститут":
                    return Red[6];
                case "Вокзальна":
                    return Red[7];
                case "Університет":
                    return Red[8];
                case "Театральна":
                    return Red[9];
                case "Хрещатик":
                    return Red[10];
                case "Арсенальна":
                    return Red[11];
                case "Дніпро":
                    return Red[12];
                case "Гідропарк":
                    return Red[13];
                case "Лівобережна":
                    return Red[14];
                case "Дарниця":
                    return Red[15];
                case "Чернігівська":
                    return Red[16];
                case "Лісова":
                    return Red[17];
                case "Героїв Дніпра":
                    return Blue[0];
                case "Мінська":
                    return Blue[1];
                case "Оболонь":
                    return Blue[2];
                case "Петрівка":
                    return Blue[3];
                case "Тараса Шевченка":
                    return Blue[4];
                case "Контрактова площа":
                    return Blue[5];
                case "Поштова площа":
                    return Blue[6];
                case "Майдан Незалежності":
                    return Blue[7];
                case "Площа Льва Толстого":
                    return Blue[8];
                case "Олімпійська":
                    return Blue[9];
                case "Палац «Україна»":
                    return Blue[10];
                case "Либідська":
                    return Blue[11];
                case "Деміївська":
                    return Blue[12];
                case "Голосіївська":
                    return Blue[13];
                case "Васильківська":
                    return Blue[14];
                case "Виставковий центр":
                    return Blue[15];
                case "Іподром":
                    return Blue[16];
                case "Теремки":
                    return Blue[17];
                case "Сирець":
                    return Green[0];
                case "Дорогожичі":
                    return Green[1];
                case "Лук'янівська":
                    return Green[2];
                case "Золоті ворота":
                    return Green[4];
                case "Палац спорту":
                    return Green[5];
                case "Кловська":
                    return Green[6];
                case "Печерська":
                    return Green[7];
                case "Дружби народів":
                    return Green[8];
                case "Видубичі":
                    return Green[9];
                case "Славутич":
                    return Green[11];
                case "Осокорки":
                    return Green[12];
                case "Позняки":
                    return Green[13];
                case "Харківська":
                    return Green[14];
                case "Вирлиця":
                    return Green[15];
                case "Бориспільська":
                    return Green[16];
                case "Червоний хутір":
                    return Green[17];
            }
            return null;
        }

        private void build_way () // making a way - list of stations
        {
            
            if (From.on_one_line(To))
            {
                for (int i = Math.Min(Red.IndexOf(From.M), Red.IndexOf(To.M)); i < Math.Max(Red.IndexOf(From.M), Red.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Red[i], 'R'));
                }
                for (int i = Math.Min(Blue.IndexOf(From.M), Blue.IndexOf(To.M)); i < Math.Max(Blue.IndexOf(From.M), Blue.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Blue[i], 'B'));
                }
                for (int i = Math.Min(Green.IndexOf(From.M), Green.IndexOf(To.M)); i < Math.Max(Green.IndexOf(From.M), Green.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Green[i], 'G'));
                }
                way.Add(To);
            }
            else if (From.line == 'R' && To.line == 'B')
            {
                station ToChange = new station(M120, 'R');
                station FromChange = new station(M217, 'B');
                for (int i = Math.Min(Red.IndexOf(From.M), Red.IndexOf(ToChange.M)); i <= Math.Max(Red.IndexOf(From.M), Red.IndexOf(ToChange.M)); i++)
                {
                    way.Add(new station(Red[i], 'R'));
                }
                for (int i = Math.Min(Blue.IndexOf(FromChange.M), Blue.IndexOf(To.M)); i <= Math.Max(Blue.IndexOf(FromChange.M), Blue.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Blue[i], 'B'));
                }
            }
            else if (From.line == 'B' && To.line == 'R')
            {
                station ToChange = new station(M217, 'B');
                station FromChange = new station(M120, 'R');
                for (int i = Math.Min(Blue.IndexOf(From.M), Blue.IndexOf(ToChange.M)); i <= Math.Max(Blue.IndexOf(From.M), Blue.IndexOf(ToChange.M)); i++)
                {
                    way.Add(new station(Blue[i], 'R'));
                }
                for (int i = Math.Min(Red.IndexOf(FromChange.M), Red.IndexOf(To.M)); i <= Math.Max(Red.IndexOf(FromChange.M), Red.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Red[i], 'B'));
                }
            }
            else if (From.line == 'R' && To.line == 'G')
            {
                station ToChange = new station(M119, 'R');
                station FromChange = new station(M314, 'G');
                for (int i = Math.Min(Red.IndexOf(From.M), Red.IndexOf(ToChange.M)); i <= Math.Max(Red.IndexOf(From.M), Red.IndexOf(ToChange.M)); i++)
                {
                    way.Add(new station(Red[i], 'R'));
                }
                for (int i = Math.Min(Green.IndexOf(FromChange.M), Green.IndexOf(To.M)); i <= Math.Max(Green.IndexOf(FromChange.M), Green.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Green[i], 'G'));
                }
            }
            else if (From.line == 'G' && To.line == 'R')
            {
                station ToChange = new station(M314, 'G');
                station FromChange = new station(M119, 'R');
                for (int i = Math.Min(Green.IndexOf(From.M), Green.IndexOf(ToChange.M)); i <= Math.Max(Green.IndexOf(From.M), Green.IndexOf(ToChange.M)); i++)
                {
                    way.Add(new station(Green[i], 'R'));
                }
                for (int i = Math.Min(Red.IndexOf(FromChange.M), Red.IndexOf(To.M)); i <= Math.Max(Red.IndexOf(FromChange.M), Red.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Red[i], 'G'));
                }
            }
            else if (From.line == 'B' && To.line == 'G')
            {
                station ToChange = new station(M218, 'B');
                station FromChange = new station(M315, 'G');
                for (int i = Math.Min(Blue.IndexOf(From.M), Blue.IndexOf(ToChange.M)); i <= Math.Max(Blue.IndexOf(From.M), Blue.IndexOf(ToChange.M)); i++)
                {
                    way.Add(new station(Blue[i], 'B'));
                }
                for (int i = Math.Min(Green.IndexOf(FromChange.M), Green.IndexOf(To.M)); i <= Math.Max(Green.IndexOf(FromChange.M), Green.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Green[i], 'G'));
                }
            }
            else  // (From.line == 'G' && To.line == 'B')
            {
                station ToChange = new station(M315, 'G');
                station FromChange = new station(M218, 'B');
                for (int i = Math.Min(Green.IndexOf(From.M), Green.IndexOf(ToChange.M)); i <= Math.Max(Green.IndexOf(From.M), Green.IndexOf(ToChange.M)); i++)
                {
                    way.Add(new station(Green[i], 'B'));
                }
                for (int i = Math.Min(Blue.IndexOf(FromChange.M), Blue.IndexOf(To.M)); i <= Math.Max(Blue.IndexOf(FromChange.M), Blue.IndexOf(To.M)); i++)
                {
                    way.Add(new station(Blue[i], 'G'));
                }
            }
        }

        private char color_line (Ellipse m)
        {
            if (Red.IndexOf(m) != -1) return 'R';
            else if (Blue.IndexOf(m) != -1) return 'B';
            else if (Green.IndexOf(m) != -1) return 'G';
            else return ' ';
        }
        
    }

    public class station
    {
        public Ellipse M;
        public char line;
        public station(Ellipse e, char c)
        {
            M = e;
            line = c;
        }
        public bool on_one_line(station other)
        {
            if (line == other.line) return true;
            return false;
        }
    }

}
