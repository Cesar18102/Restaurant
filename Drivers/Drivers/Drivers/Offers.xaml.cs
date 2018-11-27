using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drivers {

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Offers : ContentPage {

        private Driver user;

		public Offers (Driver driver) {

			InitializeComponent ();
            user = driver;
            userInfo.Text = user.surname + " " + user.name + " " + user.fathername + "\n" + user.mail + "\nID: " + user.id;

            Actions.Items.Add("Справка");
            Actions.Items.Add("Задать вопрос");

            Actions.SelectedIndexChanged += Actions_SelectedIndexChanged;

            updateOffers();
            Device.StartTimer(new TimeSpan(0, 0, 5), updateOffers);
        }

        private void Actions_SelectedIndexChanged(object sender, EventArgs e) {

            switch ((sender as Picker).SelectedIndex) {

                case 0:
                    Application.Current.MainPage = new Help();
                    break;
                case 1:
                    Application.Current.MainPage = new Question(user.mail);
                    break;
            }
        }

        public Offers() { }

        public bool updateOffers() {

            int OfferCount = 0;

            string queryOffers = "query=SELECT O.id, O.name, O.surname, O.phone, O.city, O.avenue, O.building, O.flat, O.comment, O.total_price, COUNT(OM.id) AS all_parts, parts_to_deliver " +
                                       "FROM offer O, offered_meal OM, (" +
                                                      "SELECT offer_id, COUNT(id) parts_to_deliver " +
                                                      "FROM offered_meal " +
                                                      "WHERE state_id = 3 OR state_id = 4 " +
                                                      "GROUP BY offer_id) TD " +
                                       "WHERE TD.offer_id = OM.offer_id AND OM.offer_id = O.id " +
                                       "GROUP BY OM.offer_id " +
                                       "HAVING all_parts = TD.parts_to_deliver;&pas=Delishes228";

            List<Offer> offers_list = Server.ParseQuery<Offer>(Server.PostQuery(Constants.QueryURL, queryOffers));

            if (offers_list != null) {

                offers.Clear();

                foreach (Offer offer in offers_list) {

                    int driver_id = Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, "query=SELECT IF(COUNT(offer_id) = 1, driver_id, -1) AS count FROM driver_offer WHERE offer_id=" + offer.id + ";&pas=Delishes228"))[0].count;

                    if (driver_id == -1 || driver_id == user.id) {

                        TableSection row = new TableSection("Заказ ID: " + offer.id);

                        TextCell clientName = new TextCell();
                        clientName.Detail = "Клиент: " + offer.surname + " " + offer.name;
                        row.Add(clientName);

                        TextCell address = new TextCell();
                        address.Detail = "Адрес: г." + offer.city + ", " + offer.avenue + ", д." + offer.building + ", кв." + offer.flat;
                        row.Add(address);

                        TextCell phone = new TextCell();
                        phone.Detail = "Телефон: " + offer.phone;
                        row.Add(phone);

                        TextCell comment = new TextCell();
                        comment.Detail = "Комментарий: " + offer.comment;
                        row.Add(comment);

                        TextCell price = new TextCell();
                        price.Detail = "Цена: " + offer.total_price + " грн.";
                        row.Add(price);

                        OfferControlsSet controlsSet = new OfferControlsSet(offer.id, user.id, "Выполнить", "Секретный код клиента", "Готово", "Отменить", driver_id == user.id);

                        ViewCell TVC = new ViewCell();
                        TVC.View = controlsSet.TakeOffer;
                        row.Add(TVC);

                        ViewCell SVC = new ViewCell();
                        SVC.View = controlsSet.SecretCode;
                        row.Add(SVC);

                        ViewCell CVC = new ViewCell();
                        CVC.View = controlsSet.Confirm;
                        row.Add(CVC);

                        ViewCell RVC = new ViewCell();
                        RVC.View = controlsSet.Reject;
                        row.Add(RVC);

                        controlsSet.Alert += ControlsSet_Alert;

                        offers.Add(row);
                        OfferCount++;
                    }
                }
            }

            layout.HeightRequest = OfferCount * 750;

            return true;
        }

        private void ControlsSet_Alert(string title, string message, string cancel) {

            DisplayAlert(title, message, cancel);
        }
    }
}