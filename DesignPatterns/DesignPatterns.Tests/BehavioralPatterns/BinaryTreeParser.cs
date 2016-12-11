using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns.Iterator;

namespace DesignPatterns.Tests.BehavioralPatterns
{
    public class BinaryTreeParser
    {
        private readonly Node m_Root;
        private readonly Stack<Node> m_Stack1;
        private readonly Stack<Node> m_Stack2;
        private readonly StringBuilder m_ValueBuffer;

        //          (ROOT)
        //          /    \
        //        (A)    (B)
        //        / \     /
        //      (C) (D)  (E)
        private BinaryTreeParser()
        {
            m_ValueBuffer = new StringBuilder();
            m_Stack1 = new Stack<Node>();
            m_Stack2 = new Stack<Node>();
            m_Root = new Node();
            m_Stack1.Push(m_Root);
        }

        public static Node Parse(string tree)
        {
            var parser = new BinaryTreeParser();
            foreach (char ch in tree)
            {
                switch (ch)
                {
                    case '(':
                        parser.StartNode();
                        break;
                    case ')':
                        parser.EndNode();
                        break;
                    case '/':
                        parser.AddLeft();
                        break;
                    case '\\':
                        parser.AddRight();
                        break;
                    default:
                        if (char.IsLetterOrDigit(ch))
                        {
                            parser.m_ValueBuffer.Append(ch);
                        }
                        break;
                }
            }
            return parser.m_Root;
        }

        private void AddRight()
        {
            Node top = m_Stack2.Peek();
            if (top.Right != null)
            {
                m_Stack2.Pop();
            }
            Node current = m_Stack2.Peek();

            var right = new Node();
            current.Right = right;
            m_Stack1.Push(right);
        }

        private void AddLeft()
        {
            Node top = m_Stack2.Peek();
            if (top.Left != null)
            {
                m_Stack2.Pop();
            }
            Node current = m_Stack2.Peek();

            var left = new Node();
            current.Left = left;
            m_Stack1.Push(left);
        }

        private void EndNode()
        {
            Node node = m_Stack1.Pop();
            node.Value = m_ValueBuffer.ToString();
            ResetBuffer();
            m_Stack2.Push(node);
        }

        private void ResetBuffer()
        {
            m_ValueBuffer.Length = 0;
        }

        private void StartNode()
        {
            if (m_ValueBuffer.Length != 0) throw new InvalidOperationException(") is expected.");
        }
    }
}