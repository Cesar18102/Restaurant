using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace Drivers {

    public partial class MainPage : ContentPage {

        public Regex mail_regex = new Regex("^[A-Za-z0-9]+(\\.[A-Za-z0-9]+)?@[a-z]+\\.[a-z]+$");
        public Regex password_regex = new Regex("^[A-Za-z0-9]{8,12}$");
        public SHA1 sha1 = new SHA1Managed();

        public MainPage() {

            InitializeComponent();
            Login.Clicked += Login_Clicked;

            Actions.Items.Add("Регистрация");
            Actions.Items.Add("Справка");
            Actions.Items.Add("Задать вопрос");

            Actions.SelectedIndexChanged += Actions_SelectedIndexChanged;
        }

        private void Actions_SelectedIndexChanged(object sender, EventArgs e) {

            switch((sender as Picker).SelectedIndex) {

                case 0:
                    Application.Current.MainPage = new Registration(Mail.Text);
                    break;
                case 1:
                    Application.Current.MainPage = new Help();
                    break;
                case 2:
                    Application.Current.MainPage = new Question();
                    break;
            }
        }

        private void Login_Clicked(object sender, EventArgs e) {

            if (Mail.Text == null || !mail_regex.IsMatch(Mail.Text)) {
                
                DisplayAlert("Ошибка ввода!", "Некорректное значение e-mail", "Назад");
                return;
            }

            if (Password.Text == null || !password_regex.IsMatch(Password.Text)) {

                DisplayAlert("Ошибка ввода!", "Некорректное значение пароля", "Назад");
                return;
            }

            string queryUserMail = "query=SELECT COUNT(id) AS count FROM driver WHERE mail='" + Mail.Text + "';&pas=Delishes228";
            if (Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, queryUserMail))[0].count == 0) {

                DisplayAlert("Ошибка!", "Пользователя с таким e-mail не существует!", "Назад");
                return;
            }

            string pas_sha1 = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(Password.Text))).Replace("-", "");
            string queryUserPassword = "query=SELECT IF(password = '" + pas_sha1 + "', 1, 0) AS count FROM driver WHERE mail='" + Mail.Text + "';&pas=Delishes228";
            if (Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, queryUserPassword))[0].count == 0) {

                DisplayAlert("Ошибка!", "Неверный пароль!", "Назад");
                return;
            }

            string queryUserInfo = "query=SELECT * FROM driver WHERE mail='" + Mail.Text + "';&pas=Delishes228";
            Driver driver = Server.ParseQuery<Driver>(Server.PostQuery(Constants.QueryURL, queryUserInfo))[0];
            Application.Current.MainPage = new Offers(driver);
        }
    }
}
