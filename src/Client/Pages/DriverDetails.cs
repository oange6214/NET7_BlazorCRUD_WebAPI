using Microsoft.AspNetCore.Components;
using Shared.Models;
using src.Client.Services;

namespace src.Client.Pages;

public partial class DriverDetails
{
    protected string Message = string.Empty;
    protected Driver driver { get; set; } = new Driver();

    [Parameter]
    public string Id { get; set; }
    
    [Inject]
    private IDriverService driverService { get; set; }

    [Inject]
    private NavigationManager navigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // Adding a new driver
        }
        else
        {
            // Updating a new driver
            var driverId = Convert.ToInt32(Id);

            var apiDriver = await driverService.GetDriver(driverId);

            if (apiDriver is not null)
                driver = apiDriver;
        }
    }

    protected void HandleFailedRequest()
    {
        Message = "Something went wrong, form not submited.";
    }

    protected void GoToDrivers()
    {
        navigationManager.NavigateTo("/Drivers");
    }

    protected async Task DeleteDriver()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            var driverId = Convert.ToInt32(Id);
            var result = await driverService.Delete(driverId);

            if (result)
                navigationManager.NavigateTo("/Drivers");
            else
                Message = "Something went wrong, driver not deleted : ( )";
        }
    }

    protected async void HandleValidRequest()
    {
        if (string.IsNullOrEmpty(Id))
        {
            // Add driver
            var result = await driverService.AddDriver(driver);

            if (result != null)
                navigationManager.NavigateTo("/Drivers");
            else
                Message = "Something went wrong, driver not added :( )";
        }
        else
        {
            // Update driver
            var result = await driverService.Update(driver);

            if (result)
                navigationManager.NavigateTo("/Drivers");
            else
                Message = "Something went wrong, driver not updated :( )";
        }
    }
    
}