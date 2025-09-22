using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coin_contador : MonoBehaviour
{
    public static coin_contador instance;

    public int coinCount = 0;
    public TMP_Text coinText; // Arrastra tu TextMeshPro aquí en el inspector

    private void Awake()
    {
        // Singleton para que haya solo un GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = "coin: " + coinCount;
    }
}