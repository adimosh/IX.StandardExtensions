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
using UtfUnknown.Core.Models;
using UtfUnknown.Core.Models.MultiByte.Chinese;
using UtfUnknown.Core.Models.MultiByte.Japanese;
using UtfUnknown.Core.Models.MultiByte.Korean;

namespace UtfUnknown.Core.Probers;

internal class EscCharsetProber : CharsetProber
{
    private const int CHARSETS_NUM = 4;
    private string detectedCharset;
    private CodingStateMachine[] codingSM;
    private int activeSM;

    public EscCharsetProber()
    {
        this.codingSM = new CodingStateMachine[CHARSETS_NUM];
        this.codingSM[0] = new CodingStateMachine(new HZ_GB_2312_SMModel());
        this.codingSM[1] = new CodingStateMachine(new Iso_2022_CN_SMModel());
        this.codingSM[2] = new CodingStateMachine(new Iso_2022_JP_SMModel());
        this.codingSM[3] = new CodingStateMachine(new Iso_2022_KR_SMModel());
        this.Reset();
    }

    public override void Reset()
    {
        this.state = ProbingState.Detecting;
        for (var i = 0; i < CHARSETS_NUM; i++)
        {
            this.codingSM[i]
                .Reset();
        }

        this.activeSM = CHARSETS_NUM;
        this.detectedCharset = null;
    }

    public override ProbingState HandleData(
        byte[] buf,
        int offset,
        int len)
    {
        var max = offset + len;

        for (var i = offset; i < max && this.state == ProbingState.Detecting; i++)
        {
            for (var j = this.activeSM - 1; j >= 0; j--)
            {
                // byte is feed to all active state machine
                var codingState = this.codingSM[j]
                    .NextState(buf[i]);
                if (codingState == StateMachineModel.ERROR)
                {
                    // got negative answer for this state machine, make it inactive
                    this.activeSM--;
                    if (this.activeSM == 0)
                    {
                        this.state = ProbingState.NotMe;

                        return this.state;
                    }
                    else if (j != this.activeSM)
                    {
                        CodingStateMachine t = this.codingSM[this.activeSM];
                        this.codingSM[this.activeSM] = this.codingSM[j];
                        this.codingSM[j] = t;
                    }
                }
                else if (codingState == StateMachineModel.ITSME)
                {
                    this.state = ProbingState.FoundIt;
                    this.detectedCharset = this.codingSM[j]
                        .ModelName;

                    return this.state;
                }
            }
        }

        return this.state;
    }

    public override string GetCharsetName() => this.detectedCharset;

    public override float GetConfidence(StringBuilder status = null) => 0.99f;
}