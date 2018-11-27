using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drivers {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Help : ContentPage {

		public Help () {

			InitializeComponent ();

            Actions.Items.Add("Регистрация");
            Actions.Items.Add("Вход");
            Actions.Items.Add("Задать вопрос");

            Actions.SelectedIndexChanged += Actions_SelectedIndexChanged;
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
                    Application.Current.MainPage = new Question();
                    break;
            }
        }
    }
}