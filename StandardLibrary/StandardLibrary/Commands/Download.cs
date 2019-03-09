﻿using System;
using System.IO;
using System.Collections.Generic;
using Faction.Modules.Dotnet.Common;

namespace Faction.Modules.Dotnet.Commands
{
  class Download : Command
  {
    public override string Name { get { return "download"; } }
    public override CommandOutput Execute(Dictionary<string, string> Parameters = null)
    {
      CommandOutput output = new CommandOutput();
      string path = Path.GetFullPath(Parameters["Path"]);
#if DEBUG
      Console.WriteLine($"[Download Command] Got path: {path}");
#endif
      string content = Parameters["File"];
      byte[] bytes = Convert.FromBase64String(content);
      File.WriteAllBytes(path, bytes);

      FileStream fop = File.OpenRead(path);
      string chksum = BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));
#if DEBUG
      Console.WriteLine($"[Download Command] File downloaded. Hash: {chksum}");
#endif
      output.Complete = true;
      output.Success = true;
      output.Message = $"File written to {path}";
      output.IOCs.Add(new IOC("file", path, "create", $"Downloaded file to {path}", chksum));
      return output;
    }
  }
}
