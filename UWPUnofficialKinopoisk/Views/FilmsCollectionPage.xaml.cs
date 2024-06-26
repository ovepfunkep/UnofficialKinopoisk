﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using UWPUnofficialKinopoisk.Parameters;
using UWPUnofficialKinopoisk.ViewModels;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPUnofficialKinopoisk.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilmsCollectionPage : Page
    {
        public FilmsCollectionPage()
        {
            DataContext = new FilmsCollectionViewModel();
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var parameters = (FilmsCollectionPageParameters)e.Parameter;
            if (parameters != null) ((FilmsCollectionViewModel)DataContext).ShowOnlyFavorites = parameters.ShowOnlyFavorite;
            base.OnNavigatedTo(e);
        }
    }
}
