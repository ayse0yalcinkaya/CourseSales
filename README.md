Bu proje, bir kurs satış platformu geliştirmek amacıyla hazırlanmıştır. Proje; en iyi uygulama ve teknikleri (best practices) ve modern web uygulama standartlarına uygun olarak, katmanlı bir mimari (N-Layer) kullanılarak geliştirilmiş ve ASP.NET Core'dan yararlanılmıştır.
Proje geliştirilme aşamasındadır. 
1. Genel Mimarisi
Katmanlı Mimari: Repository (DAL), Service (BLL) ve API (Presentation Layer) katmanlarına ayrılmıştır.

ORM Kullanımı: Entity Framework ile CRUD işlemleri gerçekleştirilmiştir.

Bağımlılık Yönetimi: Proje, Dependency Injection (DI) kullanılarak modüler şekilde tasarlanmıştır.

2. Backend (ASP.NET Core)
JWT Tabanlı Güvenlik: Kullanıcıların güvenli giriş yapması sağlanmıştır.

Repository Pattern: Category ve Course için repository sınıfları geliştirilmiştir.

Veritabanı Yapılandırması: SQL Server kullanılmış, Category ve Course tabloları oluşturulmuştur.

API Özellikleri:
Authentication Controller, CategoriesController, CoursesController
![image](https://github.com/user-attachments/assets/970d4ba9-ed6a-465e-9908-5608309996ab)




![image](https://github.com/user-attachments/assets/15031477-59f8-44a8-9a84-49cb1f765153)
![image](https://github.com/user-attachments/assets/34ca2c9b-ad7f-48ac-b557-ad8bfa36b964)
![image](https://github.com/user-attachments/assets/b6539996-98ca-4326-a82f-10fa1c032d07)


