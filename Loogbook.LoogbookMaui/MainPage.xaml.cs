﻿using Loogbook.LoogbookCore.ViewModel;

namespace Loogbook.LoogbookMaui
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;

        }

       
    }

}
