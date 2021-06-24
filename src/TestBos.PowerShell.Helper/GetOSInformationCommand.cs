using System.Management.Automation;  // PowerShell namespace.
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace TestBos.PowerShell.Helper
{
    // Declare the class as a cmdlet and specify and
    // appropriate verb (VerbsCommunications.Send) and noun for the cmdlet name.
    [Cmdlet("Get", "OSInformation")]
    public class GetOSInformationCommand : Cmdlet
    {
        /*
        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = true)]
        public string Name { get; set; }
        */

        OSInformation info;

        // Override the ProcessRecord method to process
        protected override void ProcessRecord()
        {
            switch (RuntimeInformation.OSDescription)
            {
                case var id when new Regex(@"^.*Windows.*$").IsMatch(id):
                    info = OSInformation.ParseFromRuntimeInformation();
                    break;
                case var id when new Regex(@"^.*Linux.*$").IsMatch(id):
                    info = OSInformation.ParseFromFile();
                    break;
                default:
                    break;
            }

            WriteObject(info);
        }
    }
}