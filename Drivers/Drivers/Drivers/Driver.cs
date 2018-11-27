using System;
using System.Collections.Generic;
using System.Text;

namespace Drivers {

    public class Driver : IParseble {

        public int id;
        public string name;
        public string surname;
        public string fathername;
        public DateTime birth;
        public string passport_id;
        public string passport_seria;
        public string car_model;
        public string car_id;
        public string mail;
        public float KPD;

        public Driver() { }
    }
}
