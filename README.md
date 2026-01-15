# 📚 Kütüphane Otomasyonu (Library Automation System)

Bu proje, **C# Windows Forms** kullanılarak geliştirilmiş, **MySQL veritabanı** ile çalışan bir **Kütüphane Otomasyonu** uygulamasıdır.  
Amaç; kitap, üye, ödünç alma ve raporlama işlemlerini **katmanlı mimari** yapısıyla düzenli, anlaşılır ve sürdürülebilir şekilde yönetmektir.

---

## 🎯 Projenin Amacı

Bu proje ile:

- Gerçek bir kütüphane senaryosu modellenmiştir
- Katmanlı mimari kullanımı öğrenilmiştir
- Veritabanı bağlantısı ve SQL sorguları uygulanmıştır
- CRUD işlemleri (Create, Read, Update, Delete) gerçekleştirilmiştir
- Raporlama mantığı projeye entegre edilmiştir

---

## 🧱 Kullanılan Mimari (N-Layer Architecture)

Projede **Katmanlı Mimari (N-Katmanlı Mimari)** kullanılmıştır.

### Katmanların Görevleri

### 🔹 UI (User Interface)
- Kullanıcı arayüzlerini içerir
- Formlar burada yer alır
- Veritabanına **doğrudan erişmez**

Örnek:
- BookForm
- MemberForm
- BorrowForm
- ReportForm
- LoginForm

---

### 🔹 Service Layer
- İş kuralları burada yazılır
- Gerekli kontroller burada yapılır
- UI ile DAL arasında köprü görevi görür

Örnek:
- BookService
- MemberService
- BorrowService
- ReportService
- UserService

---

### 🔹 DAL (Data Access Layer)
- Veritabanı işlemleri burada yapılır
- SQL sorguları bu katmanda yazılır
- UI bu katmana **asla direkt erişmez**

Örnek:
- BookDAL
- MemberDAL
- BorrowDAL
- UserDAL
- DbConnection

---

### 🔹 Domain Layer
- Veritabanı tablolarının C# karşılıkları
- Sadece property içerir

Örnek:
- Book
- Member
- Borrow
- User
---

## 🖥 Uygulama Ekranları ve İşlevleri

### 🔐 Login Ekranı
- Kullanıcı adı ve şifre ile giriş yapılır
- Yetkili kullanıcı sisteme alınır

![Login ekranı](https://github.com/user-attachments/assets/01219a8f-e330-4526-a651-c683e1b24005)



---

### 📚 Kitap Yönetimi
- Kitap ekleme
- Kitap güncelleme
- Kitap silme
- Kitapları listeleme
- Stok takibi

![Kitap yönetimi](https://github.com/user-attachments/assets/60fcc560-a082-4f6e-9190-1930428039a4)



---

### 👥 Üye Yönetimi
- Üye ekleme
- Üye silme
- Üyeleri listeleme

![Üye yönetimi](https://github.com/user-attachments/assets/b14ade83-7ae3-4340-8c51-f2df8313209b)



---

### 🔄 Ödünç İşlemleri
- Kitap ödünç verme
- Kitap iade alma
- Stok otomatik azalır / artar
- İade durumu kontrol edilir

![Ödünçişlemleri](https://github.com/user-attachments/assets/d5375ae8-990d-4c91-9fdc-7a5628050c2e)



---

### 📊 Raporlama

Kullanıcı **ComboBox** üzerinden rapor türünü seçer ve **“Raporu Gör”** butonuna basar.

#### 📈 Mevcut Raporlar:

- ✅ En Çok Okunan Kitaplar
- ✅ İade Edilmemiş Kitaplar
- ✅ Aktif Üyeler (kaç kitap aldıkları ile)

Sonuçlar **DataGridView** üzerinde listelenir.

![Rapor ekranı](https://github.com/user-attachments/assets/e4de4e84-7e52-4259-bd78-332ad9a4e24d)



---

## 📞 İletişim

Herhangi bir soru, geri bildirim veya öneriniz olması durumunda benimle iletişime geçebilirsiniz:

- **Ad:** Zuhal Beyza  
- **Soyad:** Kırantay  
- **E-posta:** [zuhalbeyzakirantay@gmail.com](mailto:zuhalbeyzakirantay@gmail.com)

  -----
  
## YouTube Link 

https://youtu.be/-p1ULunLCvU?si=Ow2ak0Bzl6m02g24


