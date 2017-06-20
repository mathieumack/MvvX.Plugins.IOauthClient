﻿using System;
using System.Windows;
using MvvX.Plugins.IOAuthClient.Wpf;

namespace MvvX.Plugins.IOAuthClient.Sample.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            IOAuthClient auth = new PlatformOAuthClient();

            auth.New(this,
                         "temporaryKey",
                         clientId: "<ClientID>",
                         scope: "<scope>",
                         authorizeUrl: new Uri("<AuthorizeUrl>"),
                         redirectUrl: new Uri("<RedirectUrl>"));

            auth.AllowCancel = true;

            //auth.Error += (s, ee) =>
            //{
            //    Console.WriteLine(ee.Message);
            //};

            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.Completed += (s, ee) =>
            {
                if (!ee.IsAuthenticated)
                {
                    MessageBox.Show("Not Authenticated");
                    return;
                }

                else
                {
                    MessageBox.Show("Authenticated, well done");
                    return;
                }
            };

            auth.Start("Login");
        }
    }
}
