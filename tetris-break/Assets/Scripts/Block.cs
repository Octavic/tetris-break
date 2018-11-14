namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines a single block
    /// </summary>
    public class Block : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            this.transform.GetComponentInParent<BlockCollection>().OnDestroyBlock(this);
        }
    }
}
