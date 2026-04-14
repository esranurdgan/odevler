# Neon Tetris OOP - Teknik Dokümantasyon

Bu proje, Nesne Tabanlı Programlama (OOP) prensiplerini ve güvenli bir Tekil Kurulum Mekanizmasını (Single-Installation Mechanism) göstermek amacıyla geliştirilmiştir.

## 1. Nesne Tabanlı Programlama (OOP) İlkeleri

Projenin yazılım mimarisi 4 temel OOP ilkesi üzerine kurulmuştur:

### A. Soyutlama (Abstraction)
`Models/Tetromino.cs` dosyası içerisindeki `Tetromino` sınıfı `abstract` olarak tanımlanmıştır. Bir Tetris parçasının sahip olması gereken temel özellikler (pozisyon, matris yapısı, renk) ve metodlar (Hareket, Döndürme) burada soyutlanmıştır. Bu sınıf doğrudan örneklenemez (instantiated), sadece kalıtım yoluyla kullanılabilir.

### B. Kapsülleme (Encapsulation)
`GameBoard.cs` ve `Tetromino.cs` sınıflarında oyunun iç durumu (hücre verileri, parça matrisleri) `private` veya `protected` erişim belirleyicileri ile korunmuştur. Verilere erişim belirli metodlar (örneğin `GetCell`, `GetMatrix`) üzerinden kontrollü bir şekilde sağlanır. Bu, oyun mantığının dışarıdan hatalı müdahalelere karşı korunmasını sağlar.

### C. Kalıtım (Inheritance)
`Models/Shapes.cs` dosyasındaki yedi farklı Tetris parçası (`IPiece`, `OPiece`, `TPiece`, vb.), `Tetromino` sınıfından kalıtım almıştır. Bu sayede kod tekrarı önlenmiş ve ortak davranışlar tek bir merkezden yönetilir hale getirilmiştir.

### D. Çok Biçimlilik (Polymorphism)
`OPiece` (Kare parça) sınıfı, `Tetromino` sınıfındaki `RotateClockwise` metodunu `override` ederek döndürme işlemini devre dışı bırakmıştır. Çünkü kare bir parça döndüğünde şekli değişmez. Aynı metod çağrısı (`RotatePiece`), parça tipine göre farklı davranışlar sergileyebilmektedir.

---

## 2. Tekil Kurulum Mekanizması Tasarımı

Projenin en kritik gereksinimlerinden biri olan "Yazılımın sadece bir kez kurulabilmesi" özelliği, **Inno Setup** script'i (`installer_script.iss`) içerisinde şu şekilde tasarlanmıştır:

### Teknik Uygulama:
1.  **Kalıcı İşaretleyici (Persistent Marker):** Kurulum sırasında Windows Kayıt Defteri'ne (Registry) `HKCU\Software\NeonTetrisOOP_Project` anahtarı eklenir.
2.  **Silinmeme Güvencesi:** Bu anahtar, Inno Setup'ın `uninsneveruninstall` bayrağı ile işaretlenmiştir. Bu sayede kullanıcı oyunu sistemden kaldırsa (Uninstall) dahi, bu kayıt defteri anahtarı sistemde kalmaya devam eder.
3.  **Başlatma Kontrolü:** Kurulum paketi (`TetrisSetup.exe`) her çalıştırıldığında, Inno Setup'ın `[Code]` bölümündeki `InitializeSetup` fonksiyonu tetiklenir.
4.  **Engelleme Mantığı:** Eğer sistemde bahsedilen kayıt defteri anahtarı bulunursa, kurulum bir hata mesajı gösterir ve işlemi derhal durdurur.

Bu mekanizma, uygulamanın aynı sistem üzerinde birden fazla kez kurulmasını (silinse dahi) imkansız hale getirir.

---

## 3. Kurulum ve Çalıştırma
1.  Oyunun `.exe` hali `bin/Release/net10.0-windows/` klasöründedir.
2.  Kurulum paketini oluşturmak için `installer_script.iss` dosyası Inno Setup ile derlenmiştir.
3.  Oluşan `TetrisSetup.exe` ile kurulum yapılabilir.
