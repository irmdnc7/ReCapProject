using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
        public static string UserListed = "Kullanıcılar Listelendi.";

        public static string UserRegistered = "Kullanıcı  kaydedildi.";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş başarlı";
        public static string UserAlreadyExists = "Bu kullanıcı mevcut.";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string CardSaved = "Kartınız kaydedildi";
        public static string CardDeleted = "Kartıznız Silindi";

        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string ImageLimitExpiredForCar = "Bir arabaya maximum 5 fotoğraf eklenebilir";
        public static string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
        public static string InvalidImageExtension = "Geçersiz dosya uzantısı, fotoğraf için kabul edilen uzantılar" + string.Join(",", ValidImageFileTypes);
        public static string CarImageMustBeExists = "Böyle bi resim bulunamadı";

        public static string CarHaveNoImage = "Araca ait resim bulunmamaktadır.";
        public static string PasswordChanged = "Şifre başarıyla değiştirildi.";
    }
}
