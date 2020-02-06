using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppTest.Services;
using WpfAppTest.ViewModels;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate;
using WpfAppTest.Models;
using NHibernate.Tool.hbm2ddl;

namespace WpfAppTest
{
    using Configuration = NHibernate.Cfg.Configuration;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
           

            var mainWindow = new MainWindow();
            //var container = new UnityContainer();
            //container.RegisterType<IDatabase, InMemoryDatabase>();
            mainWindow.DataContext = new MainViewModel();
            mainWindow.ShowDialog();
        }
    }
}
