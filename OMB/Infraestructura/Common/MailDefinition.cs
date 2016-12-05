using System.Collections.Generic;

namespace Infraestructura.Common
{
  public class MailDefinition
  {
    public string From { get; set; }
    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }

    public MailDefinition()
    {
      To = new List<string>();
    }
  }
}