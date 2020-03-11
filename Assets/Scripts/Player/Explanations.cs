using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explanations : MonoBehaviour
{
    public GameObject Panel;
    bool _isActivated;
    public Text textExplain;

    [Header("Explicações")]
    public string bulletExplanation = "Essa é a sua munição. Ela não é tão facil de ser encontrada, então use sua arma com o maximo de sabedoria.";
    public string appleSeedExplanation = "Semente de maça: Essencial para a sobrevivencia, é de vital importância você procurar por elas, elas revitaliza a sua estamina.";
    public string batteryExplanation = "As baterias servem para aumentar a intencidade da sua luz de auxilio.";

    void Start()
    {
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) ) {
            CloseExplain();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AppleSeed"))
        {
             textExplain.text = appleSeedExplanation;
            
            Panel.SetActive(true);
            _isActivated = true;
            if(_isActivated) {
                Time.timeScale = 0;
            }
        }

        if(collision.gameObject.CompareTag("Ammo +15"))
		{
            textExplain.text = bulletExplanation;
            
            Panel.SetActive(true);
            _isActivated = true;
            if(_isActivated) {
                Time.timeScale = 0;
            }
		}

        if(collision.gameObject.CompareTag("Battery"))
        {
            textExplain.text = batteryExplanation;
            
            Panel.SetActive(true);
            _isActivated = true;
            if(_isActivated) {
                Time.timeScale = 0;
            }
        }
    }

    public void CloseExplain () {
        textExplain.text = "";

        Panel.SetActive(false);
        Time.timeScale = 1;
        _isActivated = false;
    }

}
