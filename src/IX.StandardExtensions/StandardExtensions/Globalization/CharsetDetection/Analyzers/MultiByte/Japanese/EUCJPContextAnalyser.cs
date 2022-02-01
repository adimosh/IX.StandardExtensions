#pragma warning disable SA1633 // File should have header - This is an imported file,

// original header with license shall remain the same

namespace UtfUnknown.Core.Analyzers.Japanese;

internal class EUCJPContextAnalyser : JapaneseContextAnalyser
{
    private const byte HIRAGANA_FIRST_BYTE = 0xA4;

    protected override int GetOrder(
        byte[] buf,
        int offset,
        out int charLen)
    {
        var high = buf[offset];

        //find out current char's byte length
        if (high == 0x8E || (high >= 0xA1 && high <= 0xFE))
        {
            charLen = 2;
        }
        else if (high == 0xBF)
        {
            charLen = 3;
        }
        else
        {
            charLen = 1;
        }

        // return its order if it is hiragana
        if (high == HIRAGANA_FIRST_BYTE)
        {
            var low = buf[offset + 1];
            if (low >= 0xA1 && low <= 0xF3)
            {
                return low - 0xA1;
            }
        }

        return -1;
    }

    protected override int GetOrder(
        byte[] buf,
        int offset)
    {
        // We are only interested in Hiragana
        if (buf[offset] == HIRAGANA_FIRST_BYTE)
        {
            var low = buf[offset + 1];
            if (low >= 0xA1 && low <= 0xF3)
            {
                return low - 0xA1;
            }
        }

        return -1;
    }
}