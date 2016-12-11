namespace DesignPatterns.Mediator
{
    public class Form : IForm
    {
        private readonly CheckBox m_NameRequieredCheckBox;
        private readonly TextBox m_NameTextBox;
        private readonly Button m_OkButton;

        public Form()
        {
            m_NameRequieredCheckBox = new CheckBox(this);
            m_NameTextBox = new TextBox(this);
            m_OkButton = new Button(this);
        }

        public void Refresh()
        {
            if (m_NameRequieredCheckBox.Checked)
            {
                m_NameTextBox.Enabled = true;
            }
            else
            {
                m_NameTextBox.Enabled = false;
                m_NameTextBox.Text = string.Empty;
            }

            if (m_NameRequieredCheckBox.Checked &&
                m_NameTextBox.IsEmpty())
            {
                m_OkButton.Enabled = false;
            }
        }
    }
}