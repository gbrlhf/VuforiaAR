using UnityEngine;
using Firebase.Database;
using TMPro; // Diperlukan untuk TextMeshPro
public class FirebaseDataManager : MonoBehaviour
{
    [Header("Hubungkan Teks UI ke Sini")]
    public TextMeshProUGUI txtAC;
    public TextMeshProUGUI txtDC;
    public TextMeshProUGUI txtDiode;
    public TextMeshProUGUI txtOhms;
    private DatabaseReference dbReference;
    // Variabel penampung data sementara
    private string valAC = "-";
    private string valDC = "-";
    private string valDiode = "-";
    private string valOhms = "-";

    // Tanda jika ada data baru masuk
    private bool isDataUpdated = false;
    void Start()
    {
        // Menyambungkan ke root database Firebase Anda
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        // Memantau perubahan data secara real-time pada folder "Sensor_Tanaman"
        dbReference.Child("Avometer").ValueChanged += HandleValueChanged;
    }
    // Fungsi ini otomatis terpanggil setiap kali data di Firebase berubah
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError("Error mengambil data: " + args.DatabaseError.Message);
            return;
        }
        DataSnapshot snapshot = args.Snapshot;
        if (snapshot != null && snapshot.Exists)
        {
            // Mengambil data dari Firebase.
            // .Replace("\"", "") digunakan untuk membuang tanda kutip ganda berlebih dari data Anda.
            valAC = snapshot.Child("AC").Value.ToString().Replace("\"", "");
            valDC = snapshot.Child("DC").Value.ToString().Replace("\"", "");
            valDiode = snapshot.Child("Diode").Value.ToString().Replace("\"", "");
            valOhms = snapshot.Child("Ohms").Value.ToString().Replace("\"", "");
            // Beri tahu Unity bahwa data siap ditampilkan
            isDataUpdated = true;
        }
    }
    // Unity hanya mengizinkan pembaruan UI di frame utama (Update)
    void Update()
    {
        if (isDataUpdated)
        {
            txtAC.text = "AC: " + valAC;
            txtDC.text = "DC: " + valDC;
            txtDiode.text = "Diode: " + valDiode;
            txtOhms.text = "Ohms: " + valOhms;
            // Matikan tanda agar tidak terus-menerus mengupdate UI tiap detik
            isDataUpdated = false;
        }
    }
    void OnDestroy()
    {
        // Membersihkan koneksi saat aplikasi ditutup agar tidak memori bocor
        if (dbReference != null)
        {
            dbReference.Child("Avometer").ValueChanged -= HandleValueChanged;
        }
    }
}