using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LogBook.Lib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            var entries = _repository.GetAll();

            foreach(var entry in entries)
            {
                Entries.Add(entry);
            }
        }

        [RelayCommand]
        void Add()
        {
            LogBook.Lib.Entry entrySaalfelden = new(
                DateTime.Now.AddDays(3),
                DateTime.Now.AddDays(3).AddMinutes(20), 25500, 25514,
                "Ze-XY123", "Zell am See", "Saalfelden")
            {
                Description = "Fahrt nach Saalfelden"
            };

            var result = _repository.Add(entrySaalfelden);
            if(result)
            {
                this.Entries.Add(entrySaalfelden);
            }
        }
    }
}
