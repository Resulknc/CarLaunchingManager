using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi.";
        public static string UsersListed = "Kullanıcılar listelendi.";

        public static string SellerAdded = "Satıcı eklendi.";
        public static string SellerDeleted = "Satıcı silindi.";
        public static string SellerUpdated = "Satıcı bilgileri güncellendi.";
        public static string SellersListed = "Satıcılar listelendi.";
        public static string SellerDetailsListed = "Satıcı detayları listelendi.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kayıt oldu.";
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        public static string PasswordError = "Parola hatası.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";

        public static string ImageLimitExceeded = "Bir ürünün beşten fazla fotoğrafı olamaz.";

        public static string ImageAdded = "Fotoğraf eklendi.";

        public static string ImageNotFound = "Fotoğraf bulunamadı.";
        public static string ImageDeleted = "Fotoğraf silindi.";

        public static string ImageUpdated = "Fotoğraf güncellendi.";
    }
}
