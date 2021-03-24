using DnDCharacterMaker.Enumerations;
using DnDCharacterMaker.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DnDCharacterMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string DisplayString { get ;set;}

        public MainWindow()
        {
           ShowWindow();
        }

        private async Task<List<PlayerClassRoute>> LoadClassesAsync()
        {
            var httpRequestResponse = new HttpRequestResponse();
            var repo = new DnDApiRepository();

            var classList = new List<PlayerClassRoute>();
            foreach (var playerClassValue in PlayerClassRoute.Contents)
            {
                var _class = repo.GetPlayerClassAsync(playerClassValue);
                Debug.Print(_class.name);
            }
            return classList;
        }

        private async Task ShowWindow()
        {
            Debug.Print("Hello!");
            Debug.Print("Hold Please.");
            var classList = Task.Run(() => LoadClassesAsync());
            
            InitializeComponent();
            Debug.Print("Bye!");
        }

    }
}
