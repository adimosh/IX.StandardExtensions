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
* The implementation of this feature was originally done on https://gitlab.freedesktop.org/uchardet/uchardet/blob/master/src/LangModels/LangPolishModel.cpp
* and adjusted to language specific support.
*/

namespace UtfUnknown.Core.Models.SingleByte.Polish;

internal class Mac_Centraleurope_PolishModel : PolishModel
{
    // Generated by BuildLangModel.py
    // On: 2016-09-21 17:21:04.405363

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

    private static byte[] CHAR_TO_ORDER_MAP =
    {
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        RET,
        CTR,
        CTR,
        RET,
        CTR,
        CTR, /* 0X */
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR,
        CTR, /* 1X */
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM, /* 2X */
        NUM,
        NUM,
        NUM,
        NUM,
        NUM,
        NUM,
        NUM,
        NUM,
        NUM,
        NUM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM, /* 3X */
        SYM,
        0,
        20,
        11,
        14,
        3,
        26,
        21,
        22,
        1,
        18,
        7,
        15,
        16,
        5,
        2, /* 4X */
        13,
        36,
        4,
        6,
        10,
        17,
        31,
        9,
        33,
        12,
        8,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM, /* 5X */
        SYM,
        0,
        20,
        11,
        14,
        3,
        26,
        21,
        22,
        1,
        18,
        7,
        15,
        16,
        5,
        2, /* 6X */
        13,
        36,
        4,
        6,
        10,
        17,
        31,
        9,
        33,
        12,
        8,
        SYM,
        SYM,
        SYM,
        SYM,
        CTR, /* 7X */
        40,
        63,
        63,
        34,
        25,
        38,
        39,
        35,
        25,
        44,
        40,
        44,
        30,
        30,
        34,
        32, /* 8X */
        32,
        69,
        37,
        69,
        110,
        111,
        71,
        24,
        71,
        55,
        38,
        67,
        51,
        46,
        46,
        39, /* 9X */
        SYM,
        SYM,
        23,
        SYM,
        SYM,
        SYM,
        SYM,
        57,
        SYM,
        SYM,
        SYM,
        23,
        SYM,
        SYM,
        112,
        113, /* AX */
        114,
        73,
        SYM,
        SYM,
        73,
        115,
        SYM,
        SYM,
        19,
        116,
        117,
        74,
        74,
        118,
        119,
        120, /* BX */
        121,
        29,
        SYM,
        SYM,
        29,
        122,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        123,
        49,
        67,
        49,
        42, /* CX */
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        SYM,
        42,
        124,
        125,
        50,
        SYM,
        SYM,
        50,
        126, /* DX */
        127,
        41,
        SYM,
        SYM,
        41,
        28,
        28,
        35,
        76,
        76,
        37,
        45,
        45,
        59,
        24,
        55, /* EX */
        59,
        128,
        51,
        129,
        130,
        131,
        132,
        133,
        60,
        60,
        134,
        27,
        19,
        27,
        135,
        SYM /* FX */
    };
    /*X0  X1  X2  X3  X4  X5  X6  X7  X8  X9  XA  XB  XC  XD  XE  XF */

    public Mac_Centraleurope_PolishModel()
        : base(
            CHAR_TO_ORDER_MAP,
            CodepageName.X_MAC_CE) { }
}