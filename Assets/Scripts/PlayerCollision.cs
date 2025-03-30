using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
        public int             score = 0;
        public TextMeshProUGUI scoreTextUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
            Debug.Log("PlayerCollision.OnTriggerEnter was called with: " + other.gameObject.name);

            if (other.gameObject.CompareTag("Collectible"))
            {
                    score++;
                    Debug.Log("Collected! Current Score: " + score);
                    if (scoreTextUI != null)
                    {
                            scoreTextUI.text = "Score: " + score.ToString();
                    }
                    Destroy(other.gameObject);
            }
    }
}
