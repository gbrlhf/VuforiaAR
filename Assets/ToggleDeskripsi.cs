using UnityEngine;

public class ToggleDeskripsi : MonoBehaviour
{
    public GameObject deskripsi;

    public void Toggle()
    {
        // Delegasikan ke Manager, bukan handle sendiri
        DeskripsiManager.Instance.Toggle(deskripsi);
    }
}