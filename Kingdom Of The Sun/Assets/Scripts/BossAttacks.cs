using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    bool BossActive = false;
    bool Attacking = false;
    int deurKeuze;

    GameObject deur1;
    GameObject deur2;
    GameObject deur3;
    GameObject deur4;
    GameObject deur5;

    void Start()
    {
        StartCoroutine(startBoss());
    }

    IEnumerator startBoss()
    {
        yield return new WaitForSeconds(1);
        BossActive = true;
        StartCoroutine(Slam());
        StartCoroutine(Spin());
        StartCoroutine(Train());
    }

    IEnumerator Slam()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(1); // cd
            if (Attacking == false) 
            {
                Attacking = true;
                //slam attack animatie
                yield return new WaitForSeconds(1); // attack animatie tijd
                Attacking = false;
            }
        }
    }

    IEnumerator Spin()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(1); // cd
            if (Attacking == false)
            {
                Attacking = true;
                //Spin attack animatie
                yield return new WaitForSeconds(1); // attack animatie tijd
                Attacking = false;
            }
        }
    }

    IEnumerator Train()
    {
        while (BossActive)
        {
            yield return new WaitForSeconds(1); // cd
            if (Attacking == false)
            {
                Attacking = true;
                //boss gaat weg zijn gat in animatie
                deurKeuze = Random.Range(0, 5);
                switch (deurKeuze) 
                {
                    case 1:
                        // spawn op deur 1
                        // runne deur 1 gaan gloeien
                        // dit model uit
                        break;
                    case 2:
                        // spawn op deur 2
                        // runne deur 2 gaan gloeien
                        // dit model uit
                        break;
                    case 3:
                        // spawn op deur 3
                        // runne deur 3 gaan gloeien
                        // dit model uit
                        break;
                    case 4:
                        // spawn op deur 4
                        // runne deur 4 gaan gloeien
                        // dit model uit
                        break;
                    case 5:
                        // spawn op deur 5
                        // runne deur 5 gaan gloeien
                        // dit model uit
                        break;
                }
            }
        }
    }

    public IEnumerator reappear()
    {
        // boss reappear animatie
        yield return new WaitForSeconds(1); // boss reappear animatie tijd
        StartCoroutine(startBoss());
    }
}
