# Neon Tetris OOP & Single-Install Project

![License](https://img.shields.io/badge/license-MIT-blue)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)
![Framework](https://img.shields.io/badge/framework-.NET%2010.0-purple)

This project is a high-fidelity Tetris game developed using **C#** and **WPF**, following strict **Object-Oriented Programming (OOP)** principles. It also features a unique **Single-Installation Mechanism** using Inno Setup.

---

## 🚀 Key Features

### 1. Object-Oriented Design (OOP)
The project demonstrates the core pillars of OOP:
- **Abstraction:** Use of abstract `Tetromino` base classes.
- **Encapsulation:** Hidden internal grid state and move logic.
- **Inheritance:** Specialized shape classes for all 7 Tetris blocks.
- **Polymorphism:** Uniform piece handling and specialized rotation logic.

### 2. Multi-Theme UI (Turkish Supported)
- **Neon Cyberpunk:** Glow effects with a dark purple/pink gradient background.
- **Vaporwave:** Dreamy pink-to-blue gradient with pastel styled blocks.
- **Deep Space:** Minimalist AMOLED black aesthetic.

### 3. Single-Installation Mechanism (Tekil Kurulum)
- Designed to allow only **one successful installation** per machine.
- Uses a persistent **Windows Registry** marker.
- Even after uninstallation, the installer prevents re-installation, meeting strict project requirements.

---

## 🛠️ Tech Stack
- **Language:** C#
- **UI Framework:** Windows Presentation Foundation (WPF)
- **Installer:** Inno Setup 6
- **Architecture:** Managed OOP

## 📦 Installation & Build

### For Developers:
1. Clone the repository.
2. Open the project in Visual Studio or use CLI.
3. Run: `dotnet build -c Release`

### For Users:
1. Run `TetrisSetup.exe`.
2. Install the game.
3. Once uninstalled, note that you will be unable to re-install due to the security mechanism.

---

## 🇹🇷 Ödev Özeti (Turkish)
Bu ödev kapsamında, OOP prensiplerine sadık kalınarak bir Tetris oyunu geliştirilmiştir. Yazılımın en dikkat çekici özelliği, Inno Setup ve Windows Kayıt Defteri entegrasyonu ile sağlanan **Tekil Kurulum Mekanizmasıdır.** Bu mekanizma, uygulamanın bir sistem üzerine sadece bir kez kurulabilmesini garanti eder.

---

Developed for OOP Principles Course Assignment.
