﻿using System;
using System.Management.Automation;
using PnP.PowerShell.Commands.Enums;

namespace PnP.PowerShell.Commands.Features
{
    [Cmdlet(VerbsLifecycle.Disable, "PnPFeature")]
    [OutputType(typeof(void))]
    public class DisableFeature : PnPWebCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public Guid Identity;

        [Parameter(Mandatory = false, ParameterSetName = ParameterAttribute.AllParameterSets)]
        public SwitchParameter Force;

        [Parameter(Mandatory = false)]
        public FeatureScope Scope = FeatureScope.Web;

        protected override void ExecuteCmdlet()
        {
            var pnpContext = Connection.PnPContext;
            if (Scope == FeatureScope.Web)
            {
                pnpContext.Web.LoadAsync(w => w.Features).GetAwaiter().GetResult();
                pnpContext.Web.Features.Disable(Identity);
            }
            else
            {
                pnpContext.Site.LoadAsync(s => s.Features).GetAwaiter().GetResult();
                pnpContext.Site.Features.Disable(Identity);
            }
        }
    }
}
