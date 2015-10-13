//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Tile.cs" company="Sascha Schwarzlose">
//    copyright 2014 by Sascha Schwarzlose
//  </copyright>
//  <summary>
//    TODO
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------
namespace Assets.Scripts
{

    using UnityEngine;
    using UnityEngine.UI;

    public class Tile : MonoBehaviour
    {
        public GameObject SpriteOk;
        public GameObject SpriteWrong;
        public Vector2 Position { get; set; }

        public bool isInRightPlace;

        public Vector3 NewPosition;

        private Vector3 origin;
        public string Type { get; set; }

        private Vector2 offset;

        public GameObject[] Anchors;
        private GameObject target;

        public Text TooltipText;

        private bool anchorPosition = false;
        private bool isDragable;

        void Start()
        {
            this.isDragable = true;
            this.origin = this.transform.position;
            
            this.Anchors = GameObject.FindGameObjectsWithTag(Tags.Anchor);
            if(TooltipText != null)
                this.TooltipText.GetComponent<Text>();

            
        }

        void OnMouseDown()
        {  
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);
            if (isDragable && SpriteWrong.GetComponent<SpriteRenderer>().enabled)
            {
                SpriteWrong.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        void OnMouseUp()
        {
            if (isDragable)
            {
                if (!anchorPosition)
                {
                    transform.position = Vector2.Lerp(Position, this.origin, 1);
                }
                else
                {
                    transform.position = NewPosition;
                    LessonEventController.Instance.OnTilePlaced(this, target);
                    if (isInRightPlace)
                    {
                        this.isDragable = false;
                        SpriteWrong.GetComponent<SpriteRenderer>().enabled = false;
                        SpriteOk.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        SpriteOk.GetComponent<SpriteRenderer>().enabled = false;
                        SpriteWrong.GetComponent<SpriteRenderer>().enabled = true;
                    }
                }
            }
        }

        void OnMouseDrag()
        {
            if(this.isDragable)
            {
                Vector2 curScreenPoint = (Vector2)Input.mousePosition;

                Position = (Vector2)Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = Position;

                foreach (GameObject anchor in this.Anchors)
                {
                    if (gameObject.GetComponent<Collider2D>().OverlapPoint(anchor.transform.position))
                    {
                        anchorPosition = true;
                        target = anchor;
                        NewPosition = anchor.transform.position;
                        NewPosition.z = -0.2f;
                        break;
                    }
                    else anchorPosition = false;
                }
            }
        }

        private void OnMouseOver()
        {
            if (TooltipText != null)
            {
                this.TooltipText.rectTransform.position = Camera.main.WorldToScreenPoint(this.transform.position);
                this.TooltipText.text = this.name;
                this.TooltipText.enabled = !Input.GetMouseButton(0);
            }

            this.GetComponent<Renderer>().material.color = Color.green;
        }

        void OnMouseExit()
        {
            if(TooltipText != null)
                this.TooltipText.enabled = false;

            this.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}