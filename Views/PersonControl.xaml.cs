using DateProject01.ViewModels;
using System.Windows.Controls;

namespace DateProject01.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonControl.xaml
    /// </summary>
    public partial class PersonControl : UserControl
    {
        public PersonControl()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }
}
