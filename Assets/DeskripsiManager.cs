using UnityEngine;

public class DeskripsiManager : MonoBehaviour
{
    public static DeskripsiManager Instance;

    private GameObject currentOpen = null;

    void Awake()
    {
        Instance = this;
    }

    public void Toggle(GameObject deskripsi)
    {
        // Kalau panel yang diklik sudah terbuka ? tutup saja
        if (currentOpen == deskripsi)
        {
            deskripsi.SetActive(false);
            currentOpen = null;
            return;
        }

        // Tutup panel yang sedang terbuka (kalau ada)
        if (currentOpen != null)
        {
            currentOpen.SetActive(false);
        }

        // Buka panel baru
        deskripsi.SetActive(true);
        currentOpen = deskripsi;
    }
}