
namespace CustomInput
{
    public class ButtonAxisInput : IAxisInput
    {
        public enum Mode
        {
            Positive,
            Negative,
        }

        private readonly IButtonInput m_button;
        private readonly ButtonAxisInput.Mode m_mode;

        public bool Positive
        {
            get
            {
                return m_mode==ButtonAxisInput.Mode.Positive;
            }
        }

        public ButtonAxisInput(IButtonInput button, ButtonAxisInput.Mode mode)
        {
            m_button = button;
            m_mode = mode;
        }

        public float AxisValue()
        {
            ButtonAxisInput.Mode mode = m_mode;
            if (mode == ButtonAxisInput.Mode.Positive)
            {
               return (float)((!m_button.GetButton()?0:1));
            }

            if (mode!=ButtonAxisInput.Mode.Negative)
            {
                return 0f;
            }
            return (float)((!m_button.GetButton())?0:-1);
        }

        public IButtonInput GetButtonInput()
        {
            return m_button;
        }

        
    }
}
