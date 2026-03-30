using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Net.Http;

namespace AstralService
{
    public partial class MainWindow : Window
    {

        private static readonly HttpClient client = new();

        public MainWindow()
        {
            InitializeComponent();
            FadeInText();
        }

        private async void FadeInText ()
        {
            DoubleAnimation fadeIn = new()
            { 
            
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(2500),
                AutoReverse = false
            
            
            };
            LogoImage.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            LoadingText.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            await Task.Delay(3500);
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://95.85.251.53:8000/auth");
                System.Diagnostics.Debug.WriteLine("OK");
            } catch (Exception ex)
            {
                MessageBox.Show($"NO: {ex}");
            }


        }

    }
}