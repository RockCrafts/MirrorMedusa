using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    // Start is called before the first frame update
    public float range = 100f;
    [Min(0)] public int maxBounces = 10;
    public BoolVariable eyesClosed;
    public GameEvent deathEvent;
    public GameObject laserHitEffect;
    private List<LineRenderer> lines = new List<LineRenderer>();
    private int nextLine;
    [SerializeField]
    private LineRenderer lineTemplate;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hideReflectedLine();
        if (!eyesClosed.value)
        {
            sightCheck(transform.position, transform.up);
        }
        //seeable afterwords
        this.gameObject.layer = 3;
    }
    void sightCheck(Vector2 origin, Vector2 angle)
    {
        int itr = 0;
        //prevents hitting self with initial gaze
        this.gameObject.layer = 2;
        Color color = Color.white;
        while (itr <= maxBounces)
        {
            //cast the ray
            RaycastHit2D hit = Physics2D.Raycast(origin, angle, range);
            if (hit)
            {
                drawReflectedLine(origin, hit.point, color, itr);
            }
            else
            {
                drawReflectedLine(origin, origin + angle * range, color, itr);
               // Debug.Log("No Hit: " + angle*range);
            }
            Debug.DrawRay(origin, angle * range, Color.red);

            if (hit.collider != null)
            {
                //not the best self-check...

                if (hit.collider.gameObject.TryGetComponent(out PlayerSight sight))
                {
                    Debug.Log("OWW");
                    deathEvent.Invoke();
                    //die
                }

                // if (hit.collider.gameObject.TryGetComponent(out Seeable seeable)) {
                //     seeable.whenSeen.Invoke(color);
                // }

                if (hit.collider.gameObject.TryGetComponent(out Mirror mirror))
                {
                    if (mirror.isActiveAndEnabled)
                    {
                        //reflect light. Color stuff will probably go here too
                        origin = hit.point + hit.normal * 0.01f;
                        angle = Vector2.Reflect(angle, hit.normal);
                        color = mirror.ReflectColor(color);
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
            itr++;
            //now you can self-hit
            this.gameObject.layer = 3;
        }
    }
    public void hideReflectedLine()
    {
        foreach (LineRenderer l in lines)
        {
            l.enabled = false;
        }
        nextLine = 0;
    }
    public void drawReflectedLine(Vector2 start, Vector2 end, Color c, int itr)
    {
        GameObject child;
        LineRenderer line;
        if (nextLine >= lines.Count)
        {
            child = Instantiate(lineTemplate.gameObject, transform);
            line = child.GetComponent<LineRenderer>();
            lines.Add(line);
        } else
        {
            line = lines[nextLine];
        }
        nextLine++;
        //child.transform.parent = transform;
        // Destroy(Instantiate(laserHitEffect, end, Quaternion.identity), 0.1f);


        //line.startWidth = 0.1f;
        //line.endWidth = 0.1f;
        //line.material = new Material(Shader.Find("Sprites/Default"));
        //print("color: " + c);
        line.enabled = true;
        line.startColor = c;
        line.endColor = c;
        line.numCapVertices = 20;
        line.SetPositions(new Vector3[] { new Vector3(start.x, start.y, itr/10), new Vector3(end.x, end.y, itr/10) });
        //Destroy(child, 10);
    }
}

