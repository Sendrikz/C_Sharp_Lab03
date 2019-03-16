using DateProject01.Models;
using DateProject01.ViewModels;
using System;
using System.Windows;

namespace DateProject01.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public PersonInfoWindow(Person person)
        {
            InitializeComponent();
            DataContext = new PersonInfoViewModel(person);
        }
        
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}
