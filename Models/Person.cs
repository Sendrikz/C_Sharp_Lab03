using System;
using System.Text.RegularExpressions;
using DateProject01.Exceptions;
using DateProject01.Tools;

namespace DateProject01.Models
{
    public class Person : BaseViewModel
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;

        public Person() { }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; OnPropertyChanged("Surname"); }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(value);
                if (match.Success)
                {
                    _email = value; OnPropertyChanged("Email");
                }
                else
                {
                    throw new InvalidFormatEmailException("Format of your email is wrong", value);
                }
                
            }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set
            {
                int _age = countAge(value);
                if (_age < 0)
                {
                    throw new BirthdateInFutureException("There was a mistake. You have not been born yet", _age);
                }
                else if (_age > 135)
                {
                    throw new BirthdateInPastException("There was a mistake. Your age is above 135", _age);
                }
                else
                {
                    _birthday = value; OnPropertyChanged("Birthday");
                }
            }
        }

        public Boolean IsAdult
        {
            get
            {
                if (countAge(Birthday) >= 18)
                    return true;
                return false;
            }
        }

        public string SunSign
        {
            get { return countSunSign(); }
        }

        public string ChineseSign
        {
            get { return countChineeseSign(); }
        }

        public Boolean IsBirthday
        {
            get
            {
                if (Birthday.Day == DateTime.Today.Day)
                    return true;
                return false;
            }
        }

        private string countChineeseSign()
        {
            System.Globalization.EastAsianLunisolarCalendar cc = new System.Globalization.ChineseLunisolarCalendar();
            int sexagenaryYear = cc.GetSexagenaryYear(Birthday);
            int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);

            string[] years = new string[] { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            return years[terrestrialBranch - 1];
        }

        private int countAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;

            return age;
        }

        private string countSunSign()
        {
            int moth = Birthday.Month;
            int day = Birthday.Day;
            switch (moth)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return "";
        }
    }
}
