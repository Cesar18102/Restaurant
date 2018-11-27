using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drivers {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Question : ContentPage {

        public Regex mail_regex = new Regex("^[A-Za-z0-9]+(\\.[A-Za-z0-9]+)?@[a-z]+\\.[a-z]+$");

        public Question () {

			InitializeComponent ();

            Actions.Items.Add("Регистрация");
            Actions.Items.Add("Вход");
            Actions.Items.Add("Справка");

            Actions.SelectedIndexChanged += Actions_SelectedIndexChanged;

            Confirm.Clicked += Confirm_Clicked;
        }

        private void Confirm_Clicked(object sender, EventArgs e) {

            if(Mail.Text == null || !mail_regex.IsMatch(Mail.Text)) {

                DisplayAlert("Ошибка!", "Вы ввели некорректный e-mail", "ОК");
                return;
            }

            if(Quest.Text == null || Quest.Text.Length == 0) {

                DisplayAlert("Ну зачем же?!", "У нас итак немало работы. Пожалуйста, не волнуйте нас напрасно.", "Извините");
                return;
            }

            Server.PostQuery(Constants.QueryMailURL, "mail=jewelfiltermarket@gmail.com&text=;;;**********;Вопрос от пользователя********От: " + Mail.Text + ";Вопрос: " + Quest.Text);
            DisplayAlert("Вы задали вопрос!", "Мы ответим на Ваш вопрос в течение нескольких рабочих дней", "ОК");
        }

        public Question(string mail) : this() {

            Mail.Text = mail;
        }

        private void Actions_SelectedIndexChanged(object sender, EventArgs e) {

            switch ((sender as Picker).SelectedIndex) {

                case 0:
                    Application.Current.MainPage = new Registration();
                    break;
                case 1:
                    Application.Current.MainPage = new MainPage();
                    break;
                case 2:
                    Application.Current.MainPage = new Help();
                    break;
            }
        }
    }
}