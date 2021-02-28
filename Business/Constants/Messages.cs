using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string CarAdded = "Araç eklendi.";
        public static string CarUpdated = "Araç güncellendi.";      
        public static string CarDeleted = "Araç silindi.";
        public static string CarNameInvalid = "Araç ismi geçersiz!";
        public static string MaintenanceTime = "Sistem Bakımda...";
        public static string CarsListed = "Araçlar listelendi.";

        public static string ColorNotAdded = "Renk eklenemedi!";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNotUpdated ="Renk güncellemesi başarısız!";
        public static string GetColorById = "Renkler ID'leri ile birlikte listelendi";
        public static string ColorListed = "Renkler Listelendi";
        public static string ColorDeleted = "Renk Silindi.";

        public static string BrandNameInvalid = "Marka adı geçersiz!";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandsListed = "Markalar Listelendi";
        public static string BrandNotUpdated = "Marka Güncellenmedi!";
        public static string BrandUpdated = " Marka güncellendi";

        public static string CustomerAdded = " Müşteri Eklendi";
        public static string CustomerDeleted = " Müşteri silindi";
        public static string CustomerUpdated = " Müşteri güncellendi";
        public static string CustomerListed = "Müşteriler Listelendi";

        public static string InvalidRental = "Araç Kiralanamadı!";
        public static string RentalAdded = "Araç Kiralandı.";
        public static string UserAdded = "Kullanıcı Eklendi.";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi.";
    }
}
