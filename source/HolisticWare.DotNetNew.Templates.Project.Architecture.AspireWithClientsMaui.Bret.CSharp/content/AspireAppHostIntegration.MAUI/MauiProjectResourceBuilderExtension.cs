﻿using System.Net.Sockets;
using Aspire.Hosting;
using Aspire.Hosting.Publishing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Aspire.Hosting;

public static class MauiProjectResourceBuilderExtension
{
    /// <summary>
    /// Adds a .NET project to the application model. 
    /// </summary>
    /// <param name="builder">The <see cref="IDistributedApplicationBuilder"/>.</param>
    /// <param name="name">The name of the resource. This name will be used for service discovery when referenced in a dependency.</param>
    /// <param name="projectDirectory">The path to the project file.</param>
    /// <returns>A reference to the <see cref="IResourceBuilder{ProjectResource}"/>.</returns>
    public static IResourceBuilder<ProjectResource> AddMauiProject(this IDistributedApplicationBuilder builder, string name, string projectDirectory,
        string settingsFileName = "AspireAppSettings.g.cs")
    {
        string settingsPath = NormalizePathForCurrentPlatform(Path.Combine(builder.AppHostDirectory, projectDirectory, settingsFileName));
        string mauiAppHostPath = NormalizePathForCurrentPlatform(Path.Combine(builder.AppHostDirectory, "../Aspire.MAUIAppHost/Aspire.MAUIAppHost.csproj"));

        return builder.AddProject(name, "../Aspire.MAUIAppHost/Aspire.MAUIAppHost.csproj")
           .WithEnvironment(context =>
           {
               context.EnvironmentVariables.Add("ASPIRE_SETTINGS_PATH", settingsPath);
           });
    }

    private static string NormalizePathForCurrentPlatform(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return path;
        }

        // Fix slashes
        path = path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);

        return Path.GetFullPath(path);
    }
}
