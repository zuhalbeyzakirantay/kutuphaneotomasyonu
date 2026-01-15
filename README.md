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

---

### 📚 Kitap Yönetimi
- Kitap ekleme
- Kitap güncelleme
- Kitap silme
- Kitapları listeleme
- Stok takibi

---

### 👥 Üye Yönetimi
- Üye ekleme
- Üye silme
- Üyeleri listeleme

---

### 🔄 Ödünç İşlemleri
- Kitap ödünç verme
- Kitap iade alma
- Stok otomatik azalır / artar
- İade durumu kontrol edilir

---

### 📊 Raporlama

Kullanıcı **ComboBox** üzerinden rapor türünü seçer ve **“Raporu Gör”** butonuna basar.

#### 📈 Mevcut Raporlar:

- ✅ En Çok Okunan Kitaplar
- ✅ İade Edilmemiş Kitaplar
- ✅ Aktif Üyeler (kaç kitap aldıkları ile)

Sonuçlar **DataGridView** üzerinde listelenir.

---
## youtube linki

https://youtu.be/-p1ULunLCvU?si=Ow2ak0Bzl6m02g24


