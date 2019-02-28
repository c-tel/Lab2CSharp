using Lab2Telizhenko.Models;
using Lab2Telizhenko.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab2Telizhenko.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainModel Model { get; private set; }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private string _chZodiac;
        public string ChineeseZodiac
        {
            get => _chZodiac;
            set
            {
                _chZodiac = value;
                OnPropertyChanged(nameof(ChineeseZodiac));
            }
        }

        private string _wZodiac;
        public string WestZodiac
        {
            get => _wZodiac;
            set
            {
                _wZodiac = value;
                OnPropertyChanged(nameof(WestZodiac));
            }
        }

        private Visibility _congratulationsVisibility;
        public Visibility CongratulationsVisibility
        {
            get => _congratulationsVisibility;
            set
            {
                _congratulationsVisibility = value;
                OnPropertyChanged(nameof(CongratulationsVisibility));
            }
        }
        public MainViewModel(Storage storage)
        {
            Model = new MainModel(storage);
            Model.UserDataChanged += AssignUserData;
        }

        private ICommand _backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand<object>(BackExecute, BackCanExecute);
                }
                return _backCommand;
            }
            set
            {
                _backCommand = value;
                OnPropertyChanged(nameof(BackCommand));
            }
        }

        private void AssignUserData(UserData userData)
        {
            Age = userData.Age;
            ChineeseZodiac = userData.ChineeseZodiac.ToString();
            WestZodiac = userData.WestZodiac.ToString();
            CongratulationsVisibility = userData.HasBirthday ? Visibility.Visible : Visibility.Collapsed;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool BackCanExecute(object obj)
        {
            return true;
        }

        private void BackExecute(object obj)
        {
            Model.Back();
        }
    }
}
