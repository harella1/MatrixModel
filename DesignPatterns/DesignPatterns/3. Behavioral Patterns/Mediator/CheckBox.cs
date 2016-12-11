namespace DesignPatterns.Mediator
{
    public class CheckBox : Control
    {
        private bool m_Checked;

        public CheckBox(IForm form)
            : base(form)
        {
        }

        public bool Checked
        {
            get { return m_Checked; }
            set
            {
                m_Checked = value;
                Refresh();
            }
        }
    }
}