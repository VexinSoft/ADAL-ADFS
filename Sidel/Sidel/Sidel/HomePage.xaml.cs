﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sidel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(string userName, string token)
        {
            InitializeComponent();
            lblname.Text = " Welcome Mr " + userName;
            lblToken.Text = token;
        }
    }
}