# K2-Portal-Password

[![GitHub license](https://img.shields.io/github/license/Zedeldi/K2-Portal-Password?style=flat-square)](https://github.com/Zedeldi/K2-Portal-Password/blob/master/LICENSE) [![GitHub last commit](https://img.shields.io/github/last-commit/Zedeldi/K2-Portal-Password?style=flat-square)](https://github.com/Zedeldi/K2-Portal-Password/commits)

K2 Portal Password Generator.

## Description

Generate daily passwords for [K2 portals](https://www.k2ms.com/k2-portal).

### C#

`PasswordGenerator.cs` extracted from `Shell.exe` using `dnSpy`, with an added `Main` entry-point and `OSAccessLevel` enum included.

The method for generating passwords can be found in `PasswordGenerator.GeneratePassword`.

### Python

A pure-Python implementation can be found in `PasswordGenerator.py`, designed to be as close to the original as possible.

## Licence

The Python implementation is licensed by the GPL-3.0.

## Credits

K2MS = <https://www.k2ms.com>

dnSpy = <https://github.com/dnSpy/dnSpy>
