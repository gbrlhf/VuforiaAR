using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wait : MonoBehaviour
{
    public float wait_time = 0; // Durasi tunggu dalam detik
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitBumper()); // Ganti 3f dengan durasi yang Anda inginkan
    }
    IEnumerator WaitBumper()
        {
        yield return new WaitForSeconds(wait_time); // Tunggu selama 3 detik
        SceneManager.LoadScene(1); // Ganti "NamaScene" dengan nama scene yang ingin Anda muat
    }


}
