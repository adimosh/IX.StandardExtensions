﻿/* ***** BEGIN LICENSE BLOCK *****
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
 * The Original Code is Mozilla Communicator client code.
 *
 * The Initial Developer of the Original Code is
 * Netscape Communications Corporation.
 * Portions created by the Initial Developer are Copyright (C) 1998
 * the Initial Developer. All Rights Reserved.
 *
 * Contributor(s):
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

/*
* The following part was imported from https://gitlab.freedesktop.org/uchardet/uchardet
* The implementation of this feature was originally done on https://gitlab.freedesktop.org/uchardet/uchardet/blob/master/src/LangModels/LangCzechModel.cpp
* and adjusted to language specific support.
*/

namespace UtfUnknown.Core.Models.SingleByte.Czech;

internal class Ibm852_CzechModel : CzechModel
{
    // Generated by BuildLangModel.py
    // On: 2016-09-21 03:28:11.733089

    // Character Mapping Table:
    // ILL: illegal character.
    // CTR: control character specific to the charset.
    // RET: carriage/return.
    // SYM: symbol (punctuation) that does not belong to word.
    // NUM: 0 - 9.

    // Other characters are ordered by probabilities
    // (0 is the most common character in the language).

    // Orders are generic to a language. So the codepoint with order X in
    // CHARSET1 maps to the same character as the codepoint with the same
    // order X in CHARSET2 for the same language.
    // As such, it is possible to get missing order. For instance the
    // ligature of 'o' and 'e' exists in ISO-8859-15 but not in ISO-8859-1
    // even though they are both used for French. Same for the euro sign.

    private static byte[] CHAR_TO_ORDER_MAP = {
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,RET,CTR,CTR,RET,CTR,CTR, /* 0X */
        CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR,CTR, /* 1X */
        SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, /* 2X */
        NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,NUM,SYM,SYM,SYM,SYM,SYM,SYM, /* 3X */
        SYM,  3, 22, 14, 15,  1, 30, 32, 17,  4, 21, 12, 10, 16,  2,  0, /* 4X */
        8, 40,  9,  6,  5, 13,  7, 36, 34, 20, 19,SYM,SYM,SYM,SYM,SYM, /* 5X */
        SYM,  3, 22, 14, 15,  1, 30, 32, 17,  4, 21, 12, 10, 16,  2,  0, /* 6X */
        8, 40,  9,  6,  5, 13,  7, 36, 34, 20, 19,SYM,SYM,SYM,SYM,CTR, /* 7X */
        139, 43, 24,140, 42, 31,141,142,143,144,145,146,147,148, 42,149, /* 8X */
        24,150,151,152, 41, 45, 45, 46, 46, 41, 43, 38, 38,153,SYM, 25, /* 9X */
        18, 11, 37, 33,154,155, 26, 26,156,157,SYM,158, 25,159,SYM,SYM, /* AX */
        SYM,SYM,SYM,SYM,SYM, 18,160, 23,161,SYM,SYM,SYM,SYM,162,163,SYM, /* BX */
        SYM,SYM,SYM,SYM,SYM,SYM,164,165,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM, /* CX */
        166,167, 39,168, 39, 35, 11,169, 23,SYM,SYM,SYM,SYM,170, 31,SYM, /* DX */
        37,171,172,173,174, 35, 29, 29,175, 33,176,177, 28, 28,178,SYM, /* EX */
        SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,SYM,179, 27, 27,SYM,SYM, /* FX */
    };
    /*X0  X1  X2  X3  X4  X5  X6  X7  X8  X9  XA  XB  XC  XD  XE  XF */

    public Ibm852_CzechModel() : base(CHAR_TO_ORDER_MAP, CodepageName.IBM852)
    {
    }
}