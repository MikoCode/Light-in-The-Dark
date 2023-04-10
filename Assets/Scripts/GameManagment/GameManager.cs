using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool shootingDisabled;
    public UnityEngine.Rendering.Universal.Light2D playerLight;
    public int lighting;
    public int playerDamage;
    // Start is called before the first frame update
    private void Awake()
    {
        playerDamage = 1;
        lighting = 4;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
       

    }

    public void AddLighting(int light)
    {
        lighting += light;
        float addedLighting = light * 0.4f;
        playerLight.pointLightOuterRadius += addedLighting;
        if (playerLight.intensity < 0.9f)
        {
            playerLight.intensity += 0.3f;
        }
    }

   

    public void GameOver()
    {
       
            Debug.Log("GameOver");
        
    }

    public void TakeDamage( int damage)
    
    {
        lighting -= damage;
        if (playerLight.pointLightOuterRadius > 0.3f)
        {
            float addedLighting = damage * 0.4f;
            playerLight.pointLightOuterRadius -= addedLighting;
            if (lighting < 2)
            {
                playerLight.intensity -= 0.3f;
            }
        }
        if (lighting <= 0)
        {
            GameOver();
        }
    }


    
}
