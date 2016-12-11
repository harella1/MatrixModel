using System;

namespace DesignPatterns.Mediator
{
    public class TextBox : Control
    {
        private string m_Text;

        public TextBox(IForm form)
            : base(form)
        {
        }

        public bool Enabled { get; set; }

        public string Text
        {
            get { return m_Text; }
            set
            {
                m_Text = value;
                Refresh();
            }
        }

        public bool IsEmpty()
        {
            return String.IsNullOrEmpty(m_Text);
        }
    }
}