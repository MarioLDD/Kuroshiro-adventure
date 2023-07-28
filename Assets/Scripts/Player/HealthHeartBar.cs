using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    //private HealthSystem healthSystem;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void Awake()
    {
        //healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        PlayerHealthBar.OnUpdateHealthBar += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerHealthBar.OnUpdateHealthBar -= DrawHearts;
    }
    private void Start()
    {
        //DrawHearts();
    }
    public void DrawHearts(int maxHealth, int currentHealth)
    {
        ClearHearts();

        float maxHealthRemainder = maxHealth % 4;
        int heartsToMake = (int)(maxHealth / 4 + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStausRemainder = (int)Mathf.Clamp(currentHealth - (i * 4), 0, 4);
            hearts[i].SetHeartImage((HeartStatus)heartStausRemainder);

        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}
