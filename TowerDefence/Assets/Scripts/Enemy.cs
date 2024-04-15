using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    TileStatus currentTile, nextTile;
    int pathIndicator = 0;
    float t = 0;
    float moveTime = 1f;

    List<TileStatus> tilePath;

    Resource.Type type;

    private void Start()
    {
        tilePath = TileManager.instance.CreatePath();
        currentTile = tilePath[pathIndicator];
        nextTile = tilePath[pathIndicator+1];

        InitEnemy();
    }

    public void InitEnemy()
    {


        int which = Random.Range(0, 4);
        type = (Resource.Type)which;

        switch (type)
        {
            case Resource.Type.Meat:
                gameObject.GetComponent<SpriteRenderer>().sprite = EnemyManager.instance.meatE;
                break;
            case Resource.Type.Bone:
                gameObject.GetComponent<SpriteRenderer>().sprite = EnemyManager.instance.boneE;
                break;
            case Resource.Type.Potion:
                InitEnemy();
                break;
            case Resource.Type.Plutonium:
                gameObject.GetComponent<SpriteRenderer>().sprite = EnemyManager.instance.plutoniumE;
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {

        if (t > 0.99f)
        {
            t = 0;
            pathIndicator++;
            currentTile = nextTile;

            if (currentTile.isLast)
            {
                //When arriving the summon circle, destroy and start the level again.
                Destroy(gameObject);
                Timer.instance.StartAgain();
            }
            else
            {
                nextTile = tilePath[pathIndicator + 1];
            }
        }

        MoveEnemy();
    }

    public void MoveEnemy()
    {
        this.transform.position = Vector2.Lerp(currentTile.posReal, nextTile.posReal, t);
        t += Time.fixedDeltaTime/moveTime;
    }

    public void TakeHp(float amount)
    {
        Debug.Log(amount);
        hp -= amount;
        if (hp < 1)
        {
            ShootResource();
            Destroy(this.gameObject);
        }


    }

    public void ShootResource()
    {
        int deg = Random.Range(0, 360);
        Vector3 dir = (Quaternion.Euler(0f, 0f, deg) * new Vector2(0, 1)).normalized;
        GameObject resource = Instantiate(GameManager.instance.resourceDropped, (this.transform.position + dir) * 1, Quaternion.identity);
        resource.transform.parent = GameManager.instance.resourceMother.transform;
        resource.GetComponent<Resource>().InitThis(type);
    }
}
