using System;
using System.Collections.Generic;
using System.IO;
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

namespace HtmlRtf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)                 //Конвертация в HTML
        {
            HtmlRtfConverter.ToHtml(new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd));
            txt.Text = File.ReadAllText("send.html");

            //для очистки
            File.Delete("send.html");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)               //Конвертация в Rtf
        {
            HtmlRtfConverter.ToRtf(txt.Text);

            //подобно тому, что было в лекции про RichTextBox
            var text = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);
            FileStream fs = new FileStream("msg.rtf", FileMode.Open);
            text.Load(fs, DataFormats.Rtf);
            fs.Close();

            //для очистки
            File.Delete("msg.rtf");
        }
    }
}
