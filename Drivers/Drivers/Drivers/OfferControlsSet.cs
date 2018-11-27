using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Drivers {

    public class OfferControlsSet {

        public delegate void ProduceAlert(string title, string message, string cancel);
        public event ProduceAlert Alert;

        public int OfferId { get; private set; }
        public int DriverId { get; private set; }

        public Button TakeOffer { get; private set; }
        public Entry SecretCode { get; private set; }
        public Button Confirm { get; private set; }
        public Button Reject { get; private set; }

        public Regex secure = new Regex("^[0-9]{4}$");

        public OfferControlsSet(int id, int driver_id, string takeText, string secretPlaceholder, string confirmText, string rejectText, bool my) {

            OfferId = id;
            DriverId = driver_id;

            TakeOffer = new Button();
            TakeOffer.Clicked += TakeOffer_Clicked;
            TakeOffer.Text = takeText;
            TakeOffer.IsVisible = !my;

            SecretCode = new Entry();
            SecretCode.Placeholder = secretPlaceholder;
            SecretCode.Keyboard = Keyboard.Numeric;
            SecretCode.IsVisible = my;

            Confirm = new Button();
            Confirm.Clicked += Confirm_Clicked;
            Confirm.Text = confirmText;
            Confirm.IsVisible = my;

            Reject = new Button();
            Reject.Clicked += Reject_Clicked;
            Reject.Text = rejectText;
            Reject.IsVisible = my;
        }

        private void Reject_Clicked(object sender, EventArgs e) {
            ToggleVisibility();

            string queryDeleteDriverOffer = "query=DELETE FROM driver_offer WHERE offer_id = " + OfferId + " AND driver_id = " + DriverId + ";&pas=Delishes228";
            Server.PostQuery(Constants.QueryURL, queryDeleteDriverOffer);

            string queryUpdateStates = "query=UPDATE offered_meal SET state_id = 3 WHERE offer_id = " + OfferId + ";&pas=Delishes228";
            Server.PostQuery(Constants.QueryURL, queryUpdateStates);

            if (Alert != null)
                Alert.Invoke("Клиент ждет...", "Вы отменили заказ", "ОК"); // КПД--
        }

        private void Confirm_Clicked(object sender, EventArgs e) {

            if(SecretCode.Text == null || !secure.IsMatch(SecretCode.Text)) {

                if(Alert != null)
                    Alert("Ошибка!", "Некорректный секретный код", "Назад");
                return;
            }

            string queryGetSecureOK = "query=SELECT IF(secure_code = " + SecretCode.Text + ", 1, 0) AS count FROM offer WHERE id = " + OfferId + ";&pas=Delishes228";
            bool OK = Server.ParseQuery<Counts>(Server.PostQuery(Constants.QueryURL, queryGetSecureOK))[0].count == 1;

            if(OK) {

                string queryUpdateStates = "query=UPDATE offered_meal SET state_id = 5 WHERE offer_id = " + OfferId + ";&pas=Delishes228";
                Server.PostQuery(Constants.QueryURL, queryUpdateStates);

                if (Alert != null)
                    Alert.Invoke("Отлично!", "Заказ успешно доставлен!", "ОК"); // КПД++
            }
            else {

                if (Alert != null)
                    Alert.Invoke("Ошибка!", "Неверный секретный код!", "ОК"); 
                return;
            }
        }

        private void TakeOffer_Clicked(object sender, EventArgs e)
        {
            ToggleVisibility();

            string queryInsertDriverOffer = "query=INSERT INTO driver_offer VALUES(" + OfferId + ", " + DriverId + ");&pas=Delishes228";
            Server.PostQuery(Constants.QueryURL, queryInsertDriverOffer);

            string queryUpdateStates = "query=UPDATE offered_meal SET state_id = 4 WHERE offer_id = " + OfferId + ";&pas=Delishes228";
            Server.PostQuery(Constants.QueryURL, queryUpdateStates);

            if (Alert != null)
                Alert.Invoke("Появилась работа", "Заказ принят!", "ОК");
        }

        public void ToggleVisibility() {

            TakeOffer.IsVisible = !TakeOffer.IsVisible;
            SecretCode.IsVisible = !SecretCode.IsVisible;
            Confirm.IsVisible = !Confirm.IsVisible;
            Reject.IsVisible = !Reject.IsVisible;
        }
    }
}
