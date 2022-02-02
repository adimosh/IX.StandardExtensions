// <copyright file="PureProber.cs" company="Adrian Mos">
// Copyright (c) Adrian Mos with all rights reserved. Part of the IX Framework.
// </copyright>

using System.Text;
using UtfUnknown.Core;
using UtfUnknown.Core.Probers;

namespace IX.StandardExtensions.Globalization.CharsetDetectionContrib
{
    internal class PureProber : CharsetProber
    {
        private bool notAscii;
        private byte lastByte;

        /// <summary>
        /// Feed data to the prober.
        /// </summary>
        /// <param name="buf">The buffer containing the data to probe.</param>
        /// <param name="offset">The offset into the buffer.</param>
        /// <param name="len">The number of bytes to read.</param>
        /// <returns>
        /// A <see cref="ProbingState"/> detailing what the prober's current state is.
        /// </returns>
        public override ProbingState HandleData(
            byte[] buf,
            int offset,
            int len)
        {
            int lastPos = offset + len;
            for (int i = offset; i < lastPos; i++)
            {
                if ((buf[i] & 0x80) != 0 && buf[i] != 0xA0)
                {
                    // High-byte found, let's get out of here
                    this.notAscii = true;

                    break;
                }

                if (buf[i] == 0x1B || (buf[i] == 0x7B && this.lastByte == 0x7E))
                {
                    // We found escape character or HZ "~{" - this is escaped ASCII and a different prober will take care of it
                    this.notAscii = true;

                    break;
                }

                this.lastByte = buf[i];
            }

            this.state = this.notAscii ? ProbingState.NotMe : ProbingState.Detecting;

            return this.state;
        }

        /// <summary>
        /// Reset prober state.
        /// </summary>
        public override void Reset()
        {
            this.state = ProbingState.Detecting;
            this.notAscii = false;
            this.lastByte = 0;
        }

        public override string GetCharsetName() => CodepageName.ASCII;

        public override float GetConfidence(StringBuilder? status = null) => this.notAscii ? 0f : 1f;
    }
}