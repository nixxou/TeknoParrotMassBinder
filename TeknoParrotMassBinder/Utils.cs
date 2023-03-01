using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TeknoParrotMassBinder
{
	internal class Utils
	{
		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
		//static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
		static extern bool CreateHardLink(
		  string lpFileName,
		  string lpExistingFileName,
		  IntPtr lpSecurityAttributes
	  );

		public static void MakeLink(string source, string target)
		{
			if (!File.Exists(source)) return;
			if (File.Exists(target)) return;

			CreateHardLink(target, source, IntPtr.Zero);
		}

		public static bool EmptyFolder(string pathName)
		{
			bool errors = false;
			DirectoryInfo dir = new DirectoryInfo(pathName);

			foreach (FileInfo fi in dir.EnumerateFiles())
			{
				try
				{
					fi.IsReadOnly = false;
					fi.Delete();

					//Wait for the item to disapear (avoid 'dir not empty' error).
					while (fi.Exists)
					{
						System.Threading.Thread.Sleep(10);
						fi.Refresh();
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine(e.Message);
					errors = true;
				}
			}

			foreach (DirectoryInfo di in dir.EnumerateDirectories())
			{
				try
				{
					EmptyFolder(di.FullName);
					di.Delete();

					//Wait for the item to disapear (avoid 'dir not empty' error).
					while (di.Exists)
					{
						System.Threading.Thread.Sleep(10);
						di.Refresh();
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine(e.Message);
					errors = true;
				}
			}

			return !errors;
		}

		public static string RemoveInvalidChars(string filename)
		{
			return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
		}
		static string RemoveDiacritics(string text)
		{
			var normalizedString = text.Normalize(NormalizationForm.FormD);
			var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

			for (int i = 0; i < normalizedString.Length; i++)
			{
				char c = normalizedString[i];
				var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
				if (unicodeCategory != UnicodeCategory.NonSpacingMark)
				{
					stringBuilder.Append(c);
				}
			}

			return stringBuilder
				.ToString()
				.Normalize(NormalizationForm.FormC);
		}

	}
}
