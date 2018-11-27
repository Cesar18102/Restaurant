using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drivers {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registration : ContentPage {

        public Regex old_pas_id = new Regex("^[0-9]{6}$");
        public Regex old_pas_ser = new Regex("^[А-Я]{2}$");
        public Regex new_pas_id = new Regex("^[0-9]{9}$");
        public Regex mail_regex = new Regex("^[A-Za-z0-9]+(\\.[A-Za-z0-9]+)?@[a-z]+\\.[a-z]+$");
        public Regex password_regex = new Regex("^[A-Za-z0-9]{8,12}$");
        public Regex car_id_regex = new Regex("[ABEKMHOPCTYX]{2}[0-9]{4}[ABEKMHOPCTYX]{2}");

        public delegate bool Valid();
        public delegate string Modifier(View entry);

        private View[] entries;
        private Valid[] predicates;
        private Modifier[] modifiers;

        public SHA1 sha1 = new SHA1Managed(); 

        public Registration() {

            InitializeComponent();
            Confirm.Clicked += Confirm_Clicked;

            Actions.Items.Add("Вход");
            Actions.Items.Add("Справка");
            Actions.Items.Add("Задать вопрос");

            Actions.SelectedIndexChanged += Actions_SelectedIndexChanged;

            entries = new View[] {

                Nm, SrNm, FthrNm, BrthDt, PID, PS,
                CM, CID, Mail, Pass, PassCheck
            };

            predicates = new Valid[] {

                () => Nm.Text != null && Nm.Text.Length <= 20,
                () => SrNm.Text != null && SrNm.Text.Length <= 30,
                () => FthrNm.Text == null || FthrNm.Text.Length <= 20,
                () => BrthDt.Date.AddYears(18) <= DateTime.Now,
                () => (PID.Text != null && (PS.Text == null || PS.Text == "") && (new_pas_id.IsMatch(PID.Text))) || (PS.Text != null && PID.Text != null && old_pas_id.IsMatch(PID.Text) && old_pas_ser.IsMatch(PS.Text.ToUpper())),
                () => (PID.Text != null && (PS.Text == null || PS.Text == "") && (new_pas_id.IsMatch(PID.Text))) || (PS.Text != null && PID.Text != null && old_pas_id.IsMatch(PID.Text) && old_pas_ser.IsMatch(PS.Text.ToUpper())),
                () => CM.Text != null && CM.Text.Length <= 20,
                () => CID.Text != null && car_id_regex.IsMatch(CID.Text.ToUpper()),
                () => Mail.Text != null && mail_regex.IsMatch(Mail.Text),
                () => Pass.Text != null && password_regex.IsMatch(Pass.Text),
                () => PassCheck.Text != null && Pass.Text != null && Pass.Text == PassCheck.Text
            };

            modifiers = new Modifier[] {

                (en) => (en as Entry).Text.Substring(0, 1).ToUpper() + (en as Entry).Text.Substring(1),
                (en) => (en as Entry).Text.Substring(0, 1).ToUpper() + (en as Entry).Text.Substring(1),
                (en) => (en as Entry).Text == null || (en as Entry).Text == ""? "" : ((en as Entry).Text.Substring(0, 1).ToUpper() + (en as Entry).Text.Substring(1)),
                (en) => (en as DatePicker).Date.Year + "-" + (en as DatePicker).Date.Month + "-" + (en as DatePicker).Date.Day,
                (en) => (en as Entry).Text,
                (en) => (en as Entry).Text == null? "" : (en as Entry).Text.ToUpper(),
                (en) => (en as Entry).Text,
                (en) => (en as Entry).Text.ToUpper(),
                (en) => (en as Entry).Text,
                (en) => BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes((en as Entry).Text))).Replace("-", "")
            };
        }

        private void Actions_SelectedIndexChanged(object sender, EventArgs e) {

            switch ((sender as Picker).SelectedIndex) {

                case 0:
                    Application.Current.MainPage = new MainPage();
                    break;
                case 1:
                    Application.Current.MainPage = new Help();
                    break;
                case 2:
                    Application.Current.MainPage = new Question();
                    break;
            }
        }

        public Registration(string mail) : this() {

            Mail.Text = mail;
		}

        private void Confirm_Clicked(object sender, EventArgs e) {

            bool isValid = ValidateForm(entries, predicates);

            if (isValid) {

                string queryNewUser = "query=SELECT COUNT(id) AS count FROM driver WHERE passport_id='" + PID.Text + "' AND passport_seria='" + (PS.Text == null ? "" : PS.Text.ToUpper()) + "';&pas=Delishes228";
                if(Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, queryNewUser))[0].count != 0) {

                    DisplayAlert("Ошибка регистрации!", "Пользователь с такими паспортными данными уже существует", "Назад");
                    return;
                }

                string queryNewUserMail = "query=SELECT COUNT(id) AS count FROM driver WHERE mail='" + Mail.Text + "';&pas=Delishes228";
                if (Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, queryNewUserMail))[0].count != 0) {

                    DisplayAlert("Ошибка регистрации!", "Пользователь с таким e-mail уже существует", "Назад");
                    return;
                }

                string queryNewUserCarID = "query=SELECT COUNT(id) AS count FROM driver WHERE car_id='" + CID.Text.ToUpper() + "';&pas=Delishes228";
                if (Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, queryNewUserCarID))[0].count != 0) {

                    DisplayAlert("Ошибка регистрации!", "Пользователь с таким номером машины уже существует", "Назад");
                    return;
                }

                string query = "query=INSERT INTO driver VALUES(0,";
                for (int i = 0; i < entries.Length - 1; i++)
                    query += "'" + modifiers[i].Invoke(entries[i]) + "',";
                query += "0.0);&pas=Delishes228";
                Server.PostQuery(Constants.QueryURL, query);

                Server.PostQuery(Constants.QueryMailURL, "mail=" + Mail.Text + "&text=;Ваш логин: " + Mail.Text + ";Ваш пароль: " + Pass.Text + ";Будем рады сотрудничать!");

                DisplayAlert("Регистрация успешна!", "Письмо со ссылкой для активации аккаунта отправлено на Ваш e-mail", "ОК");
                Application.Current.MainPage = new MainPage();
            }
        }

        private bool ValidateForm(View[] views, Valid[] valids) {

            bool valid = true;
            for (int i = 0; i < views.Length && i < valids.Length; i++)
                if (!valids[i].Invoke()) {

                    valid = false;
                    views[i].BackgroundColor = Color.Red;
                }
                else
                    views[i].BackgroundColor = Color.Green;

            return valid;
        }
    }
}