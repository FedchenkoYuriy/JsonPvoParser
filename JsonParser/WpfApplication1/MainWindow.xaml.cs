using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JsonParser;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string directoryPath;
        IEnumerable<Group> groups;
        IEnumerable<User> users;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                //Путь к папке с файлами груп и пользователей
                directoryPath = System.IO.Path.GetDirectoryName(openFileDialog.FileName)+@"\";
                //Заргужаем групы по пути полученым из OpenDialog
                groups = GroupRepository.GetInstance(openFileDialog.FileName).GetGroups();
                //Отделяем дату файла груп для открытия файла с пользователями с такой же датой
                string[] stringDate = openFileDialog.FileName.Split(new Char[] { '_'});
                //Создаем путь для файла с датой аналогичной с групами  (Делать ли тут проверку на существующий файл?)
                string userPath = directoryPath + "users_" + stringDate[1];
                //Загружаем пользователей из файла с датой аналогичной групам
                users = UserRepository.GetInstance(userPath).GetUsers();       
                // Проверка выполлнения                
                txtEditor.Text = "Groups: " + groups.Count().ToString()+" Users: " + users.Count().ToString();
                //txtEditor.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                
            }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //Сохранение и удаление ненужных бэкапов по закрытии (дореализовать)
            FileUtils.Save(groups, users, directoryPath, DateTime.Now);

            base.OnClosing(e);
        }
    }
}
