using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class RoomSpawner : RoomTemplates
{
    [SerializeField]private GameObject[] sectionsPositions;
    private int currentSection = 1;
    private int chosenSection;
    private int exitSection;
    private void Start()
    {
        exitSection = Random.Range(1, 10);
        Debug.Log(exitSection);
        SectionSelector();
    }
    private void TileSpawner()
    {
        switch (currentSection)
        {
            case 1:
                if (currentSection != exitSection)
                {
                    Instantiate(section1[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else 
                {
                    Instantiate(section1Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 2:
                if (currentSection != exitSection)
                {
                    Instantiate(section2[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else
                {
                    Instantiate(section2Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 3:
                if (currentSection != exitSection)
                {
                    Instantiate(section3[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else
                {
                    Instantiate(section3Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 4:
                if (currentSection != exitSection)
                {
                    Instantiate(section4[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else
                {
                    Instantiate(section4Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 5:
                Instantiate(Entrance[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                currentSection += 1;
                SectionSelector();
                break;
            case 6:
                if (currentSection != exitSection)
                {
                    Instantiate(section6[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else
                {
                    Instantiate(section6Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 7:
                if (currentSection != exitSection)
                {
                    Instantiate(section7[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else
                {
                    Instantiate(section7Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 8:
                if (currentSection != exitSection)
                {
                    Debug.Log(chosenSection);
                    Debug.Log(currentSection);
                    Instantiate(section8[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
                else
                {
                    Instantiate(section8Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    SectionSelector();
                    break;
                }
            case 9:
                if (currentSection != exitSection)
                {
                    Debug.Log(chosenSection);
                    Debug.Log(currentSection);
                    Instantiate(section9[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    break;
                }
                else
                {
                    Instantiate(section9Exit[chosenSection], sectionsPositions[currentSection-1].transform.position, Quaternion.identity);
                    currentSection += 1;
                    break;
                }
        }

    }
    private void SectionSelector()
    {
        chosenSection = Random.Range(0,2);
        TileSpawner();
    }
}
