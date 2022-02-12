using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Progressbar : MonoBehaviour
{
    public float max;
    public float min;
    public float value;
    public Image fill;

    void Update() => GetCurrentFill();

    void GetCurrentFill()
    {
        float currentOffset = value - min;
        float maximumOffset = max - min;
        float fillAmount = currentOffset / maximumOffset;
        fill.fillAmount = fillAmount;
    }
}