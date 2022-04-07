#pragma warning disable SA1633 // File should have header - This is an imported file,

// original header with license shall remain the same

/* ***** BEGIN LICENSE BLOCK *****
 * Version: MPL 1.1/GPL 2.0/LGPL 2.1
 *
 * The contents of this file are subject to the Mozilla Public License Version
 * 1.1 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 * http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the
 * License.
 *
 * The Original Code is Mozilla Universal charset detector code.
 *
 * The Initial Developer of the Original Code is
 * Netscape Communications Corporation.
 * Portions created by the Initial Developer are Copyright (C) 2001
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
 *          Shy Shalom <shooshX@gmail.com>
 *          Rudi Pettazzi <rudi.pettazzi@gmail.com> (C# port)
 *
 * Alternatively, the contents of this file may be used under the terms of
 * either the GNU General Public License Version 2 or later (the "GPL"), or
 * the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
 * in which case the provisions of the GPL or the LGPL are applicable instead
 * of those above. If you wish to allow use of your version of this file only
 * under the terms of either the GPL or the LGPL, and not to allow others to
 * use your version of this file under the terms of the MPL, indicate your
 * decision by deleting the provisions above and replace them with the notice
 * and other provisions required by the GPL or the LGPL. If you do not delete
 * the provisions above, a recipient may use your version of this file under
 * the terms of any one of the MPL, the GPL or the LGPL.
 *
 * ***** END LICENSE BLOCK ***** */

using System.Text;

#region using languages

using UtfUnknown.Core.Models.SingleByte.Arabic;
using UtfUnknown.Core.Models.SingleByte.Bulgarian;
using UtfUnknown.Core.Models.SingleByte.Croatian;
using UtfUnknown.Core.Models.SingleByte.Czech;
using UtfUnknown.Core.Models.SingleByte.Danish;
using UtfUnknown.Core.Models.SingleByte.Esperanto;
using UtfUnknown.Core.Models.SingleByte.Estonian;
using UtfUnknown.Core.Models.SingleByte.Finnish;
using UtfUnknown.Core.Models.SingleByte.French;
using UtfUnknown.Core.Models.SingleByte.German;
using UtfUnknown.Core.Models.SingleByte.Greek;
using UtfUnknown.Core.Models.SingleByte.Hebrew;
using UtfUnknown.Core.Models.SingleByte.Hungarian;
using UtfUnknown.Core.Models.SingleByte.Irish;
using UtfUnknown.Core.Models.SingleByte.Italian;
using UtfUnknown.Core.Models.SingleByte.Latvian;
using UtfUnknown.Core.Models.SingleByte.Lithuanian;
using UtfUnknown.Core.Models.SingleByte.Maltese;
using UtfUnknown.Core.Models.SingleByte.Polish;
using UtfUnknown.Core.Models.SingleByte.Portuguese;
using UtfUnknown.Core.Models.SingleByte.Romanian;
using UtfUnknown.Core.Models.SingleByte.Russian;
using UtfUnknown.Core.Models.SingleByte.Slovak;
using UtfUnknown.Core.Models.SingleByte.Slovene;
using UtfUnknown.Core.Models.SingleByte.Spanish;
using UtfUnknown.Core.Models.SingleByte.Swedish;
using UtfUnknown.Core.Models.SingleByte.Thai;
using UtfUnknown.Core.Models.SingleByte.Turkish;
using UtfUnknown.Core.Models.SingleByte.Vietnamese;

#endregion using languages

namespace UtfUnknown.Core.Probers;

internal class SBCSGroupProber : CharsetProber
{
    private const int PROBERS_NUM = 100;
    private CharsetProber[] probers = new CharsetProber[PROBERS_NUM];
    private bool[] isActive = new bool[PROBERS_NUM];
    private int bestGuess;
    private int activeNum;

    public SBCSGroupProber()
    {
        // Russian
        this.probers[0] = new SingleByteCharSetProber(new Windows_1251_RussianModel());
        this.probers[1] = new SingleByteCharSetProber(new Koi8r_Model());
        this.probers[2] = new SingleByteCharSetProber(new Iso_8859_5_RussianModel());
        this.probers[3] = new SingleByteCharSetProber(new X_Mac_Cyrillic_RussianModel());
        this.probers[4] = new SingleByteCharSetProber(new Ibm866_RussianModel());
        this.probers[5] = new SingleByteCharSetProber(new Ibm855_RussianModel());

        // Greek
        this.probers[6] = new SingleByteCharSetProber(new Iso_8859_7_GreekModel());
        this.probers[7] = new SingleByteCharSetProber(new Windows_1253_GreekModel());

        // Bulgarian
        this.probers[8] = new SingleByteCharSetProber(new Iso_8859_5_BulgarianModel());
        this.probers[9] = new SingleByteCharSetProber(new Windows_1251_BulgarianModel());

        // Hebrew
        var hebprober = new HebrewProber();
        this.probers[10] = hebprober;

        // Logical
        this.probers[11] = new SingleByteCharSetProber(
            new Windows_1255_HebrewModel(),
            false,
            hebprober);

        // Visual
        this.probers[12] = new SingleByteCharSetProber(
            new Windows_1255_HebrewModel(),
            true,
            hebprober);
        hebprober.SetModelProbers(
            this.probers[11],
            this.probers[12]);

        // Thai
        this.probers[13] = new SingleByteCharSetProber(new Tis_620_ThaiModel());
        this.probers[14] = new SingleByteCharSetProber(new Iso_8859_11_ThaiModel());

        // French
        this.probers[15] = new SingleByteCharSetProber(new Iso_8859_1_FrenchModel());
        this.probers[16] = new SingleByteCharSetProber(new Iso_8859_15_FrenchModel());
        this.probers[17] = new SingleByteCharSetProber(new Windows_1252_FrenchModel());

        // Spanish
        this.probers[18] = new SingleByteCharSetProber(new Iso_8859_1_SpanishModel());
        this.probers[19] = new SingleByteCharSetProber(new Iso_8859_15_SpanishModel());
        this.probers[20] = new SingleByteCharSetProber(new Windows_1252_SpanishModel());

        // Is the following still valid?
        // disable latin2 before latin1 is available, otherwise all latin1
        // will be detected as latin2 because of their similarity
        // Hungarian
        this.probers[21] = new SingleByteCharSetProber(new Iso_8859_2_HungarianModel());
        this.probers[22] = new SingleByteCharSetProber(new Windows_1250_HungarianModel());

        // German
        this.probers[23] = new SingleByteCharSetProber(new Iso_8859_1_GermanModel());
        this.probers[24] = new SingleByteCharSetProber(new Windows_1252_GermanModel());

        // Esperanto
        this.probers[25] = new SingleByteCharSetProber(new Iso_8859_3_EsperantoModel());

        // Turkish
        this.probers[26] = new SingleByteCharSetProber(new Iso_8859_3_TurkishModel());
        this.probers[27] = new SingleByteCharSetProber(new Iso_8859_9_TurkishModel());

        // Arabic
        this.probers[28] = new SingleByteCharSetProber(new Iso_8859_6_ArabicModel());
        this.probers[29] = new SingleByteCharSetProber(new Windows_1256_ArabicModel());

        // Vietnamese
        this.probers[30] = new SingleByteCharSetProber(new Viscii_VietnameseModel());
        this.probers[31] = new SingleByteCharSetProber(new Windows_1258_VietnameseModel());

        // Danish
        this.probers[32] = new SingleByteCharSetProber(new Iso_8859_15_DanishModel());
        this.probers[33] = new SingleByteCharSetProber(new Iso_8859_1_DanishModel());
        this.probers[34] = new SingleByteCharSetProber(new Windows_1252_DanishModel());

        // Lithuanian
        this.probers[35] = new SingleByteCharSetProber(new Iso_8859_13_LithuanianModel());
        this.probers[36] = new SingleByteCharSetProber(new Iso_8859_10_LithuanianModel());
        this.probers[37] = new SingleByteCharSetProber(new Iso_8859_4_LithuanianModel());

        // Latvian
        this.probers[38] = new SingleByteCharSetProber(new Iso_8859_13_LatvianModel());
        this.probers[39] = new SingleByteCharSetProber(new Iso_8859_10_LatvianModel());
        this.probers[40] = new SingleByteCharSetProber(new Iso_8859_4_LatvianModel());

        // Portuguese
        this.probers[41] = new SingleByteCharSetProber(new Iso_8859_1_PortugueseModel());
        this.probers[42] = new SingleByteCharSetProber(new Iso_8859_9_PortugueseModel());
        this.probers[43] = new SingleByteCharSetProber(new Iso_8859_15_PortugueseModel());
        this.probers[44] = new SingleByteCharSetProber(new Windows_1252_PortugueseModel());

        // Maltese
        this.probers[45] = new SingleByteCharSetProber(new Iso_8859_3_MalteseModel());

        // Czech
        this.probers[46] = new SingleByteCharSetProber(new Windows_1250_CzechModel());
        this.probers[47] = new SingleByteCharSetProber(new Iso_8859_2_CzechModel());
        this.probers[48] = new SingleByteCharSetProber(new Mac_Centraleurope_CzechModel());
        this.probers[49] = new SingleByteCharSetProber(new Ibm852_CzechModel());

        // Slovak
        this.probers[50] = new SingleByteCharSetProber(new Windows_1250_SlovakModel());
        this.probers[51] = new SingleByteCharSetProber(new Iso_8859_2_SlovakModel());
        this.probers[52] = new SingleByteCharSetProber(new Mac_Centraleurope_SlovakModel());
        this.probers[53] = new SingleByteCharSetProber(new Ibm852_SlovakModel());

        // Polish
        this.probers[54] = new SingleByteCharSetProber(new Windows_1250_PolishModel());
        this.probers[55] = new SingleByteCharSetProber(new Iso_8859_2_PolishModel());
        this.probers[56] = new SingleByteCharSetProber(new Iso_8859_13_PolishModel());
        this.probers[57] = new SingleByteCharSetProber(new Iso_8859_16_PolishModel());
        this.probers[58] = new SingleByteCharSetProber(new Mac_Centraleurope_PolishModel());
        this.probers[59] = new SingleByteCharSetProber(new Ibm852_PolishModel());

        // Finnish
        this.probers[60] = new SingleByteCharSetProber(new Iso_8859_1_FinnishModel());
        this.probers[61] = new SingleByteCharSetProber(new Iso_8859_4_FinnishModel());
        this.probers[62] = new SingleByteCharSetProber(new Iso_8859_9_FinnishModel());
        this.probers[63] = new SingleByteCharSetProber(new Iso_8859_13_FinnishModel());
        this.probers[64] = new SingleByteCharSetProber(new Iso_8859_15_FinnishModel());
        this.probers[65] = new SingleByteCharSetProber(new Windows_1252_FinnishModel());

        // Italian
        this.probers[66] = new SingleByteCharSetProber(new Iso_8859_1_ItalianModel());
        this.probers[67] = new SingleByteCharSetProber(new Iso_8859_3_ItalianModel());
        this.probers[68] = new SingleByteCharSetProber(new Iso_8859_9_ItalianModel());
        this.probers[69] = new SingleByteCharSetProber(new Iso_8859_15_ItalianModel());
        this.probers[70] = new SingleByteCharSetProber(new Windows_1252_ItalianModel());

        // Croatian
        this.probers[71] = new SingleByteCharSetProber(new Windows_1250_CroatianModel());
        this.probers[72] = new SingleByteCharSetProber(new Iso_8859_2_CroatianModel());
        this.probers[73] = new SingleByteCharSetProber(new Iso_8859_13_CroatianModel());
        this.probers[74] = new SingleByteCharSetProber(new Iso_8859_16_CroatianModel());
        this.probers[75] = new SingleByteCharSetProber(new Mac_Centraleurope_CroatianModel());
        this.probers[76] = new SingleByteCharSetProber(new Ibm852_CroatianModel());

        // Estonian
        this.probers[77] = new SingleByteCharSetProber(new Windows_1252_EstonianModel());
        this.probers[78] = new SingleByteCharSetProber(new Windows_1257_EstonianModel());
        this.probers[79] = new SingleByteCharSetProber(new Iso_8859_4_EstonianModel());
        this.probers[80] = new SingleByteCharSetProber(new Iso_8859_13_EstonianModel());
        this.probers[81] = new SingleByteCharSetProber(new Iso_8859_15_EstonianModel());

        // Irish
        this.probers[82] = new SingleByteCharSetProber(new Iso_8859_1_IrishModel());
        this.probers[83] = new SingleByteCharSetProber(new Iso_8859_9_IrishModel());
        this.probers[84] = new SingleByteCharSetProber(new Iso_8859_15_IrishModel());
        this.probers[85] = new SingleByteCharSetProber(new Windows_1252_IrishModel());

        // Romanian
        this.probers[86] = new SingleByteCharSetProber(new Windows_1250_RomanianModel());
        this.probers[87] = new SingleByteCharSetProber(new Iso_8859_2_RomanianModel());
        this.probers[88] = new SingleByteCharSetProber(new Iso_8859_16_RomanianModel());
        this.probers[89] = new SingleByteCharSetProber(new Ibm852_RomanianModel());

        // Slovene
        this.probers[90] = new SingleByteCharSetProber(new Windows_1250_SloveneModel());
        this.probers[91] = new SingleByteCharSetProber(new Iso_8859_2_SloveneModel());
        this.probers[92] = new SingleByteCharSetProber(new Iso_8859_16_SloveneModel());
        this.probers[93] = new SingleByteCharSetProber(new Mac_Centraleurope_SloveneModel());
        this.probers[94] = new SingleByteCharSetProber(new Ibm852_SloveneModel());

        // Swedish
        this.probers[95] = new SingleByteCharSetProber(new Iso_8859_1_SwedishModel());
        this.probers[96] = new SingleByteCharSetProber(new Iso_8859_4_SwedishModel());
        this.probers[97] = new SingleByteCharSetProber(new Iso_8859_9_SwedishModel());
        this.probers[98] = new SingleByteCharSetProber(new Iso_8859_15_SwedishModel());
        this.probers[99] = new SingleByteCharSetProber(new Windows_1252_SwedishModel());

        this.Reset();
    }

    public override ProbingState HandleData(
        byte[] buf,
        int offset,
        int len)
    {
        // apply filter to original buffer, and we got new buffer back
        // depend on what script it is, we will feed them the new buffer
        // we got after applying proper filter
        // this is done without any consideration to KeepEnglishLetters
        // of each prober since as of now, there are no probers here which
        // recognize languages with English characters.

        var newBuf = FilterWithoutEnglishLetters(
            buf,
            offset,
            len);

        if (newBuf.Length == 0)
        {
            return this.state; // Nothing to see here, move on.
        }

        for (var i = 0; i < PROBERS_NUM; i++)
        {
            if (this.isActive[i])
            {
                ProbingState st = this.probers[i]
                    .HandleData(
                        newBuf,
                        0,
                        newBuf.Length);

                if (st == ProbingState.FoundIt)
                {
                    this.bestGuess = i;
                    this.state = ProbingState.FoundIt;

                    break;
                }
                else if (st == ProbingState.NotMe)
                {
                    this.isActive[i] = false;
                    this.activeNum--;
                    if (this.activeNum <= 0)
                    {
                        this.state = ProbingState.NotMe;

                        break;
                    }
                }
            }
        }

        return this.state;
    }

    public override float GetConfidence(StringBuilder? status = null)
    {
        float bestConf = 0.0f, cf;

        switch (this.state)
        {
            case ProbingState.FoundIt:
                return 0.99f; //sure yes

            case ProbingState.NotMe:
                return 0.01f; //sure no

            default:

                if (status != null)
                {
                    status.AppendLine($"Get confidence:");
                }

                for (var i = 0; i < PROBERS_NUM; i++)
                {
                    if (this.isActive[i])
                    {
                        cf = this.probers[i]
                            .GetConfidence();
                        if (bestConf < cf)
                        {
                            bestConf = cf;
                            this.bestGuess = i;

                            if (status != null)
                            {
                                status.AppendLine(
                                    $"-- new match found: confidence {bestConf}, index {this.bestGuess}, charset {this.probers[i].GetCharsetName()}.");
                            }
                        }
                    }
                }

                if (status != null)
                {
                    status.AppendLine($"Get confidence done.");
                }

                break;
        }

        return bestConf;
    }

    public override string DumpStatus()
    {
        var status = new StringBuilder();

        var cf = this.GetConfidence(status);

        status.AppendLine(" SBCS Group Prober --------begin status");

        for (var i = 0; i < PROBERS_NUM; i++)
        {
            if (this.probers[i] != null)
            {
                if (!this.isActive[i])
                {
                    status.AppendLine(
                        $" SBCS inactive: [{this.probers[i].GetCharsetName()}] (i.e. confidence is too low).");
                }
                else
                {
                    var cfp = this.probers[i]
                        .GetConfidence();

                    status.AppendLine($" SBCS {cfp}: [{this.probers[i].GetCharsetName()}]");

                    status.AppendLine(
                        this.probers[i]
                            .DumpStatus());
                }
            }
        }

        status.AppendLine(
            $" SBCS Group found best match [{this.probers[this.bestGuess].GetCharsetName()}] confidence {cf}.");

        return status.ToString();
    }

    public override void Reset()
    {
        this.activeNum = 0;

        for (var i = 0; i < PROBERS_NUM; i++)
        {
            if (this.probers[i] != null)
            {
                this.probers[i]
                    .Reset();
                this.isActive[i] = true;
                ++this.activeNum;
            }
            else
            {
                this.isActive[i] = false;
            }
        }

        this.bestGuess = -1;

        this.state = ProbingState.Detecting;
    }

    public override string GetCharsetName()
    {
        //if we have no answer yet
        if (this.bestGuess == -1)
        {
            this.GetConfidence();

            //no charset seems positive
            if (this.bestGuess == -1)
            {
                this.bestGuess = 0;
            }
        }

        return this.probers[this.bestGuess]
            .GetCharsetName();
    }
}