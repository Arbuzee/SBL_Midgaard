using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalController : MonoBehaviour
{
    public GameObject journal;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;


    public GameObject[] objects;
    private int i = 0;

    public bool[] itemFound;

    public Color white;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (journal.activeSelf) {
                journal.SetActive(false);
            } else {
                journal.SetActive(true);
            }
        }

        objects[i].GetComponent<Image>().enabled = false;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            i--;
            if(i < 0)
            {
                i = itemFound.Length - 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            i++;
            if (i > itemFound.Length - 1)
            {
                i = 0;
            }
        }
        objects[i].GetComponent<Image>().enabled = true;


        if (i == 0 && itemFound[i])
        {
            titleText.text = "Drakhuvud";
            descText.text = "Syftet med drakhuvudet var att skrämma befolkningen på land. När skeppet var på väg in mot land ylade och skrek vikingarna.";
        }
        else if (i == 1 && itemFound[i])
        {
            titleText.text = "Skepp";
            descText.text = "Det fanns olika typer av skepp; det vanligaste skeppet kallades för långskepp. Om det hade ett djurhuvud i fören kallades det för drakskepp. Skeppen behövde fler än 20 män för att ro. De hade bara ett stort segel som kunde monteras ner vid oväder eller för att smyga sig in vid kusten.";
        }
        else if (i == 2 && itemFound[i])
        {
            titleText.text = "Ting";
            descText.text = "Varje höst och vår hölls ett rådslag som kallades för ting, vilket pågick en vecka. Man betalade skatt, bestämde olika göromål för det kommande året och redde ut olika konflikter. Vem som helst, man som kvinna, kunde lägga fram sina åsikter och problem under tinget.";
        }
        else if (i == 3 && itemFound[i])
        {
            titleText.text = "Envig";
            descText.text = "Envig var en tvekamp där varje kämpe fick, förutom en yxa eller ett svärd, tre sköldar var. Om man skadades så blod spilldes kunde man dra sig ur, men då förlorade man.  I allmänhet ansågs det förbjudet att avbryta en påbörjad envig, var och när den än ägde rum.";
        }
        else if (i == 4 && itemFound[i])
        {
            titleText.text = "Långhus";
            descText.text = "I detta hus bodde vanligen en hel gårds befolkning, bonden med familj och lite släkt, kanske några fler. I de äldre långhusen bodde djur och människor under samma tak.";
        }
        else if (i == 5 && itemFound[i])
        {
            titleText.text = "Mat";
            descText.text = "Fisk var den kost man åt till vardags. Man torkade eller saltade oftast fisken och smaksatte den vid måltiden med olika kryddor. Frukter och vilda bär samlades in under sommaren och torkades för att smaksätta måltider under höst och vinter.";
        }
        else if (i == 6 && itemFound[i])
        {
            titleText.text = "Mjöd";
            descText.text = "Mjöd var ett slags öl som bestod av honung, vatten, skogshumle och malt. Vikingarna var också mycket förtjusta i vin, men det importerades alltid från andra länder.";
        } else
        {
            titleText.text = "Okänd artefakt";
            descText.text = "Du har ännu inte hittat den här artefakten.";
        }
    }

    public void ChangeIconColor(int x)
    {
        objects[x].GetComponent<PanelItem>().icon.GetComponent<Image>().color = white;
    }
}
