using Core.Entities.Concrete;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";//ppublicduğu için büyük harfle yazdık pprdoct aded'ı
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductListed="Ürünler Listelendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered="Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Başarılı Giriş";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string ProductUpdated="Ürün güncellendi.";
    }
}
