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

using UtfUnknown.Core.Analyzers.Korean;
using UtfUnknown.Core.Models;
using UtfUnknown.Core.Models.MultiByte.Korean;

namespace UtfUnknown.Core.Probers.MultiByte.Korean;

internal class CP949Prober : CharsetProber
{
    private CodingStateMachine codingSM;
    private EUCKRDistributionAnalyser distributionAnalyser;
    private byte[] lastChar = new byte[2];

    public CP949Prober()
    {
        codingSM = new(new CP949SMModel());
        // NOTE: CP949 is a superset of EUC-KR, so the distribution should be
        //       not different.
        distributionAnalyser = new();
        Reset();
    }

    public override string GetCharsetName()
    {
        return CodepageName.CP949;
    }

    public override ProbingState HandleData(byte[] buf, int offset, int len)
    {
        int codingState;
        int max = offset + len;

        for (int i = offset; i < max; i++)
        {
            codingState = codingSM.NextState(buf[i]);
            if (codingState == StateMachineModel.ERROR)
            {
                state = ProbingState.NotMe;
                break;
            }

            if (codingState == StateMachineModel.ITSME)
            {
                state = ProbingState.FoundIt;
                break;
            }

            if (codingState == StateMachineModel.START)
            {
                int charLen = codingSM.CurrentCharLen;
                if (i == offset)
                {
                    lastChar[1] = buf[offset];
                    distributionAnalyser.HandleOneChar(lastChar, 0, charLen);
                }
                else
                {
                    distributionAnalyser.HandleOneChar(buf, i - 1, charLen);
                }
            }
        }

        lastChar[0] = buf[max - 1];

        if (state == ProbingState.Detecting)
            if (distributionAnalyser.GotEnoughData() && GetConfidence() > SHORTCUT_THRESHOLD)
                state = ProbingState.FoundIt;

        return state;
    }

    public override float GetConfidence(StringBuilder status = null)
    {
        return distributionAnalyser.GetConfidence();
    }

    public override void Reset()
    {
        codingSM.Reset();
        state = ProbingState.Detecting;
        distributionAnalyser.Reset();
        //mContextAnalyser.Reset();
    }
}