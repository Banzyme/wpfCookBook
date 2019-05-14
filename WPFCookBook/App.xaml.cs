﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using WPFCookBook.DataService.Repository;

namespace WPFCookBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IWpfCourseModulesRepository, WpfCourseModulesRepository>();
            container.RegisterType<IWpfCourseSectionRepository, WpfCourseSectionRepository>();
            container.RegisterType<IWpfCourseSectionItemRepo, WpfCourseSectionItemRepo>();
        }
    }
}
