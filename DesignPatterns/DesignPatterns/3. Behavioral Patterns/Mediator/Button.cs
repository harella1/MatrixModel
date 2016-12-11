namespace DesignPatterns.Mediator
{
    public class Button : Control
    {
        public Button(IForm form)
            : base(form)
        {
        }

        public bool Enabled { get; set; }
    }
}