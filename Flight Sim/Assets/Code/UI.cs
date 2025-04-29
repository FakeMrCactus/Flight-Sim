using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{

    public TextMeshProUGUI SpeedText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float playerspeed = GameObject.Find("Player").GetComponent<PlayerController>().curSpeed;

        SpeedText.text = "speed: " + Mathf.Floor(playerspeed);
    }
}
