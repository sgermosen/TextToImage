using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamFormsMobileApp
{
   public class BaseViewModel:ViewModelBase
    {
        private string _selectedTextColor;
        public string SelectedTextColor
        {
            get => _selectedTextColor;
            set
            {
                _selectedTextColor = value;
                RaisePropertyChanged();
            }
        }


        private string _notes;
        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                RaisePropertyChanged();
            }
        }
    }
}
