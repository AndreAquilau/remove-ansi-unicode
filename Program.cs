using System;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

string[] texts = new string[]
    {
            "\u001b[33mΓò╖\u001b[0m\u001b[0m",
            "\u001b[33mΓöé\u001b[0m \u001b[0m\u001b[1m\u001b[33mWarning: \u001b[0m\u001b[0m\u001b[1mNo outputs found\u001b[0m",
            "\u001b[33mΓöé\u001b[0m \u001b[0m",
            "\u001b[33mΓöé\u001b[0m \u001b[0m\u001b[0mThe state file either has no outputs defined, or all the defined outputs are empty. Please define an output in your configuration with the `output` keyword and run `terraform refresh` for it to become available. If you",
            "\u001b[33mΓöé\u001b[0m \u001b[0mare using interpolation, please verify the interpolated value is not empty. You can use the `terraform console` command to assist.",
            "\u001b[33mΓò╡\u001b[0m\u001b[0m"
    };

using StreamWriter streamWriter = new StreamWriter("./text.txt");

foreach (string text in texts)
{
    // Define a expressão regular para remover os caracteres unicode e ANSI
    string unescaped = Regex.Unescape(text);
    Regex regex = new Regex(@"[^\x00-\x7F]|\u001b\[\d{1,2}m|[\x80-\xFF]");

    // Remove os caracteres unicode e ANSI da string de entrada
    string output = regex.Replace(unescaped, string.Empty).Trim();

    Console.WriteLine(output);

    streamWriter.WriteLine(output);

}