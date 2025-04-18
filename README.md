﻿# PASPAS

**PASPAS** is a fast and efficient multi-threaded analysis and cleanup tool designed to accelerate system maintenance tasks. It is easy to use, making it accessible for all users. PASPAS operates offline, without the need for telemetry or an internet connection, and includes features to optimize your network performance. It also securely clears sensitive data, ensuring your privacy while offering advanced system tuning capabilities.

![PASPAS Banner](https://github.com/berkaygediz/PASPAS/blob/master/paspas_banner_5.png)

## Features

- [x] **Blazing-fast multi-threaded analysis and cleanup**: Efficiently scans and cleans your system with minimal resource usage.
- [x] **No telemetry or internet connection required**: Operates completely offline for enhanced privacy.
- [x] **Network optimization**: Improves network performance and reduces latency for a smoother browsing experience.
- [x] **Securely clears sensitive data**: Ensures your private data is completely erased and cannot be recovered.
- [x] **Advanced system tweaks**: Includes several built-in performance tweaks to fine-tune your system:
  - **Disable telemetry** to prevent data collection.
  - **Clear activity history** (recent documents, clipboard, and run history) to further safeguard your privacy.
  - **Control system services** by setting them to manual startup, optimizing resource usage.
- [x] **Program Uninstaller**

## Tweaks

PASPAS offers the following system tweaks to enhance your privacy and optimize system performance:

- [x] **Disable Telemetry**: Prevents the collection of usage data, ensuring your system remains private.
- [x] **Disable Activity History**: Clears recent documents, clipboard entries, and run history, improving privacy.
- [x] **Set System Services to Manual**: Offers control over services, allowing you to set them to manual startup, saving system resources.
- [x] **Network Optimization**: Optimizes your network connection to improve speed and reduce delays.

## Requirements

- **.NET 9.0 or later**
  
## Usage

1. Download the latest release of [PASPAS](https://github.com/berkaygediz/PASPAS/releases).
2. Extract the contents of the zip file to any location on your system.
3. Run the `PASPAS.exe` application to begin analyzing and cleaning your system.
4. Apply the system tweaks to optimize performance and enhance privacy.

## Build

```bash
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -o ".\bin\publish\PASPAS-win-x64\"
```

## Contribute

We welcome contributions to PASPAS! If you'd like to help improve the tool, please refer to our [Contribution Guide](CONTRIBUTING.md) for more information on how you can contribute to the project.

## Contact Us

If you have any questions or feedback, please [open an issue](https://github.com/berkaygediz/PASPAS/issues) on GitHub. We're happy to assist and improve PASPAS with your input!

## Press and Publications

- [Comment Ça Marche](https://www.commentcamarche.net/telecharger/utilitaires/29641-paspas-un-nettoyeur-de-pc-gratuit-et-sans-installation/) (Téo Marciano - 01/12/23 19:53)
- [JustGeek](https://www.justgeek.fr/paspas-logiciel-nettoyage-pc-simple-et-gratuit-111141/) (Benjamin - 11.08.2023)
- [Softpedia](https://www.softpedia.com/get/Tweak/System-Tweak/PASPAS.shtml) (Robert Condorache ⭐ 4.0 / Users ⭐ 4.7)
- [Softaro](https://softaro.jp/paspas/) (2025/02/28 09:28)
- [PlanetaSofta](https://planetasofta.ru/windows/system-tweak/paspas)
- [AlternativeTo](https://alternativeto.net/software/berkaygediz-paspas/about/) (Users ⭐ 4.9)
- [YouTube - Actualia tech](https://www.youtube.com/watch?v=Il3TOGORYoM) (24.08.2023)
