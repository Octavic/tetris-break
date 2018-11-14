namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public class BlockCollection : MonoBehaviour
    {
        /// <summary>
        /// Size for the block collection
        /// </summary>
        public int SizeX;
        public int SizeY;

        public Matrix<Block> Blocks;

        /// <summary>
        /// Prefab for a single block
        /// </summary>
        public Block BlockPrefab;

        protected void Start()
        {
        }

        public void OnDestroyBlock(Block block)
        {
            bool found = false;
            for (int x = 0; x < this.SizeX && !found; x++)
            {
                var newList = new List<Block>();
                for (int y = 0; y < this.SizeY; y++)
                {
                    if (this.Blocks[x, y] == block)
                    {
                        this.Blocks[x, y] = null;
                        Destroy(block.gameObject);
                        found = true;
                    }
                }
            }
        }
    }
}
