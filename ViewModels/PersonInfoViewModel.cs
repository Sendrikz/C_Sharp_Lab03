using DateProject01.Models;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DateProject01.ViewModels
{
    class PersonInfoViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Person _person;
        
        public string Name => $"{_person.Name}";
        public string Surname => $"{_person.Surname}";
        public string Email => $"{_person.Email}";
        public string BirthDate => $"{_person.Birthday.ToShortDateString()}";
        public string SunSign => $"{_person.SunSign}";
        public string ChineseSign => $"{_person.ChineseSign}";
        public string IsBirthday => $"{(_person.IsBirthday ? "Congratulations! Today is your birthday." : "Today is not your birthday :(")}";
        public string IsAdult => $"{(_person.IsAdult)}";
        #endregion

        public PersonInfoViewModel(Person person)
        {
            _person = person;
        }

        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
