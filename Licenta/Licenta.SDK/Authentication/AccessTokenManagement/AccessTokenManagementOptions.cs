// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Licenta.SDK.Authentication.AccessTokenManagement.ClientAccessToken;
using Licenta.SDK.Authentication.AccessTokenManagement.UserAccessToken;

namespace Licenta.SDK.Authentication.AccessTokenManagement
{
    /// <summary>
    /// Options for the token management services
    /// </summary>
    public class AccessTokenManagementOptions
    {
        /// <summary>
        /// Options for user access tokens
        /// </summary>
        public UserAccessTokenManagementOptions User { get; set; } = new();

        /// <summary>
        /// Options for client acccess tokens
        /// </summary>
        public ClientAccessTokenManagementOptions Client { get; set; } = new();
    }
}