using UnityEngine;
using UnityEngine.UI;

public class barravida : MonoBehaviour
{
    [SerializeField]private vida vidaplayer;
    [SerializeField]private Image totalbarravida;
    [SerializeField]private Image actualvida;

    private void Start()
    {
        totalbarravida.fillAmount=vidaplayer.actualvida/10;
    }
     private void Update()
     {
        actualvida.fillAmount=vidaplayer.actualvida/10;
    }

}
