using UnityEngine;
using TMPro;


public class FPSShow : MonoBehaviour
{
        private TextMeshProUGUI textMesh;


        void Start()
        {
            textMesh= GetComponent<TextMeshProUGUI>();

            InvokeRepeating(nameof(FpsCalculator), 0, 1);
        }

        private void FpsCalculator()
        {
            textMesh.text = (1f / Time.deltaTime).ToString("FPS: 00");
        }
}
