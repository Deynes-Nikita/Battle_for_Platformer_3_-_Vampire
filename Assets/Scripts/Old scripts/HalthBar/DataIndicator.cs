using UnityEngine;

public class DataIndicator : MonoBehaviour
{
    [SerializeField] protected Character Character;

    private void OnEnable()
    {
        Character.HealthChanged += UpdateData;
        Character.Movement.Turned += Reflect;
    }

    private void OnDisable()
    {
        Character.HealthChanged -= UpdateData;
        Character.Movement.Turned -= Reflect;
    }

    protected virtual void UpdateData(float value, float maxValue) { }

    private void Reflect()
    {
        transform.rotation = Quaternion.identity;
    }
}
