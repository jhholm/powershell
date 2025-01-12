using PnP.PowerShell.Commands.Enums;
using PnP.PowerShell.Commands.Base;
using PnP.PowerShell.Commands.Attributes;
using System.Collections;
using System.Management.Automation;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Linq;

namespace PnP.PowerShell.Commands.PeopleSettings
{
    [Cmdlet(VerbsCommon.Remove, "PnPProfileCardProperty")]
    [RequiredApiDelegatedOrApplicationPermissions("graph/PeopleSettings.ReadWrite.All")]
    [OutputType(typeof(void))]
    public class RemoveProfileCardProperty : PnPGraphCmdlet
    {
        [Parameter(Mandatory = true)]
        public ProfileCardPropertyName PropertyName;

        protected override void ExecuteCmdlet()
        {            
            var graphApiUrl = $"v1.0/admin/people/profileCardProperties/{PropertyName.ToString()}";
            
            Utilities.REST.GraphHelper.Delete(this, Connection, graphApiUrl, AccessToken);
        }
    }
}