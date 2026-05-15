# AR Avometer Learning Simulator

Proyek ini adalah aplikasi pembelajaran berbasis Augmented Reality untuk membantu pengguna mempelajari penggunaan avometer atau multimeter secara lebih interaktif. Aplikasi dibangun dengan Unity dan Vuforia, lalu dihubungkan dengan Firebase Realtime Database agar nilai pengukuran dari aplikasi Kodular dapat diperbarui secara real-time.

## Anggota Tim

- Bilal Rizky Akbar - 224443050
- Muhammad Miftah Rizki - 224443061
- Gibral Haikal Faiz - 224443075
- Haikal Alghiffari Sunggoro - 224443075
- Najma Nur Asyifa - 224443086

## Gambaran Proyek

AR Avometer Learning Simulator dirancang sebagai media pembelajaran praktikum yang menampilkan model avometer 3D di lingkungan nyata menggunakan kamera smartphone. Proyek ini mendukung pendekatan belajar visual dan interaktif, sehingga pengguna dapat memahami fungsi dasar avometer tanpa harus selalu bergantung pada alat fisik.

Pada implementasinya, pengguna memasukkan nilai melalui aplikasi yang dibuat di Kodular. Data tersebut dikirim ke Firebase Realtime Database, kemudian aplikasi Unity membaca perubahan itu dan menampilkan hasil pembacaan pada antarmuka aplikasi. Berdasarkan struktur proyek saat ini, data yang dipantau berada pada node `Avometer` dengan beberapa nilai utama seperti `AC`, `DC`, `Diode`, dan `Ohms`.

## Fitur Utama

- Visualisasi avometer 3D berbasis Augmented Reality
- Pelacakan marker menggunakan Vuforia Engine
- Splash screen sebelum masuk ke scene utama
- Input data pengukuran dari aplikasi Kodular
- Tampilan nilai pengukuran secara real-time dari Firebase
- Dukungan mode pembacaan:
  - AC
  - DC
  - Diode
  - Ohms
- Panel deskripsi yang dapat dibuka dan ditutup secara dinamis
- Cocok digunakan sebagai media pembelajaran dasar alat ukur listrik

## Teknologi yang Digunakan

| Teknologi | Keterangan |
| --- | --- |
| Unity 2022.3.62f3 | Engine utama pengembangan aplikasi |
| Vuforia Engine 11.4.4 | Tracking image target untuk pengalaman AR |
| Kodular | Antarmuka input nilai pengukuran |
| Firebase Realtime Database | Sinkronisasi data pengukuran secara real-time |
| TextMeshPro | Komponen tampilan teks pada antarmuka |
| Android Build Support | Target deployment ke perangkat mobile |

## Struktur Proyek Singkat

Beberapa bagian penting pada proyek:

- `Assets/Scenes/splashscreen.unity`  
  Scene pembuka aplikasi.

- `Assets/Scenes/SampleScene.unity`  
  Scene utama aplikasi AR.

- `Assets/FirebaseDataManager.cs`  
  Menghubungkan aplikasi ke Firebase dan memperbarui tampilan nilai `AC`, `DC`, `Diode`, dan `Ohms`.

- `Assets/DeskripsiManager.cs`  
  Mengatur panel deskripsi yang sedang aktif agar hanya satu panel terbuka dalam satu waktu.

- `Assets/ToggleDeskripsi.cs`  
  Handler tombol untuk membuka atau menutup panel deskripsi.

- `Assets/ScriptSplah/Wait.cs`  
  Mengatur perpindahan dari splash screen ke scene utama setelah jeda tertentu.

- `Assets/StreamingAssets/Vuforia/AvoMeter.dat` dan `Assets/StreamingAssets/Vuforia/AvoMeter.xml`  
  Dataset image target untuk kebutuhan pelacakan AR.

## Alur Sistem

```text
Kodular -> Firebase Realtime Database -> Unity AR App -> Tampilan nilai pada UI avometer
```

Secara umum:

1. Pengguna memasukkan data pengukuran melalui aplikasi Kodular.
2. Kodular mengirimkan data tersebut ke Firebase Realtime Database.
3. Unity memantau perubahan data pada node `Avometer`.
4. Saat data berubah, nilai `AC`, `DC`, `Diode`, dan `Ohms` diperbarui pada UI.
5. Pengguna melihat visualisasi AR avometer beserta informasi nilainya secara langsung.

## Kebutuhan Pengembangan

Sebelum membuka proyek, pastikan lingkungan pengembangan memiliki:

- Unity Hub
- Unity Editor `2022.3.62f3`
- Android Build Support pada Unity
- Vuforia Engine yang sudah tersedia sesuai manifest proyek
- Konfigurasi Firebase yang sesuai dengan perangkat atau environment pengujian

## Cara Menjalankan Proyek

1. Buka Unity Hub.
2. Tambahkan proyek dari folder `D:\Polman\UnityProject\VuforiaAR`.
3. Pastikan editor yang dipakai adalah Unity `2022.3.62f3`.
4. Buka scene `Assets/Scenes/splashscreen.unity` atau `Assets/Scenes/SampleScene.unity`.
5. Periksa konfigurasi Vuforia dan Firebase bila proyek dijalankan di perangkat baru.
6. Build ke Android atau jalankan dari editor sesuai kebutuhan pengujian.

## Catatan

- Proyek sudah memuat dependensi Vuforia melalui package lokal `com.ptc.vuforia.engine-11.4.4.tgz`.
- File konfigurasi Firebase dan aset build kemungkinan perlu disesuaikan kembali bila proyek dipindahkan ke environment lain.
- Folder seperti `Library`, `Logs`, dan `obj` merupakan artefak hasil generate Unity dan bukan bagian inti logika aplikasi.

## Tujuan Pengembangan

Proyek ini dikembangkan sebagai media pembelajaran interaktif agar proses memahami penggunaan avometer menjadi lebih menarik, aman, dan mudah diakses. Dengan pendekatan AR, pengguna dapat belajar melalui simulasi visual yang lebih dekat dengan praktik nyata.
