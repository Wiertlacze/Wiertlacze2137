using System.Collections;
using UnityEngine;

public class Digging : MonoBehaviour
{
    public Transform player;
    public PlayerMovement pmove;
    public bool busy = false;
    public Item Copper;
    public Item Tin;
    public Item Iron;
    IEnumerator Fade(Collider digged)
    {
        pmove.enabled = false;
        Color c = digged.gameObject.GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            digged.gameObject.GetComponent<Renderer>().material.color = c;
            digged.gameObject.GetComponent<Renderer>().material.shader = Shader.Find("Transparent/Diffuse");
            yield return new WaitForSeconds(0.1f);
        }

        Destroy(digged.gameObject);
        pmove.enabled = true;
        busy = false;

        int first = digged.name.IndexOf("Tile");
        digged.name = digged.name.Substring(0,first);
        Debug.Log(digged.name);
        switch(digged.name)
        {
            case "Iron":
                Inventory.instance.Add(Iron);
                break;
            case "Copper":
                Inventory.instance.Add(Copper);
                break;
            case "Tin":
                Inventory.instance.Add(Tin);
                break;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && Input.GetKey("space") && !busy)
        {
            Collider[] detect = Physics.OverlapSphere(new Vector3(player.position.x + 1, player.position.y, -2), 0.01f);
            if (detect.Length != 0)
            {
                if (detect[0].transform.parent.name == "BreakableGround")
                {
                    busy = true;
                    StartCoroutine(Fade(detect[0]));
                }
            }
        }
        else if (Input.GetKey("a") && Input.GetKey("space") && !busy)
        {
            Collider[] detect = Physics.OverlapSphere(new Vector3(player.position.x - 1, player.position.y, -2), 0.01f);
            if (detect.Length != 0)
            {
                if (detect[0].transform.parent.name == "BreakableGround")
                {
                    busy = true;
                    StartCoroutine(Fade(detect[0]));
                }
            }
        }
        else if (Input.GetKey("s") && Input.GetKey("space") && !busy)
        {
            Collider[] detect = Physics.OverlapSphere(new Vector3(player.position.x, player.position.y - 1, -2), 0.01f);
            if (detect.Length != 0)
            {
                if (detect[0].transform.parent.name == "BreakableGround")
                {
                    busy = true;
                    StartCoroutine(Fade(detect[0]));
                }
            }
        }
    }

    // void PickUp(GameObject digged)
    // {
    //     
    //     // GameObject digged = new GameObject();
    //     // digged = diggedGameObject;
    //     name = digged.name;
    //     Debug.Log("adding " + name + " to inventory");
        
        // Debug.Log("digged " + digged);

        // item.name = name;
        // item.icon = null;
        // item.isDefaultItem = true;
        // Inventory.instance.Add(item);

        //Add to inv

    // }
}
