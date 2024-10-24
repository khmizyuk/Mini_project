using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CubeVerticalMoverWithInteraction : XRGrabInteractable
{
    public float moveSpeed = 1.0f;  // Скорость вертикального перемещения
    private bool isGrabbed = false;  // Состояние захвата
    private XRBaseInteractor currentInteractor;  // Текущий интерактор (кто держит объект)

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        isGrabbed = true;  // Флаг, что объект захвачен
        currentInteractor = interactor;  // Сохранить, кто держит объект
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        isGrabbed = false;  // Флаг, что объект больше не захвачен
        currentInteractor = null;  // Очистить интерактор
    }

    void Update()
    {
        // Если куб захвачен
        if (isGrabbed && currentInteractor != null)
        {
            // Здесь можно использовать ось движения из тачпада для движения вверх/вниз
            // Например, ось Y или вертикальное движение на тачпаде
            float verticalInput = Input.GetAxis("Vertical");  // Получить значение по вертикальной оси (тачпад)

            if (verticalInput != 0)
            {
                MoveCube(verticalInput);
            }
        }
    }

    // Метод для перемещения куба вверх/вниз
    private void MoveCube(float verticalInput)
    {
        // Перемещать куб вверх или вниз в зависимости от input
        transform.position += Vector3.up * verticalInput * moveSpeed * Time.deltaTime;
    }
}
