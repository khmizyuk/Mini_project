// using UnityEngine;

// public class DayNightCycle : MonoBehaviour
// {
//     public Light sunLight;                 // The sun (directional light)
//     public float dayLength = 60f;          // Duration of a full day (in seconds)
//     public Color dayColor = Color.white;   // Light color during the day
//     public Color nightColor = Color.blue;  // Light color during the night

//     private float timeOfDay = 0f;

//     void Update()
//     {
//         // Rotate the sun to simulate day-night cycle
//         timeOfDay += Time.deltaTime / dayLength;
//         float angle = Mathf.Lerp(0, 360, timeOfDay);
//         sunLight.transform.rotation = Quaternion.Euler(angle, 0, 0);

//         // Change light color based on the angle (sunset/sunrise simulation)
//         sunLight.color = Color.Lerp(nightColor, dayColor, Mathf.InverseLerp(180, 360, angle));

//         // Reset timeOfDay to start a new cycle
//         if (timeOfDay >= 1f)
//         {
//             timeOfDay = 0f;
//         }
//     }
// }

using UnityEngine;
using UnityEngine.UI; // Не забудьте добавить этот using для работы с UI

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight;          // Один Directional Light
    public Color dayColor = Color.white;    // Цвет дневного света
    public Color nightColor = Color.blue;   // Цвет ночного света
    public float dayIntensity = 1f;         // Яркость дневного света
    public float nightIntensity = 0.2f;     // Яркость ночного света
    public float transitionSpeed = 0.5f;    // Скорость перехода между днем и ночью

    private bool isDay = true;              // Флаг, указывающий, день ли сейчас
    private float currentIntensity;          // Текущая яркость света
    private Color currentColor;              // Текущий цвет света

    void Start()
    {
        // Инициализация текущих значений
        currentIntensity = dayIntensity;
        currentColor = dayColor;
        directionalLight.color = currentColor;
        directionalLight.intensity = currentIntensity;
    }

    void Update()
    {
        // Плавное изменение цвета и интенсивности света
        directionalLight.color = Color.Lerp(directionalLight.color, currentColor, transitionSpeed * Time.deltaTime);
        directionalLight.intensity = Mathf.Lerp(directionalLight.intensity, currentIntensity, transitionSpeed * Time.deltaTime);
    }

    // Метод для переключения на день
    public void SetDay()
    {
        isDay = true;
        currentColor = dayColor;
        currentIntensity = dayIntensity;
    }

    // Метод для переключения на ночь
    public void SetNight()
    {
        isDay = false;
        currentColor = nightColor;
        currentIntensity = nightIntensity;
    }
}

