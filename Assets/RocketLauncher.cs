using UnityEngine;
using TMPro; 
using System.Collections;
//using System.Drawing.Printing;
using System.Diagnostics;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocket;     // Reference to the rocket model
    public float launchSpeed = 10f;   // Speed of the rocket launch
    public float launchHeight = 100f; // How high the rocket will go before deactivation

    public AudioSource launchSound;

    public float earthGravity = 9.81f;
    public float moonGravity = 1.62f;
    public float orbitHeightEarth = 300f;  // Arbitrary orbit height for Earth
    public float orbitHeightMoon = 50f;    // Arbitrary orbit height for Moon
    private bool isEarthGravity = true;  // True if Earth gravity, false if Moon
    private float remainingTime; 
    public TextMeshProUGUI timerText;

    private bool isLaunching = false; // State of the rocket (whether it's launching or not)
    private Vector3 startPosition;    // Initial position of the rocket

    void Start()
    {
        // Save the initial position of the rocket
        startPosition = rocket.transform.position;


        if (launchSound == null)
        {
            launchSound = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // If the rocket is in launching state, move it upwards
        if (isLaunching)
        {
            LaunchRocket();

            
        }

        
    }

    // This method will be triggered when the button is pressed
    public void OnLaunchButtonPressed()
    {
        if (!isLaunching)
        {
            if (launchSound != null)
            {
                launchSound.Play();
            }

            isLaunching = true; // Set the launching state to true

            float gravity = Physics.gravity.y;  // Получаем текущую гравитацию по оси Y
            float orbitHeight;

            if (Mathf.Approximately(gravity, -earthGravity))  // Если Земля
            {
                orbitHeight = orbitHeightEarth;
            }
            else if (Mathf.Approximately(gravity, -moonGravity))  // Если Луна
            {
                orbitHeight = orbitHeightMoon;
            }
            else
            {
                //Debug.LogWarning("Неизвестная гравитация: " + gravity);
                return;
            }

             // Рассчитываем время до выхода на орбиту (упрощенно, без учета ускорения)
            remainingTime = orbitHeight / launchSpeed;

            // Запускаем таймер
            StartCoroutine(CountdownTimer());
        }
    }

    void LaunchRocket()
    {
        // Move the rocket upwards
        rocket.transform.position += Vector3.up * launchSpeed * Time.deltaTime;

        float orbitHeight = Mathf.Approximately(Physics.gravity.y, -earthGravity) ? orbitHeightEarth : orbitHeightMoon;

        // Check if the rocket has reached the target height
        if (rocket.transform.position.y >= startPosition.y + launchHeight)
        {
            // Deactivate the rocket
            rocket.SetActive(false);
            isLaunching = false; // Stop the launching state
        }
    }

    IEnumerator CountdownTimer()
    {
        if (isLaunching) {
            
        }

        while (remainingTime > 0)
        {
            timerText.text = "Time to Orbit: " + remainingTime.ToString("F2") + "s";
            yield return new WaitForSeconds(1);
            remainingTime -= 1;
        }

        if (remainingTime == 0) timerText.text = "Rocket exited the orbit!";
    }

    // Reset the rocket back to its starting position and reactivate it
    public void ResetRocket()
    {
        rocket.transform.position = startPosition;
        rocket.SetActive(true);
        isLaunching = false;
        timerText.text = "";  // Сброс текста таймера
        remainingTime = -1;

        if (launchSound.isPlaying)
        {
            launchSound.Stop();
        }
    }
}
