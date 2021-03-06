﻿using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using VL.Core;
using VL.Core.CompilerServices;
using VL.Lib.Basics.Resources;

[assembly: AssemblyInitializer(typeof(VL.MediaFoundation.Initialization))]

namespace VL.MediaFoundation
{
    public sealed class Initialization : AssemblyInitializer<Initialization>
    {
        protected override void RegisterServices(IVLFactory factory)
        {
            if (!factory.HasService<NodeContext, IResourceProvider<Device>>())
            {
                factory.RegisterService<NodeContext, IResourceProvider<Device>>(nodeContext =>
                {
                    // One per entry point
                    return ResourceProvider.NewPooledPerApp(nodeContext, () => new Device(DriverType.Hardware, DeviceCreationFlags.BgraSupport | DeviceCreationFlags.VideoSupport));
                });
            }
        }
    }
}
