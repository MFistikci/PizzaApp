PizzaApp

PizzaApp, ASP.NET Core Blazor Server kullanılarak geliştirilmiş bir pizza sipariş uygulamasıdır. Kullanıcıların farklı pizza seçeneklerini görüntüleyebildiği, pizza boyutu ve malzemelerini seçerek sipariş oluşturabildiği bir web uygulamasıdır.

Uygulama, Entity Framework Core kullanarak veritabanı işlemlerini yönetir ve SQLite veritabanı ile çalışır. Proje ayrıca başlangıç verilerinin otomatik olarak eklenmesini sağlayan bir SeedData mekanizması içerir.

Özellikler

Pizza menüsünü listeleme

Farklı pizza boyutları seçebilme

Ek malzemeler (toppings) ekleyebilme

Sipariş oluşturma

Sipariş durumunu takip edebilme

Veritabanına otomatik başlangıç verisi ekleme

Entity Framework Core Migration desteği

Kullanılan Teknolojiler

ASP.NET Core Blazor Server

Entity Framework Core

SQLite

C#

Razor Components

Proje Yapısı
PizzaApp
│

├── Data

│   └── PizzaContext.cs        → Entity Framework veritabanı bağlamı

│

├── Model

│   ├── Pizza.cs               → Pizza modeli

│   ├── PizzaSpecial.cs        → Özel pizza tanımları

│   ├── PizzaSize.cs           → Pizza boyutları

│   ├── PizzaTopping.cs        → Pizza ve malzeme ilişkisi

│   ├── Topping.cs             → Malzemeler

│   ├── Order.cs               → Sipariş modeli

│   ├── OrderSubmission.cs     → Sipariş gönderimi modeli

│   ├── OrderWithStatus.cs     → Sipariş durumu modeli

│   ├── Address.cs             → Adres bilgisi

│   └── UserInfo.cs            → Kullanıcı bilgisi

│

├── Migrations

│   └── Veritabanı migration dosyaları

│

└── Program.cs

    → Uygulama başlangıç noktası
Veritabanı

Uygulama SQLite kullanmaktadır.

Veritabanı dosyası:

pizza.db

Uygulama çalıştığında:

Migration işlemleri uygulanır.

Eğer veritabanında veri yoksa başlangıç pizzaları eklenir.

Bu işlem PizzaContext.SeedData() metodu ile yapılır.

Kurulum

Projeyi çalıştırmak için aşağıdaki adımları takip edebilirsiniz.

1. Projeyi klonlayın
git clone https://github.com/kullaniciadi/PizzaApp.git
2. Proje klasörüne girin
cd PizzaApp
3. Bağımlılıkları yükleyin
dotnet restore
4. Uygulamayı çalıştırın
dotnet run
Migration İşlemleri

Yeni migration oluşturmak için:

dotnet ef migrations add MigrationAdi

Veritabanını güncellemek için:

dotnet ef database update
Uygulama Akışı

Kullanıcı pizza menüsünü görüntüler.

Pizza seçilir.

Boyut ve malzemeler belirlenir.

Sipariş oluşturulur.

Sipariş veritabanına kaydedilir.

Sipariş durumu takip edilebilir.

Geliştirme Notları

Proje Blazor Server mimarisini kullanır.

Veritabanı işlemleri Entity Framework Core ile yapılmaktadır.

Başlangıç verileri SeedData yöntemi ile otomatik yüklenir.

Veritabanı şeması Migration sistemi ile yönetilir.

Gelecek Geliştirmeler

Kullanıcı hesap sistemi

Sipariş geçmişi

Ödeme entegrasyonu

Admin paneli

Pizza özelleştirme geliştirmeleri

REST API desteği
