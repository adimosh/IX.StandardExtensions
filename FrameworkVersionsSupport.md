# .NET Framework versions estimated lifecycle and support

Below is an estimated support lifecycle for .NET Framework and above. It is compiled based on
lifecycle and support documents coming from Microsoft, and is not meant to be an official support
document.

You can use this document to roughly gauge what versions are supported at this moment, and when
support will end.

Please note that, in order to encourage upgrade, the current table will only show IX.Framework
support that is current. You are intentionally left on your own to figure out if previous
IX.Framework versions support older, out-of-support frameworks or not.

NuGet packages for frameworks that have ended support are marked obsolete. If you find one
that is not marked obsolete, please let me know by opening an issue here.

## .NET Version lifecycle

### Symbols legend

| Symbol | Meaning |
|:------:|:-------:|
| :x: | Not supported |
| :heavy_exclamation_mark: | Still supported, but use is not advised |
| :warning: | Still supported, but only for a short while |
| :heavy_check_mark: | Supported |

### .NET Framework

| Version | IX Support | MS Support |
|:-------:|:----------:|:----------:|
| <= 1.1 SP1 | :x: | :x: (14th July, 2015) |
| 2.0 SP2 | :x: | :heavy_exclamation_mark:_1_ (9th January, 2029) |
| 3.0 SP2 | :x: | :heavy_exclamation_mark:_1_ (9th January, 2029) |
| 3.5 SP1 | :x: | :heavy_check_mark: (9th January, 2029) |
| 4.0 | :x: | :x: (12th January, 2016) |
| 4.5 | :x: | :x: (12th January, 2016) |
| 4.5.1 | :x: | :x: (12th January, 2016) |
| 4.5.2 | :x: | :warning: (26th April, 2022) |
| 4.6 | :warning: | :warning: (26th April, 2022) |
| 4.6.1 | :warning: | :warning: (26th April, 2022) |
| 4.6.2 | :heavy_check_mark: | :heavy_check_mark: (12th January, 2027) |
| 4.7 | :heavy_check_mark: | :heavy_check_mark: (12th January, 2027) |
| 4.7.1 | :heavy_check_mark: | :heavy_check_mark: (12th January, 2027) |
| 4.7.2 | :heavy_check_mark: | :heavy_check_mark: (9th January, 2029) |
| 4.8 | :heavy_check_mark: | :heavy_check_mark: (14th October, 2031)_2_ |

_1_ - .NET Framework versions 2.0 and 3.0 are noted to be an integral part of .NET 3.5, and are supported
under a single lifecycle policy, and Microsoft stated that their components will continue to be supported
for as long as .NET 3. SP1 remains in support; full statement can be found
[on this page](https://docs.microsoft.com/en-us/lifecycle/faq/dotnet-framework).

_2_ - Support for .NET Framework 4.8 doesn't have a definitive ending date yet, so the ending date of
Windows Server 2022, which is the farthest in time, is presumed.

### .NET Standard

### .NET Core

### .NET

## Source lifecycle table

This table shows estimated Microsoft Windows estimated support dates, onto which .NET versions are
based.

Like the previous tables, this is compiled as support for IX.Framework users and is not meant to be
an official Microsoft support document.

| Version | Support | EHS |
|:-------:|:-------:|:---:|
| Windows 7 SP1 | :x: 2020.01.14 | :heavy_exclamation_mark: 2023.01.10 |
| Windows Server 2008 R2 | :x: 2020.01.14 | :heavy_exclamation_mark: 2024.01.09 |
| Windows 8.1 | :heavy_exclamation_mark: 2023.01.10 | - |
| Windows Server 2012 | :heavy_check_mark: 2023.10.10 | :heavy_check_mark: 2026.10.13 |
| Windows Server 2012 R2 | :heavy_check_mark: 2023.10.10 | :heavy_check_mark: 2026.10.13 |
| Windows 10 1507 | :x: 2017.05.09 | - |
| Windows 10 1151 | :x: 2017.10.10 | - |
| Windows 10 1607 | :x: 2019.04.09 | - |
| Windows 10 1703 | :x: 2019.10.08 | - |
| Windows 10 1709 | :x: 2020.10.13 | - |
| Windows 10 1803 | :x: 2021.05.11 | - |
| Windows 10 1809 | :x: 2021.05.11 | - |
| Windows 10 1903 | :x: 2020.12.08 | - |
| Windows 10 1909 | :heavy_exclamation_mark: 2022.05.10 | - |
| Windows 10 2004 | :x: 2021.12.04 | - |
| Windows 10 20H2 | :heavy_exclamation_mark: 2023.05.09 | - |
| Windows 10 21H1 | :heavy_exclamation_mark: 2022.12.13 | - |
| Windows 10 21H2 | :heavy_check_mark: 2025.10.14 | - |
| Windows 10 2015 LTSB | :heavy_check_mark: 2025.10.14 | - |
| Windows 10 2016 LTSB | :heavy_check_mark: 2026.10.13 | - |
| Windows 10 2019 LTSC | :heavy_check_mark: 2029.01.09 | - |
| Windows Server 2016 | :heavy_check_mark: 2027.01.12 | - |
| Windows Server Version 1709 | :x: 2019.04.09 | - |
| Windows Server Version 1803 | :x: 2019.11.12 | - |
| Windows Server 2019 | :heavy_check_mark: 2029.01.09 | - |
| Windows Server Version 1809 | :x: 2020.11.10 | - |
| Windows Server Version 1903 | :x: 2020.12.08 | - |
| Windows Server Version 1909 | :x: 2021.05.11 | - |
| Windows Server Version 2004 | :heavy_exclamation_mark: 2021.12.14 | - |
| Windows Server Version 20H2 | :heavy_check_mark: 2022.08.11 | - |
| Windows Server 2022 | :heavy_check_mark: 2031.10.14 | - |
| Windows 11 21H2 | :heavy_check_mark: 2024.10.08 | - |