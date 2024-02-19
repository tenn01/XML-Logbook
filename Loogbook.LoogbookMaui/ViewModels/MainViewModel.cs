using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loogbook.LoogbookMaui.ViewModel
{
    public partial class  MainViewModel(Irepository repository) : ObservableObject
    {
        public string Header => "Fahrtenbuch";
        Irepository _repository = repository;

        [ObservableProperty]
        ObservableCollection<LogBook.Lib.Entry> _entries = [];


        [RelayCommand]
        void LoadData()
        {

        }
    }
}
