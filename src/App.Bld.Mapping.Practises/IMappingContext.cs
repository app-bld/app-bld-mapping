/*---------------------------------------------------------------------------------------------
 *  Copyright (c) applicationbuildersalmanac.com. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace App.Bld.Mapping.Practises
{
    public interface IMappingContext :
        IDisposable
    {
        bool TryGetMapping(
            object source,
            out object target);

        void AddMapping(
            object source,
            object target);
    }
}
