using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class DepthFirstTree : BaseTree
    {
        public DepthFirstTree(Node root) 
            : base(root)
        {
        }

        public override IEnumerator<Node> GetEnumerator()
        {
            return new DepthFirstIterator(Root);
        }
    }
}