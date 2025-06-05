using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    public static UIHandler instance { get; private set; }

    private VisualElement m_Healthbar;

   private void Awake()
   {
        instance = this;
   }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();

        // "Q" looks for a VisualElement 
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");

        SetHealthValue(1.0f);
    }

    // Resizes the health bar based on a percentage.
    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }
}