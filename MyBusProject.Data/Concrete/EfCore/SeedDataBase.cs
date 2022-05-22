using Microsoft.EntityFrameworkCore;
using MyBusProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBusProject.Data.Concrete
{
  public static  class SeedDataBase
    {
        public static void Seed()
        {
            var context = new MyBusProjectContext();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Routes.Count() == 0)
                {
                    context.Routes.AddRange(Routes);
                }
                if (context.Tickets.Count() == 0)
                {
                    context.Tickets.AddRange(Tickets);
                }
                if (context.Cities.Count() == 0)
                {
                    context.Cities.AddRange(Cities);
                }
            }
            context.SaveChanges();
        }


        private static Route[] Routes =
        {
            new Route(){ StartRoute="İstanbul", Route1="Kocaeli", Route2="Kütahya", Route3="Afyon", EndRoute="Isparta", Date="15.05.2021", Hour="18.00",  Price=110},
            new Route(){ StartRoute="Rize", Route1="Ordu", Route2="Samsun", Route3="Kocaeli", EndRoute="İstanbul", Date="16.05.2021", Hour="19.00",  Price=180},
        };
        private static Ticket[] Tickets =
        {
            new Ticket(){Name="Emirhan", Surname="Taşçı", Mail="emirhantasci@outlook.com", StartCity="İstanbul", EndCity="Isparta", SeatNo=11, Price=110, RouteId=1},
            new Ticket(){Name="Can", Surname="Yumak", Mail="canyumak@outlook.com", StartCity="Kocaeli", EndCity="Isparta", SeatNo=10, Price=100, RouteId=1},
            new Ticket(){Name="Hale", Surname="Opak", Mail="haleopak@outlook.com", StartCity="Kütahya", EndCity="Isparta", SeatNo=8, Price=80, RouteId=1},
            new Ticket(){Name="Aylin", Surname="Kone", Mail="aylinkone@outlook.com", StartCity="İstanbul", EndCity="Isparta", SeatNo=4, Price=110, RouteId=1},
            new Ticket(){Name="Murat", Surname="Porut", Mail="muratporut@outlook.com", StartCity="İstanbul", EndCity="Isparta", SeatNo=20, Price=110, RouteId=1},
            new Ticket(){Name="Mehmet", Surname="Oguz", Mail="mehmetoguz@outlook.com", StartCity="İstanbul", EndCity="Isparta", SeatNo=19, Price=110, RouteId=1},
            new Ticket(){Name="Yusuf", Surname="Süy", Mail="yusufyus@outlook.com", StartCity="Rize", EndCity="İstanbul", SeatNo=15, Price=180, RouteId=2},
            new Ticket(){Name="Sena", Surname="Çor", Mail="senacor@outlook.com", StartCity="Ordu", EndCity="Samsun", SeatNo=11, Price=60, RouteId=2},
            new Ticket(){Name="Ahmet", Surname="Can", Mail="ahmetcan@outlook.com", StartCity="Kocaeli", EndCity="İstanbul", SeatNo=8, Price=50, RouteId=2}
        };
        private static City[] Cities =
  {
             new City() {Name="NameANA"},
             new City() {Name="NameIYAMAN"},
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
