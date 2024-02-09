using Microsoft.AspNetCore.Components;
using Shared.Models;
using src.Client.Services;

namespace src.Client.Pages;

public partial class Drivers
{
    [Inject]
    private IDriverService driverService { get; set; }
    public IEnumerable<Driver> _drivers { get; set; } = new List<Driver>();
    protected async override Task OnInitializedAsync()
    {
        var apiDrivers = await driverService.All();
        if (apiDrivers is not null && apiDrivers.Any())
            _drivers = apiDrivers;
    }
}