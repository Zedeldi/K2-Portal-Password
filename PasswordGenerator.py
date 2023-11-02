from datetime import datetime
from enum import Enum
from typing import Optional


class OSAccessLevel(Enum):
    Closed = 0
    Read = 8
    Write = 28
    Full = 42
    PasswordOfTheDay = 95
    Exclusions = 125
    ManagedChanges = 157


class PasswordGenerator:
    TokenChars = "ETOVCFNRSDJKWXGHBLMYZIAPQU"

    @staticmethod
    def GetCharIndex(testChar: str) -> int:
        try:
            num = "ETOVCFNRSDJKWXGHBLMYZIAPQU".index(testChar)
        except ValueError as err:
            raise Exception(f"Invalid character ({testChar}) in token") from err
        return num + 1

    @staticmethod
    def GeneratePassword(
        dt: datetime, checkLevel: OSAccessLevel, token: Optional[str] = None
    ) -> str:
        day = dt.day
        month = dt.month
        year = dt.year
        num = 0
        num2 = 0
        num3 = 0
        num4 = 0
        if token:
            if len(token) < 3:
                raise Exception("Invalid token, must be at least 3 characters long.")
            text = token.upper()
            num = PasswordGenerator.GetCharIndex(text[0])
            num2 = PasswordGenerator.GetCharIndex(text[1])
            num3 = PasswordGenerator.GetCharIndex(text[2])
        if checkLevel != OSAccessLevel.PasswordOfTheDay:
            text2 = checkLevel.name[:1]
            num4 = ord(text2[0].lower())
        if checkLevel == OSAccessLevel.Full:
            i = year - day
            j = year - month
            k = month - day if month > day else day - month
            i *= month + day + num + num4
            j *= day + year + num2 + num4
            k *= year + month + num3 + num4
        else:
            i = (year + day) * (month + num + num4)
            j = (year + month) * (day + num2 + num4)
            k = (month + day) * (year + num3 + num4)
            i *= day
            j *= day
            k *= day
        while i > 99:
            i -= 99
        while j > 99:
            j -= 99
        while k > 99:
            k -= 99
        return f"{i:02}{j:02}{k:02}"


if __name__ == "__main__":
    password = PasswordGenerator.GeneratePassword(
        datetime.now(), OSAccessLevel.PasswordOfTheDay
    )
    print(password)
