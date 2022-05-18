using Microsoft.EntityFrameworkCore;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBusProject.Data.Concrete
{
  public static  class SeedDataBase
    {
        public static void Seed()
        {
            var context = new MyBusProjectContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Busses.Count() == 0)
                {
                    context.Busses.AddRange(Busses);
                }
                if (context.Passengers.Count() == 0)
                {
                    context.Passengers.AddRange(Passengers);
                }
                if (context.Routes.Count() == 0)
                {
                    context.Routes.AddRange(Routes);
                }
                if (context.Tickets.Count() == 0)
                {
                    context.Tickets.AddRange(Tickets);
                }
                if (context.Voyages.Count() == 0)
                {
                    context.Voyages.AddRange(Voyages);
                }
                if (context.Stations.Count() == 0)
                {
                    context.Stations.AddRange(Stations);
                }
                if (context.Cities.Count()==0)
                {
                    context.Cities.AddRange(Cities);
                }
            }
            context.SaveChanges();
        }
        private static Bus[] Busses =
        {
            new Bus() {Name="Mercedes-Travego",SeatCount=45,IsActive=true},
            new Bus() {Name="Mercedes-Tourismo",SeatCount=43,IsActive=true},
            new Bus() {Name="Mercedes-Intouro",SeatCount=50,IsActive=true},
            new Bus() {Name="Temsa-Prenses",SeatCount=56,IsActive=true},
            new Bus() {Name="Temsa-Safir",SeatCount=66,IsActive=true},
            new Bus() {Name="Temsa-Avenue",SeatCount=72,IsActive=false},
            new Bus() {Name="Man-Lion's Coach",SeatCount=56,IsActive=true},
            new Bus() {Name="Otokar-Vectio T",SeatCount=58,IsActive=false},
            new Bus() {Name="Temsa-Metropol",SeatCount=44,IsActive=true},
        };
        private static Passenger[] Passengers =
        {
         new Passenger() {Name="Serhan",Surname="ORHAN",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Ali",Surname="Kamber",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Veli",Surname="Kamiloğlu",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Mehmet",Surname="Yılmaz",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Kadir",Surname="Pazarcı",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Ayşe",Surname="Kadıoglu",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Büşra",Surname="Türe",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},
         new Passenger() {Name="Melek",Surname="Deniz",IdentityNo="35678915562",Phone="05379879890",Email="serhan__orhan@hotmail.com",BirthDay="1950-01-01"},

        };
        private static Route[] Routes =
        {
            new Route() {Name="İstanbul",Cordinate="500",Type="Otobüs"},
            new Route() {Name="İzmir",Cordinate="675",Type="Otobüs"},
            new Route() {Name="Bursa",Cordinate="456",Type="Otobüs"},
            new Route() {Name="Ankara",Cordinate="567",Type="Otobüs"},
            new Route() {Name="Karabük",Cordinate="456",Type="Otobüs"},
            new Route() {Name="Balıkesir",Cordinate="497",Type="Otobüs"},
            new Route() {Name="Çorum",Cordinate="503",Type="Otobüs"},
        };
        private static Ticket[] Tickets =
        {
            new Ticket() {Date="1965-12-25",Price=25.30,BusId=1,PassengerId=2},
            new Ticket() {Date="1961-10-25",Price=240.30,BusId=2,PassengerId=1},
            new Ticket() {Date="1965-09-11",Price=225.30,BusId=1,PassengerId=7},
            new Ticket() {Date="1995-07-25",Price=215.30,BusId=5,PassengerId=5},
            new Ticket() {Date="1935-01-25",Price=225.30,BusId=8,PassengerId=3},
            new Ticket() {Date="1965-03-22",Price=245.30,BusId=3,PassengerId=4},
            new Ticket() {Date="1965-08-01",Price=235.30,BusId=7,PassengerId=8},
        };
        private static Voyage[] Voyages =
        {
            new Voyage() {StartRoute="İstanbul",EndRoute="İzmir",Price=50.5,BusId=9},
            new Voyage() {StartRoute="İzmir",EndRoute="Bursa",Price=70.5,BusId=1},
            new Voyage() {StartRoute="Ankara",EndRoute="İstanbul",Price=520.5,BusId=2},
            new Voyage() {StartRoute="Samsun",EndRoute="İstanbul",Price=530.5,BusId=3},
            new Voyage() {StartRoute="Amasya",EndRoute="Balıkesir",Price=510.5,BusId=4},
            new Voyage() {StartRoute="Tokat",EndRoute="Çorum",Price=508.5,BusId=6},
            new Voyage() {StartRoute="Sivas",EndRoute="Denizli",Price=504.5,BusId=7},
            new Voyage() {StartRoute="Yozgat",EndRoute="İzmir",Price=505.5,BusId=9},
        };
        private static Station[] Stations =
        {
            new Station() {VoyageId=1,RouteId=1},
            new Station() {VoyageId=2,RouteId=6},
            new Station() {VoyageId=3,RouteId=5},
            new Station() {VoyageId=4,RouteId=4},
            new Station() {VoyageId=5,RouteId=3},
            new Station() {VoyageId=6,RouteId=2},
        };
        private static City[] Cities =
        {
             new City() {Name="ADANA"},
             new City() {Name="ADIYAMAN"},
             new City() {Name="AFYON"},
             new City() {Name="AĞRI"},
             new City() {Name="AMASYA"},
             new City() {Name="ANKARA"},
             new City() {Name="ANTALYA"},
             new City() {Name="ARTVİN"},
             new City() {Name="AYDIN"},
             new City() {Name="BALIKESİR"},
             new City() {Name="BİLECİK"},
             new City() {Name="BİNGÖL"},
             new City() {Name="BİTLİS"},
             new City() {Name="BOLU"},
             new City() {Name="BURDUR"},
             new City() {Name="BURSA"},
             new City() {Name="ÇANAKKALE"},
             new City() {Name="ÇANKIRI"},
             new City() {Name="ÇORUM"},
             new City() {Name="DENİZLİ"},
             new City() {Name="DİYARBAKIR"},
             new City() {Name="EDİRNE"},
             new City() {Name="ELAZIĞ"},
             new City() {Name="ERZİNCAN"},
             new City() {Name="ERZURUM"},
             new City() {Name="ESKİŞEHİR"},
             new City() {Name="GAZİANTEP"},
             new City() {Name="GİRESUN"},
             new City() {Name="GÜMÜŞHANE"},
             new City() {Name="HAKKARİ"},
             new City() {Name="HATAY"},
             new City() {Name="ISPARTA"},
             new City() {Name="MERSİN"},
             new City() {Name="İSTANBUL"},
             new City() {Name="İZMİR"},
             new City() {Name="KARS"},
             new City() {Name="KASTAMONU"},
             new City() {Name="KAYSERİ"},
             new City() {Name="KIRKLARELİ"},
             new City() {Name="KIRŞEHİR"},
             new City() {Name="KOCAELİ"},
             new City() {Name="KONYA"},
             new City() {Name="KÜTAHYA"},
             new City() {Name="MALATYA"},
             new City() {Name="MANİSA"},
             new City() {Name="KAHRAMANMARAŞ"},
             new City() {Name="MARDİN"},
             new City() {Name="MUĞLA"},
             new City() {Name="MUŞ"},
             new City() {Name="NEVŞEHİR"},
             new City() {Name="NİĞDE"},
             new City() {Name="ORDU"},
             new City() {Name="RİZE"},
             new City() {Name="SAKARYA"},
             new City() {Name="SAMSUN"},
             new City() {Name="SİİRT"},
             new City() {Name="SİNOP"},
             new City() {Name="SİVAS"},
             new City() {Name="TEKİRDAĞ"},
             new City() {Name="TOKAT"},
             new City() {Name="TRABZON"},
             new City() {Name="TUNCELİ"},
             new City() {Name="ŞANLIURFA"},
             new City() {Name="UŞAK"},
             new City() {Name="VAN"},
             new City() {Name="YOZGAT"},
             new City() {Name="ZONGULDAK"},
             new City() {Name="AKSARAY"},
             new City() {Name="BAYBURT"},
             new City() {Name="KARAMAN"},
             new City() {Name="KIRIKKALE"},
             new City() {Name="BATMAN"},
             new City() {Name="ŞIRNAK"},
             new City() {Name="BARTIN"},
             new City() {Name="ARDAHAN"},
             new City() {Name="IĞDIR"},
             new City() {Name="YALOVA"},
             new City() {Name="KARABÜK"},
             new City() {Name="KİLİS"},
             new City() {Name="OSMANİYE"},
             new City() {Name="DÜZCE"},






        };
    }
}
