using Microsoft.AspNetCore.Components.Forms;

namespace Hackathon_Team5_19_21.Shared
{
    public class InputSelectNumber<T> : InputSelect<T>
    {
        protected override bool TryParseValueFromString(string value, out T result, out string validationErrorMessage)
        {
            var typeOfT = typeof(T);
            if (typeOfT == typeof(int) || typeOfT == typeof(int?))
            {
                if (int.TryParse(value, out int resultInt))
                {
                    result = (T)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = "The chosen value is not a valid number.";
                    return false;
                }
            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}
