using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WpfAppTest.Services;
using WpfAppTest.ViewModels;

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var container = new UnityContainer();
            container.RegisterType<IDatabase, InMemoryDatabase>();
            mainWindow.DataContext = container.Resolve<MainViewModel>();
            mainWindow.ShowDialog();
        }
    }
}
