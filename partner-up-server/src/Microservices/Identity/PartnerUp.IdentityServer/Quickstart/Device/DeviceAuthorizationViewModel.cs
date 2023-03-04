// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using PartnerUp.IdentityServer.Quickstart.Consent;

namespace PartnerUp.IdentityServer.Quickstart.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; } = null!;
        public bool ConfirmUserCode { get; set; }
    }
}
