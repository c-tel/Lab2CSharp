using Lab2Telizhenko.Models;
using Lab2Telizhenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Lab2Telizhenko.ViewModels
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public WelcomeModel Model { get; private set; }
        private DateTime _dateOfBirth;
        private string _name;
        private string _surname;
        private string _email;
        private ICommand _submitFormCommand;

        public WelcomeViewModel(Storage storage)
        {
            Model = new WelcomeModel(storage);
            DateOfBirth = DateTime.Now;
        }

        #region FormData
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        #endregion

        public ICommand SubmitFormCommand
        {
            get
            {
                if (_submitFormCommand == null)
                {
                    _submitFormCommand = new RelayCommand<object>(SubmitFormExecute, SubmitFormCanExecute);
                }
                return _submitFormCommand;
            }
            set
            {
                _submitFormCommand = value;
                OnPropertyChanged(nameof(SubmitFormCommand));
            }
        }

        private bool SubmitFormCanExecute(object o)
        {
            return !string.IsNullOrEmpty(Name) &&
                !string.IsNullOrEmpty(Surname) &&
                !string.IsNullOrEmpty(Email);
        }

        private void SubmitFormExecute(object o)
        {
            try
            {
                Model.SubmitForm(DateOfBirth, Name, Surname, Email);
            }
            catch (FarBirthDateException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (FutureBirthDateException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (InvalidEmailException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
