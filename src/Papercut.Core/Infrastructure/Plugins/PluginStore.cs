// Papercut
// 
// Copyright � 2008 - 2012 Ken Robertson
// Copyright � 2013 - 2017 Jaben Cargman
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//  
// http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License. 
namespace Papercut.Core.Infrastructure.Plugins
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using Papercut.Core.Annotations;

    public sealed class PluginStore : IPluginStore
    {
        private readonly ConcurrentBag<IPluginModule> _loadedPlugins = new ConcurrentBag<IPluginModule>();

        private PluginStore() { }

        public static PluginStore Instance { get; } = new PluginStore();

        public IEnumerable<IPluginModule> Plugins => this._loadedPlugins.ToArray();

        public void Add([NotNull] IPluginModule module)
        {
            if (module == null) throw new ArgumentNullException(nameof(module));

            this._loadedPlugins.Add(module);
        }
    }
}