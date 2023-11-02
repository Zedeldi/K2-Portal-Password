using System;
using System.Text;

namespace Shell
{
	public enum OSAccessLevel
	{
		// Token: 0x04000139 RID: 313
		Closed,
		// Token: 0x0400013A RID: 314
		Read = 8,
		// Token: 0x0400013B RID: 315
		Write = 28,
		// Token: 0x0400013C RID: 316
		Full = 42,
		// Token: 0x0400013D RID: 317
		PasswordOfTheDay = 95,
		// Token: 0x0400013E RID: 318
		Exclusions = 125,
		// Token: 0x0400013F RID: 319
		ManagedChanges = 157
	}

	// Token: 0x02000014 RID: 20
	public class PasswordGenerator
	{
		// Token: 0x060000FB RID: 251 RVA: 0x0000B08F File Offset: 0x0000928F
		private static int GetCharIndex(char testChar)
		{
			int num = "ETOVCFNRSDJKWXGHBLMYZIAPQU".IndexOf(testChar);
			if (num < 0)
			{
				throw new Exception("Invalid character (" + testChar.ToString() + ") in token");
			}
			return num + 1;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000B0C0 File Offset: 0x000092C0
		public static string GeneratePassword(DateTime dt, OSAccessLevel checkLevel, string token = null)
		{
			int day = dt.Day;
			int month = dt.Month;
			int year = dt.Year;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (!string.IsNullOrEmpty(token))
			{
				if (token.Length < 3)
				{
					throw new Exception("Invalid token, must be at least 3 characters long.");
				}
				string text = token.ToUpper();
				num = PasswordGenerator.GetCharIndex(text[0]);
				num2 = PasswordGenerator.GetCharIndex(text[1]);
				num3 = PasswordGenerator.GetCharIndex(text[2]);
			}
			if (checkLevel != OSAccessLevel.PasswordOfTheDay)
			{
				string text2 = checkLevel.ToString().Substring(0, 1);
				num4 = (int)Encoding.ASCII.GetBytes(text2.ToLower())[0];
			}
			int i;
			int j;
			int k;
			if (checkLevel == OSAccessLevel.Full)
			{
				i = year - day;
				j = year - month;
				k = ((month > day) ? (month - day) : (day - month));
				i *= month + day + num + num4;
				j *= day + year + num2 + num4;
				k *= year + month + num3 + num4;
			}
			else
			{
				i = (year + day) * (month + num + num4);
				j = (year + month) * (day + num2 + num4);
				k = (month + day) * (year + num3 + num4);
				i *= day;
				j *= day;
				k *= day;
			}
			while (i > 99)
			{
				i -= 99;
			}
			while (j > 99)
			{
				j -= 99;
			}
			while (k > 99)
			{
				k -= 99;
			}
			return string.Format("{0:00}{1:00}{2:00}", i, j, k);
		}

		// Token: 0x040000DF RID: 223
		private const string TokenChars = "ETOVCFNRSDJKWXGHBLMYZIAPQU";

		public static void Main() {
			string password = PasswordGenerator.GeneratePassword(
				DateTime.Now,
				OSAccessLevel.PasswordOfTheDay
			);
			Console.WriteLine(password);
		}
	}
}

