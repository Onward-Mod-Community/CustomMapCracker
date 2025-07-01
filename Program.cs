
using System.Buffers.Text;
using System.Text;

static string Rot13(string value)
{
    int shift = 13;
    char[] array = value.ToCharArray();
    for (int i = 0; i < array.Length; i++)
    {
        int num = array[i];
        switch (num)
        {
            case 110:
            case 111:
            case 112:
            case 113:
            case 114:
            case 115:
            case 116:
            case 117:
            case 118:
            case 119:
            case 120:
            case 121:
            case 122:
                num -= shift;
                break;
            case 97:
            case 98:
            case 99:
            case 100:
            case 101:
            case 102:
            case 103:
            case 104:
            case 105:
            case 106:
            case 107:
            case 108:
            case 109:
                num += shift;
                break;
            default:
                switch (num)
                {
                    case 78:
                    case 79:
                    case 80:
                    case 81:
                    case 82:
                    case 83:
                    case 84:
                    case 85:
                    case 86:
                    case 87:
                    case 88:
                    case 89:
                    case 90:
                        num -= shift;
                        break;
                    case 65:
                    case 66:
                    case 67:
                    case 68:
                    case 69:
                    case 70:
                    case 71:
                    case 72:
                    case 73:
                    case 74:
                    case 75:
                    case 76:
                    case 77:
                        num += shift;
                        break;
                }
                break;
        }
        array[i] = (char)num;
    }
    return new string(array);
}

static string DecryptInfo(string path)
{
    var s = File.ReadAllText(path);
    s = Rot13(s.Substring(1));

    s = Encoding.UTF8.GetString(Convert.FromBase64String(s));

    return s;
}

static string EncryptInfo(string path)
{
    var json = File.ReadAllText(path);
    var utf8 = Encoding.UTF8.GetBytes(json);
    var base64 = Convert.ToBase64String(utf8);
    var shifted = Rot13(base64);
    return "\0" + shifted;
}

string[] cli_args = Environment.GetCommandLineArgs();

if (cli_args.Length == 4 && cli_args[1] == "decrypt")
{
    string json = DecryptInfo(cli_args[2]);
    File.WriteAllText(cli_args[3], json);

    Console.WriteLine(json);
} else if (cli_args.Length == 4 && cli_args[1] == "encrypt")
{
    string bin = EncryptInfo(cli_args[2]);
    File.WriteAllText(cli_args[3], bin);
} else
{
    Console.WriteLine($"Command Line Usage: {cli_args[0]} (encrpyt|decrypt) in out");
}
