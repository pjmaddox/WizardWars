using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject healthSliderPrefab;
    public GameObject parentPanel;

    public Vector2 UIOffsetValues;

    private GameObject healthUI;
    private Image thisHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hit parent Start()");
        currentHealth = maxHealth;
        Debug.Log(Camera.main.WorldToScreenPoint(transform.position));
        Debug.Log(Camera.main.WorldToScreenPoint(transform.position));
        healthUI = Instantiate(healthSliderPrefab, parentPanel.transform, true) as GameObject;
        RectTransform rt = healthUI.GetComponent<RectTransform>();

        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, (Camera.main.WorldToScreenPoint(transform.position)).x + UIOffsetValues.x, 10f);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, (Camera.main.WorldToScreenPoint(transform.position)).y + UIOffsetValues.y, 2);
        Image[] childImages = healthUI.GetComponentsInChildren<Image>();
        for (int i = 0; i < childImages.Length; i++) {
            if (childImages[i].name == "Redness")
            {
                childImages[i].fillAmount = currentHealth / maxHealth;
                thisHealthBar = childImages[i];
            }
        }
       

    }

    void Update()
    {
        Debug.Log(Camera.main.WorldToScreenPoint(transform.position));
        thisHealthBar.fillAmount = currentHealth / maxHealth;
        RectTransform rt = healthUI.GetComponent<RectTransform>();
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, (Camera.main.WorldToScreenPoint(transform.position)).x + UIOffsetValues.x, 10f);
        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, (Camera.main.WorldToScreenPoint(transform.position)).y + UIOffsetValues.y, 2);
    }

    public void TakeDamage(float amount)
    {
        ChangeHealth(-amount);
    }

    public void Heal(float amount)
    {
        ChangeHealth(amount);
    }

    public virtual void ChangeHealth(float delta)
    {
        this.currentHealth += delta;
        DestroyOnDeath();
    }

    public virtual void DestroyOnDeath()
    {
        if(this.currentHealth <= 0) 
        {
            Debug.Log($"{this.gameObject.name} has been destroyed!");
            Destroy(this.gameObject);
        }
    }
}
