namespace DesignPatterns.Iterator
{
    public class Node
    {
        private Node m_Left;
        private Node m_Right;
        public Node Parent { get; private set; }

        public Node Left
        {
            get { return m_Left; }
            set
            {
                m_Left = value;
                m_Left.Parent = this;
            }
        }

        public Node Right
        {
            get { return m_Right; }
            set
            {
                m_Right = value;
                m_Right.Parent = this;
            }
        }

        public string Value { get; set; }
    }
}