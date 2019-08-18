
public class Turn
{
    public struct Result
    {
        public ushort m_CorrectInPlaceUshort;
        public ushort m_CorrectMisplaceUshort;
    }
    private string m_guess;
    private Result m_result;



    public Result PinResult
    {
        get
        {
            return m_result;
        }
        set
        {
            if (value.m_CorrectInPlaceUshort + value.m_CorrectMisplaceUshort <= 4)
            {
                m_result = value;
            }
        }
    }
    public string Guess
    {
        get
        {
            return m_guess;
        }
        set
        {
            m_guess = value;
        }
    }
}


