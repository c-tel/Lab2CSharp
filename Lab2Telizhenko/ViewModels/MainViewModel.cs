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


        #region LABELS
        private string _nameLabel;
        public string NameLabel
        {
            get => _nameLabel;
            set
            {
                _nameLabel = value;
                OnPropertyChanged(nameof(NameLabel));
            }
        }

        private string _surnameLabel;
        public string SurnameLabel
        {
            get => _surnameLabel;
            set
            {
                _surnameLabel = value;
                OnPropertyChanged(nameof(SurnameLabel));
            }
        }

        private string _emailLabel;
        public string EmailLabel
        {
            get => _emailLabel;
            set
            {
                _emailLabel = value;
                OnPropertyChanged(nameof(EmailLabel));
            }
        }

        private string _birthDateLabel;
        public string BirthDateLabel
        {
            get => _birthDateLabel;
            set
            {
                _birthDateLabel = value;
                OnPropertyChanged(nameof(BirthDateLabel));
            }
        }

        private string _isAdultLabel;
        public string IsAdultLabel
        {
            get => _isAdultLabel;
            set
            {
                _isAdultLabel = value;
                OnPropertyChanged(nameof(IsAdultLabel));
            }
        }

        private string _chZodiacLabel;
        public string ChineeseZodiacLabel
        {
            get => _chZodiacLabel;
            set
            {
                _chZodiacLabel = value;
                OnPropertyChanged(nameof(ChineeseZodiacLabel));
            }
        }

        private string _wZodiacLabel;
        public string WestZodiacLabel
        {
            get => _wZodiacLabel;
            set
            {
                _wZodiacLabel = value;
                OnPropertyChanged(nameof(WestZodiacLabel));
            }
        }

        #endregion

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
            Model.PersonChanged += AssignUserData;
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

        private void AssignUserData(Person userData)
        {
            NameLabel = $"Person name: {userData.Name}";
            SurnameLabel = $"Person surname: {userData.Surname}";
            EmailLabel = $"Person email: {userData.Email}";
            BirthDateLabel = $"Person birthdate: {userData.BirthDate.ToString("dd-MM-yyyy")}";
            ChineeseZodiacLabel = $"Person sun sign: {userData.SunSign.ToString()}";
            WestZodiacLabel = $"Person sun sign: {userData.WestZodiac.ToString()}";
            IsAdultLabel = $"Person is {(userData.IsAdult ? "an" : "not an")} adult";
            CongratulationsVisibility = userData.IsBirthday ? Visibility.Visible : Visibility.Collapsed;
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
