using System;
using System.Threading.Tasks;
using DateProject01.Tools;
using DateProject01.Views;
using DateProject01.Models;
using DateProject01.Tools.Managers;
using System.Threading;
using System.Windows;
using DateProject01.Exceptions;

namespace DateProject01.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate;
        #endregion

        #region Commands

        #endregion

        #region Properties
        public DateTime Birthday
        {
            get { return _birthDate; }
            set { _birthDate = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        #endregion

        #region Functionality
        private int countAge()
        {
            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if (Birthday > today.AddYears(-age)) age--;

            return age;
        }
        #endregion

        #region Commands
        private RelayCommand<object> _signInCommand;

        public RelayCommand<object> RegisterCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(RegisterImpl,
                           o => !string.IsNullOrWhiteSpace(_name) &&
                                !string.IsNullOrWhiteSpace(_surname) &&
                                !string.IsNullOrWhiteSpace(_email)));
            }
        }

        private async void RegisterImpl(object o)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() => Thread.Sleep(1000));
            LoaderManager.Instance.HideLoader();
            
            Person person = null;

            await Task.Run((() =>
            {
                try
                {
                    person = new Person(_name, _surname, _email, _birthDate);
                }
                catch (InvalidFormatEmailException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine($"Invalid value: {ex.Email}");
                }
                catch (BirthdateInFutureException ex1)
                {
                    Console.WriteLine($"Error: {ex1.Message}");
                    Console.WriteLine($"Invalid value: {ex1.Age}");
                }
                catch(BirthdateInPastException ex2)
                {
                    Console.WriteLine($"Error: {ex2.Message}");
                    Console.WriteLine($"Invalid value: {ex2.Age}");
                }
                }));

            PersonInfoWindow personInfoWindow = new PersonInfoWindow(person);
            personInfoWindow.Show();

        }
        #endregion

    }
}
