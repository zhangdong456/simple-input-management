
namespace CustomInput
{
    public interface IButtonInput
    {
        bool GetButton();
    }

    public interface IAxisInput
    {
        float AxisValue();
    }
}
