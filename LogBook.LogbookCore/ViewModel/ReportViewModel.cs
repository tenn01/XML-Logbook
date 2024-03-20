using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LogBook.Lib;
using LogBook.LogbookCore.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.LogbookCore.ViewModel
{
    public partial class ReportViewModel : ObservableObject
    {
        Irepository _repository;

        public ReportViewModel(Irepository repository)
        { 
            _repository = repository;

            WeakReferenceMessenger.Default.Register<AddMessage>(this, (r,m) =>
            {
                // m.Value: user Entry-Objekt
                System.Diagnostics.Debug.WriteLine(m.Value);

                // add to list
                this.Entries.Add(m.Value);
            });
        }

        private bool _isLoaded = false;
        [ObservableProperty]
        ObservableCollection<LogBook.Lib.Entry> _entries = [];

        [RelayCommand]
        void LoadData()
        {
            // Entries.Clear();

            if (!_isLoaded)
            {


                var entries = _repository.GetAll();

                foreach (var entry in entries)
                {
                    Entries.Add(entry);
                }

                _isLoaded = true;
            }
        }
    }
}
