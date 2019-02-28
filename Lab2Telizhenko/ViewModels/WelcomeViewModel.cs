using Lab2Telizhenko.Models;
using Lab2Telizhenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Lab2Telizhenko.ViewModels
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public WelcomeModel Model { get; private set; }
        private DateTime _dateOfBirth;
        private ICommand _submitDateOfBirthCommand;

        public WelcomeViewModel(Storage storage)
        {
            Model = new WelcomeModel(storage);
            DateOfBirth = DateTime.Now;
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public ICommand SubmitDateOfBirthCommand
        {
            get
            {
                if (_submitDateOfBirthCommand == null)
                {
                    _submitDateOfBirthCommand = new RelayCommand<object>(SubmitDateOfBirthExecute, SubmitDateOfBirthCanExecute);
                }
                return _submitDateOfBirthCommand;
            }
            set
            {
                _submitDateOfBirthCommand = value;
                OnPropertyChanged(nameof(SubmitDateOfBirthCommand));
            }
        }

        private bool SubmitDateOfBirthCanExecute(object o)
        {
            return true;
        }

        private void SubmitDateOfBirthExecute(object o)
        {
            Model.SubmitDateOfBirth(DateOfBirth);
        }

        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
