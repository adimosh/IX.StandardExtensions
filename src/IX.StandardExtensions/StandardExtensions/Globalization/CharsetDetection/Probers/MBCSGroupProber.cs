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

using System;
using System.Text;
using UtfUnknown.Core.Probers.MultiByte;
using UtfUnknown.Core.Probers.MultiByte.Chinese;
using UtfUnknown.Core.Probers.MultiByte.Japanese;
using UtfUnknown.Core.Probers.MultiByte.Korean;

namespace UtfUnknown.Core.Probers;

/// <summary>
/// Multi-byte charsets probers
/// </summary>
internal class MBCSGroupProber : CharsetProber
{
    private const int PROBERS_NUM = 8;

    private CharsetProber[] probers = new CharsetProber[PROBERS_NUM];
    private bool[] isActive = new bool[PROBERS_NUM];
    private int bestGuess;
    private int activeNum;

    public MBCSGroupProber()
    {
        this.probers[0] = new UTF8Prober();
        this.probers[1] = new SJISProber();
        this.probers[2] = new EUCJPProber();
        this.probers[3] = new GB18030Prober();
        this.probers[4] = new EUCKRProber();
        this.probers[5] = new CP949Prober();
        this.probers[6] = new Big5Prober();
        this.probers[7] = new EUCTWProber();

        this.Reset();
    }

    public override string GetCharsetName()
    {
        if (this.bestGuess == -1)
        {
            this.GetConfidence();

            if (this.bestGuess == -1)
            {
                this.bestGuess = 0;
            }
        }

        return this.probers[this.bestGuess]
            .GetCharsetName();
    }

    public override void Reset()
    {
        this.activeNum = 0;

        for (var i = 0; i < this.probers.Length; i++)
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

    public override ProbingState HandleData(
        byte[] buf,
        int offset,
        int len)
    {
        // do filtering to reduce load to probers
        var highbyteBuf = new byte[len];
        var hptr = 0;

        //assume previous is not ascii, it will do no harm except add some noise
        var keepNext = true;
        var max = offset + len;

        for (var i = offset; i < max; i++)
        {
            if ((buf[i] & 0x80) != 0)
            {
                highbyteBuf[hptr++] = buf[i];
                keepNext = true;
            }
            else
            {
                //if previous is highbyte, keep this even it is a ASCII
                if (keepNext)
                {
                    highbyteBuf[hptr++] = buf[i];
                    keepNext = false;
                }
            }
        }

        for (var i = 0; i < this.probers.Length; i++)
        {
            if (this.isActive[i])
            {
                ProbingState st = this.probers[i]
                    .HandleData(
                        highbyteBuf,
                        0,
                        hptr);
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
        var bestConf = 0.0f;

        switch (this.state)
        {
            case ProbingState.FoundIt:
                return 0.99f;

            case ProbingState.NotMe:
                return 0.01f;

            default:

                if (status != null)
                {
                    status.AppendLine($"Get confidence:");
                }

                for (var i = 0; i < PROBERS_NUM; i++)
                {
                    if (this.isActive[i])
                    {
                        var cf = this.probers[i]
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

        status.AppendLine(" MBCS Group Prober --------begin status");

        for (var i = 0; i < PROBERS_NUM; i++)
        {
            if (this.probers[i] != null)
            {
                if (!this.isActive[i])
                {
                    status.AppendLine(
                        $" MBCS inactive: {this.probers[i].GetCharsetName()} (i.e. confidence is too low).");
                }
                else
                {
                    var cfp = this.probers[i]
                        .GetConfidence();

                    status.AppendLine($" MBCS {cfp}: [{this.probers[i].GetCharsetName()}]");

                    status.AppendLine(
                        this.probers[i]
                            .DumpStatus());
                }
            }
        }

        status.AppendLine(
            $" MBCS Group found best match [{this.probers[this.bestGuess].GetCharsetName()}] confidence {cf}.");

        return status.ToString();
    }
}