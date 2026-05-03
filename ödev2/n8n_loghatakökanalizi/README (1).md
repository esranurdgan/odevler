# Log Kök Neden Analizi - Yapay Zeka Destekli Otomasyon Sistemi

Bu proje, sistem loglarından otomatik olarak hata analizi yapan ve hataların kök nedenlerini tespit etmek amacıyla geliştirilmiş bir otomasyon sistemidir.

---

## Amaç

Yazılım sistemlerinde oluşan hataların manuel olarak incelenmesi zaman alıcı ve hataya açık bir süreçtir. Bu sistem, log dosyalarını otomatik olarak okuyarak yapay zeka ile analiz eder ve sonuçları hem veritabanına kaydeder hem de e-posta ile iletir.

---

## Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|-----------|----------|
| **n8n** | Otomasyon iş akışı platformu |
| **Node.js** | n8n'in çalıştığı ortam |
| **Groq (LLaMA)** | Yapay zeka dil modeli - log analizi |
| **Notion** | Analiz sonuçlarının kaydedildiği veritabanı |
| **Gmail SMTP** | Otomatik e-posta bildirimi |
| **Windows** | Sistemin çalıştığı işletim sistemi |

---

## Nasıl Çalışır?

1. **Log Okuma** - Belirlenen klasöre atılan `.log` dosyaları otomatik okunur
2. **AI Analizi** - Groq dil modeli log içeriğini analiz eder
3. **Sonuç Üretimi** - Hatanın kök nedeni, çözüm önerisi ve öncelik seviyesi belirlenir
4. **Notion Kaydı** - Analiz sonuçları otomatik olarak Notion veritabanına kaydedilir
5. **E-posta Bildirimi** - Kullanıcıya otomatik e-posta gönderilir

---

## Notion Veritabanı Alanları

- **Hata** - Hatanın kısa açıklaması
- **Kök Neden** - Hatanın temel nedeni
- **Çözüm Önerisi** - Önerilen çözüm adımları
- **Öncelik** - Kritik / Yüksek / Düşük
- **Tarih** - Analiz tarihi ve saati

---

## Kurulum

### Gereksinimler
- Node.js (v18 veya üzeri)
- n8n

### Adımlar

1. **n8n'i yükle:**
```bash
npm install -g n8n
```

2. **n8n'i başlat:**
```bash
n8n start
```

3. **Tarayıcıdan aç:**
```
http://localhost:5678
```

4. **Workflow'u içe aktar:**
   - n8n arayüzünde `...` menüsüne tıkla
   - `Import from file` seç
   - `workflow.json` dosyasını seç

5. **API Anahtarlarını Gir:**
   - Groq API key: [groq.com](https://groq.com)
   - Notion API key: [notion.so/profile/integrations](https://notion.so/profile/integrations)
   - Gmail SMTP: Uygulama şifresi gerekli

6. **Log dosyasını klasöre at:**
```
C:\Users\[KullaniciAdi]\.n8n-files\
```

7. **Workflow'u çalıştır ve sonuçları Notion'da görüntüle!**

---

## Örnek Log Dosyası

```
[2024-01-15 14:23:01] ERROR: Connection timeout - Database unreachable
[2024-01-15 14:23:05] ERROR: Retry attempt 1 failed
[2024-01-15 14:23:10] CRITICAL: Service crashed - null pointer exception
```

---

## Proje Sahibi

**Esranur Doğan**  
Bilgisayar Mühendisliği
