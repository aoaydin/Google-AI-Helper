# Google AI Helper


## Google AI Yardımcısı

Bu program, Google'ın Generative Language API'sini kullanarak metin işleme görevlerini gerçekleştiren basit bir masaüstü uygulamasıdır.  Kullanıcılar, metin girdilerini çeşitli işlemler için gönderebilir ve API'den gelen yanıtları uygulamada görüntüleyebilirler.

Özellikler:

* Çoklu İşlem Türleri:  Uygulama, şu işlemleri destekler:
    * Düzenle:  Girilen metni daha iyi bir şekilde yeniden yazar.
    * Özetle:  Girilen metnin kısa bir özetini oluşturur.
    * Çevir (İngilizce): Girilen metni İngilizce'ye çevirir / Henüz Düzgün ve stabil çalışmamaktadır. yazı sonuna çevrilmek istenen dil eklenmesi gerekiyor.
    * Resmileştir: Girilen metni daha resmi bir dile dönüştürür.
* Kullanıcı Dostu Arayüz:  Basit ve anlaşılır bir arayüz ile kullanıcılar kolayca metin girebilir ve işlemleri seçebilirler.
* Yanıt İşleme:  API'den gelen yanıtlar, okunabilirliği artırmak için biçimlendirilir ve gösterilir.
* Panoya Kopyalama:  Kullanıcılar, yanıt metnini kolayca panoya kopyalayabilirler.
* Hata Yönetimi:  API hataları yakalanır ve kullanıcıya bildirilir.


Kullanım:

1. API Anahtarı ve Model Adı:  `Form1.cs` dosyasındaki `ApiKey` ve `ModelName` değişkenlerine Google Cloud projenizden aldığınız geçerli API anahtarınızı ve kullanılacak model adını ("gemini-1.5-flash") girin.
2. Uygulamayı Çalıştırın:  Uygulamayı derleyin ve çalıştırın.
3. Metin Girin:  İşlem yapmak istediğiniz metni giriş kutusuna yazın.
4. İşlem Seçin:  İşlem türünü açılır menüden seçin.
5. Gönder Butonuna Tıklayın:  API'ye istek göndermek için "Gönder" butonuna tıklayın.
6. Yanıtı Görüntüleyin:  Yanıt, uygulamada gösterilecektir. Yanıtı panoya kopyalamak için yanıt kutusuna tıklayın.


Gereksinimler:

* .NET Framework (uygun sürüm)
* Newtonsoft.Json NuGet paketi


Notlar:

* Bu uygulama, Google Cloud Platform'un Generative Language API'sine bağlıdır.  API kullanımına ilişkin ücretlendirme politikaları için Google Cloud Platform dokümanlarını inceleyin.
* Uygulama, `gemini-1.5-flash` modelini kullanır.  Farklı bir model kullanmak isterseniz, `ModelName` değişkenini güncellemeniz gerekecektir.
* Uygulamada kullanılan API anahtarının güvenliği sizin sorumluluğunuzdadır.  API anahtarınızı başkalarıyla paylaşmayın.


Bu program, Google'ın güçlü Generative Language API'sini kullanarak metin işleme görevlerini kolaylaştıran basit ve kullanışlı bir araçtır.  Umarım işinize yarar!

