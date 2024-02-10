using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Register your appsettings.json config file
IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .AddJsonFile
                                                        (
                                                            Path.Combine("Properties", "appsettings.json"), 
                                                            optional: true, 
                                                            reloadOnChange: true
                                                        )
                                                    .Build();

// Create a service provider registering the service discovery and HttpClient extensions
ServiceProvider provider = new ServiceCollection()
                                        .AddServiceDiscovery()
                                        .AddHttpClient()
                                        .AddSingleton<IConfiguration>(configuration)
                                        .ConfigureHttpClientDefaults
                                            (
                                                static http =>
                                                {
                                                    // Configure the HttpClient to use service discovery
                                                    http.UseServiceDiscovery();
                                                }
                                            )
                                        .BuildServiceProvider();

// Grab a new client from the service provider
HttpClient client = provider.GetService<HttpClient>()!;

// Call an API called `apiservice` using service discovery
HttpResponseMessage response = await client.GetAsync("http://apiservice/weatherforecast");
string body = await response.Content.ReadAsStringAsync();

Console.WriteLine(body);