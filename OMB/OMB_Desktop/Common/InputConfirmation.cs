using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Interactivity.InteractionRequest;

namespace OMB_Desktop.Common
{
  public class InputConfirmation : IConfirmation
  {
    public bool Confirmed { get; set; }

    public object Content { get; set; }

    public string Title { get; set; }

    public string Input { get; set; }

    public string Descripcion { get; set; }

    public Func<string, bool> Validator { get; set; }
  }
}
