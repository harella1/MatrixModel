using System;
using System.Collections.Generic;

namespace DesignPatterns.Memento
{
    public class Caretaker
    {
        private readonly TextBox m_TextBox;
        private readonly Stack<IMemento> m_UndoStack;

        public Caretaker(TextBox textBox)
        {
            m_TextBox = textBox;
            m_UndoStack = new Stack<IMemento>();
        }

        public void Snapshot()
        {
            IMemento memento = m_TextBox.CreateMemento();
            m_UndoStack.Push(memento);
        }

        public void Undo()
        {
            if (!CanUndo()) throw new InvalidOperationException("Undo stack is empty.");
            IMemento memento = m_UndoStack.Pop();
            m_TextBox.ApplyMemento(memento);
        }

        private bool CanUndo()
        {
            return m_UndoStack.Count != 0;
        }
    }
}