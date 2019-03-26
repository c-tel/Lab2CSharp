using Lab2Telizhenko.Models;
using Lab2Telizhenko.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Lab2Telizhenko.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainModel Model { get; private set; }
        private ObservableCollection<Person> _sortedAndFiltteredPeople;
        public ObservableCollection<Person> SortedAndFilteredPeople
        {
            get => _sortedAndFiltteredPeople;
            set
            {
                _sortedAndFiltteredPeople = value;
                OnPropertyChanged(nameof(SortedAndFilteredPeople));
            }
        }
        #region SelectedPerson
        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
                OnPersonSelected();
            }
        }
        public string _selectedPersName;

        public string SelectedPersName
        {
            get => _selectedPersName;
            set
            {
                _selectedPersName = value;
                OnPropertyChanged(nameof(SelectedPersName));
            }
        }

        public string _selectedPersSurname;

        public string SelectedPersSurname
        {
            get => _selectedPersSurname;
            set
            {
                _selectedPersSurname = value;
                OnPropertyChanged(nameof(SelectedPersSurname));
            }
        }

        private void OnPersonSelected()
        {
            SelectedPersName = SelectedPerson?.Name;
            SelectedPersSurname = SelectedPerson?.Surname;
            PersonEditorVisibility = SelectedPerson != null ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion


        #region ViewParams
        public List<string> _sortingParameters;

        public List<string> SortingParameters
        {
            get => _sortingParameters;
            set
            {
                _sortingParameters = value;
                OnPropertyChanged(nameof(SortingParameters));
            }
        }

        public string SelectedSortingParam { get; set; }
        public string Filter { get; set; }

        private void OnViewParamsChanged()
        {
            IEnumerable<Person> nextPeople = Model.CurrentPeople();
            if (!string.IsNullOrEmpty(Filter))
            {
                nextPeople = nextPeople.Where(p =>
                $"{p.Name} {p.Surname} {p.SunSign} {p.WestZodiac}"
                    .ToLower()
                    .Contains(Filter.ToLower()));
            }
            if(!string.IsNullOrEmpty(SelectedSortingParam))
            {
                switch(SelectedSortingParam)
                {
                    case "Name":
                        nextPeople = nextPeople.OrderBy(p => p.Name);
                        break;
                    case "Surname":
                        nextPeople = nextPeople.OrderBy(p => p.Surname);
                        break;
                    case "Email":
                        nextPeople = nextPeople.OrderBy(p => p.Email);
                        break;
                    case "Date of birth":
                        nextPeople = nextPeople.OrderBy(p => p.BirthDate);
                        break;
                }
            }
            SortedAndFilteredPeople = new ObservableCollection<Person>(nextPeople);
        }

        #endregion

        public MainViewModel(Storage storage)
        {
            Model = new MainModel(storage);
            Model.PeopleChanged += AssignPeople;
            Model.RefreshPeople();
            PersonEditorVisibility = Visibility.Collapsed;
            SortingParameters = new List<string> { "Name", "Surname", "Email", "Date of birth" };
        }

        private ICommand _applyParamsCommand;
        public ICommand ApplyParamsCommand
        {
            get
            {
                if (_applyParamsCommand == null)
                {
                    _applyParamsCommand = new RelayCommand<object>(ApplyParamsExecute, ApplyParamsCanExecute);
                }
                return _applyParamsCommand;
            }
            set
            {
                _applyParamsCommand = value;
                OnPropertyChanged(nameof(ApplyParamsCommand));
            }
        }

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand<object>(RemoveExecute, RemoveCanExecute);
                }
                return _removeCommand;
            }
            set
            {
                _removeCommand = value;
                OnPropertyChanged(nameof(RemoveCommand));
            }
        }

        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new RelayCommand<object>(EditExecute, EditCanExecute);
                }
                return _editCommand;
            }
            set
            {
                _editCommand = value;
                OnPropertyChanged(nameof(EditCommand));
            }
        }

        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand<object>(AddExecute, AddCanExecute);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
                OnPropertyChanged(nameof(AddCommand));
            }
        }

        private Visibility _personEditorVisibility;
        public Visibility PersonEditorVisibility
        {
            get
            {
                return _personEditorVisibility;
            }
            set
            {
                _personEditorVisibility = value;
                OnPropertyChanged(nameof(PersonEditorVisibility));
            }
        }
        private void AssignPeople(List<Person> people)
        {
            OnViewParamsChanged();
        }

        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private bool ApplyParamsCanExecute(object obj)
        {
            return true;
        }

        private void ApplyParamsExecute(object obj)
        {
            OnViewParamsChanged();
        }

        private bool RemoveCanExecute(object obj)
        {
            return SelectedPerson != null;
        }

        private void RemoveExecute(object obj)
        {
            Model.Remove(SelectedPerson);
        }

        private bool EditCanExecute(object obj)
        {
            return SelectedPerson != null && !string.IsNullOrEmpty(SelectedPersName) && !string.IsNullOrEmpty(SelectedPersSurname);
        }

        private void EditExecute(object obj)
        {
            Model.Edit(SelectedPerson, SelectedPersName, SelectedPersSurname);
        }

        private bool AddCanExecute(object obj)
        {
            return true;
        }

        private void AddExecute(object obj)
        {
            Model.AddPerson();
        }
    }
}
