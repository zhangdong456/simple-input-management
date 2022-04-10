
namespace CustomInput
{
    public class LogicInput 
    {
        public static float HorizontalValue;

        public static float VerticalValue;

        public static int HorizontalDigiPadValue;

        public static int VerticalDigiPadValue;

        public static int NormalizedHorizontal
        {
            get
            {
                if (LogicInput.HorizontalValue< -0.4f)
                {
                    return -1;
                }

                if (LogicInput.HorizontalValue> 0.4f)
                {
                    return 1;
                }

                return 0;
            }
        }
        public static float NormalizedVertical
        {
            get
            {
                if (LogicInput.VerticalValue < -0.6f)
                {
                    return -1f;
                }
                if (LogicInput.VerticalValue > 0.6f)
                {
                    return 1f;
                }
                return 0f;
            }
        }

        public static InputButtonProcessor Down = new InputButtonProcessor();
        public static InputButtonProcessor Up = new InputButtonProcessor();
        public static InputButtonProcessor Left = new InputButtonProcessor();
        public static InputButtonProcessor Right = new InputButtonProcessor();
        public static InputButtonProcessor Jump = new InputButtonProcessor();
        public static InputButtonProcessor LeftStick = new InputButtonProcessor();
        public static InputButtonProcessor RightStick = new InputButtonProcessor();
        public static InputButtonProcessor Cancel = new InputButtonProcessor();
        public static InputButtonProcessor Attack = new InputButtonProcessor();
        public static InputButtonProcessor ChangeSkill = new InputButtonProcessor();

    }
}