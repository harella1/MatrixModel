using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    public class BreadthFirstTree : BaseTree
    {
        public BreadthFirstTree(Node root) 
            : base(root)
        {
        }

        public override IEnumerator<Node> GetEnumerator()
        {
            return new BreadthFirstIterator(Root);
        }
    }
}