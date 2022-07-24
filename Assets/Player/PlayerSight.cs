using System.Collections;
using UnityEngine;

public class PlayerSight : MonoBehaviour
{
    // Start is called before the first frame update
    public float range = 100f;
    [Min(0)] public int maxBounces = 10;
    public BoolVariable eyesClosed;

    ArrayList lines = new ArrayList();
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
            RaycastHit2D hit = Physics2D.Raycast(origin, angle, 100);

            if (hit)
            {
                drawReflectedLine(origin, hit.point, color);
            }
            else
            {
                drawReflectedLine(origin, angle * range, color);
            }

            Debug.DrawRay(origin, angle * range, Color.red);

            if (hit.collider != null)
            {
                //not the best self-check...

                if (hit.collider.gameObject.TryGetComponent(out PlayerSight sight))
                {
                    Debug.Log("OWW");
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
        foreach (GameObject obj in lines)
            Destroy((GameObject)obj);
        lines.Clear();
    }
    public void drawReflectedLine(Vector2 start, Vector2 end, Color c)
    {
        GameObject child = new GameObject("Line");

        child.transform.parent = transform;
        LineRenderer line = child.AddComponent<LineRenderer>();
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.material = new Material(Shader.Find("Sprites/Default"));
        print("color: " + c);
        line.startColor = c;
        line.endColor = c;
        line.SetPositions(new Vector3[] { new Vector3(start.x, start.y, 0), new Vector3(end.x, end.y, 0) });
        lines.Add((GameObject)child);
        Destroy(child, 10);
    }
}

