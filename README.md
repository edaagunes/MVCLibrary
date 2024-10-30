# Kütüphane Projesi

## Genel Bakış
:books: Bu proje bir kütüphanenin Vitrin, Admin ve Kullanıcı olmak üzere 3 temel panelinden oluşmaktadır. Kullanıcıların kütüphaneden ödünç kitap alabileceği,kullanıcılar arası mesajlaşma özelliği, kütüphanenin yayınladığı duyuruları görebileceği bir kullanıcı paneli hazırlandı. Admin tarafında kütüphaneye ait kitapların yönetimi, ödünç kitap işlemleri gerçekleştirildi. Vitrin kısmında admin tarafından belirlenen kitapların listelenmesi ve kullanıcıların mesaj gönderebileceği bir iletişim paneli kullanıldı. 

### 🏛️ [Vitrin](#%EF%B8%8F-vitrin)

 📚 **Kitaplarımız:** Admin tarafından belirlenen kitaplar listelenir.
 
 ✉️ **İletişim:** Kullanıcıların admine mesaj göndermesi sağlandı.
 
🔑 **Giriş Yap:** Kullanıcı ve Admin Panellerine giriş sayfasına yönlendirildi.

### 🔐 Login Sayfaları

 👥 **Kullanıcı ve Admin Girişleri:** Hesabı olmayan kullanıcılar için Kayıt Ol sayfasına yönlendirme yapıldı.

![2](https://github.com/user-attachments/assets/3aef41bc-24b3-4e73-b32e-948aa58a7a72)
![4](https://github.com/user-attachments/assets/a7715c42-e166-4ca8-8d7c-4cf37114622e)
![3](https://github.com/user-attachments/assets/29cebef2-a1d4-4ce1-8d9c-1cc4834f0e4f)

### 👤 [Kullanıcı Paneli](#-kullanıcı-paneli)

 🔖 **Profil:** Kullanıcıyı admin tarafından yayınlanan Duyurular ve bilgilerini güncelleyebilmesi için Ayarlar kısmı karşılar.
 
 📥 **Gelen Mesajlar:** Sisteme kayıtlı diğer kullanıcılar tarafından gelen mesajlar görüntülenir.
 
 📤 **Giden Mesajlar:** Kullanıcının gönderdiği mesajlar listelenir.
 
 ✍️ **Yeni Mesaj:** Kullanıcı yeni mesaj gönderebilir.
 
 📚 **Kitaplarım:** Kullanıcının kütüphaneden ödünç aldığı kitapların bilgileri listelenir.
 
 🚪 **Çıkış Yap:** Kullanıcının sistemden çıkış yapması sağlanır.

### 🛠️ [Admin Paneli](%EF%B8%8F-admin-paneli)

 🗂️ **Kategoriler:** Kitapların kategorileri listelenir.
 
 📘 **Kitaplar:** Kitapların Ekle/Sil/Güncelle işlemleri yapılır. Kitap Arama ve Sayfalama özellikleri eklendi.
 
 ✒️ **Yazarlar:** Yazar işlemleri yapılır. Detaylarda yazara ait kitaplar listelenir.
 
 👥 **Üyeler:** Sisteme kayıtlı kullanıcılar listelenir. Kitap geçmişi ile kullanıcının ödünç aldığı kitaplar listelenir.
 
 🧑‍💼 **Personeller:** Ödünç kitap işlemleri yapması için personel eklendi.
 
 📖 **Ödünç Kitap Ver:** Kullanıcı-kitap-personel ve tarih bilgileri girilerek kullanıcıya ödünç kitap verme işlemi yapılır.

 ❗  Kullanıcının ödünç aldığı kitabı iade etme süresi 7 gündür. İade tarihi otomatik olarak tanımlanır.

 🔄 **Ödünç Kitap Al:** Ödünç verilen kitaplar listelenir. Kitabın kütüphaneye iade işlemi yapılır.

  ❗ Geç Gelen Gün Sayısı kadar kullanıcıya para cezası uygulanır. Henüz iade süresi dolmamışsa fazla gün sayısı - olarak gösterilir.

   📊 **İstatistikler:** Sisteme ait veriler listelenir.
   
 📢 **Duyurular:** Kullanıcıya gönderilecek duyurular listelenir.
 
 📜 **İşlemler:** Geçmişe ait ödünç işlemleri kayıtları tutulur.
 
🌦️ **Hava Kartları:** Widget kullanımı için güncel hava durumu verileri çekilir.

 🖼️ **Galeri:** Kütüphane görselleri bulunmaktadır. Fotoğraf yükleme özelliği eklenmiştir.
 
🧮 **Linq Kartları:** Sisteme ait veriler listelenir.

 📈 **Grafikler:** Chartlar kullanılarak istatistikler listelenir.
 
 ⚙️ **Ayarlar:** Adminler için bilgi güncelleme yapılabilir. Yeni Admin ekleme işlemi için Modal Popup kullanıldı.
 
 🚪 **Çıkış:** Adminin sistemden çıkışı gerçekleştirilir.

### 🔗 Veri Tabanı İlişkileri

![1](https://github.com/user-attachments/assets/45b5f0d4-2a05-4fdb-90b3-2d068cd8eff0)

### 💻 Kullanılan Teknolojiler

<table>
  <tr>
    <td>🎉 Asp.Net MVC ile hazırlanmıştır.</td>
    <td>📊 Partial Views, Paging ve Search işlemleri uygulandı.</td>
  </tr>
  <tr>
    <td>📚 Entity Framework kullanılmıştır.</td>
    <td>🖼️ Modal popup ile veri ekleme.</td>
  </tr>
  <tr>
    <td>🔨 DbFirst yaklaşımı uygulanmıştır.</td>
    <td>🏗️ CRUD işlemleri</td>
  </tr>
  <tr>
    <td>💾 MSSQL veri tabanı kullanılmıştır.</td>
    <td>📈 ChartJS ile chartlar oluşturuldu.</td>
  </tr>
  <tr>
    <td>📖 LINQ sorguları.</td>
    <td>⚙️ Triggers ve Procedure kullanıldı.</td>
  </tr>
  <tr>
    <td>⚠️ Alert ve Error Page Kullanımı</td>
    <td>📋 Dropdown ile veri listeleme</td>
  </tr>
  <tr>
    <td>📝 Data Annotations</td>
    <td>📂 File Upload kullanımı</td>
  </tr>
  <tr>
    <td>🔑 Session Yönetimi</td>
    <td>🔐 Authentication ve Authorize işlemleri</td>
  </tr>
</table>

## 🏛️  Vitrin

![5](https://github.com/user-attachments/assets/9bd35546-0bb2-4132-8d5d-32ae20635e04)
![6](https://github.com/user-attachments/assets/1c181609-a642-4e8a-ab3b-d69e1b8a288d)


## 👤 Kullanıcı Paneli

![7](https://github.com/user-attachments/assets/c747a141-1314-422c-ae15-7134f194e2d2)
![8](https://github.com/user-attachments/assets/1b2546c6-e289-4cfc-b043-b4d3c710ff85)
![9](https://github.com/user-attachments/assets/20191ebb-f738-4ad8-b330-c7866f6b19d0)
![10](https://github.com/user-attachments/assets/6a2bc41e-524a-42ce-b881-824c024fc30c)
![11](https://github.com/user-attachments/assets/821d6b1d-6399-483e-8668-bb1be1cbc65a)
![12](https://github.com/user-attachments/assets/230011f7-8875-4350-9091-709a31efbb96)
![13](https://github.com/user-attachments/assets/b5920f28-dcd1-46b2-9a69-4bd9a74ee841)

## 🛠️ Admin Paneli

![14](https://github.com/user-attachments/assets/250d1558-52b1-4d23-bf7e-84bf2aeb5ddb)
![15](https://github.com/user-attachments/assets/0717e5b5-4f30-4dc3-b1fd-533c17544593)
![16](https://github.com/user-attachments/assets/3050dad1-1547-4f7e-8885-f24e00324e59)
![17](https://github.com/user-attachments/assets/ec561614-94a0-4e79-a8f9-26d2933ee6c6)
![18](https://github.com/user-attachments/assets/3554d11e-db81-4a39-a31c-cfb3a8122324)
![19](https://github.com/user-attachments/assets/24976057-d82a-493d-92cc-75e2b146e5b2)
![20](https://github.com/user-attachments/assets/614a5c5a-426e-4921-b17e-48e75d7183cb)
![21](https://github.com/user-attachments/assets/b0d7aae7-2084-4ecd-9ea5-cca3b4d56564)
![22](https://github.com/user-attachments/assets/213f295c-44b3-4316-a39b-d3e16d25479f)
![23](https://github.com/user-attachments/assets/14c3fdb2-dd87-4122-832c-a543c3aba7ed)
![24](https://github.com/user-attachments/assets/0019cc6d-113c-43bb-af6e-b6b4bb76f03e)
![25](https://github.com/user-attachments/assets/30762f0f-9d94-4063-9b04-d741fc02199e)
![26](https://github.com/user-attachments/assets/1b3aa3cc-ac08-413a-b645-92d9d3e69cd1)
![27](https://github.com/user-attachments/assets/9c757e01-176d-49a7-ac96-ec5ec68babcc)
![28](https://github.com/user-attachments/assets/6af101fc-8bb0-46b3-a574-ca8890c7588d)
![29](https://github.com/user-attachments/assets/0ae62fdd-4e53-4621-b574-bd1b4b51cece)
![30](https://github.com/user-attachments/assets/6a7ff177-72a4-4baf-8b09-d361f8276f47)
![31](https://github.com/user-attachments/assets/e0f2a3e0-de9f-498e-94ab-3af3d0c9dfa1)
![32](https://github.com/user-attachments/assets/f61a4470-fa26-4f52-8a3a-53d3ffe04ee3)
![33](https://github.com/user-attachments/assets/89e9a1d6-99a1-4c73-8b42-4032429ff981)
![34](https://github.com/user-attachments/assets/686c99c1-0372-4730-8b40-4ede41d6eab5)
![35](https://github.com/user-attachments/assets/726d3bad-70f2-4154-938b-f5fd5b01afb0)














