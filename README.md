# Asp.Net MCV - nTier Architecture - Repository Pattern

# Görev Yönetim Sistemi

## Amaç
Kullanıcıların görev ekleyip, düzenleyip, silmesine imkan tanıyan bir sistem oluşturmak. Görevlerin durumu ve oluşturulma tarihine göre listelenmesi ve filtrelenmesi sağlanacak.

## Gereksinimler
- Kullanıcıların sisteme giriş yapabilmesi için kimlik doğrulama gereklidir.
- Kullanıcılar yeni görevler oluşturabilmeli.
- Mevcut görevleri düzenleyebilmeli ve silebilmeli.
- Görevler oluşturulma tarihine ve durumuna göre listelenebilmeli ve filtrelenebilmeli.

## Veri Yapısı
### Görev
Her görev aşağıdaki bilgileri içermelidir:
- **ID:** Görevin benzersiz kimliği (otomatik olarak atanacak).
- **Başlık:** Görevin başlığı (zorunlu alan).
- **Açıklama:** Görevin detaylı açıklaması (zorunlu alan).
- **Oluşturulma Tarihi:** Görevin oluşturulduğu tarih (otomatik olarak atanacak).
- **Durum:** Görevin durumu (yeni, devam ediyor, tamamlandı) (zorunlu alan).

## İşlevler
### Görev Oluşturma
- Kullanıcı yeni bir görev ekleyebilmeli.
- Kullanıcı, görev başlığı ve açıklamasını girmeli.
- Görev oluşturulma tarihi otomatik olarak atanmalı.
- Görev durumu başlangıçta "yeni" olarak ayarlanmalı.

### Görev Düzenleme
- Kullanıcı mevcut bir görevi düzenleyebilmeli.
- Kullanıcı, görev başlığı ve açıklamasını güncelleyebilmeli.
- Kullanıcı, görevin durumunu değiştirebilmeli (yeni, devam ediyor, tamamlandı).

### Görev Silme
- Kullanıcı, bir görevi silebilmeli.
- Silinen görevler kalıcı olarak veritabanından silinmeli.

### Görev Listesi
- Tüm görevler oluşturulma tarihine göre listelenmeli.
- Görevler durumlarına göre filtrelenebilmeli (yeni, devam ediyor, tamamlandı).

## Kullanıcı Arayüzü
### Giriş Ekranı
- Kullanıcı adı ve şifre alanları bulunmalı.
- Giriş yap butonu.

### Görev Listesi Ekranı
- Görevlerin listelendiği bir tablo veya kart görünümü.
- Her görev için başlık, açıklama, oluşturulma tarihi ve durum bilgisi gösterilmeli.
- Görevleri düzenleme ve silme butonları.
- Duruma göre filtreleme seçenekleri (dropdown menü).

### Görev Oluşturma ve Düzenleme Formu
- Başlık, açıklama ve durum alanları.
- Görev oluşturma veya güncelleme butonu.

## Veritabanı Tasarımı
### Görev Tablosu (Tasks)
- `id` (INT, Primary Key, Auto Increment)
- `title` (VARCHAR, Not Null)
- `description` (TEXT, Not Null)
- `creation_date` (DATETIME, Not Null)
- `status` (ENUM('new', 'in_progress', 'completed'), Not Null)
- `kullanıcı_id` (foreign key, not null)

### Kullanıcı Tablosu (Users)
- `id` (INT, Primary Key, Auto Increment)
- `username` (VARCHAR, Not Null)
- `password` (VARCHAR, Not Null)
- `role_id` (INT, Foreign Key)

