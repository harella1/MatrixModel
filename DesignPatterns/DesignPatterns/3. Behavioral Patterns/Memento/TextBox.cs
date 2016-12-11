using System;

namespace DesignPatterns.Memento
{
    public class TextBox
    {
        private int m_CaretPostition;
        private Selection m_Selection;
        private string m_Text;

        public TextBox()
        {
            Text = String.Empty;
        }

        public string Text
        {
            get { return m_Text; }
            set
            {
                m_Text = value;
                m_CaretPostition = 0;
                m_Selection = Selection.Empty;
            }
        }

        public int CaretPostition
        {
            get { return m_CaretPostition; }
        }


        public Selection Selection
        {
            get { return m_Selection; }
        }

        public IMemento CreateMemento()
        {
            return new TextBoxMemento(Text, CaretPostition, Selection);
        }

        public void MoveCaretBy(int offset)
        {
            m_CaretPostition = GetTrimmedValue(CaretPostition + offset, 0, Text.Length);
        }

        public void MoveCaretTo(int position)
        {
            m_CaretPostition = GetTrimmedValue(position, 0, Text.Length);
        }

        private int GetTrimmedValue(int suggestedValue, int minValue, int maxValue)
        {
            if (suggestedValue < minValue) return minValue;
            if (suggestedValue > maxValue) return maxValue;
            return suggestedValue;
        }

        public void Select(Selection selection)
        {
            int start = GetTrimmedValue(selection.Start, 0, Text.Length);
            int length = GetTrimmedValue(selection.Length, 0, Text.Length - start);
            m_Selection = new Selection(start, length);
        }

        public void ApplyMemento(IMemento memento)
        {
            if (memento == null) throw new ArgumentNullException("memento");
            TextBoxMemento textBoxMemento;
            try
            {
                textBoxMemento = (TextBoxMemento) memento;
            }
            catch (InvalidCastException ex)
            {
                throw new IncompatibleMementoException(
                    string.Format(
                        "Only memento of type [{0}] be applied to [{1}] ",
                        memento.GetType(),
                        GetType()),
                    ex);
            }
            Text = textBoxMemento.Text;
            MoveCaretTo(textBoxMemento.CaretPostition);
            Select(textBoxMemento.Selection);
        }

        public override string ToString()
        {
            string line1 = Text;
            var line2 = new char[Text.Length];
            for (int i = 0; i < Text.Length; i++)
            {
                line2[i] =
                    Selection.Includes(i)
                        ? '█'
                        : ' ';
            }
            line2[CaretPostition] = '▲';
            return String.Concat(line1, Environment.NewLine, new string(line2));
        }

        private class TextBoxMemento : IMemento
        {
            private static int s_UniqueIdCounter = 1;
            private readonly int m_CaretPostition;
            private readonly Selection m_Selection;
            private readonly string m_Text;

            private readonly int m_UniqueId;

            protected internal TextBoxMemento(string text, int caretPostition, Selection selection)
            {
                m_Text = text;
                m_CaretPostition = caretPostition;
                m_Selection = selection;
                s_UniqueIdCounter++;
                m_UniqueId = s_UniqueIdCounter;
            }

            public string Text
            {
                get { return m_Text; }
            }

            public int CaretPostition
            {
                get { return m_CaretPostition; }
            }

            public Selection Selection
            {
                get { return m_Selection; }
            }

            public string GetDescription()
            {
                return
                    string.Format(
                        "Step: '{0}'; Caret: {1}; Selection:{2}-{3}",
                        m_UniqueId,
                        CaretPostition,
                        Selection.Start,
                        Selection.Length);
            }
        }
    }
}