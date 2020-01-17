using UnityEngine;

public class SpawnCountAdd : MonoBehaviour
{
    public int spawnCount;
    private void OnTriggerEnter(Collider other) //kui vastane "sünnib" siis...
    {
        spawnCount += 1;                            //lisab kogu vastaste "sündimisele" ühe juurde, tänu sellele saab iga 10 vastase tagant...
    }                                               //...teha pausi, et mängija saaks natuke aega(2.5s/3s/3.5s) mõelda ja puhata
}
