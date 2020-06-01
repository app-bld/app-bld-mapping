/*---------------------------------------------------------------------------------------------
 *  Copyright (c) applicationbuildersalmanac.com. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading;

namespace App.Bld.Mapping.Practises
{
    public sealed partial class MappingContext :
        IMappingContext
    {
        private static readonly AsyncLocal<IMappingContext?> _current = new AsyncLocal<IMappingContext?>();

        public static IMappingContext Current => _current.Value ??
            throw new InvalidOperationException("MappingContext.Create() must be called first");

        public static IMappingContext Create()
        {
            var context = new MappingContext();

            _current.Value = context;

            return context;
        }

        #region Internal State

        private readonly IDictionary<object, object> _mappings = new Dictionary<object, object>();

        #endregion

        private MappingContext()
        {
        }

        #region IMapper Implementation

        public void AddMapping(
            object source,
            object target)
            => _mappings.Add(
                source,
                target);

        public bool TryGetMapping(
            object source,
            out object target)
            => _mappings.TryGetValue(
                source,
                out target);

        #endregion

        #region Disposable Support

        public void Dispose()
        {
            _mappings.Clear();

            _current.Value = null;
        }

        #endregion
    }
}
