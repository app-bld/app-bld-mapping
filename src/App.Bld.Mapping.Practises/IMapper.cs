/*---------------------------------------------------------------------------------------------
 *  Copyright (c) applicationbuildersalmanac.com. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

namespace App.Bld.Mapping.Practises
{
    public interface IMapper<in TSource, out TTarget>
    {
        TTarget Map(
            TSource source);
    }
}
