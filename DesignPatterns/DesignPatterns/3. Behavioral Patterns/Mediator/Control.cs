namespace DesignPatterns.Mediator
{
    public abstract class Control
    {
        private readonly IForm m_Form;

        protected Control(IForm form)
        {
            m_Form = form;
        }

        protected void Refresh()
        {
            m_Form.Refresh();
        }
    }
}