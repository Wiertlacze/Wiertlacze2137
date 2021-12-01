using System.Collections;
using UnityEngine;

public class Digging : MonoBehaviour
{
    public Transform player;
    public PlayerMovement pmove;
    bool busy = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") && !busy)
        {
            Collider[] detect = Physics.OverlapSphere(new Vector3(player.position.x + 1, player.position.y, -2), 0.01f);
            if (detect.Length != 0)
            {
                busy = true;
                if (detect[0].transform.parent.name == "BreakableGround")
                {
                    StartCoroutine(Fade(detect[0]));
                }
            }
        }
        else if (Input.GetKey("a") && !busy)
        {
            Collider[] detect = Physics.OverlapSphere(new Vector3(player.position.x - 1, player.position.y, -2), 0.01f);
            if (detect.Length != 0)
            {
                busy = true;
                if (detect[0].transform.parent.name == "BreakableGround")
                {
                    StartCoroutine(Fade(detect[0]));
                }
            }
        }
        else if (Input.GetKey("s") && !busy)
        {
            Collider[] detect = Physics.OverlapSphere(new Vector3(player.position.x, player.position.y - 1, -2), 0.01f);
            if (detect.Length != 0)
            {
                busy = true;
                if (detect[0].transform.parent.name == "BreakableGround")
                {
                    StartCoroutine(Fade(detect[0]));
                }
            }
        }
    }
}
